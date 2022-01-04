using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOVEit.DTOs;
using System;
using System.IO;
using System.Net.Http;

namespace MOVEit.Controllers
{
    [ApiController]
    [Authorize]
    [Route("api/v1/folders/")]
    public class UploadController : Controller
    {
        const string Baseurl = "https://mobile-1.moveitcloud.com/api/v1/";

        /// <summary>
        /// The upload file method from the MOVEit API. Still Under development!
        /// </summary>
        /// <param name="file">IFormFile type</param>
        /// <param name="folderItemDTO">Passing the DTOs</param>
        /// <param name="inputFile">IFormFile type for uploading the file</param>
        /// <returns></returns>
        [HttpPost]
        [Route("{id}/files")]
        [Produces("application/json")]
        [Consumes("multipart/form-data")]       
        public JsonResult Upload(IFormFile inputFile, [FromForm] FolderItemDTO folderItemDTO)
        {
            var Form = HttpContext.Request.Form;
            var File = Form.Files[0];
            var FileName = Form["fileName"][0];
            var Dest = Form["dest"][0];
            var ChunkIndex = int.Parse(Form["chunkIndex"]);
            var loc = "d://";
            var ChunkSize = 2 * 1024 * 1024;                //chunk Size

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);
                httpClient.DefaultRequestHeaders.Clear();
                MultipartFormDataContent form = new MultipartFormDataContent();

                var response = httpClient.PostAsync($"{folderItemDTO.ID}/files", form);

                httpClient.Dispose();
                string sd = response.Result.Content.ReadAsStringAsync().Result;
            }


            if (File.Length > 200 * 1024 * 1024)            //Max File Size = 200MB
            {
                return Json(StatusCodes.Status403Forbidden);
            }

            //If file not exist and request form tell us that is the first file part
            else if (!System.IO.File.Exists(Dest + FileName) && ChunkIndex == 0)
            {
                using (var ms = new MemoryStream())
                {
                    File.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    using (var output = System.IO.File.Create(loc + Dest + FileName))
                    {
                        output.Write(fileBytes, 0, (int)File.Length);
                    }
                }
            }

            //If file exist and request form tell us that is not the first file part and we should attack this file to the prev uploaded parts
            else
            {
                using (var ms = new MemoryStream())
                {
                    File.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    using (var output = System.IO.File.OpenWrite(loc + Dest + FileName))
                    {
                        output.Position = ChunkIndex * (ChunkSize);
                        output.Write(fileBytes, 0, (int)File.Length);
                    }
                }
            }
            return Json(StatusCodes.Status200OK);
        }


        //public async Task<IActionResult> Upload([FromQuery] FolderItemDTO folderItemDTO)
        //{
        //    using (HttpClient httpClient = new HttpClient())
        //    {
        //        httpClient.BaseAddress = new Uri(Baseurl);
        //        httpClient.DefaultRequestHeaders.Clear();
        //        MultipartFormDataContent form = new MultipartFormDataContent();

        //        HttpResponseMessage response = await httpClient.PostAsync($"{folderItemDTO.FolderID}/files", form);

        //        response.EnsureSuccessStatusCode();
        //        httpClient.Dispose();
        //        string sd = response.Content.ReadAsStringAsync().Result;
        //    }

        //    return Ok("2");
        //}
    }
}