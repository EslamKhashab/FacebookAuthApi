using Newtonsoft.Json;

namespace TestFaceBook.FacebookService
{
    public class FacebookUserInfo
    {
        [JsonProperty("first_name")]
        public string FirstName { get; set; }

        [JsonProperty("last_name")]
        public string LastName { get; set; }

        [JsonProperty]
        public string Email { get; set; }

        [JsonProperty]
        public string Id { get; set; }

    }
}