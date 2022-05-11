using System;
using System.Collections.Generic;

#nullable disable

namespace QLPBService.Domain.Entities
{
    public partial class CongChucVienChuc
    {
        public int Id { get; set; }
        public string HoTen { get; set; }
        public bool LaDaiDienPb { get; set; }
        public int ChucVuId { get; set; }
        public int PhongBanId { get; set; }
        public int? TrinhDoId { get; set; }

        public virtual ChucVu ChucVu { get; set; }
        public virtual PhongBan PhongBan { get; set; }
        public virtual TrinhDo TrinhDo { get; set; }
    }
}
