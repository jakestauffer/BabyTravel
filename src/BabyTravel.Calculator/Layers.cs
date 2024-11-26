using BabyTravel.Calculator.Models;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTravel.Calculator
{
    // https://www.mother.ly/baby/baby-products/dress-your-baby-for-outside/
    public class Layers
    {
        private decimal _temperature;

        private Layers(decimal temperature)
        {
            _temperature = temperature;
        }

        public static Layers For(decimal temperatureInFahrenheit) => new(temperatureInFahrenheit);

        public int TotalLayers;

        public int Shirt;
        
        public int Bottoms;

        public int Socks;

        public int Shoes;

        public int Boots;

        public int Hats;

        public int Gloves;
    }
}
