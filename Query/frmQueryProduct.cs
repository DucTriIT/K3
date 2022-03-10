using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Messages;
using System.IO;
using System.Drawing.Drawing2D;

namespace GoldRT
{
    public partial class frmQueryProduct : DevExpress.XtraEditors.XtraForm
    {
        public frmQueryProduct()
        {
            InitializeComponent();
        }

        #region "Private Functions"

        private void f_loadDataToCombo()
        {
            DataSet ds = new DataSet();
            try
            {


                ds = clsCommon.LoadComboSP("T_SECTION", null);
                Functions.BindDropDownList(cboSection, ds, "SectionName", "SectionID", "", true, "--- Tất cả ---", "");
                ds.Clear();

                ds = clsCommon.LoadComboSP("T_STATUS", "PRODUCT");
                Functions.BindDropDownList(cboStatus, ds, "StatusName", "Status", "", true);
                ds.Clear();
            }
            catch
            {
            }
            finally
            {
                ds.Dispose();
            }
        }

        private void f_loadDataToGrid()
        {
            DataSet ds = new DataSet();

            this.Cursor = Cursors.WaitCursor;
            try
            {
                ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_QryLst]",((ItemList)cboSection.SelectedItem).ID);

                if (ds.Tables.Count > 0)
                {
                    grdProduct.DataSource = ds.Tables[0];
                    //f_loadDataToDetail();
                }
            }
            catch (Exception ex)
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
                ThongBao.Show("Lỗi", ex.Message, "OK", ICon.Error);
                return;
            }
            finally
            {
                ds.Dispose();
                this.Cursor = Cursors.Default;
            }
        }

        private Byte[] m_PrdtImage;
        public Byte[] PrdtImage
        {
            get { return m_PrdtImage; }
            set { m_PrdtImage = value; }
        }
        private void f_loadDataToDetail()
        {
           
        }
        public Image ResizeImage2(Image sourceImage, int width, int height)
        {
            Image oThumbNail = new Bitmap(sourceImage, width, height);
            Graphics oGraphic = Graphics.FromImage(oThumbNail);
            oGraphic.CompositingQuality = CompositingQuality.HighQuality;
            oGraphic.SmoothingMode = SmoothingMode.HighQuality;
            oGraphic.InterpolationMode = InterpolationMode.HighQualityBicubic;
            Rectangle oRectangle = new Rectangle(0, 0, width, height);
            oGraphic.DrawImage(sourceImage, oRectangle);
            return oThumbNail;
        }
        private void f_enableControl(string _Status)
        {
            //switch (_Status)
            //{
            //    case "I":
            //        btnXemChiTiet.Enabled = false;
            //        break;
            //    default:
            //        btnXemChiTiet.Enabled = true;
            //        break;
            //}
        }

        #endregion

        #region "Event Handlers"

        private void txtProductCode_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmQueryProduct_Load(object sender, EventArgs e)
        {

           // dtpDenNgay.EditValue = DateTime.Now;//.ToString("dd/MM/yyyy");
           //
            //dtpTuNgay.EditValue = 
            Functions.Format_DecimalNumber(this.layoutControl1.Controls);
            f_loadDataToCombo();
            f_loadDataToGrid();
            
            
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            f_loadDataToGrid();
            if (txtProductCode.Text != "")
            {
                for (int i = 0; i < grvProduct.RowCount; i++)
                {

                    if (grvProduct.GetRowCellValue(i, "GoldDesc").ToString().ToUpper() == txtProductCode.Text.Trim().ToUpper())
                    {
                        grvProduct.SelectRow(i);
                        grvProduct.FocusedRowHandle = i;
                        txtProductCode.Focus();
                        txtProductCode.SelectAll();
                        return;

                    }
                }
            }
        }

        private void cboMainSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            //DataSet ds = new DataSet();
            //try
            //{
            //    string strMainSectionID = ((ItemList)cboMainSection.SelectedItem).ID;

            //    ds = clsCommon.LoadComboSP("T_SECTION", strMainSectionID);
            //    Functions.BindDropDownList(cboSection, ds, "SectionName", "SectionID", "", true, "--- Tất cả ---", "");
            //    ds.Clear();
            //}
            //catch
            //{
            //}
            //finally
            //{
            //    ds.Dispose();
            //    btnTimKiem.Focus();
            //}
        }

        private void cboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

            f_enableControl(((ItemList)cboStatus.SelectedItem).ID);
        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {

        }

        private void grvProduct_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            f_loadDataToDetail();
        }

        #endregion

        private void txtProductCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                for (int i = 0; i < grvProduct.RowCount; i++)
                {

                    if (grvProduct.GetRowCellValue(i, "ProductCode").ToString().ToUpper() == txtProductCode.Text.Trim().ToUpper())
                    {
                        grvProduct.SelectRow(i);
                        grvProduct.FocusedRowHandle = i;
                        txtProductCode.Focus();
                        txtProductCode.SelectAll();
                        return;

                    }
                }
            }
        }

        private void cboSection_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnTimKiem.Focus();
        }

        private void grvProduct_DoubleClick(object sender, EventArgs e)
        {
            //////DataSet ds = new DataSet();
            //////try
            //////{
            //////    DataRow dr = grvProduct.GetDataRow(grvProduct.FocusedRowHandle);
            //////    if (dr["StatusName"].ToString() == "Chờ duyệt")
            //////    {
            //////        ds = clsCommon.ExecuteDatasetSP("T_PRODUCT_GetTrnType", dr["ProductCode"].ToString());
            //////        if (ds.Tables[0].Rows[0]["Result"].ToString() != "Error")
            //////            // MessageBox.Show("Mã hàng "+dr["ProductCode"].ToString()+" đang chờ duyệt trong "+ds.Tables[0].Rows[0]["Result"].ToString());
            //////            ThongBao.Show("Thông báo", "Mã hàng " + dr["ProductCode"].ToString() + " đang chờ duyệt trong " + ds.Tables[0].Rows[0]["Result"].ToString(), "OK", ICon.Information);
            //////    }
            //////}
            //////catch (Exception ex)
            //////{
            //////    MessageBox.Show(ex.Message);
            //////}
            //////finally
            //////{
            //////    ds.Dispose();
            //////}
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {

            if (!grdProduct.IsPrintingAvailable)
            {
                MessageBox.Show("The 'DevExpress.XtraPrinting' Library is not found", "Error");
                return;
            }
            // Opens the Preview window. 
            //grdControl.ShowPreview();
            printableComponentLink1.CreateDocument();
            printableComponentLink1.ShowPreview();

        }

        private void frmQueryProduct_KeyDown(object sender, KeyEventArgs e)
        {
            string strDocPath;
            strDocPath = Application.StartupPath + "\\Documents\\" + "Huong dan su dung PMV.CHM";
            if (e.KeyCode == Keys.F1)
            {
                Help.ShowHelp(this, strDocPath, HelpNavigator.Index, "Tra cuu thong tin hang.mht");
                Help.ShowHelp(this, strDocPath, HelpNavigator.KeywordIndex, "Tra cuu thong tin hang.mht");
            }
        }




        private void btnXoa_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (clsSystem.GroupID != "0")
                {
                    ThongBao.Show("Thông báo", "Chỉ quyền admin mới được thực hiện chức năng này!", "OK", ICon.Error);
                    return;
                }

                if (ThongBao.Show("Thông báo", "Bạn có muốn xóa những thông tin trên lưới", "OK", "Cancel", ICon.QuestionMark) == DialogResult.OK)
                {
                    for (int i = 0; i <= grvProduct.RowCount - 1; i++)
                    {
                        if (grvProduct.GetRowCellValue(i, "CanDel").ToString() == "Y")
                        {
                            ds = clsCommon.ExecuteDatasetSP("[T_PRODUCT_QryCancel]", grvProduct.GetRowCellValue(i, "ProductID").ToString());

                        }
                    }
                    if (ds.Tables.Count == 0)
                    {
                        ThongBao.Show("Thông báo", "Không thể xóa hàng tồn trong quầy", "OK", ICon.Error);
                        return;
                    }
                    if (ds.Tables[0].Rows[0]["Result"].ToString() == "0")
                    {
                        ThongBao.Show("Thông báo", "Xóa thành công", "OK", ICon.QuestionMark);
                        grvProduct.ClearColumnsFilter();
                        f_loadDataToGrid();
                    }
                }


            }
            catch
            {
                ThongBao.Show("Lỗi", "Không thể xóa", "OK", ICon.Error);
            }
            finally
            {
                ds.Dispose();

            }
        }

        private void txtMainSection_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtSellOutDate_EditValueChanged(object sender, EventArgs e)
        {

        }

        private void txtInDate_EditValueChanged(object sender, EventArgs e)
        {
        }

        private void txtDiscount_EditValueChanged(object sender, EventArgs e)
        {
        }



    }
}