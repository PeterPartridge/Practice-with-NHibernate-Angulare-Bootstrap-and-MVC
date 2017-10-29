using DataLayer.Mapping;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using NHibernate.Tool.hbm2ddl;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NHibernate;
using NHibernate.Driver;
using NHibernate.Cfg;
using DataLayer.Class;

namespace DataLayer.SessionFactory
{
   public class DatabaseFactory
    {
        private static ISessionFactory _sessionFactory;

        public void CreateDB()
        {
            var config = new Configuration();

            config = Fluently.Configure()
           /*    .Database(
                MsSqlConfiguration.MsSql2008.ConnectionString(c => c.FromConnectionStringWithKey("Default")).ShowSql())
                .Mappings(
                m => m.FluentMappings.AddFromAssemblyOf<CompanyMap>().AddFromAssemblyOf<UserMap>()
                )*/.BuildConfiguration();



            Console.WriteLine("Database Generated");
            var exporter = new SchemaExport(config);
       //    exporter.Execute(true, false, true);
            exporter.Execute(true, true, false);

            _sessionFactory = config.BuildSessionFactory();

            SeedData _sd = new SeedData();

           List<Company> compList = _sd.CreateCompany();

            Wage wg = _sd.CreateWageBand();

            using (ISession session = _sessionFactory.OpenSession())
            {
                using (var transaction = session.BeginTransaction())
                {
                    foreach (var item in compList)
                    {
                        session.SaveOrUpdate(item);
                       
                    }

                    session.SaveOrUpdate(wg);

                    transaction.Commit();
                    session.Flush();
                   Console.WriteLine("Company Generated");
                }
            }

           
       
        }
    }
}
