using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace MSBuilder
{
    public class ImportItemGroup : IEnumerable<ImportItem>, IItemGroup
    {
        private List<ImportItem> _ii = new List<ImportItem>();

        public void AddImportItem(ImportItem item)
        {
            _ii.Add(item);
        }

        public IEnumerator<ImportItem> GetEnumerator()
        {
            return _ii.GetEnumerator();
        }

        public ImportItem this[int number]
        {
            get
            {
                return _ii[number];
            }
            set
            {
                _ii[number] = value;
            }
        }

        public string GetXml()
        {
            var result = _ii.Select(x => x.GetXml()).Aggregate((a, b) => a + Environment.NewLine + b);
            return result;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
