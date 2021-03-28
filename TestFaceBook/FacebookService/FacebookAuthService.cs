using Newtonsoft.Json;
using System;

using System.Net.Http;

using System.Threading.Tasks;
using TestFaceBook.Options;

namespace TestFaceBook.FacebookService
{
    public class FacebookAuthService : IFacebookAuthService
    {
        private const string TokenValidationUrl = "https://graph.facebook.com/debug_token?input_token={0}&access_token={1}|{2}";
        private const string UserInfoUrl = "https://graph.facebook.com/me?fields=first_name,last_name,email&access_token={0}";
        private readonly FacebookAuthSettings _facebookAuthSettings;
        private readonly IHttpClientFactory _httpClientFactory;
        public FacebookAuthService(FacebookAuthSettings facebookAuthSettings, IHttpClientFactory httpClientFactory)
        {
            _facebookAuthSettings = facebookAuthSettings;
            _httpClientFactory = httpClientFactory;
        }

        public async Task<FacebookUserInfo> GetUserInfoAsync(string accessToken)
        {
            var formatedurl = string.Format(UserInfoUrl, accessToken);
            var result = await _httpClientFactory.CreateClient().GetAsync(formatedurl);
            var responseAsString = await result.Content.ReadAsStringAsync();
            var finalResult = JsonConvert.DeserializeObject<FacebookUserInfo>(responseAsString);
            return finalResult;
        }

        public async Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken)
        {
            var formatedurl = string.Format(TokenValidationUrl, accessToken, _facebookAuthSettings.AppId, _facebookAuthSettings.AppSecret);
            var result = await _httpClientFactory.CreateClient().GetAsync(formatedurl);
            var responseAsString = await result.Content.ReadAsStringAsync();
            var finalResult = JsonConvert.DeserializeObject<FacebookTokenValidationResult>(responseAsString);
            return finalResult;
        }
    }
}
