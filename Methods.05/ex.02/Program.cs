using System;

namespace ex02
{
    class Program
    {
        static void Main(string[] args)
        {
            string cmd = Console.ReadLine();
            int[] arr = cmd
            .Split(" ")
            .Select(int.Parse)
            .ToArray();
            
            while (cmd != "end")
            {
                cmd = Console.ReadLine();
                string[] command = cmd.Split(" ");

                switch (command[0]) 
                {
                    case "exchange":
                        int index = int.Parse(command[1]);
                        Exchange(arr, index);
                        Console.WriteLine("[" + string.Join(", ", arr) + "]");
                        break;

                    case "max":
                        int maxReturn = 0;
                        maxReturn = MaxValue(arr, command[1]);
                        Console.WriteLine(maxReturn);
                        //working
                        break;

                    case "min":
                        int minReturn = 0;
                        minReturn = MinValue(arr, command[1]);
                        Console.WriteLine(minReturn);
                        //working
                        break;

                    case "first":
                        int countFirst = int.Parse(command[1]);
                        string resultFirst = PrintFirst(arr, command[2], countFirst);
                        Console.WriteLine(resultFirst);
                        //working
                        break;
                    case "last":
                        int countLast = int.Parse(command[1]);
                        string resultLast = PrintLast(arr, command[2], countLast);
                        Console.WriteLine(resultLast);
                        break;
                }
            }
        }

        static int MaxValue(int[] arr, string oddOrEven)
        {
            int indexOdd = 1;
            int indexEven = 1;
            int minOdd = int.MinValue;
            int minEven = int.MinValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (arr[i] > minOdd)
                    {
                        minOdd = arr[i];
                    }
                }
                else
                {
                    if (arr[i] > minEven)
                    {
                       minEven = arr[i];
                    }
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (minEven == arr[i])
                {
                    indexEven += i;
                }
                else if(minOdd == arr[i])
                {
                    indexOdd += i;
                }
            }

            if (oddOrEven == "even")
            {
                return indexEven;
            }
            else
            {
                return indexOdd;
            }
        
        }static int MinValue(int[] arr, string oddOrEven)
        {
            int indexOdd = 1;
            int indexEven = 1;
            int maxOdd = int.MaxValue;
            int maxEven = int.MaxValue;
            for (int i = 0; i < arr.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (arr[i] < maxOdd)
                    {
                        maxOdd = arr[i];
                    }
                }
                else
                {
                    if (arr[i] < maxEven)
                    {
                       maxEven = arr[i];
                    }
                }
            }

            for (int i = 0; i < arr.Length; i++)
            {
                if (maxEven == arr[i])
                {
                    indexEven += i;
                }
                else if(maxOdd == arr[i])
                {
                    indexOdd += i;
                }
            }

            if (oddOrEven == "even")
            {
                return indexEven;
            }
            else
            {
                return indexOdd;
            }
        }

        static string PrintFirst(int[] arr,string oddOrEven,int count)
        {
            if (count > arr.Length)
            {
                return "Invalid count";
            }

            string result = "[";
            int num = 0;
            int addedElements = 0;
            bool isOdd = false;

            if (oddOrEven == "odd")
            {
                isOdd = true;
            }

            if(!isOdd)
            {
                num = 1;
            }

            for(int i = num;i < arr.Length;i += 2)
            { 
                result += arr[i];
                addedElements++;
                if (addedElements < count)
                {
                result += ", ";
                }
                else if (addedElements == count)
                {
                    result += "]";
                    return result;
                }
            }

            if (addedElements == 0)
            {
                return "[]";
            }

            result += "]";
            return result;
        }


        static string PrintLast(int[] arr, string oddOrEven, int count)
        {
            if (count > arr.Length)
            {
                return "Invalid count";
            }

            string result = "[";
            int num = arr.Length - 1;
            int addedElements = 0;
            bool isOdd = false;

            if (oddOrEven == "odd")
            {
                isOdd = true;
            }

            if (!isOdd)
            {
                num = arr.Length;
            }

            for (int i = num; i > 0; i -= 2)
            {
                result += arr[i - 1];
                addedElements++;
                if (addedElements < count)
                {
                    result += ", ";
                }
                else if (addedElements == count)
                {
                    result += "]";
                    return result;
                }
            }

            if (addedElements == 0)
            {
                return "[]";
            }

            result += "]";
            return result;
        }

        static void Exchange(int[] arr, int index)
        {
            if (index < 0 || index >= arr.Length - 1)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            int[] tempArray = new int[arr.Length];
            int secondPartStart = index + 1;
            int pos = 0;

            for (int i = secondPartStart; i < arr.Length; i++)
            {
                tempArray[pos] = arr[i];
                pos++;
            }

            for (int i = 0; i <= index; i++)
            {
                tempArray[pos] = arr[i];
                pos++;
            }

            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = tempArray[i];
            }
        }



    }
}