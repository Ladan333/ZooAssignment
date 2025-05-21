using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace ZooAssignment.Models;

public partial class Visit
{
    public int Id { get; set; }

    public int VisitorId { get; set; }

    public DateTime VisitDate { get; set; }

    public byte TicketPaid { get; set; }

    public virtual Person Visitor { get; set; } = null!;

    public void VisitMenu()
    {
        bool inMenu = true;
        do
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Visit Management System!");
            Console.WriteLine("1. Generate a new visit");
            Console.WriteLine("2. View all visits");
            Console.WriteLine("3. Update a visit");
            Console.WriteLine("4. Delete a visit");
            Console.WriteLine("5. Back to main menu");
            char input = Console.ReadKey().KeyChar;
            switch (input)
            {
                case '1':
                    // Call method to add a new visit
                    GenerateVisit();
                    break;
                case '2':
                    // Call method to view all visits
                    ViewAllVisits();
                    break;
                case '3':
                    // Call method to update a visit
                    UpdateVisit();
                    break;
                case '4':
                    // Call method to delete a visit
                    DeleteVisit();
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

    public void GenerateVisit()
    {
        // Implementation for adding a new visit
        using var context = new ZooAssignmentContext();
        var persons = context.Persons.ToList();
        var habitats = context.Habitats.ToList();
        try
        {
            Visit visit = new Visit();
            Random random = new Random();
            int randomVisitorId = random.Next(1, persons.Count + 1);
            int randomTicketPaid = random.Next(0, 20);
            if (randomTicketPaid < 3)
            {
                visit.TicketPaid = 0;
            }
            else
            {
                visit.TicketPaid = 1;
            }
            visit.VisitorId = randomVisitorId;
            visit.VisitDate = DateTime.Now;
            visit.Visitor = persons[randomVisitorId - 1];
            context.Visits.Add(visit);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error: " + ex.Message);
        }
    }

    public void ViewAllVisits()
    {
        // Implementation for viewing all visits
        Console.Clear();
        Console.WriteLine("List of all visits:\n\n");
        using var context = new ZooAssignmentContext();
        var visits = context.Visits.ToList();
        foreach (var visit in visits)
        {
            Console.WriteLine($"ID: {visit.Id}, Visitor ID: {visit.VisitorId}\nVisit Date: {visit.VisitDate}");
            Console.Write("Ticket Paid: ");
            if (visit.TicketPaid == 0)
            {
                Console.Write("No\n");
            }
            else
            {
                Console.Write("Yes\n");
            }
            Console.WriteLine();
        }
        Console.ReadKey();
    }

    public void UpdateVisit()
    {
        // Implementation for updating a visit
        Console.WriteLine("Updating a visit...");
        // Code to update a visit
    }

    public void DeleteVisit()
    {
        // Implementation for deleting a visit
        Console.WriteLine("Deleting a visit...");
        // Code to delete a visit
    }
}
