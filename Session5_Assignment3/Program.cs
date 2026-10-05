namespace Session5_Assignment3
{
    //---------------- Question 2 ------------
    class Person
    {
        public string Name { get; set; }
    }

    //----------------------------------- Enum and Struct -----------------------------------
    //---------------- Question 1 ------------
    public enum WeekDays
    {
        Monday, Tuesday, Wednesday, Thursday, Friday, Saturday, Sunday
    }
    //---------------- Question 2 ------------
    struct Persons
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Persons(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    //---------------- Question 3 ------------
    public enum Seasons
    {
        Spring, Summer, Autumn, Winter
    }
    //---------------- Question 4 ------------
    [Flags]
    public enum Permissions
    {
        None = 0,Read = 1,Write = 2,Delete = 4,Execute = 8
    }
    //---------------- Question 5 ------------
    public enum Colors
    {
        Red,Green, Blue
    }
    //---------------- Question 6 ------------
    public struct MyPoint
    {
        public double Z { get; set; }
        public double F { get; set; }

        public MyPoint(double z, double f)
        {
            Z = z;
            F = f;
        }
        public double DistanceTo(MyPoint target)
        {
            double deltaZ = target.Z - Z;
            double deltaF = target.F - F;
            return Math.Sqrt(deltaZ * deltaZ + deltaF * deltaF);
        }
    }
    //---------------- Question 7 ------------
    public struct PersonInfo
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public PersonInfo(string name, int age)
        {
            Name = name;
            Age = age;
        }
    }
    internal class Program
    {
        //---------------- Question 1 ------------
        static void PassByValue(int num)
        {
            num = 100;
        }
        static void PassByRef(ref int num)
        {
            num = 100;
        }
        //---------------- Question 2 ------------
        static void PassRefByValue(Person p)
        {
            p = new Person { Name = "Omar" };
            Console.WriteLine($"in PassRefByValue : {p.Name}");
        }
        static void PassRefByRef(ref Person p)
        {
            p = new Person { Name = "Mona" };
            Console.WriteLine($"in PassRefByRef: {p.Name}");
        }
        //---------------- Question 3 ------------
        static (int Sum, int Sub) SumAndSubtract(int a, int b, int c, int d)
        {
            int sum = a + b + c + d;
            int sub = a - b - c - d;
            return (sum, sub);
        }
        //---------------- Question 4 ------------
        static int SumOfDigits(int number)
        {
            int sum = 0;
            while (number != 0)
            {
                sum += number % 10;
                number /= 10;
            }
            return sum;
        }
        //---------------- Question 5 ------------
        static bool IsPrime(int number)
        {
            if (number < 2)
                return false;

            for (int i = 2; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                    return false;
            }

            return true;
        }
        //---------------- Question 6 ------------
        static void MinMaxArray(int[] arr, ref int min, ref int max)
        {
            min = arr[0];
            max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] < min)
                    min = arr[i];
                if (arr[i] > max)
                    max = arr[i];
            }
        }
        //---------------- Question 7 ------------
        static long CalculateFactorial(int num)
        {
            if (num < 0) return 0; 
            if (num == 0 || num == 1) return 1;
            long result = 1;
            for (int i = 2; i <= num; i++)
            {
                result *= i;
            }

            return result;
        }
        //---------------- Question 8 ------------
        static string ChangeChar(string str, int index, char newChar)
        {
            if (string.IsNullOrEmpty(str) || index < 0 || index >= str.Length)
            {
                return str;
            }
            char[] charArray = str.ToCharArray();
            charArray[index] = newChar;
            return new string(charArray);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("------------------------------------------------------- Functions -------------------------------------------------------");
            Console.WriteLine("------------------------------ Question 1 ------------------------------");
            //* Difference between passing (Value type parameters) by value and by reference
            Console.WriteLine("* Passing Value Type parameters:");
            Console.WriteLine("1. By Value (Default): Pass a copy of the variable. Changes inside the function do NOT affect the original variable.");
            Console.WriteLine("2. By Reference (using ref): Pass the memory address of the variable. Changes inside the function DO affect the original variable.");
            Console.WriteLine("\n--- Example Output ---");
            int number = 10;
            Console.WriteLine($"Original Value of number: {number}");
            // Testing Pass By Value
            PassByValue(number);
            Console.WriteLine($"After PassByValue function: {number}");
            // Testing Pass By Reference
            PassByRef(ref number);
            Console.WriteLine($"After PassByRef function: {number}");

            Console.WriteLine("\n------------------------------ Question 2 ------------------------------");
            //* Difference between passing (Reference type parameters) by value and by reference
            Console.WriteLine("* Passing Reference Type parameters:");
            Console.WriteLine("1. By Value (Default): Pass a copy of the reference. Modifying object properties affects original, but reassigning (new) does NOT.");
            Console.WriteLine("2. By Reference (using ref): Pass the original reference. Reassigning the object (new) inside function DOES affect the original variable.");
            //* Example Demonstration
            Console.WriteLine("\n--- Example Output ---");
            Person p1 = new Person { Name = "Ali" };
            Console.WriteLine($"Original Person Name: {p1.Name}");
            // Testing Pass Reference Type By Value
            PassRefByValue(p1);
            Console.WriteLine($"After PassRefByValue function: {p1.Name}"); //
            // Testing Pass Reference Type By Reference
            PassRefByRef(ref p1);
            Console.WriteLine($"After PassRefByRef function: {p1.Name}");

            Console.WriteLine("\n------------------------------ Question 3 ------------------------------");
            Console.WriteLine("* Enter 4 numbers to calculate Summation and Subtraction:");
            Console.Write("Enter First Number: ");
            int num1 = int.Parse(Console.ReadLine());
            Console.Write("Enter Second Number: ");
            int num2 = int.Parse(Console.ReadLine());
            Console.Write("Enter Third Number: ");
            int num3 = int.Parse(Console.ReadLine());
            Console.Write("Enter Fourth Number: ");
            int num4 = int.Parse(Console.ReadLine());
            // Calling Function with User Inputs
            var result = SumAndSubtract(num1, num2, num3, num4);
            Console.WriteLine($"Summation Result: {result.Sum}");
            Console.WriteLine($"Subtraction Result: {result.Sub}");

            Console.WriteLine("\n------------------------------ Question 4 ------------------------------");
            Console.WriteLine("* Enter a number to calculate the sum of its digits:");
            Console.Write("Enter a number: ");
            int  SumNun = int.Parse(Console.ReadLine());
            int sumOfDigits = SumOfDigits(SumNun);
            Console.WriteLine($"The sum of the digits of the number {SumNun} is: {sumOfDigits}");

            Console.WriteLine("\n------------------------------ Question 5 ------------------------------");
            Console.WriteLine("* Enter a number to check if it is prime:");
            Console.Write("Enter a number: ");
            int Pnum = int.Parse(Console.ReadLine());
            Console.WriteLine(IsPrime(Pnum));

            Console.WriteLine("\n------------------------------ Question 6 ------------------------------");
            Console.WriteLine("* find Minimum and Maximum values array elements:");
            int[] numbers = { 10, 5, 20, 3, 15 };
            int min = 0;
            int max = 0;
            MinMaxArray(numbers, ref min, ref max);
            Console.WriteLine("Minimum value = " + min);
            Console.WriteLine("Maximum value = " + max);

            Console.WriteLine("\n------------------------------ Question 7 ------------------------------");
            Console.WriteLine("* Calculating Factorial of a number:");
            int numberToFactorial = 5;
            long factorialResult = CalculateFactorial(numberToFactorial);
            Console.WriteLine($"Factorial of {numberToFactorial} ({numberToFactorial}!) = {factorialResult}");

            Console.WriteLine("\n------------------------------ Question 8 ------------------------------");
            Console.WriteLine("* Modifying a character inside a string:");
            string text = "Hello World";
            int position = 6;
            char newLetter = 'C';
            string modifiedText = ChangeChar(text, position, newLetter);
            Console.WriteLine($"Modified String: \"{modifiedText}\"");

            Console.WriteLine("\n------------------------------------------------------- Enum & Struct  -------------------------------------------------------");
            Console.WriteLine("\n------------------------------ Question 1 ------------------------------");
            Console.WriteLine("* Days of the week from WeekDays Enum:\n");
            foreach (WeekDays day in Enum.GetValues(typeof(WeekDays)))
            {
                Console.WriteLine($"- {day}");
            }

            Console.WriteLine("\n------------------------------ Question 2 ------------------------------");
            Console.WriteLine("* Displaying details of Person objects:");
            Persons[] persons = new Persons[3]
            {
                new Persons("Ahmed", 25),
                new Persons("Sara", 22),
                new Persons("Omar", 30)
            };
            for (int i = 0; i < persons.Length; i++)
            {
                Console.WriteLine($"Person {i + 1}: Name = {persons[i].Name}, Age = {persons[i].Age}");
            }

            Console.WriteLine("\n------------------------------ Question 3 ------------------------------");
            Console.WriteLine("* Enter a Season name (Spring, Summer, Autumn, Winter):");
            Console.Write("Enter Season: ");
            string seasonInput = Console.ReadLine();
            if (Enum.TryParse(seasonInput, true, out Seasons season))
            {
                switch (season)
                {
                    case Seasons.Spring:
                        Console.WriteLine("Spring month range: March to May");
                        break;
                    case Seasons.Summer:
                        Console.WriteLine("Summer month range: June to August");
                        break;
                    case Seasons.Autumn:
                        Console.WriteLine("Autumn month range: September to November");
                        break;
                    case Seasons.Winter:
                        Console.WriteLine("Winter month range: December to February");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid Season name entered!");
            }

            Console.WriteLine("\n------------------------------ Question 4 ------------------------------");
            Console.WriteLine("* Managing Permissions using Flags Enum:\n");
            Permissions myPermissions = Permissions.Read | Permissions.Write;
            Console.WriteLine($"Initial Permissions: {myPermissions}");
            myPermissions |= Permissions.Execute;
            Console.WriteLine($"After Adding Execute: {myPermissions}");
            myPermissions &= ~Permissions.Write;
            Console.WriteLine($"After Removing Write: {myPermissions}");
            bool hasRead = (myPermissions & Permissions.Read) == Permissions.Read;
            Console.WriteLine($"Does it have Read permission? {hasRead}");

            Console.WriteLine("\n------------------------------ Question 5 ------------------------------");
            Console.WriteLine("* Enter a Color name (e.g., Red, Green, Blue, Yellow):");
            Console.Write("Enter Color: ");
            string colorInput = Console.ReadLine();
            if (Enum.TryParse(colorInput, true, out Colors color))
            {
                Console.WriteLine($"{color} is a primary color.");
            }
            else
            {
                Console.WriteLine($"{colorInput} is NOT a primary color.");
            }

            Console.WriteLine("\n------------------------------ Question 6 ------------------------------");
            Console.WriteLine("* Calculating Distance Between Two Points using Struct:\n");
            Console.WriteLine("Enter coordinates for Point 1:");
            Console.Write("Z1: ");
            double.TryParse(Console.ReadLine(), out double z1);
            Console.Write("F1: ");
            double.TryParse(Console.ReadLine(), out double f1);
            MyPoint pt1 = new MyPoint(z1, f1);
            Console.WriteLine("\nEnter coordinates for Point 2:");
            Console.Write("Z2: ");
            double.TryParse(Console.ReadLine(), out double z2);
            Console.Write("F2: ");
            double.TryParse(Console.ReadLine(), out double f2);
            MyPoint pt2 = new MyPoint(z2, f2);
            double distance = pt1.DistanceTo(pt2);
            Console.WriteLine($"\nThe distance between Point 1 ({pt1.Z}, {pt1.F}) and Point 2 ({pt2.Z}, {pt2.F}) is: {distance:F2}");

            Console.WriteLine("\n------------------------------ Question 7 ------------------------------");
            Console.WriteLine("* Find the Oldest Person:\n");
            PersonInfo[] peopleList = new PersonInfo[3];
            for (int i = 0; i < 3; i++)
            {
                Console.WriteLine($"Enter details for Person {i + 1}:");
                Console.Write("Name: ");
                string nameInput = Console.ReadLine();
                Console.Write("Age: ");
                int.TryParse(Console.ReadLine(), out int ageInput);
                peopleList[i] = new PersonInfo(nameInput, ageInput);
                Console.WriteLine();
            }
            PersonInfo oldestPerson = peopleList[0];

            for (int i = 1; i < peopleList.Length; i++)
            {
                if (peopleList[i].Age > oldestPerson.Age)
                {
                    oldestPerson = peopleList[i];
                }
            }
            Console.WriteLine($"The oldest person is {oldestPerson.Name} with age {oldestPerson.Age}.");

            Console.ReadLine();
        }

    }
}
