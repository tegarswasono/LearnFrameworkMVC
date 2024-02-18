using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFrameworkMvc.Module.Models
{
	public class ExecuteSPDefaultModel
	{
		public bool IsValid { get; set; }
		public string MsgError { get; set; } = string.Empty;
	}
}
