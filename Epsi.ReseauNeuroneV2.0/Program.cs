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

            double[] backpropagate1;
            double[] backpropagate2;
            int incremente = 0;
            double iterative = 1;



            //Une instance pour Trainer
            Trainer trainer = new Trainer();

            double[] Weight1 = new double[] {0,0,0,0};
            double[] Weight2 = new double[] {0,0,0,0};
            int weights = 4;

            //Valeur "entrée" 1
            double[] Valeur1 = new double[] { 4, 9, 6, 8 };
            double[] Valeur2 = new double[] { 6, 8, 12, 2 };


            Random rand = new Random();
            double Result1;
            double Result2;
            //Instance des Neurones
            double expected = Valeur1.Sum(); 
            Neurone neurone1 = new Neurone(Weight1, Valeur1);
            Neurone neurone2 = new Neurone(Weight2, Valeur2);

            //On calcule la somme des valeurs d'un tableau valeurs et on se sert cette variable comme le résultat attendu
           
            Console.WriteLine("La valeur attendu est :" + expected);
            do
            {

                for (int i = 0; i < Weight1.Length; i++)
                {
                    Weight1[i] = rand.NextDouble();
                }
                for (int i = 0; i < Weight2.Length; i++)
                {
                    Weight2[i] = rand.NextDouble();
                }


                Result1 = neurone1.Forward(Valeur1, Weight1);
                Result2 = neurone2.Forward(Valeur2, Weight2);


                //On récupére le résultat du Forward
                Console.WriteLine("Le neurone 1 a prédit : " + Math.Round(neurone1.Forward(Valeur1, Weight1),0));
                Console.WriteLine("Le neurone 2 a prédit : " + Math.Round(neurone2.Forward(Valeur2, Weight2),0));
                
                // Juste pour l'informatif
                Console.WriteLine("Neurone 1 : La valeur purement informatif " + trainer.Verification(expected, Result1));
                Console.WriteLine("Neurone 2 : La valeur purement informatif " + trainer.Verification(expected, Result2));
            

                // On récupère la valeur Gradient 
                double gradient1 = trainer.Gradient(expected, Result1);
                double gradient2 = trainer.Gradient(expected, Result2);
                Console.WriteLine("Neurone 1 : La valeur gradient est : " + gradient1);
                Console.WriteLine("Neurone  : La valeur gradient est : " + gradient2);

                //On calcule le backpropagate 
                backpropagate1 = neurone1.Backpropagate(gradient1);
                backpropagate2 = neurone2.Backpropagate(gradient2);

                Console.WriteLine("Le résultat de backpropagate : ");

                for (int i = 0; i < backpropagate1.Length; i++)
                {
                    Weight1[i] = backpropagate1[i];
                    Console.WriteLine(Weight1[i]);
                }
                for (int i = 0; i < backpropagate2.Length; i++)
                {
                    Weight2[i] = backpropagate2[i];
                    Console.WriteLine(Weight2[i]);
                }

                incremente++;
            } while (trainer.Verification(expected, Result1) > 0.03 || trainer.Verification(expected, Result2) > 0.03);
            Console.WriteLine("le système a essayé : " + incremente + " fois" );


            //Eviter d'éteindre la console
            Console.ReadKey();
        }

    }
}