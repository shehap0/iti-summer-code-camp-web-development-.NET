USE Company;
GO

-- 1. All employee data
SELECT * FROM Employee;

-- 2. First name, last name, salary, department number
SELECT Fname, Lname, Salary, Dno FROM Employee;

-- 3. Project names, locations, and responsible department
SELECT p.Pname, p.Plocation, d.Dname
FROM Project p
JOIN Departments d ON p.Dnum = d.Dnum;

-- 4. Full name + 10% annual commission
SELECT Fname + ' ' + Lname AS FullName,
       (Salary * 12 * 0.10) AS ANNUAL_COMM
FROM Employee;

-- 5. Id, name of employees earning more than 1000 LE monthly
SELECT SSN, Fname + ' ' + Lname AS Name
FROM Employee
WHERE Salary > 1000;

-- 6. Id, name of employees earning more than 10000 LE annually
SELECT SSN, Fname + ' ' + Lname AS Name
FROM Employee
WHERE Salary * 12 > 10000;

-- 7. Names and salaries of female employees
SELECT Fname, Lname, Salary
FROM Employee
WHERE Sex = 'F';

-- 8. Department id, name managed by manager with id 968574
SELECT Dnum, Dname
FROM Departments
WHERE MGRSSN = 968574;

-- 9. Ids, names, locations of projects controlled by department 10
SELECT Pnumber, Pname, Plocation
FROM Project
WHERE Dnum = 10;

-- 10. Last name starts with 'A' and ends with 'N', OR ends with 'L'
SELECT *
FROM Employee
WHERE (Lname LIKE 'A%N') OR (Lname LIKE '%L');

-- 11. First letter of last name NOT in range A-X
SELECT *
FROM Employee
WHERE Lname NOT LIKE '[A-X]%';

-- 12. First letter of last name is Y or Z
SELECT *
FROM Employee
WHERE Lname LIKE '[Y-Z]%';
GO


-- RESTORE FILELISTONLY
-- FROM DISK = '/var/opt/mssql/backup/company.bak';
-- GO

-- RESTORE DATABASE Company
-- FROM DISK = '/var/opt/mssql/backup/company.bak'
-- WITH MOVE 'Company_SD' TO '/var/opt/mssql/data/Company_SD.mdf',
--      MOVE 'Company_SD_log' TO '/var/opt/mssql/data/Company_SD_log.ldf';
-- GO

-- USE master;
-- GO
-- ALTER DATABASE Company MODIFY NAME = Company_Old;
-- GO

-- RESTORE DATABASE Company
-- FROM DISK = '/var/opt/mssql/backup/company.bak'
-- WITH MOVE 'Company_SD' TO '/var/opt/mssql/data/Company_SD.mdf',
--      MOVE 'Company_SD_log' TO '/var/opt/mssql/data/Company_SD_log.ldf',
--      REPLACE;
-- GO

-- USE master;
-- GO
-- ALTER DATABASE Company SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
-- DROP DATABASE Company;
-- GO

-- USE Company;
-- GO

-- -- 1. EMPLOYEE (FKs added later, since DEPARTMENT doesn't exist yet)
-- CREATE TABLE employee (
--     FNAME       NVARCHAR(50) NOT NULL,
--     LNAME       NVARCHAR(50) NOT NULL,
--     SSN         INT PRIMARY KEY,
--     BDATE       DATE,
--     ADDRESS     NVARCHAR(255),
--     SEX         CHAR(1),
--     SALARY      DECIMAL(10,2),
--     SUPER_SSN   INT,
--     DNO         INT
-- );
-- GO

-- -- 2. DEPARTMENT
-- CREATE TABLE department (
--     DNAME           NVARCHAR(50) NOT NULL,
--     DNUMBER         INT PRIMARY KEY,
--     MGR_SSN         INT,
--     MGR_START_DATE  DATE
-- );
-- GO

-- -- 3. DEPT_LOCATIONS
-- CREATE TABLE dept_locations (
--     DNUMBER     INT NOT NULL,
--     DLOCATION   NVARCHAR(50) NOT NULL,
--     CONSTRAINT PK_DeptLocations PRIMARY KEY (DNUMBER, DLOCATION)
-- );
-- GO

-- -- 4. PROJECT
-- CREATE TABLE project (
--     PNAME       NVARCHAR(50) NOT NULL,
--     PNUMBER     INT PRIMARY KEY,
--     PLOCATION   NVARCHAR(50),
--     DNUM        INT
-- );
-- GO

-- -- 5. WORKS_ON
-- CREATE TABLE work_on (
--     ESSN    INT NOT NULL,
--     PNO     INT NOT NULL,
--     HOURS   DECIMAL(5,2),
--     CONSTRAINT PK_WorkOn PRIMARY KEY (ESSN, PNO)
-- );
-- GO

-- -- 6. DEPENDENT
-- CREATE TABLE dependent (
--     ESSN            INT NOT NULL,
--     DEPENDENT_NAME  NVARCHAR(50) NOT NULL,
--     SEX             CHAR(1),
--     BDATE           DATE,
--     RELATIONSHIP    NVARCHAR(50),
--     CONSTRAINT PK_Dependent PRIMARY KEY (ESSN, DEPENDENT_NAME)
-- );
-- GO

-- -- Now all 6 tables exist, so add every foreign key
-- ALTER TABLE employee
-- ADD CONSTRAINT FK_Employee_SuperSSN FOREIGN KEY (SUPER_SSN) REFERENCES employee(SSN);

-- ALTER TABLE employee
-- ADD CONSTRAINT FK_Employee_DNO FOREIGN KEY (DNO) REFERENCES department(DNUMBER);

-- ALTER TABLE department
-- ADD CONSTRAINT FK_Department_MgrSSN FOREIGN KEY (MGR_SSN) REFERENCES employee(SSN);

-- ALTER TABLE dept_locations
-- ADD CONSTRAINT FK_DeptLocations_DNumber FOREIGN KEY (DNUMBER) REFERENCES department(DNUMBER);

-- ALTER TABLE project
-- ADD CONSTRAINT FK_Project_DNum FOREIGN KEY (DNUM) REFERENCES department(DNUMBER);

-- ALTER TABLE work_on
-- ADD CONSTRAINT FK_WorkOn_Employee FOREIGN KEY (ESSN) REFERENCES employee(SSN);

-- ALTER TABLE work_on
-- ADD CONSTRAINT FK_WorkOn_Project FOREIGN KEY (PNO) REFERENCES project(PNUMBER);

-- ALTER TABLE dependent
-- ADD CONSTRAINT FK_Dependent_Employee FOREIGN KEY (ESSN) REFERENCES employee(SSN);
-- GO