create table Property
(
id_Property int not null IDENTITY(1,1),
tittle varchar(255) not null,
address text not null,
descripcion text not null,
created_at datetime not null,
update_at datetime not null,
disable_at datetime null,
status varchar(35) not null,
primary key(id_Property)
)

create table Activity
(
id_Activity int not null IDENTITY(1,1),
property_id int not null,
schedule datetime not null,
title varchar(255) not null,
created_at datetime not null,
updated_at datetime not null,
status varchar(35) not null,
primary key (id_Activity),
foreign key (property_id) references Property(id_Property)

)



create table survey(
id_survey int not null IDENTITY(1,1),
activity_id  int not null FOREIGN KEY REFERENCES Activity(id_Activity),
answers nvarchar(max),
created_at datetime not null,
update_at datetime not null,
primary key(id_survey)
)