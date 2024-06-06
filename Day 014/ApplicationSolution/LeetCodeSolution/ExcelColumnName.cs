using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeSolutionApplication
{
    public class ExcelColumnName
    {
        public string result = "";

        public async Task<string> GetColumnName(int colNumber)
        {
            while (colNumber > 0)
            {
                colNumber--;
                char c = (char)('A' + colNumber % 26);
                result = c + result;
                colNumber /= 26;
            }
            await Task.Delay(0);
            return result;
        }
    }
}
