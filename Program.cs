using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        ResidenceManager manager = new ResidenceManager();

        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nUniversity Residence Management System");
            Console.WriteLine("1. Add new residence");
            Console.WriteLine("2. View available residences");
            Console.WriteLine("3. Assign a student to a residence");
            Console.WriteLine("4. Remove a student from a residence");
            Console.WriteLine("5. Submit a maintenance request");
            Console.WriteLine("6. Display submitted maintenance requests");
            Console.WriteLine("7. Display rent collection report");
            Console.WriteLine("8. Display all registered students");
            Console.WriteLine("9. Search for a student by ID");
            Console.WriteLine("10. Exit");
            Console.Write("\nEnter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }
// use switch case to select option
            switch (choice)
            {
                case 1:
                    AddResidence(manager);
                    break;
                case 2:
                    manager.DisplayAvailableResidences();
                    break;
                case 3:
                    AssignStudentToResidence(manager);
                    break;
                case 4:
                    RemoveStudentFromResidence(manager);
                    break;
                case 5:
                    SubmitMaintenanceRequest(manager);
                    break;
                case 6:
                    manager.DisplayMaintenanceRequests();
                    break;
                case 7:
                    manager.DisplayRentCollectionReport();
                    break;
                case 8:
                    manager.DisplayAllStudents();
                    break;
                case 9:
                    SearchStudentByID(manager);
                    break;
                case 10:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 10.");
                    break;
            }
        }
    }
// adding new residence 
    static void AddResidence(ResidenceManager manager)
    {
        Console.Write("Enter residence ID: ");
        string residenceID = Console.ReadLine();

        // Check if the residence ID already exists
        if (manager.Residences.Any(residence => residence.ResidenceID == residenceID))
        {
            Console.WriteLine($"Residence with ID {residenceID} already exists.");
            return;
        }

        Console.Write("Enter residence type (DormRoom/Apartment): ");
        string residenceType = Console.ReadLine();

        switch (residenceType.ToLower())
        {
            case "dormroom":
                Console.Write("Enter room size: ");
                if (!int.TryParse(Console.ReadLine(), out int roomSize))
                {
                    Console.WriteLine("Invalid input for room size.");
                    return;
                }
                manager.AddResidence(new DormRoom(residenceID, roomSize));
                Console.WriteLine("Dorm room added successfully.");
                break;
            case "apartment":
                Console.Write("Enter number of bedrooms: ");
                if (!int.TryParse(Console.ReadLine(), out int numberOfBedrooms))
                {
                    Console.WriteLine("Invalid input for number of bedrooms.");
                    return;
                }
                manager.AddResidence(new Apartment(residenceID, numberOfBedrooms));
                Console.WriteLine("Apartment added successfully.");
                break;
            default:
                Console.WriteLine("Invalid residence type.");
                break;
        }
    }

    static void AssignStudentToResidence(ResidenceManager manager)
    {
        Console.Write("Enter student name: ");
        string name = Console.ReadLine();
        Console.Write("Enter student ID: ");
        string studentID = Console.ReadLine();

        Student student = new Student(name, studentID);

        Console.Write("Enter residence ID to assign the student: ");
        string residenceID = Console.ReadLine();

        Residence residence = manager.Residences.FirstOrDefault(res => res.ResidenceID == residenceID);
        if (residence == null)
        {
            Console.WriteLine($"Residence with ID {residenceID} does not exist.");
            return;
        }

        manager.AssignStudentToResidence(student, residence);
    }

    static void RemoveStudentFromResidence(ResidenceManager manager)
    {
        Console.Write("Enter student ID to remove: ");
        string studentID = Console.ReadLine();

        Student student = manager.SearchStudentByID(studentID);
        if (student == null)
        {
            Console.WriteLine($"Student with ID {studentID} not found.");
            return;
        }

        Console.Write("Enter residence ID to remove the student from: ");
        string residenceID = Console.ReadLine();

        Residence residence = manager.Residences.FirstOrDefault(res => res.ResidenceID == residenceID);
        if (residence == null)
        {
            Console.WriteLine($"Residence with ID {residenceID} does not exist.");
            return;
        }

        manager.RemoveStudentFromResidence(student, residence);
    }
  //to make request
    static void SubmitMaintenanceRequest(ResidenceManager manager)
    {
        Console.Write("Enter maintenance request description: ");
        string description = Console.ReadLine();

        manager.SubmitMaintenanceRequest(new MaintenanceRequest(description));
    }

    static void SearchStudentByID(ResidenceManager manager)
    {
        Console.Write("Enter student ID to search: ");
        string studentID = Console.ReadLine();

        Student student = manager.SearchStudentByID(studentID);
        if (student == null)
        {
            Console.WriteLine($"Student with ID {studentID} not found.");
        }
        else
        {
            Console.WriteLine($"Student found - Name: {student.Name}, Student ID: {student.StudentID}");
        }
    }
}
