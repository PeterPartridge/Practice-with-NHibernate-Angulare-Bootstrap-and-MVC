using CoreDataLayer.Class;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate;

namespace CoreBusinessLayer.Factories
{
    public  class UserCompanyVehicleFactory
    {
       public static ISessionFactory _sessionFactory;


        public void BuildCompanyUserVehicleQueryFactory()
        {
            var config = Fluently.Configure()
             .Database(
              MsSqlConfiguration.MsSql2012.ConnectionString(c => c.FromConnectionStringWithKey("Default")).ShowSql())
              .Mappings(
              m => m.FluentMappings.AddFromAssemblyOf<CompanyMap>().AddFromAssemblyOf<User>().AddFromAssemblyOf<Vehicle>()
            ).BuildConfiguration();


            _sessionFactory = config.BuildSessionFactory();
        }
    }
}
