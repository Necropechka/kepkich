using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = Encoding.UTF8;
        Unpack();
        loading();
        Console.Clear();
        onstart();
        baskov();
    }
    static void baskov()
    {
        string kol = "1";
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string desktopPat = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string filePath = Path.Combine(desktopPath, "reproxyset", "proxy.txt");
        string filePat = Path.Combine(desktopPat, "reproxyset", "botz.txt");
        string filebotc = Path.Combine(desktopPat, "reproxyset", "kolbocheck.txt");
        string h;
        int m = 0;
        string l;
        int k = 1;
        int count = 0;
        int rok = 10;
        while (rok != 0)
        {
            Console.WriteLine("Введите 1, чтобы перейти к настройке ботов или 2, чтобы настроить программу автоматически: ");
            int ror = Convert.ToInt32(Console.ReadLine());
            if (ror == 1)
            {

                Console.Clear();
                while (k != 0)
                {
                    string fileContent = File.ReadAllText(filebotc);
                    int.TryParse(fileContent, out int yu);
                    count = yu;
                    Console.WriteLine("Введите 1, чтобы записать новые прокси, 2, чтобы изменить адреса ботов вручную, 3, чтобы изменить количество ботов в программе. Чтобы добавить новых ботов, введите 4. Если хотите завершить работу, введите 0: ");
                    int zap = Convert.ToInt32(Console.ReadLine());
                    if (zap == 1)
                    {
                        using (StreamWriter writer = new StreamWriter(filePath)) { }
                        Console.Write($"Введите тип прокси (ipv4/ipv6): ");
                        string IPV = Console.ReadLine();
                        string ipv = IPV.ToLower();
                        if (ipv == "ipv4" || ipv == "ipv 4")
                        {
                            for (int i = 0; i < count; i++)
                            {

                                Console.Write($"Введите прокси {i + 1}: ");
                                h = Console.ReadLine();
                                using (StreamWriter sw = File.AppendText(filePath))
                                    sw.Write(h + " ");
                                //выставляет введенные прокси через пробел в папке Path
                            }
                            for (int w = 0; w < count; w++)
                            {
                                string text = File.ReadAllText(filePat);
                                string adress = ExtractFirstWord(text, m);
                                // Укажите путь к исходному файлу
                                string sourceFilePath = filePath;
                                string destinationFilePath = adress;

                                // Чтение слов из исходного файла
                                string[] words = File.ReadAllText(sourceFilePath).Split('!');

                                // Запись слов в целевой файл
                                using (StreamWriter sw = new StreamWriter(destinationFilePath))

                                {
                                    foreach (string word in words)
                                    {
                                        sw.WriteLine(word);
                                    }
                                }
                                m++;
                                debug(adress);
                                debug(adress, count, m);
                            }
                            Console.Clear();
                            Console.WriteLine("Прокси записаны!");
                        }
                        else if (ipv == "ipv6" || ipv == "ipv 6")
                        {
                            for (int i = 0; i < count; i++)
                            {

                                Console.Write($"Введите прокси {i + 1}: ");
                                h = Console.ReadLine();
                                //модификация прокси
                                string originalString = h;
                                string modifiedString = originalString.Substring(7);
                                h = modifiedString;
                                originalString = h;
                                modifiedString = originalString + ":";
                                h = modifiedString;

                                int atIndex = h.IndexOf("@");
                                originalString = h;
                                modifiedString = originalString.Substring(atIndex + 1) + originalString.Substring(0, atIndex);
                                h = modifiedString;
                                //
                                using (StreamWriter sw = File.AppendText(filePath))
                                    sw.Write(h + "!");
                                //выставляет введенные прокси через пробел в папке Path
                            }
                            for (int w = 0; w < count; w++)
                            {
                                string text = File.ReadAllText(filePat);
                                string adress = ExtractFirstWord(text, m);
                                // Укажите путь к исходному файлу
                                string sourceFilePath = filePath;
                                string destinationFilePath = adress;

                                // Чтение слов из исходного файла
                                string[] words = File.ReadAllText(sourceFilePath).Split('!');

                                // Запись слов в целевой файл
                                using (StreamWriter sw = new StreamWriter(destinationFilePath))

                                {
                                    foreach (string word in words)
                                    {
                                        sw.WriteLine(word);
                                    }
                                }
                                m++;
                                debug(adress);
                                debug(adress, count, m);
                            }
                            Console.Clear();
                            Console.WriteLine("Прокси записаны!");
                        }
                    }
                    else if (zap == 2)
                    {
                        Console.Write("будете ли вы использовать функцию 'копировать как путь'? y/n:");
                        string yt = Console.ReadLine();
                        yt = yt.ToLower();
                        for (int i = 0; i < count; i++)
                        {
                            Console.Write($"Введите адрес бота {i + 1}: ");
                            l = Console.ReadLine();
                            if (yt == "y")
                            {
                                l = l.Substring(1, l.Length - 2);
                            }
                            using (StreamWriter sw = File.AppendText(filePat))
                                sw.Write(l + "!");
                        }
                        Console.Clear();
                        Console.WriteLine("Адреса ботов сохранены!");
                    }
                    else if (zap == 3)
                    {
                        // filebotc адрес
                        File.WriteAllText(filebotc, string.Empty);
                        Console.Write("Введите количество ботов в папке: ");
                        kol = Console.ReadLine();
                        using (StreamWriter sw = File.AppendText(filebotc))
                        {
                            sw.Write(kol);
                        }
                        Console.Clear();
                        Console.WriteLine("Количество ботов записано!");
                    }
                    else if (zap == 4)
                    {
                        string fi;
                        fi = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                        string musicFolderPath = Path.Combine(fi, "reproxyset");
                        Directory.CreateDirectory(musicFolderPath);
                        //coздание папки reproxy
                        string filePatg = Path.Combine(musicFolderPath, "softcopyinfo.txt");
                        if (new FileInfo(filePatg).Length <= 0)
                        {
                            Console.WriteLine("Пожалуйста, укажите путь к материнской папке с ботами: ");
                            string word = Console.ReadLine();
                            using (StreamWriter writer = new StreamWriter(filePatg, true))
                            {
                                writer.WriteLine(word);
                            }
                        }
                        Botz_create();
                    }
                    else if (zap == 0)
                    {
                        Environment.Exit(0);
                    }
                    else
                    {
                        Console.WriteLine("Введено некорректное число!");
                    }
                }
            }
            else if (ror == 2)
            {
                rebootfstadress();
            }
            else
            {
                Console.WriteLine("Введено некорректное число!");
            }
        }
    }
    static string ExtractFirstWord(string text, int m)
    {
        char[] separators = { '!' };
        string[] words = text.Split(separators, StringSplitOptions.RemoveEmptyEntries);
        // Возвращаем первое слово (если оно есть)
        return words.Length > 0 ? words[m] : "Текст не содержит слов.";
    }

    static void debug(string adress, int count, int m)
    {
        for (int i = 0; i < count; i++)
        {
            string filePath = adress;
            int h = m - 1;
            string content = File.ReadAllText(filePath);
            string[] words = content.Split(' ');
            if (h >= 0 && h < words.Length)
            {
                string selectedWord = words[h];
                string result = string.Join(" ", new[] { selectedWord });
                File.WriteAllText(filePath, result);
            }
            else
            {
            }
        }
    }
    static void debug(string adress)
    {
        // Чтение текста из файла
        string texo = File.ReadAllText(adress);
        // Замена символов новой строки на пробел
        texo = texo.Replace("\n", " ");
        // Запись измененного текста обратно в файл
        File.WriteAllText(adress, texo);

        // Чтение текста из файла
        string text = File.ReadAllText(adress);

        // Удаление символов новой строки
        text = text.Replace("\n", "").Replace("\r", "");

        // Запись изменений обратно в файл
        File.WriteAllText(adress, text);

    }


    static void rebootfstadress()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderPa = Path.Combine(desktopPath, "reproxyset");

        // Создать папку на рабочем столе
        Directory.CreateDirectory(folderPa);

        // Установить атрибуты папки, чтобы она была невидимой
        File.SetAttributes(folderPa, File.GetAttributes(folderPa) | FileAttributes.Hidden);

        string[] fileNamesToCheck = { "proxy.txt", "botz.txt", "kolbocheck.txt", "softcopyinfo.txt", "colnewbots.txt", "names.txt" };

        foreach (string fileName in fileNamesToCheck)
        {
            string filePath = Path.Combine(folderPa, fileName);

            Console.Clear();

            if (!File.Exists(filePath))
            {
                // Создание файла
                File.Create(filePath);
            }
            string file;
            file = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string namesfile1 = Path.Combine(file, "reproxyset");
            string filePen = Path.Combine(namesfile1, "names.txt");
            string content = "Августа\r\nАвгустина\r\nАвдотья\r\nАврелия\r\nАврея\r\nАврора\r\nАгапа\r\nАгапия\r\nАгарь\r\nАгата\r\nАгафа\r\nАгафия\r\nАгафоклия\r\nАгафоника\r\nАгафья\r\nАгита\r\nАглаида\r\nАглая\r\nАгна\r\nАгнесса\r\nАгния\r\nАграфена\r\nАгриппина\r\nАда\r\nАделаида\r\nАделина\r\nАделия\r\nАделла\r\nАдель\r\nАдельфина\r\nАдиля\r\nАдина\r\nАдолия\r\nАдриана\r\nАза\r\nАзалия\r\nАзелла\r\nАзиза\r\nАида\r\nАйжан\r\nАйта\r\nАкгюль\r\nАкилина\r\nАксиния\r\nАксинья\r\nАкулина\r\nАлана\r\nАлевтина\r\nАлександра\r\nАлександрина\r\nАлексина\r\nАлена\r\nАлеся\r\nАлешан\r\nАлёна\r\nАлико\r\nАлина\r\nАлиса\r\nАлла\r\nАлсу\r\nАлфея\r\nАльберта\r\nАльбертина\r\nАльбина\r\nАльвина\r\nАльжбета\r\nАльфия\r\nАльфреа\r\nАльфреда\r\nАмалия\r\nАмата\r\nАмелия\r\nАмелфа\r\nАмина\r\nАнабела\r\nАнастасия\r\nАнатолия\r\nАнгела\r\nАнгелика\r\nАнгелина\r\nАнджела\r\nАндрея\r\nАндрона\r\nАндроника\r\nАнжела\r\nАнжелика\r\nАнисия\r\nАнисья\r\nАнита\r\nАнна\r\nАнтигона\r\nАнтониана\r\nАнтонида\r\nАнтонина\r\nАнтония\r\nАнуш\r\nАнфима\r\nАнфиса\r\nАнфия\r\nАнфуса\r\nАнэля\r\nАполлинария\r\nАполлония\r\nАпраксин\r\nАпрелия\r\nАпфия\r\nАрабелла\r\nАргентея\r\nАриадна\r\nАрина\r\nАрия\r\nАрлета\r\nАрминия\r\nАрсения\r\nАртемида\r\nАртемия\r\nАрхелия\r\nАсия\r\nАста\r\nАстра\r\nАся\r\nАурелия\r\nАфанасия\r\nАэлита\r\nБабетта\r\nБагдагуль\r\nБарбара\r\nБеата\r\nБеатриса\r\nБелла\r\nБенедикта\r\nБереслава\r\nБернадетта\r\nБерта\r\nБибиана\r\nБиргит\r\nБирута\r\nБландина\r\nБланка\r\nБогдана\r\nБожена\r\nБолеслава\r\nБорислава\r\nБотогоз\r\nБояна\r\nБригитта\r\nБронислава\r\nБруна\r\nВаленсия\r\nВалентина\r\nВалерия\r\nВалида\r\nВалия\r\nВанда\r\nВарвара\r\nВаря\r\nВасёна\r\nВасила\r\nВасилида\r\nВасилина\r\nВасилиса\r\nВасилия\r\nВасилла\r\nВасса\r\nВацлава\r\nВевея\r\nВеджиха\r\nВелимира\r\nВелислава\r\nВенедикта\r\nВенера\r\nВенуста\r\nВенцеслава\r\nВера\r\nВербния\r\nВереника\r\nВероника\r\nВеселина\r\nВеста\r\nВестита\r\nВета\r\nВива\r\nВивея\r\nВивиана\r\nВида\r\nВидина\r\nВикентия\r\nВиктбрия\r\nВикторина\r\nВиктория\r\nВила\r\nВилена\r\nВиленина\r\nВилора\r\nВильгельмина\r\nВиолетта\r\nВиргиния\r\nВиринея\r\nВита\r\nВиталика\r\nВиталина\r\nВиталия\r\nВитольда\r\nВлада\r\nВладилена\r\nВладимира\r\nВладислава\r\nВладлена\r\nВоислава\r\nВоля\r\nВсеслава\r\nГабриэлла\r\nГаджимет\r\nГазама\r\nГала\r\nГалата\r\nГалатея\r\nГали\r\nГалима\r\nГалина\r\nГалла\r\nГаля\r\nГая\r\nГаянэ\r\nГеласия\r\nГелена\r\nГелла\r\nГемелла\r\nГемина\r\nГения\r\nГеннадия\r\nГеновефа\r\nГенриетта\r\nГеоргина\r\nГера\r\nГермана\r\nГертруда\r\nГея\r\nГизелла\r\nГлафира\r\nГликерия\r\nГлорибза\r\nГлория\r\nГолиндуха\r\nГольпира\r\nГонеста\r\nГонората\r\nГоргония\r\nГорислава\r\nГортензия\r\nГрадислава\r\nГражина\r\nГрета\r\nГулара\r\nГульмира\r\nГульназ\r\nГульнара\r\nГюзель\r\nДайна\r\nДалила\r\nДалия\r\nДамира\r\nДана\r\nДаная\r\nДаниэла\r\nДанута\r\nДариа\r\nДарина\r\nДария\r\nДарья\r\nДастагуль\r\nДебора\r\nДеена\r\nДекабрена\r\nДенесия\r\nДенница\r\nДея\r\nДжамиля\r\nДжана\r\nДжафара\r\nДжемма\r\nДжулия\r\nДжульетта\r\nДиана\r\nДигна\r\nДиля\r\nДиляра\r\nДина\r\nДинара\r\nДиодора\r\nДионина\r\nДионисия\r\nДия\r\nДоброгнева\r\nДобромила\r\nДобромира\r\nДоброслава\r\nДоля\r\nДоминика\r\nДомитилла\r\nДомна\r\nДомника\r\nДомникия\r\nДомнина\r\nДонара\r\nДоната\r\nДора\r\nДоротея\r\nДорофея\r\nДоса\r\nДосифея\r\nДросида\r\nДуклида\r\nЕва\r\nЕвангелина\r\nЕванфия\r\nЕвгения\r\nЕвдокия\r\nЕвдоксия\r\nЕвлалия\r\nЕвлампия\r\nЕвмения\r\nЕвминия\r\nЕвника\r\nЕвникия\r\nЕвномия\r\nЕвпраксия\r\nЕвсевия\r\nЕвстафия\r\nЕвстолия\r\nЕвтихия\r\nЕвтропия\r\nЕвфалия\r\nЕвфимия\r\nЕвфросиния\r\nЕкатерина\r\nЕлена\r\nЕлизавета\r\nЕликонида\r\nЕпистима\r\nЕпистимия\r\nЕрмиония\r\nЕсения\r\nЕфимия\r\nЕфимья\r\nЕфросиния\r\nЕфросинья\r\nЖанна\r\nЖеральдина\r\nЖозефина\r\nЗабава\r\nЗаира\r\nЗамира\r\nЗара\r\nЗарема\r\nЗари\r\nЗарина\r\nЗарифа\r\nЗвезда\r\nЗемфира\r\nЗенона\r\nЗина\r\nЗинаида\r\nЗинат\r\nЗиновия\r\nЗита\r\nЗлата\r\nЗоя\r\nЗульфия\r\nЗураб\r\nЗухра\r\nИва\r\nИванна\r\nИветта\r\nИвона\r\nИда\r\nИдея\r\nИзабелла\r\nИзида\r\nИзольда\r\nИлария\r\nИлзе\r\nИлия\r\nИлона\r\nИльина\r\nИльмира\r\nИнара\r\nИнга\r\nИнесса\r\nИнна\r\nИоанна\r\nИовилла\r\nИола\r\nИоланта\r\nИпполита\r\nИрада\r\nИраида\r\nИрена\r\nИрина\r\nИрма\r\nИсидора\r\nИфигения\r\nИюлия\r\nИя\r\nКаздоя\r\nКазимира\r\nКалерия\r\nКалида\r\nКалиса\r\nКаллиникия\r\nКаллиста\r\nКаллисфения\r\nКама\r\nКамила\r\nКамилла\r\nКандида\r\nКапитолина\r\nКарима\r\nКарина\r\nКаролина\r\nКасиния\r\nКатарина\r\nКелестина\r\nКеркира\r\nКетевань\r\nКикилия\r\nКима\r\nКира\r\nКириакия\r\nКириана\r\nКирилла\r\nКирьяна\r\nКлавдия\r\nКлара\r\nКлариса\r\nКлементина\r\nКлена\r\nКлеопатра\r\nКлиментина\r\nКлотильда\r\nКонкордия\r\nКонстанция\r\nКонсуэлла\r\nКора\r\nКорнелия\r\nКристина\r\nКсаверта\r\nКсанфиппа\r\nКсения\r\nКупава\r\nЛавиния\r\nЛавра\r\nЛада\r\nЛайма\r\nЛариса\r\nЛатафат\r\nЛаура\r\nЛебния\r\nЛеда\r\nЛейла\r\nЛемира\r\nЛенина\r\nЛеокадия\r\nЛеонида\r\nЛеонила\r\nЛеонина\r\nЛеонтина\r\nЛеся\r\nЛетиция\r\nЛея\r\nЛиана\r\nЛивия\r\nЛидия\r\nЛилиана\r\nЛилия\r\nЛина\r\nЛинда\r\nЛира\r\nЛия\r\nЛола\r\nЛолита\r\nЛонгина\r\nЛора\r\nЛота\r\nЛуиза\r\nЛукерья\r\nЛукиана\r\nЛукия\r\nЛукреция\r\nЛюбава\r\nЛюбовь\r\nЛюбомила\r\nЛюбомира\r\nЛюдмила\r\nЛюсьена\r\nЛюцина\r\nЛюция\r\nМавра\r\nМагда\r\nМагдалена\r\nМагдалина\r\nМагна\r\nМадина\r\nМадлена\r\nМаина\r\nМайда\r\nМайя\r\nМакрина\r\nМаксима\r\nМалания\r\nМалика\r\nМалина\r\nМалинья\r\nМальвина\r\nМамелфа\r\nМанана\r\nМанефа\r\nМануэла\r\nМаргарита\r\nМариам\r\nМариамна\r\nМариана\r\nМарианна\r\nМариетта\r\nМарина\r\nМаринэ\r\nМарионелла\r\nМарионилла\r\nМарица\r\nМариэтта\r\nМария\r\nМарка\r\nМаркеллина\r\nМаркиана\r\nМарксина\r\nМарлена\r\nМарселина\r\nМарта\r\nМартина\r\nМартиниана\r\nМарфа\r\nМарьина\r\nМарья\r\nМарьям\r\nМарьяна\r\nМастридия\r\nМатильда\r\nМатрёна\r\nМатрона\r\nМая\r\nМедея\r\nМелания\r\nМеланья\r\nМелитика\r\nМеркурия\r\nМерона\r\nМилана\r\nМилена\r\nМилица\r\nМилия\r\nМилослава\r\nМилютина\r\nМина\r\nМинна\r\nМинодора\r\nМира\r\nМирдза\r\nМиропия\r\nМирослава\r\nМирра\r\nМитродора\r\nМихайлина\r\nМихалина\r\nМлада\r\nМодеста\r\nМоика\r\nМоника\r\nМстислава\r\nМуза\r\nМэрилант\r\nНада\r\nНадежда\r\nНазира\r\nНаиля\r\nНаина\r\nНана\r\nНаркисса\r\nНастасия\r\nНастасья\r\nНаталия\r\nНаталья\r\nНателла\r\nНелли\r\nНенила\r\nНеонила\r\nНида\r\nНика\r\nНила\r\nНимфа\r\nНимфодора\r\nНина\r\nНинель\r\nНовелла\r\nНонна\r\nНора\r\nНоргул\r\nНоэми\r\nНоябрина\r\nНунехия\r\nОдетта\r\nОксана\r\nОктавия\r\nОктябрина\r\nОлдама\r\nОлеся\r\nОливия\r\nОлимпиада\r\nОлимпиодора\r\nОлимпия\r\nОльвия\r\nОльга\r\nОльда\r\nОфелия\r\nПавла\r\nПавлина\r\nПаисия\r\nПаллада\r\nПаллидия\r\nПальмира\r\nПамела\r\nПараскева\r\nПатрикия\r\nПатриция\r\nПаула\r\nПаулина\r\nПелагея\r\nПерегрина\r\nПерпетуя\r\nПетра\r\nПетрина\r\nПетронилла\r\nПетрония\r\nПиама\r\nПинна\r\nПлакида\r\nПлакилла\r\nПлатонида\r\nПобеда\r\nПолактия\r\nПоликсена\r\nПоликсения\r\nПолина\r\nПоплия\r\nПравдина\r\nПрасковья\r\nПрепедигна\r\nПрискилла\r\nПросдока\r\nПульхерия\r\nПульхерья\r\nРада\r\nРадана\r\nРадислава\r\nРадмила\r\nРадомира\r\nРадосвета\r\nРадослава\r\nРадость\r\nРаиса\r\nРафаила\r\nРахиль\r\nРашам\r\nРевекка\r\nРевмира\r\nРегина\r\nРезета\r\nРема\r\nРената\r\nРимма\r\nРипсимия\r\nРоберта\r\nРогнеда\r\nРоза\r\nРозалина\r\nРозалинда\r\nРозалия\r\nРозамунда\r\nРозина\r\nРозмари\r\nРоксана\r\nРомана\r\nРостислава\r\nРужена\r\nРузана\r\nРумия\r\nРусана\r\nРусина\r\nРуслана\r\nРуфина\r\nРуфиниана\r\nРуфь\r\nСабина\r\nСавватия\r\nСавелла\r\nСавина\r\nСаида\r\nСаломея\r\nСалтанат\r\nСамона\r\nСания\r\nСанта\r\nСарра\r\nСатира\r\nСветислава\r\nСветлана\r\nСветозара\r\nСвятослава\r\nСевастьяна\r\nСеверина\r\nСеклетея\r\nСеклетинья\r\nСелена\r\nСелестина\r\nСелина\r\nСерафима\r\nСибилла\r\nСильва\r\nСильвана\r\nСильвестра\r\nСильвия\r\nСима\r\nСимона\r\nСинклитикия\r\nСиотвия\r\nСира\r\nСлава\r\nСнандулия\r\nСнежана\r\nСозия\r\nСола\r\nСоломонида\r\nСосипатра\r\nСофия\r\nСофрония\r\nСофья\r\nСталина\r\nСтанислава\r\nСтелла\r\nСтепанида\r\nСтефанида\r\nСтефания\r\nСусанна\r\nСуфия\r\nСюзанна\r\nТавифа\r\nТаира\r\nТаисия\r\nТаисья\r\nТала\r\nТамара\r\nТарасия\r\nТатьяна\r\nТахмина\r\nТекуса\r\nТеодора\r\nТереза\r\nТигрия\r\nТина\r\nТихомира\r\nТихослава\r\nТома\r\nТомила\r\nТранквиллина\r\nТрифена\r\nТрофима\r\nУлдуза\r\nУлита\r\nУльяна\r\nУрбана\r\nУрсула\r\nУстина\r\nУстиния\r\nУстинья\r\nФабиана\r\nФавста\r\nФавстина\r\nФаиза\r\nФаина\r\nФанни\r\nФантика\r\nФаня\r\nФарида\r\nФатима\r\nФая\r\nФебния\r\nФеврония\r\nФевронья\r\nФедоза\r\nФедора\r\nФедосия\r\nФедосья\r\nФедотия\r\nФедотья\r\nФедула\r\nФекла\r\nФекуса\r\nФеликса\r\nФелица\r\nФелицата\r\nФелициана\r\nФелицитата\r\nФелиция\r\nФеогния\r\nФеодора\r\nФеодосия\r\nФеодота\r\nФеодотия\r\nФеодула\r\nФеодулия\r\nФеозва\r\nФеоктиста\r\nФеона\r\nФеонилла\r\nФеопистия\r\nФеосовия\r\nФеофания\r\nФеофила\r\nФервуфа\r\nФеруза\r\nФессалоника\r\nФессалоникия\r\nФетиния\r\nФетинья\r\nФея\r\nФёкла\r\nФива\r\nФивея\r\nФиларета\r\nФилиппа\r\nФилиппин\r\nФилиппина\r\nФиломена\r\nФилонилла\r\nФилофея\r\nФиста\r\nФлавия\r\nФлёна\r\nФлора\r\nФлорентина\r\nФлоренция\r\nФлориана\r\nФлорида\r\nФомаида\r\nФортуната\r\nФотина\r\nФотиния\r\nФотинья\r\nФрансуаза\r\nФранциска\r\nФранческа\r\nФредерика\r\nФрида\r\nФридерика\r\nХаврония\r\nХалима\r\nХариесса\r\nХариса\r\nХарита\r\nХаритина\r\nХильда\r\nХильдегарда\r\nХиония\r\nХриса\r\nХрисия\r\nХристиана\r\nХристина\r\nХристя\r\nЦвета\r\nЦветана\r\nЦелестина\r\nЦецилия\r\nЧеслава\r\nЧулпан\r\nШангуль\r\nШарлотта\r\nШирин\r\nШушаника\r\nЭвелина\r\nЭгина\r\nЭдда\r\nЭдит\r\nЭдита\r\nЭлахе\r\nЭлеонора\r\nЭлиана\r\nЭлиза\r\nЭлизабет\r\nЭлина\r\nЭлисса\r\nЭлла\r\nЭллада\r\nЭллина\r\nЭлоиза\r\nЭльвира\r\nЭльга\r\nЭльза\r\nЭльмира\r\nЭмилиана\r\nЭмилия\r\nЭмма\r\nЭннафа\r\nЭра\r\nЭрика\r\nЭрнеста\r\nЭрнестина\r\nЭсмеральда\r\nЭстер\r\nЭсфирь\r\nЮдита\r\nЮдифь\r\nЮзефа\r\nЮлдуз\r\nЮлиана\r\nЮлиания\r\nЮлия\r\nЮна\r\nЮния\r\nЮнона\r\nЮрия\r\nЮстина\r\nЮханна\r\nЯдвига\r\nЯна\r\nЯнина\r\nЯнита\r\nЯнка\r\nЯнсылу\r\nЯрослава";
            string filePatt = filePen;
            File.WriteAllText(filePatt, content);
            Console.WriteLine($"Files created.");
        }
        baskov();
    }
    
    static void onstart()
    {
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderPath = Path.Combine(desktop, "visual");
        string imageoutpaf = Path.Combine(folderPath, "output.jpg");
        string proxyFilePath = imageoutpaf;
        string proxyFileAddress = proxyFilePath;
        Bitmap image = new Bitmap(proxyFileAddress);
        int scale = 17;
        int width = 70;
        int height = 15;

        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < width; x++)
            {

                Color pixelColor = image.GetPixel(x * scale, y * scale);
                int grayValue = (int)(pixelColor.R * 0.3 + pixelColor.G * 0.59 + pixelColor.B * 0.12);
                char asciiChar = GetAsciiChar(grayValue);
                Console.Write(asciiChar);
            }
            Console.WriteLine();
        }
    }

    static char GetAsciiChar(int grayValue)
    {
        char[] asciiChars = { ' ', '.', ':', '-', '=', '+', '*', '#', '%', '8', '@' };
        int index = grayValue * (asciiChars.Length - 1) / 255;
        return asciiChars[index];
    }


    public static void DecryptTextToImage(string inputTextFile, string outputImagePath)
    {
        StreamReader reader = new StreamReader(inputTextFile);
        string base64String = reader.ReadLine();
        reader.Close();

        byte[] imageBytes = Convert.FromBase64String(base64String);
        MemoryStream memoryStream = new MemoryStream(imageBytes);
        Image image = Image.FromStream(memoryStream);
        image.Save(outputImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
    }

    public static void Unpack()
    {
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string hiddenFolderPath = Path.Combine(desktopPath, "visual");
        if (!File.Exists(hiddenFolderPath))
        {
            Directory.CreateDirectory(hiddenFolderPath);
            File.SetAttributes(hiddenFolderPath, File.GetAttributes(hiddenFolderPath) | FileAttributes.Hidden);
        }
        Maz();
        //formir papki
        // teper fail
        string desktop = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderPath = Path.Combine(desktop, "visual");
        string imageoutpaf = Path.Combine(folderPath, "output.jpg");
        string filePath = Path.Combine(folderPath, "tt.txt");
        string fileAddress = filePath;
        //puti failov
        string inputTextFile = fileAddress;

        string outputImagePath = imageoutpaf;
        // Расшифровать текстовый документ в изображение
        DecryptTextToImage(inputTextFile, outputImagePath);
    }

    static void Maz()
    {

        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string folderPath = Path.Combine(desktopPath, "visual");
        string filePath = Path.Combine(folderPath, "tt.txt");

        string text = "/9j/4AAQSkZJRgABAgEAYABgAAD/4QB2RXhpZgAATU0AKgAAAAgAAYdpAAQAAAABAAAAGgAAAAAAAZKGAAcAAABCAAAALAAAAABVTklDT0RFAABTAFkAUwBUAEUATQBBAFgAIABKAEYASQBGACAARQBuAGMAbwBkAGUAcgAgAFYAZQByAC4AMgAuADD/2wBDAAEBAQEBAQICAgICAgICAgICAgICAgMDAwMDAwMDAwMDAwMDAwQEBAQEBAQEBAQEBAQFBQUFBQUFBQUGBgYHBwf/2wBDAQMDAwMDAwQEBAQEBAQEBAUFBQUFBQcHBwcHBwcICAgICAgICAoKCgoKCgoLCwsLCwsNDQ0NDQ8PDw8PDw8PDw//wAARCAEJBQADAREAAhEBAxEB/8QAHwAAAQUBAQEBAQEAAAAAAAAAAAECAwQFBgcICQoL/8QAtRAAAgEDAwIEAwUFBAQAAAF9AQIDAAQRBRIhMUEGE1FhByJxFDKBkaEII0KxwRVS0fAkM2JyggkKFhcYGRolJicoKSo0NTY3ODk6Q0RFRkdISUpTVFVWV1hZWmNkZWZnaGlqc3R1dnd4eXqDhIWGh4iJipKTlJWWl5iZmqKjpKWmp6ipqrKztLW2t7i5usLDxMXGx8jJytLT1NXW19jZ2uHi4+Tl5ufo6erx8vP09fb3+Pn6/8QAHwEAAwEBAQEBAQEBAQAAAAAAAAECAwQFBgcICQoL/8QAtREAAgECBAQDBAcFBAQAAQJ3AAECAxEEBSExBhJBUQdhcRMiMoEIFEKRobHBCSMzUvAVYnLRChYkNOEl8RcYGRomJygpKjU2Nzg5OkNERUZHSElKU1RVVldYWVpjZGVmZ2hpanN0dXZ3eHl6goOEhYaHiImKkpOUlZaXmJmaoqOkpaanqKmqsrO0tba3uLm6wsPExcbHyMnK0tPU1dbX2Nna4uPk5ebn6Onq8vP09fb3+Pn6/90ABAKA/9oADAMBAAIRAxEAPwD/AD/6ACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgCxQA7v/AHqAG0ABPlqpVufagCNm3fxfgRQAR5LKPfpQBJQAUAFABQAUAFABQAUAR+X7/pQBHQAUAFABQAUAFABQAUAFABQAUAFABQAUASeU/pQBHQBJ5fv+lAB5fv8ApQAeX7/pQAbMdeKAJKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAK9ABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFAEynI9xwaAGiTb93ge9AEdABQAUAOVivIJ+lAC7z6CgBN7ev6UAG9vX9KADe3r+lABvb1/SgA3t6/pQAb29f0oAN7ev6UAG9vX9KADe3r+lAAXJBHGDigBtABQAUAFABQAUAFABQAUAFAEgjfPp9TQBJ5afKBuye2KALKzPFG6K21JPvrQBU/wCBj8qAHUAFABQAUAFACbl9RQAAg9DQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFAFegAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAFUlSCOooAeJP7w3e5NAB5nt+tAB5nt+tAB5nt+tAC+c/bFADNx49hgUAG5vWgBMn1P50AJQAUAFAE45APtQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFADo/7u3FADaADdH/AHv0NABuj/vfoaAE83P8O73xQAzzPb9aADzPb9aADzPb9aAH4wV2/NjnkUALQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAR+X7/pQAeX7/pQAeX7/AKUAHl+/6UAR0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAuCegNADgh78UAS0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABuj/AL36GgCPzPb9aADzPb9aADzPb9aAAyO3U/lQBHQAUAFABQAUAFABQAUAFABQBPv3/UUALQAUAFABQAUAFABQAUAFABQAUAJ0/wBk0APzH/e/WgBm9Pf8/wD61AB1/wBo0ALQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUARydvxoAjoAKACgAoAKACgAoAKACgAoAKACgAoAKACgD/0P8AP/oAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgABx/9egCYqD2/KgBhQ9uaAG4I6g0AJQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFACgE0AS7F9KAFwPQflQAtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQA7v/AHaAGs0Y/wBo0AM38/KoFADfMf1NADKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAn7bc/NQAtABuj/vfoaAI/M9v1oAPM9v1oAPM9v1oAPM9v1oAZk+p/OgBKACgAoAKACgAoAKAJ/MEn3v0oAWgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgCOTt+NAEdABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFAFigCNnwcD86AG729f0oATJ/pQAlABQAUAFABQAUAKCB1GQaAHEr2GOvWgB/yH0oAAq9QKAHYA6DFAAeeKAICCP6UAJQAUAFABQAUAFABQBIH6A9OlAElABQAUAFABQAUAFABQAUAFABQAUAFADlO5tvp2oAbQBcW1upI3ZULLGgd2/u+ZQBV/1bsvfqKAG0AFABQAUAFABQAUAFABQAUAFABQAbo/736GgBBtJLM2c8cUAQ5PqfzoASgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAJfM7fw9OlAEVABQAUAFABQAUAFABQAUAFABQAUAFABQAUAT7tw/2qAFoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgCOTt+NAEdABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQA5Qp4Oc0AP2D3oAfQBAepx0yaAEoAKACgAoAKACgAoAKACgAoAKACgBQxHegB280AKWDAg8c5H+FAEdABQAUAFABQAUAFABQA4MR7j0oAeHB46UAPoAKACgAoAKACgAoAKACgAoAUVSA+mf2Zv2XvjR+2F8Y9E8B+BNHl1fX9Zl+z2tvD8u1P3knnT/wCxGieZQwP7U/D/APwZRSN4XtLjUvjLcLrDWXm3+n2uhR/ZluNnmeTHP5nmbN//AEyqQP5if+Cn/wDwSK/an/4JTaroNn48XQ5NN8VNqiaNqmg6hNOt4tm8ckiXcckUex40mX/V+ZQB+RFABQAUAFABQAUAFABQAUAFABQAUAFAFegAoAKAJI+/4UASUAQv94/hQA2gAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgCSPv+FAElABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUARydvxoAjoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoA/Tf9hP/AIJA/t4/8FIPCet678J/CcOuaT4f1CHStTvbrVLayjS6khE6wobhxvIjIZsdNw9aAPuxP+DWP/gs26bv+FdaYPZvFOnA/l5tACt/waxf8Fm1IB+HemHOeR4p084+v7ygdvQf/wAQr/8AwWc4/wCLeaVz/wBTXp3/AMdoEfI37Zv/AAQ6/wCCkv7BHwifx38SPAn9m+FYb600+71aw1W1vo7aW5JWD7QtvIWjV3+QORt3FVzzQB+SNABQ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ZQBJ5nbt6UAA2bDn72aAI6ACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAJPNf1oAI5NmeMg0APTP8PWgBaACgD+k7/gjj+0h4B+DX7B37VGn6vr3hnS7+Hw3o3ibw9pmqPs1DUtQs5o5I7W0/57f6pP3f8Ayzk5oA/HL9uD9p1v2wP2gdS8dyab/ZdxqltZRXNuZvNZpY0/ePv8ygD48j+6f8+lADqACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoATuu7rxigCCgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKALDj5Q3RuKAK9ABQAUAFAEidc5wR60ASUAJJjaM/e70AQUAFABQAUAFABQAUAFACgkcjH4jP86AFZixJOAT6AD9BQA2gAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgCxQA3+59DQBt20GLNZY3jeVpdht9j+ZhPn3/u/4P/iaAGXF/LcW8MJCqkbSOrqm1v3n8FAGWM87W3fWgBtABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAnPLfxL1zQBBQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQBa5VvRcUAViMH+tACUAFAD0Gc8ZI5AoAscu3quKAGUARM3zZ7igBlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQBJ5fv+lAB5fv+lAB5fv8ApQAeX7/pQBHQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAPj++PrQBLQBcs9QudPnEsMskUgJUsv9ygCrI3mSFmbcWoAbQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFADZPuj/AD60AQ0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAWKACgBrDIP5igCGgBynBFAE1ABQBXoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgCaP7p/z6UAOoAKACgAoAKADy4/X9DQBH5fv+lAElABQBXoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAHx/fH1oAloAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgCOTt+NAEdABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQB//1/8AP/oAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKALFABQAUAQEYJFACUATqcgH86AFoAr0AFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQBNH90/59KAHUAFABQAUAFABQAUAFABQBC/3j+FADaACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKAJE+630oAkoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgBX/ANV+NAFagAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgCxQAUAFAET9fwoAZQBKnT8aAH0AV6ACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAKACgAoAmj+6f8APpQA6gAoAKACgAoAKACgAoAe/X8KAKlABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUASf8ALT/PpQBHQAUAFABQBN/c+hoAdQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAKn+q/GgBKACgAoAKAK9ABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQAUAFABQB//Z";

        File.WriteAllText(filePath, text);
    }

    static void loading()
    {
        Console.WriteLine("Loading...");

        for (int i = 0; i <= 3; i++)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write("[{0}{1}] {2}%", new string('#', i), new string('-', 10 - i), i * 10);
            Thread.Sleep(80);
        }
        Thread.Sleep(800);
        for (int i = 3; i <= 5; i++)
        {
            // Очищаем текущую строку перед выводом следующего прогресса
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write("[{0}{1}] {2}%", new string('#', i), new string('-', 10 - i), i * 10);
            Thread.Sleep(400); // Задержка для эффекта загрузки
        }
        for (int i = 5; i <= 10; i++)
        {
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write("[{0}{1}] {2}%", new string('#', i), new string('-', 10 - i), i * 10);
            Thread.Sleep(100);
        }
    }




    static void Botz_create()
    {
        Console.WriteLine("Введите количество ботов, которое хотите добавить: ");
        int colbobotz = int.Parse(Console.ReadLine());
        string fi;
        fi = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string musicFolderPath = Path.Combine(fi, "reproxyset");
        //coздание папки reproxy
        string filePaqz = Path.Combine(musicFolderPath, "botz.txt");
        string filePaz = Path.Combine(musicFolderPath, "softcopyinfo.txt");
        // Читаем содержимое файла
        string fileContents = File.ReadAllText(filePaz);
        string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        string sourcePath = fileContents;
        //
        string content = File.ReadAllText(filePaqz);
        int number;
        int.TryParse(content, out number);
        string filePath = Path.Combine(musicFolderPath, "botz.txt");


        //начало копирования
        for (int i = 0; i < colbobotz; i++)
        {
            string fileP = Path.Combine(musicFolderPath, "names.txt");
            string randomLine = GetRandomLineFromFile(fileP);
            Console.WriteLine(randomLine);
            string destinationPaz;
            destinationPaz = Path.Combine("Bots", randomLine);
            string destinationPath = Path.Combine(desktopPath, destinationPaz);
            string l = Path.Combine(destinationPath, "settings", "proxy.txt");

            // Проверяем, существует ли исходная папка
            if (!Directory.Exists(musicFolderPath))
            {
                Console.WriteLine("Исходная папка не существует.");
                return;
            }
            //тута метод копирования
            CopyDirectoy(sourcePath, destinationPath);
            using (StreamWriter sw = File.AppendText(filePath))
                sw.Write(l + "!");
        }
        using (StreamWriter writer = new StreamWriter(filePaqz, true))
        {
            writer.WriteLine(colbobotz);
        }
    }

    static string GetRandomLineFromFile(string filePath)
    {
        string[] lines = File.ReadAllLines(filePath);
        Random random = new Random();
        int randomIndex = random.Next(0, lines.Length);
        string randomLine = lines[randomIndex];
        return randomLine;
    }

    static void CopyDirectoy(string sourcePath, string destinationPath)
    {
        if (!Directory.Exists(destinationPath))
        {
            Directory.CreateDirectory(destinationPath);
        }
        string[] files = Directory.GetFiles(sourcePath);
        string[] directories = Directory.GetDirectories(sourcePath);
        foreach (string file in files)
        {
            string destinationFile = Path.Combine(destinationPath, Path.GetFileName(file));
            File.Copy(file, destinationFile, true);
        }
        foreach (string directory in directories)
        {
            string directoryName = Path.GetFileName(directory);
            string destinationDirectory = Path.Combine(destinationPath, directoryName);
            CopyDirectoy(directory, destinationDirectory);
        }
    }
  /*  static void runonatime()
    {
        Console.WriteLine("Введите путь к приложению:");
        string appPath = Console.ReadLine();
        DateTime startTime = DateTime.Today.AddHours(7); // Установка времени запуска в 7:00 утра
        DateTime endTime = DateTime.Today.AddHours(24); // Установка времени окончания в 24:00 вечера (12:00 позднее)
        // Создание таймера для задержки до времени запуска
        Timer timer = new Timer(state =>
        {
            // Проверка текущего времени и наличия приложения
            if (DateTime.Now >= startTime && DateTime.Now <= endTime && System.IO.File.Exists(appPath))
            {
                // Запуск приложения
                Process.Start(appPath);

                // Ожидание указанного времени работы
                Thread.Sleep((int)(endTime - DateTime.Now).TotalMilliseconds);

                // Завершение приложения
                foreach (var process in Process.GetProcessesByName(System.IO.Path.GetFileNameWithoutExtension(appPath)))
                {
                    process.Kill();
                }
            }
        }, null, TimeSpan.Zero, TimeSpan.FromMinutes(1)); // Проверка каждую минуту
        // Ожидание завершения программы
        Console.ReadLine();
        timer.Dispose();
    }
    */
}