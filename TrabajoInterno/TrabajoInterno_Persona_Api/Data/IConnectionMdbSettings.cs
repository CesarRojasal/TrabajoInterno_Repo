using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TrabajoInterno_Api.Data
{
    public interface IConnectionMdbSettings
    {
         string Server { get; set; }
         string DataBase { get; set; }
         string Collection { get; set; }

    }
}
