using QLPBService.DataAccess.Context;
using QLPBService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPBService.DataAccess.Repositories
{
    public interface IKhoiPhongBanRepository : IBaseRepository<KhoiPhongBan>
    {

    }

    public class KhoiPhongBanRepository : BaseRepository<KhoiPhongBan>, IKhoiPhongBanRepository
    {
        public KhoiPhongBanRepository(QLPBContext context) : base(context)
        {
        }
    }
}
