-- Joins

select St_fname, D.Dept_Name
from Student S ,Department D

select St_fname, D.Dept_Name
from Student S  cross join Department D

select St_fname, D.Dept_Name
from Student S ,Department D
where D.Dept_Id = S.Dept_Id


select*
from Student S ,Department D
where D.Dept_Id = S.Dept_Id


select St_fname, D.Dept_Name
from Student S ,Department D
where D.Dept_Id = S.Dept_Id and S.St_Address = 'Cairo'


select St_Fname, D.*
from Student S ,Department D
where D.Dept_Id = S.Dept_Id


select St_fname, D.Dept_Name
from Student S left outer join Department D
	on D.Dept_Id = S.Dept_Id


select St_fname, D.Dept_Name
from Student S right outer join Department D
	on D.Dept_Id = S.Dept_Id

select St_fname, D.Dept_Name
from Department D full outer join Student S
	on D.Dept_Id = S.Dept_Id


-- 3 tables .. 
Select St_Fname,St_Lname, Grade, Crs_Name
From Student S, Stud_Course SC, Course C
where S.St_Id = Sc.St_Id and
	  C.Crs_Id = SC.Crs_Id

Select St_Fname, Grade, Crs_Name
From Student S inner join Stud_Course SC
	on S.St_Id = Sc.St_Id
inner join Course C
	on C.Crs_Id = SC.Crs_Id

-- Functions -- return type value,
-- Built-in --> 1 value --> Scaler fn  
--derived column ==> alias name

select St_Fname + ' ' + St_Lname  [Fullname]
From Student

select St_Fname + ' ' + St_Age [Full]             
From Student            --????

-- Convert(datatype, col)
select St_Fname + ' ' +  Convert(varchar(2), St_Age) [Name Age]
From Student

-- CONCAT ==> return type ==> String
-- Replace Null and put empty string ' '
select CONCAT(St_fname, ' ', St_Lname)
from Student

select GetDate()

select 5 * 5

 --ISNULL  function 

-- isnull(Column,replacment) => one replacement
select ISNUll(St_fname, 'NOT Found')
from Student


select ISNUll(St_fname, St_Lname)
from Student
----------------------------------------------------------------------------------

--Aggregate Fns
Select Salary 
From Instructor

select sum(salary)
from Instructor

select Min(Salary) Mi, Max(Salary) Ma
from Instructor
---------------------------------
Select Sum(salary), dept_id
from Instructor
group by dept_id
---------------------------------


--Number of students in each department
select Count(st_id), Dept_Id
from Student
group by dept_id

--Number of students in each Address
select Count(st_id), St_Address
from Student
group by St_Address

--Number of students in each Address in each department
select Count(st_id), dept_id , St_Address
from Student
group by  dept_id ,St_Address



Select Sum(salary), d.dept_id, dept_name
from Instructor i inner join Department d
	on i.Dept_Id = d.Dept_Id
group by d.dept_id, Dept_Name


select Sum(Salary), Dept_Id
from Instructor
group by dept_id
having count( Ins_Id )> 6

---------------------------------------------
select Sum(St_age) ---> value, Col/Array, #col/Table
from Student ----> One value

select St_Fname ---> Array of values
from Student


select *
from Student 
where St_age > 20

select *
from Student 
where St_age < Avg(St_age)  --???

select *
from Student 
where St_age < (select Avg(St_age) from Student)




Select St_Fname ,St_Age
From Student
where st_age > (select avg(st_age) from Student)


select *, count(st_id)
from Student                --- ???

select *, (select count(st_id) from Student )
from Student 


select *, (select count(Ins_Id) from Instructor )
from Student 

-- Names of departments that contain students
select dept_name
from Department
where Dept_Id in (select distinct dept_id 
                  from Student 
				  where Dept_Id is not null
				  )
 --- dept_id in (10, 20, 30, 40)

select distinct dept_name
from Student s inner join Department d
	on s.Dept_Id = d.Dept_Id

--------------------------------------------
-- Union Family --> 
-- Union all --> Faster
-- union, intersect, except --> Distinct(order by + no duplicate)

select St_fname as Names
from Student

Union all

select Ins_name
from Instructor


select St_fname as Names
from Student
Union 
select Ins_name
from Instructor



select St_fname as Names
from Student
Intersect
select Ins_name
from Instructor

select St_fname as Names
from Student
Except
select Ins_name
from Instructor

-------------------------------
-- Excution order for query
-- from
-- join
-- on
-- where
-- Group by
-- having
-- select  [distinct + aggergate]
-- order by
-- Top

--2 select St_fname + ' ' + St_lname Fullname
--1 from Student
--3 order by Fullname

--3 select St_fname + ' ' + St_lname Fullname
--1 from Student
--2 where Fullname = 'Heba EL-Said'