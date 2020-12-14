﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace MiniGame2020
{
    class Ctverecek2
    {
        private GraphicsDevice _zobrazovac { get; set; }

        private int _velikost { get; set; }
        private int _rychlost { get; set; }

        private Color _barva { get; set; }

        private Vector2 _pozice { get; set; }
        private Texture2D _textura { get; set; }

        private OvladaniDucha _ovladaniPohybu2 { get; set; }
        private Rectangle _omezeniPohybu { get; set; }

        public Ctverecek2(int velikost, int rychlost, Vector2 pozice, OvladaniDucha ovladaniPohybu, Rectangle omezeniPohybu, Color barva, GraphicsDevice zobrazovac)
        {
            _velikost = velikost;
            _rychlost = rychlost;

            _ovladaniPohybu2 = ovladaniPohybu;
            _omezeniPohybu = omezeniPohybu;

            _barva = barva;
            _pozice = pozice;

            _zobrazovac = zobrazovac;
            _textura = PripravitTexturu();
        }

        private Texture2D PripravitTexturu()
        {
            Texture2D vyslednaTextura = new Texture2D(_zobrazovac, _velikost, _velikost);

            Color[] pixely = new Color[_velikost * _velikost];
            for (int i = 0; i < pixely.Length; i++)
                pixely[i] = Color.White;
            vyslednaTextura.SetData(pixely);
            
            return vyslednaTextura;
        }

        private void Pohnout(KeyboardState klavesnice)
        {
            Vector2 smerPohybu = Vector2.Zero;

            if (klavesnice.IsKeyDown(_ovladaniPohybu2.Doprava))
                smerPohybu += Vector2.UnitX;
            if (klavesnice.IsKeyDown(_ovladaniPohybu2.Doleva))
                smerPohybu -= Vector2.UnitX;
            if (klavesnice.IsKeyDown(_ovladaniPohybu2.Nahoru))
                smerPohybu -= Vector2.UnitY;
            if (klavesnice.IsKeyDown(_ovladaniPohybu2.Dolu))
                smerPohybu += Vector2.UnitY;

            if (smerPohybu != Vector2.Zero)
                _pozice += _rychlost * Vector2.Normalize(smerPohybu);

            _pozice = Vector2.Clamp(_pozice, new Vector2(_omezeniPohybu.Left, _omezeniPohybu.Top), new Vector2(_omezeniPohybu.Right - 450, _omezeniPohybu.Bottom - _velikost));
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
