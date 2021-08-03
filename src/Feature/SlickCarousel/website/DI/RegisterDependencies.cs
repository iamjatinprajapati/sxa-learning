using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.XA.Feature.SlickCarousel.Controllers;
using Sitecore.XA.Feature.SlickCarousel.Repositories;
using System;
using System.Collections.Generic;
using System.Web;

namespace Sitecore.XA.Feature.SlickCarousel.DI
{
    public class RegisterDependencies : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTransient<ISlickCarouselRepository, SlickCarouselRepository>();
            serviceCollection.AddTransient<SlickCarouselController>();
        }
    }
}