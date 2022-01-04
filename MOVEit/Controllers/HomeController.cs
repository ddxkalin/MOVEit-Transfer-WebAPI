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
        /// <summary>
        /// Log In with the user credentials to get the AuthToken that we need for uploading a file via the MOVEit API.
        /// </summary>
        /// <param name="userDTO">User Data Transfer Object with the grant_type, username and password.</param>bg
        /// <returns></returns>
        [HttpPost]
        [Route("token")]
        [Produces("application/json")]
        public async Task<IActionResult> Index([FromQuery] UserDTO userDTO)
        {

            using (var httpClient = new HttpClient())
            {
                HttpContent content = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("grant_type", userDTO.Grant_Type.ToString()),
                    new KeyValuePair<string, string>("username", userDTO.Username),
                    new KeyValuePair<string, string>("password", userDTO.Password)
                });

                httpClient.BaseAddress = new Uri(Common.Consts.Baseurl);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));

                HttpResponseMessage Response = await httpClient.PostAsync("token", content);

                var resultContent = Response.Content.ReadAsStringAsync().Result;
                TokenDTO tokenDTO = JsonConvert.DeserializeObject<TokenDTO>(resultContent);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", tokenDTO.access_token);

                httpClient.Dispose();

                return Ok(tokenDTO);
            }
        }
    }
}
