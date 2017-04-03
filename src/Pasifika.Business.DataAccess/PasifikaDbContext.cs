using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Pasifika.Model;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Pasifika.Business.DataAccess
{
    public class PasifikaDbContext : IdentityDbContext<AppUser>
    {
        public PasifikaDbContext(string sqlConnectionString)
            : base(sqlConnectionString)
        {
            //Database.SetInitializer<AppIdentityDbContext>(new IdentityDbInit());

            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PasifikaDbContext, Pasifika.Business.DataAccess.Migrations.Configuration>(sqlConnectionString));

            //enable-migrations –EnableAutomaticMigration:$false
            //Add-Migration pruebacolumna
            //Update-Database 
            //Update-Database -TargetMigration:0
            //Update-Database -TargetMigration:"MigrationName"
        }

        public PasifikaDbContext()
            : base("DefaultConnection")
        {

        }

        public PasifikaDbContext Create()
        {
            return new PasifikaDbContext("DefaultConnection");
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Viaje>()
                .Map<ViajeTipo1>(m => m.Requires("ViajeTipo").HasValue(1))
                .Map<ViajeTipo2>(m => m.Requires("ViajeTipo").HasValue(2));

            modelBuilder.Entity<ViajeTipo1>()
                .Map<Vuelo>(m => m.Requires("ViajeTipo1").HasValue(1))
                .Map<Crucero>(m => m.Requires("ViajeTipo1").HasValue(2))
                .Map<Tren>(m => m.Requires("ViajeTipo1").HasValue(3))
                .Map<Wellnes>(m => m.Requires("ViajeTipo1").HasValue(4));

            modelBuilder.Entity<ViajeTipo2>()
                .Map<Hotel>(m => m.Requires("ViajeTipo2").HasValue(1))
                .Map<Excursion>(m => m.Requires("ViajeTipo2").HasValue(2));
        }

        public DbSet<Contacto> Contactos { get; set; }
        public DbSet<Viaje> Viajes { get; set; }
        public DbSet<Ciudad> Ciudades { get; set; }
        public DbSet<Destino> Destinos { get; set; }
        public DbSet<Region> Regiones { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<ViajeTag> ViajesTags { get; set; }
        public DbSet<Pagina> Paginas { get; set; }
        public DbSet<Seccion> Secciones { get; set; }
        public DbSet<Destacado> Destacados { get; set; }
        public DbSet<Sugerencia> Sugerencias { get; set; }
        public DbSet<SugerenciaPagina> SugerenciasPaginas { get; set; }
        public DbSet<BannerHome> BannersHome { get; set; }
        public DbSet<Banner> Banners { get; set; }
        public DbSet<BannerInferior> BannersInferiores { get; set; }
        public DbSet<InfoRelacion> InfoRelaciones { get; set; }
        public DbSet<MetaTag> MetaTags { get; set; }
        public DbSet<Partner> Partners { get; set; }
        public DbSet<PaginaTexto> PaginaTextos { get; set; }
        public DbSet<Promocion> Promociones { get; set; }
        public DbSet<Prensa> Prensas { get; set; }
        public DbSet<FormularioSesion> FormularioSesiones { get; set; }
        public DbSet<DestinoTitulo> DestinosTitulos { get; set; }
        public DbSet<Nota> Notas { get; set; }
        public DbSet<BannerContextual> BannersContextual { get; set; }
    }

    public class AppUserStore : UserStore<AppUser>
    {
        public AppUserStore(PasifikaDbContext context)
            : base(context)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<PasifikaDbContext, Pasifika.Business.DataAccess.Migrations.Configuration>("DefaultConnection"));
        }
    }
}
