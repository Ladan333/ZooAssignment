using System;
using System.Collections.Generic;

namespace ZooAssignment.Models;

public partial class Animal
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public int Species { get; set; }

    public int Sex { get; set; }

    public int? HabitatId { get; set; }

    public int? Status { get; set; }

    string[] speciesNames = { "Mammal", "Bird", "Reptile", "Amphibian", "Fish" };
    string[] sexList = { "Male", "Female" };
    string[] statusNames = { "Healthy", "Sick", "Injured", "Deceased" };
    public void AnimalMenu()
    {

        bool inMenu = true;
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Animal Management System!");
            Console.WriteLine("1. Add a new animal");
            Console.WriteLine("2. View all animals");
            Console.WriteLine("3. Update an animal");
            Console.WriteLine("4. Delete an animal");
            Console.WriteLine("5. Change status of an animal");
            Console.WriteLine("6. Back to main menu");
            char input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    // Call method to add a new animal
                    AddAnimal();
                    break;
                case '2':
                    // Call method to view all animals
                    ViewAllAnimals();
                    break;
                case '3':
                    // Call method to update an animal
                    UpdateAnimal();
                    break;
                case '4':
                    // Call method to delete an animal
                    DeleteAnimal();
                    break;
                case '5':
                    ChangeStatus();
                    break;
                case '6':
                    inMenu = false;
                    break;
                default:
                    break;
            }
        } while (inMenu);
    }

    public void AddAnimal()
    {
        // Implementation for adding a new animal
        Console.Clear();
        Console.WriteLine("Enter the name of the animal:");
        string name = Console.ReadLine()!;
        Console.WriteLine("Enter the species of the animal\n\n" +
            "1: Mammal\n" +
            "2: Bird\n" +
            "3: Reptile\n" +
            "4: Amphibian\n" +
            "5: Fish");
        int species = int.Parse(Console.ReadLine()!);
        Console.Clear();
        Console.WriteLine("Enter the sex of the animal:\n\n" +
            "1: Male\n" +
            "2: Female");
        int sex = int.Parse(Console.ReadLine()!);
        Console.Clear();
        Console.WriteLine("Enter the habitat ID of the animal:\n\n");
        new Models.Habitat().ListAllHabitats();
        int habitatId = int.Parse(Console.ReadLine()!);
        Console.Clear();
        try
        {
            var context = new ZooAssignmentContext();
            List<int> ids = new Models.Habitat().GetHabitatIds();
            if (ids.Contains(habitatId) && species <= speciesNames.Length && sex <= sexList.Length)
            {
                Animal animal = new Animal()
                {
                    Name = name,
                    Species = species,
                    Sex = sex,
                    HabitatId = habitatId,
                };
                context.Animals.Add(animal);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Invalid information. Please try again.");
                Thread.Sleep(2000);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public void ViewAllAnimals()
    {
        // Implementation for viewing all animals
        Console.Clear();
        Console.WriteLine("List of all animals:\n\n");
        var context = new ZooAssignmentContext();
        var animals = context.Animals.ToList();
        foreach (var animal in animals)
        {
            int statusID = animal.Status ?? 0;
            Console.WriteLine($"ID:{animal.Id} Name: {animal.Name}\n" +
                $"Species: {speciesNames[animal.Species - 1]}\n" +
                $"Sex: {sexList[animal.Sex - 1]}\n" +
                $"Status: {statusNames[statusID]}\n" +
                $"Habitat ID: {animal.HabitatId}\n");
        }
        Console.ReadKey();
    }
 

    public static void UpdateAnimal()
    {
        // Implementation for updating an animal
        Console.Clear();
        Console.WriteLine("Enter the ID of the animal to update:");
        int id = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter the new name of the animal:");
        string name = Console.ReadLine()!;
        Console.WriteLine("Enter the new species of the animal\n\n" +
            "1: Mammal\n" +
            "2: Bird\n" +
            "3: Reptile\n" +
            "4: Amphibian\n" +
            "5: Fish");
        int species = int.Parse(Console.ReadLine()!);
        Console.Clear();
        Console.WriteLine("Enter the new sex of the animal:\n\n" +
            "1: Male\n" +
            "2: Female\n");
        int sex = int.Parse(Console.ReadLine()!);
        Console.Clear();
        Console.WriteLine("Enter the new habitat ID of the animal:\n\n");
        new Models.Habitat().ListAllHabitats();
        int habitatId = int.Parse(Console.ReadLine()!);
        try
        {
            var context = new ZooAssignmentContext();
            var animal = context.Animals.Find(id);
            if (animal != null)
            {
                animal.Name = name;
                animal.Species = species;
                animal.Sex = sex;
                animal.HabitatId = habitatId;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Animal not found.");
                Thread.Sleep(2000);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }

    }

    public static void DeleteAnimal()
    {
        // Implementation for deleting an animal
        Console.Clear();
        Console.WriteLine("Enter the ID of the animal to delete:");
        int id = int.Parse(Console.ReadLine()!);
        try
        {
            var context = new ZooAssignmentContext();
            var animal = context.Animals.Find(id);
            if (animal != null)
            {
                context.Animals.Remove(animal);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Animal not found.");
                Thread.Sleep(2000);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public void ChangeStatus()
    {
        Console.Clear();
        Console.WriteLine("Enter the ID of the animal to change status:");
        int id = int.Parse(Console.ReadLine()!);
        Console.WriteLine("Enter the new status of the animal:\n\n" +
            "1: Healthy\n" +
            "2: Sick\n" +
            "3: Injured\n" +
            "4: Deceased");
        int status = int.Parse(Console.ReadLine()!);
        try
        {
            var context = new ZooAssignmentContext();
            var animal = context.Animals.Find(id);
            if (animal != null)
            {
                animal.Status = status;
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("Animal not found.");
                Thread.Sleep(2000);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }
}
