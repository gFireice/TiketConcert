using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using TiketConcert.Model;
using TiketConcert.Class;


namespace TiketConcert.Api
{
    public class ApiControler
    {
        public static HttpClient client = new HttpClient();

        public async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://95.165.143.19:8085/api/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        public async Task<AuthUser> Authorization(AuthUserNow user)
        {
            AuthUser authUser = null;
            HttpResponseMessage response = await client.PostAsJsonAsync("auth/login", user);
            if (response.IsSuccessStatusCode)
            {
                authUser = await response.Content.ReadAsAsync<AuthUser>();
            }
            else
            {
                authUser = await response.Content.ReadAsAsync<AuthUser>();
            }
            return authUser;
        }

        public async Task<List<Concert>> GetAllConcrt()
        {
            List<Concert> concert = null;
            HttpResponseMessage response = await client.GetAsync($"concert");
            concert = await response.Content.ReadAsAsync<List<Concert>>();

            return concert;
        }

        public byte[] GetImage(string path)
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    byte[] data = webClient.DownloadData($"http://95.165.143.19:8085/api/uploads/{path}");
                    return data;
                }
                catch (WebException)
                {
                    return new byte[0];
                }
            }
        }
    }
}