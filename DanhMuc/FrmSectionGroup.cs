using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Messages;

namespace GoldRT
{
    public partial class FrmSectionGroup : Form
    {
        DataTable dtProduct = new DataTable();
        public FrmSectionGroup()
        {
            InitializeComponent();
        }

        private void FrmSectionGroup_Load(object sender, EventArgs e)
        {
            fn_createProductDataTable();
            grdControl.DataSource = dtProduct;
            fn_LoadDataToCombo();
            fn_LoadDataToGrid();
        }

        private void fn_LoadDataToCombo()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("T_SECTION", "");
            Functions.BindDropDownList(cboQuayNho, ds, "SectionName", "SectionID","", false);
            ds.Clear();       
            ds = clsCommon.LoadComboSP("I_GOLD", "G");
            Functions.BindDropDownList(cboGoldCode, ds, "GoldDesc", "GoldCode", false);
            ds.Clear();
        
            ds.Dispose();
        }

        private void fn_createProductDataTable()
        {
            this.dtProduct.Columns.Add("GoldCode", typeof(string));
            this.dtProduct.Columns.Add("UuTien", typeof(string));
            
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string strGoldCode = "";
            string strUuTien = "";
            string strSetctionID = ((ItemList)cboQuayNho.SelectedItem).ID;
          
            for (int i = 0; i < grdDanhSach.RowCount; i++)
            {
                DataRow dr = grdDanhSach.GetDataRow(i);

                if (!fn_CheckValidate(dr)) return;

                strGoldCode += dr["GoldCode"].ToString() + "@";
                strUuTien += dr["UuTien"].ToString() + "@";               
            }
            if (strGoldCode != "" && strUuTien != "")
            {
                strGoldCode = strGoldCode.Substring(0, strGoldCode.Length - 1);
                strUuTien = strUuTien.Substring(0, strUuTien.Length - 1);
            }
         
            DataSet ds = new DataSet();
            try
            {

                ds = clsCommon.ExecuteDatasetSP("[I_SECTION_GOLD_GROUP_Ins]",strSetctionID,
                    strGoldCode, strUuTien);


                if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                {
                    ThongBao.Show("Thông báo", "Cập nhật thành công.", "OK", ICon.Information);
                    fn_LoadDataToGrid();
                }
                else
                {
                    ThongBao.Show("Lỗi", "Cập nhật không thành công. Vui lòng thử lại", "OK", ICon.Error);
                    return;
                }
            }
            catch 
            {
                ds.Dispose();
                ThongBao.Show("Lỗi", ds.Tables[0].Rows[0]["Messages"].ToString(), "OK", ICon.Error);
                this.Cursor = Cursors.Default;
                return;
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private bool fn_CheckValidate(DataRow dr)
        {       
            
            if (dr["GoldCode"].ToString() == "")
            {
                ThongBao.Show("Lỗi", "Vui lòng kiểm tra cột loại vàng.", "OK", ICon.Error);
                return false;
            }

            if (dr["UuTien"].ToString() == "" || decimal.Parse(dr["UuTien"].ToString()) <0)
            {
                ThongBao.Show("Lỗi", "Vui lòng nhập độ Ưu tiên lớn hơn hoặc bằng 0.", "OK", ICon.Error);
                return false;
            }

            return true;
        }

        private void fn_LoadDataToGrid()
        {
            DataSet ds = new DataSet();

            try
            {
                ds = clsCommon.ExecuteDatasetSP("I_SECTION_GOLD_GROUP_Get", ((ItemList)cboQuayNho.SelectedItem).ID);
                grdControl.DataSource = ds.Tables[0];               
            }
            catch (Exception ex)
            {
                ThongBao.Show("Lỗi", "Hàm LoadDataToGrid: " + ex.Message, "OK", ICon.Error);
            }
            finally
            {
                ds = null;
            }
        }

        private void cboQuayNho_SelectedIndexChanged(object sender, EventArgs e)
        {
            fn_LoadDataToGrid();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(grdDanhSach.FocusedRowHandle < 0)
            {
                ThongBao.Show("Thông báo", "Không có dữ liệu để xoá", "OK", ICon.Information);
                return;
            }
            if (ThongBao.Show("Thông báo", "Bạn có chắc không?", "Có", "Không", ICon.QuestionMark) != DialogResult.OK)
                return;
            grdDanhSach.DeleteSelectedRows();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }



    }
}