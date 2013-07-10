using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Finan
{
    public interface IBankCodeService
    {
        bool Contains(string code);
    }
}
