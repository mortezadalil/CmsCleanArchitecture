using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Cms.Api.Presenters
{
    public sealed class JsonContentResult : ContentResult
    {
        public JsonContentResult()
        {
            ContentType = "application/json";
         
        }

        public string Serialize(object data)
        {
            return JsonConvert.SerializeObject(data,
                Newtonsoft.Json.Formatting.None, new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                });
        }
    }
}
