using EPiServer.Data;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace testEpiCore.EpiServer
{
    [ModuleDependency(typeof(DataInitialization))]
    public class DataAccessInitialization : IConfigurableModule
    {
        public void ConfigureContainer(ServiceConfigurationContext context)
        {
        context.Services.Configure<DataAccessOptions>(o => o.SetConnectionString(@"Data Source=(LocalDb)\MSSQLLocalDB;AttachDbFilename=E:\github\epicore\testEpiCore\EpiserverSiteAlloy\App_Data\EPiServerDB_4208d7f1.mdf;Initial Catalog=EPiServerDB_4208d7f1;Connection Timeout=60;Integrated Security=True;MultipleActiveResultSets=True"));
        }

        public void Initialize(InitializationEngine context)
        { }

        public void Uninitialize(InitializationEngine context)
        { }
    }
}
