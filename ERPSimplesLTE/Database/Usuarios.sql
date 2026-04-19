CREATE TABLE Usuarios (
  Id int NOT NULL AUTO_INCREMENT,
  Nome varchar(80) DEFAULT NULL,
  Email varchar(120) DEFAULT NULL,
  Senha varchar(20) DEFAULT NULL,
  PRIMARY KEY (Id)
);
