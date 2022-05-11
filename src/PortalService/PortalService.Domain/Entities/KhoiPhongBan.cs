using System;
using System.Collections.Generic;

#nullable disable

namespace PortalService.Domain.Entities
{
    public partial class KhoiPhongBan
    {
        public KhoiPhongBan()
        {
            PhongBans = new HashSet<PhongBan>();
        }

        public int Id { get; set; }
        public string TenKhoiPb { get; set; }

        public virtual ICollection<PhongBan> PhongBans { get; set; }
    }
}
