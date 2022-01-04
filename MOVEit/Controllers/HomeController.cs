using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOVEit.DTOs;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MOVEit.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class HomeController : ControllerBase
    {
        ///hardcoded...ew & when AccessToken expires, you have to add it again here...
        public string AccessToken = "a9-KyC2eQDcClsshnRuA5IRxkPB4S0WF4h2ozmuGU62k88qpB0QTP8aTzzqp4Ra2gzbTA7H4yQr2nk6xL4-XwiCNwgqyEud3wu_w1Y3s_CioL23L7W8aPUKHn3He9dRQ11hxuc5bZebIbHiqd_gBxsmLd96lqtXwCvVGJUhc8KQX4YoxbzctXvSYKFsXAoawGhC8w6DQjhPsh60O0pAMNWPHFSFAjdH5Dzw3HUg4RfThCjAxjBNaAScFykcTG7tufOtQpxCaOfOhxf6rovrISIG8qLs_Vrb-B-eebgrpxGJE2JbMk6O1sjRqILvSvZcTThgrX3EZvsOsD116_FW5Qw";

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
                AccessToken = tokenDTO.access_token;
                httpClient.Dispose();

                return Ok(tokenDTO);            ///Remove status code OK alltime..
            }
        }

        /// <summary>
        /// Uploading file to MOVEit API
        /// </summary>
        /// <param name="File">IFormFile type</param>
        /// <param name="folderItemDTO">FolderItem Data transfer objects</param>
        /// <returns></returns>
        [HttpPost]
        [Route("folders/{id}/files")]
        public async Task<IActionResult> UploadFile(IFormFile File,
                                                    [FromQuery] FolderItemDTO folderItemDTO)
        {
            FileItemDTO fileItemDTO = new FileItemDTO();
            fileItemDTO.folderID = "825894166";         ///hardcoded only for tests atm

            Dictionary<string, string> parameters = new Dictionary<string, string>();
            parameters.Add("hashtype", folderItemDTO.hashtype);
            parameters.Add("hash", folderItemDTO.hash);
            parameters.Add("comments", folderItemDTO.comments);

            HttpContent DictionaryItems = new FormUrlEncodedContent(parameters);

            using (var httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri(Common.Consts.Baseurl);
                httpClient.DefaultRequestHeaders.Clear();
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", AccessToken);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                using (var form = new MultipartFormDataContent())
                {
                    using (var fs = File.OpenReadStream())
                    {
                        using (var streamContent = new StreamContent(fs))
                        {
                            HttpResponseMessage response = await httpClient.PostAsync($"folders/{fileItemDTO.folderID}/files", DictionaryItems);
                            var resultContent = response.Content.ReadAsStringAsync().Result;
                            fileItemDTO = JsonConvert.DeserializeObject<FileItemDTO>(resultContent);
                            httpClient.Dispose();

                            return Ok(fileItemDTO);         ///Remove status code OK alltime..
                        }
                    }
                }
            }
        }
    }
}
