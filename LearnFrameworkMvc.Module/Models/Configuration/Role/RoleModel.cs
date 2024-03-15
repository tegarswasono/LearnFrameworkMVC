using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFrameworkMvc.Module.Models.Master.Role
{
	public class RoleModel
	{
		public Guid ID { get; set; }
		public string NAME { get; set; } = string.Empty;
		public string DESCRIPTION { get; set; } = string.Empty;
	}
	public class CreateOrUpdateRoleModel
	{
		public Guid Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public string Functions { get; set; } = string.Empty;
	}
}
