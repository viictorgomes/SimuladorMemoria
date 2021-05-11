using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorMemoria
{
    class Cache
    {
        public int? Tag { get; set; }
        public string Bloco { get; set; }
        public DateTime HoraCarregada { get; set; }
        public DateTime HoraUsada { get; set; }
        public string HoraCarregadaFormatted { get { return HoraCarregada.ToString("HH:mm:ss"); } }
        public string HoraUsadaFormatted { get { return HoraUsada.ToString("HH:mm:ss"); } }
        public int Contador { get; set; }

        public Cache() {}
    }
}
