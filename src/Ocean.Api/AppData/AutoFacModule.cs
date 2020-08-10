using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Autofac;
using FluentValidation;
using MediatR;
using Ocean.Domain.Core.Bus;
using Ocean.Domain.Core.Events;
using Ocean.Domain.Hostility.Command;
using Ocean.Domain.Hostility.Event;
using Ocean.Domain.Validations;
using Ocean.Infrastructure.Behaviors;
using Ocean.Infrastructure.EventBus;
using Ocean.Infrastructure.Repositorys.store;

namespace Ocean.Api.AppData
{
    public class AutoFacModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType(typeof(InEventBus)).As(typeof(IMediatorHandler));
            builder.RegisterType(typeof(EventStore)).As(typeof(IEventStore));
            builder.RegisterType(typeof(EventStoreRepository)).As(typeof(IEventStoreRepository));

            //注入所有command指令
            builder.RegisterAssemblyTypes(typeof(AddHostilityCommand).GetTypeInfo().Assembly)
                   .AsClosedTypesOf(typeof(IRequestHandler<,>));

            //注入所有的领域事件
            builder.RegisterAssemblyTypes(typeof(HotilityEventHandle).GetTypeInfo().Assembly)
             .AsClosedTypesOf(typeof(INotificationHandler<>));

            //注入所有的command指令验证类
            builder.RegisterAssemblyTypes(typeof(CreateHotilityVaildate).GetTypeInfo().Assembly)
                   .Where(t => t.IsClosedTypeOf(typeof(IValidator<>)))
                   .AsImplementedInterfaces();

            //注入command指令管道
            builder.RegisterGeneric(typeof(LoggingBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(ValidatorBehavior<,>)).As(typeof(IPipelineBehavior<,>));
            builder.RegisterGeneric(typeof(TransactionBehaviour<,>)).As(typeof(IPipelineBehavior<,>));
        }
    }
}
