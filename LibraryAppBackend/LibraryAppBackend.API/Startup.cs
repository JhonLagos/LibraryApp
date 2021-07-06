using LibraryAppBackend.Business;
using LibraryAppBackend.Business.Interfaces;
using LibraryAppBackend.Repository;
using LibraryAppBackend.Repository.Interfaces;
using LibraryAppBackend.Transversal.Response;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Linq;
using System.Net;

namespace LibraryAppBackend.API
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
            services.AddCors();

            services.AddControllers()
                .ConfigureApiBehaviorOptions(options =>
                {
                    options.InvalidModelStateResponseFactory = actionContext =>
                    {
                        return CustomErrorResponse(actionContext);
                    };
                });

            services.AddDbContext<LibraryAppContext>(
                options =>
                    options.UseSqlServer(Configuration.GetConnectionString("LibraryAppConnection"), x => x.MigrationsAssembly("LibraryAppBackend.Repository"))
            );

            // Repository
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IEditorialRepository, EditorialRepository>();
            services.AddScoped<IBookRepository, BookRepository>();

            // Business
            services.AddScoped<IAuthorBusiness, AuthorBusiness>();
            services.AddScoped<IEditorialBusiness, EditorialBusiness>();
            services.AddScoped<IBookBusiness, BookBusiness>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseCors(x => x
               .AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        private BadRequestObjectResult CustomErrorResponse(ActionContext actionContext)
        {
            if (actionContext is null)
            {
                throw new System.ArgumentNullException(nameof(actionContext));
            }

            var errors = actionContext.ModelState
                 .Where(modelError => modelError.Value.Errors.Count > 0)
                 .Select(modelError => new ErrorWrapper
                 {
                     Field = modelError.Key,
                     Description = modelError.Value.Errors.FirstOrDefault().ErrorMessage
                 }).ToList();

            var result = new ResultWrapper(HttpStatusCode.BadRequest, "Se produjeron uno o más errores de validación.")
            {
                Errors = errors
            };

            return new BadRequestObjectResult(result);
        }
    }
}
