-- phpMyAdmin SQL Dump
-- version 5.2.0
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Янв 16 2024 г., 08:45
-- Версия сервера: 8.0.30
-- Версия PHP: 7.2.34

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `cabinetequipment`
--

-- --------------------------------------------------------

--
-- Структура таблицы `componenteymk`
--

CREATE TABLE `componenteymk` (
  `id` int NOT NULL,
  `type` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `title` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `content` text CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `componenteymk`
--

INSERT INTO `componenteymk` (`id`, `type`, `title`, `content`) VALUES
(1, 'Лабораторная работа', 'Лабораторная работа №2', 'Что-то умное.'),
(2, 'Практическая работа', 'Практическая работа №1', 'Что-то умное.'),
(3, 'Лабораторная работа', 'Лабораторная работа №4', 'Что-то умное.');

-- --------------------------------------------------------

--
-- Структура таблицы `compoundeymk`
--

CREATE TABLE `compoundeymk` (
  `id` int NOT NULL,
  `idEYMK` int DEFAULT NULL,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `compoundeymk`
--

INSERT INTO `compoundeymk` (`id`, `idEYMK`, `name`) VALUES
(1, 3, 'Теоритический'),
(2, 2, 'Теоритический'),
(3, 1, 'Практический');

-- --------------------------------------------------------

--
-- Структура таблицы `discipline`
--

CREATE TABLE `discipline` (
  `id` int NOT NULL,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `CK` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `discipline`
--

INSERT INTO `discipline` (`id`, `name`, `CK`) VALUES
(2, 'БДиСУБД', 'Программное обеспечение информационных технологий'),
(3, 'ССП', 'Программное обеспечение информационных технологий');

-- --------------------------------------------------------

--
-- Структура таблицы `equipment`
--

CREATE TABLE `equipment` (
  `id` int NOT NULL,
  `idTypeEquipment` int DEFAULT NULL,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `count` int DEFAULT NULL,
  `idKabinet` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `equipment`
--

INSERT INTO `equipment` (`id`, `idTypeEquipment`, `name`, `count`, `idKabinet`) VALUES
(1, 3, 'Компьютеры', 10, 2),
(3, 2, 'Компьютеры', 10, 3);

-- --------------------------------------------------------

--
-- Структура таблицы `eymk`
--

CREATE TABLE `eymk` (
  `id` int NOT NULL,
  `idDiscipline` int DEFAULT NULL,
  `idTeacher` int DEFAULT NULL,
  `idComponentEYMK` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `eymk`
--

INSERT INTO `eymk` (`id`, `idDiscipline`, `idTeacher`, `idComponentEYMK`) VALUES
(1, 3, 3, 2),
(2, 2, 3, 3),
(3, 2, 2, 1),
(4, 2, 2, 1);

-- --------------------------------------------------------

--
-- Структура таблицы `kabinets`
--

CREATE TABLE `kabinets` (
  `id` int NOT NULL,
  `name` varchar(100) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `area` int DEFAULT NULL,
  `idTeacher` int DEFAULT NULL,
  `floor` int DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `kabinets`
--

INSERT INTO `kabinets` (`id`, `name`, `area`, `idTeacher`, `floor`) VALUES
(2, 'Ведение дипломного проектирования', 20, 2, 4),
(3, 'Сопровождение и управление базами данных', 45, 2, 4);

-- --------------------------------------------------------

--
-- Структура таблицы `teachers`
--

CREATE TABLE `teachers` (
  `id` int NOT NULL,
  `surname` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `patronymic` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `CK` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL,
  `numberPhone` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `teachers`
--

INSERT INTO `teachers` (`id`, `surname`, `name`, `patronymic`, `CK`, `numberPhone`) VALUES
(2, 'Цыганок', 'Ольга', 'Чеславовна', 'Правовые дисциплины', '234'),
(3, 'Янцевич', 'Людмила', 'Александровна', 'Экономика и логистика', '234');

-- --------------------------------------------------------

--
-- Структура таблицы `typeequipment`
--

CREATE TABLE `typeequipment` (
  `id` int NOT NULL,
  `name` varchar(50) CHARACTER SET utf8mb4 COLLATE utf8mb4_unicode_ci DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- Дамп данных таблицы `typeequipment`
--

INSERT INTO `typeequipment` (`id`, `name`) VALUES
(2, 'Техничекское средство обучения'),
(3, 'Электронные учебники');

--
-- Индексы сохранённых таблиц
--

--
-- Индексы таблицы `componenteymk`
--
ALTER TABLE `componenteymk`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `compoundeymk`
--
ALTER TABLE `compoundeymk`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idEYMK` (`idEYMK`);

--
-- Индексы таблицы `discipline`
--
ALTER TABLE `discipline`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `equipment`
--
ALTER TABLE `equipment`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idTypeEquipmant` (`idTypeEquipment`),
  ADD KEY `idKabinet` (`idKabinet`);

--
-- Индексы таблицы `eymk`
--
ALTER TABLE `eymk`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idDiscipline` (`idDiscipline`),
  ADD KEY `idTeacher` (`idTeacher`),
  ADD KEY `idComponentEYMK` (`idComponentEYMK`);

--
-- Индексы таблицы `kabinets`
--
ALTER TABLE `kabinets`
  ADD PRIMARY KEY (`id`),
  ADD KEY `idTeacher` (`idTeacher`);

--
-- Индексы таблицы `teachers`
--
ALTER TABLE `teachers`
  ADD PRIMARY KEY (`id`);

--
-- Индексы таблицы `typeequipment`
--
ALTER TABLE `typeequipment`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT для сохранённых таблиц
--

--
-- AUTO_INCREMENT для таблицы `componenteymk`
--
ALTER TABLE `componenteymk`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `compoundeymk`
--
ALTER TABLE `compoundeymk`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `discipline`
--
ALTER TABLE `discipline`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `equipment`
--
ALTER TABLE `equipment`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `eymk`
--
ALTER TABLE `eymk`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT для таблицы `kabinets`
--
ALTER TABLE `kabinets`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `teachers`
--
ALTER TABLE `teachers`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT для таблицы `typeequipment`
--
ALTER TABLE `typeequipment`
  MODIFY `id` int NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- Ограничения внешнего ключа сохраненных таблиц
--

--
-- Ограничения внешнего ключа таблицы `compoundeymk`
--
ALTER TABLE `compoundeymk`
  ADD CONSTRAINT `compoundeymk_ibfk_1` FOREIGN KEY (`idEYMK`) REFERENCES `eymk` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `equipment`
--
ALTER TABLE `equipment`
  ADD CONSTRAINT `equipment_ibfk_1` FOREIGN KEY (`idTypeEquipment`) REFERENCES `typeequipment` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `equipment_ibfk_2` FOREIGN KEY (`idKabinet`) REFERENCES `kabinets` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `eymk`
--
ALTER TABLE `eymk`
  ADD CONSTRAINT `eymk_ibfk_1` FOREIGN KEY (`idDiscipline`) REFERENCES `discipline` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `eymk_ibfk_2` FOREIGN KEY (`idTeacher`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `eymk_ibfk_3` FOREIGN KEY (`idComponentEYMK`) REFERENCES `componenteymk` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Ограничения внешнего ключа таблицы `kabinets`
--
ALTER TABLE `kabinets`
  ADD CONSTRAINT `kabinets_ibfk_1` FOREIGN KEY (`idTeacher`) REFERENCES `teachers` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
