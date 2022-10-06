
SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;


CREATE TABLE IF NOT EXISTS `appointment` (
  `appointment_id` int(11) NOT NULL auto_increment,
  `user_id` int(11) NOT NULL,
  `barber_id` int(11) NOT NULL,
  `date_slot` date NOT NULL,
  `time_slot` time NOT NULL,
  PRIMARY KEY  (`appointment_id`),
  KEY `user_id` (`user_id`),
  KEY `barber_id` (`barber_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=13 ;

--
-- Dumping data for table `appointment`
--

INSERT INTO `appointment` (`appointment_id`, `user_id`, `barber_id`, `date_slot`, `time_slot`) VALUES
(5, 1, 5, '2015-05-08', '16:00:00'),
(3, 1, 3, '2015-05-02', '14:00:00'),
(6, 1, 2, '2015-05-10', '15:00:00'),
(7, 3, 2, '2015-05-08', '17:00:00'),
(8, 3, 2, '2015-05-09', '12:00:00'),
(9, 1, 3, '2015-05-16', '11:00:00');

-- --------------------------------------------------------
--
-- Table structure for table `barber`
--

CREATE TABLE IF NOT EXISTS `barber` (
  `barber_id` int(11) NOT NULL auto_increment,
  `name` varchar(32) NOT NULL,
  `available` tinyint(2) NOT NULL default '1',
  PRIMARY KEY  (`barber_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `barber`
--

INSERT INTO `barber` (`barber_id`, `name`, `available`) VALUES
(1, 'Clive', 1),
(2, 'Janice', 1),
(3, 'TJ', 1),
(4, 'Dany', 0);
-- --------------------------------------------------------
--
-- Table structure for table `behaviour`
--

--
-- Dumping data for table `behaviour`
--

-- --------------------------------------------------------

/*
INSERT INTO `teacher` (`teacher_id`, `username`, `password`, `title`, `firstname`, `surname`, `class_name`, `year_group`) VALUES
(1, 'newuser', '02c593fd9af8254b859d426a76b6cd42847fbec1', 'Mr', 'New', 'User', '3XY', 3),
(2, 'Ogbenga', 'f16ca2dfa3688bf08c7a4e21544af15bd598cb70', 'mr', 'Gbenga', 'Ogunduyile', '4GO', 4),
(3, 'Hdebbie1', '67fab92a16d6246960fc2d976e22c426730a2abf', 'mrs', 'Debbie', 'Harrison', '5DH', 5),
(4, 'Nemil99', 'ab136697f8f6577d82e3cd5077effd5d23b199fa', 'Mr', 'Emil', 'Naydenov', '6EN', 6);

-- --------------------------------------------------------
*/
--
-- Table structure for table `user`
--

CREATE TABLE IF NOT EXISTS `user` (
  `user_id` int(11) NOT NULL auto_increment,
  `firstname` varchar(32) NOT NULL,
  `surname` varchar(32) NOT NULL,
  `mobile` varchar(11) NOT NULL,
  `email` varchar(40) default NULL,
  `username` varchar(32) NOT NULL,
  `password` varchar(40) NOT NULL,
  `admin_status` tinyint(4) NOT NULL default '0',
  PRIMARY KEY  (`user_id`)
) ENGINE=MyISAM  DEFAULT CHARSET=latin1 AUTO_INCREMENT=8 ;

--
-- Dumping data for table `user`
--

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
