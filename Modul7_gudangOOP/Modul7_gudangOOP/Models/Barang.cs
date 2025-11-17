    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    namespace Modul7_GudangOOP.Models
    {
        public class Barang
        {
            public string KodeBarang;
            private string namaBarang;
            public string NamaBarang
            {
                get => namaBarang;
                set
                {
                    if (string.IsNullOrWhiteSpace(value))
                        throw new ArgumentException("NamaBarang tidak boleh kosong.", nameof(NamaBarang));
                    if (value.Length > 15)
                        throw new ArgumentException("NamaBarang maksimal 15 karakter.", nameof(NamaBarang));
                    namaBarang = value;
                }
            }
            private int jumlahStok;
            public int JumlahStok
            {
                get => jumlahStok;
                set
                {
                    // [Langkah 2 Modul 6] Validasi dengan Custom Exception
                    if (value < 0)
                    {
                        throw new StokNegatifException("Jumlah stok tidak boleh negatif.");
                    }
                    jumlahStok = value;
                }
            }
            public string Kategori { get; set; }

            // Read-only property per Langkah 5
            public string Status => JumlahStok > 50 ? "Aman" : "Perlu Reorder";

            public Barang(string kode, string nama, int stok, string kategori)
            {
                KodeBarang = kode;
                NamaBarang = nama;
                JumlahStok = stok;
                Kategori = kategori;
            }

            // Changed to virtual and removed Status from base output per assignment
            public virtual void TampilkanInfo()
            {
                Console.WriteLine($"[{KodeBarang}] {NamaBarang} - Stok: {JumlahStok}, Kategori: {Kategori}");
            }

            public string StatusStok()
            {
                return Status; // delegasi ke property read-only agar konsisten
            }
            public Barang()
            {
                KodeBarang = "UNKNOWN";
                NamaBarang = "Barang Baru";
                JumlahStok = 0;
                Kategori = "Umum";
            }
        }
    }
