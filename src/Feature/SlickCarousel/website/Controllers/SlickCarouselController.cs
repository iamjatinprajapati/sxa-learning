using Sitecore.XA.Feature.SlickCarousel.Repositories;
using Sitecore.XA.Foundation.Mvc.Controllers;
using System;
using System.Collections.Generic;
using System.Web;

namespace Sitecore.XA.Feature.SlickCarousel.Controllers
{
    public class SlickCarouselController : StandardController
    {
        public ISlickCarouselRepository SlickCarouselRepository { get; set; }

        public SlickCarouselController(ISlickCarouselRepository slickCarouselRepository) => this.SlickCarouselRepository = slickCarouselRepository;

        protected override object GetModel()
        {
            return this.SlickCarouselRepository.GetModel();
        }

        public override System.Web.Mvc.ActionResult Index()
        {
            return base.Index();
        }
    }
}