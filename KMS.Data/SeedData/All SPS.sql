USE [KMS_DB]
GO
------------------------------HomePageSettingForLoginPage------------------------------
 CREATE OR ALTER PROCEDURE [dbo].[HomePageSettingForLoginPage]
            AS
            BEGIN
            SELECT * FROM [KMS_DB].[dbo].[HomePageSettings] where IsDeleted=0
            END
---------------------------------------------------------------------------------------








