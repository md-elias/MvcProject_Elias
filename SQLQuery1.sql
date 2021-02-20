CREATE TABLE Course
(
CourseID int IDENTITY NOT NULL Primary key,
CourseName varchar(30) NULL,
CourseDuration varchar(30) NULL
)
CREATE TABLE Trainee
(
TraineeID int IDENTITY NOT NULL primary key,
CourseID int NULL FOREIGN KEY REFERENCES Course(CourseID),
Name varchar(30) NULL,
Address varchar(100) NULL,
Email varchar(30) NULL,
CellPhone varchar(20) NULL
) 