using Newtonsoft.Json;

namespace DemoAzureServerless.Models {
    public class Trainer{
        public string FullName {get; set;}
        [JsonProperty("id")]      
        public string Id {get; set;}
        public int Rating {get; set;}
        public string Address {get; set;}
    }
}