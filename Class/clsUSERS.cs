using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient; 

namespace GoldRT
{
    class clsUsers
    {
        public DataSet CheckLogin(string pUserName, string pPassword)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SYS_USERS_CheckLogin", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramUserName = new SqlParameter("@p_UserName", SqlDbType.VarChar, 20);
            paramUserName.Value = pUserName;
            sda.SelectCommand.Parameters.Add(paramUserName);

            SqlParameter paramPassword = new SqlParameter("@p_Password", SqlDbType.VarChar, 50);
            paramPassword.Value = pPassword;
            sda.SelectCommand.Parameters.Add(paramPassword);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet ChangePassword(string pUserID, string pPasswordOld, string pPasswordNew)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SYS_USERS_ChangePwd", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramUserID = new SqlParameter("@p_UserID", SqlDbType.VarChar, 15);
            paramUserID.Value = pUserID;
            sda.SelectCommand.Parameters.Add(paramUserID);

            SqlParameter paramPasswordOld = new SqlParameter("@p_PasswordOld", SqlDbType.VarChar, 50);
            paramPasswordOld.Value = pPasswordOld;
            sda.SelectCommand.Parameters.Add(paramPasswordOld);

            SqlParameter paramPasswordNew = new SqlParameter("@p_PasswordNew", SqlDbType.VarChar, 50);
            paramPasswordNew.Value = pPasswordNew;
            sda.SelectCommand.Parameters.Add(paramPasswordNew);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet Lst(string pUserID, string pEmpID, string pUserName, string pFullName, string pIsAdmin, string pActive, string pSort)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SYS_USERS_Lst", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter paramUserID = new SqlParameter("@p_UserID", SqlDbType.VarChar, 15);
            paramUserID.Value = pUserID;
            sda.SelectCommand.Parameters.Add(paramUserID);

            SqlParameter paramEmpID = new SqlParameter("@p_EmpID", SqlDbType.VarChar, 15);
            paramEmpID.Value = pEmpID;
            sda.SelectCommand.Parameters.Add(paramEmpID);

            SqlParameter paramUserName = new SqlParameter("@p_UserName", SqlDbType.NVarChar, 80);
            paramUserName.Value = pUserName;
            sda.SelectCommand.Parameters.Add(paramUserName);

            SqlParameter paramIsAdmin = new SqlParameter("@p_IsAdmin", SqlDbType.VarChar, 50);
            paramIsAdmin.Value = pIsAdmin;
            sda.SelectCommand.Parameters.Add(paramIsAdmin);

            SqlParameter paramActive = new SqlParameter("@p_Active", SqlDbType.NVarChar, 200);
            paramActive.Value = pActive;
            sda.SelectCommand.Parameters.Add(paramActive);

            SqlParameter paramSort = new SqlParameter("@p_Sort", SqlDbType.VarChar, 100);
            paramSort.Value = pSort;
            sda.SelectCommand.Parameters.Add(paramSort);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet Ins(string pEmpID, string pUserName, string pPassword, string pGroupIDs, string pIsAdmin, string pActive)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SYS_USERS_Ins", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlParameter paramEmpID = new SqlParameter("@p_EmpID", SqlDbType.VarChar, 15);
            paramEmpID.Value = pEmpID;
            sda.SelectCommand.Parameters.Add(paramEmpID);

            SqlParameter paramUserName = new SqlParameter("@p_UserName", SqlDbType.NVarChar, 80);
            paramUserName.Value = pUserName;
            sda.SelectCommand.Parameters.Add(paramUserName);

            SqlParameter paramPassword = new SqlParameter("@p_Password", SqlDbType.NVarChar, 50);
            paramPassword.Value = pPassword;
            sda.SelectCommand.Parameters.Add(paramPassword);

            SqlParameter paramGroupIDs = new SqlParameter("@p_GroupIDs", SqlDbType.VarChar, 4000);
            paramGroupIDs.Value = pGroupIDs;
            sda.SelectCommand.Parameters.Add(paramGroupIDs);

            SqlParameter paramIsAdmin = new SqlParameter("@p_IsAdmin", SqlDbType.VarChar, 50);
            paramIsAdmin.Value = pIsAdmin;
            sda.SelectCommand.Parameters.Add(paramIsAdmin);

            SqlParameter paramActive = new SqlParameter("@p_Active", SqlDbType.NVarChar, 200);
            paramActive.Value = pActive;
            sda.SelectCommand.Parameters.Add(paramActive);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet Upd(string pUserID, string pEmpID, string pUserName, string pPassword, string pGroupIDs, string pIsAdmin, string pActive)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SYS_USERS_Upd", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter paramUserID = new SqlParameter("@p_UserID", SqlDbType.VarChar, 15);
            paramUserID.Value = pUserID;
            sda.SelectCommand.Parameters.Add(paramUserID);

            SqlParameter paramEmpID = new SqlParameter("@p_EmpID", SqlDbType.VarChar, 15);
            paramEmpID.Value = pEmpID;
            sda.SelectCommand.Parameters.Add(paramEmpID);

            SqlParameter paramUserName = new SqlParameter("@p_UserName", SqlDbType.NVarChar, 80);
            paramUserName.Value = pUserName;
            sda.SelectCommand.Parameters.Add(paramUserName);

            SqlParameter paramPassword = new SqlParameter("@p_Password", SqlDbType.NVarChar, 50);
            paramPassword.Value = pPassword;
            sda.SelectCommand.Parameters.Add(paramPassword);

            SqlParameter paramGroupIDs = new SqlParameter("@p_GroupIDs", SqlDbType.VarChar, 4000);
            paramGroupIDs.Value = pGroupIDs;
            sda.SelectCommand.Parameters.Add(paramGroupIDs);

            SqlParameter paramIsAdmin = new SqlParameter("@p_IsAdmin", SqlDbType.VarChar, 50);
            paramIsAdmin.Value = pIsAdmin;
            sda.SelectCommand.Parameters.Add(paramIsAdmin);

            SqlParameter paramActive = new SqlParameter("@p_Active", SqlDbType.NVarChar, 200);
            paramActive.Value = pActive;
            sda.SelectCommand.Parameters.Add(paramActive);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet Get(string pUserID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SYS_USERS_Get", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter paramUserID = new SqlParameter("@p_UserID", SqlDbType.VarChar, 15);
            paramUserID.Value = pUserID;
            sda.SelectCommand.Parameters.Add(paramUserID);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet Del(string pUserID)
        {
            SqlDataAdapter sda = new SqlDataAdapter("SYS_USERS_Del", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter paramUserID = new SqlParameter("@p_UserID", SqlDbType.VarChar, 15);
            paramUserID.Value = pUserID;
            sda.SelectCommand.Parameters.Add(paramUserID);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

    }
}
