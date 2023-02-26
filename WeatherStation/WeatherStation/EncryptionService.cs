using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherStation
{
    public class EncryptionService
    {
        public static double Encrypt(double value)
        {
            // just a sample transformation to 'encrypt' data before transfer
            return value * 100 - 25;
        }

        public static double Decrypt(double value)
        {
            // reverse transformation from 'encrypt'
            return (value + 25) / 100;
        }
    }
}
