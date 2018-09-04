namespace Sales.Services
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Threading.Tasks;    
    using Common.Models;
    using Newtonsoft.Json;




    public class ApiService
    {
        public async Task<Response> GetList<T>(string UrlBase, string prefix, string controller)
        {
            try
            {
                var client = new HttpClient();
                client.BaseAddress = new Uri(UrlBase);
                var url = string.Format("{0}{1}", prefix, controller);
                var response = await client.GetAsync(url);
                //respuesta de datos
                var anwer = await response.Content.ReadAsStringAsync();
                ///serializar

                if (!response.IsSuccessStatusCode)
                {
                    return new Response
                    {
                        IsSuccess = false,
                        Message = anwer,
                    };
                }

                var list = JsonConvert.DeserializeObject<List<T>>(anwer);
                return new Response
                {
                    IsSuccess = true,
                    Result = list,

                };
            }
            catch (Exception ex)
            {
                return new Response
                {
                    IsSuccess = false,
                    Message = ex.Message,
                };

            }
        }
    }
}
