-- Fix IDENTITY column errors by removing identity from string columns
-- These columns should NOT be identity columns in SQL Server

-- Drop any dependent constraints first
ALTER TABLE [dbo].[employee] DROP CONSTRAINT IF EXISTS PK__employee__SSN;

-- Recreate FNAME as regular nvarchar (not identity)
DECLARE @ConstraintName NVARCHAR(255);
SELECT @ConstraintName = CONSTRAINT_NAME 
FROM INFORMATION_SCHEMA.KEY_COLUMN_USAGE 
WHERE TABLE_NAME = 'employee' AND COLUMN_NAME = 'SSN';

IF @ConstraintName IS NOT NULL
    EXEC('ALTER TABLE [dbo].[employee] DROP CONSTRAINT ' + @ConstraintName);

-- Recreate the table structure if needed, or use DBCC to turn off identity
DBCC CHECKIDENT('[dbo].[employee]', NORESEED);

-- For department table
ALTER TABLE [dbo].[department] DROP CONSTRAINT IF EXISTS PK__department__DNUMBER;
DBCC CHECKIDENT('[dbo].[department]', NORESEED);

-- For project table  
ALTER TABLE [dbo].[project] DROP CONSTRAINT IF EXISTS PK__project__PNUMBER;
DBCC CHECKIDENT('[dbo].[project]', NORESEED);

-- Re-add primary keys
ALTER TABLE [dbo].[employee] ADD CONSTRAINT PK_employee_SSN PRIMARY KEY (SSN);
ALTER TABLE [dbo].[department] ADD CONSTRAINT PK_department_DNUMBER PRIMARY KEY (DNUMBER);
ALTER TABLE [dbo].[project] ADD CONSTRAINT PK_project_PNUMBER PRIMARY KEY (PNUMBER);

-- Verify the schema is now valid
SELECT TABLE_NAME, COLUMN_NAME, DATA_TYPE, 
       COLUMNPROPERTY(OBJECT_ID(TABLE_SCHEMA+'.'+TABLE_NAME), COLUMN_NAME, 'IsIdentity') AS IsIdentity
FROM INFORMATION_SCHEMA.COLUMNS
WHERE TABLE_NAME IN ('employee', 'department', 'project')
ORDER BY TABLE_NAME, ORDINAL_POSITION;
