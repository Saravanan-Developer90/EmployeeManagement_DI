Create table deptInfo(deptNo int Primary key,deptName varchar(300),deptLocation Varchar(300))

Insert into deptInfo values(1,'HR','Chennai')
Insert into deptInfo values(2,'Development','Pune')
Insert into deptInfo values(3,'Marketing','Coimbatore')
Insert into deptInfo values(4,'Delivery team','Chennai')
Insert into deptInfo values(5,'DevOps','Madurai')

Create Table employeeInfo(empNo int Primary key,empName Varchar(200),empDesignation Varchar(100),empSalary int,empIsPermenant bit)
insert into employeeInfo values (101,'Saran','HR',35000,1)
insert into employeeInfo values (102,'Divya','HR',30000,0)
insert into employeeInfo values (103,'Priya','Development',40000,1)
insert into employeeInfo values (104,'Hari','Delivery Team',466000,1)
insert into employeeInfo values (105,'Mane','DevOps',23000,0)
insert into employeeInfo values (106,'Bilby','DevOps',25000,1)
insert into employeeInfo values (107,'Dinesh','Marketing',80000,1)

Create Table jobOpening(positionId int Primary Key,totalPositions int,designation Varchar(100),
		jobTitle varchar(200),isPositionOpen bit,positionDept int Foreign Key references deptInfo(deptNo))

select * from jobOpening