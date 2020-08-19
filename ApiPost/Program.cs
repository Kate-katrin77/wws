using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;

namespace ApiPost
{
    public class Program
    {
        private static readonly HttpClient client = new HttpClient();

        static void Main(string[] args)
        {
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            var postData = new Post
            {
                Id = 101,
                UserId = 99,
                Title = "dog",
                Body = "black"
            };

            var content = new StringContent(JsonConvert.SerializeObject(postData));
            var result = client.PostAsync("https://jsonplaceholder.typicode.com/posts", content).GetAwaiter().GetResult();
            if (result.StatusCode != HttpStatusCode.Created)
            {
                throw new Exception("Unable to create post");
            }
        }
    }
}
