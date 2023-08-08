
----------------Organization.Insert------------------------------

USE KMS_DB
GO
 SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create PROCEDURE [dbo].[Organization.Insert](
@Id UNIQUEIDENTIFIER,
 	@SortingNumber int,
	@PersianTitle nvarchar(100),
 	@EnglishTitle nvarchar(100),
 	@Description nvarchar(100),
 	@ParentId uniqueidentifier )
AS
BEGIN
  	SET NOCOUNT ON;
 INSERT INTO [dbo].Organizations (Id,[SortingNumber]
      ,[PersianTitle]
      ,[EnglishTitle]
      ,[Description]
      ,[ParentId]
      ,[CreateDate]
      ,[LastUpdateDate]
      ,[IsDeleted])
VALUES( @Id,@SortingNumber
      ,@PersianTitle
      ,@EnglishTitle
      ,@Description
      ,@ParentId
      ,GETDATE()
      ,GETDATE()
      ,0)
END
GO
---------------------------------------------------------------------------------








