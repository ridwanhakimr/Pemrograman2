namespace Modul5_GudangOOP.Models
{
    public class BarangKimia : ItemGudang
    {
        public BarangKimia(string kode, string nama) : base(kode, nama) { }

        public override string EvaluasiResiko()
        {
            return "Perlu penyimpanan khusus bahan berbahaya.";
        }
    }
}