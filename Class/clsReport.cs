using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace GoldRT
{
    class clsReport
    {
        public DataSet rpt001(string pDocTypeID, string pTuNgay, string pDenNgay)
        {
            SqlDataAdapter sda = new SqlDataAdapter("RPT_001", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter paramDocTypeID = new SqlParameter("@p_DocTypeID", SqlDbType.VarChar, 15);
            paramDocTypeID.Value = pDocTypeID;
            sda.SelectCommand.Parameters.Add(paramDocTypeID);

            SqlParameter paramTuNgay = new SqlParameter("@p_TuNgay", SqlDbType.VarChar, 10);
            paramTuNgay.Value = pTuNgay;
            sda.SelectCommand.Parameters.Add(paramTuNgay);

            SqlParameter paramDenNgay = new SqlParameter("@p_DenNgay", SqlDbType.VarChar, 10);
            paramDenNgay.Value = pDenNgay;
            sda.SelectCommand.Parameters.Add(paramDenNgay);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet rpt002(string pTuNgay, string pDenNgay)
        {
            SqlDataAdapter sda = new SqlDataAdapter("RPT_002", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter paramTuNgay = new SqlParameter("@p_TuNgay", SqlDbType.VarChar, 10);
            paramTuNgay.Value = pTuNgay;
            sda.SelectCommand.Parameters.Add(paramTuNgay);

            SqlParameter paramDenNgay = new SqlParameter("@p_DenNgay", SqlDbType.VarChar, 10);
            paramDenNgay.Value = pDenNgay;
            sda.SelectCommand.Parameters.Add(paramDenNgay);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet rpt003(string pTuNgay, string pDenNgay)
        {
            SqlDataAdapter sda = new SqlDataAdapter("RPT_003", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter paramTuNgay = new SqlParameter("@p_TuNgay", SqlDbType.VarChar, 10);
            paramTuNgay.Value = pTuNgay;
            sda.SelectCommand.Parameters.Add(paramTuNgay);

            SqlParameter paramDenNgay = new SqlParameter("@p_DenNgay", SqlDbType.VarChar, 10);
            paramDenNgay.Value = pDenNgay;
            sda.SelectCommand.Parameters.Add(paramDenNgay);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet rpt004(string pTuNgay, string pDenNgay)
        {
            SqlDataAdapter sda = new SqlDataAdapter("RPT_004", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter paramTuNgay = new SqlParameter("@p_TuNgay", SqlDbType.VarChar, 10);
            paramTuNgay.Value = pTuNgay;
            sda.SelectCommand.Parameters.Add(paramTuNgay);

            SqlParameter paramDenNgay = new SqlParameter("@p_DenNgay", SqlDbType.VarChar, 10);
            paramDenNgay.Value = pDenNgay;
            sda.SelectCommand.Parameters.Add(paramDenNgay);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet rpt005(string pTuNgay, string pDenNgay)
        {
            SqlDataAdapter sda = new SqlDataAdapter("RPT_005", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter paramTuNgay = new SqlParameter("@p_TuNgay", SqlDbType.VarChar, 10);
            paramTuNgay.Value = pTuNgay;
            sda.SelectCommand.Parameters.Add(paramTuNgay);

            SqlParameter paramDenNgay = new SqlParameter("@p_DenNgay", SqlDbType.VarChar, 10);
            paramDenNgay.Value = pDenNgay;
            sda.SelectCommand.Parameters.Add(paramDenNgay);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet rpt006(string pTuNgay, string pDenNgay)
        {
            SqlDataAdapter sda = new SqlDataAdapter("RPT_006", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter paramTuNgay = new SqlParameter("@p_TuNgay", SqlDbType.VarChar, 10);
            paramTuNgay.Value = pTuNgay;
            sda.SelectCommand.Parameters.Add(paramTuNgay);

            SqlParameter paramDenNgay = new SqlParameter("@p_DenNgay", SqlDbType.VarChar, 10);
            paramDenNgay.Value = pDenNgay;
            sda.SelectCommand.Parameters.Add(paramDenNgay);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet rpt101(string pDocTypeID, string pTuNgay, string pDenNgay)
        {
            SqlDataAdapter sda = new SqlDataAdapter("RPT_101", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter paramDocTypeID = new SqlParameter("@p_DocTypeID", SqlDbType.VarChar, 15);
            paramDocTypeID.Value = pDocTypeID;
            sda.SelectCommand.Parameters.Add(paramDocTypeID);

            SqlParameter paramTuNgay = new SqlParameter("@p_TuNgay", SqlDbType.VarChar, 10);
            paramTuNgay.Value = pTuNgay;
            sda.SelectCommand.Parameters.Add(paramTuNgay);

            SqlParameter paramDenNgay = new SqlParameter("@p_DenNgay", SqlDbType.VarChar, 10);
            paramDenNgay.Value = pDenNgay;
            sda.SelectCommand.Parameters.Add(paramDenNgay);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }

        public DataSet rpt102(string pTuNgay, string pDenNgay)
        {
            SqlDataAdapter sda = new SqlDataAdapter("RPT_102", Program.objDB.gConnection);
            sda.SelectCommand.CommandType = CommandType.StoredProcedure;


            SqlParameter paramTuNgay = new SqlParameter("@p_TuNgay", SqlDbType.VarChar, 10);
            paramTuNgay.Value = pTuNgay;
            sda.SelectCommand.Parameters.Add(paramTuNgay);

            SqlParameter paramDenNgay = new SqlParameter("@p_DenNgay", SqlDbType.VarChar, 10);
            paramDenNgay.Value = pDenNgay;
            sda.SelectCommand.Parameters.Add(paramDenNgay);

            DataSet ds = new DataSet();
            sda.Fill(ds);
            return ds;
        }
    }
}
