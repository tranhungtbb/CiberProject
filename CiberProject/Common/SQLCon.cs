using System;
using Dapper;
using Microsoft.Data.SqlClient;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;

namespace PAKNAPI.Common
{
	public class SQLCon
	{
		private static string _connectString;

		public SQLCon(string connectString)
		{
			_connectString = connectString;
		}

		public SQLCon()
		{
		}

		public static SqlConnection GetConnection()
		{
			return new SqlConnection(_connectString);
		}
		

		public T ExecuteScalar<T>(string sqlText, params SqlParameter[] param)
		{
			using (SqlConnection conn = GetConnection())
			using (SqlCommand cmd = new SqlCommand(sqlText, conn))
			{
				cmd.CommandType = CommandType.Text;
				cmd.Parameters.AddRange(param);

				
				return (T)cmd.ExecuteScalar();
			}
		}


		public async Task<int> ExecuteNonQueryDapperAsync(string ProcedureName, DynamicParameters DP)
		{
			using (SqlConnection conn = GetConnection())
			{
				
				return await conn.ExecuteAsync(ProcedureName, DP, commandType: CommandType.StoredProcedure);
			}
		}
		public async Task<T> ExecuteScalarDapperAsync<T>(string ProcedureName, DynamicParameters DP)
		{
			using (SqlConnection conn = GetConnection())
			{
				
				return (T)await conn.ExecuteScalarAsync(ProcedureName, DP, commandType: CommandType.StoredProcedure);
			}
		}


		public async Task<IEnumerable<T>> ExecuteListDapperAsync<T>(string ProcedureName, DynamicParameters DP)
		{
			using (SqlConnection conn = GetConnection())
			{
				
				return await conn.QueryAsync<T>(ProcedureName, DP, commandType: CommandType.StoredProcedure);
			}
		}
	}
}