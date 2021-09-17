using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace vidly.ViewModels
{
    public class TableViewModel<T>
    {
        public List<string> Columns { set; get; }
        public List<T> Rows { get; set; }
    }
}