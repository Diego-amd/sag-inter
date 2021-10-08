using System;
using System.Data.SqlClient; 

// 3 classes principais do namespace SqlClient:
// SqlConnection (usada para conectar e desconectar com o banco de dados)
// SqlCommand (usada para executar um comando SQL a partir da conexão estabelecida)
// SqlDataReader (usada para percorrer os dados consultados pelo comando SQL)

namespace sag.Repositores
{
    public abstract class BDContext
    {
        protected SqlConnection connection;

        public BDContext()
        {
            // var context = new BDContext(); //abre a conexão
            // context.Dispose(); //fecha a conexão
            var strConnection = "Data Source = localhost; Integrated Security = True; User=admin; Password=A1b2c3d4e5!; Initial Catalog = bd_sag";
            connection = new SqlConnection(strConnection);
            connection.Open();
        }

        public void Dispose()
        {
            connection.Close();
        }
    }
}