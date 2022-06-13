﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PPAI.Entidades;

namespace PPAI.Entidades
{
    public class Modelo
    {
        private string nombre;
        private Marca? marca;
        public Modelo(string nom)
        {
            nombre = nom;
        }
        public Modelo(string nom, Marca mar)
        {
            nombre = nom;
            marca = mar;
        }
        public string MostrarModelo()
        {
            return nombre;
        }
        public List<string> MostrarMarcaYModelo()
        {
            List<string> marcaModelo = new List<string>();
            marcaModelo.Add(MostrarModelo());
            marcaModelo.Add(marca.MostrarMarca());
            return marcaModelo;

        }
    }
}
