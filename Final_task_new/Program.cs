using System;

namespace Final_task_new
{
    class Program
    {
        public class person
        {
            public string name_first = "Dmitry";
            public string name_last = "Filin";
        }
        public class address
        {
            public string Address = "apartment 109";
            public string Street = "Poligrafistov 21";
            public string City = "Chekhov";
           	public string Country = "Russia";

        }
        public class student : person
        {
            public int student_num = 1;
            public int age = 18;
            public address Address = new address();
            public string name_full;
            public int[] scores = {70,66,70,66};
            public int average_score;
            public string full_address;
        }
        public static student calculate(student Student)
        {//Here all the necessary data is calculated for further display to the user.
            Student.name_full = Student.name_first + " " +Student.name_last;
            try
            {
                int i = 0;
                int j = Student.scores.Length - 1;
                int count = 0;
                while (j != 0)//The average value of all the student's scores by adding all the scores and then dividing by the number of grades
                {
                    count += Student.scores[i];
                    i++;
                    j--;
                }
                Student.average_score = count/(Student.scores.Length-1);
            }
            catch
            {
                Student.average_score = 0;
            }
            Student.full_address = Student.Address.Country + " " + Student.Address.City + " " + Student.Address.Street + " " + Student.Address.Address;
            return (Student);
        }

        public static void show_info(student S)//displays information to the user
        {
            Console.WriteLine("Student " + S.name_full + " score is " + S.average_score);
            Console.WriteLine("Student " + S.name_full + " is living in " + S.Address.City);
            Console.WriteLine("Student " + S.name_full + " address is " + S.full_address);
        }

        static public int check_int(int from, int to, int Num)//checks a number within certain limits
        {
            while (true)
            {
                try
                {
                    if (Num == -1)
                    {
                        Num = Convert.ToInt32(Console.ReadLine());
                    }
                    if ((from <= Num) && (to >= Num))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Please enter a number in this range:" + " from " + from + " to " + to);
                        Num = Convert.ToInt32(Console.ReadLine());
                    }
                }
                catch
                {
                    Console.WriteLine("Error, enter only numbers");
                }
            }
            return (Num);
        }

        static public string check_string()//checks if the string is empty
        {
            string String = Console.ReadLine();
            while (true)
            {
                if (String != "")
                {
                    return (String);
                }
                else
                {
                    Console.WriteLine("Empty value");
                    String = Console.ReadLine();
                }
            }
        }

        static public int[] convert(string String)//wraps a string to an array of strings and then converts to an array of numbers
        {
            string[] string_array = String.Split();
            int[] int_array = new int[string_array.Length];
            int i = string_array.Length-1;
            while((i) != -1)
            {
                int_array[i] = check_int(0,100,Convert.ToInt32(string_array[i]));
                i--;
            }
            return (int_array);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("You can use standard information, for this enter 1");//if necessary, you can use the predefined data
            if (Console.ReadLine() == "1")
            {
                student Student = calculate(new student());
                show_info(Student);
            }
            else//here you can specify all the necessary data about the student
            {
                student Student = new student();
                Console.WriteLine("Please fill in student information:");
                Console.WriteLine("Enter first name of student");
                Student.name_first = check_string();
                Console.WriteLine("Enter last name of student");
                Student.name_last = check_string();
                Console.WriteLine("Enter id of student");
                Student.student_num = check_int(0, 99999999, -1);//each line is checked to ensure that it contains the correct information
                Console.WriteLine("Enter age of student");
                Student.age = check_int(0, 100, -1);
                Console.WriteLine("Enter address of student");
                Student.Address.Address = check_string();
                Console.WriteLine("Enter street of student");
                Student.Address.Street = check_string();
                Console.WriteLine("Enter city of student");
                Student.Address.City = check_string();
                Console.WriteLine("Enter country of student");
                Student.Address.Country = check_string();
                Console.WriteLine("Enter all points in subjects separated by a space");
                string array = Console.ReadLine();
                Student.scores = convert(array);
                Student = calculate(Student);
                Console.WriteLine();
                Console.WriteLine();
                show_info(Student);//information is ready and sent to the user

            }
        }
    }
}

