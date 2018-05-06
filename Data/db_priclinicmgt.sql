/*
Navicat MySQL Data Transfer

Source Server         : NMCNPM_local
Source Server Version : 50714
Source Host           : localhost:3306
Source Database       : db_priclinicmgt

Target Server Type    : MYSQL
Target Server Version : 50714
File Encoding         : 65001

Date: 2018-05-06 21:53:32
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for change_reg
-- ----------------------------
DROP TABLE IF EXISTS `change_reg`;
CREATE TABLE `change_reg` (
  `modifled_day` datetime NOT NULL,
  `id_function` int(11) NOT NULL,
  `name_function` varchar(32) COLLATE utf8_unicode_ci DEFAULT NULL,
  `value_old` int(11) NOT NULL,
  `date_apply` datetime NOT NULL,
  `value_new` int(11) NOT NULL,
  `user_change` int(11) DEFAULT NULL,
  PRIMARY KEY (`id_function`),
  KEY `user_change` (`user_change`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of change_reg
-- ----------------------------
INSERT INTO `change_reg` VALUES ('2018-05-06 17:56:56', '1', 'fee', '350000', '2018-05-20 00:00:00', '450000', '3');
INSERT INTO `change_reg` VALUES ('2018-05-06 17:56:56', '2', 'patient', '55', '2018-05-20 00:00:00', '55', '3');

-- ----------------------------
-- Table structure for medical_exam
-- ----------------------------
DROP TABLE IF EXISTS `medical_exam`;
CREATE TABLE `medical_exam` (
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

-- ----------------------------
-- Records of medical_exam
-- ----------------------------

-- ----------------------------
-- Table structure for medicine
-- ----------------------------
DROP TABLE IF EXISTS `medicine`;
CREATE TABLE `medicine` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `another_name` varchar(64) COLLATE utf8_unicode_ci DEFAULT NULL,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `user_change` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `user_change` (`user_change`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of medicine
-- ----------------------------

-- ----------------------------
-- Table structure for medicine_history
-- ----------------------------
DROP TABLE IF EXISTS `medicine_history`;
CREATE TABLE `medicine_history` (
  `date` datetime NOT NULL,
  `medicine` int(11) NOT NULL,
  `amount` int(11) NOT NULL,
  `unit` int(11) NOT NULL,
  PRIMARY KEY (`date`,`medicine`)
) ENGINE=MyISAM DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of medicine_history
-- ----------------------------

-- ----------------------------
-- Table structure for patient
-- ----------------------------
DROP TABLE IF EXISTS `patient`;
CREATE TABLE `patient` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `sex` tinyint(1) NOT NULL,
  `yob` smallint(4) NOT NULL,
  `address` varchar(128) COLLATE utf8_unicode_ci NOT NULL,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of patient
-- ----------------------------

-- ----------------------------
-- Table structure for prescription
-- ----------------------------
DROP TABLE IF EXISTS `prescription`;
CREATE TABLE `prescription` (
  `code` char(11) COLLATE utf8_unicode_ci NOT NULL,
  `medicine_id` int(11) NOT NULL,
  `unit_id` int(11) NOT NULL,
  `amount` int(11) NOT NULL,
  `use_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`code`,`medicine_id`,`unit_id`),
  KEY `medicine_id` (`medicine_id`,`unit_id`),
  KEY `use_id` (`use_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of prescription
-- ----------------------------

-- ----------------------------
-- Table structure for role
-- ----------------------------
DROP TABLE IF EXISTS `role`;
CREATE TABLE `role` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `user_id_change` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of role
-- ----------------------------
INSERT INTO `role` VALUES ('1', 'Dashboard', '0', null);
INSERT INTO `role` VALUES ('2', 'Lập danh sách bệnh nhân', '0', null);
INSERT INTO `role` VALUES ('3', 'Danh sách bệnh nhân', '0', null);
INSERT INTO `role` VALUES ('4', 'Báo cáo doanh thu', '0', null);
INSERT INTO `role` VALUES ('5', 'Báo cáo sử dụng thuốc', '0', null);
INSERT INTO `role` VALUES ('6', 'Quản lý quy định', '0', null);
INSERT INTO `role` VALUES ('7', 'Quản lý người dùng', '0', null);

-- ----------------------------
-- Table structure for role_function
-- ----------------------------
DROP TABLE IF EXISTS `role_function`;
CREATE TABLE `role_function` (
  `role` int(11) NOT NULL,
  `function` int(11) NOT NULL,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `user_change` int(11) DEFAULT NULL,
  PRIMARY KEY (`role`,`function`),
  KEY `user_change` (`user_change`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of role_function
-- ----------------------------
INSERT INTO `role_function` VALUES ('1', '1', '0', null);
INSERT INTO `role_function` VALUES ('1', '4', '0', null);
INSERT INTO `role_function` VALUES ('1', '5', '0', null);
INSERT INTO `role_function` VALUES ('1', '6', '0', null);
INSERT INTO `role_function` VALUES ('1', '7', '0', null);
INSERT INTO `role_function` VALUES ('2', '3', '0', null);
INSERT INTO `role_function` VALUES ('3', '2', '0', null);

-- ----------------------------
-- Table structure for sickness
-- ----------------------------
DROP TABLE IF EXISTS `sickness`;
CREATE TABLE `sickness` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(64) COLLATE utf8_unicode_ci NOT NULL,
  `noted` text COLLATE utf8_unicode_ci,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `user_change` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `user_change` (`user_change`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of sickness
-- ----------------------------

-- ----------------------------
-- Table structure for unit_medicine
-- ----------------------------
DROP TABLE IF EXISTS `unit_medicine`;
CREATE TABLE `unit_medicine` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(32) COLLATE utf8_unicode_ci NOT NULL,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `user_change` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `user_change` (`user_change`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of unit_medicine
-- ----------------------------

-- ----------------------------
-- Table structure for unit_price_medicine
-- ----------------------------
DROP TABLE IF EXISTS `unit_price_medicine`;
CREATE TABLE `unit_price_medicine` (
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

-- ----------------------------
-- Records of unit_price_medicine
-- ----------------------------

-- ----------------------------
-- Table structure for user
-- ----------------------------
DROP TABLE IF EXISTS `user`;
CREATE TABLE `user` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `user` varchar(16) CHARACTER SET utf8mb4 NOT NULL,
  `name` varchar(64) COLLATE utf8_unicode_ci DEFAULT NULL,
  `pw` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `email` varchar(128) COLLATE utf8_unicode_ci DEFAULT NULL,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `role_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `role_id` (`role_id`)
) ENGINE=InnoDB AUTO_INCREMENT=12 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of user
-- ----------------------------
INSERT INTO `user` VALUES ('1', 'admin', 'Admin', 'e10adc3949ba59abbe56e057f20f883e', 'admin@gmail.com', '0', '1');

-- ----------------------------
-- Table structure for use_medicine
-- ----------------------------
DROP TABLE IF EXISTS `use_medicine`;
CREATE TABLE `use_medicine` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `name` varchar(128) COLLATE utf8_unicode_ci NOT NULL,
  `detail` text COLLATE utf8_unicode_ci NOT NULL,
  `is_delete` tinyint(1) NOT NULL DEFAULT '0',
  `user_change` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;

-- ----------------------------
-- Records of use_medicine
-- ----------------------------
