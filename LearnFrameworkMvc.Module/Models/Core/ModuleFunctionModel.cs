namespace LearnFrameworkMvc.Module.Models.Core
{
    public class ModuleFunctionModel
    {
        public string Id { get; set; } = string.Empty;
        public string IdText { get; set; } = string.Empty;
        public string Module { get; set; } = string.Empty;
        public string FunctionName { get; set; } = string.Empty;
        public int Order { get; set; }
    }
}
