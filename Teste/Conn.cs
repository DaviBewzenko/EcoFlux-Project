using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Teste
{
    internal class Conn
    {
        private static string server = @"PAES/SQLSERVER"; //Meu usuario
        private static string dataBase = "EcoFlux";
        private static string user = "BS";
        private static string password = "senha";

    public static string StrCon
        {
            //get { return "Data Source = " + server + "; Integrated Security = false; Initial Catalog=" + dataBase + "; User id= " + user + ";
           // Password=" + password + "; }

            get { return $"Data Source = {server}; Integrated Security=false;Initial Catalog={dataBase};User Id={user};Passaword={password}"; }
        }
    }


}
