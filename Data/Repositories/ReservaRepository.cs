using ProjetoNugets.Data.Interfaces;
using ProjetoNugets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.Data.Repositories
{
    public class ReservaRepository : RepositoryBase<Reserva>, IReservaRepository
    {
        public ReservaRepository(AppDbContext db) : base(db)
        {

        }
    }
}
