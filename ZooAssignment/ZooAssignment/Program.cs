using Microsoft.EntityFrameworkCore;

namespace ZooAssignment
{
    internal class Program
    {
        static void Main(string[] args)
        {

            bool appRunning = true;
            


            do
            {
                Console.Clear();
                Console.WriteLine("Welcome to the Zoo Management System!");
                Console.WriteLine("1. Manage animals");
                Console.WriteLine("2. Manage habitats");
                Console.WriteLine("3. Manage people");
                Console.WriteLine("4. Manage visits");
                Console.WriteLine("5. Generate a new day");



                char input = Console.ReadKey().KeyChar;
                switch (input)
                {
                    case '1':
                        // Call method to manage animals
                        new Models.Animal().AnimalMenu();
                        break;
                    case '2':
                        // Call method to manage habitats
                        new Models.Habitat().HabitatMenu();
                        break;
                    case '3':
                        // Call method to manage people
                        new Models.Person().PersonMenu();
                        break;
                    case '4':
                        // Call method to manage visits
                        new Models.Visit().VisitMenu();
                        break;
                    case '5':
                        new Models.ZooFunction().GenerateDay();
                        break;
                    default:
                        break;
                }
            } while (appRunning);
        }
    }
}
    
