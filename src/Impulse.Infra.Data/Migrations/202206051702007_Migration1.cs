namespace Impulse.Infra.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Migration1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AGENDA",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PacienteId = c.Int(nullable: false),
                        MedicoId = c.Int(nullable: false),
                        DataHoraConsulta = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.MEDICOS", t => t.MedicoId)
                .ForeignKey("dbo.PACIENTES", t => t.PacienteId)
                .Index(t => t.PacienteId)
                .Index(t => t.MedicoId);
            
            CreateTable(
                "dbo.MEDICOS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Crm = c.String(nullable: false, maxLength: 10),
                        Especialidade = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PACIENTES",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Documento = c.String(nullable: false, maxLength: 14),
                        NumeroConvenio = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.USUARIOS",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nome = c.String(nullable: false, maxLength: 100),
                        Documento = c.String(nullable: false, maxLength: 14),
                        Senha = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AGENDA", "PacienteId", "dbo.PACIENTES");
            DropForeignKey("dbo.AGENDA", "MedicoId", "dbo.MEDICOS");
            DropIndex("dbo.AGENDA", new[] { "MedicoId" });
            DropIndex("dbo.AGENDA", new[] { "PacienteId" });
            DropTable("dbo.USUARIOS");
            DropTable("dbo.PACIENTES");
            DropTable("dbo.MEDICOS");
            DropTable("dbo.AGENDA");
        }
    }
}
