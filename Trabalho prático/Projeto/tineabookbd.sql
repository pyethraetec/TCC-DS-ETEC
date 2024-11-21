# Host: localhost  (Version 5.5.5-10.4.22-MariaDB)
# Date: 2024-10-22 22:32:23
# Generator: MySQL-Front 6.0  (Build 2.20)


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

DROP TABLE IF EXISTS `postagem-progresso`;

CREATE TABLE `postagem-progresso` (
  `Id_hist` int(11) NOT NULL AUTO_INCREMENT,
  `porc_lido_hist` varchar(255) DEFAULT NULL,
  `data_hist` date DEFAULT NULL,
  `id_livro` int(11) DEFAULT NULL,
  `id_usuario` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id_hist`),
)


CREATE TABLE `usuarios` (
  `Id_usuario` int(11) NOT NULL AUTO_INCREMENT,
  `nome` varchar(255) DEFAULT NULL,
  `apelido` varchar(255) DEFAULT NULL,
  `data_nasc` date DEFAULT NULL,
  `email` varchar(255) DEFAULT NULL,
  `senha` varchar(255) DEFAULT NULL,
  `bio` varchar(255) DEFAULT NULL,
  PRIMARY KEY (`Id_usuario`)
)


INSERT INTO `usuarios` VALUES (1,'Vitor Gabriel','hajzok','2005-10-21','vitor@gmail.com','123','ALO');
