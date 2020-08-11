
关于Ocean3D 框架?
=====================
Ocean3D是一套基于.net core 3.1开发的领域驱动设计框架，这套框架主要用于大家学习一些.net core
的开发知识，帮助大家了解领取驱动的开发模式。

## 求一颗星星！
=====================
如果你觉得框架对你有一点帮助请帮我点一些星星:)

## 如何开始？
=====================
首先我门需要配置数据源，打开项目在Ocean.Api应用程序中找到appsettings.json文件，文件中有一个链接节点。

```csharp
 "ConnectionStrings": {
    "MsSqlServer": "Data Source=192.168.31.195;initial catalog=WaterMargin;password=123456;User id=sa;Trusted_Connection=False;MultipleActiveResultSets=True",
    "StoreSqlServer": "Data Source=192.168.31.195;initial catalog=WaterMargin;password=123456;User id=sa;Trusted_Connection=False;MultipleActiveResultSets=True"
  },
```csharp

上面"MsSqlServer"是链接你的主要应用的主数据源,"StoreSqlServer"是用来存储你的事件溯源记录的链接，作者这里使用了相同的链接，希望小伙伴们在实际开发中还是要区分开。
配置好链接字符串后我们就需要生成数据库，可以采用EF CORE 的数据迁移功能，在你的程序包管理器控制台运行如下代码。
```csharp
Add-migration init -c EFContext

Update-DataBase -c EFContext
```csharp

如果一切顺利这个时候已经生成了数据库，可以运行程序开始学习了。如果你不喜欢用数据迁移功能作者在SQL文件夹下面提供了sql 脚本（sqlservice）共大家生成数据库。


## 如何使用:
=====================
- 作者已经内置了一些模块给大家做参考.

- 代码中有大量的注释帮助小伙伴们分析代码。

- 还可以通过我的博客学习到更多内容


## 技术实现:
=====================
- ASP.NET Core 3.1 (with .NET Core 3.1)
 - ASP.NET WebApi Core
 - ASP.NET Identity Core
- Entity Framework Core 3.1
- Dapper
- AutoMapper
- FluentValidator
- MediatR
- Swagger UI with JWT support
- AutoFac
- serilog
- Swashbuchkle.JWT

## 架构设计:
=====================
- 仓储模式遵守职责分离规则
- 领域驱动建模
- 领域事件
- 领域指令
- 指令模型验证
- CQRS 读写分离
- 事件溯源历史追踪
- 工作单元事务的一致性

## 如何联系作者:
=====================
小伙伴们需要问题可以联系作者QQ ：286463642
