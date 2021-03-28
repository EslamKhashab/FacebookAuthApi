using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using TestFaceBook.FacebookService;

namespace TestFaceBook.Options
{
    public class FacebookAuthInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var facebookAuthSettings = new FacebookAuthSettings();
            configuration.Bind(nameof(FacebookAuthSettings), facebookAuthSettings);
            services.AddSingleton(facebookAuthSettings);
            services.AddHttpClient();
            services.AddTransient<IFacebookAuthService, FacebookAuthService>();
        }
    }
}
