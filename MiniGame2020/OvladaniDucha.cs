using Microsoft.Xna.Framework.Input;

namespace MiniGame2020
{
    class OvladaniDucha
    {
        public Keys Doprava { get; private set; }
        public Keys Doleva{ get; private set; }
        public Keys Nahoru { get; private set; }
        public Keys Dolu { get; private set; }

        public OvladaniDucha(Keys doleva, Keys doprava, Keys nahoru, Keys dolu)
        {
            Doprava = doleva;
            Doleva = doprava;
            Nahoru = nahoru;
            Dolu = dolu;
        }
    }
}
