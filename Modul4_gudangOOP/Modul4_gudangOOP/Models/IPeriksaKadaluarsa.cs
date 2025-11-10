using System;

namespace Modul4_GudangOOP.Models
{
    public interface IPeriksaKadaluarsa
    {
        DateTime TanggalKadaluarsa { get; set; }
        bool ApakahKadaluarsa();
    }
}