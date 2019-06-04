using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate;
using IdentidadeAcesso.Domain.AggregatesModel.PerfilAggregate.Repository;
using IdentidadeAcesso.Domain.SeedOfWork.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Knowledge.IO.Infra.Data.Repository
{
    public class PerfilRepository : Repository<Perfil>, IPerfilRepository
    {
      
    }
}
