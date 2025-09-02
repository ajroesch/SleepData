//ask for input
using System.Security;

Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data file.");
Console.WriteLine("Enter anything else to quit.");
//input response
string? resp = Console.ReadLine();


if (resp == "1")
{
    // Create data file

    //ask how many weeks
    Console.WriteLine("How many weeks of data do you want to enter?");
    //input the response (convert to int)
    int weeks = Convert.ToInt32(Console.ReadLine());
    //determine start and end date
    DateTime today = DateTime.Now;
    //we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    //subtract number of weeks from dataEndDate to get dataDate
    DateTime dataDate = dataEndDate.AddDays(-((weeks * 7)));

    Random rand = new();

    StreamWriter sw = new("data.txt");

    while (dataDate < dataEndDate)
    {
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            hours[i] = rand.Next(4, 13);
        }

        //write data to text file
        //M/d/yy,#|#|#|#|#|#|#
        sw.WriteLine($"{dataDate:M/d/yyyy},{string.Join("|", hours)}");

        dataDate = dataDate.AddDays(7);
    }

    sw.Close();
}
else if (resp == "2")
{
    // Parse data file
    //read data file
    StreamReader sr = new("data.txt");
    string? line;
    while ((line = sr.ReadLine()) != null)
    {
        string[] parts = line.Split(',');
        DateTime date = DateTime.Parse(parts[0]);
        int[] hours = Array.ConvertAll(parts[1].Split('|'), int.Parse);
        
        Console.WriteLine($"Week of {date:MM, dd, yyyy}");
        Console.WriteLine("{0,-3}{1,-3}{2,-3}{3,-3}{4,-3}{5,-3}{6,-3}{7,-4}{8,-4}", "Su", "Mo", "Tu", "We", "Th", "Fr", "Sa", "Tot", "Avg");
        Console.WriteLine("{0,-3}{0,-3}{0,-3}{0,-3}{0,-3}{0,-3}{0,-3}{1,-4}{1,-4}", "--", "---");
        Console.WriteLine("{0,-3}{1,-3}{2,-3}{3,-3}{4,-3}{5,-3}{6,-3}{7,-4}{8,-4}", hours[0], hours[1], hours[2], hours[3], hours[4], hours[5], hours[6], hours.Sum(), hours.Average().ToString("0.0"));
        Console.WriteLine();
    }
    
    sr.Close();
}




