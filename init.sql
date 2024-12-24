IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'IMS_Production')
BEGIN
    CREATE DATABASE IMS_Production;
END
GO
USE [IMS_Production];
GO