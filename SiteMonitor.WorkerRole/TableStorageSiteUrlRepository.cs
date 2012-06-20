using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace SiteMonitor.WorkerRole
{
    public class TableStorageSiteUrlRepository : ISiteUrlRepository
    {
        GenericTableDataRepository<StoredSiteUrl> _repo;

        public TableStorageSiteUrlRepository()
        {
            _repo = new GenericTableDataRepository<StoredSiteUrl>("SiteUrls");
        }

        public List<string> GetUrls()
        {
            var r = _repo.GetEntries();
            return r.Select(x => x.Url).ToList();
        }

        public void Add(string url)
        {
            _repo.AddEntry(new StoredSiteUrl
            {
                Url = url
            });

            Trace.WriteLine("Site Added: " + url);
        }

        public void Remove(string url)
        {
            var target = _repo.GetEntries().First(x => x.Url == url);
            _repo.Delete(x => x.Url == url);

            Trace.WriteLine("Site Removed: " + url);
        }
    }
}
