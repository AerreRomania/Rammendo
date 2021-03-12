using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Rammendo.Data.Repositories;
using Rammendo.Data.Repositories.Interfaces;

namespace Rammendo.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }
        
        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services) {
            services.AddControllers();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Latest);

            services.AddTransient<ILoginRepository, LoginRepository>();
            services.AddTransient<IRammendoImportRepository, RammendoImportRepository>();
            services.AddTransient<ITelliProdotiRepository, TelliProdotiRepository>();
            services.AddTransient<ITelliProdotiArticoloRepository, TelliProdotiArticoloRepository>();
            services.AddTransient<IRammendoClicksRepository, RammendoClicksRepository>();
            services.AddTransient<ICommessaDetailsReporsitory, CommessaDetailsRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => {
                endpoints.MapControllers();
            });
        }
    }
}
