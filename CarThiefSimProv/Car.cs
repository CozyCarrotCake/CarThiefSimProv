using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarThiefSimProv
{
    class Car
    {
        public int passengers;

        public int contrabandAmount;

        public int contrabandRandom;

        public int contrabandChecker;

        public bool alreadyChecked;

        public static Random generator = new Random();

        List<bool> contrabands = new List<bool>();

        public int totalContras;

        public int foundContras;


        public bool Examine()
        {
            //Om den har 0 är den clean därav kommer det inte finnas nåt
            if (contrabandAmount == 0)
            {
                Console.WriteLine("Nothing Here");
                return alreadyChecked = true;
            }

            


            //contrabandRandom = contrabandAmount * (6 - contrabandAmount); används inte då den skapade för liten chans, men är exponential så gillade den
            contrabandRandom = contrabandAmount + (5 - contrabandAmount); // Blir svårare destu färre contras det är

            //lägger till true i listan för alla faktiska contras
            for (int k = 0; k < contrabandAmount; k++)
            {
                contrabands.Add(true);
            }
            //lägger till fel i listan för alla "missar"
            for (int i = 0; i < contrabandRandom - contrabandAmount; i++)
            {
                contrabands.Add(false);                

            }
            
                        
            //slumpar om den hittar eller inte, slumpade variabeln checkas mot bool-listans index och ifall true hittade man nåt å får köra igen annars hittade man inget och slutar
            for (int j = 0; j < contrabandRandom; j++)
            {
                contrabandChecker = generator.Next(0, contrabandRandom);

                if (contrabands[contrabandChecker] == true)
                {
                    Console.WriteLine("Found One!");
                    foundContras++;
                }
                else
                {
                    Console.WriteLine("Nothing Here!");
                    j = contrabandRandom;
                }
            }
            



            return alreadyChecked = true;
        }

    }
}
