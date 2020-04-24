using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epsi.ReseauNeuroneV2._0
{
    class Neurone
    {
        private double[] ArrayWeights;
        private double[] ArrayValeurs;
        private double[] Poids;
        private double lr = 1 * 10 ^ -5;


        public Neurone(double[] Weights, double[] Valeurs)
        {
            ArrayWeights = Weights;
            ArrayValeurs = Valeurs;
        }


        public double activation(double result)
        {
            return result;
        }


        public double[] backprogate(double gradient)
        {
            

            for (int i = 0; i < ArrayWeights.Length; i++)
            {


                ArrayWeights[i] = ArrayWeights[i] - lr * ArrayValeurs[i] * gradient;
            }

            return ArrayWeights;
        }

        public double forward(double[] valeur, double[] weight)
        {
            double result = 0;
            if (weight.Length == valeur.Length)
            {
                for (int i = 0; i < weight.Length; i++)
                {
                    result += (weight[i] * valeur[i]);
                }
            }
            else
            {
                Console.WriteLine("Taille des tableaux incompatibles");
            }
            return activation(result);
        }

    }

}
