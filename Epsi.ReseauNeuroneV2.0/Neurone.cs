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
        private double lr = 1 * 1000 ;
        private double expected;
       


        public Neurone(double[] Weights, double[] Valeurs)
        {
            ArrayWeights = Weights;
            ArrayValeurs = Valeurs;
            ArrayValeurs = Valeurs;
        }


        public double Activation(double result/*, double previousResult*/)
        {
            if (result < 0)
            {
                result = 0;
            }/* else if (result < previousResult / 2)
            {

            }*/

            //return 1 / (Math.Pow(result,2) + 1);
            return result * 2;
        }


        public double[] Backpropagate(double gradient)
        {
            lr = Math.Pow(lr, -5);

            for (int i = 0; i < ArrayWeights.Length; i++)
            {
                ArrayWeights[i] = ArrayWeights[i] - lr * ArrayValeurs[i] * gradient;
            }

            return ArrayWeights;
        }

        public double Forward(double[] valeur, double[] weight)
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
            return Activation(result);
        }

    }

}
