-- phpMyAdmin SQL Dump
-- version 4.7.9
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: May 01, 2018 at 04:12 AM
-- Server version: 5.7.21
-- PHP Version: 5.6.35

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_priclinicmgt`
--

-- --------------------------------------------------------

--
-- Table structure for table `change_reg`
--

DROP TABLE IF EXISTS `change_reg`;
CREATE TABLE IF NOT EXISTS `change_reg` (
  `modifled_day` datetime NOT NULL,
  `id_function` int(11) NOT NULL,
  `name_function` varchar(32) COLLATE utf8_unicode_ci DEFAULT NULL,
  `value_old` int(11) NOT NULL,
  `date_apply` date NOT NULL,
  `value_new` int(11) NOT NULL,
  `user_change` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_function`),
  KEY `user_change` (`user_change`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `change_reg`
--

INSERT INTO `change_reg` (`modifled_day`, `id_function`, `name_function`, `value_old`, `date_apply`, `value_new`, `user_change`) VALUES
('2018-01-25 11:16:31', 1, 'sdfghzd', 20, '2018-01-27', 30, NULL),
('2018-01-25 11:16:31', 2, 'sadxcxb nguyễn ', 30, '2018-01-29', 50, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `medical_exam`
--

DROP TABLE IF EXISTS `medical_exam`;
CREATE TABLE IF NOT EXISTS `medical_exam` (
  `code` char(11) COLLATE utf8_unicode_ci NOT NULL,
  `patient_id` int(11) NOT NULL,
  `physician_id` int(11) DEFAULT NULL,
  `sick_id` int(11) DEFAULT NULL,
  `fee_exam` int(11) DEFAULT NULL,
  `fee_medicine` int(11) DEFAULT NULL,
  `prognostic` text COLLATE utf8_unicode_ci,
  `status` int(11) DEFAULT NULL,
  `date_exam` datetime NOT NULL,
  PRIMARY KEY (`code`),
  KEY `patient_id` (`patient_id`),
  KEY `physician_id` (`physician_id`),
  KEY `sick_id` (`sick_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `medicine`
--

DROP TABLE IF EXISTS `medicine`;
CREATE TABLE IF NOT EXISTS `medicine` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `another_name` varchar(64) COLLATE utf8_unicode_ci DEFAULT NULL,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `user_change` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`),
  KEY `user_change` (`user_change`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `medicine_history`
--

DROP TABLE IF EXISTS `medicine_history`;
CREATE TABLE IF NOT EXISTS `medicine_history` (
  `date` datetime NOT NULL,
  `medicine` int(11) NOT NULL,
  `amount` int(11) NOT NULL,
  `unit` int(11) NOT NULL,
  PRIMARY KEY (`date`,`medicine`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `patient`
--

DROP TABLE IF EXISTS `patient`;
CREATE TABLE IF NOT EXISTS `patient` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `sex` tinyint(1) NOT NULL,
  `yob` smallint(4) NOT NULL,
  `address` varchar(128) COLLATE utf8_unicode_ci NOT NULL,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `prescription`
--

DROP TABLE IF EXISTS `prescription`;
CREATE TABLE IF NOT EXISTS `prescription` (
  `code` char(11) COLLATE utf8_unicode_ci NOT NULL,
  `medicine_id` int(11) NOT NULL,
  `unit_id` int(11) NOT NULL,
  `amount` int(11) NOT NULL,
  `use_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`code`,`medicine_id`,`unit_id`),
  KEY `medicine_id` (`medicine_id`,`unit_id`),
  KEY `use_id` (`use_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `role`
--

DROP TABLE IF EXISTS `role`;
CREATE TABLE IF NOT EXISTS `role` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `user_id_change` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `role_function`
--

DROP TABLE IF EXISTS `role_function`;
CREATE TABLE IF NOT EXISTS `role_function` (
  `role` int(11) NOT NULL,
  `function` int(11) NOT NULL,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `user_change` int(11) DEFAULT NULL,
  PRIMARY KEY (`role`,`function`),
  KEY `user_change` (`user_change`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `sickness`
--

DROP TABLE IF EXISTS `sickness`;
CREATE TABLE IF NOT EXISTS `sickness` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `noted` text COLLATE utf8_unicode_ci,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `user_change` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`),
  KEY `user_change` (`user_change`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `unit_medicine`
--

DROP TABLE IF EXISTS `unit_medicine`;
CREATE TABLE IF NOT EXISTS `unit_medicine` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `user_change` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `name` (`name`),
  KEY `user_change` (`user_change`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `unit_price_medicine`
--

DROP TABLE IF EXISTS `unit_price_medicine`;
CREATE TABLE IF NOT EXISTS `unit_price_medicine` (
  `medicine_id` int(11) NOT NULL,
  `unit_id` int(11) NOT NULL,
  `unit_price` int(11) NOT NULL,
  `num_smallest_unit` int(11) NOT NULL DEFAULT '1',
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `user_change` int(11) DEFAULT NULL,
  PRIMARY KEY (`medicine_id`,`unit_id`),
  KEY `unit_id` (`unit_id`),
  KEY `user_change` (`user_change`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- --------------------------------------------------------

--
-- Table structure for table `user`
--

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user` varchar(16) COLLATE utf8_unicode_ci NOT NULL,
  `name` varchar(64) COLLATE utf8_unicode_ci DEFAULT NULL,
  `pw` varchar(16) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(128) COLLATE utf8_unicode_ci DEFAULT NULL,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `role_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `user` (`user`),
  KEY `role_id` (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

--
-- Dumping data for table `user`
--

INSERT INTO `user` (`id`, `user`, `name`, `pw`, `email`, `is_delete`, `role_id`) VALUES
(2, 'ttngoc', 'Trần Thế Ngọc', '123456789', 'ttngoc653@gmail.com', 0, NULL);

-- --------------------------------------------------------

--
-- Table structure for table `use_medicine`
--

DROP TABLE IF EXISTS `use_medicine`;
CREATE TABLE IF NOT EXISTS `use_medicine` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(128) COLLATE utf8_unicode_ci NOT NULL,
  `detail` text COLLATE utf8_unicode_ci NOT NULL,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `user_change` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
