using System;

namespace MoviesBoxOffice
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Movies Box Office!\n"+
            "What do you want to do?\n"+
            "1. Book a ticket.\n"+
            "2. Cancel a ticket.\n");
            try
            {
                int op = int.Parse(Console.ReadLine() ?? "0");

                if (op == 1)
                {
                    Console.WriteLine("Enter first name, last name and Movie name:\n");
                    string? input = Console.ReadLine();
                    if (input != null)
                    {
                        try
                        {
                            string[] parsedInput = [.. input.Split(" ")];
                            if (parsedInput.Length >= 3)
                            {
                                string fname = parsedInput[0], lname = parsedInput[1], movieName = string.Join(" ", parsedInput, 2, parsedInput.Length - 2);
                                Ticket ticket = new(fname, lname, movieName);
                                FileManager fm = new(ticket.MovieName+".txt");
                                fm.AddTicket(ticket);
                                Console.WriteLine("Ticket has been booked.");
                            }
                            else
                            {
                                Console.WriteLine("Invalid input.");
                            }
                            
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine("Error: "+e.Message);
                        }
                    }
                    else
                    {
                        Console.WriteLine("You entered empty input.");
                    }
                }
                else if (op == 2)
                {
                    Console.WriteLine("Enter first name: ");
                    string? fname = Console.ReadLine();
                    Console.WriteLine("Enter last name: ");
                    string? lname = Console.ReadLine();
                    Console.WriteLine("Enter movie name: ");
                    string? movieName = Console.ReadLine();

                    if (fname != null && lname != null && movieName != null)
                    {
                        string path = movieName+".txt";
                        FileManager? fm = File.Exists(movieName+".txt") ? new FileManager(path) : null;
                        if (fm != null)
                        {
                            string msg = fm.CancelTicket(fname, lname) == "" ? 
                                "No booked tickets with this name." 
                                : "Ticket has been cancelled successfully.";
                            Console.WriteLine(msg);
                        }
                        else
                        {
                            Console.WriteLine("There are no tickets for this movie.");
                        }
                        
                    }
                    else
                    {
                        Console.WriteLine("You entered empty input.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input.");
                }
            }
            catch
            {
                Console.WriteLine("Invalid input.");
            }
        }
    }
}