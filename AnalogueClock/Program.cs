class Program
{
    static void Main(string[] args)
    {
        int hours = -1;
        int minutes = -1;
        Console.WriteLine("Hi ReizTech!");
        while (hours == -1)
        {
            Console.WriteLine("Input hours:");
            var input = Convert.ToInt32(Console.ReadLine());
            if (input >= 0 && input <= 23)
                hours = input;
            else Console.WriteLine("Try again...");
        }
        while (minutes == -1)
        {
            Console.WriteLine("Input minutes:");
            var input = Convert.ToInt32(Console.ReadLine());
            if (input >= 0 && input <= 59)
                minutes = input;
            else Console.WriteLine("Try again...");
        }
        Console.WriteLine($"The lesser degree between the arrows at {String.Format("{0:00}", hours)}:{String.Format("{0:00}", minutes)} " +
                            $"is {GetLesserAngle(GetDegreesOfMinutes(minutes), GetDegreesOfHours(hours, minutes))}°");
    }

    private static double GetDegreesOfMinutes(int minutes) => 360/60*minutes;
    private static double GetDegreesOfHours(int hours, int minutes) => hours<12 ? 360/12*hours+(double)(360/12)/60*minutes : 360/12*(hours-12)+(double)(360/12)/60*minutes;
    private static double GetLesserAngle(double minuteDegree, double hourDegree)
    {
        double result = 0;
        if (minuteDegree > hourDegree)
        {
            result = minuteDegree - hourDegree;
            if (result <= 360 / 2)
                return result;
            return 360 - minuteDegree + hourDegree;
        }
        else if (minuteDegree < hourDegree)
        {
            result = hourDegree - minuteDegree;
            if (result <= 360 / 2)
                return result;
            return 360 - hourDegree + minuteDegree;
        }
        else if (minuteDegree == hourDegree)
            return 0;

        return result;
    }

    //Method I used to test application
    private static void Test(int testHour)
    {
        string h = String.Format("{0:00}", testHour);
        for (int i = 0; i <= 59; i++)
        {
            string min = String.Format("{0:00}", i);
            Console.WriteLine($"The lesser degree between the arrows at {h}:{min} is {GetLesserAngle(GetDegreesOfMinutes(i), GetDegreesOfHours(testHour, i))}°");
        }
    }
}