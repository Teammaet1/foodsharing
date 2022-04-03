using FoodSharing.Service;
using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FoodSharing
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            Configuration.Bind("Project", new Config());

            //services.AddTransient<IWordDocumentRepository, EFWordDocumentRepository>();
            //services.AddTransient<IWordTemplateRepository, EFWordTemplateRepository>(); 
            //services.AddTransient<IDocumentCategoryRepository, EFDocumentCategoryRepository>();
            //services.AddTransient<DataManager>();

            //services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString)); 

          

            services.AddIdentity<ApplicationUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders(); 


            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            app.UseDefaultFiles(); 
            app.UseStaticFiles(); 

            app.UseRouting(); 

            app.UseCookiePolicy(); 
            app.UseAuthentication(); 
            app.UseAuthorization(); 

            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers(); 
            });
        }
    }
}
