using System;
using System.Collections.Generic;
using System.Linq;
using EPiServer;
using EPiServer.Core;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EpiEng;

public class ArticlePage : EpiPageModel<Models.Pages.ArticlePage>
{
  public ArticlePage(IEpiServerInitialize epi, IActionDescriptorCollectionProvider actionDescriptorCollectionProvider) : base(epi, actionDescriptorCollectionProvider)
  {

  }
}
