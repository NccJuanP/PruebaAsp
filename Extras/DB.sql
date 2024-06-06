-- Active: 1717615704462@@bgq3hluli4z92czniw3k-mysql.services.clever-cloud.com@3306

SELECT * FROM `Teachers`;

CREATE TABLE Students(
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(125) NOT NULL,
    BirthDate DATE NOT NULL,
    Address VARCHAR(125) NOT NULL,
    Email VARCHAR(125) NOT NULL
);

/*CREAR DATOS PARA Students*/

INSERT INTO Students(Names, BirthDate, Address, Email) VALUES ('Juan', '1990-01-01', 'Calle 123', 'juan@gmail.com');
INSERT INTO Students(Names, BirthDate, Address, Email) VALUES ('Pedro', '1990-01-01', 'calle 321', 'pedro@gmail.com');
INSERT INTO Students(Names, BirthDate, Address, Email) VALUES ('Maria', '1990-01-01', 'calle 213', 'mar@gmail.com');

CREATE TABLE Teachers(
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Names VARCHAR(125) NOT NULL,
    Speciality VARCHAR(125)  NOT NULL,
    Phone VARCHAR(25) NOT NULL,
    Email VARCHAR(125) NOT NULL,
    YearsExperience INTEGER NOT NULL
);

/*CREAR DATOS PARA Teachers*/

INSERT INTO Teachers(Names, Speciality, Phone, Email, YearsExperience) VALUES ('Juan Profesor', 'Matematicas', '123456789', 'juan@gmail.com', 10);
INSERT INTO Teachers(Names, Speciality, Phone, Email, YearsExperience) VALUES ('pedro Profesor', 'Español', '123456789', 'pedro@gmail.com', 4);
INSERT INTO Teachers(Names, Speciality, Phone, Email, YearsExperience) VALUES ('Maria Profesora', ' Ingles', '123456789', 'Maria@gmail.com', 5);


CREATE TABLE Courses(
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Name VARCHAR(125) NOT NULL,
    Description TEXT NOT NULL,
    TeacherId INTEGER NOT NULL,
    Schedule VARCHAR(125) NOT NULL,
    Duration VARCHAR(125) NOT NULL,
    Capacity INTEGER NOT NULL,
    FOREIGN KEY (TeacherId) REFERENCES Teachers(Id)
);

/*CREAR DATOS PARA Courses*/

INSERT INTO Courses(Name, Description, TeacherId, Schedule, Duration, Capacity) VALUES ('Programacion', 'Curso de Programacion', 1, 'Lunes a Viernes', '4 horas', 5);

INSERT INTO Courses(Name, Description, TeacherId, Schedule, Duration, Capacity) VALUES ('Matematicas', 'Curso de Matematicas', 2, 'Lunes a Viernes', '3 horas', 10);
INSERT INTO Courses(Name, Description, TeacherId, Schedule, Duration, Capacity) VALUES ('Español', 'Curso de Español', 3, 'Lunes a Viernes', '1 horas', 15);
INSERT INTO Courses(Name, Description, TeacherId, Schedule, Duration, Capacity) VALUES ('Ingles', 'Curso de Ingles', 4, 'Lunes a Viernes', '2 horas', 20);




CREATE TABLE Enrollments(
    Id INTEGER PRIMARY KEY AUTO_INCREMENT,
    Date DATE NOT NULL,
    StudentId INTEGER NOT NULL,
    CourseId INTEGER NOT NULL,
    Status ENUM('PAGADA', 'PENDIENTE DE PAGO', 'CANCELADA') NOT NULL,
    FOREIGN KEY (StudentId) REFERENCES Students(Id),
    FOREIGN KEY (CourseId) REFERENCES Courses(Id)
);

/*CREAR DATOS PARA Enrollments*/


INSERT INTO Enrollments(Date, StudentId, CourseId, Status) VALUES ('2024-06-05', 1, 1, 'PAGADA');

INSERT INTO Enrollments(Date, StudentId, CourseId, Status) VALUES ('2024-06-05', 1, 2, 'CANCELADA');
INSERT INTO Enrollments(Date, StudentId, CourseId, Status) VALUES ('2024-06-05', 1, 4, 'PENDIENTE DE PAGO');
INSERT INTO Enrollments(Date, StudentId, CourseId, Status) VALUES ('2024-06-05', 2, 1, 'PAGADA');

