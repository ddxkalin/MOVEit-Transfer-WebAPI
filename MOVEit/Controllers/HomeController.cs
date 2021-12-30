using Microsoft.AspNetCore.Mvc;
using MOVEit.DTOs;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace MOVEit.Controllers
{
    [ApiController]
    [Route("api/v1/")]
    public class HomeController : ControllerBase
    {
        public string AccessToken { get; private set; }

        [HttpPost]
        [Route("token")]
        public async Task SignOnToHostAsync()
        {
            ///Remove Hardcoded Value
            var userDTO = new UserDTO
            {
                Grant_type = "password",
                Username = "interview.kalin.stoev",
                Password = "kStoev9316@"
            };

            var httpContent = new StringContent(
               JsonConvert.SerializeObject(userDTO),
               Encoding.UTF8,
               "application/x-www-form-urlencoded");

            var httpClient = new HttpClient();
            //httpClient.BaseAddress = new Uri("https://mobile-1.moveitcloud.com/api/v1/");

            var httpResponse = await httpClient.PostAsync("https://mobile-1.moveitcloud.com/api/v1/token", httpContent);
            var responseContent = await httpResponse.Content.ReadAsStringAsync();
            var token = JsonConvert.DeserializeObject<TokenDTO>(responseContent);

            httpClient.DefaultRequestHeaders.Authorization =                                                                       //AUTH
                    new AuthenticationHeaderValue("Bearer", token.AccessToken);                                                    //AUTH

            ///API Example Test
            //var httpResponseUser = await httpClient.GetAsync("https://mobile-1.moveitcloud.com/api/v1/users/self");                
            //var userResponseContent = await httpResponseUser.Content.ReadAsStringAsync();                                          
            //var folderDTO = JsonConvert.DeserializeObject<FolderDTO>(userResponseContent);

            var httpResponseFileIntoFolder = await httpClient.PostAsync("https://mobile-1.moveitcloud.com/api/v1/folders/825894166/files", httpContent);
        }
    }
}
