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
-- Database: `c#quizdb`
--

-- --------------------------------------------------------

--
-- Table structure for table `question_table`
--

CREATE TABLE `question_table` (
  `Question number` int(2) NOT NULL,
  `Correct answer` int(1) NOT NULL,
  `Question text` varchar(75) NOT NULL,
  `Option1` varchar(30) NOT NULL,
  `Option 2` varchar(30) NOT NULL,
  `Option 3` varchar(30) NOT NULL,
  `Option 4` varchar(30) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `question_table`
--

INSERT INTO `question_table` (`Question number`, `Correct answer`, `Question text`, `Option1`, `Option 2`, `Option 3`, `Option 4`) VALUES
(1, 2, 'In what year was the first James Bond movie (Dr.No) released?', '1960', '1962', '1965', '1967'),
(2, 4, 'What is the highest grossing movie ever? (as of January 2019) ', 'Titanic', 'Star Wars: The Force Awakens', 'Avengers: Infinity War', 'Avatar'),
(3, 3, 'For which movie did leonardo dicaprio win his 1st Oscar? ', 'Inception', 'Titanic', 'The Revenanat', 'The Wolf of Wall Street'),
(4, 1, 'How old was Alfred Hitchcock when his final movie was released? ', '77', '80', '65', '75'),
(5, 2, 'In what year was the first Star Wars movie released? ', '1975', '1977', '1978', '1972'),
(6, 4, 'Which of the following movies was released first?', 'Inception', 'The Bourne Ultimatum', 'The Dark Knight', 'Casino Royale'),
(7, 2, 'Who has earned the most Academy awards?', 'Alfred Hitchcock', 'Walt Disney', 'Steven Spielberg', 'Meryl Streep'),
(8, 3, 'Which movie has won the largest sweep at the Oscars (% of nominations won)?', 'Ben-Hur', 'La La Land', 'LOTR: The Return of the King', 'All About Eve'),
(9, 1, 'What was the highest grossing film of 2018?', 'Avengers: Infinity War', 'Black Panther', 'Jurassic World: Fallen Kingdom', 'Bohemian Rhapsody'),
(10, 3, 'How long, in minutes, was the longest film to get a theatrical release?', '807', '924', '873', '899');

-- --------------------------------------------------------

--
-- Table structure for table `results_table`
--

CREATE TABLE `results_table` (
  `User_ID` int(11) NOT NULL,
  `Score` int(11) NOT NULL,
  `Grade` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `user_table`
--

CREATE TABLE `user_table` (
  `User_ID` int(4) NOT NULL,
  `User_1st_name` varchar(15) NOT NULL,
  `User_last_name` varchar(20) NOT NULL,
  `Password` varchar(15) NOT NULL,
  `Admin_status` tinyint(1) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_table`
--

INSERT INTO `user_table` (`User_ID`, `User_1st_name`, `User_last_name`, `Password`, `Admin_status`) VALUES
(1, 'John', 'Smith', 'mrsmith', 0),
(5678, 'Admin', 'Admin', 'admin', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `question_table`
--
ALTER TABLE `question_table`
  ADD PRIMARY KEY (`Question number`);

--
-- Indexes for table `user_table`
--
ALTER TABLE `user_table`
  ADD PRIMARY KEY (`User_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
