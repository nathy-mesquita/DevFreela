using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace DevFreela.API.Models
{
    public class OpeningTimeOption
    {
        public TimeSpan StartAt { get; set; }
        public TimeSpan FinishAt { get; set; }
    }
}
