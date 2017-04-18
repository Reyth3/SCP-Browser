using SCP_Browser.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP_Browser.Models.Sources
{
    public abstract class SCPSourceBase
    {
        public string Name { get; set; }
        public string Language { get; set; }

        public abstract Task<List<SCPObject>> ListObjects();
        public abstract Task LoadHtmlContent(SCPObject scp);

    }
}
