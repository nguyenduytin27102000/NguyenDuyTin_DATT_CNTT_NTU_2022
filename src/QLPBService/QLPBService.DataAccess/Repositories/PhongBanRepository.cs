using QLPBService.DataAccess.Context;
using QLPBService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPBService.DataAccess.Repositories
{
    public interface IPhongBanRepository : IBaseRepository<PhongBan>
    {

    }

    public class PhongBanRepository : BaseRepository<PhongBan>, IPhongBanRepository
    {
        public PhongBanRepository(QLPBContext context) : base(context)
        {
        }
    }
}
