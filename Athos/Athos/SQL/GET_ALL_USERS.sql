/*    ==Scripting Parameters==

    Source Server Version : SQL Server 2017 (14.0.1000)
    Source Database Engine Edition : Microsoft SQL Server Express Edition
    Source Database Engine Type : Standalone SQL Server

    Target Server Version : SQL Server 2017
    Target Database Engine Edition : Microsoft SQL Server Standard Edition
    Target Database Engine Type : Standalone SQL Server
*/

USE [Athos]
GO
/****** Object:  StoredProcedure [dbo].[GET_ALL_USERS]    Script Date: 14/04/2018 13:43:17 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GET_ALL_USERS]
AS      
BEGIN      

    SELECT 
		 Id
		,Name
		,Gender
		,Department
		,City
    FROM dbo.Users
END