using Sitecore.XA.Foundation.IoC;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sitecore.XA.Feature.SlickCarousel.Repositories
{
    public interface ISlickCarouselRepository : IModelRepository, IControllerRepository, IAbstractRepository<IRenderingModelBase>
    {

    }
}
