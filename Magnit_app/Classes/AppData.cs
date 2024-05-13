using Magnit_app.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Magnit_app.Classes
{
    class AppData
    {
        public static Frame MainFrame = new Frame();
        public static Magnit_dbEntities Context = new Magnit_dbEntities();
        public static Workers currentUser;
    }
}
