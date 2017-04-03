namespace Pasifika.Business.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgregarSPBusqueda : DbMigration
    {
        public override void Up()
        {
            CreateStoredProcedure(
           "dbo.sp_busqueda_datos",
           p => new
           {
               Descripcion = p.String(maxLength:200),
               PageIndex = p.Int(),
               PageSize = p.Int(),
           },
           body:
               @"CREATE TABLE #words (
                     id int,
                     texto varchar(100)
    )
    
    CREATE TABLE #resultado
    (
    indice int IDENTITY(1,1),
    id int,
    descripcion varchar(5000),
    tipo smallint,
    matchpct decimal(18,2)
    )
    
    --DECLARE @word varchar(100)
    DECLARE @individual varchar(20) = null
    DECLARE @Contador INT
    DECLARE @Regs INT   
    DECLARE @campo VARCHAR(50) 
    DECLARE @TotalRows int
    DECLARE @numberToIgnore int
    DECLARE @camposbusqueda varchar(200)
    --set @word = 'arte islas sentimos'
    
    set @camposbusqueda = REPLACE(@Descripcion,' ','|')
    
    SET @Contador = 1
    
    WHILE LEN(@camposbusqueda) > 0
    BEGIN
    IF PATINDEX('%|%',@camposbusqueda) > 0
    BEGIN
    SET @individual = SUBSTRING(@camposbusqueda, 0, PATINDEX('%|%',@camposbusqueda))        
                      Insert into #words(id,texto) values (@Contador,@individual)
    SET @camposbusqueda = SUBSTRING(@camposbusqueda, LEN(@individual + '|') + 1,LEN(@camposbusqueda))
    END
    ELSE
    BEGIN
    SET @individual = @camposbusqueda
    SET @camposbusqueda = NULL
    Insert into #words(id,texto) values (@Contador,@individual)
    END
    
                     SET @Contador = @Contador + 1
    END
    
    SET @Regs = (SELECT COUNT(*) FROM #words)
    SET @numberToIgnore = (@PageIndex-1) * @PageSize
    
    INSERT INTO #resultado(id,tipo,matchpct)
    
    SELECT viaje.Id, 1, a.MatchPct
    FROM Viaje viaje
                      inner join
                      (
                      select
                       vi.id, Count(*)  * 1.0 / @Regs as MatchPct
                      from
                       Viaje vi inner join
                        #words W on isnull(vi.nombre,'') + ' ' + isnull(vi.Comentarios,'') + ' ' + isnull(vi.paises,'') + ' ' +
                           isnull(vi.Ciudades,'') + ' ' +isnull(vi.Itinerario,'') + ' ' + 
                           isnull(vi.Alojamiento,'') + ' ' + isnull(vi.Actividades,'') + ' ' + isnull(vi.Translados,'') + ' ' + 
                           isnull(vi.CuandoIr,'') + ' ' + isnull(vi.Presupuesto,'') + ' ' + isnull(vi.NombreCrucero,'') + ' ' + 
                           isnull(vi.Referencia,'') + ' ' + 
                           isnull(vi.InformacionGeneral,'') + ' ' + isnull(vi.Importante,'') + ' ' + isnull(vi.Descripcion,'')
                           like '%' + W.texto + '%'  
                         group by
                         vi.id
                      ) a on viaje.Id = a.Id
    WHERE viaje.Eliminado=0
    
    UNION
    
    SELECT n.Id, 2, a.MatchPct
    FROM nota n  
                        inner join
                       (
                       select
                        n1.id, Count(*)  * 1.0 / @Regs as MatchPct
                       from
                        Nota n1 inner join
                         #words W on isnull(n1.Titulo,'') + ' ' + isnull(n1.Resumen,'') 
                            like '%' + W.texto + '%'  
                          group by
                          n1.id
                       ) a on n.Id = a.Id
    WHERE   
                      n.Eliminado = 0
    
    UNION
    
  select distinct a.Id,a.tipo,a.MatchPct from (

    SELECT d.Id, 3 as tipo, a.MatchPct
    FROM Destino d 
                        inner join
                       (
                       select
                        n1.id, Count(*)  * 1.0 / @Regs as MatchPct
                       from
                        Destino n1 inner join
                         #words W on isnull(n1.Nombre,'') + ' ' + isnull(n1.Resumen,'') 
                            like '%' + W.texto + '%'  
                          group by
                          n1.id
                       ) a on d.Id = a.Id
    
     )a
 group by a.Id,a.tipo,a.MatchPct
    ORDER BY a.MatchPct desc
      
    set @TotalRows = @@rowcount
    
    SELECT *, @TotalRows totalROWS
    FROM #resultado
    WHERE indice > @numberToIgnore
    AND indice <= (@numberToIgnore + @PageSize)
    
    drop table #words
    drop table #resultado"
            );
        }
        
        public override void Down()
        {
        }
    }
}
