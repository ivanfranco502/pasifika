namespace Pasifika.Business.DataAccess.Migrations
{
    using Pasifika.Model;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Pasifika.Business.DataAccess.PasifikaDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Pasifika.Business.DataAccess.PasifikaDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
                context.Secciones.AddOrUpdate(
                  s => s.Id,
                  new Seccion { Id = 1, Nombre = "Home" },
                  new Seccion { Id = 2, Nombre = "Quienes Somos" },
                  new Seccion { Id = 3, Nombre = "Faqs" },
                  new Seccion { Id = 4, Nombre = "Viaje 1" },
                  new Seccion { Id = 5, Nombre = "Viaje 2" },
                  new Seccion { Id = 6, Nombre = "Crucero 1" },
                  new Seccion { Id = 7, Nombre = "Crucero 2" },
                  new Seccion { Id = 8, Nombre = "Excursion 1" },
                  new Seccion { Id = 9, Nombre = "Excursion 2" },
                  new Seccion { Id = 10, Nombre = "Tren 1" },
                  new Seccion { Id = 11, Nombre = "Tren 2" },
                  new Seccion { Id = 12, Nombre = "Hotel 1" },
                  new Seccion { Id = 13, Nombre = "Hotel 2" },
                  new Seccion { Id = 14, Nombre = "Destino 1" },
                  new Seccion { Id = 15, Nombre = "Destino 2" },
                  new Seccion { Id = 16, Nombre = "Contacto" },
                  new Seccion { Id = 17, Nombre = "Guia 1" },
                  new Seccion { Id = 18, Nombre = "Guia 2" },
                  new Seccion { Id = 19, Nombre = "Seminario" },
                  new Seccion { Id = 20, Nombre = "Nota 1" },
                  new Seccion { Id = 21, Nombre = "Nota 2" },
                  new Seccion { Id = 22, Nombre = "Colaboradores" },
                  new Seccion { Id = 23, Nombre = "Prensa" },
                  new Seccion { Id = 24, Nombre = "Promociones" },
                  new Seccion { Id = 25, Nombre = "Catalogo" },
                  new Seccion { Id = 26, Nombre = "Compartir" },
                  new Seccion { Id = 27, Nombre = "Baja" },
                  new Seccion { Id = 28, Nombre = "Wellnes & spa 1" },
                  new Seccion { Id = 29, Nombre = "Wellnes & spa 2" }
                );

            /*
                var lr = context.Regiones.Where(x => x.Id == 1);
                if (lr.Count() == 0)
                    context.Regiones.Add(new Region { Id = 1, Nombre = "Asia" });

                lr = context.Regiones.Where(x => x.Id == 1);
                    if (lr.Count() == 0)
                        context.Regiones.Add(new Region { Id = 2, Nombre = "Pacífico" });

                lr = context.Regiones.Where(x => x.Id == 1);
                    if (lr.Count() == 0)
                        context.Regiones.Add(new Region { Id = 3, Nombre = "América" });
             */ 
            //
        }
    }
}
