using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MTGCore.Services;
using AutoMapper;
using MTGCore.Authentication.Identity;
using MTGCore.Configuration;
using MTGCore.Configuration.Interfaces;
using MTGCore.MtgClient.Api;
using MTGCore.Repository;
using MTGCore.Services.Decks;
using MTGCore.Services.Interfaces;

namespace MTGCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<RepoContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton<IAppConfiguration, AppConfiguration>();
            services.AddSingleton<IManaSymbolImageMap, ManaSymbolImageMap>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IRepoContext, RepoContext>();
            services.AddScoped<IManaCostConverter, ManaCostConverter>();
            services.AddScoped<IManaStringParser, ManaStringParser>();
            services.AddScoped<IManaSymbolFactory, ManaSymbolFactory>();
            services.AddScoped<IDeckService, DeckService>();
            services.RegisterRepository();
            services.RegisterMtgClient();

            services.AddDefaultIdentity<AppUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<RepoContext>();

            services.AddCors();
            
            // Auto Mapper Configurations
            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            var mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            
            app.UseStaticFiles();
            app.UseRouting();
            // TODO(CD): Env var this shit
            app.UseCors(builder => builder.WithOrigins("http://localhost:8080").AllowAnyMethod().AllowAnyHeader());

            // app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
