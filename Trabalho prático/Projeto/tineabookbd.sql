# Host: localhost  (Version 5.5.5-10.4.22-MariaDB)
# Date: 2024-10-22 22:32:23
# Generator: MySQL-Front 6.0  (Build 2.20)


#
# Structure for table "avaliacao"
#

DROP TABLE IF EXISTS `avaliacao`;
CREATE TABLE `avaliacao` (
  `id_hist` int(11) NOT NULL AUTO_INCREMENT,
  `id_livro` int(11) NOT NULL,
  `id_usuario` int(11) NOT NULL,
  `data` date DEFAULT NULL,
  `status` varchar(255) DEFAULT NULL,
  `estrelas` int(11) DEFAULT NULL,
  `resenha` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_hist`),
  KEY `id_usuario` (`id_usuario`),
  KEY `id_livro` (`id_livro`)
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
  `titulo` varchar(255) DEFAULT NULL,
  `autor` varchar(255) DEFAULT NULL,
  `edicao` varchar(255) DEFAULT NULL,
  `total_pagina` int(11) DEFAULT NULL,
  `tipo_livro` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`id_livro`)
) ENGINE=InnoDB AUTO_INCREMENT=7 DEFAULT CHARSET=utf8mb4;

#
# Data for table "livros"
#

INSERT INTO `livros` VALUES (1,'Orgulho e Preconceito','Jane Austen','26',424,'Fisico'),(2,'Guia do Mochileiro das Galáxias\'','Douglas Adams','2',208,'Fisico'),(3,'Hobbit','Tolkien','1',336,'Fisico'),(4,'Alice no País das Maravilhas','Lewis Carroll','Classic Edition',224,'Fisico'),(5,'Pequeno Principe','Antoine de Saint-Exupéry','Padrão',96,'Fisico'),(6,'Percy Jackson: O Ladrão de Raios','Rick Riordan','2',400,'Fisico');

#
# Structure for table "postagem-progresso"
#

DROP TABLE IF EXISTS `postagem-progresso`;
CREATE TABLE `postagem-progresso` (
  `Id_hist` int(11) NOT NULL AUTO_INCREMENT,
  `porc_lido_hist` varchar(255) COLLATE latin1_general_ci DEFAULT NULL,
  `data_hist` date DEFAULT NULL,
  `id_livro` int(11) DEFAULT NULL,
  `id_usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id_hist`),
  KEY `id_livro` (`id_livro`),
  KEY `id_usuario` (`id_usuario`),
  CONSTRAINT `postagem-progresso_ibfk_1` FOREIGN KEY (`id_livro`) REFERENCES `livros` (`id_livro`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

#
# Data for table "postagem-progresso"
#


#
# Structure for table "usuarios"
#

DROP TABLE IF EXISTS `usuarios`;
CREATE TABLE `usuarios` (
  `Id_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) COLLATE latin1_general_ci DEFAULT NULL,
  `apelido` varchar(255) COLLATE latin1_general_ci DEFAULT NULL,
  `data_nasc` date DEFAULT NULL,
  `email` varchar(255) COLLATE latin1_general_ci DEFAULT NULL,
  `senha` varchar(255) COLLATE latin1_general_ci DEFAULT NULL,
  `bio` varchar(255) COLLATE latin1_general_ci DEFAULT NULL,
  PRIMARY KEY (`Id_usuario`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_general_ci;

#
# Data for table "usuarios"
#

INSERT INTO `usuarios` VALUES (1,'Vitor Gabriel','hajzok','2005-10-21','vitor@gmail.com','123','ALO');
