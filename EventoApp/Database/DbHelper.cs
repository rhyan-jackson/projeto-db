using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EventoApp.Database
{
    /// <summary>
    /// Classe utilitária com métodos genéricos para aceder à base de dados p4g5.
    /// Lê a connection string do App.config (nome "p4g5").
    /// </summary>
    public static class DbHelper
    {
        public static string ConnectionString =>
            ConfigurationManager.ConnectionStrings["p4g5"].ConnectionString;

        /// <summary>Cria e abre uma SqlConnection.</summary>
        public static SqlConnection GetConnection()
        {
            var conn = new SqlConnection(ConnectionString);
            conn.Open();
            return conn;
        }

        /// <summary>
        /// Executa uma query SELECT e devolve um DataTable.
        /// Útil para popular DataGridViews.
        /// </summary>
        public static DataTable ExecuteQuery(string sql, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                using (var adapter = new SqlDataAdapter(cmd))
                {
                    var table = new DataTable();
                    adapter.Fill(table);
                    return table;
                }
            }
        }

        /// <summary>
        /// Executa INSERT / UPDATE / DELETE e devolve o número de linhas afetadas.
        /// </summary>
        public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Executa SELECT que devolve um único valor escalar.
        /// </summary>
        public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
        {
            using (var conn = GetConnection())
            using (var cmd = new SqlCommand(sql, conn))
            {
                if (parameters != null) cmd.Parameters.AddRange(parameters);
                return cmd.ExecuteScalar();
            }
        }

        /// <summary>
        /// Devolve o próximo ID disponível para uma tabela (MAX(coluna)+1).
        /// Útil porque as PKs não são IDENTITY no script.
        /// </summary>
        public static int NextId(string tabela, string colunaPk)
        {
            var sql = $"SELECT ISNULL(MAX([{colunaPk}]), 0) + 1 FROM [dbo].[{tabela}]";
            return Convert.ToInt32(ExecuteScalar(sql));
        }

        /// <summary>
        /// Helper para criar SqlParameters de forma mais curta.
        /// </summary>
        public static SqlParameter P(string name, object value)
        {
            return new SqlParameter(name, value ?? DBNull.Value);
        }
    }
}
