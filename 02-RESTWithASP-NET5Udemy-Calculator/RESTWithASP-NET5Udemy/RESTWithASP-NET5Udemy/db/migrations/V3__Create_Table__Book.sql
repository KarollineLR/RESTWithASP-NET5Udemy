
CREATE TABLE IF NOT EXISTS `book` (
  `id` bigint(20) NOT NULL AUTO_INCREMENT,
  `nome` varchar(80) NOT NULL,
  `categoria` varchar(80) NOT NULL,
  `autor` varchar(80) NOT NULL,
   `preco` bigint(6) NOT NULL,
  PRIMARY KEY (`id`)
)