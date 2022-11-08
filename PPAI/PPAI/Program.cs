using PPAI.Entidades;
using System.Data.Entity;

namespace PPAI
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            Application.Run(new Login());
        }
        public class PersistenciaContext : DbContext
        {
            public DbSet<PersonalCientifico> personalCientifico { get; set; }
            public DbSet<AsignacionCientificoCI> asignacionCientifico { get; set; }
            public DbSet<CentroInvestigacion> centroInvestigacion { get; set; }
            public DbSet<CambioEstadoRT> cambioEstadoRT { get; set; }
            public DbSet<HorarioRT> horarioRT { get; set; }
            public DbSet<Marca> marca { get; set; }
            public DbSet<Modelo> modelo { get; set; }
            public DbSet<RecursoTecnologico> recursoTecnologico { get; set; }
            public DbSet<Sesion> sesion { get; set; }
            public DbSet<TipoRT> tipoRT { get; set; }
            public DbSet<Turno> turno { get; set; }
            public DbSet<Usuario> usuario { get; set; }
            public DbSet<CambioEstadoTurno> cambioEstadoTurno { get; set; }
        }
    }
}