using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspCorePractie.Services
{
    public interface Depend
    {
        void WriteMessage(string message);
    }
    public class MyDependency : Depend
    {
        public void WriteMessage(string message)
        {
            Console.WriteLine("Test "+message+"");
        }
    }
}
