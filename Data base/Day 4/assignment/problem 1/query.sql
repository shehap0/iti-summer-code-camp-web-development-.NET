USE Company;
GO

-- 1. display department id, name, and manager's id and name
SELECT D.Dnum, D.Dname, E.SSN, E.Fname + ' ' + E.Lname AS ManagerName
FROM Departments D, Employee E
WHERE D.MGRSSN = E.SSN;

-- 2. department name and the projects it controls
SELECT D.Dname, P.Pname
FROM Departments D, Project P
WHERE D.Dnum = P.Dnum;

-- 3. full dependent data + name of employee they depend on
SELECT Dep.*, E.Fname, E.Lname
FROM Dependent Dep, Employee E
WHERE Dep.ESSN = E.SSN;

-- 4. Id, name, location of projects in Cairo or Alex
SELECT Pnumber, Pname, Plocation
FROM Project
WHERE City = 'cairo' OR City = 'alex';

-- 5. full data of projects starting with 'a'
SELECT *
FROM Project
WHERE Pname LIKE 'a%';

-- 6. employees in dept 30 with salary 1000 to 2000 monthly
SELECT *
FROM Employee
WHERE Dno = 30 AND Salary BETWEEN 1000 AND 2000;

-- 7. employees in dept 10 working >=10 hrs/week on "Al Rabwah"
SELECT E.Fname, E.Lname
FROM Employee E, Works_for W, Project P
WHERE E.SSN = W.ESSn 
  AND W.Pno = P.Pnumber 
  AND P.Pname = 'Al Rabwah' 
  AND W.Hours >= 10 
  AND E.Dno = 10;

-- 8. employee names + project names, sorted by project name
SELECT E.Fname, E.Lname, P.Pname
FROM Employee E, Works_for W, Project P
WHERE E.SSN = W.ESSn AND W.Pno = P.Pnumber
ORDER BY P.Pname;

-- 9. full data of all managers
SELECT *
FROM Employee
WHERE SSN IN (SELECT MGRSSN FROM Departments);

-- 10. all employees + their dependents, even if none exist
SELECT E.*, Dep.*
FROM Employee E LEFT OUTER JOIN Dependent Dep
ON E.SSN = Dep.ESSN;

-- 11. Insert your own record
INSERT INTO Employee (Fname, Lname, SSN, Bdate, Address, Sex, Salary, Superssn, Dno)
VALUES ('Shehap', 'sherif', 102672, '2005-06-22', 'Port Said, Egypt', 'M', 3000, 112233, 30);

-- 12. Insert a friend, no salary or supervisor
INSERT INTO Employee (Fname, Lname, SSN, Bdate, Address, Sex, Dno)
VALUES ('adham', 'samir', 102660, '2000-06-22', 'ismailia, Egypt', 'M', 30);

-- 13. Give yourself a 20% raise
UPDATE Employee
SET Salary = Salary * 1.20
WHERE SSN = 102672;
GO
