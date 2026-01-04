using System.ComponentModel.DataAnnotations; // Tambahkan ini untuk validasi

namespace GudangWebApp.Models
{
    public class Barang
    {
        public int Id { get; set; } // Primary Key (Wajib ada untuk EF Core)

        [Required]
        public string KodeBarang { get; set; } // Sesuai modul

        [Required]
        public string NamaBarang { get; set; } // Sesuai modul

        [Range(0, int.MaxValue)]
        public int JumlahStok { get; set; } // Sesuai modul

        public string Kategori { get; set; }
    }
}