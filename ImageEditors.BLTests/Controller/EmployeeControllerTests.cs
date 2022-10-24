using ImageEditors.BL.Model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace ImageEditors.BL.Controller.Tests
{
    [TestClass()]
    public class EmployeeControllerTests
    {
        [TestMethod()]
        public void TotalProductivityTest()
        {
            // Arrange
            double totalProductivity = 0;
            var employeesList = new List<Employee>();

            employeesList.Add(new Employee { Id = 1, Name = $"Person {1}", EditTime = 2 });
            employeesList.Add(new Employee { Id = 2, Name = $"Person {2}", EditTime = 3 });
            employeesList.Add(new Employee { Id = 3, Name = $"Person {3}", EditTime = 4 });


            // Act
            foreach (var time in employeesList)
            {
                totalProductivity += time.Productivity;
            }
            // Assert
            Assert.AreEqual(1.08, Math.Round(totalProductivity, 2));
        }

        [TestMethod()]
        public void TotalEditTimeTest()
        {
            // Arrange
            var images = new List<Image>();
            double totalProductivity = 0;
            var employeesList = new List<Employee>();

            employeesList.Add(new Employee { Id = 1, Name = $"Person {1}", EditTime = 2 });
            employeesList.Add(new Employee { Id = 2, Name = $"Person {2}", EditTime = 3 });
            employeesList.Add(new Employee { Id = 3, Name = $"Person {3}", EditTime = 4 });

            images.Add(new Image { Id = 1, Name = Guid.NewGuid().ToString()});
            images.Add(new Image { Id = 2, Name = Guid.NewGuid().ToString() });
            images.Add(new Image { Id = 3, Name = Guid.NewGuid().ToString() });
            images.Add(new Image { Id = 4, Name = Guid.NewGuid().ToString() });
            images.Add(new Image { Id = 5, Name = Guid.NewGuid().ToString() });

            foreach (var time in employeesList)
            {
                totalProductivity += time.Productivity;
            }
            // Act
            var totalEditTime = images.Count / totalProductivity; 

            Assert.AreEqual(4.62, Math.Round(totalEditTime, 2));
        }

        [TestMethod()]
        public void EditImagesTest()
        {
            //Arrange
            var employeesList = new List<Employee>();

            employeesList.Add(new Employee { Id = 1, Name = $"Person {1}", EditTime = 2 });
            employeesList.Add(new Employee { Id = 2, Name = $"Person {2}", EditTime = 3 });
            employeesList.Add(new Employee { Id = 3, Name = $"Person {3}", EditTime = 4 });

            var images = new List<Image>();

            images.Add(new Image { Id = 1, Name = Guid.NewGuid().ToString() });
            images.Add(new Image { Id = 2, Name = Guid.NewGuid().ToString() });
            images.Add(new Image { Id = 3, Name = Guid.NewGuid().ToString() });
            images.Add(new Image { Id = 4, Name = Guid.NewGuid().ToString() });
            images.Add(new Image { Id = 5, Name = Guid.NewGuid().ToString() });

            int i = 0;
            double img = images.Count();

            double totalProductivity = 0;

            foreach (var time in employeesList)
            {
                totalProductivity += time.Productivity;
            }

            var totalEditTime = images.Count / totalProductivity;


            //Act
            double edited = 0;
            while (img > 0)
            {
                if (employeesList[i].TotalTimeWorked < totalEditTime)
                {
                    employeesList[i].TotalTimeWorked += employeesList[i].EditTime;
                    employeesList[i].EditedImages++;
                    img--;
                }
                else
                    i++;
                edited = employeesList[0].EditedImages;
            }

            //Assert 
            Assert.AreEqual(3, edited);
        }

    }
}