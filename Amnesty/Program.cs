using System;
using System.Collections.Generic;
using System.Linq;

namespace Amnesty
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arstotska arstotska = new Arstotska();
            arstotska.Work();
        }
    }

    class Prisoner
    {
        public Prisoner()
        {
            FullName = UserUntils.GenerateRandomFullName();
            Crime = UserUntils.GenerateRandomCrime();
        }

        public string FullName { get; private set; }
        public string Crime { get; private set; }

        public void ShowInfo()
        {
            Console.WriteLine($"Преступник - {FullName} .Осуждён за : {Crime} .");
        }
    }

    class UserUntils
    {
        private static Random _random = new Random();

        public static string GenerateRandomFullName()
        {
            string[] names = { "Алексей ", "Иван ", "Анатолий ", "Андрей ", "Евгений " };
            string[] surnames = { "Гладков ", "Маркин ", "Акишев ", "Сотсков ", "Заварницын " };
            string[] middleNames = { "Иванович", "Алексеевич", "Николаевич", "Андреевич", "Вячеславович" };
            string fullName = "";
            int quantity = 1;

            for (int i = 0; i < quantity; i++)
            {
                fullName += surnames[_random.Next(surnames.Length)];
                fullName += names[_random.Next(names.Length)];
                fullName += middleNames[_random.Next(middleNames.Length)];
            }

            return fullName;
        }

        public static string GenerateRandomCrime()
        {
            string[] narionalitys = { "Антиправительственное", "Убийство", "Кража" };
            string nationality = "";
            int quantity = 1;

            for (int i = 0; i < quantity; i++)
            {
                nationality += narionalitys[_random.Next(narionalitys.Length)];
            }

            return nationality;
        }     
    }

    class Arstotska
    {
        private List<Prisoner> _jail = new List<Prisoner>();

        public Arstotska()
        {
            CreatePrisoners();
        }

        public void Work()
        {
            const string CommandAmnestyPrisoner = "1";
            const string CommandExit = "2";

            bool isWork = true;

            while (isWork)
            {
                Console.WriteLine($"Нажмите {CommandAmnestyPrisoner}, чтобы амнистировать заключённых, совершивших антиправительственное прееступление.");
                Console.WriteLine($"Нажмите {CommandExit}, чтобы завершить работу.");
                Console.WriteLine("Список всех преступников в тюрьме:\n");
                ShowAllPrisoners();
                string userInput = Console.ReadLine();

                switch (userInput)
                {
                    case CommandAmnestyPrisoner:
                        AmnestyPrisoners();
                        break;

                    case CommandExit:
                        isWork = false;
                        break;

                    default:
                        Console.WriteLine("Такой команды нет...");
                        break;
                }

                Console.ReadKey();
                Console.Clear();
            }
        }

        private void CreatePrisoners()
        {
            int quantityPrisoners = 10;

            for (int i = 0; i < quantityPrisoners; i++)
            {
                _jail.Add(new Prisoner());
            }
        }

        private void ShowAllPrisoners()
        {
            foreach (Prisoner prisoner in _jail)
            {
                prisoner.ShowInfo();
            }
        }

        private void AmnestyPrisoners()
        {
            string crime = "Антиправительственное";
            var amnestyPrisoner = _jail.Where(prisoner => prisoner.Crime != crime).ToList();
            _jail = amnestyPrisoner;
        }
    }
}
