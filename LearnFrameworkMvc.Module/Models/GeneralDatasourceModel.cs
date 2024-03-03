using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFrameworkMvc.Module.Models
{
    public class GeneralDatasourceModel
    {
        public Guid Value { get; set; }
        public string Text { get; set; } = string.Empty;
        public bool Selected { get; set; }
    }
}
