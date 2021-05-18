using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace VRChampionsCup
{
    class FC
    {
       public string club { get; set; }
       public int Id { get; set; }
       public int score { get; set; }
    }


    class Program
    {
        public static List<FC> fclubs = new List<FC>();
        public static int balance;
        public static int indexofteam1;
        public static int indexofteam2;
        public static int[] teams;

        static void Main(string[] args)
        {
            balance = balance + 500;
            

            Teamfill();
            

            Console.WriteLine("Добро пожаловать на Европейский Чемпионат футбольных команд!");
            Console.WriteLine("Нажмите любую клавишу для начала.");
            Console.ReadKey();
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("Перед каждой игрой вы будете делать ставку на одну из команд");
            Console.WriteLine("");
            Console.WriteLine("Игра закончится по завершению турнира или когда ваш баланс упадет до нуля");
            Console.WriteLine("");
            Console.WriteLine($"Ваш счет: {balance} рублей.");
            Console.WriteLine("");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();


            int[] mainteams = Randomizer(new int[fclubs.Count]);
            teams = mainteams;
            oneof8();
            Console.WriteLine("============================================================");
            Console.WriteLine("И так, 1\\8-я финала подошла к концу");
            Console.WriteLine("");
            Console.WriteLine($"На вашем счету: {balance} рублей.");
            Console.WriteLine("============================================================");
            int[] mainteams1 = Randomizer(new int[fclubs.Count]);
            teams = mainteams1;
            oneof4();
            Console.WriteLine("============================================================");
            Console.WriteLine("1\\4я подошла к концу, и мы переходим к полуфиналу!");
            Console.WriteLine("");
            Console.WriteLine($"На вашем счету: {balance} рублей.");
            Console.WriteLine("============================================================");
            int[] mainteams2 = Randomizer(new int[fclubs.Count]);
            teams = mainteams2;
            semifinal();
            final();
            End();


        }
        static void final()
        {
            Console.WriteLine("==============ФИНАЛ==============");
            Console.WriteLine("Настало время последней игры турнира!");
            Console.WriteLine("");
            Console.WriteLine("В финале сыграют две команды, показавшие лучшие результаты на протяжении турнира");
            Console.WriteLine("");
            Console.WriteLine("");
            int idcount = 1;
            foreach (FC c in fclubs)
            {
                c.Id = idcount;
                idcount++;
            }

            FC finteam1 = fclubs.First(x => x.Id == 1);
            FC finteam2 = fclubs.First(x => x.Id == 2);
            Console.WriteLine("Теперь весь ваш счет будет поставлен на кон");
            Console.WriteLine("");
            Console.WriteLine("1: " + finteam1.club + " | | VS | | 2: " + finteam2.club);
            Console.WriteLine("");
            Console.Write("Введите номер команды: ");
            int chooseteam = Convert.ToInt32(Console.ReadLine());
            int stavka = balance;

            Random rndscore = new Random();
            int score1;
            int score2;

            while (true)
            {
                score1 = rndscore.Next(5);
                score2 = rndscore.Next(5);
                if (score1 != score2)
                {
                    break;
                }
            }
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("1: " + finteam1.club + " |" + score1 + "| VS |" + score2 + "| 2: " + finteam2.club);

            if (chooseteam == 1)
            {
                if (score1 > score2)
                {
                    balance = BalanceCulc(stavka, balance);
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Ура, ваша команда выиграла");
                    Console.WriteLine("");
                    Console.WriteLine($"Ваш баланс: {balance} рублей.");

                }
                else
                {
                    balance = BalanceOut(stavka, balance);
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Увы, ваша команда проиграла");
                    Console.WriteLine("");
                    Console.WriteLine($"Ваш баланс: {balance} рублей.");
                }
            }
            if (chooseteam == 2)
            {
                if (score1 < score2)
                {
                    balance = BalanceCulc(stavka, balance);
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Ура, ваша команда выиграла");
                    Console.WriteLine("");
                    Console.WriteLine($"Ваш баланс: {balance} рублей.");
                }
                else
                {
                    balance = BalanceOut(stavka, balance);
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Увы, ваша команда проиграла");
                    Console.WriteLine("");
                    Console.WriteLine($"Ваш баланс: {balance} рублей.");
                }
            }
            idcount = 1;
            foreach (FC c in fclubs)
            {
                c.Id = idcount;
                idcount++;
            }
            FC champion = fclubs.First(x => x.Id == 1);
            Console.WriteLine("Победитель турнира и новый ЧЕМПИОН - " + champion.club + "!!!");
        }
        static void semifinal()
        {
            Console.WriteLine("Команды вышедшие в полуфинал");
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("");
            int idcount = 1;
            foreach (FC c in fclubs)
            {
                c.Id = idcount;
                Console.WriteLine(c.Id + " - " + c.club);
                idcount++;
            }
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Первая игра полуфинала");
            Console.WriteLine("==================================");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            indexofteam1 = 0;
            indexofteam2 = 1;
            Match();
            Console.WriteLine("Вторая игра полуфинала");
            Console.WriteLine("==================================");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            indexofteam1 = 2;
            indexofteam2 = 3;
            Match();
        }
        static void oneof4()
        {
            Console.WriteLine("Команды 1\\4 финала");
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("");
            int idcount = 1;
            foreach (FC c in fclubs)
            {
                c.Id = idcount;
                Console.WriteLine(c.Id + " - " + c.club);
                idcount++;
            }
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("Первая игра - 1\\4");
            Console.WriteLine("==================================");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            indexofteam1 = 0;
            indexofteam2 = 1;
            Match();
            Console.WriteLine("Вторая игра - 1\\4");
            Console.WriteLine("==================================");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            indexofteam1 = 2;
            indexofteam2 = 3;
            Match();
            Console.WriteLine("Третья игра - 1\\4");
            Console.WriteLine("==================================");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            indexofteam1 = 4;
            indexofteam2 = 5;
            Match();
            Console.WriteLine("Четвертая игра - 1\\4");
            Console.WriteLine("==================================");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            indexofteam1 = 6;
            indexofteam2 = 7;
            Match();
        }
        static void oneof8()
        {
            Console.WriteLine("Команды на 1\\8 финала");
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("");
            int idcount = 1;
            foreach (FC c in fclubs)
            {
                c.Id = idcount;
                Console.WriteLine(c.Id + " - " + c.club);
                idcount++;
            }
            Console.WriteLine("");
            Console.WriteLine("------------------------------------------------------------");
            Console.WriteLine("");

            

            Console.WriteLine("Первая игра - 1\\8");
            Console.WriteLine("==================================");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            indexofteam1 = 0;
            indexofteam2 = 1;
            Match();
            Console.WriteLine("Вторая игра - 1\\8");
            Console.WriteLine("==================================");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            indexofteam1 = 2;
            indexofteam2 = 3;
            Match();
            Console.WriteLine("Третья игра - 1\\8");
            Console.WriteLine("==================================");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            indexofteam1 = 4;
            indexofteam2 = 5;
            Match();
            Console.WriteLine("Четвертая игра - 1\\8");
            Console.WriteLine("==================================");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            indexofteam1 = 6;
            indexofteam2 = 7;
            Match();
            Console.WriteLine("Пятая игра - 1\\8");
            Console.WriteLine("==================================");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            indexofteam1 = 8;
            indexofteam2 = 9;
            Match();
            Console.WriteLine("Шестая игра - 1\\8");
            Console.WriteLine("==================================");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            indexofteam1 = 10;
            indexofteam2 = 11;
            Match();
            Console.WriteLine("Седьмая игра - 1\\8");
            Console.WriteLine("==================================");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            indexofteam1 = 12;
            indexofteam2 = 13;
            Match();
            Console.WriteLine("Восьмая игра - 1\\8");
            Console.WriteLine("==================================");
            Console.WriteLine("Нажмите любую клавишу для продолжения.");
            Console.ReadKey();
            indexofteam1 = 14;
            indexofteam2 = 15;
            Match();

        }
        static void Match()
        {
            
            int stteamnum = teams[indexofteam1];
            int ndteamnum = teams[indexofteam2];

            FC stteam = fclubs.First(x => x.Id == stteamnum);
            FC ndteam = fclubs.First(x => x.Id == ndteamnum);
            Console.WriteLine("Сделайте ставку на одну из команд");
            Console.WriteLine("");
            Console.WriteLine("1: " + stteam.club + " | | VS | | 2: " + ndteam.club);
            Console.WriteLine("");
            Console.Write("Введите номер команды: ");
            int chooseteam = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("==================================");
            int stavka;
            while (true)
            {
                Console.Write("Введите сумму ставки: ");
                stavka = Convert.ToInt32(Console.ReadLine());
                if (stavka <= balance)
                {
                    break;
                }
                Console.WriteLine("");
                Console.WriteLine("Ставка не может превышать баланс");
                Console.WriteLine("");
                Console.WriteLine($"Ваш баланс: {balance} рублей.");
            }
            Random rndscore = new Random();
            int score1;
            int score2;

            while (true)
            {
                score1 = rndscore.Next(5);
                score2 = rndscore.Next(5);
                if (score1 != score2)
                {
                    break;
                }
            }
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("");
            Console.WriteLine("1: " + stteam.club + " |" + score1 + "| VS |" + score2 + "| 2: " + ndteam.club);
            if (score1 > score2)
            {
                fclubs.Remove(ndteam);
            }
            if (score1 < score2)
            {
                fclubs.Remove(stteam);
            }


            if (chooseteam == 1)
            {
                if (score1 > score2)
                {
                    balance = BalanceCulc(stavka, balance);
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Ура, ваша команда выиграла");
                    Console.WriteLine("");
                    Console.WriteLine($"Ваш баланс: {balance} рублей.");

                }
                else
                {
                    balance = BalanceOut(stavka, balance);
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Увы, ваша команда проиграла");
                    Console.WriteLine("");
                    Console.WriteLine($"Ваш баланс: {balance} рублей.");
                    if (balance <= 0)
                    {
                        outofamount();
                    }
                }
            }
            if (chooseteam == 2)
            {
                if (score1 < score2)
                {
                    balance = BalanceCulc(stavka, balance);
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Ура, ваша команда выиграла");
                    Console.WriteLine("");
                    Console.WriteLine($"Ваш баланс: {balance} рублей.");
                }
                else
                {
                    balance = BalanceOut(stavka, balance);
                    Console.WriteLine("---------------------------------------------");
                    Console.WriteLine("");
                    Console.WriteLine("Увы, ваша команда проиграла");
                    Console.WriteLine("");
                    Console.WriteLine($"Ваш баланс: {balance} рублей.");
                    if (balance <= 0)
                    {
                        outofamount();
                    }
                }
            }
        }
        static int[] Randomizer(int[] teams1)
        {
            int ss = 1;
            for (int i = 0; i < teams1.Length; i++)
            {
                
                teams1[i] = ss;
                ss++;
            }

            Random rndteam = new Random();

            for (int i = teams1.Length - 1; i >= 1; i--)
            {
                int j = rndteam.Next(i + 1);
                var gg = teams1[j];
                teams1[j] = teams1[i];
                teams1[i] = gg;
            }
   
            return teams1;
            
        }

        static int BalanceCulc(int x, int y)
        {
            y = y - x;
            int z = x * 2;
            int result = y + z;
            return result;
        }
        static  int BalanceOut(int x, int y)
        {
            int result = y - x;
            
            return result;
        }

        static void Teamfill()
        {
            fclubs.Add(new FC() { club = "Barcelona" });
            fclubs.Add(new FC() { club = "Bayern Munich" });
            fclubs.Add(new FC() { club = "Real Madrid" });
            fclubs.Add(new FC() { club = "Liverpool" });
            fclubs.Add(new FC() { club = "Juventus" });
            fclubs.Add(new FC() { club = "Anzhi" });
            fclubs.Add(new FC() { club = "Galatasaray" });
            fclubs.Add(new FC() { club = "Borussia Dort." });
            fclubs.Add(new FC() { club = "FC Chelsea" });
            fclubs.Add(new FC() { club = "Milan" });
            fclubs.Add(new FC() { club = "FC Porto" });
            fclubs.Add(new FC() { club = "PSG" });
            fclubs.Add(new FC() { club = "Manchester United" });
            fclubs.Add(new FC() { club = "AC Monaco" });
            fclubs.Add(new FC() { club = "PSV" });
            fclubs.Add(new FC() { club = "Spartak Moscow" });
        }
        static void outofamount()
        {
            Console.WriteLine("У вас на счету закончились деньги!");
            End();
        }
        static void End()
        {
            Console.WriteLine("<< -- == The End == -- >>");
            return;
        }
    }

}
