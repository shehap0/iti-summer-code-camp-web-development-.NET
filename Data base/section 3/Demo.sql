--data types
------------------------>numeric DT
bit  --boolean   false:true   0:1
tinyint --1 byte   -128:127  unsigned 0:255
smallint --2 bytes  -32768:+32767  unsigned  0:65555
int  --4 bytes
bigint -- 8 bytes
------------------------>decimal DT
smallmoney  --4B   .0000
money       --8B   .0000
real               .0000000        -- 7num
float              .0000000000000000000000000
dec decimal    dec(5,2)  123.99    1.3    12.987 ????
------------------------>Text DT
char(10)  fixed length characters   ahmed 10   ali 10    على محمد  ؟؟؟
varchar(10) variable length characters  ahmed 5   ali 3    على محمد  ؟؟؟
nchar(10)  unicode   language     على محمد     على محمد 
nvarchar(10)
nvarchar(max) --up to 2 GB
text --old DT
------------------------>Date_Time DT
Date   MM/dd/yyyy
time   hh:mm:12.987
smalldatetime  MM/dd/yyyy hh:mm:00
datetime MM/dd/yyyy hh:mm:ss.234


----------------------------------


-- DDL 

Create database IsmG3FromCode

use IsmG3FromCode

create table emps
(
eid int primary key,
ename varchar(50) not null,
eadd varchar(50) default 'Ismailia',
hiredate date default getdate(),
sal int,
eage int,
overtime int
)

alter table emps drop column overtime --> drop --> meta data + data
alter table emps add overtime int
alter table emps alter column overtime bigint    -- change Data type

drop table emps --> metadata + data

--- DML --> insert, update, delete

insert into emps
values(1, 'ali', 'alex', '1/1/2000', 4000, 21, NULL)

insert into emps(ename, eid)
values ('mona', 3)

select * from emps



insert into emps(ename, eid)
values ('osama', 2),('ahmed', 4),('nader', 5),('Nour', 6)

--> update

update emps
	set sal += 100

update emps
	set sal = 100 ,ename = 'Heba'

update emps
	set sal += 100
	where eid = 1

--> delete --> data 
delete from emps
	where eid = 6


------------------------------

--DQL --> Display
use ITI

select *
from Student


--- OrderBy

Select *
from Student
order by St_Age desc  -- asc default

------ Distinct

Select  distinct St_Fname 
from Student
-----------

Select  Fullname 
from Student

Select St_Fname + ' ' +St_Lname as [Full Name]
from Student

-- NULL

select *
from student
where St_Fname = NULL          ????


select *
from student
where St_Fname is NULL 

select *
from student
where St_Fname is not NULL 



select * from Student
where St_Address = 'cairo' and St_Address = 'alex'


select * from Student
where St_Address = 'cairo' or St_Address = 'alex'

select *
from Student
where St_Address in ('alex', 'mansoura','cairo')

select * from Student
where St_Age between 22 and 25

---TOP

Select Top(3) * from Student

Select Top(3)St_Fname,St_Age 
from Student

select top(2) Salary
from Instructor
order by Salary desc

select distinct top(2) Salary
from Instructor
order by Salary desc

--order by => default asc
--Distinct => DefaultOrderBy + Uniquness

----------Like

select St_Fname
from Student
where St_Fname like 'Ahmed'

'_' --> one char
'%' --> 0 or more char

Select * 
from Student
where St_Fname like '_a%'

'a%h' 
'%a_'
'__'
'__%'
'ahm%'
'[ahm]%'
'[^ahm]%'
'[a-h]%'
'%[%]' 
'%[_]%' 
'[_]%[_]'  


