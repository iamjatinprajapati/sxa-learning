using Sitecore.XA.Feature.Composites.Repositories;
using Sitecore.XA.Feature.SlickCarousel.Models;
using Sitecore.XA.Foundation.IoC;
using Sitecore.XA.Foundation.Mvc.Repositories.Base;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace Sitecore.XA.Feature.SlickCarousel.Repositories
{
    public class SlickCarouselRepository : CompositeComponentRepository, ISlickCarouselRepository, IModelRepository, IControllerRepository, IAbstractRepository<IRenderingModelBase>
    {
        public override IRenderingModelBase GetModel()
        {
            var model = new SlickCarouselRenderingModel();
            FillBaseProperties(model);
            model.ContainerClass = "slick-carousel";
            return model;
        }
    }
}