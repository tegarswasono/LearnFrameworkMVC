using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFrameworkMvc.Module.Models.Master.User
{
    public class UserModel
    {
        public Guid ID { get; set; }
        public string FULLNAME { get; set; } = string.Empty;
        public string USERNAME { get; set; } = string.Empty;
        public string EMAIL { get; set; } = string.Empty;
        public string TELP1 { get; set; } = string.Empty;
        public string DESCRIPTION { get; set; } = string.Empty;
        public bool IS_ACTIVE { get; set; }
    }
}
