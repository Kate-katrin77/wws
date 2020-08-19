using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ApiCall
{
    public class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var result = client.GetAsync("https://jsonplaceholder.typicode.com/comments?postId=49").GetAwaiter().GetResult();
            if (result.StatusCode != HttpStatusCode.OK)
            {
                throw new Exception($"Unable to reach out and get data: {result.ReasonPhrase}");
            }

            var responseJson = result.Content.ReadAsStringAsync().GetAwaiter().GetResult();
            var myObject = JsonConvert.DeserializeObject<List<Comments>>(responseJson);
            var x = myObject.FirstOrDefault(x => x.Id == 242);
            var text = JsonConvert.SerializeObject(x).ToString();
            string createText = text + Environment.NewLine;
            File.WriteAllText("text.txt", createText);

        }


    }
}
