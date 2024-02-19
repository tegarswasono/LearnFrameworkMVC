using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFrameworkMvc.Module.Models
{
	public class BaseActionIdentity
	{
		public DateTime CREATED_AT { get; set; }
		public string CREATED_BY { get; set; } = string.Empty;
		public DateTime UPDATED_AT { get; set; }
		public string UPDATED_BY { get; set; } = string.Empty;
	}
}
