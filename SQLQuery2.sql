create database Processing

use Processing

create table PersonDetails(
Poid int primary key,
)

create table DetailInformation
(
poid int foreign key references PersonDetails(Poid),
BatchNo int ,
ProcessDate DateTime,
AccountNo int,
Amount int,
)

alter table Details
ALTER COLUMN BatchNo varchar(10)

alter table Details
ALTER COLUMN AccountNo varchar(20)

alter table Details
Alter column Amount varchar(20)

select * from PersonDetails

select * from DetailInformation where poid=1000 and ProcessDate='16/06/2017 00:00:00'

insert into PersonDetails values(1003);

insert into DetailInformation values(1001,04,'2017/06/20',234178,10056);
insert into DetailInformation values(1001,02,'2017/06/22',23415,10057);
insert into DetailInformation values(1001,01,'2017/06/22',23416,10082);
insert into DetailInformation values(1001,04,'2017/06/23',23417,10082);
insert into DetailInformation values(1001,05,'2017/06/20',23418,10056);
insert into DetailInformation values(1000,02,'2017/06/16',23419,10057);
insert into DetailInformation values(1000,01,'2017/06/16',23420,10082);
insert into DetailInformation values(1000,03,'2017/06/16',23421,10082);
insert into Details values(1000,05,'2017/06/16',23440,1005767);
select * from Details where poid=1000 and ProcessDate='2017-06-16'

select * from tbl_Users
truncate table tbl_Users

select SCOPE_IDENTITY()


select * from Details where poid=1000 and ProcessDate='2017-06-15'