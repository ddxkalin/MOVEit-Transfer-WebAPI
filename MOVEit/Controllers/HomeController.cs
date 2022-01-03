using Microsoft.AspNetCore.Mvc;
using MOVEit.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MOVEit.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class HomeController : ControllerBase
    {
        const string Baseurl = "https://mobile-1.moveitcloud.com/api/v1/";

        /// <summary>
        /// Log In with the user credentials to get the AuthToken that we need for uploading a file via the MOVEit API.
        /// </summary>
        /// <param name="userDTO">User Data Transfer Object with the grant_type, username and password.</param>
        /// <returns></returns>
        [HttpPost]
        [Route("token")]
        public async Task<IActionResult> Index([FromQuery] UserDTO userDTO)
        {
            //var tokenDTO = new TokenDTO();

            using (var client = new HttpClient())
            {
                HttpContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", userDTO.Grant_type),
                    new KeyValuePair<string, string>("username", userDTO.Username),
                    new KeyValuePair<string, string>("password", userDTO.Password)
                });

                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                HttpResponseMessage Response = await client.PostAsync("token", content);
                
                var json = Response.Content.ReadAsStringAsync().Result;
                TokenDTO tokenDTO = JsonConvert.DeserializeObject<TokenDTO>(json.ToString());

                return Ok(json);
            }
        }

        ///<summary>
        /// The upload file method from the MOVEit API. Still Under development because of the /api/v1/token problems with the API.
        /// </summary>
        //[HttpPost]
        //[Route("folders/{FolderID}/files")]
        //public async Task<ActionResult> UploadFile([FromQuery] FolderItemDTO folderItemDTO, int FolderID)
        //{
        //    var tokenDTO = new TokenDTO();

        //    using (var client = new HttpClient())
        //    {
        //        HttpContent content = new FormUrlEncodedContent(new[]
        //        {
        //            new KeyValuePair<string, string>("ID", folderItemDTO.FolderID),
        //            new KeyValuePair<string, string>("file ", folderItemDTO.File),
        //            new KeyValuePair<string, string>("hash", folderItemDTO.Hash),
        //            new KeyValuePair<string, string>("hashtype", folderItemDTO.Hashtype),
        //            new KeyValuePair<string, string>("comments", folderItemDTO.Comments)
        //        });

        //        client.BaseAddress = new Uri(Baseurl);
        //        client.DefaultRequestHeaders.Clear();
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        //        client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
        //        client.DefaultRequestHeaders.Authorization =
        //            new AuthenticationHeaderValue("Bearer", tokenDTO.AccessToken);

        //        HttpResponseMessage Response = await client.PostAsync("token", content);
        //        if (Response.IsSuccessStatusCode)
        //        {

        //        }
        //        return Ok();
        //    }
        //}


    }
}
