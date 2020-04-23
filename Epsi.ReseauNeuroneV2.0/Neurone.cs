using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epsi.ReseauNeuroneV2._0
{
    class Neurone
    {


        public void activation()
        {

        }


        public void backprogate()
        {

        }

        public double forward(double[] valeur , double[] weight)
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
            return result;
        }

    }

}
