using Microsoft.ApplicationBlocks.Data;
using System.Data;
using System.Data.SqlClient;

namespace GoldRT
{
    class clsCommon
    {
        public static DataSet ExecuteDatasetSP(string pStoreName, params object[] arrParams)
        {
           return SqlHelper.ExecuteDataset(Program.objDB.gConnection, pStoreName, arrParams);
        }
        public static int ExecuteNonQuery(string pStoreName, params SqlParameter[] arrParams)
        {
            return SqlHelper.ExecuteNonQuery(Program.objDB.gConnection, CommandType.StoredProcedure, pStoreName, arrParams);
        }

        public static int ExecuteNonQuerySP(string pStoreName, params object[] arrParams)
        {
            return SqlHelper.ExecuteNonQuery(Program.objDB.gConnection, pStoreName, arrParams);
        }

        public static SqlDataReader ExecuteReaderSP(string pStoreName, params object[] arrParams)
        {
            return SqlHelper.ExecuteReader(Program.objDB.gConnection, pStoreName, arrParams);
        }

        public static string ExecuteScalarSP(string pStoreName, params object[] arrParams)
        {
            return SqlHelper.ExecuteScalar(Program.objDB.gConnection, pStoreName, arrParams).ToString();
        }

        public static DataSet LoadComboSP(string strTableName, string strParams)
        {
            return SqlHelper.ExecuteDataset(Program.objDB.gConnection, "[SYS_LOADCOMBO]", strTableName, strParams);
        }
    }
}
