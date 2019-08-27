using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EpiBlazor.EpiEng;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EpiBlazor.Pages
{
  public class StandardPageModel : EpiPageModel<Models.Pages.StandardPage>
  {
    public StandardPageModel(IEpiServerInitialize epi, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider) : base(epi,actionDescriptorCollectionProvider)
    {

    }
  }
}