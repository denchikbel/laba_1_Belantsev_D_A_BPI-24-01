using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace ConsoleApp1
{
    class Program2
    {
        static int[] RadixSort(int[] array)
        {
            int kol = array.Length;
            int[] result = new int[kol];
            int max = array.Max();
            for (int exp = 1; max / exp > 0; exp *= 10)
            {
                int[] output = new int[array.Length];
                int[] count = new int[10];

                for (int i = 0; i < array.Length; i++)
                {
                    int digit = array[i] / exp % 10;
                    count[digit]++;
                }
                    

                for (int i = 1; i < 10; i++)
                    count[i] += count[i - 1];

                for (int i = array.Length - 1; i >= 0; i--)
                {
                    int digit = array[i] / exp % 10;
                    output[--count[digit]] = array[i];
                }

                for (int i = 0; i < array.Length; i++)
                    array[i] = output[i];

                result = output;
            }
            return result;
        }



        public static int[] ShellSort(int[] arr)
        {
            int n = arr.Length;

            for (int gap = n / 2; gap > 0; gap /= 2)
            {
                for (int i = gap; i < n; i++)
                {
                    int temp = arr[i];
                    int j;

                    for (j = i; j >= gap && arr[j - gap] > temp; j -= gap)
                    {
                        arr[j] = arr[j - gap];
                    }

                    arr[j] = temp;
                }
            }
            return arr;
        }
        

        static int[] MergeSort(int[] arr)
        {
            if (arr.Length <= 1) return arr;

            int mid = arr.Length / 2;

            int[] left = new int[mid];
            for (int i = 0; i < mid; i++)
                left[i] = arr[i];

            int[] right = new int[arr.Length - mid];
            for (int i = mid; i < arr.Length; i++)
                right[i - mid] = arr[i];

            left = MergeSort(left);
            right = MergeSort(right);

            return Merge(left, right);
        }

        static int[] Merge(int[] left, int[] right)
        {
            int[] result = new int[left.Length + right.Length];
            int i = 0, j = 0, k = 0;

            while (i < left.Length && j < right.Length)
                result[k++] = left[i] < right[j] ? left[i++] : right[j++];

            while (i < left.Length) result[k++] = left[i++];
            while (j < right.Length) result[k++] = right[j++];

            return result;
        }

        
        static int get_value(string message)
        {
     
            int number = -1;
            bool flag = false;
            while (!flag)
            {
                Console.Write(message);
                string data = Console.ReadLine();
                try
                {
                    number = int.Parse(data);
                    if (number > 0)
                        flag = true;
                    else
                        Console.WriteLine("Число должно быть больше 0");
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            return number;
        }

        static void Main(string[] args)
        {
            int n = get_value("Введите длинну массива\n");
            int x = get_value("Введите минимальный элемент массива\n");
            int y = get_value("Введите максимальный элемент массива\n");

            int[] radix_m = new int[n];
            int[] shel_m = new int[n];
            int[] mer_s = new int[n];
            
            
;
            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                int element = rnd.Next(x, y);

                radix_m[i] = element;
            }
            Array.Copy(radix_m, radix_m, radix_m.Length);
            Array.Copy(radix_m, shel_m, radix_m.Length);
            Array.Copy(radix_m, mer_s, radix_m.Length);
            if (n < 50)
                Console.WriteLine("исходный массив: " + string.Join(", ", radix_m));
            else
                Console.WriteLine("длинна массива больше или равна 50 (не буду выводить)");
            Stopwatch stpwatch = new Stopwatch();
            //Radix Sort
            stpwatch.Start();
            int[] radix_result = RadixSort(radix_m);
            stpwatch.Stop();
            if (n < 50)
                Console.WriteLine("результат RadixSort : " + string.Join(" ", radix_result));
            Console.WriteLine("Время работы алгоритма поразраядной сортировки: " + stpwatch.Elapsed.TotalMilliseconds.ToString());

            //ShellSort
            stpwatch.Reset();
            stpwatch.Start();
            int[] ShellSort_result = ShellSort(shel_m);
            stpwatch.Stop();
            if (n < 50)
                Console.WriteLine("результат ShellSort : " + string.Join(" ", ShellSort_result));
            Console.WriteLine("Время работы алгоритма сортировки выбором: " + stpwatch.Elapsed.TotalMilliseconds.ToString());

            //MergeSort
            stpwatch.Reset();
            stpwatch.Start();
            int[] piramid_resilt = MergeSort(mer_s);
            stpwatch.Stop();
            if (n < 50)
                Console.WriteLine("результат MergeSort: " + string.Join(" ", piramid_resilt));
            Console.WriteLine("Время работы алгоритма сортировки слиянием: " + stpwatch.Elapsed.TotalMilliseconds.ToString());
            Console.ReadKey();
        }
    }
}