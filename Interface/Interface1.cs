using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kaif
{
    public interface IDataProvider
    {
        Dish GetData(string n, int p);
    }

    public interface IDataProcess
    {
        void ProcessData(IDataProvider dataProvider);
    }


}
