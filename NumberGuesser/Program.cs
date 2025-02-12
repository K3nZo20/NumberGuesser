using System;

namespace NumberGuesser
{
    class Program
    {
        static void Main(string[] args)
        {
            GetAppInfo();

            string userName = GetUserName();

            GreetUser(userName);

            Random random = new Random();

            int correctNumber = random.Next(1,11);

            bool correctAnswer = false;

            while (!correctAnswer)
            {
                string input = Console.ReadLine();

                int guess;

                bool isNumber = int.TryParse(input, out guess);

                if (!isNumber)
                {
                    PrintColorMessage("To nie jest liczba", ConsoleColor.Yellow);
                    continue;
                }

                if (guess < 1 || guess > 10)
                {
                    PrintColorMessage("Wprowadź liczbę z przedziału od 1 do 10", ConsoleColor.Yellow);
                    continue;
                }

                if (guess < correctNumber)
                {
                    PrintColorMessage("Wylosowana liczba jest większa", ConsoleColor.Red);
                }
                else if (guess > correctNumber)
                {
                    PrintColorMessage("Wylosowana liczba jest mniejsza", ConsoleColor.Red);
                }
                else
                {
                    correctAnswer = true;
                    PrintColorMessage("Brawo! Prawidłowa odpowiedź!", ConsoleColor.Green);
                }
            }
        }

        static void GetAppInfo()
        {
            string appName = "Zgadywanie liczby";
            int appVersion = 1;

            string info = $"[{appName}] Wersja:{appVersion}";

            PrintColorMessage(info, ConsoleColor.Magenta);
        }

        static string GetUserName()
        {
            Console.WriteLine("Jak masz na imię?");

            string inputUserName = Console.ReadLine();

            return inputUserName;
        }

        static void GreetUser(string userName)
        {
            string info = $"Powodzenia {userName}, odgadnij liczbę od 1 do 10.";

            PrintColorMessage($"Powodzenia {userName}, odgadnij liczbę od 1 do 10.", ConsoleColor.Blue);
        }

        static void PrintColorMessage(string message, ConsoleColor color)
        {

            Console.ForegroundColor = color;

            Console.WriteLine(message);

            Console.ResetColor();
        }
    }
}
