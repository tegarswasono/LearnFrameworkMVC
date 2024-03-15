using LearnFrameworkMvc.Module.Models;

namespace LearnFrameworkMvc.Module
{
    public static class ModuleFunction
    {
        public static List<ModuleFunctionModel> GetAll()
        {
#pragma warning disable CS8601 // Possible null reference assignment.

            int a = 1;
            var result = typeof(ModuleFunction)
                .GetFields()
                .Select(x => new ModuleFunctionModel 
                { 
                    //Id = x.Name, 
                    Id = x.GetValue(null)?.ToString(),
					IdText = x.GetValue(null)?.ToString(),
                    Module = x.GetValue(null)?.ToString()?.Split(".")[0],
                    FunctionName = x.GetValue(null)?.ToString()?.Split(".")[1],
                    Order = a++
                }).ToList();
#pragma warning restore CS8601 // Possible null reference assignment.
            return result;
        }

		public const string BookingsView = "Bookings.View";

		public const string CategoryView = "Category.View";
		public const string CategoryAdd = "Category.Add";
		public const string CategoryEdit = "Category.Edit";
		public const string CategoryDelete = "Category.Delete";
		public const string CategorySearch = "Category.Search";
		public const string CategoryDownload = "Category.Download";
		public const string CategoryUpload = "Category.Upload";

		public const string ProductView = "Product.View";
		public const string ProductAdd = "Product.Add";
		public const string ProductEdit = "Product.Edit";
		public const string ProductDelete = "Product.Delete";
		public const string ProductSearch = "Product.Search";
		public const string ProductDownload = "Product.Download";
		public const string ProductUpload = "Product.Upload";

		public const string RolesView = "Roles.View";
        public const string SMTPSettingView = "SMTPSetting.View";
        public const string SystemConfigurationView = "SystemConfiguration.View";
        public const string UsersView = "Users.View";

	}
}
