using System;
using System.Collections.Generic;

namespace ZooAssignment.Models;

public partial class Person
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Age { get; set; }

    public string? Email { get; set; }

    public string? Phone { get; set; }

    public virtual ICollection<Visit> Visits { get; set; } = new List<Visit>();

    public void PersonMenu()
    {
        bool inMenu = true;
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Person Management System!");
            Console.WriteLine("1. Add a new person");
            Console.WriteLine("2. View all persons");
            Console.WriteLine("3. Update a person");
            Console.WriteLine("4. Delete a person");
            Console.WriteLine("5. Back to main menu");
            char input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    // Call method to add a new person
                    AddPerson();
                    break;
                case '2':
                    // Call method to view all persons
                    ViewAllPersons();
                    break;
                case '3':
                    // Call method to update a person
                    UpdatePerson();
                    break;
                case '4':
                    // Call method to delete a person
                    DeletePerson();
                    break;
                case '5':
                    inMenu = false;
                    break;
                default:
                    Console.WriteLine("Invalid input, please try again.");
                    break;
            }
        } while (inMenu);
    }

    public void AddPerson()
    {
        // Implementation for adding a new person
        Console.Clear();
        Console.WriteLine("Write the name of the person:");
        string name = Console.ReadLine() ?? string.Empty;
        Console.Clear();
        Console.WriteLine("Write the age of the person:");
        int age = int.Parse(Console.ReadLine()!);
        Console.Clear();
        Console.WriteLine("Write the email of the person:");
        string email = Console.ReadLine() ?? string.Empty;
        Console.Clear();
        Console.WriteLine("Write the phone number of the person:");
        string phone = Console.ReadLine() ?? string.Empty;
        Console.Clear();
        try
        {
            using var context = new ZooAssignmentContext();
            var person = new Person
            {
                Name = name,
                Age = age,
                Email = email,
                Phone = phone
            };
            context.Persons.Add(person);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error adding person: {ex.Message}");
        }
    }

    public void ViewAllPersons()
    {
        // Implementation for viewing all persons
        Console.Clear();
        Console.WriteLine("List of all persons:\n\n");
        using var context = new ZooAssignmentContext();
        var persons = context.Persons.ToList();
        foreach (var person in persons)
        {
            Console.WriteLine($"ID: {person.Id}, Name: {person.Name}, Age: {person.Age}\nEmail: {person.Email}\nPhone: {person.Phone}\nNumber of visits: {Visits.Count}\n");
        }
            Console.ReadKey();
    }

    public void UpdatePerson()
    {
        // Implementation for updating a person
        Console.Clear();
        Console.WriteLine("Enter the ID of the person to update:");
        int id = int.Parse(Console.ReadLine()!);
        Console.Clear();
        Console.WriteLine("Enter the new name of the person:");
        string name = Console.ReadLine() ?? string.Empty;
        Console.Clear();
        Console.WriteLine("Enter the new age of the person:");
        int age = int.Parse(Console.ReadLine()!);
        Console.Clear();
        Console.WriteLine("Enter the new email of the person:");
        string email = Console.ReadLine() ?? string.Empty;
        Console.Clear();
        Console.WriteLine("Enter the new phone number of the person:");
        string phone = Console.ReadLine() ?? string.Empty;
        Console.Clear();
        try
        {
            using var context = new ZooAssignmentContext();
            var person = context.Persons.Find(id);
            if (person != null)
            {
                person.Name = name;
                person.Age = age;
                person.Email = email;
                person.Phone = phone;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Person not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating person: {ex.Message}");
        }
    }

    public void DeletePerson()
    {
        // Implementation for deleting a person
        Console.Clear();
        Console.WriteLine("Enter the ID of the person to delete:");
        int id = int.Parse(Console.ReadLine()!);
        Console.Clear();
        try
        {
            using var context = new ZooAssignmentContext();
            var person = context.Persons.Find(id);
            if (person != null)
            {
                context.Persons.Remove(person);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Person not found.");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error deleting person: {ex.Message}");
        }
    }
}
