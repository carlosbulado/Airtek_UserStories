using UserStories;
using UserStories.Domain;

static void Main(string[] args)
{
    while (true)
    {
        int option = 0;
        Console.WriteLine("Hello!");
        Console.WriteLine("Options: ");
        Console.WriteLine("     1 - User Story #1");
        Console.WriteLine("     2 - User Story #2");
        Console.WriteLine("     0 - Exit");
        if (int.TryParse(Console.ReadLine(), out option))
        {
            switch (option)
            {
                case 0:
                    Console.WriteLine("End Of Program!");
                    return;
                case 1:
                    Console.WriteLine("Launching User Story #1...");
                    UserStoryNumber1.Main();
                    break;
                case 2:
                    Console.WriteLine("Launching User Story #2...");
                    UserStoryNumber2.Main();
                    break;
            }
        }
    }
}

Main(args);