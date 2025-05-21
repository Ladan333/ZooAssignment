using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZooAssignment.Models;
public class ZooFunction
{
    int internalDayCount = 0;
    public void GenerateDay()
    {
        internalDayCount++;
        using var context = new ZooAssignmentContext();
        var animals = context.Animals.ToList();
        var habitats = context.Habitats.ToList();
        var persons = context.Persons.ToList();

        Random random = new Random();
        List<int> dailyVisitors = new List<int>();
        List<HabitatVisit> habitatVisits = new List<HabitatVisit>();
        foreach (var person in persons)
        {
            if (random.Next(1, 3) == 1)
            {
                dailyVisitors.Add(person.Id);
            }
        }

        foreach (var visitorId in dailyVisitors)
        {
            Visit visit = new Visit();
            visit.VisitorId = visitorId;
            visit.VisitDate = DateTime.Now;
            Random random2 = new Random();
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
            context.Visits.Add(visit);
        }
        context.SaveChanges();

        int totalHabitatVisits = 0;
        foreach (var visitorId in dailyVisitors)
        {
            int visitsForPerson = random.Next(1, 5);
            totalHabitatVisits += visitsForPerson;
        }

        for (int i = totalHabitatVisits; i > 0; i--)
        {
            HabitatVisit habitatVisit = new HabitatVisit();
            habitatVisit.InternalDay = internalDayCount;
            int visitedHabitat = random.Next(1, habitats.Count + 1);
            habitatVisit.HabitatId = habitats[visitedHabitat - 1].Id;

            var habitatAnimals = context.Animals
                .Where(a => a.HabitatId == habitatVisit.HabitatId)
                .ToList();
            if (habitatAnimals.Count > 0)
            {
                int randomAnimalIndex = random.Next(0, habitatAnimals.Count);
                habitatVisit.FavoriteAnimalId = habitatAnimals[randomAnimalIndex].Id;
            }

            int visitingPersonIndex = dailyVisitors[random.Next(0, dailyVisitors.Count)];
            habitatVisit.PersonId = visitingPersonIndex;

            habitatVisits.Add(habitatVisit);
        }

        int mostVisitedHabitat = habitatVisits
            .GroupBy(h => h.HabitatId)
            .OrderByDescending(g => g.Count())
            .FirstOrDefault()?.Key ?? 0;
        int favoriteAnimal = habitatVisits
            .GroupBy(h => h.FavoriteAnimalId)
            .OrderByDescending(g => g.Count())
            .FirstOrDefault()?.Key ?? 0;

        Console.Clear();
        Console.WriteLine($"Day {internalDayCount} generated.");
        Console.WriteLine($"Total visitors: {dailyVisitors.Count}");
        Console.WriteLine($"Most visited habitat ID: {mostVisitedHabitat}");
        Console.WriteLine($"Favorite animal ID: {favoriteAnimal}");
        Console.ReadKey();
    }
}
