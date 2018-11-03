using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeGenarator
{
    public interface ITypeChangesUtil
    {
         string EnChange(string namespaces, string tbname, List<TableProperModel> list);
    }
}
