namespace DemoDP
{
    internal class Program
    {
        // Användning:
        public static void Main(string[] args)
        {
            // Utan Strategy Pattern
            //Person person1 = new Person(Person.TravelMethod.Car);
            //person1.TravelTo("Stockholm");
            //person1.PreferredMethod = Person.TravelMethod.Train;
            //person1.TravelTo("Malmö");

            //Person person2 = new Person(Person.TravelMethod.Train);
            //person2.TravelTo("Gothenburg");


            // Med Strategy Pattern
            Person person = new Person();

            //Välj bilstrategi
            person.SetTravelStrategy(new CarStrategy());
            person.TravelTo("Stockholm");

            // Byt till tågstrategi
            person.SetTravelStrategy(new TrainStrategy());
            person.TravelTo("Gothenburg");


        }

        // Utan Strategy
        //public class Person
        //{
        //    int car = 0;
        //    int train = 1;
        //    public enum TravelMethod
        //    {
        //        Car,
        //        Train,
        //    }

        //    public TravelMethod PreferredMethod;

        //    public Person(TravelMethod preferredMethod)
        //    {
        //        PreferredMethod = preferredMethod;
        //    }

        //    public void TravelTo(string destination)
        //    {
        //        switch (PreferredMethod)
        //        {
        //            case TravelMethod.Car:
        //                Console.WriteLine($"Traveling to {destination} by car.");
        //                break;

        //            case TravelMethod.Train:
        //                Console.WriteLine($"Traveling to {destination} by train.");
        //                break;

        //            default:
        //                throw new InvalidOperationException("Unknown travel method.");
        //        }
        //    }
        //}






        // Med strategy pattern:

        // Definiera ett interface för alla strategier
        public interface ITravelStrategy
        {
            void Travel(string destination);
        }

        // En konkret strategi: resa med bil
        public class CarStrategy : ITravelStrategy
        {
            public void Travel(string destination)
            {
                Console.WriteLine($"Traveling to {destination} by car.");
            }
        }

        // En annan konkret strategi: resa med tåg
        public class TrainStrategy : ITravelStrategy
        {
            public void Travel(string destination)
            {
                Console.WriteLine($"Traveling to {destination} by train.");
            }
        }

        // Kontextklassen som använder en strategi
        public class Person
        {
            private ITravelStrategy _travelStrategy;

            // Sätt en ny strategi
            public void SetTravelStrategy(ITravelStrategy strategy)
            {
                _travelStrategy = strategy;
            }

            // Använd vald strategi för att resa
            public void TravelTo(string destination)
            {
                _travelStrategy.Travel(destination);
            }
        }

    }
}