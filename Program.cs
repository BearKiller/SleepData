﻿// See https://aka.ms/new-console-template for more information
// ask for input
Console.WriteLine("Enter 1 to create data file.");
Console.WriteLine("Enter 2 to parse data.");
Console.WriteLine("Enter anything else to quit.");
// input response
string? resp = Console.ReadLine();
string data = "data.txt";
if (resp == "1")
{
    // create data file
    // ask a question
    Console.WriteLine("How many weeks of data is needed?");
    // input the response (convert to int)
    int weeks = int.Parse(Console.ReadLine());
    // determine start and end date
    DateTime today = DateTime.Now;
    // we want full weeks sunday - saturday
    DateTime dataEndDate = today.AddDays(-(int)today.DayOfWeek);
    // subtract # of weeks from endDate to get startDate
    DateTime dataDate = dataEndDate.AddDays(-(weeks * 7));
    // random number generator
    Random rnd = new Random();
    StreamWriter sw = new StreamWriter(data);
    // loop for the desired # of weeks
    while (dataDate < dataEndDate)
    {
        // 7 days in a week
        int[] hours = new int[7];
        for (int i = 0; i < hours.Length; i++)
        {
            // generate random number of hours slept between 4-12 (inclusive)
            hours[i] = rnd.Next(4, 13);
        }
        // M/d/yyyy,#|#|#|#|#|#|#
        sw.WriteLine($"{dataDate:M/d/yy},{string.Join("|", hours)}");
        // add 1 week to date
        dataDate = dataDate.AddDays(7);
    }
        sw.Close();
}
else if (resp == "2")
{
    if (File.Exists(data)){
        int count = 0;
        StreamReader sr = new StreamReader(data);
        while (!sr.EndOfStream) {
            // Reads a line of data and converts it all to string
            string line = sr.ReadLine();

            // Splits the string between the date and time
            string dateSplit = line.Split(',').First();
            string timeSplit = line.Split(',').Last();

            Console.WriteLine(dateSplit);
            Console.WriteLine(timeSplit);
            
            count += 1;
        } sr.Close();

    } else {
        Console.WriteLine("File does not exist. Please create a file first.");
    }

}