using PropertyChanged;
using SCP_Browser.Models.Sources;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SCP_Browser.ViewModel
{
    [ImplementPropertyChanged]
    public class SCPObject
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string HtmlContent { get; set; }

        public SCPSourceBase Source { get; set; }

        public SCPObject(string id, string name, string url)
        {
            Id = id;
            Name = name;
            Url = url;
            HtmlContent = "<p>Loading...</p>";
        }

        public async Task LoadHtmlContent()
        {
            await Source.LoadHtmlContent(this);
        }
    }
}
