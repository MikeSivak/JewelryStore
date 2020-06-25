create procedure productsExportXml 
as
	set nocount on
	set xact_abort on  

	begin transaction

	select * FROM ProductsTypes
	for XML path('productType'), ROOT('productTypes');

	commit
GO
--drop procedure productsExportXml
execute productsExportXml;

create procedure productsImportXml
    @file_path nvarchar(max)
as
	set nocount on
	set xact_abort on  
	
	begin transaction
	
	declare @sql nvarchar(MAX) = 'INSERT INTO ProductsTypes (nameType)
	SELECT
		MY_XML.productType.query(''nameType'').value(''.'', ''VARCHAR(50)'')
	FROM (SELECT CAST(MY_XML AS xml)
		FROM OPENROWSET(BULK ''' + @file_path + ''' , SINGLE_BLOB) AS T(MY_XML)) AS T(MY_XML)
		CROSS APPLY MY_XML.nodes(''productTypes/productType'') AS MY_XML (productType)';

	execute sp_executesql @sql;

	-- Begin Return Select <- do not remove
	select idType, nameType from ProductsTypes
	where  idType = scope_identity()
	-- End Return Select <- do not remove
               
	commit
go

declare	@return_value int
execute	@return_value = productsImportXml
		@file_path = 'E:\products.xml'
GO

select * from ProductsTypes;

delete from ProductsTypes where idType > 4;