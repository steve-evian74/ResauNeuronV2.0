using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epsi.ReseauNeuroneV2._0
{
    class Program
    {
        static void Main(string[] args)
        {

            double[] backpropagate;
            int incremente = 0;



            //Une instance pour Trainer
            Trainer trainer = new Trainer();

            double[] Weight = new double[] { 1, 2, 3, 4 };
            int weights = 4;
            //Valeur "entrée"
            double[] Valeur = new double[] { 5, 6, 10, 16 };

            //Une insatance pour Neurone 
            Neurone neurone = new Neurone(Weight, Valeur);

            //On calcule la somme des valeurs d'un tableau valeurs et on se sert cette variable comme le résultat attendu
            double expected = Valeur.Sum();
            Console.WriteLine("La valeur attendu est :" + expected);
            do
            {
                double Result = neurone.forward(Valeur, Weight);


                //On récupére le résultat du Forward
                Console.WriteLine("Le neurone a prédit : " + neurone.forward(Valeur, Weight));
                
                // Juste pour l'informatif
                Console.WriteLine("La valeur purement informatif " + trainer.Verification(expected, Result));
            

                // On récupère la valeur Gradient 
                double gradient = trainer.gradient(expected, Result);
                Console.WriteLine("La valeur gradient est : " + gradient);


                //On calcule le backpropagate 
                backpropagate = neurone.backprogate(gradient);

                Console.WriteLine("Le résultat de backpropagate : ");
                foreach (var item in backpropagate)
                {

                    Console.WriteLine(item);

                }
                for (int i = 0; i < backpropagate.Length; i++)
                {
                    Weight[i] = backpropagate[i];
                }

                incremente++;
            } while (incremente < 10);



            //Eviter d'éteindre la console
            Console.ReadKey();
        }

    }
}