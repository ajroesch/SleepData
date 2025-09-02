//ask for input
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

    while (dataDate < dataEndDate)
    {
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            hours[i] = rand.Next(4, 13);
        }

        //write data to text file
        //M/d/yy,#|#|#|#|#|#|#
        Console.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");

        dataDate = dataDate.AddDays(7);
    }

}
else if (resp == "2")
{
    // Parse data file
}




