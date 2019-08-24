using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPiServer;
using EPiServer.Core;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using testEpiCore.EpiServer;

namespace testEpiCore
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            //var epi = new EpiServerInitialize();
            //services.AddSingleton<IEpiServerInitialize, EpiServerInitialize>();
            var epiCore = new EpiServerInitialize();
            services.Add(new ServiceDescriptor(typeof(IEpiServerInitialize), p => epiCore, ServiceLifetime.Singleton));

            services.AddMvc().AddRazorPagesOptions(o =>
            {
                o.Conventions.Add(new EpiPageRouteModelConvention(epiCore));
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);




            var container = new Container();
            container.Configure(config =>
            {
                config.Populate(services);
            });


            return container.GetInstance<IServiceProvider>();
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
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc();
        }
    }
    public class EpiPageRouteModelConvention : IPageRouteModelConvention
    {
        private readonly EpiServerInitialize _epiCore;
        public EpiPageRouteModelConvention(EpiServerInitialize epiCore)
        {
            _epiCore = epiCore;
        }
        public void Apply(PageRouteModel model)
        {

            var contentLoader = _epiCore.GetInstance<IContentLoader>();
            var pages = new List<PageData>();
            foreach (var contentReference in contentLoader.GetDescendents(ContentReference.StartPage))
            {
                var hasPage = contentLoader.TryGet(contentReference, out PageData pageData);
                if (hasPage)
                {
                    pages.Add(pageData);
                }
            }
            var gruppedPages = pages.GroupBy(x => x.PageTypeName);
            foreach (var gruppe in gruppedPages)
            {
                if (model.ViewEnginePath.EndsWith(gruppe.Key))
                {
                    var versions = new List<string>();
                    foreach (var item in gruppe)
                    {
                        model.Selectors.Add(new SelectorModel()
                        {
                            AttributeRouteModel = new AttributeRouteModel
                            {
                                Template = item.URLSegment,
                                Name = item.ContentGuid.ToString(),
                            }
                        });
                    }
                }
            }
        }
    }
}
