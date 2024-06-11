// Johnathan Robb 602367
// Josh Arnold 601951
// Wouter Kuhn 602418


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp123
{
    internal class Program
    {
        // Enum for menu options 
        enum MenuOption
        {
            NewApplication = 1, // Starting point
            CompletedApplications,
            QualifiedForGameToken,
            QualifiedForLongTermLoyalty,
            Exit
        }
        static void averagePizzFirstVisit(List<ApplicantInfo> applications)
        {
            foreach (var application in applications)
            {
                // Calculate months since first visit
                int monthsSinceFirstVisit = (DateTime.Today.Year - application.DateOfReg.Year) * 12 +
                                           (DateTime.Today.Month - application.DateOfReg.Month);

                // Calculate average pizzas consumed per month since first visit
                if (monthsSinceFirstVisit > 0)
                {
                    double averagePizzasPerMonth = (double)application.PizzasConsumed / monthsSinceFirstVisit;
                    Console.WriteLine($"Average pizzas consumed per month since first visit for {averagePizzasPerMonth}");
                }
                else
                {
                    Console.WriteLine($"No data available for.");
                }
            }
        }
        static void LoadAnimation(List<ApplicantInfo> applications)
        {
            Console.Write("Loading ");
            for (int i = 0; i < 3; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000); // Adjust the delay based on your preference
            }
            Console.WriteLine();

        }

        static void LongTermLoyalty(List<ApplicantInfo> applications)
        {
            Console.WriteLine("People who qualify for long-term loyalty:");
            foreach (var application in applications)
            {
                // Calculate the difference in years between today and the registration date
                int yearsSinceRegistration = DateTime.Today.Year - application.DateOfReg.Year;

                // Check if the difference is greater than or equal to 10
                if (yearsSinceRegistration >= 10)
                {
                    Console.WriteLine($"{application.fName} {application.surname}");
                }
            }

        }


        //New Age method to find higest and lowest age
        static void GetAgeLowAndHigh(List<ApplicantInfo> applications)
        { 
            int youngestAge = int.MaxValue;
            int oldestAge = int.MinValue;

            foreach (var application in applications)
            {
                if (application.Age < youngestAge)
                {
                    youngestAge = application.Age;
                }

                if (application.Age > oldestAge)
                {
                    oldestAge = application.Age;
                }
            }

            Console.WriteLine($"Youngest Applicant: {youngestAge}");
            Console.WriteLine($"Oldest Applicant: {oldestAge}");
        }
    
//-------------------------------------------------------------------------------------------------------------------------------------

    static void Main(string[] args)
        {
          
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.BackgroundColor = ConsoleColor.White;

            int notEliteCount = 0;

            bool exit = false;
            List<ApplicantInfo> applications = new List<ApplicantInfo>(); // Create a list to store applications

            //Loading animations calling
            LoadAnimation(applications);
            Console.Clear();

            while (!exit)
            {

                //Menu for options
                Console.WriteLine("Welcome! Please select an option and follow the prompts.");
                Console.WriteLine("1. New application");
                Console.WriteLine("2. Compeleted applications");
                Console.WriteLine("3. People who have qualified for game token");
                Console.WriteLine("4. People who qualify for long term loyalty");
                Console.WriteLine("5. Exit");

                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                if (!Enum.TryParse(choice, out MenuOption selectedOption))
                {
                    Console.WriteLine("Invalid choice. Please try again.");
                    continue;
                }

                Console.Clear();

                switch (selectedOption)
                {
                    case MenuOption.NewApplication:
                        //Loading animations calling
                        LoadAnimation(applications);
                        Console.Clear();

                        Console.WriteLine("You selected Option 1.");
                        Console.WriteLine('\n');

                        while (true)
                        {
                            // Collect application information
                            ApplicantInfo newApplication = new ApplicantInfo();

                            // Name Input 
                            Console.WriteLine("Please enter your firstname:");
                            newApplication.fName = Console.ReadLine();

                            Console.Clear();

                            // Surname Input 
                            Console.WriteLine("Please enter your surname:");
                            newApplication.surname = Console.ReadLine();

                            Console.Clear();

                            // Age Input
                            Console.WriteLine("How old are you?");
                            newApplication.Age = int.Parse(Console.ReadLine());

                            Console.Clear();

                            // Date Input
                            Console.WriteLine("Enter a date you joined in this format (yyyy-MM-dd):");
                            string userInput = Console.ReadLine();

                            // Parse user input to DateTime
                            //Checker for correct formate\
                            DateTime userDate;
                            if (!DateTime.TryParse(userInput, out userDate))
                            {
                                Console.WriteLine("Invalid date format.");
                                continue; // continue the loop if the date format is invalid
                            }

                            // Get today's date
                            DateTime currentDate = DateTime.Today;

                            // Calculate the difference in years
                            newApplication.DateOfReg = userDate;
                            int differenceInYears = currentDate.Year - userDate.Year;

                            // Diffrence in months
                            newApplication.DateOfReg = userDate;
                            int diffrenceInMoths = currentDate.Month - userDate.Month;

                            int MonthsTotal = ((differenceInYears * 12) + diffrenceInMoths);

                            Console.Clear();

                            // Pizzas bought on firts visit 
                            Console.WriteLine("How many pizza's have you bought on your first visit");
                            newApplication.Pizzafvisit = int.Parse(Console.ReadLine());


                            // Pizza consumed since first visit
                            Console.WriteLine("How many pizzas have you consumed since your first visit?");
                            newApplication.PizzasConsumed = int.Parse(Console.ReadLine());

                            //Average pizza's;
                            newApplication.AvgPizza = newApplication.PizzasConsumed / MonthsTotal;

                            Console.Clear();

                            // Slush Puppy Flavour Preference 
                            Console.WriteLine("What is your Slush puppy flavour preference?");
                            newApplication.SlushFlavour = Console.ReadLine();

                            Console.Clear();

                            // Slush Puppys Consumed since first visit
                            Console.WriteLine("How many slush puppies have you consumed since your first visit?");
                            newApplication.SlushiesConsumed = int.Parse(Console.ReadLine());

                            // Average slushies

                            newApplication.AvgSlushies = newApplication.SlushiesConsumed / MonthsTotal;

                            Console.Clear();

                            // High score rank
                            Console.WriteLine("What is your high score rank?");
                            newApplication.HighScoreRank = int.Parse(Console.ReadLine());

                            Console.Clear();

                            // Bowling High Score
                            Console.WriteLine("What is your highest score in bowling?");
                            newApplication.hBowlingScore = int.Parse(Console.ReadLine());

                            Console.Clear();

                            if (newApplication.Age > 18)
                            {
                                Console.WriteLine("Are you employed? Yes/ No");
                                newApplication.EmpStatus = Console.ReadLine();


                                Console.Clear();

                                Console.WriteLine("Application" + '\n' + "Name" + " " + newApplication.fName + '\n' +
                                    "Surname:" + " " + newApplication.surname + '\n' + "Date:" + " " + userInput + '\n'
                                    + $"Years of membership: {differenceInYears}" + '\n' + "Pizza consumed:" +
                                " " + newApplication.PizzasConsumed + '\n' + "Average monthly pizza consumed:" + " " + newApplication.AvgPizza + '\n' + "Slush puppy flavour preference:" + " " +
                                newApplication.SlushFlavour + '\n' + "Slush puppies consumed:" + " " + newApplication.SlushiesConsumed + "\n" + "Average slushies consumed:" + " " + newApplication.AvgSlushies + '\n' +
                                  "High score rank:" + " " + newApplication.HighScoreRank + '\n' +
                                "Highest bowling Score:" + " " + newApplication.hBowlingScore + '\n' + "Employment status:"
                                + " " + newApplication.EmpStatus);
                            }
                            else
                            {
                                Console.WriteLine("Are your parents employed? Yes/No");
                                newApplication.EmpStatus = Console.ReadLine();

                                Console.Clear();

                                Console.WriteLine("Application" + '\n' + "Name" + " " + newApplication.fName + '\n' +
                                    "Surname:" + " " + newApplication.surname + '\n' + "Date:" + " " + userInput + '\n'
                                    + $"Years of membership: {differenceInYears}" + '\n' + "Pizza consumed:" +
                                " " + newApplication.PizzasConsumed + '\n' + "Average Monthly Pizza Consumed:" + " " + newApplication.AvgPizza + '\n' + "Slush puppy flavour preference:" + " " +
                                newApplication.SlushFlavour + '\n' + "Slush puppies consumed:" + " " + newApplication.SlushiesConsumed + "\n" + "Average slushies consumed:" + " " + newApplication.AvgSlushies +
                                '\n' + "High score Rank:" + " " + newApplication.HighScoreRank + '\n' +
                                "Highest bowling score:" + " " + newApplication.hBowlingScore + '\n' + "Employment status:"
                                + " " + newApplication.EmpStatus);
                            }

                            Console.WriteLine('\n');

                            int combinedCalculation = ((newApplication.hBowlingScore + newApplication.HighScoreRank) / 2);
                            if (differenceInYears > 2 && newApplication.hBowlingScore > 1500 && newApplication.HighScoreRank > 2000 && newApplication.AvgPizza > 3 && newApplication.AvgSlushies > 4 && newApplication.SlushFlavour != "Gooey Gulp Galore" && newApplication.EmpStatus == "Yes")
                            {
                                Console.WriteLine("You qualify for game token credit");
                            }
                            else if (combinedCalculation > 1200 && newApplication.AvgPizza >= 3 && newApplication.AvgSlushies > 4 && newApplication.SlushFlavour != "Gooey Gulp Galore" && newApplication.EmpStatus == "Yes")
                            {
                                Console.WriteLine("You still qualify for it with combined stuff");
                            }
                            else
                            {
                                Console.WriteLine("You're not elite");
                                notEliteCount++;

                            }

                            // Add the new application to the list
                            applications.Add(newApplication);
                            Console.WriteLine("Do you want to enter a new application? (y/n) If Y double click enter and you will be taken to the start again");
                            string answer = Console.ReadLine();

                            if (answer.ToLower() != "y")
                            {
                                break; // exit the loop if the answer is not "y"
                            }
                        }
                        break;
                    case MenuOption.CompletedApplications:

                        //Loading animations calling
                        LoadAnimation(applications);
                        Console.Clear();

                        Console.WriteLine("You selected Option 2.");
                        Console.WriteLine('\n');    

                        // Applications denied
                        Console.WriteLine("Applications denied: " + notEliteCount);

                        // Display the number of applications entered
                        Console.WriteLine($"Number of applications entered: {applications.Count}");

                        // Average pizzas bought per first visit 
                        int totalPizzasFirstVisit = 0;
                        foreach (var application in applications)
                        {
                            totalPizzasFirstVisit += application.Pizzafvisit;
                        }
                        double avgPizzaPfV = Math.Round((double)totalPizzasFirstVisit / applications.Count, 2);

                        Console.WriteLine($"The average amount of pizzas bought on the first visit: {avgPizzaPfV}");

                        Console.WriteLine();

                        // Check if there are any applications stored
                        if (applications.Count == 0)
                        {
                            Console.WriteLine("No applications stored.");
                        }
                        else
                        {
                            // Display information for each application
                            foreach (var application in applications)
                            {
                                Console.WriteLine("Name: " + application.fName + " " + application.surname);
                                Console.WriteLine("Date of joining: " + application.DateOfReg.ToString("yyyy-MM-dd"));
                                Console.WriteLine("Age: " + application.Age);
                                Console.WriteLine("Pizza consumed: " + application.PizzasConsumed);
                                Console.WriteLine("Average pizza's consumed monthly: " + application.AvgPizza);
                                Console.WriteLine("Slush puppy flavour preference: " + application.SlushFlavour);
                                Console.WriteLine("Slush puppies consumed: " + application.SlushiesConsumed);
                                Console.WriteLine("Average slush consumed monthly: " + application.AvgSlushies);
                                Console.WriteLine("High score rank: " + application.HighScoreRank);
                                Console.WriteLine("Highest bowling score: " + application.hBowlingScore);
                                Console.WriteLine("Employment status: " + application.EmpStatus);
                                Console.WriteLine();
                            }

                            // Call the method to retrieve age extremes
                            GetAgeLowAndHigh(applications);
                        }

                       


                        break;
                    case MenuOption.QualifiedForGameToken:
                                                
                        //Loading animations calling
                        LoadAnimation(applications);
                        Console.Clear();

                        Console.WriteLine("You selected Option 3." + '\n' + '\n' + "People who qualify are:");
                        Console.WriteLine('\n');
                        List<string> qualifiedApplicants = new List<string>(); // List to store qualified applicants

                        foreach (var application in applications)
                        {
                            int combinedCalculation = (application.hBowlingScore + application.HighScoreRank) / 2;
                            int differenceInYears = (DateTime.Today.Year - application.DateOfReg.Year)
                                - (DateTime.Today.DayOfYear < application.DateOfReg.DayOfYear ? 1 : 0);

                            if (application.EmpStatus == "Yes" && differenceInYears > 2 && application.hBowlingScore > 1500 && application.HighScoreRank > 2000 && application.AvgPizza > 3 && application.AvgSlushies > 4 && application.SlushFlavour != "Gooey Gulp Galore")
                            {
                                Console.WriteLine($"{application.fName} {application.surname}");
                                qualifiedApplicants.Add($"{application.fName} {application.surname}");
                            }
                            else if (application.EmpStatus == "Yes" && combinedCalculation > 1200 && application.AvgPizza > 3 && application.AvgSlushies > 4 && application.SlushFlavour != "Gooey Gulp Galore")
                            {
                                Console.WriteLine($"{application.fName} {application.surname}");
                                qualifiedApplicants.Add($"{application.fName} {application.surname}");
                            }
                        }

                        // Count for accepted applicactions
                        Console.WriteLine($"Total qualified applicants: {qualifiedApplicants.Count}");
                        
                        break;

                    case MenuOption.QualifiedForLongTermLoyalty:
                        LongTermLoyalty(applications);
                        break;

                    case MenuOption.Exit:
                        exit = true;
                        Console.WriteLine("Exiting the program...");
                        System.Threading.Thread.Sleep(2400);
                        return;

                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }

                Console.WriteLine();
            }
            Console.ReadKey();
        }
    }

    // Class to represent application information
    class ApplicantInfo
    {
        public string fName { get; set; }  // applicants name

        public string surname { get; set; }  // applicants Surname

        public DateTime DateOfReg { get; set; } //Registeration date

        public int Age { get; set; } // applicants age

        public int PizzasConsumed { get; set; }  // Pizzas consumed by applicants

        public string SlushFlavour { get; set; }  // applicants favourite slush flavour

        public int SlushiesConsumed { get; set; } // Total slushies the applicants consumed

        public int HighScoreRank { get; set; }  // applicants high score rankings 

        public int hBowlingScore { get; set; } // applicants bowling high score

        public string EmpStatus { get; set; } // The applicants employment status

        public int AvgPizza { get; set; } // The average pizzas the applicant bought each month

        public int AvgSlushies { get; set; } // The average slushies the applicant bought each month

        public double AvgPizzafVisit { get; set; }  

        public int Pizzafvisit { get; set; }
        
    }

}



