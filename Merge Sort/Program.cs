using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Merge_Sort
{
    class Program
    {
        static public void DoMerge(int[] numbers, int left, int mid, int right)
        {
            int[] temp = new int[25];
            int i, left_end, num_elements, tmp_pos;

            left_end = (mid - 1);
            tmp_pos = left;
            num_elements = (right - left + 1);

            while ((left <= left_end) && (mid <= right))
            {
                if (numbers[left] <= numbers[mid])
                    temp[tmp_pos++] = numbers[left++];
                else
                    temp[tmp_pos++] = numbers[mid++];
            }

            while (left <= left_end)
                temp[tmp_pos++] = numbers[left++];

            while (mid <= right)
                temp[tmp_pos++] = numbers[mid++];

            for (i = 0; i < num_elements; i++)
            {
                numbers[right] = temp[right];
                right--;
            }
        }

        static public void MergeSort_Recursive(int[] numbers, int left, int right)
        {
            int mid;

            if (right > left)
            {
                mid = (right + left) / 2;
                MergeSort_Recursive(numbers, left, mid);
                MergeSort_Recursive(numbers, (mid + 1), right);

                DoMerge(numbers, left, (mid + 1), right);
            }
        }

        public static void DisplayInitialArray(int[] arr)
        {
            int max = arr.Max() - 1;

            for (int i = 0; i < arr.Length; i++)
            {
                if (i < max)
                    Console.Write("{0}, ", arr[i]);
                else
                    Console.Write("{0}", arr[i]);
            }
            Console.WriteLine(" ");
        }

        static void Main(string[] args)
        {
            int[] numbers = { 3, 8, 7, 5, 2, 1, 9, 6, 4 };
            int len = 9;
            Console.WriteLine("Initial List of Numbers ");
            DisplayInitialArray(numbers);
            Console.Write("");
            Console.WriteLine("");

            Console.WriteLine("MergeSort By Recursive Method");
            MergeSort_Recursive(numbers, 0, len - 1);
            for (int i = 0; i < 9; i++)
            {
                Console.Write(numbers[i]);
                if (i < 8)
                    Console.Write(", ");
            }
            Console.Read();
        }
    }
}
