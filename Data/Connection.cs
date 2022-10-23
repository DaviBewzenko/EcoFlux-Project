using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EcoFlux.Properties;
using Kimtoo.DbContext;
using ServiceStack.OrmLite;

namespace EcoFlux.Data
{
    /*public static class Connection
    {
        //constructor
        static Connection()
        {
            try
            {
                //settings for mysql
                var err = Db.Init(@"Server=myServerAddress;DataBase=myDataBase;Uid=myUsername;Pwd=myPassword;", MySqlDialect.Provider);

                //settings for sql server

                if (err != null)
                {
                    MessageBox.Show(err.Message);
                    Environment.Exit(0);

                }
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);
                Environment.Exit(0);
            }
        }



        public static void CheckAndCreateTables()
        {

        }
    }*/
}
