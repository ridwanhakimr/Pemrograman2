using Modul1_gudangOOP.Models;
using System;
class Program
{
    static void Main()
    {
        Barang b1 = new Barang("BRG001", "Karton", 120, "Kemasan");
        Barang b2 = new Barang("BRG002", "Bubble Wrap", 40, "Pelindung");

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
        Console.Write("Masukkan Nama Barang: ");
        b3.NamaBarang = Console.ReadLine();
        Console.Write("Masukkan Kode Barang: ");
        b3.KodeBarang = Console.ReadLine();
        Console.Write("Masukkan Jumlah Stok: ");
        Console.Write("Masukkan Jumlah Stok: ");
        b3.JumlahStok = int.Parse(Console.ReadLine());
        Console.Write("Masukkan Kategori: ");
        b3.Kategori = Console.ReadLine();
        b3.TampilkanInfo();
        Console.WriteLine($"Status: {b3.StatusStok()}");
    }
}