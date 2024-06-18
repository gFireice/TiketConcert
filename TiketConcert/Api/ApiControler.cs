using System.Collections.Generic;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Threading.Tasks;
using System;
using TiketConcert.Model;
using Newtonsoft.Json;
using System.Linq;
using System.Windows.Controls;
using TiketConcert.Class;

namespace TiketConcert.Api
{
    public class ApiControler
    {
        public static HttpClient client = new HttpClient();

        public async Task RunAsync()
        {
            client.BaseAddress = new Uri("http://localhost:8085/api/");
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
            HttpResponseMessage response = await client.GetAsync("concert");
            concert = await response.Content.ReadAsAsync<List<Concert>>();

            return concert;
        }



        public byte[] GetImage(string path)
        {
            using (WebClient webClient = new WebClient())
            {
                try
                {
                    byte[] data = webClient.DownloadData($"http://localhost:8085/api/uploads/{path}");
                    return data;
                }
                catch (WebException)
                {
                    return new byte[0];
                }
            }
        }

        public async Task<List<Orderer>> GetOrderById(int clientId)
        {
            List<Orderer> orders = null;
            HttpResponseMessage response = await client.GetAsync($"order/{clientId}");
            if (response.IsSuccessStatusCode)
            {
                orders = await response.Content.ReadAsAsync<List<Orderer>>();
            }
            return orders;
        }

        public async Task<bool> CreateOrder( List<Concert> basket)
        {

            var tickets = AppData.basket
            .GroupBy(item => item.IDConcert)
            .Select(group => new TicketOrder
             {
             ticketId = group.Key,
             quantity = group.Count()
            }).ToList();

            var order = new Order
            {
                IDClient = TempData.IdUser,
                tickets = tickets
            };

            try
            {
                var response = await client.PostAsJsonAsync("order", order);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
 
                Console.WriteLine("Error creating order: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> AddConcert(Concert concert)
        {
            try
            {
                var response = await client.PostAsJsonAsync("concert", concert);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error adding concert: " + ex.Message);
                return false;
            }
        }

        public async Task<bool> UpdateConcert(int concertId, Concert concert)
        {
            try
            {
                var response = await client.PutAsJsonAsync($"concert/{concertId}", concert);
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error updating concert: " + ex.Message);
                return false;
            }
        }
        public async Task<bool> DeleteConcert(int concertId)
        {
            try
            {
                var response = await client.DeleteAsync($"concert/{concertId}");
                response.EnsureSuccessStatusCode();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error deleting concert: " + ex.Message);
                return false;
            }
        }
    }
       
}


