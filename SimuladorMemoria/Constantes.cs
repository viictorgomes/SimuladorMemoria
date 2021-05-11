using System;

namespace SimuladorMemoria
{
    public static class Algoritmo
    {
        public const string FIFO = "FIFO";
        public const string LRU = "LRU";
        public const string LFU = "LFU";
    }
    public static class Tecnica
    {
        public const int Direta = 0;
        public const int Associativa = 1;
        public const int AssociativaConjuntoNPos = 2;
    }
}
