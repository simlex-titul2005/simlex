using SX.WebCore.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace simlex.ViewModels
{
    public sealed class VMNetAccordion
    {
        public VMNetAccordion()
        {
            Nets = new SxVMSiteNet[0];
            Items = new Dictionary<string, IEnumerable<object>>();
        }

        public SxVMSiteNet[] Nets { get; set; }

        public Dictionary<string, IEnumerable<object>> Items { get; set; }

        public T[] GetItems<T>(string netCode)
        {
            var data = Items.ContainsKey(netCode) ? Items[netCode].Cast<T>() : new T[0];
            return data.ToArray();
        }
    }
}