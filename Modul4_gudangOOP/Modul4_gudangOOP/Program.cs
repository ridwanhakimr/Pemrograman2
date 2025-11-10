using Modul4_GudangOOP.Models;
using System;

class Program
{
    static void Main()
    {
        // Instansiasi menggunakan tipe dasar abstrak ItemGudang
        ItemGudang item1 = new BarangKimia("KIM001", "Asam Sulfat");
        ItemGudang item2 = new BarangMakanan("MAK001", "Susu Kental", DateTime.Parse("2023-12-01"));

        // Menguji method umum dan method abstract EvaluasiResiko
        Console.WriteLine("--- Tes Abstract Class ---");
        item1.CetakInfo();
        Console.WriteLine($"Resiko: {item1.EvaluasiResiko()}\n");

        item2.CetakInfo();
        Console.WriteLine($"Resiko: {item2.EvaluasiResiko()}");

        // Menguji Interface IPeriksaKadaluarsa
        Console.WriteLine("\n--- Tes Interface ---");
        if (item2 is IPeriksaKadaluarsa periksa)
        {
            Console.WriteLine($"Status Barang {item2.Nama}: {(periksa.ApakahKadaluarsa() ? "Kadaluarsa" : "Masih berlaku")}");
        }
    }
}