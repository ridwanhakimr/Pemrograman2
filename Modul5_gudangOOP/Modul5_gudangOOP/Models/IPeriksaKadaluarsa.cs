using System;

namespace Modul5_GudangOOP.Models
{
    public interface IPeriksaKadaluarsa
    {
        DateTime TanggalKadaluarsa { get; set; }
        bool ApakahKadaluarsa();
    }
}