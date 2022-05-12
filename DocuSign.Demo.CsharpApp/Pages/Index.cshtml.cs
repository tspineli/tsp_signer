using DocuSign.Demo.CsharpApp.Settings;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;

namespace DocuSign.Demo.CsharpApp.Pages
{
    public class IndexModel : PageModel
  {
    public string DocuSignIDPBaseURL { get; }
    public DocuSignSettings docusignconfig;

    public IndexModel(IConfiguration configuration, DocuSignSettings dsconfig)
    {
        DocuSignIDPBaseURL = dsconfig.IDPServerBaseUrl;
    }

    public void OnGet()
    {
    }
  }
}
