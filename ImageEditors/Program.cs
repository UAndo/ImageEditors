using ImageEditors.BL.Controller;

namespace ImageEditors
{
    class Program
    {
        public static void Main()
        {
            int i = 1;
            int j = 1;
            var editTime = new List<double>();
            Console.WriteLine("What do you want to do?\n1.Press E to enter your own values.\n2.Press D to start with default values.");
            var key = Console.ReadKey();
            Console.WriteLine();

            if (key.Key == ConsoleKey.E)
            {
                var img = ParseDouble("Enter number of images: ", "images");

                var employees = ParseDouble("Enter number of employees: ", "employees");

                Console.WriteLine("Enter editing time for every workers: \n");
                for (i = 1; i <= employees; i++)
                {
                    var time = ParseDouble($"Employee {i}, edit time: ", "time");
                    editTime.Add(time);
                }

                var employeeController = new EmployeeController(img, employees, editTime);

                var employeesList = employeeController.EditImages();
                var totalTime = employeeController.TotalEditTime();
                foreach (var item in employeesList)
                {
                    Console.Write($"\nEmployee {j++}, edited images: {item.EditedImages}");
                }

                Console.WriteLine($"\nTotal time at work: {Math.Floor(totalTime / 60)} hours {Math.Round(totalTime % 60)} min ({Math.Round(totalTime)} min)");
            }

            if (key.Key == ConsoleKey.D)
            {
                int img = 1000;
                int employees = 3;
                j = 2;
           
                for (i = 0; i < employees; i++)
                {
                    editTime.Add(j++);
                }

                var employeeController = new EmployeeController(img, employees, editTime);
                var employeesList = employeeController.EditImages();
                var totalTime = employeeController.TotalEditTime();

                i = 1;
                foreach (var item in employeesList)
                {
                    Console.Write($"\nEmployee {i++}, edited images: {item.EditedImages}");
                }

                Console.WriteLine($"\nTotal time at work: {Math.Floor(totalTime / 60)} hours {Math.Round(totalTime % 60)} min ({Math.Round(totalTime)} min)");
            }
        }
        private static double ParseDouble(string s, string name)
        {
            while (true)
            {
                Console.Write(s);
                if (double.TryParse(Console.ReadLine(), out double value))
                { 
                    return value;
                }
                else
                {
                    Console.WriteLine($"Invalid {name} format.");
                }
            }
        }
    }
}