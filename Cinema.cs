class Cinema
{
    public static Dictionary<string, bool> MakeSeats()
    {
        Dictionary<string, bool> seats = new();
        List<string> rows = new List<string>(){"a", "b", "c", "d", "e"};
        List<int> cols = new List<int>(){1, 2, 3, 4, 5};

        foreach (string row in rows)
        {
            foreach (int col in cols)
            {
                seats[row + col.ToString()] = true;
            }
        }

        return seats;
    }

    public static string ShowSeats(Dictionary<string, bool> seats)
    {
        string str = string.Empty;
        string result = string.Empty;
        int count = 0;

        foreach (var seat in seats)
        {
            if (seat.Value)
            {
                str += seat.Key + " ";
            }
            else
            {
                str += "■■ ";
            }
        }

        foreach (var s in str.Split(' '))
        {
            result += s + " ";
            count += 1;
            if (count % 5 == 0)
            {
                result += "\n";
            }
        }

        result = "====SCREEN====\n" + result;

        return result;
    }

    public static Dictionary<string, bool> MakeTicket(string title, Dictionary<string, bool> seats)
    {
        int seatNum = 0;
        List<string> reservedSeats = new();

        Console.WriteLine("This is {0}'s seats!!", title);
        Console.WriteLine(ShowSeats(seats));

        while (seatNum <= 0)
        {
            try
            {
                Console.Write("How many seats would you like to reserve? : ");
                seatNum = Int32.Parse(Console.ReadLine());

                if (seatNum <= 0)
                {
                    Console.WriteLine("You should enter the number that bigger than 0..");
                }
            }
            catch
            {
                Console.WriteLine("You should enter the number");
            }
        }

        for (int i = 0; i < seatNum; i++)
        {
            while (true)
            {
                Console.Write($"{i + 1}. Enter the seat : ");
                string seat = Console.ReadLine();

                if ((seats.ContainsKey(seat) && seats[seat]) && (!reservedSeats.Contains(seat)))
                {
                    reservedSeats.Add(seat);  
                    break;
                }

                Console.WriteLine("That seat doesn't exist or already reserved.. Choose another seat.");
            }
        }

        foreach (var rs in reservedSeats)
        {
            seats[rs] = false;
        }

        Console.WriteLine("");    
        Console.WriteLine("Reservation Complete!!");
        Console.WriteLine("");
        Console.WriteLine("##########Ticket##########");
        Console.WriteLine($"Moive : {title}");
        Console.Write("Seats : ");
        foreach (var rs in reservedSeats)
        {
            Console.Write($"{rs} ");
        }
        Console.WriteLine("\n###########################");
        Console.WriteLine("");
        Console.WriteLine("");

        return seats;
    
    }
}