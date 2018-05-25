/*
   Friday, May 25, 20189:52:03 AM
   User: 
   Server: DESKTOP-FLN7PJC
   Database: MixedMediaInventoryTracker
   Application: 
*/

/* To prevent any potential data loss issues, you should review this script in detail before running it outside the context of the database designer.*/
BEGIN TRANSACTION
SET QUOTED_IDENTIFIER ON
SET ARITHABORT ON
SET NUMERIC_ROUNDABORT OFF
SET CONCAT_NULL_YIELDS_NULL ON
SET ANSI_NULLS ON
SET ANSI_PADDING ON
SET ANSI_WARNINGS ON
COMMIT
BEGIN TRANSACTION
GO
EXECUTE sp_rename N'dbo.Media.ConditionId', N'Tmp_MediaConditionId', 'COLUMN' 
GO
EXECUTE sp_rename N'dbo.Media.Tmp_MediaConditionId', N'MediaConditionId', 'COLUMN' 
GO
ALTER TABLE dbo.Media SET (LOCK_ESCALATION = TABLE)
GO
COMMIT
select Has_Perms_By_Name(N'dbo.Media', 'Object', 'ALTER') as ALT_Per, Has_Perms_By_Name(N'dbo.Media', 'Object', 'VIEW DEFINITION') as View_def_Per, Has_Perms_By_Name(N'dbo.Media', 'Object', 'CONTROL') as Contr_Per 