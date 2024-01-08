using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SP7_Dz_31._08
{
    public class Bus
    {
        public int occupiedSeats = 0;
        public int totalSeats;



        public void rideToTheStopAndAgain(ref int peopleAtBusStop, AutoResetEvent resetEvent, int busId)
        {
            Thread.Sleep(500);
            while (true)
            {
                resetEvent.WaitOne();
                Console.WriteLine();
                Console.WriteLine($"Bus with ID {busId} arrived!");
                Console.WriteLine($"People at buss stop {peopleAtBusStop}");
                int pickedPassenger;
                if (peopleAtBusStop <= (totalSeats - occupiedSeats))
                {
                    occupiedSeats += peopleAtBusStop;
                    pickedPassenger = peopleAtBusStop;
                    peopleAtBusStop = 0;
                }
                else
                {
                    pickedPassenger = totalSeats - occupiedSeats;
                    occupiedSeats = totalSeats;
                    peopleAtBusStop -= pickedPassenger;
                }
                Console.WriteLine($"Bus with ID {busId} picked up {pickedPassenger} passenger.");
                Console.WriteLine();

                resetEvent.Set();
                Thread.Sleep(3000);
                occupiedSeats = 0;
            }
        }

        public Bus(int totalSeats)
        {
            this.totalSeats = totalSeats;
            Console.WriteLine($"Created bus with {totalSeats} seats");
        }


    }
}
