USE [CarRental]
GO

INSERT INTO [dbo].[Users]([Surname],[Name],[BirthDate],[DrivingLicenseNumber]) VALUES 
('Petrov','Ivan','1975-08-22','AA365789'),
('Sidorov','Alex','1980-10-24','AB663424'),
('Vetrov','Vasiliy','2001-09-01','AF555232')
GO

INSERT INTO [dbo].[Cars]([Brand],[Model],[Class],[IssueYear],[RegistrationNumber]) VALUES
('Ford','Focus','Econom',2015,'A2046ST'),
('Opel','Corsa','Econom',2010,'B6654GT'),
('BMW','X5','Business',2019,'D3553DD')
GO

INSERT INTO [dbo].[Orders]([UserId],[CarId],[RentalStartDate],[RentalEndDate],[Comment]) VALUES
(1,1,'2019-10-25','2019-10-30',null),
(2,2,'2019-10-12','2019-10-20','Dent')
GO