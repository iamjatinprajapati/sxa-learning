using Sitecore.XA.Feature.Composites.Models;
using System;
using System.Collections.Generic;
using System.Web;

namespace Sitecore.XA.Feature.SlickCarousel.Models
{
    public class SlickCarouselRenderingModel : CompositeComponentRenderingModel
    {
        public string ContainerClass { get; set; }

        public string JsonDataProperties { get; set; }

        public CarouselSettings Settings { get; set; }
    }
}