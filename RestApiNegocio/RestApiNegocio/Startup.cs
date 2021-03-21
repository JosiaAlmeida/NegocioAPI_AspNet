using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestApiNegocio.Models.Context;
using RestApiNegocio.Repositorio;
using RestApiNegocio.Repositorio.Implementação;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestApiNegocio
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public IWebHostEnvironment Environment { get; }
        public Startup(IConfiguration configuration, IWebHostEnvironment environment)
        {
            Configuration = configuration;
            Environment = environment;
            Log.Logger = new LoggerConfiguration().WriteTo.Console().CreateLogger();
        }


        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Autenticação
            services.AddCors();
            services.AddControllers();

            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });
            //Conexão com Mysql
            var connection = Configuration["MysqlConnection:MysqlConnectionString"];
            services.AddDbContext<MysqlContext>(opt=> opt.UseMySql(connection));
            //Migration
            if (Environment.IsDevelopment())
            {
                Migration(connection);
            }

            //Swagger
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "RestApiNegocio", Version = "v1" });
            });
            //Injeção de dependencia
            services.AddScoped<IBook, BookImplementation>();
            services.AddScoped<ICuddly, CuddlyImplementation>();
        }

        private void Migration(string connection)
        {
            try
            {
                var envolveConnection = new MySql.Data.MySqlClient.MySqlConnection(connection);
                var Evolve = new Evolve.Evolve(envolveConnection, msg => Log.Information(msg))
                {
                    Locations = new List<string> { "Migrates/migration", "Migrates/dataset" },
                    IsEraseDisabled = true
                };
                Evolve.Migrate();
            }
            catch (Exception ex)
            {
                Log.Error("Falha na migration ", ex);
                throw;
            }
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "RestApiNegocio v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(x=> x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
