using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Ninject;
using Ninject.Web.Common;
using Ninject.Parameters;

using Pasifika.Business.Abstract;
using Pasifika.Business.Concrete;
using Pasifika.Business.DataAccess.Abstract;
using Pasifika.Business.DataAccess.Concrete;
using Pasifika.Model;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using Pasifika.WebUI.DI.Ninject.Modules;
using MvcSiteMapProvider.Loader;
using MvcSiteMapProvider.Web.Mvc;
using System.Web.Routing;

namespace Pasifika.WebUI.Infrastructure
{
    public class NinjectDependencyResolver : IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
            AddSiteMapProvider();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<Pasifika.Business.DataAccess.PasifikaDbContext>().ToSelf().InRequestScope()
                .WithConstructorArgument("sqlConnectionString", "DefaultConnection");

            kernel.Bind<IUserStore<AppUser>>().To<Pasifika.Business.DataAccess.AppUserStore>();
            kernel.Bind<UserManager<AppUser>>().ToSelf();
            //kernel.Bind<IRoleStore<IdentityRole, string>>().To<RoleStore<IdentityRole, string, IdentityUserRole>>();
            kernel.Bind<IRoleStore<IdentityRole, string>>().To<RoleStore<IdentityRole, string, IdentityUserRole>>().WithConstructorArgument("context", context => kernel.Get<Pasifika.Business.DataAccess.PasifikaDbContext>());
            kernel.Bind<RoleManager<IdentityRole>>().ToSelf();
            kernel.Bind<IAuthenticationManager>().ToMethod(c => HttpContext.Current.GetOwinContext().Authentication).InRequestScope();

            kernel.Bind<AppUser>().ToMethod(c =>
            {
                var userManager = c.Kernel.Get<UserManager<AppUser>>();
                AppUser currentUser = null;
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                    currentUser = userManager.FindById(HttpContext.Current.User.Identity.GetUserId());

                return currentUser;
            });

            kernel.Bind<IViajeBusiness>().To<ViajeBusiness>();
            kernel.Bind<IViajeData>().To<ViajeData>();

            kernel.Bind<ITagBusiness>().To<TagBusiness>();
            kernel.Bind<ITagData>().To<TagData>();

            kernel.Bind<IPaginaBusiness>().To<PaginaBusiness>();
            kernel.Bind<IPaginaData>().To<PaginaData>();

            kernel.Bind<ISeccionBusiness>().To<SeccionBusiness>();
            kernel.Bind<ISeccionData>().To<SeccionData>();

            kernel.Bind<IPartnerBusiness>().To<PartnerBusiness>();
            kernel.Bind<IPartnerData>().To<PartnerData>();

            kernel.Bind<IRegionBusiness>().To<RegionBusiness>();
            kernel.Bind<IRegionData>().To<RegionData>();

            kernel.Bind<IDestinoBusiness>().To<DestinoBusiness>();
            kernel.Bind<IDestinoData>().To<DestinoData>();

            kernel.Bind<ICiudadBusiness>().To<CiudadBusiness>();
            kernel.Bind<ICiudadData>().To<CiudadData>();

            kernel.Bind<ISugerenciaBusiness>().To<SugerenciaBusiness>();
            kernel.Bind<ISugerenciaData>().To<SugerenciaData>();

            kernel.Bind<IPromocionBusiness>().To<PromocionBusiness>();
            kernel.Bind<IPromocionData>().To<PromocionData>();

            kernel.Bind<IPrensaBusiness>().To<PrensaBusiness>();
            kernel.Bind<IPrensaData>().To<PrensaData>();

            kernel.Bind<IFormularioSesionBusiness>().To<FormularioSesionBusiness>();
            kernel.Bind<IFormularioSesionData>().To<FormularioSesionData>();

            kernel.Bind<INotaBusiness>().To<NotaBusiness>();
            kernel.Bind<INotaData>().To<NotaData>();

            kernel.Bind<IBannerHomeBusiness>().To<BannerHomeBusiness>();
            kernel.Bind<IBannerHomeData>().To<BannerHomeData>();

            kernel.Bind<IContactoBusiness>().To<ContactoBusiness>();
            kernel.Bind<IContactoData>().To<ContactoData>();

            kernel.Bind<IBusquedaBusiness>().To<BusquedaBusiness>();
            kernel.Bind<IBusquedaData>().To<BusquedaData>();

            kernel.Bind<IExcelExportBusiness>().To<ExcelExportBusiness>();
        }

        private void AddSiteMapProvider()
        {
            // Setup configuration of DI (required)
            kernel.Load(new MvcSiteMapProviderModule());

            // Setup global sitemap loader (required)
            MvcSiteMapProvider.SiteMaps.Loader = kernel.Get<ISiteMapLoader>();

            /*
            // Check all configured .sitemap files to ensure they follow the XSD for MvcSiteMapProvider (optional)
            var validator = container.Get<ISiteMapXmlValidator>();
            validator.ValidateXml(HostingEnvironment.MapPath("~/Mvc.sitemap"));
            */

            // Register the Sitemaps routes for search engines (optional)
            XmlSiteMapController.RegisterRoutes(RouteTable.Routes);
        }
    }
}