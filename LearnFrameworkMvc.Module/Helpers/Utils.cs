using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LearnFrameworkMvc.Module.Helpers
{
    public static class Utils
    {
        #pragma warning disable IDE0057 // Use range operator
        public static string ConvertListGuidToString(this List<Guid> datas)
        {
            string result = string.Empty;
            foreach (var data in datas)
            {
                result = $"{result}'{data}',";
            }
            if (datas.Count > 0)
            {
                result = result.Substring(0, result.Length - 1);
                
            }
            return result;
            //example result = "'EA4879FE-2E17-4508-B6B3-21C22F93AB9A','215F7FB1-1BA3-4C78-94A6-C14C1BBEAA22'"
        }
        public static string ConvertListStringToString(this List<string> datas)
        {
            string result = string.Empty;
            foreach (var data in datas)
            {
                result = $"{result}{data},";
            }
            if (datas.Count > 0)
            {
                result = result.Substring(0, result.Length - 1);

            }
            return result;
            //example result = "a,b"
        }
        #pragma warning restore IDE0057 // Use range operator
    }
}
