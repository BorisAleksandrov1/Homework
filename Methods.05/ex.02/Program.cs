using System.Numerics;
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
                        arr = Exchange(arr, index);
                        Console.WriteLine(String.Join(" ", arr)); 
                        break;

                    case "max":
                        int maxEven = MaxEven(arr);
                        int maxOdd = MaxOdd(arr);

                        bool isEven;
                        if (command[1] == "even")
                        isEven = true;
                        else
                        isEven = false;


                        if (isEven)
                        {
                            if (maxEven == -1)
                            {
                                Console.WriteLine("No matches");
                                break;
                            }
                            Console.WriteLine(maxEven);
                        } 
                        else
                        {
                            if (maxOdd == -1)
                            {
                                Console.WriteLine("No matches");
                                break;
                            }
                            Console.WriteLine(maxOdd);
                        }
                        break;

                    case "min":
                        int minEven = MinEven(arr);
                        int minOdd = MinOdd(arr);

                        if (command[1] == "even")
                            isEven = true;
                        else
                            isEven = false;


                        if (isEven)
                        {
                            if (minEven == -1)
                            {
                                Console.WriteLine("No matches");
                                break;
                            }
                            Console.WriteLine(minEven);
                        }
                        else
                        {
                            if (minOdd == -1)
                            {
                                Console.WriteLine("No matches");
                                break;
                            }
                            Console.WriteLine(minOdd);
                        }
                        break;

                    case "first":
                        int count = int.Parse(command[1]);

                        if (command[2] == "even")
                            isEven = true;
                        else
                            isEven = false;

                        if (count > arr.Length)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }

                        if (isEven)
                        {
                            int[] result = FirstEven(arr, count);
                            Console.WriteLine("[" + string.Join(",", result) + "]");
                        }
                        else
                        {
                            int[] result = FirstOdd(arr, count);
                            Console.WriteLine("[" + string.Join(",", result) + "]");
                        }
                        break;
                    case "last":
                        count = int.Parse(command[1]);

                        if (command[2] == "even")
                            isEven = true;
                        else
                            isEven = false;

                        if (count > arr.Length)
                        {
                            Console.WriteLine("Invalid count");
                            break;
                        }

                        if (isEven)
                        {
                            int[] result = LastEven(arr, count);
                            Console.WriteLine("[" + string.Join(",", result) + "]");
                        }
                        else
                        {
                            int[] result = LastOdd(arr, count);
                            Console.WriteLine("[" + string.Join(",", result) + "]");
                        }
                        break;
                }
            }
        }

        static int[] Exchange(int[] arr, int index)
        {
            for(int i = 0; i < index; i++)
            {
                int temp = arr[0];
                for (int j = 1; j < arr.Length; j++)
                {
                    arr[j - 1] = arr[j];
                }
                arr[arr.Length - 1] = temp;
            }
            return arr;
        }

        static int MaxEven(int[] arr)
        {
           int max = arr.Max(x => x);
           List<int> numbers = new List<int>();
           for (int i = 0;i < arr.Length;i++)
            {
                if (arr[i] % 2 == 0)
                {
                    numbers.Add(arr[i]);
                }
            }
           int index = numbers.FindLastIndex(x => x == max);
           return index;
        }
        
        static int MaxOdd(int[] arr)
        {
           int max = arr.Max(x => x);
           List<int> numbers = new List<int>();
           for (int i = 0;i < arr.Length;i++)
            {
                if (arr[i] % 2 != 0)
                {
                    numbers.Add(arr[i]);
                }
            }
           int result = numbers.FindLastIndex(x => x == max);
           if (result == -1)
            {

            }
           return result;
        }
           static int MinEven(int[] arr)
        {
           int min = arr.Min(x => x);
           List<int> numbers = new List<int>();
           for (int i = 0;i < arr.Length;i++)
            {
                if (arr[i] % 2 == 0)
                {
                    numbers.Add(arr[i]);
                }
            }
           int result = numbers.FindLastIndex(x => x == min);
           return result;
        }
        
        static int MinOdd(int[] arr)
        {
           int min = arr.Min(x => x);
           List<int> numbers = new List<int>();
           for (int i = 0;i < arr.Length;i++)
            {
                if (arr[i] % 2 != 0)
                {
                    numbers.Add(arr[i]);
                }
            }
           int result = numbers.FindLastIndex(x => x == min);
           return result;
        }

        static int[] FirstEven(int[] arr, int count)
        { 
            int timesRepeated = 0;
            int[] result = new int[count];
            for(int i = 0; i < arr.Length && timesRepeated < count; i++)
            {
                if (arr[i] % count == 0)
                {
                    result[timesRepeated] = arr[i];
                    timesRepeated++;
                }
            }
            return result;
        }
        static int[] FirstOdd(int[] arr, int count)
        { 
            int timesRepeated = 0;
            int[] result = new int[count];
            for(int i = 0; i < arr.Length && timesRepeated < count; i++)
            {
                if (arr[i] % count != 0)
                {
                    result[timesRepeated] = arr[i];
                    timesRepeated++;
                }
            }
            return result;
        }
        static int[] LastEven(int[] arr, int count)
        { 
            int timesRepeated = 0;
            int[] result = new int[count];
            for(int i = arr.Length - 1; 0 < i && timesRepeated < count; i--)
            {
                if (arr[i] % count == 0)
                {
                    result[timesRepeated] = arr[i];
                    timesRepeated++;
                }
            }
            return result;
        }
        static int[] LastOdd(int[] arr, int count)
        { 
            int timesRepeated = 0;
            int[] result = new int[count];
            for(int i = arr.Length - 1; 0 < i && timesRepeated < count; i--)
            {
                if (arr[i] % count != 0)
                {
                    result[timesRepeated] = arr[i];
                    timesRepeated++;
                }
            }
            return result;
        }

        

    }
