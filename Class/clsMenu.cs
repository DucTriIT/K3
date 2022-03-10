using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GoldRT
{
    class clsMenu
    {
        public DataSet Update(string pMenuID, string pMenuDesc, string pParentID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SYS_MENUS_Update", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramMenuID = new SqlParameter("@p_MenuID", SqlDbType.VarChar, 100);
            paramMenuID.Value = pMenuID;
            sda.SelectCommand.Parameters.Add(paramMenuID);

            SqlParameter paramMenuDesc = new SqlParameter("@p_MenuDesc", SqlDbType.NVarChar, 300);
            paramMenuDesc.Value = pMenuDesc;
            sda.SelectCommand.Parameters.Add(paramMenuDesc);

            SqlParameter paramParentID = new SqlParameter("@p_ParentID", SqlDbType.VarChar, 100);
            paramParentID.Value = pParentID;
            sda.SelectCommand.Parameters.Add(paramParentID);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet UpdateByGroupID(string pGroupID, string pMenuIDs)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SYS_MENUS_UpdByGroupID", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramGroupID = new SqlParameter("@p_GroupID", SqlDbType.VarChar, 15);
            paramGroupID.Value = pGroupID;
            sda.SelectCommand.Parameters.Add(paramGroupID);

            SqlParameter paramMenuIDs = new SqlParameter("@p_MenuIDs", SqlDbType.VarChar, 8000);
            paramMenuIDs.Value = pMenuIDs;
            sda.SelectCommand.Parameters.Add(paramMenuIDs);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet LstAllMenu(string pGroupID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SYS_MENUS_LstAll", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramGroupID = new SqlParameter("@p_GroupID", SqlDbType.VarChar, 15);
            paramGroupID.Value = pGroupID;
            sda.SelectCommand.Parameters.Add(paramGroupID);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet GetAllRights(string pGroupID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SYS_MENUS_GetAllRights", Program.objDB.gConnection);
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
