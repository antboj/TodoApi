using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Controllers
{
    public class Osnovna
    {
        public int Id { get; set; }
    }

    public class Izvedena : Osnovna
    {
        public string Name { get; set; }
    }

    public class Treca
    {
        public int Id { get; set; }
    }

    public class Kod
    {
        public static void Metoda()
        {
            List<Osnovna> lista = new List<Osnovna>();
            lista.Add(new Izvedena
            {
                Id = 1, Name = "Izvedena"
            });

            foreach (var osnovna in lista)
            {
                var izvedena = osnovna as Izvedena;
                if (izvedena == null)
                {
                    // Pogresan tip
                    // int.MaxValue;
                    // uint.MaxValue;
                }
            }
        }
    }
}