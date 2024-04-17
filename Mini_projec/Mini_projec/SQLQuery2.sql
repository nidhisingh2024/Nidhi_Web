use miniproject

create table TrainDetails

(SerailNo int identity,
Train_No numeric(5) primary key,
Train_Name varchar(45),
Source varchar(20),
Destination varchar(20))

insert into TrainDetails values
(11211,'Vande-Bharat','Hyderabad','Lucknow'),
(11212,'HIMGIRI EXPRESS','Lucknow','Jammu'),
(11213,'Gkp-Express','Lucknow','Gorakhpur')
 
create table Fare
(SerialNo int identity,
Train_No numeric(5) foreign key references TrainDetails(Train_No),
[1_AC] int,
[2_AC] int,
[SL] int)

create table Seat
(SerialNo int identity,
Train_No numeric(5) foreign key references TrainDetails(Train_No),
[1_AC] int,
[2_AC] int,
[SL] int)

insert into Seat values
(11211,100,200,900),
(11212,200,300,800),
(11213,50,400,1100)
 

create table UserDetails
(User_Id numeric(3) primary key,
User_Name varchar(30)

)

create table AdminDetails
(Admin_Id numeric(3) primary key,
Admin_Name varchar(35),
Admin_passcode varchar(30) unique) 

insert into AdminDetails values
(101,'Nidhi','Nidhi15@'),
(102,'Admin','Admin@15')

create table Ticket_Booking
(PNR_No numeric(5) primary key,
User_Id numeric(3) foreign key references UserDetails(User_Id),
Train_No numeric(5) foreign key references TrainDetails(Train_No),
TotalFare float,
Booking_time_date datetime
)

create table CanceledTicket
(Can_id numeric(5),
PNR_No numeric(5) foreign key references Ticket_Booking(PNR_No),
User_Id numeric(3) foreign key references UserDetails(User_Id),
Train_No numeric(5) foreign key references TrainDetails(Train_No),
cancellation_time datetime)
drop CanceledTicket

select * from TrainDetails
alter table Traindetails add train_stat varchar(10)
alter table CanceledTicket add iden int identity

create or alter proc Softdeletetrain (@trainno int)
as begin
	update TrainDetails set [train_stat] ='Deactive'
end

create or alter proc AddTrain(@tno numeric(5),@tname varchar(30),@source varchar(20),@dest varchar(20),@sts varchar(10))
as 
begin
	insert into TrainDetails values
	(@tno,@tname,@source,@dest,@sts)
end

exec AddTrain 111,ni,la,na,s

create or alter proc modifytrain(@trainno numeric(5),@source varchar(20),@dest varchar(20))
as 
begin
	update TrainDetails set Source=@source,Destination=@dest where Train_No=@trainno
end


alter table ticket_booking add ticket_class varchar(15)


create or alter proc Add_seat(@train_no int,@fir_Ac int,@Sec_Ac int,@slp int)
as
	insert into Fare values(@train_no,@fir_Ac,@Sec_Ac,@slp)


 create or alter proc Add_fare(@train_no int,@fir_AcFare int,@Sec_AcFare int,@slpFare int)
as
	insert into Fare values(@train_no,@fir_AcFare,@Sec_AcFare,@slpFare)

select*from Ticket_Booking
select*from TrainDetails

alter table ticket_booking add tktstatus varchar(20)
alter  table userdetails add password varchar(20) 
alter table traindetails drop column serailNo
