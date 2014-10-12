﻿using Abp.Configuration.Startup;
using Abp.Localization;
using Abp.Localization.Sources;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;

namespace Abp.Dependency.Installers
{
    internal class AbpCoreInstaller : IWindsorInstaller
    {
        public void Install(IWindsorContainer container, IConfigurationStore store)
        {
            RegisterStartupSystem(container);
            RegisterLocalizationSystem(container);
        }

        private static void RegisterStartupSystem(IWindsorContainer container)
        {
            container.Register(

                Component.For<IAbpStartupConfiguration, AbpStartupConfiguration>().ImplementedBy<AbpStartupConfiguration>().LifestyleSingleton(),
                Component.For<INavigationConfiguration, NavigationConfiguration>().ImplementedBy<NavigationConfiguration>().LifestyleSingleton(),
                
                Component.For<IModuleFinder>().ImplementedBy<DefaultModuleFinder>().LifestyleTransient(),
                Component.For<IAbpModuleManager>().ImplementedBy<AbpModuleManager>().LifestyleSingleton()
                );
        }

        private static void RegisterLocalizationSystem(IWindsorContainer container)
        {
            container.Register(
                Component.For<ILocalizationManager>().ImplementedBy<LocalizationManager>().LifestyleSingleton()
                );
        }
    }
}
