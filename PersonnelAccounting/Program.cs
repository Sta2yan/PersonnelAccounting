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
                        AddDossier(ref fullNameEmployees, ref positionEmployees);
                        break;
                    case IdGetAllDossiersCommand:
                        ShowAllDossiers(fullNameEmployees, positionEmployees);
                        break;
                    case IdDeleteDossierCommand:
                        DeleteDossier(ref fullNameEmployees, ref positionEmployees);
                        break;
                    case IdSearchByLastNameCommand:
                        SearchByLastName(fullNameEmployees, positionEmployees);
                        break;
                    case IdExecuteExitCommand:
                        isOpen = ExecuteExit();
                        break;
                }
            }
        }

        static void AddDossier(ref string[] fullNameArray, ref string[] positionArray)
        {
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("Заполните ФИО сотрудника:");
            string addedFullName = Console.ReadLine();
            Console.WriteLine("Заполните должность сотрудника:");
            string addedPosition = Console.ReadLine();

            IncreaseArray(ref fullNameArray);
            IncreaseArray(ref positionArray);

            fullNameArray[fullNameArray.Length - 1] = addedFullName;
            positionArray[positionArray.Length - 1] = addedPosition;


            Console.WriteLine($"Добавлено новое досье: ФИО: {addedFullName} | Позиция: {addedPosition}");
            Console.ReadKey();
            Console.Clear();
        }

        static void ShowAllDossiers(string[] fullNameArray, string[] positionArray)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;

            int totalSizeArrays = fullNameArray.Length;

            Console.WriteLine($"Все досье:");
            for (int currentIndex = 0; currentIndex < totalSizeArrays; currentIndex++)
            {
                Console.WriteLine($"{currentIndex + 1}. ФИО: {fullNameArray[currentIndex]} | Должность: {positionArray[currentIndex]}");
            }

            Console.ReadKey();
            Console.Clear();
        }

        static void DeleteDossier(ref string[] fullNameArray, ref string[] positionArray)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Заполните ФИО сотрудника, которого хотите удалить из досье:");
            string remoteFullName = Console.ReadLine();

            int totalSizeArrays = fullNameArray.Length;
            

            for (int currentIndex = 0; currentIndex < totalSizeArrays; currentIndex++)
            {
                totalSizeArrays--;
                if (fullNameArray[currentIndex].Equals(remoteFullName))
                {
                    DecreaseArray(ref fullNameArray, currentIndex);
                    DecreaseArray(ref positionArray, currentIndex);
                }
            }
        }

        static void SearchByLastName(string[] fullNameArray, string[] positionArray)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("Введите Фамилию сотрудника, которого хотите найти:");
            string surname = Console.ReadLine();

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

        static void IncreaseArray(ref string[] array)
        {
            int totalSizeArrays = array.Length;
            string[] tempArray = new string[array.Length + 1];

            for (int currentIndex = 0; currentIndex < totalSizeArrays; currentIndex++)
            {
                tempArray[currentIndex] = array[currentIndex];
            }

            array = tempArray;
        }

        static void DecreaseArray(ref string[] array, int decreaseIndex)
        {
            string[] tempFullNameArray = new string[array.Length - 1];

            for (int currentIndex = 0; currentIndex < decreaseIndex; currentIndex++)
            {
                tempFullNameArray[currentIndex] = array[currentIndex];
            }
            for (int currentIndex2 = decreaseIndex; currentIndex2 <= array.Length; currentIndex2++)
            {
                tempFullNameArray[currentIndex2] = array[currentIndex2 + 1];
            }
            array = tempFullNameArray;
        }
    }
}