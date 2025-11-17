using System;

namespace Modul6_GudangOOP.Models
{
    // [Langkah 2 Modul 6] Membuat Custom Exception
    public class StokNegatifException : Exception
    {
        public StokNegatifException(string pesan) : base(pesan) { }
    }
}