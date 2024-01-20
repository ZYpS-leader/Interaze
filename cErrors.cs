using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace interaze_alpha1
{
    internal class cErrors
    {
    }

    internal class FromPathAppendError(string mes) : Exception(mes) { };
}
