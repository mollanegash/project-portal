-- ***********************************************
-- CREATING TABLES FOR COMPUTER SCIENCE PORTAL
-- ***********************************************

CREATE TABLE USERTABLE(
    U_ID INT UNIQUE NOT NULL IDENTITY (1,1), -- creates auto-numbered user IDs
    Fname varchar(100) NOT NULL,
    Lname varchar(100) not null,
    School varchar(200) not null,
    email varchar(200) not null,

    CONSTRAINT USERPK PRIMARY KEY (U_ID)
);



CREATE TABLE STUDENT(
    U_ID INT UNIQUE NOT NULL REFERENCES USERTABLE (U_ID),
    Major varchar(100) not null,
    Grad_Date date not null,

    CONSTRAINT  STUDENTPK PRIMARY KEY (U_ID)
);


CREATE TABLE FACULTY(
    U_ID INT UNIQUE NOT NULL REFERENCES USERTABLE (U_ID),
    Field_Exp varchar(200),

    CONSTRAINT FACULTYPK PRIMARY KEY (U_ID)
);



CREATE TABLE PROJECT2(
    P_ID INT UNIQUE NOT NULL IDENTITY (1,1), --Creates auto-numbered projects IDs
    P_Name varchar(100) NOT NULL,
    UploadDate DATE NOT NULL,
    Link varchar(200),
    Tag varchar(100) NOT NULL,
    Descrip varchar(600),
    UserID INT NOT NULL,

    CONSTRAINT PROJECTPK PRIMARY KEY (P_ID),
    CONSTRAINT PROJECTFK FOREIGN KEY (UserID) REFERENCES STUDENT(U_ID)
    --ON DELETE SET NULL
    --ON UPDATE CASCADE
);



CREATE TABLE RELATION_CONTAINS(
    P_ID INT UNIQUE NOT NULL REFERENCES PROJECT2 (P_ID),
    Likes_Count INT,

    CONSTRAINT CONTAINSPK PRIMARY KEY (P_ID)
);


CREATE TABLE COMMENT(
    ProjectID INT NOT NULL REFERENCES PROJECT2(P_ID),
    UserID INT NOT NULL REFERENCES USERTABLE(U_ID),
    CommentText varchar(1000),
    DateComment DATE,

    CONSTRAINT COMMENTPK PRIMARY KEY (ProjectID, UserID)

);

--DROP TABLE RELATION_CONTAINS
--DROP TABLE COMMENT
--DROP TABLE USERTABLE
--DROP TABLE PROJECT2
--DROP TABLE FACULTY
--DROP TABLE STUDENT

--- ***********************************
--- TUPLES CREATION
--- ***********************************

INSERT INTO USERTABLE VALUES  ('JUAN','SANCHEZ', 'UF', 'JP@UF.EDU')
INSERT INTO USERTABLE VALUES  ('JOHN','LENNON', 'NYU', 'JL@NYU.EDU')
INSERT INTO USERTABLE VALUES  ('SAM','SMITH', 'BU', 'SS@BU.EDU')

INSERT INTO STUDENT VALUES (1, 'Computer Science', '01-MAY-19')
INSERT INTO STUDENT VALUES (3, 'Statistics', '01-DEC-18')

INSERT INTO FACULTY VALUES (2, 'Computer Architecture')

INSERT INTO PROJECT2 VALUES ('New York City AirBnB Data Maps', '01-FEB-19', 'www.project1.com', '#MachineLearning #NP', 'my cool projet', 1 )
INSERT INTO PROJECT2 VALUES ('Boston Crime Rates Correlation', '01-FEB-19', 'www.project1.com', '#LinearRegression #R', 'my project about Boston', 3 )


INSERT INTO RELATION_CONTAINS VALUES (1, 0)
INSERT INTO RELATION_CONTAINS VALUES (2, 0)

INSERT INTO COMMENT VALUES (1, 2, 'Nice project. Lets work together', '01-MAR-19')
INSERT INTO COMMENT VALUES (2, 1, 'Interesting implementation', '01-JAN-19')


