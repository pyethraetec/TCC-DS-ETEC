# Host: localhost  (Version 5.5.5-10.4.22-MariaDB)
# Date: 2024-08-27 19:42:10
# Generator: MySQL-Front 6.0  (Build 2.20)


#
# Structure for table "avaliacao"
#

DROP TABLE IF EXISTS `avaliacao`;
CREATE TABLE `avaliacao` (
  `id_livro` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `data` date DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  `estrelas` int(255) DEFAULT NULL,
  `resenha` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_livro`,`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

#
# Data for table "avaliacao"
#


#
# Structure for table "livros"
#

DROP TABLE IF EXISTS `livros`;
CREATE TABLE `livros` (
  `id_livro` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) DEFAULT NULL,
  `autor` varchar(255) DEFAULT NULL,
  `edicao` varchar(255) DEFAULT NULL,
  `total_pagina` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_livro`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

#
# Data for table "livros"
#


#
# Structure for table "usuarios"
#

DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE `usuarios` (
  `id_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) DEFAULT NULL,
  `apelido` varchar(255) DEFAULT NULL,
  `data_nasc` date DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `senha` varchar(255) DEFAULT NULL,
  `fk_Avaliacao_id_livro` int(11) DEFAULT NULL,
  `fk_Avaliacao_id_usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_usuario`),
  KEY `FK_Usuarios_2` (`fk_Avaliacao_id_livro`,`fk_Avaliacao_id_usuario`),
  CONSTRAINT `FK_Usuarios_2` FOREIGN KEY (`fk_Avaliacao_id_livro`, `fk_Avaliacao_id_usuario`) REFERENCES `avaliacao` (`id_livro`, `id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

#
# Data for table "usuarios"
#

INSERT INTO `usuarios` VALUES (1,'Vitor Gabriel','hajzok','2005-10-21','vitor@gmail.com','123',NULL,NULL),(2,'Samuel Francisco','samuka','2000-01-01','samuel@gmail.com','5050',NULL,NULL),(3,'Pyethra Ribeiro','pye','2001-09-01','pyethra@gmail.com','2020',NULL,NULL);

#
# Structure for table "lido"
#

DROP TABLE IF EXISTS `lido`;
CREATE TABLE `lido` (
  `fk_Livros_id_livro` int(11) DEFAULT NULL,
  `fk_Usuarios_id_usuario` int(11) DEFAULT NULL,
  KEY `FK_Lido_1` (`fk_Livros_id_livro`),
  KEY `FK_Lido_2` (`fk_Usuarios_id_usuario`),
  CONSTRAINT `FK_Lido_1` FOREIGN KEY (`fk_Livros_id_livro`) REFERENCES `livros` (`id_livro`),
  CONSTRAINT `FK_Lido_2` FOREIGN KEY (`fk_Usuarios_id_usuario`) REFERENCES `usuarios` (`id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

#
# Data for table "lido"
#

