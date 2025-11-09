using Modul3_gudangOOP.Models;
using System;
class Program
{
    static void Main()
    {
        Barang b1 = new Barang("BRG001", "Peti Plastik", 80, "Kemasan");
        // Shortened name to 15 chars ("HandheldScanner")
        Barang b2 = new BarangElektronik("ELK001", "HandheldScanner", 10, "Elektronik", 25);

        // Membuat array dan mengisi dengan objek Barang
        Barang[] daftarBarang = new Barang[2];
        daftarBarang[0] = b1;
        daftarBarang[1] = b2;

        // Menampilkan info semua barang dalam array
        foreach (var barang in daftarBarang)
        {
            barang.TampilkanInfo();
            Console.WriteLine($"Status: {barang.StatusStok()}");
        }

        Barang b3 = new Barang();

        // Loop hingga nama valid (setter di Barang akan melempar ArgumentException jika tidak valid)
        while (true)
        {
            Console.Write("Masukkan Nama Barang: ");
            string inputNama = Console.ReadLine();
            try
            {
                b3.NamaBarang = inputNama;
                break;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Input tidak valid: {ex.Message} Silakan coba lagi.");
            }
        }

        Console.Write("Masukkan Kode Barang: ");
        b3.KodeBarang = Console.ReadLine();

        // Validasi jumlah stok: harus integer >= 0
        while (true)
        {
            Console.Write("Masukkan Jumlah Stok: ");
            string stokInput = Console.ReadLine();
            if (int.TryParse(stokInput, out int stok) && stok >= 0)
            {
                b3.JumlahStok = stok;
                break;
            }
            Console.WriteLine("Jumlah Stok harus bilangan bulat lebih dari 0. Silakan coba lagi.");
        }

        Console.Write("Masukkan Kategori: ");
        b3.Kategori = Console.ReadLine();

        b3.TampilkanInfo();
        Console.WriteLine($"Status: {b3.StatusStok()}");
    }
}