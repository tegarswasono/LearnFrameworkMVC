﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFrameworkMvc.Module.Models
{
	public class GeneralResponseMessage
	{
		public string Message { get; set; } = string.Empty;
		public static GeneralResponseMessage Dto(string message)
		{
			return new GeneralResponseMessage { Message = message };
		}
		public static GeneralResponseMessage ProcessSuccessfully()
		{
			return new GeneralResponseMessage { Message = ConstantString.ProcessSuccessfully };
		}
		public static GeneralResponseMessage DeleteSuccessfully()
		{
			return new GeneralResponseMessage { Message = ConstantString.DeleteSuccessfully };
		}
	}
}
