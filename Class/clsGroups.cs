using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient; 

namespace GoldRT
{
    class clsGroups
    {
        public DataSet Ins(string pGroupCode, string pGroupName, string pDescription, string pAdmin)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SYS_GROUPS_Ins", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramGroupCode = new SqlParameter("@p_GroupCode", SqlDbType.NVarChar, 20);
            paramGroupCode.Value = pGroupCode;
            sda.SelectCommand.Parameters.Add(paramGroupCode);

            SqlParameter paramGroupName = new SqlParameter("@p_GroupName", SqlDbType.NVarChar, 255);
            paramGroupName.Value = pGroupName;
            sda.SelectCommand.Parameters.Add(paramGroupName);

            SqlParameter paramDescription = new SqlParameter("@p_Description", SqlDbType.NVarChar, 255);
            paramDescription.Value = pDescription;
            sda.SelectCommand.Parameters.Add(paramDescription);

            SqlParameter paramAdmin = new SqlParameter("@p_Admin", SqlDbType.VarChar, 1);
            paramAdmin.Value = pAdmin;
            sda.SelectCommand.Parameters.Add(paramAdmin);    

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;        
        }

        public DataSet Upd(string pGroupID, string pGroupCode, string pGroupName, string pDescription, string pAdmin)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SYS_GROUPS_Upd", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramGroupCode = new SqlParameter("@p_GroupCode", SqlDbType.NVarChar, 20);
            paramGroupCode.Value = pGroupCode;
            sda.SelectCommand.Parameters.Add(paramGroupCode);

            SqlParameter paramGroupName = new SqlParameter("@p_GroupName", SqlDbType.NVarChar, 255);
            paramGroupName.Value = pGroupName;
            sda.SelectCommand.Parameters.Add(paramGroupName);

            SqlParameter paramDescription = new SqlParameter("@p_Description", SqlDbType.NVarChar, 255);
            paramDescription.Value = pDescription;
            sda.SelectCommand.Parameters.Add(paramDescription);

            SqlParameter paramAdmin = new SqlParameter("@p_Admin", SqlDbType.VarChar, 1);
            paramAdmin.Value = pAdmin;
            sda.SelectCommand.Parameters.Add(paramAdmin);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet Lst(string pGroupID, string pGroupCode, string pGroupName, string pDescription, string pAdmin, string pSort)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SYS_GROUPS_Lst", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramGroupID = new SqlParameter("@p_GroupID", SqlDbType.VarChar, 15);
            paramGroupID.Value = pGroupID;
            sda.SelectCommand.Parameters.Add(paramGroupID);

            SqlParameter paramGroupCode = new SqlParameter("@p_GroupCode", SqlDbType.NVarChar, 20);
            paramGroupCode.Value = pGroupCode;
            sda.SelectCommand.Parameters.Add(paramGroupCode);

            SqlParameter paramGroupName = new SqlParameter("@p_GroupName", SqlDbType.NVarChar, 255);
            paramGroupName.Value = pGroupName;
            sda.SelectCommand.Parameters.Add(paramGroupName);

            SqlParameter paramDescription = new SqlParameter("@p_Description", SqlDbType.NVarChar, 255);
            paramDescription.Value = pDescription;
            sda.SelectCommand.Parameters.Add(paramDescription);

            SqlParameter paramAdmin = new SqlParameter("@p_Admin", SqlDbType.VarChar, 1);
            paramAdmin.Value = pAdmin;
            sda.SelectCommand.Parameters.Add(paramAdmin);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet Del(string pGroupID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SYS_GROUPS_Del", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramGroupID = new SqlParameter("@p_GroupID", SqlDbType.VarChar, 15);
            paramGroupID.Value = pGroupID;
            sda.SelectCommand.Parameters.Add(paramGroupID);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
    }
}
