public class Student
{
    public string Name { get; set; }
    public string StudentID { get; set; }

    public Student(string name, string studentID)
    {
        Name = name;
        StudentID = studentID;
    }
}
