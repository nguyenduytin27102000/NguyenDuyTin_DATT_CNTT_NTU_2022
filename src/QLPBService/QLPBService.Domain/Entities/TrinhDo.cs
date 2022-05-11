using System;
using System.Collections.Generic;

#nullable disable

namespace QLPBService.Domain.Entities
{
    public partial class TrinhDo
    {
        public TrinhDo()
        {
            CongChucVienChucs = new HashSet<CongChucVienChuc>();
        }

        public int Id { get; set; }
        public string CapBac { get; set; }
        public string VietTat { get; set; }

        public virtual ICollection<CongChucVienChuc> CongChucVienChucs { get; set; }
    }
}
