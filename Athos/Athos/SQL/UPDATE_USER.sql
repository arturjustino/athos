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
/****** Object:  StoredProcedure [dbo].[UPDATE_USER]    Script Date: 14/04/2018 13:43:41 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[UPDATE_USER]
(
	@pId			INT,
	@pName			VARCHAR(50),
	@pGender		VARCHAR(9),
	@pDepartment	VARCHAR(50),
	@pCity			VARCHAR(50)
)
AS      
BEGIN      
	UPDATE USERS
	SET
		 Name = @pName
		,Gender = @pGender
		,Department = @pDepartment
		,City = @pCity
	WHERE Id = @pId
END