using System;
using System.IO;


namespace ReadWriter
{
    class Program
    {

        private static string filepath = System.IO.Directory.GetCurrentDirectory() + @"\write.txt";

        static void Main(string[] args)
        {

            int stillUpdating = 1;

            while (stillUpdating == 1)
            {

                Console.WriteLine("Please input the item number you wish to select: ");
                Console.WriteLine("1 - Create a new file");
                Console.WriteLine("2 - Update current file");
                Console.WriteLine("3 - Read current file");
                Console.WriteLine("4 - Exit");


                string menuItem = validInput();
                switch (menuItem)
                {
                    case "1":
                        createNewFile();
                        Console.WriteLine("You created a new file");
                        break;

                    case "2":
                        updateFile();
                        Console.WriteLine("File has been updated");
                        break;

                    case "3":
                        Console.WriteLine("reading..");
                        readFile();
                        break;

                    case "4":
                        Console.WriteLine("exiting...");
                        stillUpdating = 0;
                        break;
                }
            }


        }

        private static void createNewFile()
        {
            using (StreamWriter writetext = new StreamWriter("write.txt"))
            {
                writetext.WriteLine("You created a new text file!");
            }
        }

        private static void updateFile()
        {
            string userText;

            Console.WriteLine("What do you want to add?");
            userText = Console.ReadLine();
            appendFile(userText);
        }

        private static void appendFile(string userText)
        {
            File.AppendAllText(filepath, userText);
            File.AppendAllText(filepath, ", Edit by: " + Environment.UserName + Environment.NewLine);
        }

        private static void readFile()
        {
            string[] lines = System.IO.File.ReadAllLines(filepath);

            // Display the file contents by using a foreach loop.
            System.Console.WriteLine("Opening file... ");
            foreach (string line in lines)
            {
                // Use a tab to indent each line of the file.
                Console.WriteLine(">" + line);
            }
        }

        private static string validInput()
        {
            string menuItem = "";

            while (menuItem != "1" && menuItem != "2" && menuItem != "3" && menuItem != "4") // Error handling
            {
                menuItem = Console.ReadLine();
            }

            return menuItem;
        }

    }
}