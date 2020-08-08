using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using myApp.Models;
using myApp.Models.Repositry;
using myApp.Security;

namespace myApp
{
    public class Startup
    {
        private IConfiguration _config;

        public Startup(IConfiguration config)
        {
            _config = config;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Adding Localization Service
            services.AddLocalization(opts => {
                opts.ResourcesPath = "Resources";
            });

            //Add Mvc To Dependency Injection Container
            services.AddMvc().AddViewLocalization(opts => { opts.ResourcesPath = "Resources"; })
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                    .AddDataAnnotationsLocalization();

            //Localization Configuration
            services.Configure<RequestLocalizationOptions>(opts => {
                var supportedCultures = new List<CultureInfo> {
                    new CultureInfo("en"),
                    new CultureInfo("en-US"),
                    new CultureInfo("fr"),
                    new CultureInfo("ru"),
                    new CultureInfo("ja"),
                    new CultureInfo("fr-FR"),
                    new CultureInfo("zh-CN"),   // Chinese China
                    new CultureInfo("ar"),   // Arabic Egypt
                  };

                opts.DefaultRequestCulture = new RequestCulture("en-US");
                // Formatting numbers, dates, etc.
                opts.SupportedCultures = supportedCultures;
                // UI strings that we have localized.
                opts.SupportedUICultures = supportedCultures;
            });

            //Add Enttityfraework To Serices
            services.AddDbContextPool<DB>(options => options.UseSqlServer(_config.GetConnectionString("DB")));

            //Add Singleton (Memory)
            //services.AddSingleton<IEmployeeRepositry, MemoryEmployeeRepositry>();

            //Add Scoped (DB)
            services.AddScoped<IEmployeeRepositry, DBEmployeeRepositry>();

            //Adding Default System Identity 
            //Adding Default Token Provider For Create Tokens
            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DB>()
                .AddDefaultTokenProviders()
                //Add Custom Token Provider
                .AddTokenProvider<EmailConfirmationTokenProvider<IdentityUser>>("ConfirmEmail");

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                //options.SignIn.RequireConfirmedEmail = true;
                // options.User.RequireUniqueEmail = true;
                options.Tokens.EmailConfirmationTokenProvider = "ConfirmEmail";


                //LockOut Account Data
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(1);
            });

            //Configure Options For Token provider
            services.Configure<DataProtectionTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromDays(2);
            });
            //Configure Options For Token provider For Email Confirmation
            services.Configure<EmailConfirmationTokenProviderOptions>(options =>
            {
                options.TokenLifespan = TimeSpan.FromHours(10);
            });
            

            services.AddAuthentication().AddGoogle(options =>
            {
                options.ClientId = "220322720848-hqflhgbioq7p5v8p9d8res6kcmfjj87s.apps.googleusercontent.com";
                options.ClientSecret = "ZLhoT1zB7cqHc_GXYwseOcoy";
            }).AddFacebook(options =>
            {
                options.ClientId = "1087979261578413";
                options.ClientSecret = "390236394af00e7b4f779adce808c427";
            });


            services.AddAuthorization(options =>
            {
                //Policy for CRUD Role
                options.AddPolicy("CUDRole",
                     policy => policy.RequireClaim("CreateRole")
                                     .RequireClaim("EditRole")
                                     .RequireClaim("DeleteRole"));
                //Policy for Users
                options.AddPolicy("Users", policy => policy.RequireClaim("User"));

                //Custom Policy
                options.AddPolicy("test", policy => policy.RequireAssertion(context =>               
                context.User.HasClaim(claim=>claim.Type=="User")&&context.User.IsInRole("Admin")
                ));

                //Custom Authentication Requirments
                options.AddPolicy("testCustom", policy => policy.AddRequirements(new Requirment()));
            });

            services.AddSingleton<IAuthorizationHandler, RequirmentHandler>();


            // For Change Default Login & LogOut & AccessDenied Default Path
            /*
            services.ConfigureApplicationCookie(options =>
            {
                options.AccessDeniedPath = new PathString("/Adminstaration/AccessDenied");
            });
            */
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                //This Middleware For Manage Exceptions Page
                DeveloperExceptionPageOptions op = new DeveloperExceptionPageOptions
                {
                    SourceCodeLineCount=20
                };
                app.UseDeveloperExceptionPage(op);
            }
            else        
            {
                app.UseExceptionHandler("/Home/ErrorGlobal");       //Handle Exceptions

                //app.UseStatusCodePages();                           //Default Error Page
                //app.UseStatusCodePagesWithRedirects("/Error/{0}");    //Redirect To Error Action And Pass Error Code
                //app.UseStatusCodePagesWithReExecute("/Error/{0}");  //Show Error Page Content Without Change URL

            }


            #region Files Middlewares

            //All Files Must Be In wwwroot Folder

            //app.UseDefaultFiles();  //Make Default Files [index.htm or index.html or default.htm default.html] the Home Page
            app.UseStaticFiles();   //Configure Files
            //app.UseDirectoryBrowser();  //Configure Folders

            //Add test.html as The Default Home Page
            /*
            DefaultFilesOptions options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("test.html");
            app.UseDefaultFiles(options);
            app.UseStaticFiles();
            /*

            //Add test.html as The Default Home Page In UseFileServer Middleware
            //Usefileserver Middleware = UseDefaultFiles + UseStaticFiles + UseDirectoryBrowser
            /*
            FileServerOptions optionsfileserver = new FileServerOptions();
            optionsfileserver.DefaultFilesOptions.DefaultFileNames.Clear();
            optionsfileserver.DefaultFilesOptions.DefaultFileNames.Add("test.html");
            app.UseFileServer(optionsfileserver);
            */
            #endregion

            //Add Authentication Middleware To Pipline
            app.UseAuthentication();


            //Add Mvc Middleware With Default Route [{Controller=Home}/{Action=Index}/{id?}]
            //app.UseMvcWithDefaultRoute();


            //Add Localization MiddleWare
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);

            //Add Mvc With custom default Routing
            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "{controller=Home}/{Action=index}/{id?}");
            });

            //This Middleware Use When Use Attribute Routing
            //app.UseMvc();

            #region Middlewares
            //app.Use(async (context, next) =>
            //{
            //    //Request Middleware Code
            //    await context.Response.WriteAsync("MiddleWare 1 Request");
            //    //Next Function To Excute Next Middleware
            //    await next();
            //    //Respone Middleware Code
            //    await context.Response.WriteAsync("MiddleWare 1  Response");
            //});


            ////Terminal Middleware(Not Has Next)تعتبر اخر ميدلوير لانها لا تعمل تنفيذ للتي بعدها
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("MiddleWare 2");
            //    //await context.Response.WriteAsync(_config["Name"]);
            //    //await context.Response.WriteAsync(System.Diagnostics.Process.GetCurrentProcess().ProcessName);
            //});
            #endregion
        }
    }
}
