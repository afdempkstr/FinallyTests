namespace Finally
{
    public class Lesson
    {
        public string Name { get; }

        public byte Grade { get; }

        public Lesson(string name, byte grade)
        {
            Name = name;
            Grade = grade;
        }
    }
}
