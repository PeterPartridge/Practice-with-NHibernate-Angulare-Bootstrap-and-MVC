using CoreBusinessLayer.IdentityCalls;
using CoreDataLayer.Class;
using CoreDataLayer.Class;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using Microsoft.AspNet.Identity;
using NHibernate;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreBusinessLayer.Factories
{
    public class IdentityFactory
    {
        /*  private readonly ISessionFactory sessionFactory;

          public IdentityFactory()
          {
              var connectionString = ConfigurationManager.ConnectionStrings["default"].ConnectionString;
              sessionFactory = Fluently.Configure()
                  .Database(MsSqlConfiguration.MsSql2008.ConnectionString(connectionString))
                  .Mappings(m => m.FluentMappings.AddFromAssemblyOf<User>())
                  .BuildSessionFactory();
          }
          public ISession MakeSession()
          {
              return sessionFactory.OpenSession();
          }

          public IUserStore<User, Guid> Users
          {
              get { return new IdentityStore(MakeSession()); }
          }*/
    }
}

