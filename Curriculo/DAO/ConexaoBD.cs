using System;
using System.Data.SqlClient;
namespace N2B1_Curriculo.DAO
{
    public class ConexaoBD
    {
        public static SqlConnection GetConexao()
        {
            string strCon = "Data Source=LOCALHOST;Initial Catalog=N2B1_Curriculo;user id=sa; password=Valuetech@123";
            //string strCon = "Data Source=LOCALHOST; Database=N2B1_Curriculo; integrated security=true";
            SqlConnection conexao = new SqlConnection(strCon);
            conexao.Open();
            return conexao;
        }
    }
}

