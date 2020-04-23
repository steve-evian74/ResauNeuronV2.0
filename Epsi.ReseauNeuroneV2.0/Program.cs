﻿using System;
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

            // Déclaration des instance 

            //Une insatance pour Neurone 
            Neurone neurone = new Neurone();

            //Une instance pour Trainer
            Trainer trainer = new Trainer();

            double[] Weight = new double[] { 1, 2, 3, 4 };
            double[] Valeur = new double[] { 5, 6, 10, 16 };
            
            //On calcule la somme des valeurs d'un tableau valeurs et on se sert cette variable comme le résultat attendu
            double expected = Valeur.Sum();
            Console.WriteLine("La valeur attendu est :" + expected);


            //On récupére le résultat du Forward
            Console.WriteLine("Le neurone a prédit : " + neurone.forward(Valeur,Weight));
            double Result = neurone.forward(Valeur, Weight);

            // Juste pour l'informatif
            Console.WriteLine("La valeur purement informatif " + trainer.Verification(expected,Result));


            // On récupère la valeur Gradient 
            double gradient = trainer.gradient(expected, Result);
            Console.WriteLine("La valeur gradient est : " + gradient);
            //Eviter d'éteindre la console
            Console.ReadKey();
        }

    }
}