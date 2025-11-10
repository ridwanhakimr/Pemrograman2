using System;

namespace Modul6_GudangOOP.Models
{
    public interface IPeriksaKadaluarsa
    {
        DateTime TanggalKadaluarsa { get; set; }
        bool ApakahKadaluarsa();
    }
}