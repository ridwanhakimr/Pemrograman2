using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul7_GudangOOP.Helpers
{
    // [Langkah 3, Bagian 1 PDF]
    public static class InputHelper
    {
        public static int AmbilStokValid()
        {
            while (true)
            {
                Console.Write("Jumlah Stok: ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int stok))
                {
                    if (stok >= 0)
                    {
                        return stok; // Valid, kembalikan nilai
                    }
                    else
                    {
                        Console.WriteLine("Stok tidak boleh negatif.");
                    }
                }
                else
                {
                    Console.WriteLine("Input harus berupa angka!");
                }
            }
        }

        // Tambahan: Helper untuk input string agar konsisten
        public static string AmbilString(string prompt)
        {
            Console.Write(prompt);
            return Console.ReadLine();
        }
    }
}
