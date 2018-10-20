using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Util
{

    public static class Enum
    {
        public sealed class RelatorioStatus
        {
            public static readonly int Pago = 2;
            public static readonly int NaoPago = 1;
        }
    }
}
