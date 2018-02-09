using System;
using System.Collections.Generic;

namespace TechJobsConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create two Dictionary vars to hold info for menu and data
            // actionChoices dictionary holds a menu with 2 choices - Search or List
            // columnChoices dictionary holds a menu with 5 choices - skill, employer, location, postion type, all
    

            // Top-level menu options
            Dictionary<string, string> actionChoices = new Dictionary<string, string>();
            actionChoices.Add("search", "Search");
            actionChoices.Add("list", "List");
            // Create a dictionary named actionChoices with keypairs key(string) value(string)
            // added search:Search, list:List

            // Column options
            Dictionary<string, string> columnChoices = new Dictionary<string, string>();
            columnChoices.Add("core competency", "Skill");
            columnChoices.Add("employer", "Employer");
            columnChoices.Add("location", "Location");
            columnChoices.Add("position type", "Position Type");
            columnChoices.Add("all", "All");
            // Created a dictionary names columnChoices with keypairs key(string) value(string)
            // Added several key pairs from core compentency:Skill to all:All

            Console.WriteLine("Welcome to LaunchCode's TechJobs App!");
            // Write the Page title "Welcome to ... 

            // Allow user to search/list until they manually quit with ctrl+c
            while (true) // while what is true? How does this work?
            {

            // I want to call GetUserSelection so I can display the menu created by the actionChoices dictionary. I call it by creating a variable called actionChoice and pass 2 arguments "View Jobs" and the dictionary actionChoices
                string actionChoice = GetUserSelection("View Jobs", actionChoices);
                // What does this string look like? 
                // created a string variable called actionChoice. 
                // This string value is key value pair from dictionary.
                // GetUserSelection is a class outside of class: Main but inside Class: Program.
                // is is listed below (or could be in a different file but then I would have to be "using" it)

// what happens when I call the static method GetUserSelection?
// 


                if (actionChoice.Equals("list"))
                {
                    string columnChoice = GetUserSelection("List", columnChoices);

                    if (columnChoice.Equals("all"))
                    {
                        //??PrintJobs(GetUserSelection.FindAll());
                    }
                    else
                    {
                        List<string> results = JobData.FindAll(columnChoice);

                        Console.WriteLine("\n*** All " + columnChoices[columnChoice] + " Values ***");
                        foreach (string item in results)
                        {
                            Console.WriteLine(item);
                        }
                    }
                }
                else // choice is "search"
                {
                    // How does the user want to search (e.g. by skill or employer)
                    string columnChoice = GetUserSelection("Search", columnChoices);

                    // What is their search term?
                    Console.WriteLine("\nSearch term: ");
                    string searchTerm = Console.ReadLine();

                    List<Dictionary<string, string>> searchResults;

                    // Fetch results
                    if (columnChoice.Equals("all"))
                    {
                        Console.WriteLine("Search all fields not yet implemented.");
                    }
                    else
                    {
                        searchResults = JobData.FindByColumnAndValue(columnChoice, searchTerm);
                        PrintJobs(searchResults);
                    }
                }
            }
        }

        /*
         * Returns the key of the selected item from the choices Dictionary
         */
        private static string GetUserSelection(string choiceHeader, Dictionary<string, string> choices)
        // Creates a class called GetUserSelection - a class has methods and properties. Methods do something and properties are attributes. They don't do anything.
        // Is this creating a string variale "choiceHeader" .. No it is not. choiceHeader is the string argument that has to be passed in. So in order to call this class I need to pass in a string and dictionary. 
        // GetUserSelection("View Jobs", actionChoices) so when I call this "View Jobs" is passed to choiceHeader (which is printed), and actionChoices is the dictionary named choices. Does this make sense? is there a dictionary name actionchoices. Here's the thing. I created two dictionaries at the beginning.
        {
            int choiceIdx;
            // declared(created) an integer varialbe called choiceIdx - no value set
            bool isValidChoice = false;
            // declared a booleen variable called isValidChoice and set the value to false
            string[] choiceKeys = new string[choices.Count];
            // declared (created) and initiated a string array call choiceKeys
            // this appears to be a one-dimentional array so like a list then. Why did they not make a list?
            // Being passed into the array called choiceKeys is choices.count
            // for dictionary named choices (which was created under GetUserSelection by the dictionary argument passed through) the count would be a number (integer?) for the number of keyvaluepairs.
            // For dictionary actionChoices it would be 2, for dictionary columnChoices it would be 5

            int i = 0;
            // setting i to "0"
            foreach (KeyValuePair<string, string> choice in choices)
            // for each KeyValuePair called choice in dictionary named choices (which was created under GetUserSelection)
            // the KeyValuePairs in choices are from the dictionary that was passed through
            // so for string actionChoice = GetUserSelection("View Jobs", actionChoices)
            // the dictionary actionChoices is now called dictionary choices
            // so the KeyValuePairs are search:Search, list:List
            // do something. In this case 
            {
                // what does 
                choiceKeys[i] = choice.Key; 
                i++; // then increase i by 1 so from 0 to 1, 1 to 2, etc.
                // why are we dong this/ in order to create the Keys as 0,1,2, etc
            }

            do
            {
                Console.WriteLine("\n" + choiceHeader + " by:");
                // for this (what used to call a function) class (this has both properties and methods) to be called I had to pass an argument for choiceHeader - that's how it works.
                // choiceHeaders are "Search", "List", "View Jobs"

                for (int j = 0; j < choiceKeys.Length; j++)
                {
                    Console.WriteLine(j + " - " + choices[choiceKeys[j]]);
                    // what am I doing here? looping a range starting at 0, until <len, increase by 1)
                    // what is choices[choiceKeys[j]]])
                    // When GetUserSelection is called I create the dictionary called choices
                    // choiceKeys is the array we created here in GetUserSelection
                    //          string[] choiceKeys = new string[choices.Count];
                }

                string input = Console.ReadLine();
                choiceIdx = int.Parse(input);

                if (choiceIdx < 0 || choiceIdx >= choiceKeys.Length)
                {
                    Console.WriteLine("Invalid choices. Try again.");
                }
                else
                {
                    isValidChoice = true;
                }

            } while (!isValidChoice);

            return choiceKeys[choiceIdx];
        }

        private static void PrintJobs(List<Dictionary<string, string>> someJobs)
        { 
            Console.WriteLine("printJobs is not implemented yet");
        }
    }
}
