USE [maracuya_store]
GO
/****** Object:  StoredProcedure [dbo].[SP_Usuarios_Validacion]    Script Date: 12/12/2022 8:45:57 p. m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_Usuarios_Validacion] 
	@Email VARCHAR(100),
	@Password VARCHAR(50)
AS
BEGIN
	
	SELECT * FROM [dbo].[Usuarios] WHERE Correo = @Email AND Password = @Password

END
GO
