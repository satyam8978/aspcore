using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePractie
{
    public class SampleTest
    {
        public void ValueTest(int id)
        {
            if (id == 0)
            {

                throw new ArgumentOutOfRangeException("invalid id");
            }
        }
    }
}
