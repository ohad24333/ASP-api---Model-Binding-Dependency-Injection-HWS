using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP_api___Model_Binding___Dependency_Injection_HWS
{
    public class CriminalCount : ICriminalCount
    {
        int sum = 0;

        public void AddAmount(int amount)
        {
            sum += amount;
        }

        public int GetSum()
        {
            return sum;
        }
    }
}
