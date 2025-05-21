using System;
using System.Collections.Generic;

namespace ZooAssignment.Models;

public partial class Habitat
{
    string[] habitatNames = { "Forest", "Savannah", "Rainforest", "Desert", "Tundra" };
    string[] growthNames = { "Barren", "Sparse", "Dense" };
    string[] climateNames = { "Tropical", "Temperate", "Polar", "Dry" };

    public int Id { get; set; }

    public int Name { get; set; }

    public int GrowthDensity { get; set; }

    public int Climate { get; set; }

    public (string[], string[], string[]) GetHabitatNames()
    {
        return (habitatNames, growthNames, climateNames);
    }

    public void HabitatMenu()
    {
        bool inMenu = true;
        do
        {

            Console.Clear();
            Console.WriteLine("Welcome to the Habitat Management System!");
            Console.WriteLine("1. Add a new habitat");
            Console.WriteLine("2. View all habitats");
            Console.WriteLine("3. Update a habitat");
            Console.WriteLine("4. Delete a habitat");
            Console.WriteLine("5. Back to main menu");
            char input = Console.ReadKey().KeyChar;

            switch (input)
            {
                case '1':
                    // Call method to add a new habitat
                    AddHabitat();
                    break;
                case '2':
                    // Call method to view all habitats
                    ViewAllHabitats();
                    break;
                case '3':
                    // Call method to update a habitat
                    UpdateHabitat();
                    break;
                case '4':
                    // Call method to delete a habitat
                    DeleteHabitat();
                    break;
                case '5':
                    inMenu = false;
                    break;
                default:
                    break;
            }

        } while (inMenu);
    }

    public void AddHabitat()
    {
        Console.Clear();
        Console.WriteLine("Enter the name of the habitat:\n\n" +
            "1. Forest\n" +
            "2. Savannah\n" +
            "3. Rainforest\n" +
            "4. Desert\n" +
            "5. Tundra");
        int name = int.Parse(Console.ReadLine()!);
        Console.Clear();
        Console.WriteLine("Enter the growth density:\n\n" +
            "1. Barren\n" +
            "2. Sparse\n" +
            "3. Dense");
        int growthDensity = int.Parse(Console.ReadLine()!);
        Console.Clear();
        Console.WriteLine("Enter the climate:\n\n" +
            "1. Tropical\n" +
            "2. Temperate\n" +
            "3. Polar\n" +
            "4. Dry");
        int climate = int.Parse(Console.ReadLine()!);
        // Add logic to save the new habitat to the database

        try
        {
            using (var context = new ZooAssignmentContext())
            {
                if (name < 1 || name > habitatNames.Length || growthDensity < 1 || growthDensity > growthNames.Length || climate < 1 || climate > climateNames.Length)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Thread.Sleep(2000);
                    return;
                }
                else
                {

                    var newHabitat = new Habitat
                    {
                        Name = name,
                        GrowthDensity = growthDensity,
                        Climate = climate
                    };
                    context.Habitats.Add(newHabitat);
                    context.SaveChanges();
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public void ViewAllHabitats()
    {
        Console.Clear();
        Console.WriteLine("All Habitats:");
        using (var context = new ZooAssignmentContext())
        {
            var habitats = context.Habitats.ToList();
            foreach (var habitat in habitats)
            {
                Console.WriteLine($"ID: {habitat.Id}, Name: {habitatNames[habitat.Name - 1]}\nGrowth Density: {growthNames[habitat.GrowthDensity - 1]}\nClimate: {climateNames[habitat.Climate - 1]}\n");
            }
        }
        Console.ReadKey();
    }

    public void UpdateHabitat()
    {
        // Logic to update a habitat
        Console.Clear();
        Console.WriteLine("Enter the ID of the habitat to update:");
        int id = int.Parse(Console.ReadLine()!);
        Console.Clear();
        Console.WriteLine("Enter the new name of the habitat:\n\n" +
            "1. Forest\n" +
            "2. Savannah\n" +
            "3. Rainforest\n" +
            "4. Desert\n" +
            "5. Tundra");
        int name = int.Parse(Console.ReadLine()!);
        Console.Clear();
        Console.WriteLine("Enter the new growth density:\n\n" +
            "1. Barren\n" +
            "2. Sparse\n" +
            "3. Dense");
        int growthDensity = int.Parse(Console.ReadLine()!);
        Console.Clear();
        Console.WriteLine("Enter the new climate:\n\n" +
            "1. Tropical\n" +
            "2. Temperate\n" +
            "3. Polar\n" +
            "4. Dry");
        int climate = int.Parse(Console.ReadLine()!);
        // Add logic to update the habitat in the database
        try
        {
            using (var context = new ZooAssignmentContext())
            {
                if (name < 1 || name > habitatNames.Length || growthDensity < 1 || growthDensity > growthNames.Length || climate < 1 || climate > climateNames.Length)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    Thread.Sleep(2000);
                    return;
                }
                else
                {

                    var habitatToUpdate = context.Habitats.Find(id);
                    if (habitatToUpdate != null)
                    {
                        habitatToUpdate.Name = name;
                        habitatToUpdate.GrowthDensity = growthDensity;
                        habitatToUpdate.Climate = climate;
                        context.SaveChanges();
                    }
                    else
                    {
                        Console.WriteLine("Habitat not found.");
                        Thread.Sleep(2000);
                    }
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public void DeleteHabitat()
    {
        // Logic to delete a habitat
        Console.Clear();
        Console.WriteLine("Enter the ID of the habitat to delete:");
        int id = int.Parse(Console.ReadLine()!);
        try
        {
            using (var context = new ZooAssignmentContext())
            {
                var habitatToDelete = context.Habitats.Find(id);
                if (habitatToDelete != null)
                {
                    context.Habitats.Remove(habitatToDelete);
                    context.SaveChanges();
                }
                else
                {
                    Console.WriteLine("Habitat not found.");
                    Thread.Sleep(2000);
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public void ListAllHabitats()
    {
        using (var context = new ZooAssignmentContext())
        {
            var habitats = context.Habitats.ToList();
            foreach (var habitat in habitats)
            {
                Console.WriteLine($"ID: {habitat.Id}, Name: {habitatNames[habitat.Name - 1]}\nGrowth Density: {growthNames[habitat.GrowthDensity - 1]}\nClimate: {climateNames[habitat.Climate - 1]}\n");
            }
        }
    }

    public List<int> GetHabitatIds()
    {
        using (var context = new ZooAssignmentContext())
        {
            var habitatIds = new List<int>();
            foreach (var habitat in context.Habitats.ToList())
            {
                habitatIds.Add(habitat.Id);
            }
            return habitatIds;
        }
    }
}
