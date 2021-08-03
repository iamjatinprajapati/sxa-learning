using System;
using System.Collections.Generic;
using System.Web;

namespace Sitecore.XA.Feature.SlickCarousel.Models
{
    public class CarouselSettings
    {
        public int Timeout { get; set; }

        public bool PauseEnabled { get; set; }

        public string Transition { get; set; }
    }
}