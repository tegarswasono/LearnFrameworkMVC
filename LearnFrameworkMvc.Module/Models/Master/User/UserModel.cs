using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFrameworkMvc.Module.Models.Master.User
{
    public class UserModel
    {
        public Guid Id { get; set; }
        public string Fullname { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Telp1 { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public bool Is_Active { get; set; }
    }
	public class CreateOrUpdateUserModel
	{
		public Guid Id { get; set; }
		public string Fullname { get; set; } = string.Empty;
		public string Username { get; set; } = string.Empty;
		public string Email { get; set; } = string.Empty;
		public string Telp1 { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
        public List<string> Roles { get; set; } = [];
		public bool IsActive { get; set; }
	}
}
