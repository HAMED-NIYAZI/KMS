using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace KMS.Data.Migrations
{
    public static class StoredProcs
    {
        public static void AddStoredProcs(this MigrationBuilder migrationBuilder)
        {
            //var assembly = Assembly.GetExecutingAssembly();
            //var resourceNames =
            //    assembly.GetManifestResourceNames().Where(str => str.EndsWith(".sql"));
            //foreach (string resourceName in resourceNames)
            //{
            //    using (Stream stream = assembly.GetManifestResourceStream(resourceName))
            //    using (StreamReader reader = new StreamReader(stream))
            //    {
            //        string sql = reader.ReadToEnd();
            //        migrationBuilder.Sql(sql);
            //    }
            //}

            #region Organization 
            var sp = @"

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
-------------------------------------[dbo].[Organization.Update]--------------------------------------------
USE [KMS_DB]
GO
/****** Object:  StoredProcedure [dbo].[Organization.Update]    Script Date: 08/08/2023 07:15:11 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[Organization.Update](
  @Id  UNIQUEIDENTIFIER,
  @SortingNumber  INT,
  @PersianTitle  NVARCHAR(100),
  @ParentId  UNIQUEIDENTIFIER 
) 
AS
BEGIN
  	SET NOCOUNT ON;
UPDATE [dbo].[Organizations] 
SET SortingNumber=@SortingNumber, PersianTitle=@PersianTitle,ParentId=@ParentId,LastUpdateDate=GETDATE()
WHERE Id=@Id
SELECT @@rowcount
 END

 ----------------[dbo].[Organization.GetPage]---------------------
 go

 USE [KMS_DB]
GO
/****** Object:  StoredProcedure [dbo].[Organization.GetPage]    Script Date: 08/08/2023 07:16:19 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Organization.GetPage](
  @PageNumber  INT,
  @RowsOfPage  INT,
  @SortingCol  NVARCHAR(100),
  @SortType  NVARCHAR(100) 
) 
AS
BEGIN
  	SET NOCOUNT ON;
SELECT * FROM [dbo].Organizations
ORDER BY 
CASE WHEN @SortingCol = 'Id' AND @SortType ='ASC' THEN Id END ,
CASE WHEN @SortingCol = 'Id' AND @SortType ='DESC' THEN ID END DESC,
CASE WHEN @SortingCol = 'PersianTitle' AND @SortType ='ASC' THEN PersianTitle END ,
CASE WHEN @SortingCol = 'PersianTitle' AND @SortType ='DESC' THEN PersianTitle END DESC
OFFSET (@PageNumber-1)*@RowsOfPage ROWS
FETCH NEXT @RowsOfPage ROWS ONLY
 END
 go
 ------------------ [dbo].[Organization.GetByName]-------------------
 USE [KMS_DB]
GO
/****** Object:  StoredProcedure [dbo].[Organization.GetByName]    Script Date: 08/08/2023 07:17:00 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Organization.GetByName](
@PersianTitle  NVARCHAR(MAX))
AS
BEGIN
  	SET NOCOUNT ON;
 SELECT * FROM   [dbo].Organizations  WHERE PersianTitle=@PersianTitle
 END
 go
 -------------------[dbo].[Organization.GetById]------------------
 USE [KMS_DB]
GO
/****** Object:  StoredProcedure [dbo].[Organization.GetById]    Script Date: 08/08/2023 07:17:17 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Organization.GetById](
@Id UNIQUEIDENTIFIER)
AS
BEGIN
  	SET NOCOUNT ON;
 SELECT * FROM   [dbo].Organizations  WHERE Id=@Id
 END
 go
 --------------------[dbo].[Organization.GetAll] -----------------
 USE [KMS_DB]
GO
/****** Object:  StoredProcedure [dbo].[Organization.GetAll]    Script Date: 08/08/2023 07:17:30 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Organization.GetAll] 
AS
BEGIN
  	SET NOCOUNT ON;
 SELECT * FROM   [dbo].Organizations  WHERE IsDeleted=0
 END
 go
 -------------------[dbo].[Organization.DeleteByName]------------------
 USE [KMS_DB]
GO
/****** Object:  StoredProcedure [dbo].[Organization.DeleteByName]    Script Date: 08/08/2023 07:17:46 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Organization.DeleteByName](
@PersianTitle NVARCHAR(MAX))
AS
BEGIN
  	SET NOCOUNT ON;
 UPDATE  [dbo].Organizations  SET IsDeleted=1 WHERE PersianTitle=@PersianTitle
 SELECT @@ROWCOUNT
 END
 go
 -------------------[dbo].[Organization.DeleteById]------------------
 USE [KMS_DB]
GO
/****** Object:  StoredProcedure [dbo].[Organization.DeleteById]    Script Date: 08/08/2023 07:17:59 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Organization.DeleteById](
@Id UNIQUEIDENTIFIER)
AS
BEGIN
  	SET NOCOUNT ON;
 UPDATE  [dbo].Organizations02 SET IsDeleted=1 WHERE Id=@Id
  SELECT @@ROWCOUNT
 END
 
 -------------------[dbo].[Organization.Count]------------------
 go
 USE [KMS_DB]
GO
/****** Object:  StoredProcedure [dbo].[Organization.Count]    Script Date: 08/08/2023 07:18:12 ب.ظ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
ALTER PROCEDURE [dbo].[Organization.Count]
AS
BEGIN
  	SET NOCOUNT ON;
 SELECT COUNT(*) FROM dbo.Organizations
END

 -------------------------------------
 -------------------------------------


";

            migrationBuilder.Sql(sp);

            #endregion   Organization 

        }

    }
}
 
