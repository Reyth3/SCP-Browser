using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SCP_Browser.ViewModel;
using System.Net.Http;
using HtmlAgilityPack;
using System.Net;

namespace SCP_Browser.Models.Sources
{
    public class EnglishSCPSource : SCPSourceBase
    {
        public EnglishSCPSource()
        {
            Name = "SCP Foundation - English";
            Language = "en-us";
        }

        public override async Task<List<SCPObject>> ListObjects()
        {
            var urls = new string[] {
                "http://www.scp-wiki.net/scp-series",
                "http://www.scp-wiki.net/scp-series-2",
                "http://www.scp-wiki.net/scp-series-3",
                "http://www.scp-wiki.net/scp-series-4"
            };
            var scps = new List<SCPObject>();

            foreach (var url in urls)
            {
                using (var http = new HttpClient())
                using (var res = await http.GetAsync(url))
                    if (res.IsSuccessStatusCode)
                    {
                        var doc = new HtmlDocument();
                        doc.LoadHtml(await res.Content.ReadAsStringAsync());
                        var list = doc.DocumentNode.Descendants("li").Where(p => p.ChildNodes.FirstOrDefault(o => o.Name == "a") != null && p.InnerText.StartsWith("SCP-")).Select(p => new SCPObject(p.Element("a").InnerText.Trim(), WebUtility.HtmlDecode(p.LastChild.InnerText.Replace("-", "").Trim()), p.Element("a").GetAttributeValue("href", "")));
                        scps.AddRange(list);
                    }
            }
            return scps;
        }

        public override async Task LoadHtmlContent(SCPObject scp)
        {
            using (var http = new HttpClient())
            using (var res = await http.GetAsync(scp.Url))
                if (res.IsSuccessStatusCode)
                {
                    var doc = new HtmlDocument();
                    doc.LoadHtml(await res.Content.ReadAsStringAsync());
                    var div = doc.DocumentNode.Descendants("div").Where(o => o.GetAttributeValue("id", "") == "page-content");
                    scp.HtmlContent = div.First().InnerHtml;
                }
        }
    }
}
