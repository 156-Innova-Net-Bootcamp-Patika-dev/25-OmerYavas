using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PatikaOdev3.Business.Absract;
using PatikaOdev3.Business.Concrete;
using PatikaOdev3.Business.Mapping.AutoMapperProfile;
using PatikaOdev3.Business.ValidationRules.FluentValidation.CategoryValidations;
using PatikaOdev3.DataAccess.Abstract;
using PatikaOdev3.DataAccess.Concrete.EntityFramework;

namespace PatikaOdev3.WebApi
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

            services.AddControllers()
                  .AddFluentValidation(config =>
                  {
                      config.RegisterValidatorsFromAssemblyContaining(typeof(CategoryAddValidation));
                      config.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                  }); ;
            services.AddAutoMapper(typeof(MapProfile));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PatikaOdev3.WebApi", Version = "v1" });
            });

            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDAL, EfCategoryRepository>();

            services.AddScoped<IArticleService, ArticleManager>();
            services.AddScoped<IArticleDAL, EfArticleRepository>();

            services.AddScoped<ICommentService, CommentManager>();
            services.AddScoped<ICommentDAL, EfCommentRepository>();

            services.AddScoped<IRoleService, RoleManager>();
            services.AddScoped<IRoleDAL, EfRoleRepository>();

            services.AddScoped<IUserService, UserManager>();
            services.AddScoped<IUserDAL, EfUserRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PatikaOdev3.WebApi v1"));
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
