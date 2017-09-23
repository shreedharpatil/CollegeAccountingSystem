-- MySqlBackup.NET 2.0.8
-- Dump Time: 2015-08-03 12:10:15
-- --------------------------------------
-- Server version 5.6.25-log MySQL Community Server (GPL)


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;


-- 
-- Definition of admin
-- 
DROP DATABASE IF EXISTS DAS;
CREATE DATABASE DAS;
USE DAS;

DROP TABLE IF EXISTS `admin`;
CREATE TABLE IF NOT EXISTS `admin` (
  `id` varchar(30) DEFAULT NULL,
  `name` varchar(40) DEFAULT NULL,
  `contact_number` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table admin
-- 

/*!40000 ALTER TABLE `admin` DISABLE KEYS */;
INSERT INTO `admin`(`id`,`name`,`contact_number`) VALUES
('1234','Shreedhar','98989898989');
/*!40000 ALTER TABLE `admin` ENABLE KEYS */;

-- 
-- Definition of branch
-- 

DROP TABLE IF EXISTS `branch`;
CREATE TABLE IF NOT EXISTS `branch` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `name` varchar(40) DEFAULT NULL,
  `application` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table branch
-- 

/*!40000 ALTER TABLE `branch` DISABLE KEYS */;
INSERT INTO `branch`(`id`,`name`,`application`) VALUES
(1,'Computer Science','diploma'),
(2,'Mechanical','diploma'),
(3,'Electrical','diploma'),
(4,'Electronics','diploma'),
(5,'Civil','diploma'),
(7,'MCA','diploma'),
(8,NULL,'diploma'),
(9,NULL,'diploma'),
(10,NULL,'diploma'),
(11,'MBA','diploma'),
(12,'BBA','diploma'),
(13,'Diploma in Lab Technician','paramedical'),
(14,'Diploma in Health Inspector','paramedical'),
(15,'Diploma in General Nursing','nursing'),
(18,'Diploma in Pharmacy','pharmacy'),
(19,'B.A','degree'),
(20,'B.Sc','degree');
/*!40000 ALTER TABLE `branch` ENABLE KEYS */;

-- 
-- Definition of degreefees
-- 

DROP TABLE IF EXISTS `degreefees`;
CREATE TABLE IF NOT EXISTS `degreefees` (
  `student_id` int(10) DEFAULT NULL,
  `year` int(10) DEFAULT NULL,
  `tution_fee` decimal(10,2) DEFAULT NULL,
  `lab_fee` decimal(10,2) DEFAULT NULL,
  `library_fee` decimal(10,2) DEFAULT NULL,
  `identity_card_fee` decimal(10,2) DEFAULT NULL,
  `reading_room_fee` decimal(10,2) DEFAULT NULL,
  `magazine_fee` decimal(10,2) DEFAULT NULL,
  `student_welfare_fund_fee` decimal(10,2) DEFAULT NULL,
  `teacher_benefit_fund_fee` decimal(10,2) DEFAULT NULL,
  `college_sports_fee` decimal(10,2) DEFAULT NULL,
  `application_fee` decimal(10,2) DEFAULT NULL,
  `house_exam_fee` decimal(10,2) DEFAULT NULL,
  `medical_exam_fee` decimal(10,2) DEFAULT NULL,
  `union_fee` decimal(10,2) DEFAULT NULL,
  `annual_day_fee` decimal(10,2) DEFAULT NULL,
  `student_aid_fund_fee` decimal(10,2) DEFAULT NULL,
  `science_development_fee` decimal(10,2) DEFAULT NULL,
  `university_registration_fee` decimal(10,2) DEFAULT NULL,
  `eligibility_application_fee` decimal(10,2) DEFAULT NULL,
  `eligibility_fee` decimal(10,2) DEFAULT NULL,
  `university_sports_fee` decimal(10,2) DEFAULT NULL,
  `university_welfare_fee` decimal(10,2) DEFAULT NULL,
  `carrier_guidence_fund_fee` decimal(10,2) DEFAULT NULL,
  `corpus_fund_fee` decimal(10,2) DEFAULT NULL,
  `arrear_fee` decimal(10,2) DEFAULT NULL,
  `nss_Fee` decimal(10,2) DEFAULT NULL,
  `college_development_fee` decimal(10,2) DEFAULT NULL,
  `university_silver_jubilee_fee` decimal(10,2) DEFAULT NULL,
  `miscellaneous_fee` decimal(10,2) DEFAULT NULL,
  `date_of_admission` date DEFAULT NULL,
  `fee_paid` decimal(10,2) DEFAULT NULL,
  `due_fee` decimal(10,2) DEFAULT NULL,
  `due_date` date DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `total_fee` decimal(10,2) DEFAULT NULL,
  `year_of_admission` varchar(10) DEFAULT NULL,
  `mis_fee` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table degreefees
-- 

/*!40000 ALTER TABLE `degreefees` DISABLE KEYS */;
INSERT INTO `degreefees`(`student_id`,`year`,`tution_fee`,`lab_fee`,`library_fee`,`identity_card_fee`,`reading_room_fee`,`magazine_fee`,`student_welfare_fund_fee`,`teacher_benefit_fund_fee`,`college_sports_fee`,`application_fee`,`house_exam_fee`,`medical_exam_fee`,`union_fee`,`annual_day_fee`,`student_aid_fund_fee`,`science_development_fee`,`university_registration_fee`,`eligibility_application_fee`,`eligibility_fee`,`university_sports_fee`,`university_welfare_fee`,`carrier_guidence_fund_fee`,`corpus_fund_fee`,`arrear_fee`,`nss_Fee`,`college_development_fee`,`university_silver_jubilee_fee`,`miscellaneous_fee`,`date_of_admission`,`fee_paid`,`due_fee`,`due_date`,`status`,`total_fee`,`year_of_admission`,`mis_fee`) VALUES
(2,1,20000.00,23.00,21.00,100.00,200.00,100.00,30.00,45.00,25.00,0.00,0.00,0.00,0.00,200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'2015-07-09 00:00:00',20744.00,0.00,NULL,'Paid',20744.00,'2015',NULL),
(1,1,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,'2015-07-10 00:00:00',2700.00,100.00,'2015-07-31 00:00:00','Unpaid',2800.00,'2015',NULL),
(1,2,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,'2015-07-10 00:00:00',2500.00,300.00,'2015-07-03 00:00:00','Unpaid',2800.00,'2015',100.00),
(4,1,20000.00,0.00,0.00,100.00,0.00,200.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'2015-07-10 00:00:00',0.00,0.00,NULL,'Paid',20300.00,'2015',0.00);
/*!40000 ALTER TABLE `degreefees` ENABLE KEYS */;

-- 
-- Definition of degreestudents
-- 

DROP TABLE IF EXISTS `degreestudents`;
CREATE TABLE IF NOT EXISTS `degreestudents` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) DEFAULT NULL,
  `address` varchar(50) DEFAULT NULL,
  `contact_number` varchar(15) DEFAULT NULL,
  `gender` varchar(10) DEFAULT NULL,
  `branch_id` int(10) DEFAULT NULL,
  `quota` varchar(30) DEFAULT NULL,
  `date_of_registration` date DEFAULT NULL,
  `image_url` varchar(100) DEFAULT NULL,
  `fathername` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table degreestudents
-- 

/*!40000 ALTER TABLE `degreestudents` DISABLE KEYS */;
INSERT INTO `degreestudents`(`id`,`name`,`address`,`contact_number`,`gender`,`branch_id`,`quota`,`date_of_registration`,`image_url`,`fathername`) VALUES
(1,'Shreedhar, Patil','Badami','9898988988','Male',19,'Government','2015-07-09 00:00:00','/photos/default/photo1.jpg','R'),
(2,'Kaka, Kaka','Bdm','7888887878','Male',19,'Management','2015-07-09 00:00:00','/photos/default/photo8.png','K'),
(3,'Kaka, Kaka','Bdm','7888887878','Male',19,'Management','2015-07-09 00:00:00','/photos/degree/Kaka-Kaka--3.jpg','K'),
(4,'Muttu, M','Naragund','98989899899','Male',19,'Government','2015-07-10 00:00:00','/photos/degree/Muttu-M--4.jpg','N');
/*!40000 ALTER TABLE `degreestudents` ENABLE KEYS */;

-- 
-- Definition of diplomafees
-- 

DROP TABLE IF EXISTS `diplomafees`;
CREATE TABLE IF NOT EXISTS `diplomafees` (
  `student_id` int(10) DEFAULT NULL,
  `year` int(10) DEFAULT NULL,
  `tution_fee` decimal(10,2) DEFAULT NULL,
  `admission_form_fee` decimal(10,2) DEFAULT NULL,
  `lab_fee` decimal(10,2) DEFAULT NULL,
  `library_fee` decimal(10,2) DEFAULT NULL,
  `other_fee` decimal(10,2) DEFAULT NULL,
  `fee_paid` decimal(10,2) DEFAULT NULL,
  `due_fee` decimal(10,2) DEFAULT NULL,
  `due_date` date DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `total_fee` decimal(10,2) DEFAULT NULL,
  `year_of_admission` varchar(10) DEFAULT NULL,
  `admission_fee` decimal(10,2) DEFAULT NULL,
  `identity_card_fee` decimal(10,2) DEFAULT NULL,
  `student_Association_fee` decimal(10,2) DEFAULT NULL,
  `reading_room_fee` decimal(10,2) DEFAULT NULL,
  `magazine_fee` decimal(10,2) DEFAULT NULL,
  `student_welfare_fund_fee` decimal(10,2) DEFAULT NULL,
  `teacher_benefit_fund_fee` decimal(10,2) DEFAULT NULL,
  `sports_fee` decimal(10,2) DEFAULT NULL,
  `fine_fee` decimal(10,2) DEFAULT NULL,
  `admission_fine_fee` decimal(10,2) DEFAULT NULL,
  `date_of_admission` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table diplomafees
-- 

/*!40000 ALTER TABLE `diplomafees` DISABLE KEYS */;
INSERT INTO `diplomafees`(`student_id`,`year`,`tution_fee`,`admission_form_fee`,`lab_fee`,`library_fee`,`other_fee`,`fee_paid`,`due_fee`,`due_date`,`status`,`total_fee`,`year_of_admission`,`admission_fee`,`identity_card_fee`,`student_Association_fee`,`reading_room_fee`,`magazine_fee`,`student_welfare_fund_fee`,`teacher_benefit_fund_fee`,`sports_fee`,`fine_fee`,`admission_fine_fee`,`date_of_admission`) VALUES
(10,1,20000.00,100.00,200.00,100.00,200.00,16000.00,4600.00,'2015-06-18 00:00:00','Unpaid',20600.00,'2015',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
(11,1,15000.00,100.00,200.00,100.00,200.00,10000.00,5600.00,'2015-06-27 00:00:00','Unpaid',15600.00,'2015',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
(12,1,30000.00,200.00,300.00,100.00,400.00,21000.00,10000.00,'2015-06-27 00:00:00','Unpaid',31000.00,'2015',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
(13,1,25000.00,200.00,100.00,300.00,100.00,5700.00,20000.00,'2015-06-26 00:00:00','Unpaid',25700.00,'2015',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
(14,1,24000.00,100.00,200.00,300.00,400.00,25000.00,0.00,'0001-01-01 00:00:00','Paid',25000.00,'2015',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
(15,1,30000.00,100.00,100.00,200.00,200.00,30000.00,600.00,'2015-06-30 00:00:00','Unpaid',30600.00,'2015',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
(16,1,35000.00,200.00,100.00,200.00,100.00,35600.00,0.00,NULL,'Paid',35600.00,'2015',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
(17,1,18000.00,200.00,300.00,400.00,500.00,5400.00,14000.00,'2015-06-12 00:00:00','Unpaid',19400.00,'2015',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
(12,2,20000.00,200.00,200.00,100.00,100.00,20000.00,600.00,'2015-06-22 00:00:00','Unpaid',20600.00,'2015',NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL,NULL),
(16,0,100.00,NULL,100.00,100.00,400.00,1500.00,500.00,'2015-06-27 00:00:00','Unpaid',2000.00,'2015',100.00,100.00,100.00,100.00,100.00,200.00,100.00,200.00,100.00,100.00,NULL),
(16,3,100.00,100.00,100.00,100.00,100.00,1200.00,300.00,'2015-06-24 00:00:00','Unpaid',1500.00,'2015',100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,NULL),
(15,2,20000.00,100.00,200.00,100.50,100.00,15000.00,6750.50,'2015-06-25 00:00:00','Unpaid',21750.50,'2015',200.00,100.00,200.00,100.00,50.00,100.00,200.00,100.00,100.00,100.00,'2015-06-20 00:00:00'),
(12,3,100.00,100.00,100.00,100.00,100.00,1500.00,0.00,'0001-01-01 00:00:00','Paid',1500.00,'2015',100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,'2015-06-20 00:00:00'),
(14,2,200.00,200.00,200.00,200.00,200.00,3000.00,0.00,'0001-01-01 00:00:00','Paid',3000.00,'2015',200.00,200.00,200.00,200.00,200.00,200.00,200.00,200.00,200.00,200.00,'2015-06-20 00:00:00'),
(14,3,100.00,100.00,100.00,100.00,100.00,1500.00,0.00,NULL,'Paid',1500.00,'2015',100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,'2015-06-20 00:00:00'),
(19,1,20000.00,100.00,100.00,100.00,200.00,21600.00,0.00,'2015-06-30 00:00:00','Paid',21600.00,'2015',100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,200.00,'2015-06-21 00:00:00'),
(20,1,20000.00,100.00,100.00,10.00,100.00,21210.00,0.00,NULL,'Paid',21210.00,'2015',100.00,100.00,100.00,0.00,0.00,100.00,200.00,100.00,100.00,100.00,'2015-06-21 00:00:00'),
(21,1,20000.00,100.00,200.00,100.00,200.00,21900.00,0.00,NULL,'Paid',21900.00,'2015',200.00,100.00,200.00,200.00,100.00,200.00,100.00,100.00,0.00,100.00,'2015-06-28 00:00:00'),
(21,2,20000.00,100.00,10.00,10.00,100.00,21000.00,720.00,'2015-06-19 00:00:00','Unpaid',21720.00,'2015',200.00,100.00,200.00,100.00,200.00,200.00,100.00,200.00,100.00,100.00,'2015-06-28 00:00:00');
/*!40000 ALTER TABLE `diplomafees` ENABLE KEYS */;

-- 
-- Definition of diplomastudents
-- 

DROP TABLE IF EXISTS `diplomastudents`;
CREATE TABLE IF NOT EXISTS `diplomastudents` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) DEFAULT NULL,
  `address` varchar(50) DEFAULT NULL,
  `contact_number` varchar(15) DEFAULT NULL,
  `gender` varchar(10) DEFAULT NULL,
  `branch_id` int(10) DEFAULT NULL,
  `quota` varchar(30) DEFAULT NULL,
  `date_of_registration` date DEFAULT NULL,
  `image_url` varchar(100) DEFAULT NULL,
  `fathername` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=23 DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table diplomastudents
-- 

/*!40000 ALTER TABLE `diplomastudents` DISABLE KEYS */;
INSERT INTO `diplomastudents`(`id`,`name`,`address`,`contact_number`,`gender`,`branch_id`,`quota`,`date_of_registration`,`image_url`,`fathername`) VALUES
(10,'shreedhar, patil','Badami','9449484884','Male',1,'Government','2015-06-06 00:00:00','/photos/default/photo6.png',NULL),
(11,'pramod, patil','Badami','9449484884','Male',1,'Management','2015-06-06 00:00:00','/photos/default/photo10.jpg',NULL),
(12,'santosh, patil','Badami','9449484884','Male',1,'Government','2015-06-06 00:00:00','/photos/default/photo1.jpg',NULL),
(13,'ramachandra, patil','Badami','9449484884','Male',1,'Management','2015-06-06 00:00:00','/photos/default/photo6.png',NULL),
(14,'ganesh, patil','Badami','9449484884','Male',1,'Government','2015-06-06 00:00:00','/photos/default/photo2.png',NULL),
(15,'jyanakibai, patil','Badami','9449484884','Female',1,'Management','2015-06-06 00:00:00','/photos/default/photo8.png',NULL),
(16,'rukminibai, patil','Badami','9449484884','Female',1,'Government','2015-06-06 00:00:00','/photos/default/photo5.jpg',NULL),
(17,'inky, ponky','Badami','9449484884','Female',1,'Management','2015-06-06 00:00:00','/photos/default/photo3.jpg',NULL),
(18,'Abc, Def','jhkk','88888888888','Female',2,'Government','2015-06-13 00:00:00','/photos/diploma/Abc-Def--18.jpg',NULL),
(19,'Arun, Shivashimpi','BAdami','8987575747','Male',2,'Government','2015-06-21 00:00:00','/photos/diploma/Arun-Shivashimpi--19.jpg','A'),
(20,'Test, Test','Test','8989899899','Female',2,'Government','2015-06-21 00:00:00','/photos/default/photo2.png','A'),
(21,'Abc, Efg','Badami','9899543949','Male',2,'Government','2015-06-28 00:00:00','/photos/diploma/Abc-Efg--21.jpg','D'),
(22,'test, test','dfgdfg','7878787875','Male',1,'Government','2015-07-16 00:00:00','/photos/diploma/test-test--22.jpg','test');
/*!40000 ALTER TABLE `diplomastudents` ENABLE KEYS */;

-- 
-- Definition of login
-- 

DROP TABLE IF EXISTS `login`;
CREATE TABLE IF NOT EXISTS `login` (
  `username` varchar(30) DEFAULT NULL,
  `password` varchar(30) DEFAULT NULL,
  `user_type` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table login
-- 

/*!40000 ALTER TABLE `login` DISABLE KEYS */;
INSERT INTO `login`(`username`,`password`,`user_type`) VALUES
('admin','admin','admin'),
('user','user','user');
/*!40000 ALTER TABLE `login` ENABLE KEYS */;

-- 
-- Definition of nursingfees
-- 

DROP TABLE IF EXISTS `nursingfees`;
CREATE TABLE IF NOT EXISTS `nursingfees` (
  `student_id` int(10) DEFAULT NULL,
  `year` int(10) DEFAULT NULL,
  `tution_fee` decimal(10,2) DEFAULT NULL,
  `lab_fee` decimal(10,2) DEFAULT NULL,
  `library_fee` decimal(10,2) DEFAULT NULL,
  `other_fee` decimal(10,2) DEFAULT NULL,
  `fee_paid` decimal(10,2) DEFAULT NULL,
  `due_fee` decimal(10,2) DEFAULT NULL,
  `due_date` date DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `total_fee` decimal(10,2) DEFAULT NULL,
  `year_of_admission` varchar(10) DEFAULT NULL,
  `admission_fee` decimal(10,2) DEFAULT NULL,
  `caution_deposit_fee` decimal(10,2) DEFAULT NULL,
  `uniform_fee` decimal(10,2) DEFAULT NULL,
  `books_fee` decimal(10,2) DEFAULT NULL,
  `mess_fee` decimal(10,2) DEFAULT NULL,
  `hostel_fee` decimal(10,2) DEFAULT NULL,
  `examination_fee` decimal(10,2) DEFAULT NULL,
  `sports_fee` decimal(10,2) DEFAULT NULL,
  `transportation_fee` decimal(10,2) DEFAULT NULL,
  `medical_fee` decimal(10,2) DEFAULT NULL,
  `phychiatric_fee` decimal(10,2) DEFAULT NULL,
  `date_of_admission` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table nursingfees
-- 

/*!40000 ALTER TABLE `nursingfees` DISABLE KEYS */;
INSERT INTO `nursingfees`(`student_id`,`year`,`tution_fee`,`lab_fee`,`library_fee`,`other_fee`,`fee_paid`,`due_fee`,`due_date`,`status`,`total_fee`,`year_of_admission`,`admission_fee`,`caution_deposit_fee`,`uniform_fee`,`books_fee`,`mess_fee`,`hostel_fee`,`examination_fee`,`sports_fee`,`transportation_fee`,`medical_fee`,`phychiatric_fee`,`date_of_admission`) VALUES
(1,1,20000.00,100.00,100.00,100.00,21400.00,0.00,NULL,'Paid',21400.00,'2015',100.00,100.00,100.00,NULL,100.00,100.00,100.00,100.00,100.00,100.00,100.00,'2015-07-01 00:00:00'),
(2,1,20000.00,100.00,200.00,100.00,22100.00,0.00,NULL,'Paid',22100.00,'2015',200.00,200.00,200.00,NULL,200.00,100.00,200.00,100.00,100.00,200.00,100.00,'2015-07-01 00:00:00'),
(3,1,20000.00,100.00,100.00,100.00,21700.00,0.00,NULL,'Paid',21700.00,'2015',100.00,100.00,100.00,NULL,100.00,200.00,100.00,100.00,100.00,200.00,100.00,'2015-07-02 00:00:00'),
(1,2,20000.00,0.00,0.00,0.00,0.00,0.00,NULL,'Unpaid',20100.00,'2015',100.00,0.00,0.00,NULL,0.00,0.00,0.00,0.00,0.00,0.00,0.00,'2015-07-10 00:00:00'),
(1,3,20000.00,0.00,0.00,0.00,20300.00,0.00,NULL,'Paid',20300.00,'2015',200.00,0.00,0.00,NULL,0.00,0.00,0.00,0.00,0.00,0.00,100.00,'2015-07-10 00:00:00');
/*!40000 ALTER TABLE `nursingfees` ENABLE KEYS */;

-- 
-- Definition of nursingstudents
-- 

DROP TABLE IF EXISTS `nursingstudents`;
CREATE TABLE IF NOT EXISTS `nursingstudents` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) DEFAULT NULL,
  `address` varchar(50) DEFAULT NULL,
  `contact_number` varchar(15) DEFAULT NULL,
  `gender` varchar(10) DEFAULT NULL,
  `branch_id` int(10) DEFAULT NULL,
  `quota` varchar(30) DEFAULT NULL,
  `date_of_registration` date DEFAULT NULL,
  `image_url` varchar(100) DEFAULT NULL,
  `fathername` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table nursingstudents
-- 

/*!40000 ALTER TABLE `nursingstudents` DISABLE KEYS */;
INSERT INTO `nursingstudents`(`id`,`name`,`address`,`contact_number`,`gender`,`branch_id`,`quota`,`date_of_registration`,`image_url`,`fathername`) VALUES
(1,'Shreedhar, Patil','BAdami','88989989989','Male',15,'Government','2015-07-01 00:00:00','/photos/default/photo1.jpg','R'),
(2,'Pramod, Patil','BAdami','88989989989','Male',15,'Government','2015-07-01 00:00:00','/photos/nursing/Pramod-Patil--2.jpg','R'),
(3,'Final, Test','Badami','83942309048','Female',15,'Government','2015-07-02 00:00:00','/photos/default/photo6.png','Y');
/*!40000 ALTER TABLE `nursingstudents` ENABLE KEYS */;

-- 
-- Definition of paramedicalfees
-- 

DROP TABLE IF EXISTS `paramedicalfees`;
CREATE TABLE IF NOT EXISTS `paramedicalfees` (
  `student_id` int(10) DEFAULT NULL,
  `year` int(10) DEFAULT NULL,
  `tution_fee` decimal(10,2) DEFAULT NULL,
  `admission_form_fee` decimal(10,2) DEFAULT NULL,
  `lab_fee` decimal(10,2) DEFAULT NULL,
  `library_fee` decimal(10,2) DEFAULT NULL,
  `other_fee` decimal(10,2) DEFAULT NULL,
  `fee_paid` decimal(10,2) DEFAULT NULL,
  `due_fee` decimal(10,2) DEFAULT NULL,
  `due_date` date DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `total_fee` decimal(10,2) DEFAULT NULL,
  `year_of_admission` varchar(10) DEFAULT NULL,
  `admission_fee` decimal(10,2) DEFAULT NULL,
  `identity_card_fee` decimal(10,2) DEFAULT NULL,
  `student_Association_fee` decimal(10,2) DEFAULT NULL,
  `reading_room_fee` decimal(10,2) DEFAULT NULL,
  `magazine_fee` decimal(10,2) DEFAULT NULL,
  `student_welfare_fund_fee` decimal(10,2) DEFAULT NULL,
  `teacher_benefit_fund_fee` decimal(10,2) DEFAULT NULL,
  `sports_fee` decimal(10,2) DEFAULT NULL,
  `fine_fee` decimal(10,2) DEFAULT NULL,
  `admission_fine_fee` decimal(10,2) DEFAULT NULL,
  `date_of_admission` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table paramedicalfees
-- 

/*!40000 ALTER TABLE `paramedicalfees` DISABLE KEYS */;
INSERT INTO `paramedicalfees`(`student_id`,`year`,`tution_fee`,`admission_form_fee`,`lab_fee`,`library_fee`,`other_fee`,`fee_paid`,`due_fee`,`due_date`,`status`,`total_fee`,`year_of_admission`,`admission_fee`,`identity_card_fee`,`student_Association_fee`,`reading_room_fee`,`magazine_fee`,`student_welfare_fund_fee`,`teacher_benefit_fund_fee`,`sports_fee`,`fine_fee`,`admission_fine_fee`,`date_of_admission`) VALUES
(1,1,20000.00,100.00,200.00,100.00,100.00,21000.00,900.00,'2015-06-27 00:00:00','Unpaid',21900.00,'2015',200.00,100.00,200.00,100.00,200.00,100.00,200.00,100.00,100.00,100.00,'2015-06-28 00:00:00'),
(2,1,20000.00,100.00,100.00,100.00,100.00,21400.00,0.00,NULL,'Paid',21400.00,'2015',100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,'2015-06-28 00:00:00'),
(2,2,15000.00,100.00,100.00,100.00,100.00,16400.00,0.00,NULL,'Paid',16400.00,'2015',100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,100.00,'2015-06-28 00:00:00');
/*!40000 ALTER TABLE `paramedicalfees` ENABLE KEYS */;

-- 
-- Definition of paramedicalstudents
-- 

DROP TABLE IF EXISTS `paramedicalstudents`;
CREATE TABLE IF NOT EXISTS `paramedicalstudents` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) DEFAULT NULL,
  `address` varchar(50) DEFAULT NULL,
  `contact_number` varchar(15) DEFAULT NULL,
  `gender` varchar(10) DEFAULT NULL,
  `branch_id` int(10) DEFAULT NULL,
  `quota` varchar(30) DEFAULT NULL,
  `date_of_registration` date DEFAULT NULL,
  `image_url` varchar(100) DEFAULT NULL,
  `fathername` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table paramedicalstudents
-- 

/*!40000 ALTER TABLE `paramedicalstudents` DISABLE KEYS */;
INSERT INTO `paramedicalstudents`(`id`,`name`,`address`,`contact_number`,`gender`,`branch_id`,`quota`,`date_of_registration`,`image_url`,`fathername`) VALUES
(1,'Shivukumar, Reddy','Badami','8989898989','Male',13,'Government','2015-06-28 00:00:00','/photos/paramedical/Shivukumar-Reddy--1.jpg','M'),
(2,'Arun, Patil','Badami','3434534534','Male',14,'Management','2015-06-28 00:00:00','/photos/paramedical/Arun-Patil--2.jpg','A');
/*!40000 ALTER TABLE `paramedicalstudents` ENABLE KEYS */;

-- 
-- Definition of pharmacyfees
-- 

DROP TABLE IF EXISTS `pharmacyfees`;
CREATE TABLE IF NOT EXISTS `pharmacyfees` (
  `student_id` int(10) DEFAULT NULL,
  `year` int(10) DEFAULT NULL,
  `tution_fee` decimal(10,2) DEFAULT NULL,
  `home_exam_fee` decimal(10,2) DEFAULT NULL,
  `lab_fee` decimal(10,2) DEFAULT NULL,
  `library_fee` decimal(10,2) DEFAULT NULL,
  `other_fee` decimal(10,2) DEFAULT NULL,
  `fee_paid` decimal(10,2) DEFAULT NULL,
  `due_fee` decimal(10,2) DEFAULT NULL,
  `due_date` date DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `total_fee` decimal(10,2) DEFAULT NULL,
  `year_of_admission` varchar(10) DEFAULT NULL,
  `admission_fee` decimal(10,2) DEFAULT NULL,
  `identity_card_fee` decimal(10,2) DEFAULT NULL,
  `medical_fee` decimal(10,2) DEFAULT NULL,
  `caution_fee` decimal(10,2) DEFAULT NULL,
  `mis_fee` decimal(10,2) DEFAULT NULL,
  `lab_deposit_fee` decimal(10,2) DEFAULT NULL,
  `student_aid_fund_fee` decimal(10,2) DEFAULT NULL,
  `sports_fee` decimal(10,2) DEFAULT NULL,
  `magazine_fee` decimal(10,2) DEFAULT NULL,
  `journal_fee` decimal(10,2) DEFAULT NULL,
  `date_of_admission` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table pharmacyfees
-- 

/*!40000 ALTER TABLE `pharmacyfees` DISABLE KEYS */;
INSERT INTO `pharmacyfees`(`student_id`,`year`,`tution_fee`,`home_exam_fee`,`lab_fee`,`library_fee`,`other_fee`,`fee_paid`,`due_fee`,`due_date`,`status`,`total_fee`,`year_of_admission`,`admission_fee`,`identity_card_fee`,`medical_fee`,`caution_fee`,`mis_fee`,`lab_deposit_fee`,`student_aid_fund_fee`,`sports_fee`,`magazine_fee`,`journal_fee`,`date_of_admission`) VALUES
(1,1,20000.00,100.00,200.00,100.00,200.00,21900.00,0.00,NULL,'Paid',21900.00,'2015',100.00,200.00,200.00,100.00,200.00,200.00,200.00,100.00,100.00,100.00,'2015-07-06 00:00:00'),
(1,2,20000.00,200.00,200.00,100.00,200.00,21550.50,349.50,NULL,'Unpaid',21900.00,'2015',100.00,200.00,100.00,100.00,100.00,200.00,100.00,200.00,200.00,100.00,'2015-07-06 00:00:00');
/*!40000 ALTER TABLE `pharmacyfees` ENABLE KEYS */;

-- 
-- Definition of pharmacystudents
-- 

DROP TABLE IF EXISTS `pharmacystudents`;
CREATE TABLE IF NOT EXISTS `pharmacystudents` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `name` varchar(30) DEFAULT NULL,
  `address` varchar(50) DEFAULT NULL,
  `contact_number` varchar(15) DEFAULT NULL,
  `gender` varchar(10) DEFAULT NULL,
  `branch_id` int(10) DEFAULT NULL,
  `quota` varchar(30) DEFAULT NULL,
  `date_of_registration` date DEFAULT NULL,
  `image_url` varchar(100) DEFAULT NULL,
  `fathername` varchar(40) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=15 DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table pharmacystudents
-- 

/*!40000 ALTER TABLE `pharmacystudents` DISABLE KEYS */;
INSERT INTO `pharmacystudents`(`id`,`name`,`address`,`contact_number`,`gender`,`branch_id`,`quota`,`date_of_registration`,`image_url`,`fathername`) VALUES
(1,'Shreedhar, Patil','Badami','4493493434','Male',18,'Government','2015-07-06 00:00:00','/photos/default/photo10.jpg','R'),
(2,'Pramod, Patil','BAdami','9989888999','Male',18,'Management','2015-07-06 00:00:00','/photos/pharmacy/Pramod-Patil--2.jpg','R'),
(3,'A, S','Badami','3898908908','Male',18,'Government','2015-07-06 00:00:00','/photos/default/photo8.png','A'),
(4,'Test, T','Pune','5675675675','Female',18,'Government','2015-07-06 00:00:00','/photos/pharmacy/Test-T--4.jpg','G'),
(5,'Ywew, Rtrtrr','TEst','090976076079','Female',18,'Management','2015-07-06 00:00:00','/photos/pharmacy/Ywew-Rtrtrr--5.jpg','W'),
(6,'Abc, Efg','Bangalore','9898989899','Female',18,'Management','2015-07-06 00:00:00','/photos/default/photo3.jpg','D'),
(7,'Gf, WEr','wer','9838999322','Female',18,'Government','2015-07-06 00:00:00','/photos/default/photo6.png','E'),
(8,'TEwet, werw','irweo','9898298909','Male',18,'Government','2015-07-06 00:00:00','/photos/pharmacy/TEwet-werw--8.jpg','wer'),
(9,'Shankar, Kattimani','badami','7888888777','Male',18,'Government','2015-07-07 00:00:00','/photos/pharmacy/Shankar-Kattimani--9.jpg','K'),
(10,'Register, Photo','Test','4543534534','Male',18,'Government','2015-07-07 00:00:00','/photos/pharmacy/Register-Photo--10.jpg','With'),
(11,'Register, Photo','Test','9998989898','Male',18,'Management','2015-07-07 00:00:00','/photos/default/photo3.jpg','Without'),
(12,'test, jshd','sdfsd','4534534548','Male',18,'Management','2015-07-07 00:00:00','/photos/default/photo3.jpg','r'),
(13,'uyuyuy, uiyu','hjhjhkh','9989999999','Male',18,'Management','2015-07-07 00:00:00','/photos/default/photo7.jpg','u'),
(14,'yuy, uyu','iuu','98998989898','Male',18,'Management','2015-07-07 00:00:00','/photos/default/photo10.jpg','u');
/*!40000 ALTER TABLE `pharmacystudents` ENABLE KEYS */;

-- 
-- Definition of quota
-- 

DROP TABLE IF EXISTS `quota`;
CREATE TABLE IF NOT EXISTS `quota` (
  `id` int(10) NOT NULL AUTO_INCREMENT,
  `Quota_type` varchar(10) DEFAULT NULL,
  `branch_id` int(10) DEFAULT NULL,
  `number_of_seats` int(10) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table quota
-- 

/*!40000 ALTER TABLE `quota` DISABLE KEYS */;
INSERT INTO `quota`(`id`,`Quota_type`,`branch_id`,`number_of_seats`) VALUES
(1,'Government',1,5),
(2,'Management',1,30),
(3,'Government',2,60),
(4,'Government',4,60),
(5,'Government',3,60),
(6,'Management',3,30),
(7,'Government',4,60),
(8,'Management',2,30),
(9,'Government',13,60),
(10,'Management',13,30),
(11,'Government',14,60),
(12,'Management',14,30),
(13,'Government',15,60),
(14,'Management',15,30),
(15,'Government',18,60),
(16,'Management',18,2),
(17,'Government',19,60),
(18,'Management',19,30),
(19,'Government',20,60),
(20,'Management',20,30);
/*!40000 ALTER TABLE `quota` ENABLE KEYS */;

-- 
-- Definition of user
-- 

DROP TABLE IF EXISTS `user`;
CREATE TABLE IF NOT EXISTS `user` (
  `id` varchar(30) DEFAULT NULL,
  `name` varchar(40) DEFAULT NULL,
  `contact_number` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- 
-- Dumping data for table user
-- 

/*!40000 ALTER TABLE `user` DISABLE KEYS */;

/*!40000 ALTER TABLE `user` ENABLE KEYS */;


/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;


-- Dump completed on 2015-08-03 12:10:15
-- Total time: 0:0:0:0:536 (d:h:m:s:ms)
