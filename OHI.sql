-- phpMyAdmin SQL Dump
-- version 4.7.7
-- https://www.phpmyadmin.net/
--
-- Хост: 127.0.0.1:3306
-- Время создания: Ноя 18 2018 г., 06:18
-- Версия сервера: 5.6.38
-- Версия PHP: 5.5.38

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- База данных: `OHI`
--

-- --------------------------------------------------------

--
-- Структура таблицы `ohi`
--

CREATE TABLE `ohi` (
  `﻿IdQuestion` int(11) DEFAULT NULL,
  `RadioAnswer` text,
  `Answer` text
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Дамп данных таблицы `ohi`
--

INSERT INTO `ohi` (`﻿IdQuestion`, `RadioAnswer`, `Answer`) VALUES
(1, 'а', 'я не чувствую себя счастливым'),
(1, 'б', 'я чувствую себя довольно счастливым'),
(1, 'в', 'я очень счастлив'),
(1, 'г', 'я невероятно счастлив'),
(2, 'а', 'я смотрю в будущее без особого оптимизма'),
(2, 'б', 'я смотрю в будущее с оптимизмом'),
(2, 'в', 'мне кажется, будущее сулит мне много хорошего'),
(2, 'г', 'я чувствую, что будущее переполнено надеждами и перспективами'),
(3, 'а', 'ничто в моей жизни по-настоящему меня не удовлетворяет'),
(3, 'б', 'некоторые вещи в жизни меня удовлетворяют'),
(3, 'в', 'меня удовлетворяет многое в моей жизни'),
(3, 'г', 'я полностью удовлетворен всем в своей жизни'),
(4, 'а', 'я не ощущаю, что в жизни что-либо реально находится в моей власти'),
(4, 'б', 'я чувствую, что контролирую свою жизнь, по крайней мере — отчасти'),
(4, 'в', 'я чувствую, что в основном контролирую свою жизнь'),
(4, 'г', 'я чувствую, что целиком контролирую все стороны своей жизни'),
(5, 'а', 'я не ощущаю, что жизнь вознаграждает меня по заслугам'),
(5, 'б', 'я ощущаю, что в жизни мне воздается по заслугам'),
(5, 'в', 'я ощущаю, что жизнь щедро вознаграждает меня'),
(5, 'г', 'я ощущаю, что жизнь переполнена подарками'),
(6, 'а', 'я не испытываю никакой удовлетворенности жизнью'),
(6, 'б', 'я доволен тем, как я живу'),
(6, 'в', 'я очень доволен тем, как я живу'),
(6, 'г', 'я в восторге от своей жизни'),
(7, 'а', 'я никогда не могу повлиять на события в нужном мне направлении'),
(7, 'б', 'иногда я способен повлиять на события в нужном мне направлении'),
(7, 'в', 'я часто влияю на события в нужном мне направлении'),
(7, 'г', 'я всегда влияю на события в нужном мне направлении'),
(8, 'а', 'в жизни я просто выживаю'),
(8, 'б', 'жизнь — хорошая вещь'),
(8, 'в', 'жизнь — замечательная вещь'),
(8, 'г', 'я обожаю жизнь'),
(9, 'а', 'у меня потерян всякий интерес к другим людям'),
(9, 'б', 'другие люди интересны мне отчасти'),
(9, 'в', 'другие люди меня очень интересуют'),
(9, 'г', 'меня чрезвычайно интересуют другие люди'),
(10, 'а', 'мне трудно принимать решения'),
(10, 'б', 'я довольно легко принимаю некоторые решения'),
(10, 'в', 'мне довольно просто принимать большинство решений'),
(10, 'г', 'я с легкостью принимаю любые решения'),
(11, 'а', 'мне трудно приступить к какому-либо делу'),
(11, 'б', 'мне довольно просто что-либо начать'),
(11, 'в', 'я без труда принимаюсь за какое-либо дело'),
(11, 'г', 'я способен взяться за любое дело'),
(12, 'а', 'после сна я редко чувствую себя отдохнувшим'),
(12, 'б', 'иногда я просыпаюсь отдохнувшим'),
(12, 'в', 'после сна я обычно чувствую себя отдохнувшим'),
(12, 'г', 'я всегда просыпаюсь отдохнувшим'),
(13, 'а', 'я чувствую себя совершенно без сил'),
(13, 'б', 'я чувствую себя довольно энергичным'),
(13, 'в', 'я чувствую себя очень энергичным'),
(13, 'г', 'я чувствую, что энергия во мне бьет через край'),
(14, 'а', 'я не вижу в окружающих меня вещах особой красоты'),
(14, 'б', 'я нахожу красоту в некоторых вещах'),
(14, 'в', 'я нахожу красоту в большинстве вещей'),
(14, 'г', 'весь мир представляется мне прекрасным'),
(15, 'а', 'я не ощущаю себя сообразительным'),
(15, 'б', 'я чувствую, что отчасти сметлив'),
(15, 'в', 'я в значительной степени чувствую в себе живость ума'),
(15, 'г', 'я ощущаю, что мне присуща совершенная живость ума'),
(16, 'а', 'я не чувствую себя особенно здоровым'),
(16, 'б', 'я чувствую себя достаточно здоровым'),
(16, 'в', 'я чувствую себя совершенно здоровым'),
(16, 'г', 'я чувствую себя здоровым на 100%'),
(17, 'а', 'я не испытываю особо теплых чувств по отношению к другим'),
(17, 'б', 'я испытываю определенные теплые чувства по отношению к другим'),
(17, 'в', 'я испытываю очень теплые чувства по отношению к другим'),
(17, 'г', 'я люблю всех людей'),
(18, 'а', 'у меня практически нет счастливых воспоминаний'),
(18, 'б', 'у меня есть отдельные счастливые воспоминания'),
(18, 'в', 'большинство произошедших со мной событий представляются мне счастливыми'),
(18, 'г', 'все происшедшее кажется мне чрезвычайно счастливым'),
(19, 'а', 'я никогда не бываю в радостном или приподнятом настроении'),
(19, 'б', 'иногда я испытываю радость и пребываю в приподнятом настроении'),
(19, 'в', 'я часто испытываю радость и пребываю в приподнятом настроении'),
(19, 'г', 'я все время радуюсь и пребываю в приподнятом настроении'),
(20, 'а', 'между тем, что я хотел бы сделать, и тем, что сделал, — большая разница'),
(20, 'б', 'кое-что из желаемого я сделал'),
(20, 'в', 'я сделал многое из того, что хотел'),
(20, 'г', 'я сделал все, чего когда-либо желал'),
(21, 'а', 'я не способен хорошо организовать свое время'),
(21, 'б', 'я организую свое время достаточно хорошо'),
(21, 'в', 'я очень хорошо организую свое время'),
(21, 'г', 'мне удается успеть все, что я хочу сделать'),
(22, 'а', 'мне не бывает весело в компании других людей'),
(22, 'б', 'иногда мне бывает весело с другими людьми'),
(22, 'в', 'мне часто бывает весело с другими людьми'),
(22, 'г', 'мне всегда весело в окружении людей'),
(23, 'а', 'я никогда не подбадриваю окружающих'),
(23, 'б', 'иногда я подбадриваю окружающих'),
(23, 'в', 'я часто подбадриваю окружающих'),
(23, 'г', 'я всегда подбадриваю окружающих'),
(24, 'а', 'у меня нет ощущения осмысленности и цели в жизни'),
(24, 'б', 'у меня есть ощущение смысла и цели в жизни'),
(24, 'в', 'у меня ясное ощущение смысла и цели в жизни'),
(24, 'г', 'моя жизнь полна смысла и имеет цель'),
(25, 'а', 'я не ощущаю особой привязанности к другим и сопричастности'),
(25, 'б', 'иногда я ощущаю привязанность к людям и сопричастность'),
(25, 'в', 'я часто ощущаю привязанность и сопричастность'),
(25, 'г', 'я всегда ощущаю привязанность и сопричастность'),
(26, 'а', 'не думаю, что мир — это стоящее место'),
(26, 'б', 'думаю, что мир — довольно хорошее место'),
(26, 'в', 'думаю, что мир — это замечательное место'),
(26, 'г', 'по-моему, мир — это превосходное место'),
(27, 'а', 'я редко смеюсь'),
(27, 'б', 'я смеюсь довольно часто'),
(27, 'в', 'я много смеюсь'),
(27, 'г', 'я очень часто смеюсь'),
(28, 'а', 'я думаю, что выгляжу непривлекательно'),
(28, 'б', 'я думаю, что выгляжу довольно привлекательно'),
(28, 'в', 'я думаю, что выгляжу привлекательно'),
(28, 'г', 'я думаю, что выгляжу очень привлекательно'),
(29, 'а', 'я не нахожу вокруг ничего забавного и интересного'),
(29, 'б', 'некоторые вещи я нахожу забавными'),
(29, 'в', 'большинство вещей кажутся мне забавными'),
(29, 'г', 'мне все кажется забавным и интересным');
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
