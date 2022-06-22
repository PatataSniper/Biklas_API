using Biklas_API_V2.Controllers;
using Biklas_API_V2.Models;
using CalculadorRutaServicio;
using ComunicadorCorreoServicio;
using EncriptadorServicio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Cors;
using Unity;
using Unity.Injection;
using Unity.Lifetime;

namespace Biklas_API_V2
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Configuración y servicios de API web
            EnableCorsAttribute cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);

            var container = new UnityContainer();
            container.RegisterType<IEncriptador, Encriptador>(new HierarchicalLifetimeManager());
            container.RegisterType<IComunicadorCorreo, ComunicadorCorreo>(new HierarchicalLifetimeManager());
            container.RegisterType<ICalculadorRuta, CalculadorRuta>(new HierarchicalLifetimeManager());
            container.RegisterType<Usuarios>();
            
            config.DependencyResolver = new UnityResolver(container);

            // Rutas de API web
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
