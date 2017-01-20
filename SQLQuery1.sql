use MoviesBS


CREATE TABLE dbo.Comments (
id varchar(255) ,
email varchar(255), 
comment varchar(255),
commentDate datetime DEFAULT(getdate())

);

CREATE TABLE dbo.Whishlist (
id varchar(255),
email varchar(255)
)
insert into dbo.Whishlist values ('tt2820852', 'bernardo@gma.com')

 CREATE TABLE dbo.Purchases (
id varchar(255),
email varchar(255)
);

insert into dbo.Purchases values ('tt0111161', 'bfhenriques@ua.pt')

CREATE TABLE dbo.Movies (
id varchar(255),
rating varchar(255),
year varchar(255),
poster varchar(255),
title varchar(255),
insertDate datetime DEFAULT(getdate())
);


CREATE TABLE dbo.Genres (
id varchar(255),
genre varchar(255)
);
INSERT INTO dbo.Genres VALUES ('1','Action')
TRUNCATE TABLE dbo.Movies

delete from dbo.Comments where commentDate='2016-12-14 17:48:04.170'

select * from dbo.Movies