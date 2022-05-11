using Microsoft.EntityFrameworkCore;
using QLPBService.Application.Interfaces;
using QLPBService.DataAccess.Repositories;
using QLPBService.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QLPBService.Application.Services
{
    public interface IKhoiPhongBanCRUDService : ICRUD<IKhoiPhongBanRepository, KhoiPhongBan>
    {

    }

    public class KhoiPhongBanCRUDService : CRUD<IKhoiPhongBanRepository, KhoiPhongBan>, IKhoiPhongBanCRUDService
    {
        public KhoiPhongBanCRUDService(IKhoiPhongBanRepository repository) : base(repository)
        {
        }

        public override async Task Put(int id, KhoiPhongBan entity)
        {
            if (id != entity.Id)
            {
                return;
            }
            await _repository.UpdateAsync(entity);
        }
    }
}
