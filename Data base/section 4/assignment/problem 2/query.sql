USE Company;
GO

-- 1. union: Female dependents of Female employees + Male dependents of Male employees
SELECT D.Dependent_Name, D.Sex
FROM Dependent D, Employee E
WHERE D.ESSN = E.SSN AND D.Sex = 'F' AND E.Sex = 'F'

UNION

SELECT D.Dependent_Name, D.Sex
FROM Dependent D, Employee E
WHERE D.ESSN = E.SSN AND D.Sex = 'M' AND E.Sex = 'M';


-- 2. project name + total hours per week across all employees
SELECT P.Pname, SUM(W.Hours) AS TotalHours
FROM Project P, Works_for W
WHERE P.Pnumber = W.Pno
GROUP BY P.Pname;


-- 3. department of the employee with the smallest SSN
SELECT D.*
FROM Departments D, Employee E
WHERE D.Dnum = E.Dno
  AND E.SSN = (SELECT MIN(SSN) FROM Employee);


-- 4. department name + max, min, avg salary
SELECT D.Dname, MAX(E.Salary) AS MaxSalary, MIN(E.Salary) AS MinSalary, AVG(E.Salary) AS AvgSalary
FROM Departments D, Employee E
WHERE D.Dnum = E.Dno
GROUP BY D.Dname;


-- 5. full name of managers with no dependents
SELECT E.Fname + ' ' + E.Lname AS FullName
FROM Employee E
WHERE E.SSN IN (SELECT MGRSSN FROM Departments)
  AND E.SSN NOT IN (SELECT ESSN FROM Dependent);


-- 6. departments whose avg salary < overall avg salary -> number, name, employee count
SELECT D.Dnum, D.Dname, COUNT(E.SSN) AS NumEmployees
FROM Departments D, Employee E
WHERE D.Dnum = E.Dno
GROUP BY D.Dnum, D.Dname
HAVING AVG(E.Salary) < (SELECT AVG(Salary) FROM Employee);


-- 7. employee names + project names, ordered by dept number, then last name, first name
SELECT E.Fname, E.Lname, P.Pname, E.Dno
FROM Employee E, Works_for W, Project P
WHERE E.SSN = W.ESSn AND W.Pno = P.Pnumber
ORDER BY E.Dno, E.Lname, E.Fname;


-- 8. max 2 salaries using subquery
SELECT MAX(Salary) AS Salary FROM Employee
UNION
SELECT MAX(Salary) FROM Employee
WHERE Salary < (SELECT MAX(Salary) FROM Employee);


-- 9. full name of employees whose first name appears in any dependent name
SELECT DISTINCT E.Fname, E.Lname
FROM Employee E, Dependent D
WHERE D.Dependent_Name LIKE '%' + E.Fname + '%';
GO
