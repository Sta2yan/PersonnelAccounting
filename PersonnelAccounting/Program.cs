using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonnelAccounting
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int IdAddDossierCommand = 1;
            const int IdGetAllDossiersCommand = 2;
            const int IdDeleteDossierCommand = 3;
            const int IdSearchByLastNameCommand = 4;
            const int IdExecuteExitCommand = 5;

            string[] fullNameEmployees = new string[0];
            string[] positionEmployees = new string[0];
            int userInput;
            bool isOpen = true;

            ConsoleColor defaultColor = Console.ForegroundColor;
            Console.CursorVisible = false;
            while (isOpen == true)
            {
                Console.ForegroundColor = defaultColor;
                Console.WriteLine($"Что вы хотите сделать?" +
                                  $"\n\n{IdAddDossierCommand}. Добавить досье" +
                                  $"\n{IdGetAllDossiersCommand}. Вывести все досье" +
                                  $"\n{IdDeleteDossierCommand}. Удалить досье" +
                                  $"\n{IdSearchByLastNameCommand}. Поиск по фамилии" +
                                  $"\n{IdExecuteExitCommand}. Выход");
                userInput = Convert.ToInt32(Console.ReadLine());
                Console.Clear();

                switch (userInput)
                {
                    case IdAddDossierCommand:
                        Console.ForegroundColor = ConsoleColor.Green;
                        
                        Console.WriteLine("Заполните ФИО сотрудника:");
                        string addedFullNameEmployee = Console.ReadLine();
                        Console.WriteLine("Заполните должность сотрудника:");
                        string addedPositionEmployee = Console.ReadLine();

                        AddDossier(ref fullNameEmployees, ref positionEmployees, addedFullNameEmployee, addedPositionEmployee);
                        break;
                    case IdGetAllDossiersCommand:
                        Console.ForegroundColor = ConsoleColor.Yellow;

                        GetAllDossiers(fullNameEmployees, positionEmployees);
                        break;
                    case IdDeleteDossierCommand:
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("Заполните ФИО сотрудника, которого хотите удалить из досье:");
                        string remoteFullNameEmployee = Console.ReadLine();

                        DeleteDossier(ref fullNameEmployees, ref positionEmployees, remoteFullNameEmployee);
                        break;
                    case IdSearchByLastNameCommand:
                        Console.ForegroundColor = ConsoleColor.Magenta;

                        Console.WriteLine("Введите Фамилию сотрудника, которого хотите найти:");
                        string surname = Console.ReadLine();

                        SearchByLastName(fullNameEmployees, positionEmployees, surname);
                        break;
                    case IdExecuteExitCommand:
                        isOpen = ExecuteExit();
                        break;
                }
            }
        }

        static void AddDossier(ref string[] fullNameArray, ref string[] positionArray, string addedFullName, string addedPosition)
        {
            int totalSizeArrays = fullNameArray.Length;
            string[] tempFullNameArray = new string[fullNameArray.Length + 1];
            string[] tempPositionArray = new string[positionArray.Length + 1];

            for (int currentIndex = 0; currentIndex < totalSizeArrays; currentIndex++)
            {
                tempFullNameArray[currentIndex] = fullNameArray[currentIndex];
                tempPositionArray[currentIndex] = positionArray[currentIndex];
            }

            tempFullNameArray[tempFullNameArray.Length - 1] = addedFullName;
            tempPositionArray[tempPositionArray.Length - 1] = addedPosition;

            fullNameArray = tempFullNameArray;
            positionArray = tempPositionArray;

            Console.WriteLine($"Добавлено новое досье: ФИО: {addedFullName} | Позиция: {addedPosition}");
            Console.ReadKey();
            Console.Clear();
        }

        static void GetAllDossiers(string[] fullNameArray, string[] positionArray)
        {
            int totalSizeArrays = fullNameArray.Length;

            Console.WriteLine($"Все досье:");
            for (int currentIndex = 0; currentIndex < totalSizeArrays; currentIndex++)
            {
                Console.WriteLine($"{currentIndex + 1}. ФИО: {fullNameArray[currentIndex]} | Должность: {positionArray[currentIndex]}");
            }

            Console.ReadKey();
            Console.Clear();
        }

        static void DeleteDossier(ref string[] fullNameArray, ref string[] positionArray, string remoteFullName)
        {
            int totalSizeArrays = fullNameArray.Length;
            string[] tempFullNameArray = new string[fullNameArray.Length - 1];
            string[] tempPositionArray = new string[positionArray.Length - 1];

            for (int currentIndex = 0; currentIndex < totalSizeArrays; currentIndex++)
            {
                totalSizeArrays--;
                if (fullNameArray[currentIndex].Equals(remoteFullName))
                {
                    for (int currentIndex2 = 0; currentIndex2 < currentIndex; currentIndex2++)
                    {
                        tempFullNameArray[currentIndex2] = fullNameArray[currentIndex2];
                        tempPositionArray[currentIndex2] = positionArray[currentIndex2];
                    }
                    for (int currentIndex3 = currentIndex; currentIndex3 <= totalSizeArrays; currentIndex3++)
                    {
                        tempFullNameArray[currentIndex3] = fullNameArray[currentIndex3 + 1];
                        tempPositionArray[currentIndex3] = positionArray[currentIndex3 + 1];
                    }
                    fullNameArray = tempFullNameArray;
                    positionArray = tempPositionArray;

                    Console.WriteLine($"Сотрудник {remoteFullName} удален!");
                }
            }

        }

        static void SearchByLastName(string[] fullNameArray, string[] positionArray, string surname)
        {
            for (int currentIndex = 0; currentIndex < fullNameArray.Length; currentIndex++)
            {
                string[] fullName = fullNameArray[currentIndex].Split(' ');
                if (fullName[0].Equals(surname))
                {
                    Console.WriteLine($"Сотрудник найден:" +
                                      $"\nФИО: {fullNameArray[currentIndex]} | Должность: {positionArray[currentIndex]}");
                }
            }
        }

        static bool ExecuteExit()
        {
            Console.WriteLine("Выход...");

            return false;
        }
    }
}