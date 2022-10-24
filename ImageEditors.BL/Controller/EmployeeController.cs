using ImageEditors.BL.Model;

namespace ImageEditors.BL.Controller
{
    public class EmployeeController
    {
        private static List<Image> images = new List<Image>();
        private static List<Employee> employeesList= new List<Employee>();
        public EmployeeController(double img, double employees, List<double> editTime)
        {
            int i = 0;
            int j = 0;
            for (i = 1; i <= img; i++)
            {
                images.Add(new Image { Id = i, Name = Guid.NewGuid().ToString() });
            }

            
            foreach (int time in editTime)
            {
                employeesList.Add(new Employee { Id = i++, Name = $"Person {j++}", EditTime = time });
            }
        }

        public static double TotalProductivity()
        {
            double totalProductivity = 0;
            foreach (var time in employeesList)
            {
                totalProductivity += time.Productivity;
            }
            return totalProductivity;
        }

        public double TotalEditTime()
        {
            return (images.Count() / TotalProductivity());
        }

        public List<Employee> EditImages()
        {
            int i = 0;
            double img = images.Count();
            var time = TotalEditTime();
            while (img > 0)
            {
                if (employeesList[i].TotalTimeWorked < time)
                {
                    employeesList[i].TotalTimeWorked += employeesList[i].EditTime;
                    employeesList[i].EditedImages++;
                    img--;
                }
                else
                    i++;
            }
            return employeesList;
        }
    }
}
