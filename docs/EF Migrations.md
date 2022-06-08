1. Executar com perfil de build "Debug";

2. Comandos EF Migrations:
     
    
        add-migration MigrationX_NomeTabela_Acao -verbose

        update-database -verbose
       
        update-database -TargetMigration:migrationName
       
        
    
    