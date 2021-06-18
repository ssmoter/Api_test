using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;


namespace DataLibrary
{
    public class DowloandSendApi : IDowloandSendApi
    {
        private string url { get; set; } = ("https://localhost:44349/api/GarageModels");
        public async Task<List<GarageModel>> DowloandGarageModel()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(url))
                    {
                        using (var content = response.Content)
                        {
                            var result = await content.ReadAsStringAsync();
                            List<GarageModel> garage = JsonConvert.DeserializeObject<List<GarageModel>>(result);
                            return garage;
                        }
                    }
                }
            }
            catch (HttpRequestException)
            {

                return null;
            }
        }
        public async Task<GarageModel> DowloandCorrectGarageModel(int id)
        {
            try
            {
                string Url = url + "/" + id;
                using (var client = new HttpClient())
                {
                    using (var response = await client.GetAsync(Url))
                    {
                        using (var content = response.Content)
                        {
                            var result = await content.ReadAsStringAsync();
                            GarageModel garage = JsonConvert.DeserializeObject<GarageModel>(result);
                            return garage;
                        }
                    }
                }

            }
            catch (HttpRequestException)
            {

                return null;
            }
        }
        public string UploadGarageModel(GarageModel garage)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var uri = new Uri(url + "/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    var postTask = client.PostAsJsonAsync(uri, garage);
                    postTask.Wait();
                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return result.StatusCode.ToString();
                    }
                    else
                    {
                        return "failed ";
                    }
                }
            }
            catch (HttpRequestException ex)
            {
                return "failed " + ex.ToString();
            }
        }
        public string DeleteGarageModel(int id)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(url + "/");
                client.DefaultRequestHeaders.Accept.Clear();
                var DeleteTask = client.DeleteAsync(id.ToString());
                DeleteTask.Wait();

                var result = DeleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return "Delete";
                }
            }

            return "failed";
        }

        public string PutGarageModel(int ID,GarageModel garage)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    var uri = new Uri(url + "/" + ID);

                    client.DefaultRequestHeaders.Accept.Clear();
                    var PutTask = client.PutAsJsonAsync(uri, garage);
                    PutTask.Wait();
                    var result = PutTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return result.StatusCode.ToString();
                    }
                    else
                    {
                        return "failed";
                    }
                }
            }
            catch (HttpRequestException ex)
            {

                return ex.ToString();
            }
        }

    }
}