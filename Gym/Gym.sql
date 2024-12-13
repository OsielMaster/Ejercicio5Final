CREATE DATABASE  IF NOT EXISTS `gym` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `gym`;
-- MySQL dump 10.13  Distrib 8.0.40, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: gym
-- ------------------------------------------------------
-- Server version	8.0.40

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `categorias`
--

DROP TABLE IF EXISTS `categorias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `categorias` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(30) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `categorias`
--

LOCK TABLES `categorias` WRITE;
/*!40000 ALTER TABLE `categorias` DISABLE KEYS */;
INSERT INTO `categorias` VALUES (1,'ROPA DEPORTIVA'),(2,'SUPLEMENTOS'),(3,'ACCESORIOS Y EQUIPO');
/*!40000 ALTER TABLE `categorias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `productos`
--

DROP TABLE IF EXISTS `productos`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `productos` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Nombre` varchar(100) DEFAULT NULL,
  `Descripcion` text,
  `Precio` decimal(6,2) NOT NULL,
  `Stock` int DEFAULT '0',
  `IdSubCategoria` int DEFAULT NULL,
  `IdTipo` int DEFAULT NULL,
  `IdCategoria` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdCategoria` (`IdCategoria`),
  KEY `IdSubCategoria` (`IdSubCategoria`),
  KEY `IdTipo` (`IdTipo`),
  CONSTRAINT `productos_ibfk_1` FOREIGN KEY (`IdCategoria`) REFERENCES `categorias` (`Id`),
  CONSTRAINT `productos_ibfk_2` FOREIGN KEY (`IdSubCategoria`) REFERENCES `subcategorias` (`Id`),
  CONSTRAINT `productos_ibfk_3` FOREIGN KEY (`IdTipo`) REFERENCES `tipoproducto` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `productos`
--

LOCK TABLES `productos` WRITE;
/*!40000 ALTER TABLE `productos` DISABLE KEYS */;
INSERT INTO `productos` VALUES (1,'Leggins Deportivos Hombre','Leggins para entrenamiento masculino',29.99,100,1,1,1),(2,'Leggins Deportivos Mujer','Leggins para entrenamiento femenino',34.99,80,2,1,1),(3,'Proteína Whey','Proteína en polvo para recuperación muscular',49.99,200,3,3,2),(4,'Creatina Monohidratada','Creatina para mejorar el rendimiento físico',19.99,150,4,4,2),(5,'Preentreno Explosivo','Suplemento para aumentar la energía durante el entrenamiento',25.99,120,5,5,2),(6,'Guantes de Entrenamiento','Guantes para levantamiento de pesas y entrenamiento',15.50,50,6,2,3),(7,'Mancuernas Ajustables','Mancuernas con peso ajustable para entrenamiento',99.99,30,7,6,3),(11,'Youngla Leggins','Es un nuevo producto apto para entrenar',500.00,20,1,NULL,1);
/*!40000 ALTER TABLE `productos` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `subcategorias`
--

DROP TABLE IF EXISTS `subcategorias`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `subcategorias` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `NombreSub` varchar(30) NOT NULL,
  `IdCategoria` int DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `IdCategoria` (`IdCategoria`),
  CONSTRAINT `subcategorias_ibfk_1` FOREIGN KEY (`IdCategoria`) REFERENCES `categorias` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `subcategorias`
--

LOCK TABLES `subcategorias` WRITE;
/*!40000 ALTER TABLE `subcategorias` DISABLE KEYS */;
INSERT INTO `subcategorias` VALUES (1,'Hombre',1),(2,'Mujer',1),(3,'Proteínas',2),(4,'Creatinas',2),(5,'Preentrenos',2),(6,'Accesorios',3),(7,'Equipo',3);
/*!40000 ALTER TABLE `subcategorias` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tipoproducto`
--

DROP TABLE IF EXISTS `tipoproducto`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `tipoproducto` (
  `Id` int NOT NULL AUTO_INCREMENT,
  `Tipo` varchar(30) NOT NULL,
  `Descripcion` text NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tipoproducto`
--

LOCK TABLES `tipoproducto` WRITE;
/*!40000 ALTER TABLE `tipoproducto` DISABLE KEYS */;
INSERT INTO `tipoproducto` VALUES (1,'Leggins','Pantalones deportivos para entrenamiento'),(2,'Guantes','Guantes para entrenamiento y deportes'),(3,'Proteína','Suplementos alimenticios en polvo'),(4,'Creatina','Suplemento para mejorar el rendimiento físico'),(5,'Preentreno','Suplemento para aumentar la energía durante el entrenamiento'),(6,'Accesorios','Accesorios deportivos como muñequeras, toallas, etc.'),(7,'Equipo','Equipos deportivos como pesas, mancuernas, kettlebells');
/*!40000 ALTER TABLE `tipoproducto` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2024-12-12 23:12:31
