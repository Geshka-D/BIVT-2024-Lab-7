using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Lab_7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            //program.Test4();
            
        }
        public void Test1()
        {
            string[] participantNames = new string[] {"Дарья", "Тихонова", "Александр", "Козлов", "Никита",
                "Павлов", "Юрий", "Луговой", "Юрий", "Степанов", "Мария", "Луговая", "Виктор",
                "Жарков", "Марина", "Иванова", "Марина", "Полевая", "Максим", "Тихонов"};

            string[] judgeNames = new string[] { "Александр", "Екатерина", "Дмитрий", "Ольга", "Иван", "Мария", "Сергей" };


            int[][] judgeMarks = new int[][] {
                new int[] { 3, 5, 2, 6, 3, 1, 6, 6, 1, 4, 5, 3, 3, 5, 6, 5, 4, 5, 2, 3, 6, 5, 1, 3, 4, 1, 3, 3, 6, 5, 4, 6, 3, 4, 1, 1, 3, 6, 3, 5 },
                new int[] { 4, 3, 4, 4, 5, 6, 2, 5, 1, 1, 2, 1, 3, 5, 3, 1, 3, 3, 2, 2, 5, 4, 1, 1, 6, 2, 6, 3, 5, 4, 2, 5, 6, 6, 1, 4, 3, 4, 3, 1 },
                new int[] { 1, 4, 1, 3, 4, 5, 4, 2, 3, 1, 3, 3, 5, 4, 1, 6, 5, 4, 4, 1, 5, 3, 3, 5, 1, 3, 2, 6, 3, 4, 2, 6, 3, 1, 3, 4, 1, 5, 4, 5 },
                new int[] { 2, 3, 5, 2, 4, 2, 1, 2, 5, 2, 3, 4, 2, 2, 2, 6, 4, 2, 2, 3, 4, 2, 4, 1, 4, 1, 3, 6, 2, 2, 5, 1, 5, 4, 1, 6, 4, 4, 2, 5 },
                new int[] { 1, 3, 6, 2, 5, 1, 2, 4, 5, 2, 2, 2, 1, 3, 2, 3, 5, 1, 6, 5, 2, 4, 4, 4, 5, 5, 1, 3, 6, 1, 1, 6, 4, 2, 3, 6, 5, 2, 2, 1 },
                new int[] { 3, 3, 1, 1, 1, 4, 6, 3, 5, 2, 2, 4, 2, 2, 6, 2, 1, 1, 3, 1, 6, 6, 1, 3, 3, 4, 6, 6, 5, 2, 3, 3, 2, 1, 2, 2, 6, 3, 3, 3 },
                new int[] { 1, 3, 2, 1, 4, 1, 5, 4, 2, 5, 3, 5, 4, 2, 6, 5, 1, 2, 4, 5, 4, 1, 6, 1, 4, 3, 3, 6, 3, 4, 1, 3, 3, 5, 6, 5, 2, 1, 6, 4 }
            };

            //Create a list of the participants
            Purple_1.Participant[] participants = new Purple_1.Participant[10];
            for (int i = 0; i < participants.Length; i++)
            {
                participants[i] = new Purple_1.Participant(participantNames[i * 2], participantNames[i * 2 + 1]);
            }

            //Create a list of the judges
            Purple_1.Judge[] judges = new Purple_1.Judge[7];
            for (int i = 0; i < judges.Length; i++)
            {
                judges[i] = new Purple_1.Judge(judgeNames[i], judgeMarks[i]);
            }


            //Create a competition with the judges and assign all the participants to it
            Purple_1.Competition competition = new Purple_1.Competition(judges);
            competition.Add(participants);

            //Sort the leaderboard
            competition.Sort();

            //Print the leaderboard
            foreach (Purple_1.Participant var in competition.Participants)
            {
                Console.WriteLine(var.Name + " " + var.Surname + "  " + var.TotalScore);
                for (int i = 0; i < var.Marks.GetLength(0); i++)
                {
                    for (int j = 0; j < var.Marks.GetLength(1); j++)
                        Console.Write(var.Marks[i, j] + " ");
                    Console.WriteLine();
                }
                Console.WriteLine();
                //Prints every mark:
                /*Console.WriteLine(string.Join(Environment.NewLine,
                Enumerable.Range(0, var.Marks.GetLength(0))
                .Select(i => string.Join(" ", Enumerable.Range(0, var.Marks.GetLength(1))
                .Select(j => var.Marks[i, j])))));*/
            }

        }
        public void Test2()
        {
            string[] names = new string[] { "Оксана", "Сидорова", "Полина", "Полевая","Дмитрий",
                "Полевой", "Евгения", "Распутина", "Савелий", "Луговой",
                "Евгения", "Павлова", "Егор", "Свиридов", "Степан", "Свиридов",
                "Анастасия", "Козлова", "Светлана", "Свиридова" };

            int[] distances = new int[] { 135, 191, 147, 115, 112, 151, 186, 166, 112, 197 };

            int[][] marks =
            {
                new int[] {15, 1, 3, 9, 15},
                new int[] {19, 14, 9, 11, 4},
                new int[] {20, 9, 1, 13, 6},
                new int[] {5, 20, 17, 9, 16},
                new int[] {19, 8, 1, 6, 17},
                new int[] {16, 12, 5, 20, 4},
                new int[] {5, 20, 3, 19, 18},
                new int[] {16, 12, 5, 4, 15},
                new int[] {7, 4, 19, 11, 12},
                new int[] {14, 3, 6, 17, 1}
            };

            //Make a list for the participants
            Purple_2.Participant[] leaderboard = new Purple_2.Participant[10];

            //Initialize with names
            for (int i = 0; i < leaderboard.Length; i++)
            {
                leaderboard[i] = new Purple_2.Participant(names[i * 2], names[i * 2 + 1]);
            }
            Purple_2.JuniorSkiJumping ans = new Purple_2.JuniorSkiJumping();
            ans.Add(leaderboard);
            //Set distances and marks
            for (int i = 0; i < leaderboard.Length; i++)
            {
                ans.Jump(distances[i], marks[i]);
            }

            //Sort the leaderboard
            
            

            //Print the leaderboard
            foreach (Purple_2.Participant var in ans.Participants)
            {
                Console.WriteLine(var.Name + " " + var.Surname + "  " + var.Result);
            }
        }
        public void Test3()
        {
            string[] names = new string[] { "Виктор", "Полевой", "Алиса", "Козлова", "Ярослав",
                "Зайцев", "Савелий", "Кристиан", "Алиса", "Козлова", "Алиса", "Луговая",
                "Александр", "Петров", "Мария", "Смирнова", "Полина", "Сидорова", "Татьяна",
                "Сидорова" };

            double[,] marks = new double[,]
            {
                {5.93, 5.44, 1.2, 0.28, 1.57, 1.86, 5.89},
                {1.68, 3.79, 3.62, 2.76, 4.47, 4.26, 5.79},
                {2.93, 3.1, 5.46, 4.88, 3.99, 4.79, 5.56},
                {4.2, 4.69, 3.9, 1.67, 1.13, 5.66, 5.4},
                {3.27, 2.43, 0.9, 5.61, 3.12, 3.76, 3.73},
                {0.75, 1.13, 5.43, 2.07, 2.68, 0.83, 3.68},
                {3.78, 3.42, 3.84, 2.19, 1.2, 2.51, 3.51},
                {1.35, 3.4, 1.85, 2.02, 2.78, 3.23, 3.03},
                {0.55, 5.93, 0.75, 5.15, 4.35, 1.51, 2.77},
                {3.86, 0.19, 0.46, 5.14, 5.37, 0.94, 0.84}
            };
            double[] n = new double[] { 0.5, 0.5, 0.5, 0.5, 0.5, 0.5, 0.5 };
            //Make a list for the participants
            Purple_3.Participant[] leaderboard = new Purple_3.Participant[10];

            //Initialize with names
            for (int i = 0; i < leaderboard.Length; i++)
            {
                leaderboard[i] = new Purple_3.Participant(names[i * 2], names[i * 2 + 1]);
            }
            Purple_3.IceSkating ans = new Purple_3.IceSkating(n);
            ans.Add(leaderboard);
            //Set distances and marks
            for (int i = 0; i < marks.GetLength(0); i++)
            {
                var t = new double[7];
                for (int j = 0; j < marks.GetLength(1); j++)
                {
                    t[j] = marks[i, j];
                }

                ans.Evaluate(t);
            }

            //Set places


            //Print the leaderboard
            foreach (Purple_3.Participant var in leaderboard)
            {
                Console.WriteLine(var.Name + " " + var.Surname + "  " + var.Score + " "
                    + var.Places.Min() + " " + var.Marks.Sum());
            }
        }
        public void Test4()
        {


            double[] times1 = new double[] { 422.64, 142.05, 185.23, 294.32, 79.26, 230.63, 35.16, 376.12,
                279.20, 292.38, 467.60, 473.82, 290.14, 368.60, 212.67 };


            double[] times2 = new double[] { 112.49, 472.11, 213.92, 102.13, 263.21, 350.75, 248.68, 325.28,
                300.00, 252.16, 402.20, 397.33, 384.94, 8.09, 480.52 };




            string[] men1 = new string[]
            { "Савелий", "Козлов", "Дмитрий", "Иванов", "Дмитрий",
                "Полевой", "Савелий", "Петров", "Степан", "Павлов" };

            string[] women1 = new string[]
            { "Полина", "Луговая", "Екатерина", "Жаркова", "Евгения",
                "Распутина", "Екатерина", "Луговая", "Мария", "Иванова",
                };
            //"Ольга", "Павлова", "Ольга", "Полевая", "Дарья", "Павлова",
            //"Дарья", "Свиридова", "Евгения", "Свиридова"

            string[] men2 = new string[]
            {"Александр", "Павлов", "Степан", "Свиридов", "Игорь", "Сидоров",
                "Лев", "Петров", "Савелий", "Козлов", "Егор", "Свиридов"};

            string[] women2 = new string[]
            {"Анастасия", "Жаркова", "Евгения", "Сидорова", "Мария", "Сидорова",
                "Оксана", "Жаркова", "Светлана", "Петрова", "Полина", "Петрова",
                "Екатерина", "Павлова", "Юлия", "Полевая", "Евгения", "Павлова"};
            Purple_4.Group s = new Purple_4.Group("s");

            Purple_4.Sportsman[] men = new Purple_4.Sportsman[0];
            Purple_4.Sportsman[] women = new Purple_4.Sportsman[0];
            for (int i = 0; i < 5; i++)
            {
                Purple_4.SkiMan m = new Purple_4.SkiMan(men1[i * 2], men1[i * 2 + 1], times1[i]);
                s.Add(m);
            }
            for (int i = 0; i < 5; i++)
            {
                Purple_4.SkiWoman w = new Purple_4.SkiWoman(women1[i * 2], women1[i * 2 + 1], times2[i]);
                s.Add(w);
            }
            s.Split(out men, out women);
            for (int i = 0; i < 5; i++)
                men[i].Print();
            for (int i = 0; i < 5; i++)
                women[i].Print();
            s.Shuffle();
            s.Print();
        }

        
        public void Test5()
        {
            string[][] responses = new string[][]
            {
                new string[] {"Макака", null, "Манга"},
                new string[] {"Тануки", "Проницательность", "Манга"},
                new string[] {"Тануки", "Скромность", "Кимоно"},
                new string[] {"Кошка", "Внимательность", "Суши"},
                new string[] {"Сима_энага", "Дружелюбность", "Кимоно"},
                new string[] {"Макака", "Внимательность", "Самурай"},
                new string[] {"Панда", "Проницательность", "Манга"},
                new string[] {"Сима_энага", "Проницательность", "Суши"},
                new string[] {"Серау", "Внимательность", "Сакура"},
                new string[] {"Панда", null, "Кимоно"},
                new string[] {"Сима_энага", "Дружелюбность", "Сакура"},
                new string[] {"Кошка", "Внимательность", "Кимоно"},
                new string[] {"Панда", null, "Сакура"},
                new string[] {"Кошка", "Уважительность", "Фудзияма"},
                new string[] {"Панда", "Целеустремленность", "Аниме"},
                new string[] {"Серау", "Дружелюбность", null},
                new string[] {"Панда", null, "Манга"},
                new string[] {"Сима_энага", "Скромность", "Фудзияма"},
                new string[] {"Панда", "Проницательность", "Самурай"},
                new string[] {"Кошка", "Внимательность", "Сакура"}
            };
            Purple_5.Report re = new Purple_5.Report();
            Purple_5.Research r1= re.MakeResearch();
            Purple_5.Research r2 = re.MakeResearch();

            //Create the research, add the responses
            Purple_5.Research research = new Purple_5.Research("Test");
            for (int i = 0; i < responses.Length/2; i++)
            {
                r1.Add(responses[i]);
            }
            for (int i = 0; i < responses.Length / 2; i++)
            {
                r2.Add(responses[i+10]);
            }
            
            (string, double)[] ans = re.GetGeneralReport(1);
            for (int i = 0; i<ans.Length; i++)
            {
                Console.WriteLine($"{ans[i].Item1} {ans[i].Item2}");
            }
            
        }
        
    }
}

