using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LemonadeStandGamev2._0
{
    class Weather
    {
        Random random;
        string weatherType;
        int temperature;
        public Weather()
        {
            random = new Random();
            weatherType = SetWeatherType();
            temperature = SetTemperature();
        }
        public string SetWeatherType()
        {
            
            switch (random.Next(1, 5))
            {
                case 1:
                    return "humid";
                case 2:
                    return "sunny";
                case 3:
                    return "cloudy";
                default:
                    return "rainy";
            }
        }
        public int SetTemperature()
        {
            return random.Next(50, 100);
        }
        public string GetWeatherType()
        {
            return weatherType;
        }
        public int GetTemperature()
        {
            return temperature;
        }
        public int CheckWeatherType()
        {
            switch (weatherType)
            {
                case "sunny":
                    return temperature;
                case "rainy":
                    return temperature - 10;
                case "humid":
                    return temperature + 5;
                default:
                    return temperature - 5;
            }
        }
        public void LoadType(string type)
        {
            weatherType = type;
        }
        public void LoadTemperature(int loadTemperature)
        {
            temperature = loadTemperature;
        }
    }
}
