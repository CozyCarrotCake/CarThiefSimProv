using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarThiefSimProv
{
    class Program
    {
        static void Main(string[] args)
        {

            List<Car> cars = new List<Car>(); //skapar en ny lista med bilar som jag sedan använder för att låta spelaren välja vilken bil man kan med listans index

            Random generator = new Random();

            int whichCar;

            int foundContras = 0;

            int totalContras = 0;

            // Enkel tryparse för att tvinga spelaren att skriva siffror
            Console.WriteLine("Hur många bilar ska skapas?"); 
            string answer1 = Console.ReadLine();
            int answerChecker1;
            bool fine = int.TryParse(answer1, out answerChecker1);

            while (fine != true || answerChecker1 <= 0)
            {
                Console.WriteLine("Nä siffra över 0 tackar!");
                answer1 = Console.ReadLine();
                fine = int.TryParse(answer1, out answerChecker1);
            }

            Console.WriteLine("Allright! " + answerChecker1 + " many cars!");

            //Slumpar vilken sorts och lägger in bilarna i listan med Cars, först skapas bilen sen skapas den om som den typ av bil den blev slumpad att vara
            for (int i = 0; i < answerChecker1; i++)
            {
                whichCar = generator.Next(0, 2);

                Car car = new Car();

                if (whichCar == 0)
                {
                    car = new CleanCar();
                }
                else
                {
                    car = new ContrabandCar();
                }

                cars.Add(car);
            }


            for (int j = 0; j < answerChecker1; j++)
            {
                //tryparse igen
                Console.WriteLine("Vilken bil vill du'la se? Skriv dess nummer! Du kan välja mellan 0 och " + (answerChecker1-1));
                string answer2 = Console.ReadLine();
                int answerChecker2;
                bool fine2 = int.TryParse(answer2, out answerChecker2);

                //om bilen redan är checkad måste man också skriva om
                while (fine2 != true || answerChecker2 < 0 || answerChecker2 > answerChecker1-1 || cars[answerChecker2].alreadyChecked == true)
                {
                    if (cars[answerChecker2].alreadyChecked == true)
                    {
                        Console.WriteLine("Nä den har du redan tittat i hörru!");
                    }
                    else
                    {
                        Console.WriteLine("Nä siffra mellan 0 och " + (answerChecker1 - 1) + " tackar!");
                    }                    
                    answer2 = Console.ReadLine();
                    fine2 = int.TryParse(answer2, out answerChecker2);
                }

                Console.WriteLine("Allright! Kollar bil nummer " + answerChecker2);

                //Kör examine
                cars[answerChecker2].Examine();

                //Lägg till resultaten från varje bil i den totala variablarna här som sedan används i slutet, nåt fel med de men inte tid att hitta det
                totalContras = +cars[answerChecker2].totalContras;
                foundContras = +cars[answerChecker2].foundContras;
            }


            Console.WriteLine("You looked through all the cars, and found " + foundContras + " contrabands out of " + totalContras + "!");



            Console.ReadLine();
        }
    }
}
