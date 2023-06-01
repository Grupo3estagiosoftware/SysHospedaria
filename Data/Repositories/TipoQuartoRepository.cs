using ProjetoNugets.Data.Interfaces;
using ProjetoNugets.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjetoNugets.Data.Repositories
{
    public class TipoQuartoRepository : RepositoryBase<Preco>, ITipoQuartoRepository
    {
        public TipoQuartoRepository(AppDbContext db) : base(db)
        {

        }
    }
}
