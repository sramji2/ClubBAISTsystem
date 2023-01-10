GRANT EXECUTE ON uspFindMember TO aspnetcore;
GRANT EXECUTE ON uspUpdateMemberApplication TO aspnetcore;
GRANT EXECUTE ON uspFindMembershipApplication TO aspnetcore;
GRANT EXECUTE ON uspAddMember TO aspnetcore;
GRANT EXECUTE ON uspCalculateHoleByHoleScore TO aspnetcore;
GRANT EXECUTE ON uspClubUserLogin TO aspnetcore;
GRANT EXECUTE ON uspGetHandicapIndex TO aspnetcore;
GRANT EXECUTE ON uspViewPlayerHandicap TO aspnetcore;
GRANT EXECUTE ON uspFindTeeTime TO aspnetcore;
GRANT EXECUTE ON uspAddTeeTime TO aspnetcore;
GRANT EXECUTE ON uspUpdateTeeTime TO aspnetcore;
GRANT EXECUTE ON uspDeleteATeeTime TO aspnetcore;
GRANT EXECUTE ON uspAddPlayer TO aspnetcore;
GRANT EXECUTE ON uspFindPlayer TO aspnetcore;
--GRANT EXECUTE ON uspUpdatePayment TO aspnetcore;
GRANT EXECUTE ON uspAddMemberPayment TO aspnetcore;
GRANT EXECUTE ON uspDeleteStandingTeeTime TO aspnetcore;

use sramji2
GO


DROP TABLE IF EXISTS Player;
DROP TABLE IF EXISTS PlayerHandicapIndex;
DROP TABLE IF EXISTS PlayerScoreCard;
DROP TABLE IF EXISTS MembershipApplication;
DROP TABLE IF EXISTS StandingTeeTimeRequest;
DROP TABLE IF EXISTS TeeTime;
DROP TABLE IF EXISTS Member;
DROP TABLE IF EXISTS MemberPaymentTransaction;
--DROP TABLE IF EXISTS MembershipLevel;
DROP TABLE IF EXISTS ClubEmployeeInfo;
DROP TABLE IF EXISTS ClubUserInfo;
GO
--Table creation starts
CREATE TABLE ClubUserInfo
(

	MemberNumber INT NULL,
	LastName NVARCHAR(50) NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	HomePhone NVARCHAR(15) NULL,
	AlternatePhone NVARCHAR(15)  NULL,
	Email NVARCHAR(100)  NOT NULL
	CONSTRAINT PK_ClubUserInfo_Email PRIMARY KEY,
	Password VARCHAR (100) NOT NULL,
	Role VARCHAR (50) NOT NULL,
	MembershipLevel NVARCHAR(25) NOT NULL
	
);
GO
SELECT * FROM ClubUserInfo;

insert into ClubUserInfo (MemberNumber, LastName, FirstName, HomePhone, AlternatePhone, Email, Password, Role, MembershipLevel)
values (20220408, N'Smith', N'Kevin', N'780-525-3089', N'780-477-5588', N'kev.smith@yahoo.com', N'Test2022#', 'Member', N'Gold');

insert into ClubUserInfo (MemberNumber, LastName, FirstName, HomePhone, AlternatePhone, Email, Password, Role, MembershipLevel)
values (20220409, N'Smith', N'Mary', N'780-222-5555', N'780-477-5588', N'mary.smith@yahoo.com', N'Test2022!', 'Member', N'Silver');

insert into ClubUserInfo (MemberNumber, LastName, FirstName, HomePhone, AlternatePhone, Email, Password, Role, MembershipLevel)
values (20220410, N'Smith', N'Larry', N'587-667-5499', N'780-477-5588', N'larry.smith@yahoo.com', N'Test2022$', 'Member', N'Bronze');

insert into ClubUserInfo (MemberNumber, LastName, FirstName, HomePhone, AlternatePhone, Email, Password, Role, MembershipLevel)
values (20220411, N'McCarthy', N'David', N'780-987-2378', N'780-485-6741', N'dave.mccarthy@gmail.com', N'Test2022%', 'Member', N'Cooper');

insert into ClubUserInfo (MemberNumber, LastName, FirstName, HomePhone, AlternatePhone, Email, Password, Role, MembershipLevel)
values (20220412, N'Kirk', N'Frank', N'403-887-4477', N'780-448-5412', N'frank.kirk@outlook.com', N'Test2022&', 'Shareholder', N'Gold');

insert into ClubUserInfo (MemberNumber, LastName, FirstName, HomePhone, AlternatePhone, Email, Password, Role, MembershipLevel)
values (20220422, N'Ramji', N'Shamir', N'780-232-2147', N'780-440-7830', N'ramjis99@email.com', N'Test2022+', 'Member', N'Gold');


CREATE TABLE ClubEmployeeInfo
(
EmployeeNumber NVARCHAR(50) NOT NULL,
EmployeeName NVARCHAR(50) NULL,
Email NVARCHAR (100) NOT NULL
CONSTRAINT PK_ClubEmployeeInfo_Email PRIMARY KEY,
Password VARCHAR (100) NOT NULL,
Role VARCHAR (50) NULL,
	
);
GO
SELECT * FROM ClubEmployeeInfo;

insert into ClubEmployeeInfo (EmployeeNumber, EmployeeName, Email, Password, Role)
values (10220413, N'Victoria Lambert', N'victoria.lambert@clubbaist.ca', N'Test2022^', 'RuleCommittee');

insert into ClubEmployeeInfo (EmployeeNumber, EmployeeName, Email, Password, Role)
values (10220414, N'Lacy Evans', N'lacy.evans@clubbaist.ca', N'Test2022!&', 'Clerk');

insert into ClubEmployeeInfo (EmployeeNumber, EmployeeName, Email, Password, Role)
values (10220415, N'Keegan Lowe', N'keegan.lowe@clubbaist.ca', N'Test2022!$', 'ProShop');

insert into ClubEmployeeInfo (EmployeeNumber, EmployeeName, Email, Password, Role)
values (10220416, N'Daniel Freeman', N'daniel.freeman@clubbaist.ca', N'Test2022**', 'MembershipCommittee');


--MembershipLevel Table
--CREATE TABLE MembershipLevel
--(
--MembershipType NVARCHAR(15) 
--	CONSTRAINT PK_MemebershipLevel_MembershipLevel PRIMARY KEY,
--);
--GO
CREATE TABLE MemberPaymentTransaction
(
	PaymentID INT IDENTITY (700000,1)
	CONSTRAINT PK_MemberPaymentTransaction_PaymentID PRIMARY KEY,
	Date NVARCHAR(25) NOT NULL,
    LastName NVARCHAR(50) NOT NULL,
    FirstName NVARCHAR(50) NOT NULL,
    CreditCardNumber INT NOT NULL,
    ExpiryDate NVARCHAR(10) NOT NULL,
	Currency NVARCHAR (10) NOT NULL,
	PaymentDescription NVARCHAR(50) NOT NULL,
	AmountPaid DECIMAL(10,2) NULL,
	BalanceDue DECIMAL(10,2) NULL,
	BalanceOwing DECIMAL(10,2) NULL,


);
GO

CREATE TABLE Member
(
	MemberNumber INT NOT NULL PRIMARY KEY,
	LastName NVARCHAR(50) NOT NULL,
	FirstName NVARCHAR(50) NOT NULL,
	--MembershipLevels are Gold, Silver, Bronze. 
	MembershipLevel NVARCHAR(25) NOT NULL,
	HomeAddress NVARCHAR(50) NULL,
	HomePostalCode NVARCHAR(10)  NULL,
	HomePhone NVARCHAR(15) NULL,
	AlternatePhone NVARCHAR(15)  NULL,
	Email NVARCHAR(100)  NULL,
	DateOfBirth NVARCHAR(25)   NULL,
	Occupation NVARCHAR(50)  NULL,
	CompanyName NVARCHAR(50)  NULL,
	CompanyAddress NVARCHAR(50)  NULL,
	CompanyPostalCode NVARCHAR(10)  NULL,
	CompanyPhone NVARCHAR(15)  NULL,
	DateCharged NVARCHAR(25) NOT NULL,
    PaymentDescription NVARCHAR(100) NULL,
    AmountPaid DECIMAL(10,2) NULL,
	BalanceDue DECIMAL(10,2) NULL,
	BalanceOwing DECIMAL(10,2) NULL,
);
GO
INSERT INTO Member(MemberNumber, LastName, FirstName, MembershipLevel, HomeAddress, HomePostalCode, HomePhone
, AlternatePhone, Email, DateOfBirth, Occupation, CompanyName, CompanyAddress,CompanyPostalCode, CompanyPhone
, DateCharged, PaymentDescription, AmountPaid, BalanceOwing, BalanceDue) VALUES
	('20220408', N'Smith', N'Kevin', N'Gold', N'5678 50 street NW, Edmonton, AB', N'T3T 2V2', N'780-525-3089'
	, N'780-444-3344', N'kev.smith@yahoo.com', N'1978-03-16', N'Doctor', N'AHS', N'7897 112 Street NW', N'T6W 2N4'
	, N'780-444-3344', N'2022-01-01', N'Entrance Fee', N'10000.00', N'500.00', N'500.00' );

INSERT INTO Member(MemberNumber, LastName, FirstName, MembershipLevel, HomeAddress, HomePostalCode, HomePhone
, AlternatePhone, Email, DateOfBirth, Occupation, CompanyName, CompanyAddress,CompanyPostalCode, CompanyPhone
, DateCharged, PaymentDescription, AmountPaid) VALUES
	('20220409', N'Smith', N'Mary', N'Silver', N'5678 50 street NW, Edmonton, AB', N'T3T 2V2', N'780-222-5555'
	, N'780-444-33448', N'mary.smith@yahoo.com', N'1979-08-20', N'Engineer', N'Stantec', N'10400 109 street', N'T5K 2Z4'
	, N'780-477-5588', N'20220120', N'Membership Fees', N'2000.00' );

SELECT * FROM Member

CREATE TABLE TeeTime
(
ConfirmationNumber INT IDENTITY (100000,1)
	CONSTRAINT PK_TeeTime_ConfirmationNumber PRIMARY KEY,
[Date] NVARCHAR(25) NOT NULL,
[Time] NVARCHAR(25) NOT NULL,
MembershipLevel NVARCHAR(25) NULL,
LastName NVARCHAR (50) NOT NULL,
FirstName NVARCHAR (50) NOT NULL,
NumberOfPlayers INT NOT NULL,
Phone NVARCHAR(25)  NULL,
AlternatePhone NVARCHAR(25)  NULL,
NumberOfCarts INT NOT NULL,
EmployeeName NVARCHAR(50) NULL,
CheckIn BIT NULL DEFAULT 0,


);
GO
INSERT INTO TeeTime ([Date], [Time], MembershipLevel, LastName, FirstName, Phone, AlternatePhone, NumberOfPlayers, NumberOfCarts) VALUES
	((N'2022-04-23'), (N'8:30 am'),N'Gold', N'Ramji', N'Shamir', N'780-777-8888', N'780-448-3232','3' , '3');
	
 SELECT * FROM TeeTime

--Standing Tee Time Request Table
CREATE TABLE StandingTeeTimeRequest
(
PriorityNumber INT IDENTITY (400000,1)
CONSTRAINT PK_StandingTeeTimeRequest_PriorityNumber PRIMARY KEY,
MembershipLevel NVARCHAR(25)  DEFAULT 'Gold',
--Kept Role in here for future considerations.
Role VARCHAR (50) NULL,
RequestedDayOfWeek AS DATENAME(DW, RequestedStartDate), 
RequestedStartDate NVARCHAR(25),
RequestedEndDate NVARCHAR(25),
RequestedTeeTime NVARCHAR(25) NOT NULL, 
MemberNumber INT NOT NULL,
MemberName NVARCHAR(50) NOT NULL,
MemberNumber2 INT NOT NULL,
MemberNumber3 INT NOT NULL,
MemberNumber4 INT NOT NULL,
MemberName2 NVARCHAR(50) NOT NULL,
MemberName3 NVARCHAR(50) NOT NULL,
MemberName4 NVARCHAR(50) NOT NULL,
ApprovedTeeTime NVARCHAR(25) NULL,
ApprovedBy NVARCHAR(50) NULL,
ApprovedDate NVARCHAR(25) NULL,


);
GO
SELECT * FROM StandingTeeTimeRequest

--Membership Application Table
CREATE TABLE MembershipApplication
(
ApplicationID INT IDENTITY(20000,1) PRIMARY KEY,
ApplicationStatus NVARCHAR(15) DEFAULT 'On-Hold',
MembershipLevel NVARCHAR(25) NULL,
LastName NVARCHAR(50) NOT NULL,
FirstName NVARCHAR(50) NOT NULL,
HomeAddress NVARCHAR(50) NULL,
HomeCity NVARCHAR(50) NULL,
HomeProvince NVARCHAR(50) NULL,
HomePostalCode NVARCHAR(10)  NULL,
HomePhone NVARCHAR(15) NULL,
AlternatePhone NVARCHAR(15)  NULL,
Email NVARCHAR(100)  NULL,
DateOfBirth DATE   NULL,
Occupation NVARCHAR(50)  NULL,
CompanyName NVARCHAR(50)  NULL,
CompanyAddress NVARCHAR(50)  NULL,
CompanyCity NVARCHAR(50)  NULL,
CompanyProvince NVARCHAR(50)  NULL,
CompanyPostalCode NVARCHAR(10)  NULL,
CompanyPhone NVARCHAR(10)  NULL,
[Date] NVARCHAR(25) NOT NULL,
ShareholderName1 NVARCHAR(50) NOT NULL,
ShareholderName2 NVARCHAR(50) NOT NULL,
ApprovedBy NVARCHAR(50) NULL,

);

GO

SELECT * FROM MembershipApplication

--Score card for both Player
CREATE TABLE PlayerScoreCard
(
ScoreID INT IDENTITY(60000,1) PRIMARY KEY,
GolfCourse NVARCHAR(50) NOT NULL,
[Date] NVARCHAR(25) NOT NULL,
Email NVARCHAR(100) NOT NULL,
MemberNumber INT NOT NULL,
Hole1 INT NOT NULL,
Hole2 INT NOT NULL,
Hole3 INT NOT NULL,
Hole4 INT NOT NULL,
Hole5 INT NOT NULL,
Hole6 INT NOT NULL,
Hole7 INT NOT NULL,
Hole8 INT NOT NULL,
Hole9 INT NOT NULL,
Hole10 INT NOT NULL,
Hole11 INT NOT NULL,
Hole12 INT NOT NULL,
Hole13 INT NOT NULL,
Hole14 INT NOT NULL,
Hole15 INT NOT NULL,
Hole16 INT NOT NULL,
Hole17 INT NOT NULL,
Hole18 INT NOT NULL,
AdjustedGrossScore INT NULL,
CourseRating DECIMAL(5,1) NOT NULL,
SlopeRating DECIMAL(5,1) NOT NULL,
PCCAdjustment DECIMAL(3,1) DEFAULT 0.0,
ScoreDifferential DECIMAL(5,1)  NULL,

);
GO
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email, MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-01', N'kev.smith@yahoo.com', '20220408', '-2','-2', '-2', '-2','-2', '-2','-2','-2'
, '-2','-3','-3','-2','-4','-3','-3','-3','-3','-5', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email, MemberNumber,Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-02', N'kev.smith@yahoo.com', '20220408','-2','-2', '-2', '-2','-2', '-2','-2','-2'
, '-2','-3','-3','-2','-4','-3','-3','-3','-3','-5', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email, MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-03', N'kev.smith@yahoo.com', '20220408','-4','-1', '-1', '-1','-3', '-1','-4','-3'
, '-3','-3','-3','-2','-2','-3','-3','-2','-3','-4', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email, MemberNumber,Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-04', N'kev.smith@yahoo.com','20220408', '-3','-2', '-2', '-2','-1', '-1','0','-1'
, '-2','-3','-3','-1','-3','-1','-2','-2','-3','-3', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email,MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-05', N'kev.smith@yahoo.com', '20220408','-2','-3', '-3', '-3','-2', '-1','-2','-1'
, '0','-3','-3','-2','-3','-2','-2','-2','-2','-3', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email,MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-06', N'kev.smith@yahoo.com','20220408', '-1','-3', '-1', '-3','-2', '-2','-2','-2'
, '-1','-2','-4','-2','-4','-1','-1','-1','-2','-3', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email,MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-07', N'kev.smith@yahoo.com','20220408', '-2','-2', '-2', '-1','-3', '-2','-2','-3'
, '-2','-3','-3','-1','-4','-3','-3','-3','-3','-3', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email,MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-08', N'kev.smith@yahoo.com','20220408', '0','-1', '-2', '-2','-2', '-2','-3','-2'
, '-4','-3','-3','-5','-4','-3','-3','-3','-3','-2', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email,MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-09', N'kev.smith@yahoo.com','20220408', '-1','-1', '-2', '-2','-2', '-5','-2','-3'
, '-2','-3','-3','-2','-4','-3','-3','-4','-3','-5', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email, MemberNumber,Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-10', N'kev.smith@yahoo.com', '20220408','-1','-2', '-2', '-2','3', '-2','1','-2'
, '-2','-3','2','1','-4','-3','3','-3','-3','-5', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email,MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-11', N'kev.smith@yahoo.com','20220408', '1','-2', '2', '2','2', '-2','2','-2'
, '-2','1','-3','1','-4','-3','-3','3','-3','-5', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email, MemberNumber,Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-12', N'kev.smith@yahoo.com','20220408', '3','-2', '3', '-2','-2', '-2','3','-2'
, '-2','-3','3','2','4','-3','-3','4','-3','-5', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email, MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-13', N'kev.smith@yahoo.com','20220408', '-2','-2', '-2', '-2','-2', '-2','-2','-2'
, '-2','-3','-3','-2','-4','-3','-3','-3','-3','-5', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email,MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-14', N'kev.smith@yahoo.com','20220408', '0','0', '0', '-2','-2', '-2','-2','-2'
, '-2','-3','-3','-1','-4','-3','-3','-3','-3','-3', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email, MemberNumber,Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-15', N'kev.smith@yahoo.com','20220408', '-1','-1', '-2', '-2','-2', '-1','-1','-2'
, '-2','-3','-3','-2','-1','-1','-3','-3','-2','-5', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email,MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-16', N'kev.smith@yahoo.com','20220408', '0','3', '3', '-2','-2', '-2','-2','-2'
, '-2','0','-3','0','-4','-3','-3','-3','4','-5', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email, MemberNumber,Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-17', N'kev.smith@yahoo.com','20220408', '0','0', '0', '2','2', '-2','-2','-2'
, '-2','-1','-1','-1','-1','-2','-1','-1','-1','-1', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email,MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-18', N'kev.smith@yahoo.com','20220408', '-2','-2', '-2', '-2','-2', '-2','-2','-2'
, '-2','-3','-3','-2','-4','-3','-3','-3','-3','-5', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email,MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-19', N'kev.smith@yahoo.com','20220408', '-3','-3', '-3', '-3','-3', '-3','-3','-3'
, '-2','-3','-3','-2','-4','-3','-3','-3','-3','-5', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email,MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-20', N'kev.smith@yahoo.com','20220408', '-1','-1', '-1', '-1','-1', '-1','0','-1'
, '-2','-1','-1','-2','-1','-1','-1','-2','-2','-2', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email,MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-21', N'kev.smith@yahoo.com','20220408', '-2','0', '0', '-1','-1', '-1','0','2'
, '-2','-1','-1','-2','0','0','0','0','2','-2', '70.0', '131.0', '0.0');
INSERT INTO PlayerScoreCard (GolfCourse, Date, Email,MemberNumber, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8
, Hole9,Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, CourseRating
,SlopeRating, PCCAdjustment) 
VALUES (N'Club BAIST', N'2022-04-22', N'kev.smith@yahoo.com', '20220408','-1','-1', '-1', '-1','-1', '-1','0','-1'
, '-2','-1','-1','-2','-1','-1','-1','-2','-2','-2', '70.0', '131.0', '0.0');

SELECT * FROM PlayerScoreCard

CREATE TABLE PlayerHandicapIndex
(
	PlayerIndexID INT IDENTITY (70000, 1) PRIMARY KEY,
    MemberNumber INT NOT NULL,
    [Date] NVARCHAR (25) NOT NULL,
    AdjustedGrossScore INT NOT NULL,
    CourseRating DECIMAL(5,1) NOT NULL,
    SlopeRating INT NOT NULL,
	PCCAdjustment DECIMAL(3,1) DEFAULT(0.0) NULL,
	ScoreDifferential DECIMAL(5,1) NULL,

 
);
GO

CREATE TABLE Player
(
MemberNumber INT NOT NULL,
MembershipLevel NVARCHAR(25) NULL,
LastName NVARCHAR(50)  NULL,
FirstName NVARCHAR(50)  NULL,
Email NVARCHAR(100)  NULL,
Phone NVARCHAR(50) NULL
);
GO
INSERT INTO Player (MemberNumber, MembershipLevel, LastName,FirstName, Email, Phone)
VALUES (N'20220408', N'Gold', N'Smith', N'Kevin', N'kev.smith@yahoo.com', N'780-525-3089');


SELECT * FROM Player

SELECT * FROM Member

--For now Table creation ends

--Procedures start


DROP PROC IF EXISTS uspClubUserLogin
GO
CREATE PROC uspClubUserLogin
(
	@Email NVARCHAR(50),
	@Password VARCHAR(100)
)
AS
DECLARE @ReturnStatus INT = 0

IF @Email IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspClubUserLogin- Parameter required for @Email' ,16,1)
		END
		IF @Password IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspClubUserLogin- Parameter required for @Password' ,16,1)
		END
IF @ReturnStatus = 0
	BEGIN
		SELECT Email, [Password], MemberNumber, LastName, FirstName, HomePhone, AlternatePhone, Role, MembershipLevel 
		FROM ClubUserInfo 
	where Email = @Email
	--and Password = hashbytes('sha2_512', @Password + cast(salt as nvarchar (36)))
	END
GO
EXEC uspClubUserLogin
@Email = N'mary.smith@yahoo.com'
,@Password = 'Test2022!';
select * from ClubUserInfo

--ClubEmployeeInfo Store Procedure
DROP PROC IF EXISTS uspClubEmployeeLogin
GO
CREATE PROC uspClubEmployeeLogin
(
	@EmployeeNumber NVARCHAR(50),
	@Password VARCHAR(100)
)
AS
DECLARE @ReturnStatus INT = 0
IF @EmployeeNumber IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspClubEmployeeLogin - Parameter EmployeeNumber is required', 16,1)
	END
	IF @Password IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspClubEmployeeLogin - Parameter Password is required', 16,1)
	END
	IF @ReturnStatus = 0
	BEGIN
		SELECT EmployeeNumber, EmployeeName, Email, Password, Role 
		FROM ClubEmployeeInfo
	WHERE EmployeeNumber = @EmployeeNumber
	END
GO
EXEC uspClubEmployeeLogin
@EmployeeNumber = N'10220416'
,@Password = 'Test2022**';
select * from ClubEmployeeInfo

DROP PROC IF EXISTS uspAddPlayer
GO
CREATE PROC uspAddPlayer
@MemberNumber INT = NULL,
@MembershipLevel NVARCHAR(25) = NULL,
@LastName NVARCHAR(50) = NULL,
@FirstName NVARCHAR(50) = NULL,
@Email NVARCHAR(100) = NULL,
@Phone NVARCHAR(15) = NULL

AS

DECLARE @ReturnStatus INT = 0

IF @MemberNumber IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddPlayer = Parameter MemberNumber is required', 16,1)
	END
IF @LastName IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddPlayer = Parameter Last Name is required', 16,1)
	END
	IF @FirstName IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddPlayer = Parameter First Name is required', 16,1)
	END
	IF @Email IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddPlayer = Parameter Email is required', 16,1)
	END
		IF @Phone IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddPlayer = Parameter Phone is required', 16,1)
	END

IF @ReturnStatus = 0
	BEGIN
	INSERT INTO Player (MemberNumber, MembershipLevel, LastName, FirstName, Email, Phone)
	VALUES (@MemberNumber, @MembershipLevel, @LastName, @FirstName, @Email, @Phone)

		IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspAddPlayer - Error adding New Member Information',16,1)
		END
	END

	RETURN @ReturnStatus
GO
DECLARE @RC INT
EXEC @RC = uspAddPlayer @MemberNumber = '20044557',@MembershipLevel = N'Gold', @LastName = N'Ramji', @FirstName = N'Shamir', @Email = N'ramjis99@email.com'
, @Phone = N'780-232-7878'
PRINT @RC

DROP PROC IF EXISTS uspFindPlayer
GO
CREATE PROC uspFindPlayer
@Email NVARCHAR(50) = NULL,
@MemberNumber NVARCHAR(50) = NULL
AS

DECLARE @ReturnStatus INT = 0

IF @Email IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspFindPlayer = Parameter Email is required', 16,1)
	END
IF @ReturnStatus = 0
BEGIN
SELECT MemberNumber, MembershipLevel, LastName, FirstName, Email, Phone
FROM Player
WHERE Email = @Email

IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspFindPlayer - Error retreiving Player Information',16,1)
		END
	END

	RETURN @ReturnStatus
GO
--Using the Player table not Member
DECLARE @RC INT
EXEC @RC = uspFindPlayer @Email = N'kev.smith@yahoo.com'
PRINT @RC

--Add Member Store Procedure
DROP PROC IF EXISTS uspAddMember
GO
CREATE PROC uspAddMember
@MembershipLevel NVARCHAR(25) = NULL,
@LastName NVARCHAR(50) = NULL,
@FirstName NVARCHAR(50) = NULL,
@HomeAddress NVARCHAR(50) = NULL,
@HomeCity NVARCHAR(50) = NULL,
@HomeProvince NVARCHAR(50) = NULL,
@HomePostalCode NVARCHAR(10) = NULL,
@HomePhone NVARCHAR(15) = NULL,
@AlternatePhone NVARCHAR(15) = NULL,
@Email NVARCHAR(100) = NULL,
@DateOfBirth NVARCHAR(50) = NULL,
@Occupation NVARCHAR(50) = NULL,
@CompanyName NVARCHAR(50) = NULL,
@CompanyAddress NVARCHAR(50) = NULL,
@CompanyCity NVARCHAR(50) = NULL,
@CompanyProvince NVARCHAR(50) = NULL,
@CompanyPostalCode NVARCHAR(10) = NULL,
@CompanyPhone NVARCHAR(10) = NULL,
@Date DATE = NULL,
@ShareholderName1 NVARCHAR(50) = NULL,
@ShareholderName2 NVARCHAR(50) = NULL,
@ApprovedBy NVARCHAR(25) = NULL,
@ApplicationStatus NVARCHAR(15) OUTPUT,
@ApplicationID INT OUTPUT

AS

DECLARE @ReturnStatus INT = 0

IF @LastName IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Last Name is required', 16,1)
	END
IF @FirstName IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter First Name is required', 16,1)
	END
	IF @HomeAddress IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Home Address is required', 16,1)
	END
	IF @HomeCity IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Home City is required', 16,1)
	END
	IF @HomeProvince IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Home Province is required', 16,1)
	END
	IF @HomePostalCode IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Home PostalCode is required', 16,1)
	END
	IF @HomePhone IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Home Phone is required', 16,1)
	END
	IF @AlternatePhone IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Alternate Phone is required', 16,1)
	END
	IF @Email IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Email is required', 16,1)
	END
	IF @DateOfBirth IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Date of Birth is required', 16,1)
	END
	IF @Occupation IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Occupation is required', 16,1)
	END
	IF @CompanyName IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Company Name is required', 16,1)
	END
	IF @CompanyAddress IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Company Address is required', 16,1)
	END
	IF @CompanyCity IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Company City is required', 16,1)
	END
	IF @CompanyProvince IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Company Province is required', 16,1)
	END
	IF @CompanyPostalCode IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Company PostalCode is required', 16,1)
	END
	IF @CompanyPhone IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Company Phone is required', 16,1)
	END
	
	IF @Date IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter Date is required', 16,1)
	END
	IF @ShareholderName1 IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter ShareholderName1 is required', 16,1)
	END
	IF @ShareholderName2 IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMember = Parameter ShareholderName2 is required', 16,1)
	END
		
	IF @ReturnStatus = 0
	BEGIN
	INSERT INTO MembershipApplication(MembershipLevel, LastName, FirstName, HomeAddress, HomeCity, HomeProvince, HomePostalCode, HomePhone, AlternatePhone
	,ApplicationStatus, Email, DateOfBirth, Occupation, CompanyName, CompanyAddress,CompanyCity, CompanyProvince, CompanyPostalCode, CompanyPhone
	, [Date], ShareholderName1,  ShareholderName2)
	VALUES (@MembershipLevel, @LastName, @FirstName, @HomeAddress, @HomeCity, @HomeProvince, @HomePostalCode, @HomePhone, @AlternatePhone, 'On-Hold', @Email, @DateOfBirth
	, @Occupation, @CompanyName, @CompanyAddress, @CompanyCity, @CompanyProvince, @CompanyPostalCode, @CompanyPhone, @Date, @ShareholderName1
	, @ShareholderName2)
	SELECT @ApplicationID = SCOPE_IDENTITY()
	
	

		IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspAddMember - Error adding New Member Information',16,1)
		END
	END

	RETURN @ReturnStatus
GO

DECLARE @RC INT
DECLARE @ApplicationID INT
DECLARE @ApplicationStatus NVARCHAR(15)
EXEC @RC = uspAddMember @LastName = N'Ramji', @FirstName =  N'Shamir', @HomeAddress = N'3456 Home Address'
, @HomePostalCode = N'T5T 1R1', @HomePhone = N'780-555-3456', @AlternatePhone = N'587-444-9900'
, @Email = N'shamirramji@googlemail.com', @DateOfBirth=N'19780613', @Occupation=N'Engineer', @CompanyName=N'Stantec'
, @CompanyAddress=N'14725 125 street NW, Edmonton, AB', @CompanyPostalCode = N'T6T 2Y6', @CompanyPhone = N'780-477-7800'
, @Date = N'20220315', @ShareholderName1 = N'Cindy Smith', @ShareholderName2 = N'Donald Glover'
, @ApplicationID = @ApplicationID OUTPUT, @ApplicationStatus = @ApplicationStatus OUTPUT
PRINT @RC
PRINT @ApplicationID
PRINT @ApplicationStatus

SELECT * FROM MembershipApplication

DROP PROC IF EXISTS uspFindMembershipApplication
GO
CREATE PROC uspFindMembershipApplication
@ApplicationID INT = NULL,
@MembershipLevel NVARCHAR (25) = NULL,
@LastName NVARCHAR(50) = NULL,
@FirstName NVARCHAR(50) = NULL,
@HomeAddress NVARCHAR(50) = NULL,
@HomeCity NVARCHAR(50) = NULL,
@HomeProvince NVARCHAR(50) = NULL,
@HomePostalCode NVARCHAR(10) = NULL,
@HomePhone NVARCHAR(15) = NULL,
@AlternatePhone NVARCHAR(15) = NULL,
@Email NVARCHAR(100) = NULL,
@DateOfBirth NVARCHAR(50) = NULL,
@Occupation NVARCHAR(50) = NULL,
@CompanyName NVARCHAR(50) = NULL,
@CompanyAddress NVARCHAR(50) = NULL,
@CompanyCity NVARCHAR(50) = NULL,
@CompanyProvince NVARCHAR(50) = NULL,
@CompanyPostalCode NVARCHAR(10) = NULL,
@CompanyPhone NVARCHAR(15) = NULL,
@Date NVARCHAR (25) = NULL,
@ShareholderName1 NVARCHAR(50) = NULL,
@ShareholderName2 NVARCHAR(50) = NULL,
@ApprovedBy NVARCHAR(25) = NULL,
@ApplicationStatus NVARCHAR(15)  = NULL 
AS
DECLARE @ReturnStatus INT = 0

--IF @ApplicationStatus IS NULL
--BEGIN
--		SET @ReturnStatus = 1
--		RAISERROR('uspFindMembershipApplication- Parameter required for @ApplicationStatus' ,16,1)
--		END
IF @ReturnStatus = 0
BEGIN
SELECT ApplicationID, ApplicationStatus, MembershipLevel,LastName, FirstName, HomeAddress, HomeCity, HomeProvince
	, HomePostalCode, HomePhone, AlternatePhone, Email, DateOfBirth, Occupation, CompanyName
	, CompanyAddress, CompanyCity, CompanyProvince, CompanyPostalCode
	, CompanyPhone, [Date], ShareholderName1,  ShareholderName2, ApprovedBy
FROM MembershipApplication
WHERE ApplicationStatus = @ApplicationStatus

	IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspFindMembershipApplication - Error retreiving Customer Information',16,1)
		END
	END

	RETURN @ReturnStatus
GO
DECLARE @RC INT
EXEC @RC = uspFindMembershipApplication @ApplicationStatus = N'On-Hold'
PRINT @RC

SELECT * FROM MembershipApplication

--Update Member Application from On-Hold to Waitlisted, Approved, Denied
DROP PROC IF EXISTS uspUpdateMemberApplication
GO
CREATE PROC uspUpdateMemberApplication
@ApplicationID INT = NULL,
@LastName NVARCHAR(50) = NULL,
@FirstName NVARCHAR(50) = NULL,
@MembershipLevel NVARCHAR(25) = NULL,
@HomeAddress NVARCHAR(50) = NULL,
@HomePostalCode NVARCHAR(10) = NULL,
@HomePhone NVARCHAR(15) = NULL,
@AlternatePhone NVARCHAR(15) = NULL,
@Email NVARCHAR(100) = NULL,
@DateOfBirth NVARCHAR(50) = NULL,
@Occupation NVARCHAR(50) = NULL,
@CompanyName NVARCHAR(50) = NULL,
@CompanyAddress NVARCHAR(50) = NULL,
@CompanyPostalCode NVARCHAR(10) = NULL,
@CompanyPhone NVARCHAR(10) = NULL,
@Date DATE = NULL,
@ShareholderName1 NVARCHAR(50) = NULL,
@ShareholderName2 NVARCHAR(50) = NULL,
@ApprovedBy NVARCHAR(25) = NULL,
@ApplicationStatus NVARCHAR(15)  = NULL


AS

DECLARE @ReturnStatus INT = 0

IF @ApplicationStatus IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspUpdateMemberApplication = Parameter @ApplicationStatus is required', 16,1)
END

IF @ReturnStatus = 0
BEGIN

UPDATE MembershipApplication
SET ApplicationStatus = @ApplicationStatus, MembershipLevel = @MembershipLevel, ApprovedBy = @ApprovedBy
WHERE ApplicationID = @ApplicationID 

IF @@ERROR <> 0 
	BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspUpdateMemberApplication - Error updating Member Application Information',16,1)
	END
END
	RETURN @ReturnStatus
GO	

DECLARE @RC INT
EXEC uspUpdateMemberApplication @ApplicationID = '20000', @ApplicationStatus= N'Accepted', @MembershipLevel=N'Gold', @ApprovedBy=N'Shamir Ramji'
PRINT @RC
GO
--Add Tee Time Store Procedure.
DROP PROC IF EXISTS uspAddTeeTime
GO
CREATE PROC uspAddTeeTime

@Date NVARCHAR(25) = NULL,
@Time NVARCHAR(25) = NULL,
@MembershipLevel NVARCHAR(25) = NULL,
@LastName NVARCHAR(50) = NULL,
@FirstName NVARCHAR(50) = NULL,
@Phone NVARCHAR(25) = NULL,
@AlternatePhone NVARCHAR(25) = NULL,
@NumberOfPlayers INT = NULL,
@NumberOfCarts INT = NULL,
@EmployeeName NVARCHAR(50) = NULL,
@ConfirmationNumber INT OUTPUT


AS
	DECLARE @RETURNSTATUS INT = 0
		
		IF @Date IS NULL
		BEGIN
			SET @RETURNSTATUS = 1
			RAISERROR ('uspAddTeeTime - Required parameter @Date', 16,1)
		END

		IF @Time IS NULL
		BEGIN
			SET @RETURNSTATUS = 1
			RAISERROR ('uspAddTeeTime - Required parameter @Time', 16,1)
		END

			IF @LastName IS NULL
		BEGIN
			SET @RETURNSTATUS = 1
			RAISERROR ('uspAddTeeTime - Required parameter @LastName', 16,1)
		END

		IF @FirstName IS NULL
		BEGIN
			SET @RETURNSTATUS = 1
			RAISERROR ('uspAddTeeTime - Required parameter @FirstName', 16,1)
		END

		IF @NumberOfPlayers IS NULL
		BEGIN
			SET @RETURNSTATUS = 1
			RAISERROR ('uspAddTeeTime - Required parameter @NumberOfPlayers', 16,1)
		END

		IF @Phone IS NULL
		BEGIN
			SET @RETURNSTATUS = 1
			RAISERROR ('uspAddTeeTime - Required parameter @Phone', 16,1)
		END

		IF @NumberOfCarts IS NULL
		BEGIN
			SET @RETURNSTATUS = 1
			RAISERROR ('uspAddTeeTime - Required parameter @NumberOfCarts', 16,1)
		END

		IF @ReturnStatus = 0
	BEGIN
		INSERT INTO TeeTime([Date], [Time], MembershipLevel, LastName, FirstName, Phone, AlternatePhone, NumberOfPlayers, NumberOfCarts, EmployeeName)
			VALUES(@Date, @Time, @MembershipLevel, @LastName, @FirstName, @Phone, @AlternatePhone, @NumberOfPlayers, @NumberOfCarts, @EmployeeName)
			SELECT @ConfirmationNumber = SCOPE_IDENTITY()

	IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspAddTeeTime - Error inserting into Daily Tee Sheet.',16,1)
		END
	END

	RETURN @ReturnStatus
GO

DECLARE @RC INT
DECLARE @ConfirmationNumber INT
EXEC @RC = uspAddTeeTime @Date= N'2022-09-30', @Time=N'7:30', @MembershipLevel = N'Gold', @LastName=N'Smith', @FirstName=N'Kevin', @Phone=N'780-555-9999', @AlternatePhone= N'780-222-7744', @NumberOfPlayers='2' 
, @NumberOfCarts = '2', @ConfirmationNumber = @ConfirmationNumber OUTPUT
PRINT @RC
PRINT @ConfirmationNumber

--Find Tee Time Procedure. A user enters either their PlayerNumber find Tee Time
--Player Proshop staff and clerk can modify tee time
DROP PROC IF EXISTS uspFindTeeTime
GO
CREATE PROC uspFindTeeTime
	@Date NVARCHAR(25) = NULL,
	@Time NVARCHAR(25) = NULL,
	@ConfirmationNumber INT = NULL

AS
	DECLARE @ReturnStatus INT = 0

	IF @Date IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspFindTeeTime-Parameter required for @Date', 16,1)
		END
		IF @Time IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspFindTeeTime-Parameter required for @Time', 16,1)
		END
	
		IF @ReturnStatus = 0
		BEGIN
		
			SELECT ConfirmationNumber, [Date], [Time], MembershipLevel, LastName, FirstName, NumberOfPlayers, Phone, AlternatePhone, NumberOfCarts, EmployeeName, CheckIn
			FROM TeeTime
			WHERE [Date] = @Date AND [Time] = @Time

			IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspFindTeeTime - Error retreiving Tee Time Information',16,1)
		END
	END

	RETURN @ReturnStatus
GO

EXEC uspFindTeeTime @Date = '2022-04-21', @Time=N'7:15 am'
--Make sure to include intervals on the BookTeeTime.cshtml.cs side

SELECT * FROM TeeTime

DECLARE @ReturnStatus INT
EXEC @ReturnStatus = uspFindTeeTime @Date = N'2022-05-30', @Time = N'8:30'
PRINT @ReturnStatus

--Update/Modify Tee Time. An actor (player, employee) will enter their PlayerNumber to update Tee Time

--If date and time is booked. Tee time cannot be confirmed.
DROP PROC IF EXISTS uspUpdateTeeTime
GO
CREATE PROC uspUpdateTeeTime
@ConfirmationNumber INT = NULL,
@Date NVARCHAR (25) = NULL,
@Time NVARCHAR (25) = NULL,
@MembershipLevel NVARCHAR(25) = NULL,
@LastName NVARCHAR(50) = NULL,
@FirstName NVARCHAR(50) = NULL,
@Phone NVARCHAR(25) = NULL,
@AlternatePhone NVARCHAR(25) = NULL,
@NumberOfPlayers INT = NULL,
@NumberOfCarts INT = NULL,
@EmployeeName NVARCHAR(50) = NULL,
@CheckIn BIT = NULL

AS
	DECLARE @ReturnStatus INT = 0

IF @Date IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspUpdateTeeTime - Parameter Date is required', 16,1)
	END
IF @Time IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspUpdateTeeTime - Parameter Time is required', 16,1)
	END
	
	IF @NumberOfPlayers IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspUpdateTeeTime - Parameter Number Of Players is required', 16,1)
	END

IF @NumberOfCarts IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspUpdateTeeTime - Parameter Number Of Carts is required', 16,1)
	END

IF @ReturnStatus = 0
	BEGIN
	UPDATE TeeTime
		SET @Date = Date, Time = @Time, MembershipLevel = @MembershipLevel
		,LastName = @LastName, FirstName = @FirstName,NumberOfPlayers = @NumberOfPlayers, Phone = @Phone
		, AlternatePhone=@AlternatePhone, NumberOfCarts = @NumberOfCarts, EmployeeName = @EmployeeName, CheckIn=@CheckIn
		WHERE ConfirmationNumber = @ConfirmationNumber

	IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspUpdateTeeTime - Error updating Tee Time Reservation',16,1)
		END
	END

	RETURN @ReturnStatus
GO
EXEC uspUpdateTeeTime @ConfirmationNumber = '100001', @Date = N'2022-07-28', @Time= N'8:00 am'
, @NumberOfPlayers='1', @NumberOfCarts ='1', @CheckIn = '1' 

SELECT * FROM TeeTime
SELECT * FROM ClubUserInfo
--DECLARE @ReturnStatus INT
--EXEC @ReturnStatus = uspUpdateTeeTime @ConfirmationNumber = '100000', N'20220530', N'8:00', N'Smith', N'Kevin', '3', N'780-777-8888', '3'
--PRINT @ReturnStatus

--Deletes/Removes Tee Time by @ConfirmationNumber
DROP PROC IF EXISTS uspDeleteATeeTime
GO
CREATE PROC uspDeleteATeeTime
@ConfirmationNumber INT = NULL,
@Date NVARCHAR (25) = NULL,
@Time NVARCHAR (25) = NULL
AS
	DECLARE @ReturnStatus INT = 0

IF @Date IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspUpdateTeeTime - Parameter Date is required', 16,1)
	END
IF @Time IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspUpdateTeeTime - Parameter Time is required', 16,1)
	END
	
	IF @ReturnStatus = 0
	BEGIN
		DELETE TeeTime
			WHERE Date = @Date AND Time = @Time

		IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspDeleteATeeTime - Error Deleting Tee Time.',16,1)
		END
	END
	RETURN @ReturnStatus
GO
DECLARE @RC INT
EXEC @RC = uspDeleteATeeTime @Date = N'2022-07-27', @Time=N'8:00 am'
PRINT @RC

--Standing Tee Time Requests. Actors Member(Shareholder) Gold Membership only
DROP PROC IF EXISTS uspAddStandingTeeTime
GO
CREATE PROC uspAddStandingTeeTime

@MembershipLevel NVARCHAR(50) = NULL,
--@Role VARCHAR(50) = NULL,
@RequestedDayOfWeek NVARCHAR(25) = NULL,
@RequestedStartDate  NVARCHAR(25) = NULL,
@RequestedEndDate NVARCHAR(25) NULL,
@RequestedTeeTime NVARCHAR(25) NULL,
@MemberNumber INT = NULL,
@MemberName NVARCHAR(50) = NULL,
@MemberNumber2 INT = NULL,
@MemberName2 NVARCHAR (50) = NULL,
@MemberNumber3 INT = NULL,
@MemberName3 NVARCHAR (50) = NULL,
@MemberNumber4 INT = NULL,
@MemberName4 NVARCHAR (50) = NULL,
@ApprovedTeeTime DATETIME = NULL,
@ApprovedBy NVARCHAR (50) = NULL,
@ApprovedDate DATE = NULL,
@PriorityNumber INT OUTPUT

AS
	DECLARE @ReturnStatus INT = 0

	--IF @RequestedDayOfWeek IS NULL
	--BEGIN
	--	SET @ReturnStatus = 1
	--	RAISERROR('uspAddStandingTeeTime - Parameter @RequestedDayOfWeek required', 16,1)
	--END
	
	IF @RequestedStartDate IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddStandingTeeTime - Parameter @RequestedStartDate required', 16,1)
	END
	
	IF @RequestedEndDate IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddStandingTeeTime - Parameter @RequestedEndDate required', 16,1)
	END
	
	IF @RequestedTeeTime IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddStandingTeeTimeRequest - Parameter @RequestedTeeTime required', 16,1)
	END
	IF @MemberNumber IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddStandingTeeTimeRequest - Parameter @MemberNumber required', 16,1)
	END

	IF @MemberName IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddStandingTeeTimeRequest - Parameter @MemberName required', 16,1)
	END

	IF @MemberNumber2 IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddStandingTeeTimeRequest - Parameter @MemberNumber2 required', 16,1)
	END

	IF @MemberName2 IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddStandingTeeTimeRequest - Parameter @MemberName2 required', 16,1)
	END

	IF @MemberNumber3 IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddStandingTeeTimeRequest - Parameter @MemberNumber3 required', 16,1)
	END

	IF @MemberName3 IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddStandingTeeTimeRequest - Parameter @MemberName3 required', 16,1)
	END

	IF @MemberNumber4 IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddStandingTeeTimeRequest - Parameter @MemberNumber4 required', 16,1)
	END

	IF @MemberName4 IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddStandingTeeTimeRequest - Parameter @MemberName4 required', 16,1)
	END

	IF @ReturnStatus = 0
	BEGIN
		INSERT INTO StandingTeeTimeRequest (MembershipLevel, RequestedStartDate, RequestedEndDate, RequestedTeeTime
		, MemberNumber, MemberName, MemberNumber2, MemberName2, MemberNumber3, MemberName3
		,MemberNumber4, MemberName4)
		VALUES(N'Gold',  @RequestedStartDate, @RequestedEndDate, @RequestedTeeTime, @MemberNumber
		, @MemberName, @MemberNumber2, @MemberName2, @MemberNumber3, @MemberName3, @MemberNumber4, @MemberName4)
		SELECT @PriorityNumber = SCOPE_IDENTITY()	

IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspAddStandingTeeTimeRequest - Error inserting into Daily Tee Sheet.',16,1)
		END
	END

	RETURN @ReturnStatus
GO

DECLARE @RC INT
DECLARE @PriorityNumber INT
EXEC @RC = uspAddStandingTeeTime @MembershipLevel= N'Gold', @RequestedStartDate = N'2022-05-21', @RequestedEndDate = N'2022-05-21'
, @RequestedTeeTime = N'8:30 am' , @MemberNumber = '1', @MemberName = N'John', @MemberNumber2 = '2', @MemberName2 = N'Jane', @MemberNumber3 = '3'
, @MemberName3 = N'Mike', @MemberNumber4 = '4', @MemberName4 = N'Mickey', @PriorityNumber = @PriorityNumber OUTPUT
PRINT @RC
PRINT @PriorityNumber
SELECT * FROM StandingTeeTimeRequest


--Modify Standing Tee Time Request. Priority Number, Member Number, Member First and Last Name cannot be updated
DROP PROC IF EXISTS uspUpdateStandingTeeTime
GO
CREATE PROC uspUpdateStandingTeeTime
@PriorityNumber INT = NULL,
@ApprovedTeeTime NVARCHAR(25) = NULL,
@ApprovedBy NVARCHAR (50) = NULL,
@ApprovedDate NVARCHAR(25) = NULL


AS
	DECLARE @ReturnStatus INT = 0

IF @ApprovedTeeTime IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspUpdateStandingTeeTime - Parameter @ApprovedTeeTime is required', 16,1)
END

IF @ApprovedBy IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspUpdateStandingTeeTime - Parameter @ApprovedBy is required', 16,1)
END

IF @ApprovedDate IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspUpdateStandingTeeTime - Parameter @ApprovedDate is required', 16,1)
END

IF @ReturnStatus = 0
	BEGIN
	UPDATE StandingTeeTimeRequest
		SET ApprovedTeeTime = @ApprovedTeeTime, ApprovedBy = @ApprovedBy, ApprovedDate = @ApprovedDate
		WHERE PriorityNumber = @PriorityNumber

IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspUpdateStandingTeeTimeRequest - Error updating Standing Tee Time Request',16,1)
		END
	END

	RETURN @ReturnStatus
GO
DECLARE @RC INT
EXEC @RC = uspUpdateStandingTeeTime @PriorityNumber = '400001', @ApprovedTeeTime = N'Yes', @ApprovedBy = N'Committee Member', @ApprovedDate = N'2022-03-28'
PRINT @RC

SELECT * FROM StandingTeeTimeRequest

--Procedure to Find a Standing Tee Time
DROP PROC IF EXISTS uspFindStandingTeeTime
GO
CREATE PROC uspFindStandingTeeTime
(
@PriorityNumber INT = NULL,
@RequestedStartDate NVARCHAR (25) = NULL,
@RequestedTeeTime NVARCHAR (25) = NULL
)
AS
DECLARE @ReturnStatus INT = 0
IF @RequestedStartDate IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspFindStandingTeeTime - Parameter required for @RequestedStartDate' ,16,1)
	END
	IF @RequestedTeeTime IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspFindStandingTeeTime - Parameter required for @RequestedTeeTime' ,16,1)
	END


IF @ReturnStatus = 0
	BEGIN
SELECT PriorityNumber, MembershipLevel, Role, RequestedDayOfWeek, RequestedStartDate, RequestedEndDate
, RequestedTeeTime, MemberNumber, MemberName, MemberNumber2, MemberName2,
MemberNumber3, MemberName3, MemberNumber4, MemberName4, ApprovedTeeTime, ApprovedBy, ApprovedDate
FROM StandingTeeTimeRequest
WHERE RequestedStartDate = @RequestedStartDate AND RequestedTeeTime = @RequestedTeeTime

	IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspFindStandingTeeTime - Error retreiving Standing Tee Time Information',16,1)
		END
	END

	RETURN @ReturnStatus
GO
DECLARE @RC INT
EXEC @RC = uspFindStandingTeeTime @RequestedStartDate=N'2022-04-12', @RequestedTeeTime=N'11:29'
PRINT @RC
SELECT * FROM StandingTeeTimeRequest

--Delete
DROP PROC IF EXISTS uspDeleteStandingTeeTime
GO
CREATE PROC uspDeleteStandingTeeTime

@RequestedStartDate NVARCHAR(50) = NULL,
@RequestedTeeTime NVARCHAR(50) = NULL
AS
	DECLARE @ReturnStatus INT = 0

IF @RequestedStartDate IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspDeleteStandingTeeTime - Parameter required for @RequestedStartDate' ,16,1)
	END
	IF @RequestedTeeTime IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspDeleteStandingTeeTime - Parameter required for @RequestedTeeTime' ,16,1)
	END
	
	IF @ReturnStatus = 0
	BEGIN
		DELETE StandingTeeTimeRequest
			WHERE RequestedStartDate = @RequestedStartDate AND RequestedTeeTime = @RequestedTeeTime

		IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspDeleteStandingTeeTime - Error Deleting Tee Time.',16,1)
		END
	END
	RETURN @ReturnStatus
GO
DECLARE @RC INT
EXEC @RC = uspDeleteStandingTeeTime @RequestedStartDate=N'2022-04-18', @RequestedTeeTime=N'22:59'
PRINT @RC




SELECT * FROM StandingTeeTimeRequest

--Find a Member Store Procedure
DROP PROC IF EXISTS uspFindMember
GO
CREATE PROC uspFindMember
(
@Email NVARCHAR (100) = NULL
)
AS

DECLARE @ReturnStatus INT = 0

IF @Email IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR('FindPlayer-Parameter required for @Email', 16,1)
	END

	IF @ReturnStatus = 0
	BEGIN
		SELECT MemberNumber, MembershipLevel, LastName, FirstName,  HomeAddress, HomePostalCode, HomePhone, AlternatePhone
	, Email, DateOfBirth, Occupation, CompanyName, CompanyAddress, CompanyPostalCode, CompanyPhone
	, DateCharged, PaymentDescription, AmountPaid, BalanceDue, BalanceOwing
		FROM Member
		WHERE Email = @Email

	IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('FindPlayer - Error retreiving Member Information',16,1)
		END
	END

	RETURN @ReturnStatus
GO

EXEC uspFindMember @Email = N'kev.smith@yahoo.com'

SELECT * FROM Member




--ViewMemberAccount. Actor Member and Finance Committee. Both can view a members account. 
DROP PROC IF EXISTS uspViewMemberAccount
GO
CREATE PROC uspViewMemberAccount
(
	@MemberNumber INT = NULL
)
	AS
		DECLARE @ReturnStatus INT = 0

IF @MemberNumber IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspViewMemberAccount - Parameter Member Number is required', 16,1)
	END
IF @ReturnStatus = 0
	BEGIN
	SELECT * FROM Member
	WHERE MemberNumber = @MemberNumber
IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspViewMemberAccount - Error Viewing Members account',16,1)
		END
	END

	RETURN @ReturnStatus
GO
--Procedure for Getting the MembershipLevel
DROP PROC IF EXISTS uspGetMembershipLevel
GO
CREATE PROC uspGetMembershipLevel
(
@MembershipLevel NVARCHAR(25) = NULL

)
AS
DECLARE @ReturnStatus INT = 0

	IF @MembershipLevel IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspGetMembershipLevel - Parameter required for @MemberNumber' ,16,1)
	END

IF NOT EXISTS (SELECT MembershipLevel FROM Member WHERE MembershipLevel = @MembershipLevel)
	BEGIN
	SET @ReturnStatus = 1
RAISERROR('uspGetMembershipLevel- MembershipLevel does not exist. Need more Members to join.', 16,1)
	END

	IF @ReturnStatus = 0
	BEGIN
		SELECT MemberNumber, LastName, FirstName, Email, MembershipLevel, HomePhone
		FROM Member
			WHERE MembershipLevel = @MembershipLevel

		IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspGetMembershipLevel - Error Getting Membership Level.',16,1)
		END
	END
	RETURN @ReturnStatus
GO


--Procedure for Getting Member Applications. 	
DROP PROC IF EXISTS uspGetMembershipApplications
GO
CREATE PROC uspGetMembershipApplications
(
@ApplicationStatus NVARCHAR (15) = NULL

)
AS
DECLARE @ReturnStatus INT = 0

IF @ApplicationStatus IS NULL
BEGIN
	
	SET @ReturnStatus = 1
		RAISERROR('uspGetMembershipApplications - Parameter required for @ApplicationStatus' ,16,1)
	END

IF NOT EXISTS (SELECT ApplicationStatus FROM MembershipApplication WHERE ApplicationStatus = @ApplicationStatus)
	BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspGetMembershipApplications- MembershipApplication does not exist. Need more Members to join.', 16,1)
	END

	IF @ReturnStatus = 0
	BEGIN
SELECT * FROM MembershipApplication
WHERE ApplicationStatus = @ApplicationStatus

IF @@ERROR = 0 
		SET @ReturnStatus = 0 
		ELSE RAISERROR('uspGetMembershipApplications Failed - Select Error in Database',16,1) 
	END 
	RETURN @ReturnStatus 
GO
--Procedure for Getting Member Application. 
DROP PROC IF EXISTS uspGetMembershipApplication
GO
CREATE PROC uspGetMembershipApplication
(
@ApplicationStatus NVARCHAR (15) = NULL
)
AS
DECLARE @ReturnStatus INT = 0

IF @ApplicationStatus IS NULL

BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspGetMembershipApplication- Parameter required for @@ApplicationStatu' ,16,1)
	END

IF NOT EXISTS (SELECT ApplicationStatus FROM MembershipApplication WHERE ApplicationStatus = ApplicationStatus)
	BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspGetMembershipApplication- MembershipApplication does not exist. Need more Members to join.', 16,1)
	END

	IF @ReturnStatus = 0
	BEGIN
SELECT ApplicationID, LastName, FirstName, HomeAddress, HomePostalCode, HomePhone, AlternatePhone, Email
, DateOfBirth, Occupation, CompanyName, CompanyAddress, CompanyAddress, CompanyPostalCode, CompanyPhone
,  ShareholderName1, ShareholderName2, ApprovedBy, ApplicationStatus
FROM MembershipApplication
WHERE ApplicationStatus = @ApplicationStatus

	IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspGetMembershipApplication - Error retreiving Member Application Information',16,1)
		END
	END

	RETURN @ReturnStatus
GO

--Procedure for Update Membership Application
DROP PROC IF EXISTS uspUpdateApplication
GO
CREATE PROC uspUpdateApplication
(
@ApplicationID INT = NULL,
@ApplicationStatus NVARCHAR(25) = NULL,
@ApprovedBy NVARCHAR(50) = NULL

)
AS

DECLARE @ReturnStatus INT = 0

IF @ApplicationStatus IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspUpdateApplication - Parameter required for @ApplicationStatus' ,16,1)
END
IF @ApprovedBy IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspUpdateApplication - Parameter required for @ApprovedBy' ,16,1)
END


IF @ReturnStatus = 0
	BEGIN
	UPDATE MembershipApplication
	SET ApplicationStatus = @ApplicationStatus
	WHERE ApplicationID = @ApplicationID

	IF @@ERROR <>0
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspRejectMembershipApplication - Error updating Membership Application.', 16,1)
		END
	END

	RETURN @ReturnStatus
GO


--Procedure to Add Member Payment
DROP PROC IF EXISTS uspAddMemberPayment
GO
CREATE PROC uspAddMemberPayment
(
@PriorityNumber INT = NULL,
@Date NVARCHAR(25) = NULL,
@LastName NVARCHAR(50) = NULL,
@FirstName NVARCHAR(50) = NULL,
@CreditCardNumber INT = NULL,
@ExpiryDate NVARCHAR(10) = NULL,
@Currency NVARCHAR(10) = NULL,
@PaymentDescription NVARCHAR(50) = NULL,
@AmountPaid DECIMAL(10,2)= NULL,
@BalanceDue DECIMAL(10,2) = NULL,
@BalanceOwing DECIMAL(10,2) = NULL,
@PaymentID INT OUTPUT

)
AS

DECLARE @ReturnStatus INT = 0

IF @Date IS NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspAddMemberPayment - Parameter required for @Date' ,16,1)
	END

IF @LastName IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspAddMemberPayment = Parameter @LastName is required', 16,1)
END
IF @FirstName IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspAddMemberPayment = Parameter @FristName is required', 16,1)
END
IF @CreditCardNumber IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspAddMemberPayment = Parameter @CreditCardNumber is required', 16,1)
END
IF @ExpiryDate IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspAddMemberPayment = Parameter @ExpiryDate is required', 16,1)
END
IF @Currency IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspAddMemberPayment = Parameter @Currency is required', 16,1)
END
IF @PaymentDescription IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspAddMemberPayment = Parameter @PaymentDescription is required', 16,1)
END
IF @AmountPaid IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspAddMemberPayment = Parameter @AmountPaid is required', 16,1)
END
IF @BalanceDue IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspAddMemberPayment = Parameter @Balance is required', 16,1)
END
IF @BalanceOwing IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR('uspAddMemberPayment = Parameter @Balance is required', 16,1)
END

IF @ReturnStatus = 0
BEGIN
INSERT INTO MemberPaymentTransaction(Date, LastName, FirstName, CreditCardNumber, ExpiryDate, Currency, PaymentDescription, AmountPaid, BalanceDue, BalanceOwing)
VALUES (@Date, @LastName, @FirstName, @CreditCardNumber, @ExpiryDate, @Currency, @PaymentDescription, @AmountPaid, @BalanceDue, @BalanceOwing)
SELECT @PaymentID = SCOPE_IDENTITY()

	IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspAddMemberPayment - Error retreiving Member Payment Information',16,1)
		END
	END
	RETURN @ReturnStatus
GO


DROP PROC IF EXISTS uspCalculateHoleByHoleScore
GO
CREATE PROC uspCalculateHoleByHoleScore
(
@GolfCourse NVARCHAR (50) NULL, 
@Date NVARCHAR(50) NULL,
@Email NVARCHAR(100) NULL,
@Hole1 INT = NULL,
@Hole2 INT = NULL,
@Hole3 INT = NULL,
@Hole4 INT = NULL,
@Hole5 INT = NULL,
@Hole6 INT = NULL,
@Hole7 INT = NULL,
@Hole8 INT = NULL,
@Hole9 INT = NULL,
@Hole10 INT = NULL,
@Hole11 INT = NULL,
@Hole12 INT = NULL,
@Hole13 INT = NULL,
@Hole14 INT = NULL,
@Hole15 INT = NULL,
@Hole16 INT = NULL,
@Hole17 INT = NULL,
@Hole18 INT = NULL,
--calculation in C# code
@AdjustedGrossScore INT = NULL,
@CourseRating DECIMAL(3,1)  = NULL,
@SlopeRating DECIMAL(5,1)  = NULL,
@PCCAdjustment DECIMAL(3,1) = NULL,
--calculation in C# code
@ScoreDifferential DECIMAL(5,1) = NULL,
@ScoreID INT OUTPUT

)
AS 
DECLARE @ReturnStatus INT = 0

IF @GolfCourse IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @GolfCourse Required', 16,1)
END
IF @Date IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Date Required', 16,1)
END
IF @Hole1 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole1 Required', 16,1)
END
IF @Hole2 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole2 Required', 16,1)
END
IF @Hole3 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole3 Required', 16,1)
END
IF @Hole4 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole4 Required', 16,1)
END
IF @Hole5 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole5 Required', 16,1)
END
IF @Hole6 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole6 Required', 16,1)
END
IF @Hole7 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole7 Required', 16,1)
END
IF @Hole8 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole8 Required', 16,1)
END
IF @Hole9 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole9 Required', 16,1)
END
IF @Hole10 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole10 Required', 16,1)
END
IF @Hole11 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole11 Required', 16,1)
END
IF @Hole12 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole12 Required', 16,1)
END
IF @Hole13 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole13 Required', 16,1)
END
IF @Hole14 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole14 Required', 16,1)
END
IF @Hole15 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole15 Required', 16,1)
END
IF @Hole16 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole16 Required', 16,1)
END
IF @Hole17 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole17 Required', 16,1)
END
IF @Hole18 IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @Hole18 Required', 16,1)
END
IF @CourseRating IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @CourseRating Required', 16,1)
END
IF @PCCAdjustment IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @PCCAdjustment Required', 16,1)
END
IF @SlopeRating IS NULL
BEGIN
	SET @ReturnStatus = 1
	RAISERROR ('uspCalculateHoleByHoleScore = Parameter @SlopeRating Required', 16,1)
END

IF @ReturnStatus = 0
	BEGIN
	
	INSERT INTO PlayerScoreCard (GolfCourse, Date, Email, Hole1, Hole2, Hole3, Hole4, Hole5, Hole6, Hole7, Hole8, Hole9
	, Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18, AdjustedGrossScore
	, CourseRating, SlopeRating, PCCAdjustment, ScoreDifferential)

	VALUES (@GolfCourse, @Date, @Email, @Hole1, @Hole2, @Hole3, @Hole4, @Hole5, @Hole6, @Hole7, @Hole8, @Hole9, @Hole10
	, @Hole11, @Hole12, @Hole13, @Hole14, @Hole15, @Hole16, @Hole17, @Hole18, @AdjustedGrossScore,
	@CourseRating, @SlopeRating,  @PCCAdjustment, @ScoreDifferential)
	SELECT @ScoreID = SCOPE_IDENTITY()

	IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspCalculateHoleByHoleScore - Error calculating Hole By Hole Score',16,1)
		END
	END
	RETURN @ReturnStatus
GO
--Works. But AdjustedGrossScore cannot be an OUTPUT. 



SELECT * FROM PlayerScoreCard

DROP PROC IF EXISTS uspViewPlayerHandicap
GO
CREATE PROC uspViewPlayerHandicap
(
@MemberNumber INT = NULL
)
AS
DECLARE @ReturnStatus INT = 0

IF @MemberNumber is NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspViewPlayerHandicap- Parameter required for @MemberNumber' ,16,1)
		END

		IF @ReturnStatus = 0
		BEGIN
			SELECT MemberNumber, Date, AdjustedGrossScore, CourseRating, SlopeRating,PCCAdjustment,ScoreDifferential 
			FROM PlayerHandicapIndex
			WHERE MemberNumber = @MemberNumber
			
		IF @@ERROR <> 0 
		BEGIN
			SET @ReturnStatus = 1
			RAISERROR('uspViewPlayerHandicap - Error retreiving Player Handicap Information',16,1)
		END
	END

	RETURN @ReturnStatus
GO


DROP PROC IF EXISTS uspGetTop20Rounds
GO
CREATE PROC uspGetTop20Rounds
(

@Email NVARCHAR(100) = NULL
)
AS
DECLARE @ReturnStatus INT = 0
DECLARE @MemberNumber INT
IF @Email is NULL
	BEGIN
		SET @ReturnStatus = 1
		RAISERROR('uspCalculateTop20- Parameter required for @Email' ,16,1)
	END
	IF @ReturnStatus = 0
		BEGIN
	SELECT @MemberNumber = MemberNumber FROM PlayerScoreCard WHERE Email = @Email

	SELECT TOP 20 ScoreID, [Date] AS Date, CourseRating, PCCAdjustment, SlopeRating, Hole1, Hole2, Hole3, Hole4, Hole5
	, Hole6, Hole7, Hole8, Hole9, Hole10, Hole11, Hole12, Hole13, Hole14, Hole15, Hole16, Hole17, Hole18
	FROM PlayerScoreCard
	WHERE MemberNumber = @MemberNumber
	--GROUP BY ScoreID, CourseRating, SlopeRating
	ORDER BY [Date] DESC
END
RETURN @ReturnStatus
GO

DECLARE @RC INT
EXEC @RC =  uspGetTop20Rounds @Email = N'ramjis99@email.com'
PRINT @RC


SELECT * FROM PlayerScoreCard


--DECLARE @AdjustedGrossScore INT
--SELECT @AdjustedGrossScore = AdjustedGrossScore FROM PlayerScoreCard
--PRINT @AdjustedGrossScore

--SELECT AdjustedGrossScore FROM PlayerScoreCard
--WHERE SCOREID = 60004


--DECLARE @ScoreDifferential DECIMAL (3,1)
--DECLARE @SlopeRating INT
--DECLARE @CourseRating DECIMAL (3,1)

--SELECT @AdjustedGrossScore = AdjustedGrossScore FROM PlayerScoreCard
--SET @ScoreDifferential = (113/@SlopeRating) * ((@AdjustedGrossScore)-@CourseRating)

--PRINT @ScoreDifferential

--PRINT ((113/131.0) * ((-34)-70))

--DECLARE @AmountPaid DECIMAL (10,2)
--DECLARE @BalanceDue DECIMAL (10,2)
--DECLARE @BalanceOwing DECIMAL (10,2)

--SET @BalanceDue = @AmountPaid - @BalanceOwing

--PRINT ((500)-(500))
--PRINT @BalanceOwing

