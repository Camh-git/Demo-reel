-- phpMyAdmin SQL Dump
-- version 4.8.4
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Nov 24, 2020 at 05:13 PM
-- Server version: 10.1.37-MariaDB
-- PHP Version: 7.3.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `banking_app_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `account details`
--

CREATE TABLE `account details` (
  `Account number` int(10) NOT NULL,
  `Account ballance` decimal(10,2) NOT NULL,
  `Intrest rate` int(4) NOT NULL,
  `Creation date` date NOT NULL,
  `User ID` varchar(15) NOT NULL COMMENT 'secondary key, from login'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `account details`
--

INSERT INTO `account details` (`Account number`, `Account ballance`, `Intrest rate`, `Creation date`, `User ID`) VALUES
(13431251, '537.12', 2, '2019-06-14', 'leis29fs0e6cs8w'),
(17771154, '527.75', 2, '2019-04-17', 'p2cufy20s1ax83d'),
(42485713, '967.99', 2, '2019-03-17', 'spef734csp9t2x1'),
(60291917, '714.82', 2, '2019-02-13', 'si3lc9s72ecf01s'),
(62517741, '645.32', 2, '2019-04-10', 'lex92sp5c2fls1e'),
(70697660, '1000.00', 2, '2019-06-12', 'ldjeic92cspg83z'),
(82195367, '1000.00', 2, '2019-06-24', 'jiswcrsop2n54e1'),
(427887463, '654.48', 2, '2019-06-10', 'kel25s89ciel0s4'),
(671873149, '231.56', 2, '2019-06-01', 'keic2l5c9s1pw03'),
(775220095, '10000.00', 5, '2019-01-01', 'hsix3g8s0h1hlz5'),
(999999999, '99999999.99', 0, '1970-01-01', 'NBE main');

-- --------------------------------------------------------

--
-- Table structure for table `completed transactions`
--

CREATE TABLE `completed transactions` (
  `Transaction number` int(15) NOT NULL,
  `User ID` varchar(15) NOT NULL COMMENT 'Foreign key',
  `Date/time` date NOT NULL,
  `Value` int(10) NOT NULL,
  `Origin account` varchar(15) NOT NULL,
  `Target account` varchar(15) NOT NULL,
  `Completed successfully` text NOT NULL,
  `Flag type ID` varchar(5) DEFAULT NULL,
  `Offer ID` int(5) DEFAULT NULL,
  `Comment` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `completed transactions`
--

INSERT INTO `completed transactions` (`Transaction number`, `User ID`, `Date/time`, `Value`, `Origin account`, `Target account`, `Completed successfully`, `Flag type ID`, `Offer ID`, `Comment`) VALUES
(1, 'NBE main', '1970-01-01', 999999999, '0', '999999999', 'Completed successfully ', NULL, NULL, 'Inital setup up grant, from HMRC');

-- --------------------------------------------------------

--
-- Table structure for table `held transactions`
--

CREATE TABLE `held transactions` (
  `Transaction number` int(15) NOT NULL,
  `Date held` date NOT NULL,
  `Reason for hold` varchar(45) NOT NULL,
  `Origin account` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `login details`
--

CREATE TABLE `login details` (
  `User ID` varchar(15) NOT NULL,
  `User name` varchar(25) NOT NULL,
  `Password` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `login details`
--

INSERT INTO `login details` (`User ID`, `User name`, `Password`) VALUES
('hsix3g8s0h1hlz5', 'Cameron Hillier', 'apples'),
('jiswcrsop2n54e1', 'Steve Mcperson', 'something'),
('keic2l5c9s1pw03', 'Giorgio Walton', 'indult'),
('kel25s89ciel0s4', 'Nichola Hayward', 'floriform'),
('ldjeic92cspg83z', 'Bryson Crawford', 'phthartic'),
('leis29fs0e6cs8w', 'Shanaya Bourne', 'janizary'),
('lex92sp5c2fls1e', 'Alana Jordan', 'virage'),
('NBE main', 'Bank main', 'Access'),
('p2cufy20s1ax83d', 'Damian Hopper', 'veracious'),
('si3lc9s72ecf01s', 'Raees Thomson', 'esclandre'),
('spef734csp9t2x1', 'Abdur Pennington', 'angelolatry');

-- --------------------------------------------------------

--
-- Table structure for table `offers`
--

CREATE TABLE `offers` (
  `Offer ID` int(5) NOT NULL,
  `Description` varchar(50) NOT NULL,
  `Effect` varchar(20) NOT NULL COMMENT 'The method to call',
  `Expiry Date` date DEFAULT NULL,
  `Offer name` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `offers`
--

INSERT INTO `offers` (`Offer ID`, `Description`, `Effect`, `Expiry Date`, `Offer name`) VALUES
(1, 'Makes everything free', 'Debug_free', NULL, 'Debug free'),
(2, 'Gives the user £10', 'Offer_£10_cash', '2020-01-01', '£10 cash'),
(3, 'gives the user 1% cashback', '1%_cashback', '2019-10-31', '1%cashback');

-- --------------------------------------------------------

--
-- Table structure for table `recurring/future transactions`
--

CREATE TABLE `recurring/future transactions` (
  `Transaction number` int(15) NOT NULL,
  `Value` int(10) NOT NULL,
  `Date due` date NOT NULL,
  `Frequency(days)` int(5) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user details`
--

CREATE TABLE `user details` (
  `User ID` varchar(15) NOT NULL COMMENT 'Foreign key',
  `User first name` varchar(20) NOT NULL,
  `User last name` varchar(20) NOT NULL,
  `User date of birth` date NOT NULL,
  `User address` varchar(30) NOT NULL,
  `User country` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user details`
--

INSERT INTO `user details` (`User ID`, `User first name`, `User last name`, `User date of birth`, `User address`, `User country`) VALUES
('hsix3g8s0h1hlz5', 'Cameron', 'Hillier', '1997-03-11', '3 Something road, Hampshire', 'England'),
('jiswcrsop2n54e1', 'Steve', 'Mcperson', '1989-04-02', '12 Place lane, Surry', 'England'),
('keic2l5c9s1pw03', 'Giorgio', 'Walton', '1974-10-17', '11 Place lane, Surry', 'England'),
('kel25s89ciel0s4', 'Nichola', 'Hayward', '1934-02-26', '7 Imaginary avenue, Cornwall', 'England'),
('ldjeic92cspg83z', 'Bryson', 'Crawford', '1982-09-16', '4 Fictional street, Angus', 'Scotland'),
('leis29fs0e6cs8w', 'Shanaya', 'Bourne', '1999-10-31', '2 Neverreal road, Fife', 'Scotland'),
('lex92sp5c2fls1e', 'Alana', 'Jordan', '2001-07-19', '5 Nota street, Cardiff', 'Wales'),
('p2cufy20s1ax83d', 'Damian', 'Hopper', '1992-06-12', '6 Fakestreet, Pembrokeshire', 'Wales'),
('si3lc9s72ecf01s', 'Raees', 'Thomson', '1983-12-05', '5 Makebelieve row, Tyrone', 'Northern Ireland'),
('spef734csp9t2x1', 'Abdur', 'Pennington', '1971-09-23', '7 Fake street, Armagh', 'Northern Ireland');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `account details`
--
ALTER TABLE `account details`
  ADD PRIMARY KEY (`Account number`),
  ADD UNIQUE KEY `User_id` (`User ID`);

--
-- Indexes for table `completed transactions`
--
ALTER TABLE `completed transactions`
  ADD PRIMARY KEY (`Transaction number`);

--
-- Indexes for table `login details`
--
ALTER TABLE `login details`
  ADD PRIMARY KEY (`User ID`),
  ADD UNIQUE KEY `User_ID` (`User ID`),
  ADD UNIQUE KEY `User name` (`User name`);

--
-- Indexes for table `offers`
--
ALTER TABLE `offers`
  ADD UNIQUE KEY `Offer ID` (`Offer ID`),
  ADD UNIQUE KEY `Offer name` (`Offer name`);

--
-- Indexes for table `recurring/future transactions`
--
ALTER TABLE `recurring/future transactions`
  ADD UNIQUE KEY `Transaction number` (`Transaction number`);

--
-- Indexes for table `user details`
--
ALTER TABLE `user details`
  ADD UNIQUE KEY `User ID` (`User ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `completed transactions`
--
ALTER TABLE `completed transactions`
  MODIFY `Transaction number` int(15) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
