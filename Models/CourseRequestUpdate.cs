namespace Models
{
    public class CourseRequestUpdate
    {
        public string Name { get; set; }
        public bool Active { get; set; }
        public decimal Price { get; set; }
        public string Duration { get; set; }
        public string Certified { get; set; }
    }
}