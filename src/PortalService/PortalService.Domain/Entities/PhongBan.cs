using System;
using System.Collections.Generic;

#nullable disable

namespace PortalService.Domain.Entities
{
    public partial class PhongBan
    {
        public PhongBan()
        {
            CongChucVienChucs = new HashSet<CongChucVienChuc>();
        }

        public int Id { get; set; }
        public string TenPb { get; set; }
        public string DiaChi { get; set; }
        public string Fax { get; set; }
        public string Sdt { get; set; }
        public string Email { get; set; }
        public string Website { get; set; }
        public string Stk { get; set; }
        public string NganHang { get; set; }
        public int? KhoiPbid { get; set; }

        public virtual KhoiPhongBan KhoiPb { get; set; }
        public virtual ICollection<CongChucVienChuc> CongChucVienChucs { get; set; }
    }
}
