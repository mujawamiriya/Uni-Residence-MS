using System;
using System.Collections.Generic;
using System.Linq;

public class ResidenceManager
{
    private List<Residence> residences;
    private List<Student> students;
    private List<MaintenanceRequest> maintenanceRequests;

    public ResidenceManager()
    {
        residences = new List<Residence>();
        students = new List<Student>();
        maintenanceRequests = new List<MaintenanceRequest>();
    }

    // Property to access the list of residences
    public List<Residence> Residences
    {
        get { return residences; }
    }

    // Method to add a residence
    public void AddResidence(Residence residence)
    {
        residences.Add(residence);
    }

    // Method to remove a residence
    public void RemoveResidence(Residence residence)
    {
        residences.Remove(residence);
    }

    // Method to display available residences
    public void DisplayAvailableResidences()
    {
        Console.WriteLine("Available Residences:");
        foreach (var residence in residences)
        {
            if (!residence.IsOccupied)
                Console.WriteLine($"Residence ID: {residence.ResidenceID}");
        }
    }

    // Method to display occupied residences
    public void DisplayOccupiedResidences()
    {
        Console.WriteLine("Occupied Residences:");
        foreach (var residence in residences)
        {
            if (residence.IsOccupied)
                Console.WriteLine($"Residence ID: {residence.ResidenceID}");
        }
    }

    // Method to assign a student to a residence
    public void AssignStudentToResidence(Student student, Residence residence)
    {
        if (!residence.IsOccupied)
        {
            residence.IsOccupied = true;
            students.Add(student);
            Console.WriteLine($"Student {student.Name} assigned to Residence {residence.ResidenceID}");
        }
        else
        {
            Console.WriteLine($"Residence {residence.ResidenceID} is already occupied.");
        }
    }

    // Method to remove a student from a residence
    public void RemoveStudentFromResidence(Student student, Residence residence)
    {
        residence.IsOccupied = false;
        students.Remove(student);
        Console.WriteLine($"Student {student.Name} removed from Residence {residence.ResidenceID}.");
    }

    // Method to submit a maintenance request
    public void SubmitMaintenanceRequest(MaintenanceRequest request)
    {
        maintenanceRequests.Add(request);
        Console.WriteLine("Maintenance request submitted successfully!");
    }

    // Method to display submitted maintenance requests
    public void DisplayMaintenanceRequests()
    {
        Console.WriteLine("Maintenance Requests:");
        foreach (var request in maintenanceRequests)
        {
            Console.WriteLine(request.Description);
        }
    }

    // Method to display rent collection report
    public void DisplayRentCollectionReport()
    {
        Console.WriteLine("Rent Collection Report:");
        foreach (var residence in residences)
        {
            if (residence.IsOccupied)
            {
                Console.WriteLine($"Residence ID: {residence.ResidenceID}, Rent: {residence.CalculateMonthlyRent()}");
            }
        }
    }

    // Method to display all registered students
    public void DisplayAllStudents()
    {
        Console.WriteLine("Registered Students:");
        foreach (var student in students)
        {
            Console.WriteLine($"Name: {student.Name}, Student ID: {student.StudentID}");
        }
    }

    // Method to fin a student by student ID
    public Student SearchStudentByID(string studentID)
    {
        return students.Find(student => student.StudentID == studentID);
    }

    // Method to display residence details
    public void DisplayResidenceDetails(Residence residence)
    {
        Console.WriteLine($"Residence ID: {residence.ResidenceID}");
        if (residence is DormRoom)
        {
            DormRoom dormRoom = (DormRoom)residence;
            Console.WriteLine($"Type: Dorm Room, Size: {dormRoom.RoomSize}, Occupied: {residence.IsOccupied}");
        }
        else if (residence is Apartment)
        {
            Apartment apartment = (Apartment)residence;
            Console.WriteLine($"Type: Apartment, Bedrooms: {apartment.NumberOfBedrooms}, Occupied: {residence.IsOccupied}");
        }
    }
}
