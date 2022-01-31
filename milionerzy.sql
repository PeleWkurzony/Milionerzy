-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Jan 31, 2022 at 07:52 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `milionerzy`
--

-- --------------------------------------------------------

--
-- Table structure for table `milionerzy`
--

CREATE TABLE `milionerzy` (
  `ID` int(11) NOT NULL,
  `pytanie` text DEFAULT NULL,
  `poprawna` varchar(255) DEFAULT NULL,
  `npoprawna1` varchar(255) DEFAULT NULL,
  `npoprawna2` varchar(255) DEFAULT NULL,
  `npoprawna3` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `milionerzy`
--

INSERT INTO `milionerzy` (`ID`, `pytanie`, `poprawna`, `npoprawna1`, `npoprawna2`, `npoprawna3`) VALUES
(1, 'Polskim odpowiednikiem amerykańskiego baby shower jest:', 'bociankowe', 'prysznicowe', 'becikowe', '500+'),
(2, '\"Wątróbka z cebulką (...) jest zakąską doskonałą. Aby ją przyrządzić, należy kupić samochód i pędzić nim póty, aż się kogoś przejedzie\". To Lem i...', '\"Dyktanda, czyli...\"', '\"Solaris\"', '\"Szpital przemienienia\"', '\"Opowieści o pilocie Pirxie\"'),
(3, 'Ćmielów i Chodzież słyną z produkcji:', 'porcelany', 'wagonów kolejowych', 'samolotów', 'leczniczych wód'),
(4, 'Czego zakręcane wieczko ma taneczną nazwę?', 'słoika', 'trumienki', 'puderniczki', 'szkatułki'),
(5, 'Do sejmowej zamrażarki trafiają:', 'projekty niektórych ustaw', 'nachalni lobbyści', 'temperamentni posłowie', 'kibole'),
(6, 'Komu w 1917 roku Matka Boska przekazała trzy tajemnice fatimskie?', 'pastuszkom', 'skazańcom', 'hitlerowi', 'żołnierzom'),
(7, 'Czym była zielona książeczka, którą w 2001 roku zastąpiła szaro-różowa karta z poliwęglanu?', 'dowodem osobistym', 'książeczką oszczędnościową', 'książeczką zdrowia', 'prawem jazdy'),
(8, 'Jaki ptak ma oczy osadzone frontalnie i otoczone promieniście ułożonymi piórami?', 'bogatka', 'płomykówka', 'dymówka', 'brzegówka'),
(9, 'Gwiazdy, które tworzą dyszel Wielkiego Wozu, są jednocześnie:', 'ogonem Wielkiej Niedźwiedzicy', 'kolcem Skorpiona', 'szyją Żyrafy\r\n', 'łapą Lwa'),
(10, 'Znajdź błąd.', 'handlarz starzyzny', 'handlarz narkotyków', 'handlarz złotem', 'handlarz żywym towarem'),
(11, 'Tempura to panierowane i smażone na głębokim oleju ryby, krewetki, kalmary, małże. Skąd w XVI wieku przywędrowała do Japonii?', 'z Portugalii', 'z Holandii', 'z Rosji', 'z Chin'),
(12, 'Nutrikosmetyki:', 'zażywamy doustnie', 'wczesujemy we włosy', 'wklepujemy w twarz', 'wytwarza się z nutrii'),
(13, 'Migotka to:', 'trzecia powieka', 'kierunkowskaz', 'mama Muminka', 'prawa komora serca'),
(14, 'Półpasiec to krewny:\r\n', 'ospy wietrznej', 'całego paśca', 'czarnej ospy', 'żółtej febry'),
(15, 'Kość guziczna to końcowy odcinek:', 'kręgosłupa', 'strzałki', 'piszczeli', 'mostka'),
(16, 'Diuretyki to leki, po których najwięcej czasu spędzamy:', 'w toalecie', 'na siłowni', 'na haju', 'w sypialni'),
(17, 'Odczyn Biernackiego to wskaźnik:', 'opadania erytrocytów', 'przyrostu leukocytów', 'odrywania się limfocytów', 'wiązania się trombocytów'),
(18, 'Układ współczulny to inaczej:', 'sympatyczny', 'wylewny', 'kordialny', 'czuły'),
(19, 'Podczas nebulizacji lek podawany jest:', 'w postaci aerozolu', 'prosto do żyły', 'pod skórę', 'w formie czopków'),
(20, 'Kto właściwie może odczuć efekt nocebo:', 'hipochondrycy', 'nocne marki', 'szczęśliwe pary', 'noworodki'),
(21, 'Choroba łokcia dotycząca mięśni zginaczy, na którą cierpią dentyści, księgowi i informatycy, to tak zwany łokieć:', 'golfisty', 'pływaka', 'skoczka narciarskiego\r\n', 'kierowcy kabrioletu'),
(22, 'Diafragma to przysłona w aparacie fotograficznym i część ciała człowieka. Która?', 'przepona', 'błona dziewicza', 'powieka', 'opona mózgowa'),
(23, 'Jak najłatwiej zarazić się mononukleozą?', 'przez pocałunek', 'przez podanie ręki', 'jedząc zapiaszczone owoce', 'pijąc wodę z kranu'),
(24, 'Rodzaj ciała odpornościowego obecnego we krwi to:', 'aprobata albo biernik', 'pean albo celownik', 'komplement albo dopełniacz', 'duser albo mianownik'),
(25, 'Najwięcej żelaza w takiej samej ilości produktu jest:', 'w fasoli białej', 'w burakach', 'w szpinaku', 'w szczawiu'),
(26, 'Gdyby nie języczek podniebienny, połykane przez nas jedzenie:', 'wyszłoby nam nosem', 'trafiłoby do krtani', 'miałoby gorzki smak', 'trafiłoby do płuc'),
(27, 'Gdy Neil Armstron stanął na Księżycu, wypowiedział słynne zdanie. Co na Srebrnym Globie zrobił Alan Shepard?', 'Zagrał w golfa', 'Biegał z siatką na motyle', 'Zatańczył rock and rolla', 'Godzinę leżał krzyżem'),
(28, 'Co mieści Wielki Łuk Braterstwa w paryskiej dzielnicy La Defense, zwany dwudziestowieczną wersją Łuku Triumfalnego?', 'Biura ministerstwa ekologii', 'Szczątki Dinozaurów', 'Nic', 'Ziemię z pól bitewnych'),
(29, 'Kto jest twórcą logo zespołu Perfect?', 'Edward Lutczyn', 'Andrzej Mleczko', 'Marek Raczkowski', 'Henryk Sawka'),
(30, 'Na co reaguje nocyceptor?', 'Na bodźce uszkadzające tkanki', 'Na słodki smak', 'Na mroki nocy', 'Na podczerwień małej mocy'),
(31, 'Z czego odlane są złote medale olimpijskie?\r\n', 'Ze srebra', 'Z żeliwa', 'Z brązu', 'Ze złota'),
(32, 'W 1971 r. psycholog Philip Zimbardo przeprowadził eksperyment symulujący:', 'życie w więzieniu', 'odbijanie zakładników', 'życie rozbitków na wyspie', 'przebywanie w kosmosie'),
(33, 'Starte ziemniaki i mąka to w zasadzie wszystko, czego potrzebujemy na tak zwane kluski:\r\n', 'żelazne', 'papierowe', 'plastikowe', 'szklane'),
(34, 'Z czego w głównej mierze zrobione są tak zwane monety bulionowe?\r\n', 'ze złota', 'z miedzi', 'ze zrolowanego mięsa', 'z pasty rosołowej'),
(35, 'Pod jaki zabór trafił Białystok w 1795 r., jeśli trafił?\r\n', 'pod pruski', 'pod rosyjski', 'pod austriacki', 'nie trafił pod żaden'),
(36, 'Co miał wspólnego Jan Marcin Szancer z Krasickim, Mickiewiczem i Sienkiewiczem?', 'to ilustrator ich dzieł', 'był ich ulubieńcem', 'był gejem', 'nic'),
(37, 'Jednostka miary reaktywności reaktora jądrowego to:', 'dolar', 'złoty', 'euro', 'rubel'),
(38, 'Kto składa zeznanie podatkowe na druku PIT-19A?', 'duchowni', 'nauczyciele', 'rolnicy', 'więźniowie'),
(39, 'W mózgu istota szara, tworząc korę mózgu, otacza istotę białą. W rdzeniu kręgowym jest...', 'odwrotnie', 'tak samo', 'tylko istota szara', 'tylko istota biała'),
(40, 'Najwyższy budynek świata Burdż Chalifa zwieńczony jest tym samym elementem architektonicznym, co...', 'PKiN', 'Krzywa Wieża w Pizie', 'Opera w Sydney', 'Statua Wolności'),
(41, 'Krzysztof Komeda skomponował muzykę do wszystkich tych filmów, ale jeden z nich wyreżyserował kto inny niż pozostałe. Który?', '\"Niewinni czarodzieje\"', '\"Nóż w wodzie\"', '\"Dziecko Rosemary\"', '\"Matnia\"'),
(42, 'Muzykę skomponowaną przez Krzysztofa Pendereckiego usłyszymy we wszystkich tych filmach. Ale specjalnie stworzył ją do:', '\"Rękopisu znalezionego\" Hasa', '\"Wyspy tajemnic\" Scorsesego', '\"Egzorcysty\" Friedkina', '\"Blok Ekipa\" Walaszka'),
(43, 'Za 30 Judaszowych srebrników arcykapłani kupili kawałek ziemi nazywany Polem Garncarza, który przeznaczyli na:', 'cmentarz dla cudzoziemców', 'plantację oliwek', 'wybieg dla lwów', 'targowisko'),
(44, 'W oryginalnej trylogii \"Gwiezdne wojny\" 3-CPO ma srebrną:\r\n', 'prawą nogę', 'klatkę piersiowa', 'szczękę', 'lewą dłoń'),
(45, 'Kto jest autorem słów: \"Jeśli kto przychodzi do mnie, a nie ma w nienawiści swego ojca i matki, żony i dzieci, braci i sióstr, nadto i siebie samego, nie może być moim uczniem\"', 'Jezus Chrystus', 'Allah', 'Mojżesz', 'Budda'),
(46, 'Który aktor podbija muzyczną scenę rock and rollem bez przebaczenia?', 'Arkadiusz Jakubik', 'Bartłomiej Topa', 'Marian Dziędziel', 'Young Leosia'),
(47, 'Kiedy rozpoczęło się drugie tysiąclecie?', '1 stycznia 1001 r.', '1 stycznia 1000 r.', '1 stycznia 2001 r.', '1 stycznia 2000 r.'),
(48, 'Który instrument stroi muzyk?', 'kocioł', 'okarynę', 'tamburyn', 'czynele'),
(49, 'Z gry na jakim instrumencie słynie Czesław Mozil?', 'na akordeonie', 'na kornecie', 'na djembe', 'na ksylofonie'),
(50, 'Ile to jest 1111 razy 1111, jeśli 1 razy 1 to 1, a 11 razy 11 to 121?', '1 234 321', '12321', '111 111 111', '123 434 321'),
(51, 'Kto jest mistrzem tego samego oręża, w jakim specjalizowała się mitologiczna Artemida?', 'Legolas', 'Robert Lewandowski', 'Zorro', 'Don Kichot'),
(52, 'Komiksowym \"dzieckiem\" rysownika Boba Kane\'a jest:\r\n', 'Batman', 'Superman', 'Captain America', 'Spider-Man'),
(53, 'Skąd pochodził Conan Barbarzyńca?', 'z Cimmerii', 'z Mordoru', 'z Bydgoszczy', 'z Oz'),
(54, 'Co według Leszka Kołakowskiego jest sklepieniem domu, w którym duch ludzki mieszka?\r\n', 'Czas', 'Miłość', 'Bóg', 'Rozum'),
(55, 'Który aktor urodził się w roku opatentowania kinematografu braci Lumière?', 'Rudolph Valentino', 'Humphrey Bogart', 'Fred Astaire', 'Charlie Chaplin'),
(56, 'Mowa w obronie poety Archiasza przeszła do historii jako jeden z najświetniejszych popisów retorycznych:', 'Cycerona', 'Demostenesa', 'Kwintyliana', 'Izokratesa'),
(57, 'Likier maraskino produkuje się z maraski, czyli odmiany:\r\n', 'wiśni', 'jabłoni', 'figi', 'gruszy'),
(58, 'Który utwór Juliusza Słowackiego napisany jest prozą?\r\n', '\"Anhelli\"', '\"Godzina myśli\"', '\"W Szwajcarii\"', '\"Arab\"'),
(59, 'Który ssak się nie spoci?', 'Królik', 'Człowiek', 'Koń', 'Owca'),
(60, 'I ostatnie pytanie, dzięki któremu w 2019 r. po raz trzeci wygrano milion złotych. Różańcową tajemnicą chwalebną nie jest...', 'Śmierć Jezusa na krzyżu', 'Zmartwychwstanie Jezusa', 'Wniebowzięcie Matki Bożej', 'Zesłanie Ducha Świętego');

-- --------------------------------------------------------

--
-- Table structure for table `ranking`
--

CREATE TABLE `ranking` (
  `id_rankingu` int(11) NOT NULL,
  `nazwa` text DEFAULT NULL,
  `czas_rozgrywki` int(11) DEFAULT NULL,
  `ID` int(11) DEFAULT NULL,
  `wybrana_odp` varchar(255) DEFAULT NULL,
  `ilosc_dobrych_odp` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `ranking`
--

INSERT INTO `ranking` (`id_rankingu`, `nazwa`, `czas_rozgrywki`, `ID`, `wybrana_odp`, `ilosc_dobrych_odp`) VALUES
(19, 'Pele', 216, 35, 'pod rosyjski', 14),
(26, 'fdghh', 3, 49, 'na djembe', 0),
(27, 'fdgh', 10, 15, 'mostka', 1),
(28, 'xzcf', 18, 50, '111 111 111', 2),
(30, 'fgh', 12, 44, 'lewą dłoń', 1),
(31, 'fdhgj', 4, 1, 'becikowe', 0),
(32, 'efg', 20, 55, 'Charlie Chaplin', 0),
(33, 'rtf', 20, 11, 'z Chin', 1),
(34, 'Pele', 27, 60, 'Zesłanie Ducha Świętego', 1),
(35, 'Lepe', 16, 24, 'duser albo mianownik', 0),
(36, 'Lepe', 13, 19, 'prosto do żyły', 0),
(37, 'Pele', 7, 9, 'łapą Lwa', 0);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `milionerzy`
--
ALTER TABLE `milionerzy`
  ADD PRIMARY KEY (`ID`);

--
-- Indexes for table `ranking`
--
ALTER TABLE `ranking`
  ADD PRIMARY KEY (`id_rankingu`),
  ADD KEY `id_milionerzy` (`ID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `milionerzy`
--
ALTER TABLE `milionerzy`
  MODIFY `ID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=61;

--
-- AUTO_INCREMENT for table `ranking`
--
ALTER TABLE `ranking`
  MODIFY `id_rankingu` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=38;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `ranking`
--
ALTER TABLE `ranking`
  ADD CONSTRAINT `id_milionerzy` FOREIGN KEY (`ID`) REFERENCES `milionerzy` (`ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
