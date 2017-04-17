using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCP_Browser.ViewModel;

namespace SCP_Browser.Models.Sources
{
    public class EnglishSCPSource : SCPSourceBase
    {
        public EnglishSCPSource()
        {
            Name = "SCP Foundation - English";
            Language = "en-us";
        }

        public override async Task<SCPObject> ListObjects()
        {
            var urls = new string[] {
                "http://www.scp-wiki.net/scp-series",
                "http://www.scp-wiki.net/scp-series-2",
                "http://www.scp-wiki.net/scp-series-3",
                "http://www.scp-wiki.net/scp-series-4"
            };
        }

        public override async Task LoadHtmlContent(SCPObject scp)
        {
        }
    }
}
