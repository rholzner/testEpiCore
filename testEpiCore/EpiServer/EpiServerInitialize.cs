using System;
using System.Collections.Generic;
using System.Reflection;
using EPiServer.Data;
using EPiServer.Framework;
using EPiServer.Framework.Initialization;
using EPiServer.ServiceLocation;

namespace testEpiCore.EpiServer
{
    //https://world.episerver.com/forum/developer-forum/-Episerver-75-CMS/Thread-Container/2018/5/build-out-site-page-hierarchy-programmatically---getting-started/
    public class EpiServerInitialize : IEpiServerInitialize
    {
        private readonly InitializationEngine engine;
        public EpiServerInitialize()
        {
        engine = new InitializationEngine((IEnumerable<IInitializableModule>)null, HostType.TestFramework, EPiServerAssemblies());
        engine.Initialize();

        }

        private static IEnumerable<Assembly> EPiServerAssemblies()
        {
        var assemblies = new List<Assembly>();
        assemblies.Add(typeof(Program).Assembly);//this
        assemblies.Add(typeof(ConnectionStringOptions).Assembly);//EPiServer.Data
        assemblies.Add(typeof(InitializableModuleAttribute).Assembly);//EPiServer.Framework
        assemblies.Add(typeof(EPiServer.Core.IContent).Assembly);//EPiServer
        assemblies.Add(typeof(EPiServer.Enterprise.IDataExporter).Assembly);//EPiServer.Enterprise
        assemblies.Add(typeof(EPiServer.Personalization.VisitorGroups.VisitorGroupCriterion).Assembly);//EPiServer.ApplicationModules
        assemblies.Add(typeof(EPiServer.Events.EventMessage).Assembly);//EPiServer.Events
        assemblies.Add(typeof(StructureMapServiceLocator).Assembly);//EPiServer.ServiceLocation.StructureMap
        return assemblies;
        }

        public T GetInstance<T>()
        {
         return engine.Locate.Advanced.GetInstance<T>();
        }
    }
}
