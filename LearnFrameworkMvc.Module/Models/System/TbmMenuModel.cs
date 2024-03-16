using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFrameworkMvc.Module.Models.System
{
    public class TbmMenuModel
    {
        public Guid Id { get; set; }
        public Guid? ParentId { get; set; }    
        public string Title { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public string IconClass { get; set; } = string.Empty;
        public int OrderIndex { get; set; }
        public bool Visible { get; set; }
        public string FunctionId { get; set; } = string.Empty;
        public string Section { get; set; } = string.Empty;

        public DateTime CreatedAt { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime UpdatedAt { get; set; }
        public string UpdatedBy { get; set; } = string.Empty;
    }
}
