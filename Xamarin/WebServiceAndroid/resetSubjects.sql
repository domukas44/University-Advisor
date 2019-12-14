DROP TABLE IF EXISTS subjects;

CREATE TABLE subjects 
(id INT IDENTITY(1,1) PRIMARY KEY,
name VARCHAR(80) NOT NULL,
rating DECIMAL(4,2) NOT NULL DEFAULT 0,
reviewcount INT NOT NULL DEFAULT 0);

INSERT INTO subjects (name) VALUES ('Buhalterinė apskaita');
INSERT INTO subjects (name) VALUES ('Informatikos teisė');
INSERT INTO subjects (name) VALUES ('Vadybos pagrindai');
INSERT INTO subjects (name) VALUES ('Elektronikos fizikiniai pagrindai');
INSERT INTO subjects (name) VALUES ('Fizika informatikams');
INSERT INTO subjects (name) VALUES ('Bioinformatika');
INSERT INTO subjects (name) VALUES ('Blokų grandinių technologijos');
INSERT INTO subjects (name) VALUES ('Dirbtinis intelektas');
INSERT INTO subjects (name) VALUES ('Elektroninės komercijos technologijų pagrindai');
INSERT INTO subjects (name) VALUES ('Finansinis intelektas');
INSERT INTO subjects (name) VALUES ('Funkcinis programavimas');
INSERT INTO subjects (name) VALUES ('Informacinių technologijų veiklos valdymas organizacijoje');
INSERT INTO subjects (name) VALUES ('Įvadas į verslo procesų vadybą');
INSERT INTO subjects (name) VALUES ('Judrusis programavimas Ruby');
INSERT INTO subjects (name) VALUES ('Kompiuterinė grafika');
INSERT INTO subjects (name) VALUES ('Kompiuterinių žaidimų projektavimas ir kūrimas');
INSERT INTO subjects (name) VALUES ('Kompiuterių tinklai II');
INSERT INTO subjects (name) VALUES ('Kompiuterių tinklai profesionalams II');
INSERT INTO subjects (name) VALUES ('Lygiagretusis programavimas');
INSERT INTO subjects (name) VALUES ('Loginis programavimas');
INSERT INTO subjects (name) VALUES ('Oracle PL/SQL programavimas');
INSERT INTO subjects (name) VALUES ('Programavimas Windows API');
INSERT INTO subjects (name) VALUES ('Taikomųjų programų kūrimas mobiliesiems įrenginiams ir autonominėms sistemoms');
INSERT INTO subjects (name) VALUES ('Transliavimo metodai');
INSERT INTO subjects (name) VALUES ('Žinių vaizdavimas');
INSERT INTO subjects (name) VALUES ('Diferencialinės lygtys');
INSERT INTO subjects (name) VALUES ('Kodavimo teorija');
INSERT INTO subjects (name) VALUES ('Kombinatorika ir grafų teorija');
INSERT INTO subjects (name) VALUES ('Matematinė analizė');
INSERT INTO subjects (name) VALUES ('Optimizavimo metodai');
INSERT INTO subjects (name) VALUES ('Skaitiniai metodai');
INSERT INTO subjects (name) VALUES ('Statistinė duomenų analizė');
INSERT INTO subjects (name) VALUES ('Duomenų bazių valdymo sistemų papildomi skyriai');
INSERT INTO subjects (name) VALUES ('Geografinės informacinės sistemos');
INSERT INTO subjects (name) VALUES ('Giliojo mokymosi metodai');
INSERT INTO subjects (name) VALUES ('Kompiuterinė technika');
INSERT INTO subjects (name) VALUES ('Kompiuterių tinklai profesionalams I');
INSERT INTO subjects (name) VALUES ('Operacinės sistemos');
INSERT INTO subjects (name) VALUES ('Programavimas PYTHON kalba');
INSERT INTO subjects (name) VALUES ('Skaitmeninis intelektas ir sprendimų priėmimas');
INSERT INTO subjects (name) VALUES ('Informacinės sistemos');
INSERT INTO subjects (name) VALUES ('Matematinis modeliavimas');
INSERT INTO subjects (name) VALUES ('Chaoso teorija ir fraktalai');
INSERT INTO subjects (name) VALUES ('Grafų teorija');
INSERT INTO subjects (name) VALUES ('Informacijos teorija');
INSERT INTO subjects (name) VALUES ('Programavimas OS UNIX');
INSERT INTO subjects (name) VALUES ('UML ir MDA įvadas');