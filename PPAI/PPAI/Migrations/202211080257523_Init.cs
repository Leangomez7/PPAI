namespace PPAI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AsignacionCientificoCIs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fechaDesde = c.DateTime(nullable: false),
                        fechaHasta = c.DateTime(nullable: false),
                        cientifico_id = c.Int(),
                        CentroInvestigacion_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PersonalCientificoes", t => t.cientifico_id)
                .ForeignKey("dbo.CentroInvestigacions", t => t.CentroInvestigacion_id)
                .Index(t => t.cientifico_id)
                .Index(t => t.CentroInvestigacion_id);
            
            CreateTable(
                "dbo.PersonalCientificoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        legajo = c.Int(nullable: false),
                        nombre = c.String(),
                        apellido = c.String(),
                        nroDocumento = c.Int(nullable: false),
                        correoInstitucional = c.String(),
                        correoPersonal = c.String(),
                        telefono = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Turnoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fechaGeneracion = c.DateTime(nullable: false),
                        diaSemana = c.Int(nullable: false),
                        fechaHoraInicio = c.DateTime(nullable: false),
                        fechaHoraFin = c.DateTime(nullable: false),
                        PersonalCientifico_id = c.Int(),
                        AsignacionCientificoCI_id = c.Int(),
                        RecursoTecnologico_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PersonalCientificoes", t => t.PersonalCientifico_id)
                .ForeignKey("dbo.AsignacionCientificoCIs", t => t.AsignacionCientificoCI_id)
                .ForeignKey("dbo.RecursoTecnologicoes", t => t.RecursoTecnologico_id)
                .Index(t => t.PersonalCientifico_id)
                .Index(t => t.AsignacionCientificoCI_id)
                .Index(t => t.RecursoTecnologico_id);
            
            CreateTable(
                "dbo.CambioEstadoRTs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fechaHoraDesde = c.DateTime(nullable: false),
                        fechaHoraHasta = c.DateTime(nullable: false),
                        estado = c.Int(nullable: false),
                        RecursoTecnologico_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RecursoTecnologicoes", t => t.RecursoTecnologico_id)
                .Index(t => t.RecursoTecnologico_id);
            
            CreateTable(
                "dbo.CambioEstadoTurnoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fechaHoraDesde = c.DateTime(nullable: false),
                        fechaHoraHasta = c.DateTime(nullable: false),
                        estado = c.Int(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.CentroInvestigacions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        sigla = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.HorarioRTs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        diaSemana = c.Int(nullable: false),
                        horaDesde = c.DateTime(nullable: false),
                        horaHasta = c.DateTime(nullable: false),
                        vigenciaDesde = c.DateTime(nullable: false),
                        vigenciaHasta = c.DateTime(nullable: false),
                        RecursoTecnologico_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.RecursoTecnologicoes", t => t.RecursoTecnologico_id)
                .Index(t => t.RecursoTecnologico_id);
            
            CreateTable(
                "dbo.Marcas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Modeloes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        marca_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Marcas", t => t.marca_id)
                .Index(t => t.marca_id);
            
            CreateTable(
                "dbo.RecursoTecnologicoes",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        numeroRT = c.Int(nullable: false),
                        fechaAlta = c.DateTime(nullable: false),
                        periodicidadMantenimientoPrev = c.Int(nullable: false),
                        duracionMantenimientoPrev = c.Int(nullable: false),
                        fraccionHorarioTurnos = c.Int(nullable: false),
                        centroInvestigacion_id = c.Int(),
                        modelo_id = c.Int(),
                        tipoRT_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.CentroInvestigacions", t => t.centroInvestigacion_id)
                .ForeignKey("dbo.Modeloes", t => t.modelo_id)
                .ForeignKey("dbo.TipoRTs", t => t.tipoRT_id)
                .Index(t => t.centroInvestigacion_id)
                .Index(t => t.modelo_id)
                .Index(t => t.tipoRT_id);
            
            CreateTable(
                "dbo.TipoRTs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        descripcion = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Sesions",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        fechaDesde = c.DateTime(nullable: false),
                        fechaHasta = c.DateTime(nullable: false),
                        usuario_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Usuarios", t => t.usuario_id)
                .Index(t => t.usuario_id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        clave = c.String(),
                        nombreUsuario = c.String(),
                        habilitado = c.Boolean(),
                        personalCientifico_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.PersonalCientificoes", t => t.personalCientifico_id)
                .Index(t => t.personalCientifico_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sesions", "usuario_id", "dbo.Usuarios");
            DropForeignKey("dbo.Usuarios", "personalCientifico_id", "dbo.PersonalCientificoes");
            DropForeignKey("dbo.Turnoes", "RecursoTecnologico_id", "dbo.RecursoTecnologicoes");
            DropForeignKey("dbo.RecursoTecnologicoes", "tipoRT_id", "dbo.TipoRTs");
            DropForeignKey("dbo.RecursoTecnologicoes", "modelo_id", "dbo.Modeloes");
            DropForeignKey("dbo.HorarioRTs", "RecursoTecnologico_id", "dbo.RecursoTecnologicoes");
            DropForeignKey("dbo.RecursoTecnologicoes", "centroInvestigacion_id", "dbo.CentroInvestigacions");
            DropForeignKey("dbo.CambioEstadoRTs", "RecursoTecnologico_id", "dbo.RecursoTecnologicoes");
            DropForeignKey("dbo.Modeloes", "marca_id", "dbo.Marcas");
            DropForeignKey("dbo.AsignacionCientificoCIs", "CentroInvestigacion_id", "dbo.CentroInvestigacions");
            DropForeignKey("dbo.Turnoes", "AsignacionCientificoCI_id", "dbo.AsignacionCientificoCIs");
            DropForeignKey("dbo.AsignacionCientificoCIs", "cientifico_id", "dbo.PersonalCientificoes");
            DropForeignKey("dbo.Turnoes", "PersonalCientifico_id", "dbo.PersonalCientificoes");
            DropIndex("dbo.Usuarios", new[] { "personalCientifico_id" });
            DropIndex("dbo.Sesions", new[] { "usuario_id" });
            DropIndex("dbo.RecursoTecnologicoes", new[] { "tipoRT_id" });
            DropIndex("dbo.RecursoTecnologicoes", new[] { "modelo_id" });
            DropIndex("dbo.RecursoTecnologicoes", new[] { "centroInvestigacion_id" });
            DropIndex("dbo.Modeloes", new[] { "marca_id" });
            DropIndex("dbo.HorarioRTs", new[] { "RecursoTecnologico_id" });
            DropIndex("dbo.CambioEstadoRTs", new[] { "RecursoTecnologico_id" });
            DropIndex("dbo.Turnoes", new[] { "RecursoTecnologico_id" });
            DropIndex("dbo.Turnoes", new[] { "AsignacionCientificoCI_id" });
            DropIndex("dbo.Turnoes", new[] { "PersonalCientifico_id" });
            DropIndex("dbo.AsignacionCientificoCIs", new[] { "CentroInvestigacion_id" });
            DropIndex("dbo.AsignacionCientificoCIs", new[] { "cientifico_id" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Sesions");
            DropTable("dbo.TipoRTs");
            DropTable("dbo.RecursoTecnologicoes");
            DropTable("dbo.Modeloes");
            DropTable("dbo.Marcas");
            DropTable("dbo.HorarioRTs");
            DropTable("dbo.CentroInvestigacions");
            DropTable("dbo.CambioEstadoTurnoes");
            DropTable("dbo.CambioEstadoRTs");
            DropTable("dbo.Turnoes");
            DropTable("dbo.PersonalCientificoes");
            DropTable("dbo.AsignacionCientificoCIs");
        }
    }
}
