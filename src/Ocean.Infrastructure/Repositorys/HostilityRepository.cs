using Ocean.Domain.Hostility.Entity;
using Ocean.Domain.Repository;
using Ocean.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ocean.Infrastructure.Repositorys
{
   public class HostilityRepository: Repository<HostilityEntity,string>,IHostilityRepository
    {
        public HostilityRepository(EFDbContext context):base(context) { 
        
        }
    }
}
