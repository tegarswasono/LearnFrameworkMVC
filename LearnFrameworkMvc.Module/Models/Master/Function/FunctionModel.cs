using LearnFrameworkMvc.Module.Models.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LearnFrameworkMvc.Module.Models.Master.Function
{
	public class FunctionModel : BaseActionIdentity
	{
		public string ID { get; set; } = string.Empty;
		public string MODULE_ID { get; set; } = string.Empty;
		public string NAME { get; set; } = string.Empty;
		public string DESCRIPTION { get; set; } = string.Empty;
		public bool ISCHECKED { get; set; }
	}
	public class FunctionVM
	{
		public string Module { get; set; } = string.Empty;
		public List<FunctionVMFunction> Functions { get; set; } = [];
		public static List<FunctionVM> Dto(List<FunctionModel> param)
		{
			var modules = param.GroupBy(x => x.MODULE_ID).Select(x => x.Key).ToList();
			var result = new List<FunctionVM>();
			foreach (var module in modules)
			{
				var moduleFunctionVM = new FunctionVM()
				{
					Module = module,
					Functions = param.Where(x => x.MODULE_ID == module).Select(x => new FunctionVMFunction() { Id = x.ID, Function = x.NAME, IsChecked = x.ISCHECKED }).ToList()
				};
				result.Add(moduleFunctionVM);
			}
			return result;
		}
	}
	public class FunctionVMFunction
	{
		public string Id { get; set; } = string.Empty;
		public string Function { get; set; } = string.Empty;
		public bool IsChecked { get; set; }
	}
}
