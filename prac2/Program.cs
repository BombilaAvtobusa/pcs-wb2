using System;
using System.ComponentModel.Design;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;

namespace ConsoleMenuApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool exit = false;

            while (!exit)
            {
                Console.Clear();
                Console.WriteLine("=== Меню ===");
                Console.WriteLine("1. Ряд Маклорена");
                Console.WriteLine("2. Счастливый билет");
                Console.WriteLine("3. Несокращаемая дробь");
                Console.WriteLine("4. Угадай число(Акинатор)");
                Console.WriteLine("5. Кофе-машина");
                Console.WriteLine("6. Эксперимент");
                Console.WriteLine("7. Пункт 7");
                Console.WriteLine("8. Выход");
                Console.Write("Выберите пункт меню (1-8): ");

                string input = Console.ReadLine();

                if (int.TryParse(input, out int choice))
                {
                    switch (choice)
                    {
                        case 1:
                            task_1();
                            break;
                        case 2:
                            task_2();
                            break;
                        case 3:
                            task_3();
                            break;
                        case 4:
                            task_4();
                            break;
                        case 5:
                            task_5();
                            break;
                        case 6:
                            task_6();
                            break;
                        case 7:
                            task_7();
                            break;
                        case 8:
                            Exit();
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Ошибка: выберите число от 1 до 8.");
                            break;
                    }
                }
                else
                {
                    Console.WriteLine("Ошибка: введите корректное число.");
                }

                if (!exit)
                {
                    Console.WriteLine("\nНажмите любую клавишу для возврата в меню...");
                    Console.ReadKey();
                }
            }
        }

        static void task_1()
        {
            Console.WriteLine("Введите x:");
            double x = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите точность (e < 0.01):");
            double epsilon = double.Parse(Console.ReadLine());
            if (epsilon >= 0.01)
            {
                Console.WriteLine("Точность должна быть меньше 0.01");
                return;
            }
            Console.WriteLine("Введите номер члена последовательности(при больших числах появляется погрешность)");
            int n = int.Parse(Console.ReadLine());
            void GetNthTerm(double x, int n)
            {
                Console.WriteLine("N-ый член последовательности arctg x:");
                Console.WriteLine(Math.Pow(-1, n) * Math.Pow(x, 2 * n + 1) / (2 * n + 1));
            }
            void CalculateSeries(double x, double epsilon)
            {
                if (Math.Abs(x) > 1.0)
                {
                    throw new ArgumentException("Ряд Маклорена для arctan(x) сходится только при |x| <= 1.", nameof(x));
                }

                double sum = 0.0;
                int n = 0;

                while (true)
                {
                    double term = Math.Pow(x, 2 * n + 1) / (2 * n + 1);
                    if (n % 2 == 1)
                        term = -term;
                    sum += term;
                    if (Math.Abs(term) < epsilon)
                        break;

                    n++;
                }
                Console.WriteLine("Сумма ряда с точностью e:");
                Console.WriteLine(sum);
            }
            GetNthTerm(x, n);
            CalculateSeries(x, epsilon);
        }

        static void task_2()
        {
            Console.Write("Введите шестизначный номер билета: ");
            string ticket = Console.ReadLine();
            if (ticket.Length != 6)
            {
                Console.WriteLine("Ошибка: введите корректный шестизначный номер");
                return;
            };
            int[] digits = new int[6];
            for (int i = 0; i < 6; i++)
            {
                digits[i] = int.Parse(ticket[i].ToString());
            }
            int sumFirst = digits[0] + digits[1] + digits[2];
            int sumLast = digits[3] + digits[4] + digits[5];
            if (sumFirst == sumLast)
            {
                Console.WriteLine("Билет счастливый!");
            }
            else
            {
                Console.WriteLine("Билет обычный.");
            }
        }

        static void task_3()
        {
            Console.WriteLine("Введите число M");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите число N");
            int n = int.Parse(Console.ReadLine());
            int FindGCD(int a, int b)
            {
                while (b != 0)
                {
                    int temp = b;
                    b = a % b;
                    a = temp;
                }
                return a;
            }
            int gcd = FindGCD(m, n);
            int number = m / gcd;
            int devider = n / gcd;
            Console.WriteLine($"{number} / {devider} - несократимая дробь");

        }

        static void task_4()
        {
            {
                Console.WriteLine("Загадайте число от 0 до 63.");
                Console.WriteLine("Отвечайте '1' (да) или '0' (нет) на мои вопросы.");
                int lower = 0;
                int upper = 63;
                int[] masks = { 32, 16, 8, 4, 2, 1 };
                int result = 0;

                foreach (int mask in masks)
                {
                    Console.Write($"Ваше число больше или равно {lower + mask}? (1/0): ");
                    string answer = Console.ReadLine();
                    if (answer == "1")
                    {
                        result |= mask; 
                        lower += mask;
                    }
                    else
                    {
                        upper = lower + mask - 1;
                    }
                }
                Console.WriteLine("Ваше число:", result);
                Console.WriteLine("Я угадал?");
            }
        }

        static void task_5(){

            const int AMERICANO_WATER = 300; 
            const int LATTE_WATER = 30; 
            const int LATTE_MILK = 270;

            const int AMERICANO_PRICE = 150; 
            const int LATTE_PRICE = 170;

            int water;
            int milk;
            int profit = 0;
            void Start()
            {
                Console.Write("Введите количество воды (мл): ");
                water = int.Parse(Console.ReadLine());

                Console.Write("Введите количество молока (мл): ");
                milk = int.Parse(Console.ReadLine());
                ProcessOrder();
            }
            void ProcessOrder()
            {
                Console.WriteLine("\nВыберите напиток:");
                Console.WriteLine("1 - Американо");
                Console.WriteLine("2 - Латте");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        MakeAmericano();
                        break;
                    case 2:
                        MakeLatte();
                        break;
                    default:
                        Console.WriteLine("Неверный выбор");
                        break;
                }
            }
            void MakeAmericano()
            {
                if (water < AMERICANO_WATER)
                {
                    Console.WriteLine("Недостаточно воды для приготовления Американо");
                }
                else
                {
                    water -= AMERICANO_WATER;
                    Console.WriteLine($"Готовится Американо. Стоимость: {AMERICANO_PRICE} руб.");
                    profit += AMERICANO_PRICE;
                    ShowRemainingResources();
                }
            }
            void MakeLatte()
            {
                if (water >= LATTE_WATER && milk >= LATTE_MILK)
                {
                    water -= LATTE_WATER;
                    milk -= LATTE_MILK;
                    Console.WriteLine($"Готовится Латте. Стоимость: {LATTE_PRICE} руб.");
                    profit += LATTE_PRICE;
                    ShowRemainingResources();
                }
                else
                {
                    Console.WriteLine("Недостаточно ингредиентов для приготовления Латте");
                }
            }
            void ShowRemainingResources()
            {
                Console.WriteLine($"Осталось воды: {water} мл");
                Console.WriteLine($"Осталось молока: {milk} мл");
                if ((water >= LATTE_WATER && milk >= LATTE_MILK)|| (water >= AMERICANO_WATER))
                {
                    ProcessOrder();
                }
                else
                {
                    Console.WriteLine("Ингриденты кончились");
                    Console.WriteLine($"Профит составил: {profit}");
                }
            }
            Start();
        }

        static void task_6()
        {
            Console.Write("Введите количество бактерий (N): ");
            int N = int.Parse(Console.ReadLine());
            Console.Write("Введите количество капель антибиотика (X): ");
            int X = int.Parse(Console.ReadLine());
            int bacteria = N;
            int hours = 0;
            int killPower = X * 10;
            Console.WriteLine("\nДинамика изменения количества бактерий:");
            while (killPower > 0)
            {
                hours++;
                bacteria *= 2;
                bacteria -= killPower;
                killPower -= X; 
                if (bacteria < 0) bacteria = 0;
                Console.WriteLine($"Час {hours}: Бактерий = {bacteria}, Мощность антибиотика = {killPower}");
            }
            Console.WriteLine($"\nПроцесс завершен через {hours} часов");
            Console.WriteLine($"Конечное количество бактерий: {bacteria}");
        }

        static void task_7()
        {
            Console.WriteLine("Введите количество модулей (n): ");
            int n = int.Parse(Console.ReadLine());
            Console.Write("Введите размеры модуля (a b): ");
            string[] input = Console.ReadLine().Split();
            int a = int.Parse(input[0]);
            int b = int.Parse(input[1]);
            Console.Write("Введите размеры поля (h w): ");
            input = Console.ReadLine().Split();
            int h = int.Parse(input[0]);
            int w = int.Parse(input[1]);
            int maxD = CalculateMaxProtection(n, a, b, h, w);
            if (maxD != -1)
            {
                Console.WriteLine($"Максимальная толщина защиты: {maxD}");
            }
            else
            {
                Console.WriteLine("Не может быть размещен");
            };
            int CalculateMaxProtection(int n, int a, int b, int h, int w)
            {
                if (!CanPlaceModules(n, a, b, h, w, 0))
                    return -1;
                int left = 0;
                int right = Math.Min(h, w) / 2;
                int result = 0;
                while (left <= right)
                {
                    int mid = (left + right) / 2;
                    if (CanPlaceModules(n, a, b, h, w, mid))
                    {
                        result = mid;
                        left = mid + 1;
                    }
                    else
                    {
                        right = mid - 1;
                    }
                }
                return result;
            }
            bool CanPlaceModules(int n, int a, int b, int h, int w, int d)
            {
                int aWithD = a + 2 * d;
                int bWithD = b + 2 * d;
                return (h >= aWithD && w >= bWithD && CanFit(n, aWithD, bWithD, h, w)) || (h >= bWithD && w >= aWithD && CanFit(n, bWithD, aWithD, h, w));
            }
            bool CanFit(int n, int a, int b, int h, int w)
            {
                int maxHeight = h / a;
                int maxWidth = w / b;
                return maxHeight * maxWidth >= n;
            }

        }

        static void Exit()
        {
            Console.WriteLine("Завершение работы программы...");
        }
    }
}