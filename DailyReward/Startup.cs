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
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;

namespace Acaplay365
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
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);


			// Register the Swagger generator, defining 1 or more Swagger documents
			// Add Swagger
			if (Configuration.GetValue<bool>("EnableSwagger"))
			{
				services.AddSwaggerGen(c =>
				{
					c.SwaggerDoc("v1", new Info
					{
						Version = "v1",
						Title = "Acaplay 365 API",
						Description = "Acaplay 365 API",
						TermsOfService = "None",
						Contact = new Contact() { Name = "Tung Nguyen", Email = "tunga4k41@gmail.com" }
					});
				});
			}
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env)
		{
			if (env.IsDevelopment())
			{
				app.UseDeveloperExceptionPage();
			}
			else
			{
				// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
				app.UseHsts();
			}

			if (Configuration.GetValue<bool>("EnableSwagger"))
			{
				app.UseSwagger();
				app.UseSwaggerUI(c =>
				{
					c.SwaggerEndpoint("/swagger/v1/swagger.json", "Acaplay 365 V1");
				});
			}

			app.UseHttpsRedirection();
			app.UseMvc();
		}
	}
}
