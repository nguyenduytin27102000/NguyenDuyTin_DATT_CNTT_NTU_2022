using System;
using System.Collections.Generic;

#nullable disable

namespace QLPBService.Domain.Entities
{
    public partial class ChucVu
    {
        public ChucVu()
        {
            CongChucVienChucs = new HashSet<CongChucVienChuc>();
        }

        public int Id { get; set; }
        public string TenChucVu { get; set; }

        public virtual ICollection<CongChucVienChuc> CongChucVienChucs { get; set; }
    }
}
