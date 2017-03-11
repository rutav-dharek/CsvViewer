using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReadFile
{
    /// <summary>
    /// This Interface exposes contracts to Convert collection of string into Data Table
    /// </summary>
    public interface IDataTableConverter
    {
        DataTable Convert(IEnumerable<string> sourceData);
    }
}
