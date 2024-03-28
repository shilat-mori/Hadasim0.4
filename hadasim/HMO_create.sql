--create database HMO_corona;

use HMO_corona;


--address
create table patient_address(
	id int identity(1,1) primary key,
	city varchar(30),
	street varchar(30),
	number int
);

--patient
create table patient(
	id varchar(9) primary key,
	first_name varchar(20),
	last_name varchar(20),
	address_id int,
	burn_date date,
	phone varchar(10),
	tel varchar(10),
	pic varchar(max),
	_status bit,
	foreign key(address_id) references patient_address(id)
);

--manufacturer
create table producer(
	id int identity(1,1) primary key,
	_name varchar(40)
);

--vaccine חיסון
create table vaccine(
	id int identity(1,1) primary key,
	vac_date date,
	producer int
	foreign key (producer) references producer(id)
);

--serologion
create table serologion(
	id varchar(9) primary key,
	positive_date date,
	recovery_date date,
	_status bit,
);

--corona_vaccine חיסוני קורונה
create table corona_vaccine(
	id varchar(9) primary key,
	vac1 int,
	vac2 int,
	vac3 int,
	vac4 int,
	foreign key (vac1) references vaccine(id),
	foreign key (vac2) references vaccine(id),
	foreign key (vac3) references vaccine(id),
	foreign key (vac4) references vaccine(id),
	_status bit,
);



