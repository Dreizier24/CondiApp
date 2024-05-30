using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Condi.DBStorage
{
    public static class DBStorage
    {
        public static CondiEntities DB_s { get; set; } = new CondiEntities();
    }
}
