create database MoviesDB
use MoviesDB

create table movies (
    Mid int primary key identity,
    Moviename varchar(50),
    DateofRelease date
)
