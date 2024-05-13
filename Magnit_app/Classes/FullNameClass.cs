using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Magnit_app.Entities
{

        public partial class Workers
        {
            public string FullName
            {
                get
                {
                    { return Last_name + " " + First_name + " " + Patronimyc; }
                }
            }
        }
}
