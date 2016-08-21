using Autofac;
using MyApp.Bootstrapper;
using MyApp.Domain;
using MyApp.Infrastructure.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var scope = Bootstrap.Create().BeginLifetimeScope())
            {
                using (var uow = scope.Resolve<IUnitOfWork>())
                {
                    var repo = scope.Resolve<ILegoSetRepository>();
                    var draftRepo = scope.Resolve<IDraftLegoSetRepository>();

                    var draft = new DraftLegoSet
                    {
                        Name = "drafttest",
                        IsMint = true,
                        IsSold = true,
                        Price = new Money(10, Currency.Euro),
                    };

                    draftRepo.Add(draft);
                    uow.Commit();

                    var publisher = scope.ResolveOptional<ILegoSetPublisherDomainService>();

                    publisher.Publish(draft.Id);

                    uow.Commit();
                }
            }
        }
    }
}
