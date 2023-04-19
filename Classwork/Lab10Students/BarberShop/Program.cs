using System;
using System.Threading;
class Program
{
    // random number generator initialization
    static Random random = new Random();
    // number of customers and chairs in the waiting room
    const int customerNumber = 10;
    const int chairNumber = 5;
    // Manages the maximum number of customers in the waiting room, initially all the
    // chairs are free
    static Semaphore waitingRoom = new Semaphore(chairNumber, chairNumber);
    // There is just one barber chair in the barber shop, either to cut hair to a customer or 
    // for the barber to sleep. The barber does not block the barber chair, initially it is free.
    static Semaphore barberChair = new Semaphore(1, 1);
    // The barber needs a pillow to sleep, there is only one
    // Initially there is no customer, thus the barber grabs the pillow and waits sleeping
    // Barber thread has to wait thus initially this semaphore is 0
    static Semaphore pillow = new Semaphore(0, 1);
    // The customer is hold in place with a belt while
    // the barber cuts his hair =:-O
    // The first customer sits in the chair and waits until the barber releases the belt.
    static Semaphore belt = new Semaphore(0, 1);
    // True if working day finished
    static bool dayEnded = false;
    // mutex to isolate the critical section
    static Mutex m = new Mutex();
    // mutex to isolate ...

    static void Barber()
    {
        while (!dayEnded)
        {           
            Console.WriteLine("The barber takes the pillow and fells asleep.");
            // The barber waits sleeping until somebdy takes the pillow away from him
            //
            
            if (!dayEnded)
            {
                // The barber cuts the hair for a random amount of time
                Console.WriteLine("The barber is cutting the hair to a customer.");
                Thread.Sleep(random.Next(1, 3) * 1000);
                Console.WriteLine("The barber has finished cutting the hair to a customer.");
                // The barber releases the belt
                //
                
            }
            else
            {
                Console.WriteLine("The barber closes the barber shop and goes home.");
            }
        }
    }
    static void Customer(Object number)
    {
        int Numero = (int)number;
        Console.WriteLine("Customer #{0} leaves home and goes to the barber shop", Numero);
        Thread.Sleep(random.Next(1, 5) * 1000);
        Console.WriteLine("Customer  #{0} arrives to the barber shop.", Numero);
        // The customer waits until there are free chairs in the waiting room
        //
        
        Console.WriteLine("Customer #{0} enters the waiting room", Numero);
        // The customer waits until the barber chair is free
        //
        
        // Only one customer with the barber is allowed
        //
        
        // The customer leaves the waiting room
        //
        
        Console.WriteLine("Customer #{0} shouts: Awake!", Numero);
        // Uncomment the following to worsen things
        // Thread.Sleep(random.Next(1, 3) * 1000);
        // The customer grabs the pillow
        //
        
        // The customer waits until the haircut is done
        //
        
        // After that the customer gets off the chair
        //
        
        Console.WriteLine("Customer #{0} leaves the barber shop.", Numero);
        // End of the customer bussines with the barber
        //
        
    }
    static void Main()
    {
        Thread barberThread = new Thread(Barber);
        barberThread.Start();
        Thread[] customerThreads = new Thread[customerNumber];
        for (int i = 0; i < customerNumber; i++)
        {
            customerThreads[i] = new Thread(new ParameterizedThreadStart(Customer));
            customerThreads[i].Start(i);
        }
        for (int i = 0; i < customerNumber; i++)
        {
            customerThreads[i].Join();
        }
        dayEnded = true;
        // The barber's partner takes the pillow away from the barber
        //
        
        // Wait the barber thread to finish
        barberThread.Join();
        Console.WriteLine("The End. This line should appear just before \"Presione...\".");
    }
}
