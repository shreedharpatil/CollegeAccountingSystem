use das;


create table books(
book_id bigint not null auto_increment primary key,
isbn varchar(500),
title varchar(1000),
authors varchar(500),
publisher varchar(500),
edition varchar(100),
branch_id int(10),
semister varchar(100),
price decimal(10,2),
quantity int(10),
book_language varchar(50),
category_id int(10),
description varchar(200)
);

create table book_category(
book_id int(10) not null auto_increment primary key,
description varchar(200)
);

create table book_borrow(
transaction_id bigint not null auto_increment primary key,
student_id int(10),
student_branch_id int(10),
book_id bigint,
isbn varchar(500),
book_issue_date date,
book_due_date date,
book_return_date date,
fine_amount decimal(10,2),
book_status_id int(10),
remarks varchar(500)
);

create table book_status(
book_status_id int(10) not null auto_increment primary key,
description varchar(100)
);

create table book_limit(
book_limit int(10)
);

insert into login values('admin','admin','librarian');

insert into book_status(description) values('Book Issued');
insert into book_status(description) values('Book Returned');
insert into book_status(description) values('New Book Returned');

insert into book_limit values(3);