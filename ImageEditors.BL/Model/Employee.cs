namespace ImageEditors.BL.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double EditTime { get; set; }
        public double Productivity { 
            get 
            { 
                return 1 / EditTime; 
            } 
            private set { } 
        }    
        public double EditedImages { get; set; }
        public double TotalTimeWorked { get; set; }
        public Employee() { }
        public Employee(int id, string name, double productivity, int editedImages, int totalTimeWorked)
        {
            Id = id;
            Name = name;
            Productivity = productivity;
            EditedImages = editedImages;
            TotalTimeWorked = totalTimeWorked;
        }
    }
}
