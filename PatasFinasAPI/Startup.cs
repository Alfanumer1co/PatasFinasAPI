using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using PatasFinasAPI.Models;

namespace PatasFinasAPI
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }
        public static string dbConnectionString { get; set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);

            services.AddDbContext<db_Patas_FinasContext>(options => options.UseSqlServer(Configuration.GetConnectionString("db_Patas_FinasConn")));
        }
    }
}
