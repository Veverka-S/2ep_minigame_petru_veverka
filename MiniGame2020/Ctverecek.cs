﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MiniGame2020
{
    class Ctverecek
    {
        private GraphicsDevice _zobrazovac { get; set; }

        private int _velikost { get; set; }
        private int _rychlost { get; set; }

        private Color _barva { get; set; }

        private Vector2 _pozice { get; set; }
        private Texture2D _textura { get; set; }

        private SmeroveOvladani _ovladaniPohybu { get; set; }
        private Rectangle _omezeniPohybu { get; set; }

        public Ctverecek(int velikost, int rychlost, SmeroveOvladani ovladaniPohybu, Rectangle omezeniPohybu, Color barva, GraphicsDevice zobrazovac)
        {
            _velikost = velikost;
            _rychlost = rychlost;

            _ovladaniPohybu = ovladaniPohybu;
            _omezeniPohybu = omezeniPohybu;

            _pozice = new Vector2(_omezeniPohybu.Center.X, _omezeniPohybu.Center.Y);

            _barva = barva;
            _zobrazovac = zobrazovac;
            _textura = PripravitTexturu(_zobrazovac);
        }

        private static Texture2D PripravitTexturu(GraphicsDevice zobrazovac)
        {
            Texture2D vyslednaTextura = new Texture2D(zobrazovac, 1, 1);
            vyslednaTextura.SetData(new Color[] { Color.White });
            
            return vyslednaTextura;
        }

        private void Pohnout(KeyboardState klavesnice)
        {
            Vector2 smerPohybu = Vector2.Zero;

            if (klavesnice.IsKeyDown(_ovladaniPohybu.Doprava))
                smerPohybu += Vector2.UnitX;
            if (klavesnice.IsKeyDown(_ovladaniPohybu.Doleva))
                smerPohybu -= Vector2.UnitX;
            if (klavesnice.IsKeyDown(_ovladaniPohybu.Nahoru))
                smerPohybu -= Vector2.UnitY;
            if (klavesnice.IsKeyDown(_ovladaniPohybu.Dolu))
                smerPohybu += Vector2.UnitY;

            if (smerPohybu != Vector2.Zero)
                _pozice += _rychlost * Vector2.Normalize(smerPohybu);

            _pozice = Vector2.Clamp(_pozice, new Vector2(_omezeniPohybu.Left, _omezeniPohybu.Top), new Vector2(_omezeniPohybu.Right, _omezeniPohybu.Bottom));
        }

        public void Aktualizovat(KeyboardState klavesnice)
        {
            Pohnout(klavesnice);
        }

        public void Vykreslit(SpriteBatch _vykreslovac)
        {
            _vykreslovac.Draw(_textura, _pozice, _barva);
        }
    }
}
