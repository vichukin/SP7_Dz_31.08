using SP7_Dz_31._08;

List<Bus> buses = new List<Bus>(5);
Random rand = new Random();
for (int i = 0; i < 5; i++)
{
    Console.WriteLine($"Bus with ID {i}: ");
    Bus bus = new Bus(rand.Next(10, 20));
    buses.Add(bus);
}
Console.WriteLine();
Console.WriteLine();

int peopleAtTheStop = 50;
AutoResetEvent resetEvent = new AutoResetEvent(true);
for (int i = 0; i < buses.Count; i++)
{
    Thread thread = new Thread(() =>
    {
        buses[i].rideToTheStopAndAgain(ref peopleAtTheStop, resetEvent, i);
    });
    thread.Start();
    Thread.Sleep(500);
}
while (true)
{
    int countOfNewPeople = rand.Next(20, 30);
    peopleAtTheStop += countOfNewPeople;
    Console.WriteLine($"New people at stop: {countOfNewPeople}. Total count of people: {peopleAtTheStop}");
    Thread.Sleep(1000);
}
