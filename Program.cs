using System;

Dictionary<string, bool> seats1 = Cinema.MakeSeats(); 
Dictionary<string, bool> seats2 = Cinema.MakeSeats(); 
Dictionary<string, bool> seats3 = Cinema.MakeSeats(); 

Dictionary<string, Dictionary<string, bool>> movies = new();

movies.Add("Dune2", seats1);
movies.Add("Poor Things", seats2);
movies.Add("Furiosa", seats3);


bool isTicketingStart = true;

while (true)
{
    if (isTicketingStart)
    {
        Console.WriteLine("Welcome to ShinWoo's theater!!");
        Console.WriteLine($"Here is today({DateTime.Now.ToString("yyyy-MM-dd")})'s movies!!");

        foreach (KeyValuePair<string, Dictionary<string, bool>> movie in movies)
        {
            Console.WriteLine($"● {movie.Key}");
        }
    }

    Console.Write("Enter the movie : ");
    string title = Console.ReadLine();
    Console.WriteLine("");
    isTicketingStart = false;

    foreach (var movie in movies)
    {
        if (movie.Key == title)
        {
            movies.Remove(movie.Key);
            movies.Add(title, Cinema.MakeTicket(title, movie.Value));
            isTicketingStart = true;
            break;
        }
    }

    if (!isTicketingStart)
    {
        Console.WriteLine("There's no movie with that title");
    }
}
