namespace ImageEditors.BL.Model
{
    public class Image
    {
        public int Id { get; set; }             
        public string Name { get; set; }

        public Image() { }
        
        public Image(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
