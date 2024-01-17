/*
Author: Jay Patel, 000881881
Date: 26/10/2023
Purpose: Lab 3 Part A
I, Jay Patel, 000881881 certify that this material is my original work.  No other person's work has been used without due acknowledgement.
*/
using Lab3A;
namespace Lab3A
{
    public class Program
    {
        // Create a list to store Media objects
        public static List<Media> medias = new List<Media>();

        /// <summary>
        /// Reads data from a file and stores it in the Media list.
        /// </summary>
        /// <param name="filename">The name of the file to read.</param>
        public static void read(string filename)
        {
            try
            {
                // Open the file for reading
                using (StreamReader sr = new StreamReader(filename))
                {
                    string line;

                    // Read each line in the file
                    while ((line = sr.ReadLine()) != null)
                    {
                        // Check the type of media and read its details
                        if (line.StartsWith("BOOK"))
                        {
                            string[] data = line.Split('|');
                            if (data.Length == 4)
                            {
                                string title = data[1].Trim();
                                int year = int.Parse(data[2].Trim());
                                string author = data[3].Trim();
                                string summary = sr.ReadLine();
                                Media media = new Book(title, year, author, summary);
                                medias.Add(media);
                            } else
                            {
                                Console.WriteLine($"Invalid line format: {line}");
                            }
                        }
                        else if (line.StartsWith("SONG"))
                        {
                            string[] data = line.Split('|');
                            if (data.Length == 5)
                            {
                                string title = data[1].Trim();
                                int year = int.Parse(data[2].Trim());
                                string album = data[3].Trim();
                                string artist = data[4].Trim();
                                Media media = new Song(title, year, album, artist);
                                medias.Add(media);
                            }
                            else
                            {
                                Console.WriteLine($"Invalid line format: {line}");
                            }
                        }
                        else if (line.StartsWith("MOVIE"))
                        {
                            string[] data = line.Split('|');
                            if (data.Length == 4)
                            {
                                string title = data[1].Trim();
                                int year = int.Parse(data[2].Trim());
                                string director = data[3].Trim();
                                string summary = sr.ReadLine();
                                Media media = new Movie(title, year, director, summary);
                                medias.Add(media);
                            }
                            else
                            {
                                Console.WriteLine($"Invalid line format: {line}");
                            }
                        }
                    }
                }


            }

            // Catch and handle any exceptions that occur during reading
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

        }

        /// <summary>
        /// Main entry point of the program.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        public static void Main(String[] args)
        {
            // Read data from the file
            read("Data.txt");
            //foreach(Media l in medias)
            //{
            //    Console.WriteLine(l.ToString());
            //}

            Boolean toggle = true;
            string menu =
                $@"
-----------------------------------
         Media Collection
-----------------------------------
    1. List All Books
    2. List All Movies
    3. List All Songs
    4. List All Media
    5. Search All Media by title
    6. Exit
-----------------------------------
Enter Your choice: ";

            // Display a menu and process user input 
            while (toggle) {
                Console.WriteLine(menu);

                try
                {
                    string i = Console.ReadLine();
                    switch (i)
                    {
                        // List all books
                        case "1":
                            foreach (Media m in medias)
                            {
                                if (m.GetType().Name == "Book")
                                {
                                    Console.WriteLine(m.ToString());
                                    Console.WriteLine("------------------------------------------------------------------------");
                                }
                            }
                            break;

                        // List all movies
                        case "2":
                            foreach (Media m in medias)
                            {
                                if (m.GetType().Name == "Movie")
                                {
                                    Console.WriteLine(m.ToString());
                                    Console.WriteLine("------------------------------------------------------------------------");
                                }
                            }
                            break;

                        // List all songs
                        case "3":
                            foreach (Media m in medias)
                            {
                                if (m.GetType().Name == "Song")
                                {
                                    Console.WriteLine(m.ToString());
                                    Console.WriteLine("------------------------------------------------------------------------");
                                }

                            }
                            break;

                        // List all media
                        case "4":
                            foreach (Media m in medias)
                            {
                                Console.WriteLine(m.ToString());
                                Console.WriteLine("------------------------------------------------------------------------");
                            }
                            break;

                        // Search media by title
                        case "5":
                            Console.WriteLine("What are you looking for: ");
                            string searchKey = Console.ReadLine().ToLower();
                            Console.WriteLine("");

                            foreach (Media m in medias)
                            {
                                // Use the Search method provided by the ISearchable interface
                                if (m is ISearchable searchable && searchable.Search(searchKey))
                                {
                                    Console.WriteLine(m.ToString());

                                    // Decrypt and display the summary if it's a Book or Movie
                                    if (m is Book book)
                                    {
                                        Console.WriteLine($"Summary: {book.Decrypt()}");
                                    }
                                    else if (m is Movie movie)
                                    {
                                        Console.WriteLine($"Summary: {movie.Decrypt()}");
                                    }

                                    Console.WriteLine("------------------------------------------------------------------------");
                                }
                            }
                            break;

                        // Exit the program
                        case "6":
                            toggle = false;
                            break;

                        default:
                            Console.WriteLine("Please enter valid input");
                            break;

                    }
                }

                // Catch and handle any exceptions during the program's execution
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            

        }

    }
}



  
