using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Epsi.ReseauNeuroneV2._0
{
    class Trainer
    {
        

        public double Verification(double expected , double result)
        {
            double verif = expected - result;
            return Math.Pow(verif, 2);

        }


        public double gradient(double expected , double result)
        {
            return 2 * (expected - result);
        }



    }
}
