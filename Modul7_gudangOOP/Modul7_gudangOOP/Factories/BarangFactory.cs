using Modul7_GudangOOP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul7_GudangOOP.Factories
{
    public static class BarangFactory
    {
        public static Barang BuatBarang(string tipe)
        {
            if (tipe == "Elektronik")
                return new Barang("ELK001", "Scanner", 10, "Elektronik");
            else if (tipe == "Makanan")
                return new Barang("MAK001", "Susu", 50, "Makanan");
            else
                return new Barang("GEN001", "Barang Umum", 20, "Umum");
        }
    }
}
