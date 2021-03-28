using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TestFaceBook.FacebookService
{
    public interface IFacebookAuthService
    {
        Task<FacebookTokenValidationResult> ValidateAccessTokenAsync(string accessToken);
        Task<FacebookUserInfo> GetUserInfoAsync(string accessToken);

    }
}
