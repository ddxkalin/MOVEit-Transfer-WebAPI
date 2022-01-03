using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOVEit.DTOs;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace MOVEit.Controllers
{
    [ApiController]
    [Route("api/v1/folders/{id}/files")]
    public class UploadController : ControllerBase
    {
        const string Baseurl = "https://mobile-1.moveitcloud.com/api/v1/";

        /// <summary>
        /// The upload file method from the MOVEit API. Still Under development!
        /// </summary>
        /// <param name="file">IFormFile type</param>
        /// <param name="folderItemDTO">Passing the DTOs</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file, [FromQuery] FolderItemDTO folderItemDTO)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Baseurl);
                httpClient.DefaultRequestHeaders.Clear();
                MultipartFormDataContent form = new MultipartFormDataContent();

                HttpResponseMessage response = await httpClient.PostAsync($"{folderItemDTO.FolderID}/files", form);

                response.EnsureSuccessStatusCode();
                httpClient.Dispose();
                string sd = response.Content.ReadAsStringAsync().Result;
            }

            return Ok("2");
        }
    }
}