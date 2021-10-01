using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Model
{
    public class WeatherForecast
    {
        public DateTime Date { get; set; }

        public int TempC { get; set; }

        public int TempF => 32 + (int)(TempC / 0.5556);

        public string Summary { get; set; }
    }
}
