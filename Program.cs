//***************************************************************************************************************
//* Задание для лекции № 20                                                                                     *
//* Выполнила: Скороходова К.С., группа 2 ИСП                                                                   *
//* Задание: Нахождение суммы элементов массива                                                                 *
//***************************************************************************************************************
using System;
namespace задание20
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.Gray;
            Console.Title = "Задание № 20";
            Console.ForegroundColor = ConsoleColor.White;
            bool continueProgram = true;
            while (continueProgram)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Здравствуйте!");
                Console.ForegroundColor = ConsoleColor.Black;

                ExecuteArrayTask();//запуск основного алгоритма решения задачи

                Console.Write("\nХотите запустить программу повторно? (да / нет): ");//многократное повторение программы
                string answer = Console.ReadLine();
                while (answer != "да" && answer != "нет")
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Такого варианта ответа нет!");
                    Console.ForegroundColor = ConsoleColor.Black;
                    Console.WriteLine("Попробуйте еще раз");
                    Console.Write("\nХотите запустить программу повторно? (да / нет): ");
                    answer = Console.ReadLine();
                }
                if (answer == "нет")
                {
                    continueProgram = false;
                }
            }
            Console.WriteLine("\nПрограмма завершена");
            Console.ReadKey();
        }
        static void ExecuteArrayTask()
        {
            try
            {
                int[] array = new int[10];
                Console.WriteLine("Выберите способ задания значений массива:");
                Console.WriteLine("1 - Ввод пользователя с клавиатуры");
                Console.WriteLine("2 - Генерация случайных чисел в заданном пользователем диапозоне");
                Console.Write("Ваш выбор: ");
                string choice = Console.ReadLine();
                if (choice == "1")
                {
                    FillArrayManually(array);
                }
                else if (choice == "2")
                {
                    FillArrayRandomly(array);
                }
                else
                {
                    throw new Exception("Выбран несуществующий вариант заполнения массива!");
                }
                Console.WriteLine("\nТекущий массив: [" + string.Join(", ", array) + "]");//соединение элементов массива строк
                CalculateSumElements(array);
            }
            catch (FormatException fex)
            {
                HandleError(fex);
            }
            catch (StackOverflowException sofex)
            {
                HandleError(sofex);
            }
            catch (IndexOutOfRangeException ioorex)
            {
                HandleError(ioorex);
            }
            catch (Exception ex)
            {
                HandleError(ex);
            }
        }
        static void FillArrayManually(int[] array)//ввод пользователя с клавиатуры
        {
            Console.WriteLine($"\nВведите {array.Length} целых чисел:");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"Элемент [{i + 1}]: ");
                string input = Console.ReadLine();
                if (!int.TryParse(input, out array[i]))
                {
                    throw new FormatException("Должно быть введено целое число!");
                }
            }
        }
        static void FillArrayRandomly(int[] array)//генерация случайных чисел в заданном пользователем диапозоне
        {
            Console.Write("\nВведите начало диапозона (минимальное число): ");
            if (!int.TryParse(Console.ReadLine(), out int min))
                throw new FormatException("Не является целым числом");
            Console.Write("\nВведите конец диапозона (максимальное число): ");
            if (!int.TryParse(Console.ReadLine(), out int max))
                throw new FormatException("Не является целым числом");
            if (min > max)
            {
                throw new ArgumentException("Начало диапозона не может быть больше его конца!");
            }
            Random rnd = new Random();
            for(int i = 0;i<array.Length;i++)
            {
                array[i] = rnd.Next(min, max + 1);
            }
        }
        static void CalculateSumElements(int[] array)//сумма
        {
            Console.Write("\nВведите порядковый номер 1-го элемента (от 1 до 10): ");
            string input1 = Console.ReadLine();
            Console.Write("\nВведите порядковый номер 2-го элемента (от 1 до 10): ");
            string input2 = Console.ReadLine();
            if (!int.TryParse (input1, out int num1) || !int.TryParse(input2, out int num2))//num1 и num2 - номер элемента
            {
                throw new FormatException("Введенные порядковые номера не являются числами!");
            }
            int index1 = num1 - 1;//перевод из номеров в индексы
            int index2 = num2 - 1;
            if (index1 < 0 || index1 >= array.Length || index2 < 0 || index2 >= array.Length)//проверка индексов
            {
                throw new IndexOutOfRangeException($"Номера элементов выходят за рамки размера массива! Допустимо от 1 до {array.Length}!");
            }
            int sum = array[index1] + array[index2];
            Console.WriteLine($"\nРезультат: сумма {num1}-го и {num2}-го элементов равна {sum}");
        }
        static void HandleError(Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("0шибка: " + ex.Message);
            Console.ForegroundColor = ConsoleColor.Black;
        }
    }
}
