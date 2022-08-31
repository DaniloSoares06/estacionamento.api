using Estacionamento.API.Contexto;
using Estacionamento.API.Repositorio;
using Estacionamento.API.Servicos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
namespace Estacionamento.API
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
			services.AddDbContext<EstacionamentoContexto>(opts => opts.UseLazyLoadingProxies().UseMySQL(Configuration.GetConnectionString("EstacionamentoConnection")));

			services.AddControllers();
			services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
			services.AddSwaggerGen(c =>
			{
				c.SwaggerDoc("v1", new OpenApiInfo { Title = "Estacionamento.API", Version = "v1" });
			});

			services.AddScoped<PatioServico, PatioServico>();
			services.AddScoped<VeiculoServico, VeiculoServico>();
			services.AddScoped<PatioRepositorio, PatioRepositorio>();
			services.AddScoped<VeiculoRepositorio, VeiculoRepositorio>();
			services.AddScoped<VeiculoPatioRepositorio, VeiculoPatioRepositorio>();
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
				app.UseSwagger();
				app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estacionamento.API v1"));
			}

			app.UseHttpsRedirection();

			app.UseRouting();

			app.UseAuthorization();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
