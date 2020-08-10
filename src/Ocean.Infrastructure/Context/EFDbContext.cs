
using MediatR;
using Microsoft.EntityFrameworkCore;
using Ocean.Domain.Core.Bus;
using Ocean.Domain.Core.Events;
using Ocean.Domain.Core.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Ocean.Infrastructure.Context
{
    public class EFDbContext : BaseContext
    {
        public EFDbContext(IMediatorHandler mediator,DbContextOptions<EFDbContext> options):base(mediator, options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();
            //循环添加实体映射
            var typesToRegister = Assembly.GetExecutingAssembly().GetTypes().Where(q => q.GetInterface(typeof(IEntityTypeConfiguration<>).FullName) != null);
            foreach (var type in typesToRegister)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.ApplyConfiguration(configurationInstance);
            }

            //有一些关联表映射是不需要 下面的属性的 但是继承了BaseEntity 就带了这些属性.
            //所以下面的代码就是查找“Relation” class 来忽略这些属性
            var iglist = new List<string> { "CreateTime", "CreateBy", "UpdateTime", "UpdateBy" };
            modelBuilder.Model.GetEntityTypes().Where(a => a.Name.EndsWith("Relation")).ToList()
                .ForEach(l =>
                {
                    l.GetProperties().Where(c => iglist.Contains(c.Name)).ToList().ForEach(b =>
                    {
                        modelBuilder.Entity(l.Name).Ignore(b.Name);
                    });
                });
        }

    }
}
