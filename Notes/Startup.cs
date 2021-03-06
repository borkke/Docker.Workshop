﻿using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notes.Data;
using Notes.Services;
using Swashbuckle.AspNetCore.Swagger;

namespace Notes
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
	        services.AddDbContext<NotesContext>(options =>
	        {
		        options.UseSqlServer(Configuration.GetConnectionString("NotesContext"));
	        });
            services.AddCors(o => o.AddPolicy("policy", builder =>
            {
                builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
			services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
	        services.AddSwaggerGen(c =>
	        {
		        c.SwaggerDoc("v1", new Info { Title = "Notes API", Version = "v1" });
	        });
	        services.AddHttpClient<UserApiClient>(client => client.BaseAddress = new Uri("http://usersapi/api/"));
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
                app.UseHsts();
            }

            app.UseCors("policy");
            
            app.UseHttpsRedirection();

	        app.UseSwagger();
	        app.UseSwaggerUI(c =>
	        {
		        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Notes API");
	        });
			app.UseMvc();
        }
    }
}
