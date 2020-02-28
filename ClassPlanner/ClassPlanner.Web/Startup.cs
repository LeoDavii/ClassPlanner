using AutoMapper;
using ClassPlanner.Application.Services.StudentClassService;
using ClassPlanner.Application.Services.StudentService;
using ClassPlanner.Application.Services.TeacherService;
using ClassPlanner.Application.Services.UserService;
using ClassPlanner.Application.Utils;
using ClassPlanner.Domain.Interfaces;
using ClassPlanner.Infra.Context;
using ClassPlanner.Infra.Repositories.StudentRepository;
using ClassPlanner.Infra.Repositories.StudentsClassRepository;
using ClassPlanner.Infra.Repositories.TeacherRepository;
using ClassPlanner.Infra.Repositories.UserRepository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using Microsoft.OpenApi.Models;
using System.IO;

namespace ClassPlanner.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<MainContext>(opt => opt.UseSqlServer(Configuration.GetConnectionString("ClassPlannerConnectionString")));
            services.AddScoped<IStudentsClassService, StudentsClassService>();
            services.AddScoped<IStudentsClassRepository, StudentsClassRepository>();
            services.AddScoped<IStudentService, StudentService>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<Notifications, Notifications>();
            services.AddScoped<Emails, Emails>();
            services.AddCors();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "ClassPlanner",
                        Version = "V1",
                        Description = "Class Planner for independent teachers",
                    });

                string ApplicationPath =
                    PlatformServices.Default.Application.ApplicationBasePath;
                string ApplicationName =
                    PlatformServices.Default.Application.ApplicationName;
                string xml =
                    Path.Combine(ApplicationPath, $"{ApplicationName}.xml");

                c.IncludeXmlComments(xml);
            });

            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });

            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);

        }
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

            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<MainContext>();
                context.Database.Migrate();
            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "ClassPlanner");
            });

            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseCors(option => option.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
        }

    }
}

