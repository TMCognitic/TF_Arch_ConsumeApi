using ConsumeApi.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using STJ = System.Text.Json;

namespace ConsumeApi
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //using (HttpClient httpClient = new HttpClient())
            //{
            //    httpClient.BaseAddress = new Uri("https://localhost:7253/api/");

            //    using (HttpResponseMessage httpResponseMessage = httpClient.GetAsync("todo").Result)
            //    {
            //        //if(httpResponseMessage.IsSuccessStatusCode)
            //        //{
            //        //    //code
            //        //}

            //        //ou exclusif
            //        httpResponseMessage.EnsureSuccessStatusCode();

            //        string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            //        Console.WriteLine(json);

            //        //Désérialisation Microsoft
            //        IEnumerable<ToDo>? data = STJ.JsonSerializer.Deserialize<ToDo[]>(json, new STJ.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            //        if(data is not null)
            //        {
            //            foreach (ToDo toDo in data)
            //            {
            //                Console.WriteLine($"{toDo.Id:D4} : {toDo.Title}");
            //            }
            //        }

            //        //ou exclusif

            //        //Désérialisation Newtonsoft.Json
            //        IEnumerable<ToDo>? result = JsonConvert.DeserializeObject<ToDo[]>(json);

            //        if (result is not null)
            //        {
            //            foreach (ToDo toDo in result)
            //            {
            //                Console.WriteLine($"{toDo.Id:D4} : {toDo.Title}");
            //            }
            //        }
            //    }
            //}

            //using (HttpClient httpClient = new HttpClient())
            //{
            //    httpClient.BaseAddress = new Uri("https://localhost:7253/");

            //    int id = 2;

            //    using (HttpResponseMessage httpResponseMessage = httpClient.GetAsync($"api/todo/{id}").Result)
            //    {
            //        //if(httpResponseMessage.IsSuccessStatusCode)
            //        //{
            //        //    //code
            //        //}

            //        //ou exclusif
            //        httpResponseMessage.EnsureSuccessStatusCode();

            //        string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

            //        Console.WriteLine(json);

            //        //Désérialisation Microsoft
            //        ToDo? data = STJ.JsonSerializer.Deserialize<ToDo>(json, new STJ.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

            //        if (data is not null)
            //        {
            //            Console.WriteLine($"{data.Id:D4} : {data.Title}");
            //        }

            //        //ou exclusif

            //        //Désérialisation Newtonsoft.Json
            //        ToDo? result = JsonConvert.DeserializeObject<ToDo>(json);

            //        if (result is not null)
            //        {
            //            Console.WriteLine($"{result.Id:D4} : {result.Title}");
            //        }
            //    }
            //}

            //using (HttpClient httpClient = new HttpClient())
            //{
            //    httpClient.BaseAddress = new Uri("https://localhost:7253/");

            //    ToDo toDo = new ToDo() { Title = "Test 7" };

            //    HttpContent httpContent = new StringContent(STJ.JsonSerializer.Serialize(new { toDo.Title }));
            //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //    using (HttpResponseMessage httpResponseMessage = httpClient.PostAsync($"api/todo/", httpContent).Result)
            //    {
            //        //if(httpResponseMessage.IsSuccessStatusCode)
            //        //{
            //        //    //code
            //        //}

            //        //ou exclusif
            //        httpResponseMessage.EnsureSuccessStatusCode();
            //        Console.WriteLine("Création réussie!");
            //    }
            //}

            //using (HttpClient httpClient = new HttpClient())
            //{
            //    httpClient.BaseAddress = new Uri("https://localhost:7253/");

            //    ToDo toDo = new ToDo() { Id = 1002, Title = "Test 7 Bis", Done = true };

            //    HttpContent httpContent = new StringContent(STJ.JsonSerializer.Serialize(new { toDo.Title, toDo.Done }));
            //    httpContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            //    using (HttpResponseMessage httpResponseMessage = httpClient.PutAsync($"api/todo/{toDo.Id}", httpContent).Result)
            //    {
            //        //if(httpResponseMessage.IsSuccessStatusCode)
            //        //{
            //        //    //code
            //        //}

            //        //ou exclusif
            //        httpResponseMessage.EnsureSuccessStatusCode();
            //        Console.WriteLine("Mise à jour réussie!");
            //    }
            //}

            using (HttpClient httpClient = new HttpClient())
            {
                httpClient.BaseAddress = new Uri("https://localhost:7253/");

                ToDo toDo = new ToDo() { Id = 1002, Title = "Test 7 Bis", Done = true };

                using (HttpResponseMessage httpResponseMessage = httpClient.DeleteAsync($"api/todo/{toDo.Id}").Result)
                {
                    //if(httpResponseMessage.IsSuccessStatusCode)
                    //{
                    //    //code
                    //}

                    //ou exclusif
                    //httpResponseMessage.EnsureSuccessStatusCode();
                    if (httpResponseMessage.IsSuccessStatusCode)
                    {
                        Console.WriteLine("Suppression réussie!");

                        string json = httpResponseMessage.Content.ReadAsStringAsync().Result;

                        Console.WriteLine(json);

                        //Désérialisation Microsoft
                        ToDo? result = STJ.JsonSerializer.Deserialize<ToDo>(json, new STJ.JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                        if (result is not null)
                        {
                            Console.WriteLine($"{result.Id:D4} : {result.Title}");
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Aucune donnée supprimée {httpResponseMessage.StatusCode}");
                    }                                      
                }
            }
        }
    }
}