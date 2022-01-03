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
            using (var httpClient = new HttpClient())
            {
                HttpContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", userDTO.Grant_type),
                    new KeyValuePair<string, string>("username", userDTO.Username),
                    new KeyValuePair<string, string>("password", userDTO.Password)
                });

                httpClient.BaseAddress = new Uri(Baseurl);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                HttpResponseMessage Response = await httpClient.PostAsync("token", content);
                
                var json = Response.Content.ReadAsStringAsync().Result;
                TokenDTO tokenDTO = JsonConvert.DeserializeObject<TokenDTO>(json.ToString());
                var result = json.Split(new string[] { "\\t", "\\n" }, StringSplitOptions.None);        ///Half Helpful..

                httpClient.Dispose();

                return Ok(json);
            }
        }
    }
}
