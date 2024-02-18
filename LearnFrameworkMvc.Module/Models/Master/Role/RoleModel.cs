﻿using System;
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

	public class RoleIndexVM
	{
		public List<RoleModel> Data { get; set; } = new List<RoleModel>();
	}
	public class CreateOrUpdateRoleModel
	{
		public Guid ID { get; set; }
		public string NAME { get; set; } = string.Empty;
		public string DESCRIPTION { get; set; } = string.Empty;
	}
}