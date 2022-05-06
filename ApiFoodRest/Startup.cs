using System;
using System.Threading.Tasks;
using Microsoft.Owin;
using Owin;
using Microsoft.Owin.Security.OAuth;
using System.Web.Http;
using System.Configuration;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//[assembly: OwinStartup(typeof(ApiFoodRest.Startup))]

namespace ApiFoodRest
{
    public class Startup
    {

        ////
        //public Startup(Configuration configuration)
        //{
        //    Configuration = configuration;
        //}

        //public IConfiguration Configuration { get; }

        //// This method gets called by the runtime. Use this method to add services to the container.
        //public void ConfigureServices(IServiceCollection services)
        //{
        //    services.AddMvc();
        //    services.Configure<MySettingsModel>(Configuration.GetSection("MySettings"));

        //    //Registered for Model wide validation purpose
        //    services.AddMvc(options =>
        //    {
        //        options.Filters.Add(typeof(ValidatorActionFilter));
        //    });

        //    // Register the Swagger generator, defining 1 or more Swagger documents
        //    services.AddSwaggerGen(c =>
        //    {
        //        c.DescribeAllEnumsAsStrings();
        //        c.DescribeAllParametersInCamelCase();
        //        //c.IncludeXmlComments(GetXmlCommentsPath());
        //        c.SwaggerDoc("v1", new Info
        //        {
        //            Version = "v1",
        //            Title = "CollectionAPI",
        //            Description = "Providus Collection API",
        //            TermsOfService = "None",
        //            //Contact = new Contact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com", Url = "www.talkingdotnet.com" }
        //            //License = new License() { Name = "License Terms", Url = "www.example.com" }
        //        });

        //    });
        //}

        ////

        public void Configuration(IAppBuilder app)
        {

            //if (env.IsDevelopment())
            //{
            //    app.UseDeveloperExceptionPage();
            //}

            ////For running from IIS        
            //app.UseSwaggerUI(c =>
            //{
            //    string swaggerJsonBasePath = string.IsNullOrWhiteSpace(c.RoutePrefix) ? "." : "..";
            //    c.SwaggerEndpoint($"{swaggerJsonBasePath}/swagger/v1/swagger.json", "CollectionAPI V1");

            //    //c.SwaggerEndpoint("/swagger/v1/swagger.json", "CollectionAPI V1");
            //    ////c.SwaggerEndpoint("v1/swagger.json", "CollectionAPI V1");
            //});

            //// Enable middleware to serve generated Swagger as a JSON endpoint.
            //app.UseSwagger();
            //app.UseMvc();

            // For more information on how to configure your application, visit /*http://go.microsoft.com/fwlink/?LinkID=316888*/

            //enabling cross sorigin platform
            app.UseCors(Microsoft.Owin.Cors.CorsOptions.AllowAll);
            var myProvider = new MyAuthorization_seevuce();
            OAuthAuthorizationServerOptions options = new OAuthAuthorizationServerOptions()
            {
                AllowInsecureHttp = true,
                TokenEndpointPath = new PathString("/token"),
                AccessTokenExpireTimeSpan = TimeSpan.FromDays(200),
                Provider = myProvider

            };
            app.UseOAuthAuthorizationServer(options);
            app.UseOAuthBearerAuthentication(new OAuthBearerAuthenticationOptions());

            HttpConfiguration config = new HttpConfiguration();
            WebApiConfig.Register(config);


        }
    }
}
