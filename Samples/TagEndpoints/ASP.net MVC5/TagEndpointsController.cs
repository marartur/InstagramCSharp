﻿using InstagramCSharp;
using Newtonsoft.Json;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace InstagramCSharp_WebSample.Controllers
{
    public class TagEndpointsController : Controller
    {
        public async Task<object> GetRecentTaggedMediaAsync(string tag)
        {
            string clientId = "YOUR_CLIENT_ID";
            string accessToken = "A_VALID_ACCESS_TOKEN";
            
            InstagramClient client = new InstagramClient(clientId, accessToken);

            var recentTaggedMedia = await client.TagEndpoints.GetRecentTaggedMediaAsync(tag);

            //I use Json.NET for parsing the result
            var recentTaggedMediaJson = JsonConvert.DeserializeObject(recentTaggedMedia);

            //You can deserialize json result to one of the models in InstagramCSharp or to your custom model
            //var recentTaggedMediaJson = JsonConvert.DeserializeObject<MediaFeed>(recentTaggedMedia);

            return recentTaggedMediaJson;
        }   
	}
}