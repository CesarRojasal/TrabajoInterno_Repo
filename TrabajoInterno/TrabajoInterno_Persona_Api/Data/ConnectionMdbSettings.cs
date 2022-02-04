using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabajoInterno_Api. Data
{
    public class ConnectionMdbSettings: IConnectionMdbSettings

    {
        public string Server { get; set; } = string.Empty;
        public string DataBase { get; set; } = string.Empty;
        public string Collection { get; set; } = string.Empty;

    }
}
