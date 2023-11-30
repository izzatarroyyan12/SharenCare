using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharenCare_cs.Classes
{
    namespace SharenCare_cs
    {
        public class AdminUser : User
        {
            public AdminUser(NpgsqlConnection connection) : base(connection)
            {
            }
            public override void RedirectToDashboard(MainWindow mainWindow)
            {
                mainWindow.Content = new AdminDashPage(mainWindow);
            }
        }
    }
}