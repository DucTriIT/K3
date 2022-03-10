using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using GoldRT;
using SuperX.Properties;
using System.Data.SqlClient;
using SuperX.Report;
using Messages;

namespace SuperX
{
    public partial class frmSoDoPhong : DevExpress.XtraEditors.XtraForm
    {
        private static readonly log4net.ILog log =
           log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private DataTable dtThucDon;
        private string magd;
        private string mabep;
        string room;
        string tenphong;
        private int tienphong;
        private bool isLoading = false;
        decimal dGiaBan = 0;
        decimal dSL = 0;
        decimal dThanhTien = 0;
        public frmSoDoPhong()
        {
            InitializeComponent();
        }

        private void FrmSoDoPhong_Load(object sender, EventArgs e)
        {
            //txtTienCP.Dispose();
            InitSoDoPhong();
            LoadDataToCombobox();
            InitDataTable();
            grcThucDon.DataSource = dtThucDon;
            btnPrintBill.Dispose();
        }

        private void InitDataTable()
        {
            dtThucDon = new DataTable();
            dtThucDon.Columns.Add("GoldCode");
            dtThucDon.Columns.Add("GoldDesc");
            dtThucDon.Columns.Add("UnitCode");
            dtThucDon.Columns.Add("UnitDesc");
            dtThucDon.Columns.Add("SectionID");
            dtThucDon.Columns.Add("SoLuong", typeof(decimal));
            dtThucDon.Columns.Add("SellRate", typeof(decimal));
            dtThucDon.Columns.Add("Amount", typeof(decimal));

        }

        private void LoadDataToCombobox()
        {
            DataSet ds = new DataSet();

            ds = clsCommon.LoadComboSP("T_SECTION", "");
            Functions.BindDropDownList(cboNhomHang, ds, "SectionName", "SectionID", "", true);
            ds.Clear();

            ds = clsCommon.LoadComboSP("T_EMPLOYEE", "");
            Functions.BindDropDownList(cbbDVT, ds, "UnitDesc", "UnitCode", "", true);
            ds.Clear();


            ds = clsCommon.LoadComboSP("SYS_USERS", "");
            Functions.BindDropDownList(cboUserID, ds, "UserName", "UserID", "", true);
            ds.Clear();

        }

        private void InitSoDoPhong()
        {
            DataSet ds = new DataSet();
            tileControl1.Groups.Clear();
            ds = clsCommon.ExecuteDatasetSP("T_Phong_Lst");
            TileGroup group = new TileGroup();

            if (ds.Tables.Count > 0)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    TileItem item = new TileItem();
                    item.Name = dr["IDPhong"].ToString();
                    item.Text = dr["TenPhong"].ToString();                    
                    item.AppearanceItem.Normal.Font = new Font(FontFamily.GenericSerif,12,FontStyle.Bold); 
                    item.AppearanceItem.Hovered.Font = item.AppearanceItem.Normal.Font;
                    item.AppearanceItem.Selected.Font = item.AppearanceItem.Normal.Font;
                    item.Tag = dr["MAHD"] + "";
                    item.TextAlignment = TileItemContentAlignment.TopCenter;
                    item.AppearanceItem.Normal.BackColor= !string.IsNullOrEmpty(dr["MAHD"] + "") ?Color.Red:Color.DarkGreen;
                    item.AppearanceItem.Hovered.BackColor= item.AppearanceItem.Normal.BackColor;
                    item.AppearanceItem.Selected.BackColor= item.AppearanceItem.Normal.BackColor;
                    //item.Image = !string.IsNullOrEmpty(dr["MAHD"] + "") ? Resources._1454839877_Open_Sign : Resources._1454839955_closed_shop_black_friday_sale_store;
                    item.ImageAlignment = TileItemContentAlignment.MiddleCenter;
                    item.ItemClick += new TileItemClickEventHandler(item_ItemClick);
                    string strtienphong = dr["TienGio"].ToString() == "" ? "0" : dr["TienGio"].ToString();
                    item.Id = int.Parse(strtienphong);
                    group.Items.Add(item);
                }
                tileControl1.Groups.Add(group);
            }
        }

        void item_ItemClick(object sender, TileItemEventArgs e)
        {
            magd = (sender as TileItem).Tag.ToString();

            room = (sender as TileItem).Name;
            tienphong = (sender as TileItem).Id;
            tenphong = (sender as TileItem).Text;
            groupBox2.Text = "Thông tin phòng " + (sender as TileItem).Text;
            isLoading = true;
            if (string.IsNullOrEmpty(magd))
            {
                LoadThongTinPhongMoi();
                EnabledChucNang(false);
            }
            else
            {
                LoadThongTinPhong();
                EnabledChucNang(true);
            }
            isLoading = false;
        }

        private void EnabledChucNang(bool p)
        {
            btnTransfer.Enabled = p;
            btnJoin.Enabled = p;
            btnPayment.Enabled = p;
            btnPrintBill.Enabled = p;
            if (p && !string.IsNullOrEmpty(dteStart.Text))
                btnStart.Enabled = !p;
            else
                btnStart.Enabled = true;
            btnEditGioVao.Enabled = !btnStart.Enabled;
            btnEnd.Enabled = p;
            btnThem.Enabled = p;
            btnThemNgoai.Enabled = p;
            btnHuy.Enabled = p;
            btnTang.Enabled = p;
            btnGiam.Enabled = p;
            if (clsSystem.IsAdmin != "1")
            {
                btnCancel.Enabled = false;
            }
            else
            {
                btnCancel.Enabled = p;
            }

        }

        private void LoadThongTinPhongMoi()
        {
            magd = string.Empty;
            lblBillID.Text = "Tự Động";
            speSoNguoi.Value = 1;
            dteNgay.DateTime = DateTime.Now;
            dteStart.Text = "";
            dteEnd.Text = "";
            txtNotes.Text = string.Empty;
            speSL.Value = 1;
            cboUserID.SelectedIndex = Functions.GetSelectedIndexCombo(clsSystem.UserID, cboUserID, 0);
            dtThucDon.Clear();
            grcThucDon.DataSource = dtThucDon;
            txtHourMoney.EditValue = 0;
            txtTienCP.EditValue = 0;
            txtFBMoney.EditValue = 0;
            txtDiscount.EditValue = 0;
            txtTotal.EditValue = 0;
            btnVIP.Text = "N";
            txtTenMon.Text = string.Empty;
            cbbDVT.SelectedIndex = 0;
            speGia.EditValue = "10000";
        }

        private void LoadThongTinPhong()
        {
            DataSet ds = new DataSet();
            ds = clsCommon.ExecuteDatasetSP("HOADONBANGANG_GET_BYTRNID", magd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                lblBillID.Text = dr["BillCode"].ToString();
                speSoNguoi.Value = Convert.ToDecimal(dr["SoNguoi"]);
                dteNgay.DateTime = DateTime.Parse(dr["TrnDate"].ToString());
                cboUserID.SelectedIndex = Functions.GetSelectedIndexCombo(dr["EmpID"].ToString(), cboUserID, 0);
                txtNotes.Text = dr["GhiChu"].ToString();
                dteStart.Text = dr["GioBatDau"].ToString();
                dteEnd.Text = dr["GioKetThuc"].ToString();
                txtHourMoney.EditValue = dr["HourTotalAmount"];
                txtTienCP.EditValue = dr["ChangeHourTotalAmount"];
                txtFBMoney.EditValue = dr["SellTotalAmount"];
                txtDiscount.EditValue = dr["Discount"];
                txtTotal.EditValue = dr["PayAmount"];
                btnVIP.Text = Convert.ToBoolean(dr["LoaiHD"]) ? "V" : "N";
                grcThucDon.DataSource = ds.Tables[1];

            }

            ds = clsCommon.ExecuteDatasetSP("HOADONBANGANG_GET_BYTRNID", magd);

            if (ds.Tables[0].Rows.Count > 0)
            {
                DataRow dr = ds.Tables[0].Rows[0];
                lblBillID.Text = dr["BillCode"].ToString();
                speSoNguoi.Value = Convert.ToDecimal(dr["SoNguoi"]);
                dteNgay.DateTime = DateTime.Parse(dr["TrnDate"].ToString());
                cboUserID.SelectedIndex = Functions.GetSelectedIndexCombo(dr["EmpID"].ToString(), cboUserID, 0);
                txtNotes.Text = dr["GhiChu"].ToString();
                dteStart.Text = dr["GioBatDau"].ToString();
                dteEnd.Text = dr["GioKetThuc"].ToString();
                txtHourMoney.EditValue = dr["HourTotalAmount"];
                txtTienCP.EditValue = dr["ChangeHourTotalAmount"];
                txtFBMoney.EditValue = dr["SellTotalAmount"];
                txtDiscount.EditValue = dr["Discount"];
                txtTotal.EditValue = dr["PayAmount"];
                btnVIP.Text = Convert.ToBoolean(dr["LoaiHD"]) ? "V" : "N";
                grcThucDon.DataSource = ds.Tables[1];

            }
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void cboNhomHang_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sectionid = ((ItemList)cboNhomHang.SelectedItem).ID;
            DataSet ds = clsCommon.ExecuteDatasetSP("I_GOLD_Get_ByGoldType", sectionid);
            grcHang.DataSource = ds.Tables[0];
            grvHang.BestFitColumns(true);
        }
        string strGoldCode = string.Empty;
        string strGoldDesc = string.Empty;
        string strMaDVt = string.Empty;
        string strDVt = string.Empty;
        string strSectionID = string.Empty;

        private void grvHang_DoubleClick(object sender, EventArgs e)
        {
            if (grvHang.FocusedRowHandle > -1)
            {
                if (String.IsNullOrEmpty(room))
                    return;
                strGoldCode = grvHang.GetFocusedRowCellValue(grvHang.Columns["GoldCode"]).ToString();
                strGoldDesc = grvHang.GetFocusedRowCellValue(grvHang.Columns["GoldDesc"]).ToString();
                strMaDVt = grvHang.GetFocusedRowCellValue(grvHang.Columns["UnitCode"]).ToString();
                strDVt = grvHang.GetFocusedRowCellValue(grvHang.Columns["UnitDesc"]).ToString();
                strSectionID = grvHang.GetFocusedRowCellValue(grvHang.Columns["SectionID"]).ToString();
                dSL = 1;
                dGiaBan = btnVIP.Text == "N" ? Convert.ToDecimal(grvHang.GetFocusedRowCellValue(grvHang.Columns["TruLai"])) : Convert.ToDecimal(grvHang.GetFocusedRowCellValue(grvHang.Columns["TruGia"]));
                dThanhTien = dSL * dGiaBan;
                bool themmoi = true;
                int index = 0;
                decimal dSLMoi = 0;
                if (!string.IsNullOrEmpty(magd))
                {
                    for (int i = 0; i < grvThucDon.RowCount; i++)
                    {
                        if (grvThucDon.GetRowCellValue(i, grvThucDon.Columns["GoldCode"]).ToString().Equals(strGoldCode))
                        {
                            themmoi = false;
                            index = i;
                            dSLMoi = Convert.ToDecimal(grvThucDon.GetRowCellValue(i, grvThucDon.Columns["SoLuong"])) + dSL;
                            break;
                        }
                    }

                }
                else { btnStart_Click(null, null); }


                if (themmoi)
                {
                    grvThucDon.AddNewRow();
                    grvThucDon.UpdateCurrentRow();
                    TinhTienHoaDon();
                }
                else
                {
                    ThemMon(index, dSLMoi);
                    TinhTienHoaDon();
                }
                Save();
                SaveBep("1");
            }
        }
        private void TinhTienHoaDon()
        {
            decimal dTienGio = 0;
            decimal dTienHang = 0;
            for (int i = 0; i < grvThucDon.RowCount; i++)
            {
                DataRow dr = grvThucDon.GetDataRow(i);
                if (dr["GoldCode"].Equals("1") || dr["GoldCode"].Equals("2"))
                {
                    dTienGio += Convert.ToDecimal(dr["Amount"]);
                }
                else
                {
                    dTienHang += Convert.ToDecimal(dr["Amount"]);
                }
            }
            dTienGio = Convert.ToDecimal(txtHourMoney.EditValue) + Convert.ToDecimal(txtTienCP.EditValue);
            txtFBMoney.EditValue = dTienHang;
            decimal dDisCount = Convert.ToDecimal(txtDiscount.EditValue);
            txtTotal.EditValue = dTienGio + dTienHang + dDisCount;
        }

        private void txtDiscount_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(magd))
            {
                decimal dTienGio = 0;
                decimal dTienHang = 0;
                decimal dDisCount = 0;
                dTienGio = Convert.ToDecimal(txtHourMoney.EditValue) + Convert.ToDecimal(txtTienCP.EditValue);
                dTienHang = Convert.ToDecimal(txtFBMoney.EditValue);
                dDisCount = Convert.ToDecimal(txtDiscount.EditValue);
                txtTotal.EditValue = dTienGio + dTienHang + dDisCount;

                Save();
            }
        }

        private void btnTang_Click(object sender, EventArgs e)
        {
            speSL.Value += 1;
        }

        private void btnGiam_Click(object sender, EventArgs e)
        {

            if (speSL.Value > 1)
            {
                speSL.Value -= 1;
            }

        }

        private void ThemMon(int p, decimal dSL)
        {
            grvThucDon.SetRowCellValue(p, grvThucDon.Columns["SoLuong"], dSL);
            if (grvThucDon.GetRowCellValue(p, grvThucDon.Columns["GoldCode"]).Equals("1"))
            {
                grvThucDon.SetRowCellValue(p, grvThucDon.Columns["SellRate"], dGiaBan);
            }
            decimal dDonGia = Convert.ToDecimal(grvThucDon.GetRowCellValue(p, grvThucDon.Columns["SellRate"]));
            grvThucDon.SetRowCellValue(p, grvThucDon.Columns["Amount"], Functions.fn_VNDRounding(dSL * dDonGia));
        }

        private void UpdateMon(int p, decimal dUpdate)
        {
            decimal dSL = Convert.ToDecimal(grvThucDon.GetRowCellValue(p, grvThucDon.Columns["SoLuong"]));
            decimal dSLMoi = dSL - dUpdate;
            if (dSLMoi < 0)
            {
                ThongBao.Show("Thông Báo", "Số món trả lớn hơn số món đã đặt.", "Đóng", ICon.Warning);
                return;
            }
            else if ((dSLMoi) == 0)
            {
                grvThucDon.DeleteRow(p);
                return;
            }

            grvThucDon.SetRowCellValue(p, grvThucDon.Columns["SoLuong"], (dSLMoi));
            if (grvThucDon.GetRowCellValue(p, grvThucDon.Columns["GoldCode"]).Equals("1"))
            {
                grvThucDon.SetRowCellValue(p, grvThucDon.Columns["SellRate"], dGiaBan);
            }
            decimal dDonGia = Convert.ToDecimal(grvThucDon.GetRowCellValue(p, grvThucDon.Columns["SellRate"]));
            grvThucDon.SetRowCellValue(p, grvThucDon.Columns["Amount"], Functions.fn_VNDRounding(dSLMoi * dDonGia));
        }

        private void grvThucDon_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
        {
            //TinhTienHoaDon();
            //Save();
        }

        private void grvThucDon_InitNewRow(object sender, DevExpress.XtraGrid.Views.Grid.InitNewRowEventArgs e)
        {
            try
            {
                this.grvThucDon.SetRowCellValue(e.RowHandle, "GoldCode", strGoldCode);
                this.grvThucDon.SetRowCellValue(e.RowHandle, "GoldDesc", strGoldDesc);
                this.grvThucDon.SetRowCellValue(e.RowHandle, "UnitCode", strMaDVt);
                this.grvThucDon.SetRowCellValue(e.RowHandle, "UnitDesc", strDVt);
                this.grvThucDon.SetRowCellValue(e.RowHandle, "SectionID", strSectionID);
                this.grvThucDon.SetRowCellValue(e.RowHandle, "SoLuong", dSL);
                this.grvThucDon.SetRowCellValue(e.RowHandle, "SellRate", dGiaBan);
                this.grvThucDon.SetRowCellValue(e.RowHandle, "Amount", dThanhTien);
            }
            catch { }

        }

        private void grvThucDon_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (e.FocusedRowHandle > -1)
            {
                speSL.Value = Convert.ToDecimal(grvThucDon.GetRowCellValue(e.FocusedRowHandle, grvThucDon.Columns["SoLuong"]));
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (grvHang.FocusedRowHandle > -1)
            {
                strGoldCode = grvHang.GetFocusedRowCellValue(grvHang.Columns["GoldCode"]).ToString();
                strGoldDesc = grvHang.GetFocusedRowCellValue(grvHang.Columns["GoldDesc"]).ToString();
                strMaDVt = grvHang.GetFocusedRowCellValue(grvHang.Columns["UnitCode"]).ToString();
                strDVt = grvHang.GetFocusedRowCellValue(grvHang.Columns["UnitDesc"]).ToString();
                strSectionID = grvHang.GetFocusedRowCellValue(grvHang.Columns["SectionID"]).ToString();
                dSL = spOrder.Value;
                dGiaBan = btnVIP.Text == "N" ? Convert.ToDecimal(grvHang.GetFocusedRowCellValue(grvHang.Columns["TruLai"])) : Convert.ToDecimal(grvHang.GetFocusedRowCellValue(grvHang.Columns["TruGia"]));
                dThanhTien = dSL * dGiaBan;
                bool themmoi = true;
                int index = 0;
                decimal dSLMoi = 0;
                if (grvThucDon.RowCount > 0)
                {
                    for (int i = 0; i < grvThucDon.RowCount; i++)
                    {
                        if (grvThucDon.GetRowCellValue(i, grvThucDon.Columns["GoldCode"]).ToString().Equals(strGoldCode))
                        {
                            themmoi = false;
                            index = i;
                            dSLMoi = Convert.ToDecimal(grvThucDon.GetRowCellValue(i, grvThucDon.Columns["SoLuong"])) + dSL;
                            break;
                        }
                    }

                }
                if (themmoi)
                {
                    grvThucDon.AddNewRow();
                    grvThucDon.UpdateCurrentRow();
                    TinhTienHoaDon();
                }
                else
                {
                    ThemMon(index, dSLMoi);
                    TinhTienHoaDon();
                }
                Save();
                SaveBep("1");
            }
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            if (grvThucDon.FocusedRowHandle > -1)
            {
                if (grvThucDon.GetRowCellValue(grvThucDon.FocusedRowHandle, "GoldCode").Equals("2"))
                {
                    ThongBao.Show("Thông Báo", "Tiền giờ (chuyển phòng ) không thể hủy", "Đóng", ICon.Information);
                    return;
                }
                strGoldCode = grvThucDon.GetFocusedRowCellValue(grvThucDon.Columns["GoldCode"]).ToString();
                strGoldDesc = grvThucDon.GetFocusedRowCellValue(grvThucDon.Columns["GoldDesc"]).ToString();
                strMaDVt = grvThucDon.GetFocusedRowCellValue(grvThucDon.Columns["UnitCode"]).ToString();
                strSectionID = grvThucDon.GetFocusedRowCellValue(grvThucDon.Columns["SectionID"]).ToString();
                dSL = Convert.ToDecimal(grvThucDon.GetFocusedRowCellValue(grvThucDon.Columns["SoLuong"]));
                dGiaBan = Convert.ToDecimal(grvThucDon.GetFocusedRowCellValue(grvThucDon.Columns["SellRate"]));
                dThanhTien = dSL * dGiaBan;
                grvThucDon.DeleteRow(grvThucDon.FocusedRowHandle);
                TinhTienHoaDon();
                if (!string.IsNullOrEmpty(magd))
                {
                    Save();
                    SaveBep("2");
                }
            }
        }

        private void Save()
        {
            if (isLoading)
                return;
            DataSet ds = new DataSet();
            //Khởi tạo DBH
            if (string.IsNullOrEmpty(magd))
            {
                KhoiTaoHoaDon();
                ds = clsCommon.ExecuteDatasetSP("HOADONBANGANG_INS", lblBillID.Text, room, dteNgay.DateTime.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm"), speSoNguoi.Value, dteStart.Text, dteEnd.Text
                    , Convert.ToDecimal(txtHourMoney.Text), Convert.ToDecimal(txtTienCP.Text), Convert.ToDecimal(txtFBMoney.Text), Convert.ToDecimal(txtDiscount.Text), Convert.ToDecimal(txtTotal.Text), "W", "0", clsSystem.UserID, DateTime.Now.ToString("dd/MM/yyyy")
                    , (cboUserID.SelectedItem as ItemList).ID, txtNotes.Text, btnVIP.Text == "N" ? 0 : 1);

            }
            else
            {
                ds = clsCommon.ExecuteDatasetSP("HOADONBANGANG_Upd", magd, lblBillID.Text, room, dteNgay.DateTime.ToString("dd/MM/yyyy"), DateTime.Now.ToString("HH:mm"), speSoNguoi.Value, dteStart.Text, dteEnd.Text
                 , Convert.ToDecimal(txtHourMoney.Text), Convert.ToDecimal(txtTienCP.Text), Convert.ToDecimal(txtFBMoney.Text), Convert.ToDecimal(txtDiscount.Text), Convert.ToDecimal(txtTotal.Text), "W", "0", clsSystem.UserID, DateTime.Now.ToString("dd/MM/yyyy")
                 , (cboUserID.SelectedItem as ItemList).ID, txtNotes.Text, btnVIP.Text == "N" ? 0 : 1);
            }
            if (ds != null && ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0")
            {

                //Khởi tạo chi tiết DBH
                magd = ds.Tables[0].Rows[0]["TrnID"].ToString();
                string strGoldCode = string.Empty;
                string strGoldDesc = string.Empty;
                string strPriceUnit = string.Empty;
                string strPriceCcy = string.Empty;
                string strSectionID = string.Empty;
                string strSellRate = string.Empty;
                string strSL = string.Empty;
                string strSellAmount = string.Empty;
                for (int i = 0; i < grvThucDon.RowCount; i++)
                {
                    DataRow dr = grvThucDon.GetDataRow(i);

                    strGoldCode += dr["GoldCode"].ToString() + "@";
                    strGoldDesc += dr["GoldDesc"].ToString() + "@";
                    strPriceUnit += dr["UnitCode"].ToString() + "@";
                    strPriceCcy += "VND" + "@";
                    strSectionID += dr["SectionID"].ToString() + "@";
                    strSellRate += dr["SellRate"].ToString() + "@";
                    strSL += dr["SoLuong"].ToString() + "@";
                    strSellAmount += dr["Amount"].ToString() + "@";
                }

                ds = clsCommon.ExecuteDatasetSP("CHITIETHOADONBANHANG_INS", magd, strGoldCode, strGoldDesc, strPriceUnit, strPriceCcy, strSectionID, strSellRate, strSL, strSellAmount);
            }
            InitSoDoPhong();
            EnabledChucNang(true);
        }

        private void SaveBep(string loai)
        {
            if (isLoading)
                return;
            DataSet ds = new DataSet();
            if (!string.IsNullOrEmpty(magd))
            {

                ////Khởi tạo chi tiết DBH              
                //string strGoldCode = string.Empty;
                //string strGoldDesc = string.Empty;
                //string strPriceUnit = string.Empty;
                //string strPriceCcy = string.Empty;
                //string strSectionID = string.Empty;
                //string strSellRate = string.Empty;
                //string strSL = string.Empty;
                //string strSellAmount = string.Empty;

                //int[] selects = grvThucDon.GetSelectedRows();
                //for (int i = 0; i < selects.Length; i++)
                //{
                //    DataRow dr = grvThucDon.GetDataRow(i);

                //    strGoldCode += dr["GoldCode"].ToString() + "@";
                //    strGoldDesc += dr["GoldDesc"].ToString() + "@";
                //    strPriceUnit += dr["UnitCode"].ToString() + "@";
                //    strPriceCcy += "VND" + "@";
                //    strSectionID += dr["SectionID"].ToString() + "@";
                //    strSellRate += dr["SellRate"].ToString() + "@";
                //    strSL += dr["SoLuong"].ToString() + "@";
                //    strSellAmount += dr["Amount"].ToString() + "@";
                //}
                ds = clsCommon.ExecuteDatasetSP("CHITIETHOADONBEP_INS", magd, loai, strGoldCode, strGoldDesc, strMaDVt, "VND", strSectionID, dGiaBan, dSL, dThanhTien);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(room))
            {
                ThongBao.Show("Thông báo", "Vui lòng chọn phòng hát", "Đồng ý", ICon.Information);
                return;
            }
            SetStartTime();
            Save();
        }

        private void SetStartTime()
        {
            //Set Start Time
            dteStart.Text = DateTime.Now.ToString("hh:mm tt");
            //Disable 
            btnStart.Enabled = false;
            btnEditGioVao.Enabled = true;
        }
        private void SetEditStartTime(string edit)
        {
            //Set Start Time
            dteStart.Text = edit;
            //Disable 
            btnStart.Enabled = false;
            btnEditGioVao.Enabled = true;
        }

        private void KhoiTaoHoaDon()
        {
            //Tao BillID          
            DataSet ds = clsCommon.ExecuteDatasetSP("CREATEBILLID");
            //magd = ds.Tables[0].Rows[0][0].ToString();
            lblBillID.Text = ds.Tables[0].Rows[0][0].ToString();

        }

        private void btnPrintBill_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(magd))
                {
                    DataSet ds = clsCommon.ExecuteDatasetSP("[rptSRT_PrintBill]", magd);
                    Functions.fn_ShowReport_CloseAfterPrint(ds, "InBillThanhToan.rpt", "", "", false);
                }
            }
            catch (Exception ex) { }

        }

        private void speSoNguoi_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(magd))
            {
                Save();
            }
        }

        private void txtNotes_EditValueChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(magd))
            {
                Save();
            }
        }

        private void btnEnd_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(magd))
            {
                SetEndTime();
                TinhTienHoaDon();
                Save();
            }
        }

        private void SetEndTime()
        {
            //Set End Time
            dteEnd.Text = DateTime.Now.ToString("hh:mm tt");
            TinhTienGio();
        }

        private void TinhTienGio()
        {
            decimal dSL = 0;
            decimal dGiaBan = 0;
            decimal dThanhTien = 0;
            TimeSpan start23 = new TimeSpan(23, 0, 0);
            TimeSpan end23 = new TimeSpan(23, 59, 59);
            TimeSpan start12 = new TimeSpan(0, 0, 0);
            TimeSpan end12 = new TimeSpan(9, 59, 59);
            TimeSpan start10 = new TimeSpan(10, 0, 0);
            TimeSpan end10 = new TimeSpan(22, 59, 59);
            //TimeSpan duration = DateTime.Parse(dteEnd.Text).Subtract(DateTime.Parse(dteStart.Text));
            //if (duration.TotalHours < 0)
            //{
            //    dSL = Math.Round(24 + Convert.ToDecimal(duration.TotalHours), 2);
            //}
            //else
            //    dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
            DateTime ngaytinh = dteNgay.DateTime;
            if (Functions.TimeBetween(DateTime.Parse(dteStart.Text), start12, end12))
            {
                ngaytinh = ngaytinh.AddDays(-1);
            }
            string ngaythang = ngaytinh.ToString("dd/MM");
            DataSet ds = clsCommon.ExecuteDatasetSP("T_NgayLe_Get", ngaythang);
            //Ki?m tra có ph?i ngày l?
            if (ds != null && ds.Tables[0].Rows.Count > 0)
            {
                dGiaBan = btnVIP.Text == "N" ? Convert.ToDecimal(ds.Tables[0].Rows[0]["TienPhongThuong"]) : Convert.ToDecimal(ds.Tables[0].Rows[0]["TienPhongVIP"]);
            }
            else
            {
                if (ngaytinh.DayOfWeek == DayOfWeek.Saturday || ngaytinh.DayOfWeek == DayOfWeek.Sunday)
                {
                    dGiaBan = btnVIP.Text == "N" ? (decimal)tienphong + clsSystem.HSLe : (decimal)tienphong + clsSystem.HSLe;
                }
                else dGiaBan = btnVIP.Text == "N" ? (decimal)tienphong : (decimal)tienphong;
            }
            //Tính thêm khi hát luc 11h,12h
            //Neu vao tu 10h den 23h
            if (Functions.TimeBetween(DateTime.Parse(dteStart.Text), start10, end10))
            {
                //Nếu ra từ 10h  đến 23
                if (Functions.TimeBetween(DateTime.Parse(dteEnd.Text), start10, end10))
                {
                    TimeSpan duration = DateTime.Parse(dteEnd.Text).Subtract(DateTime.Parse(dteStart.Text));
                    if (duration.TotalHours < 0)
                    {
                        dSL = Math.Round(Convert.ToDecimal(24 + duration.TotalHours), 2);
                    }
                    else
                        dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
                    dThanhTien = Functions.fn_VNDRounding(dSL * (dGiaBan));
                }
                //Nếu ra từ 23h toi đến 12h sang
                else if (Functions.TimeBetween(DateTime.Parse(dteEnd.Text), start23, end23))
                {
                    //tinh den 23h toi
                    TimeSpan duration = DateTime.Parse("11:00 PM").Subtract(DateTime.Parse(dteStart.Text));
                    if (duration.TotalHours < 0)
                    {
                        dSL = 0;
                    }
                    else
                        dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
                    dThanhTien = Functions.fn_VNDRounding(dSL * (dGiaBan));

                    //Den gio ve
                    if (dteEnd.Text.Contains("12:00"))
                    {
                        dSL = 1;
                    }
                    else
                    {
                        duration = DateTime.Parse(dteEnd.Text).Subtract(DateTime.Parse("11:00 PM"));
                        if (duration.TotalHours < 0)
                        {
                            dSL = 0;
                        }
                        else
                            dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
                    }
                    dThanhTien += Functions.fn_VNDRounding(dSL * (dGiaBan + clsSystem.TiemThem11h));
                }
                //Nếu ra sau 12h
                else if (Functions.TimeBetween(DateTime.Parse(dteEnd.Text), start12, end12))
                {
                    //tinh den 23h toi
                    TimeSpan duration = DateTime.Parse("11:00 PM").Subtract(DateTime.Parse(dteStart.Text));
                    if (duration.TotalHours < 0)
                    {
                        dSL = 0;
                    }
                    else
                        dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
                    dThanhTien = Functions.fn_VNDRounding(dSL * (dGiaBan));

                    //Den 12 sang                    
                    dThanhTien += Functions.fn_VNDRounding(1 * (dGiaBan + clsSystem.TiemThem11h));
                    //Tu 12 h sang den ve
                    duration = DateTime.Parse(dteEnd.Text).Subtract(DateTime.Parse("12:00 AM"));
                    if (duration.TotalHours < 0)
                    {
                        dSL = 0;
                    }
                    else
                        dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
                    dThanhTien += Functions.fn_VNDRounding(dSL * (dGiaBan + clsSystem.TiemThem12h));
                }
            }
            //Nếu vào hát từ 11h đến 12h
            else if (Functions.TimeBetween(DateTime.Parse(dteStart.Text), start23, end23))
            {
                //Nếu ra từ 11h đến 12h
                if (Functions.TimeBetween(DateTime.Parse(dteEnd.Text), start23, end23))
                {
                    TimeSpan duration = DateTime.Parse(dteEnd.Text).Subtract(DateTime.Parse(dteStart.Text));
                    if (duration.TotalHours < 0)
                    {
                        dSL = Math.Round(Convert.ToDecimal(24 + duration.TotalHours), 2);
                    }
                    else
                        dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
                    dThanhTien = Functions.fn_VNDRounding(dSL * (dGiaBan + clsSystem.TiemThem11h));
                }
                //Nếu ra từ 12h sang1 đến 10h sang
                else if (Functions.TimeBetween(DateTime.Parse(dteEnd.Text), start12, end12))
                {
                    //Den 12h sang
                    TimeSpan duration = DateTime.Parse("12:00 AM").Subtract(DateTime.Parse(dteStart.Text));
                    if (duration.TotalHours < 0)
                    {
                        dSL = Math.Round(Convert.ToDecimal(24 + duration.TotalHours), 2);
                    }
                    else
                        dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
                    dThanhTien = Functions.fn_VNDRounding(dSL * (dGiaBan + clsSystem.TiemThem11h));

                    //Tính tiền đến gio ve
                    duration = DateTime.Parse(dteEnd.Text).Subtract(DateTime.Parse("12:00 AM"));
                    if (duration.TotalHours < 0)
                    {
                        dSL = 0;
                    }
                    else
                        dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
                    dThanhTien += Functions.fn_VNDRounding(dSL * (dGiaBan + clsSystem.TiemThem12h));

                }
                //Nếu ra từ 10h sang đến 23h 
                else if (Functions.TimeBetween(DateTime.Parse(dteEnd.Text), start10, end10))
                {
                    //Den 12h sang
                    TimeSpan duration = DateTime.Parse("12:00 AM").Subtract(DateTime.Parse(dteStart.Text));
                    if (duration.TotalHours < 0)
                    {
                        dSL = Math.Round(Convert.ToDecimal(24 + duration.TotalHours), 2);
                    }
                    else
                        dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
                    dThanhTien = Functions.fn_VNDRounding(dSL * (dGiaBan + clsSystem.TiemThem11h));

                    //Tính tiền đến 10h sang                    
                    dThanhTien += Functions.fn_VNDRounding(10 * (dGiaBan + clsSystem.TiemThem12h));

                    //Tính tiền từ 10h đến ve
                    duration = DateTime.Parse(dteEnd.Text).Subtract(DateTime.Parse("10:00 AM"));
                    if (duration.TotalHours < 0)
                    {
                        dSL = 0;
                    }
                    else
                        dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
                    dThanhTien += Functions.fn_VNDRounding(dSL * (dGiaBan));
                }
            }
            //Vào hát từ 12h sáng
            else if (Functions.TimeBetween(DateTime.Parse(dteStart.Text), start12, end12))
            {
                //Nếu ra trc 10h sáng
                if (Functions.TimeBetween(DateTime.Parse(dteEnd.Text), start12, end12))
                {
                    TimeSpan duration = DateTime.Parse(dteEnd.Text).Subtract(DateTime.Parse(dteStart.Text));
                    if (duration.TotalHours < 0)
                    {
                        dSL = Math.Round(Convert.ToDecimal(24 + duration.TotalHours), 2);
                    }
                    else
                        dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
                    dThanhTien = Functions.fn_VNDRounding(dSL * (dGiaBan + clsSystem.TiemThem12h));
                }
                //Nếu ra từ 10h sang đến 23h đêm
                else if (Functions.TimeBetween(DateTime.Parse(dteEnd.Text), start10, end10))
                {
                    //Tính tiền từ giờ vào đến 10h sáng
                    TimeSpan duration = DateTime.Parse("10:00 AM").Subtract(DateTime.Parse(dteStart.Text));
                    if (duration.TotalHours < 0)
                    {
                        dSL = 0;
                    }
                    else
                        dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
                    dThanhTien = Functions.fn_VNDRounding(dSL * (dGiaBan + clsSystem.TiemThem12h));
                    //Từ 10h sáng đến về                    
                    duration = DateTime.Parse(dteEnd.Text).Subtract(DateTime.Parse("10:00 AM"));
                    if (duration.TotalHours < 0)
                    {
                        dSL = 0;
                    }
                    else
                        dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
                    dThanhTien += Functions.fn_VNDRounding(dSL * (dGiaBan));
                }
                //Nếu ra từ 23h đến 24h 
                else if (Functions.TimeBetween(DateTime.Parse(dteEnd.Text), start23, end23))
                {
                    //Tính tiền từ giờ vào đến 10h sáng
                    TimeSpan duration = DateTime.Parse("10:00 AM").Subtract(DateTime.Parse(dteStart.Text));
                    if (duration.TotalHours < 0)
                    {
                        dSL = 0;
                    }
                    else
                        dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
                    dThanhTien = Functions.fn_VNDRounding(dSL * (dGiaBan + clsSystem.TiemThem12h));
                    //Từ 10h sáng đến 11h tối                  
                    dThanhTien += Functions.fn_VNDRounding(13 * (dGiaBan));
                    //Tu 11h den ket thuc     
                    if (dteEnd.Text.Contains("12:00"))
                    {
                        dSL = 1;
                    }
                    else
                    {
                        duration = DateTime.Parse(dteEnd.Text).Subtract(DateTime.Parse("11:00 PM"));
                        if (duration.TotalHours < 0)
                        {
                            dSL = 0;
                        }
                        else
                            dSL = Math.Round(Convert.ToDecimal(duration.TotalHours), 2);
                    }

                    dThanhTien += Functions.fn_VNDRounding(dSL * (dGiaBan + clsSystem.TiemThem11h));
                }
            }
            txtHourMoney.EditValue = dThanhTien;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (!string.IsNullOrEmpty(magd))
                {
                    if (ThongBao.Show("Thông báo", "Bạn muốn hủy hóa đơn phòng này ?", "Có", "Không", ICon.QuestionMark) == DialogResult.OK)
                    {
                        ds = clsCommon.ExecuteDatasetSP("[HOADONBANGANG_DEL]", magd, room);
                        if (ds != null && ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0")
                        {
                            ThongBao.Show("Thông báo", "Hủy phòng thành công!", "OK", ICon.Information);
                            InitSoDoPhong();
                            LoadThongTinPhongMoi();
                            EnabledChucNang(false);
                        }
                    }
                }
            }
            catch { }
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (grvThucDon.FocusedRowHandle > -1)
            {
                if (grvThucDon.GetDataRow(grvThucDon.FocusedRowHandle)["GoldCode"].Equals("1") || grvThucDon.GetDataRow(grvThucDon.FocusedRowHandle)["GoldCode"].Equals("2"))
                    return;
                strGoldCode = grvThucDon.GetFocusedRowCellValue(grvThucDon.Columns["GoldCode"]).ToString();
                strGoldDesc = grvThucDon.GetFocusedRowCellValue(grvThucDon.Columns["GoldDesc"]).ToString();
                strMaDVt = grvThucDon.GetFocusedRowCellValue(grvThucDon.Columns["UnitCode"]).ToString();
                strSectionID = grvThucDon.GetFocusedRowCellValue(grvThucDon.Columns["SectionID"]).ToString();
                dSL = speSL.Value;
                dGiaBan = Convert.ToDecimal(grvThucDon.GetFocusedRowCellValue(grvThucDon.Columns["SellRate"]));
                dThanhTien = dSL * dGiaBan;
                UpdateMon(grvThucDon.FocusedRowHandle, speSL.Value);
                TinhTienHoaDon();
                Save();                
                SaveBep("2");
            }
        }

        private void btnTransfer_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (btnStart.Enabled)
                {
                    ThongBao.Show("Thông báo", "Chưa tính tiền giờ cho phòng này!", "OK", ICon.Information);
                    return;
                }
                frmChangeRoom frm = new frmChangeRoom(room);
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    string changeroom = frm.changeroom;
                    string changemagd = frm.changemagd;
                    //Tính tiền giờ phòng này
                    btnEnd_Click(sender, e);
                    //Thực hiện chuyển phòng
                    ds = clsCommon.ExecuteDatasetSP("ChuyenPhong", magd, room, changemagd, changeroom);
                    if (ds != null && ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0")
                    {
                        ThongBao.Show("Thông báo", "Chuyển phòng thành công!", "OK", ICon.Information);
                        InitSoDoPhong();
                        LoadThongTinPhongMoi();
                        EnabledChucNang(false);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                if (btnStart.Enabled)
                {
                    ThongBao.Show("Thông báo", "Chưa tính tiền giờ cho phòng này!", "OK", ICon.Information);
                    return;
                }
                if (clsSystem.TillID == "")
                {
                    ThongBao.Show("Lỗi", "Không thể thanh toán vì chưa mở quầy thu ngân.", "OK", ICon.Error);
                    return;
                }
                btnEnd_Click(sender, e);
                btnPrintBill_Click(null, null);
                ds = clsCommon.ExecuteDatasetSP("ThanhToan", magd, room, clsSystem.UserID);
                if (ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0")
                {                    
                    if (FunctionTill.fn_TillProccessTxn(magd) == "0")
                    {
                        //if (clsSystem.IsSMS)
                        //{
                        //    StringBuilder msg = new StringBuilder();
                        //    msg.AppendLine(clsSystem.ShopName + " " + DateTime.Now.ToString("dd/MM/yyyy HH:mm"));
                        //    msg.AppendLine("Phòng:" + tenphong);
                        //    msg.AppendLine("Thanh toán:" + Convert.ToDecimal(txtTotal.Text).ToString("#,##0"));

                        //    //if (TongTien > 10000000)
                        //    CommSetting.SendMessage(msg.ToString());
                        //}

                        InitSoDoPhong();
                        LoadThongTinPhongMoi();
                        EnabledChucNang(false);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
            }
        }

        private void btnVIP_Click(object sender, EventArgs e)
        {
            if (ThongBao.Show("Thông báo", "Bạn có muốn thay đổi loại phòng", "Có", "Không", ICon.Information) == DialogResult.OK)
            {
                btnVIP.Text = (btnVIP.Text == "N") ? "V" : "N";
                CapNhatHDTheoLoaiPhong();
                if (!string.IsNullOrEmpty(magd))
                {
                    Save();
                }
            }
        }

        private void CapNhatHDTheoLoaiPhong()
        {
            if (grvThucDon.RowCount > 0)
            {
                for (int i = 0; i < grvThucDon.RowCount; i++)
                {
                    DataRow dr = grvThucDon.GetDataRow(i);
                    if (dr != null && dr["GoldCode"].ToString() != "2")
                    {
                        decimal giaban = 0;
                        if (btnVIP.Text.Equals("V"))
                        {
                            giaban = Convert.ToDecimal(clsSystem.IGold.Tables[0].Select("GoldCode='" + dr["GoldCode"].ToString() + "'")[0]["TruGia"]);
                            decimal dSL = Convert.ToDecimal(grvThucDon.GetRowCellValue(i, grvThucDon.Columns["SoLuong"]));
                            grvThucDon.SetRowCellValue(i, grvThucDon.Columns["SellRate"], giaban);
                            grvThucDon.SetRowCellValue(i, grvThucDon.Columns["Amount"], Functions.fn_VNDRounding(dSL * giaban));
                        }
                        else
                        {
                            giaban = Convert.ToDecimal(clsSystem.IGold.Tables[0].Select("GoldCode='" + dr["GoldCode"].ToString() + "'")[0]["TruLai"]);
                            decimal dSL = Convert.ToDecimal(grvThucDon.GetRowCellValue(i, grvThucDon.Columns["SoLuong"]));
                            grvThucDon.SetRowCellValue(i, grvThucDon.Columns["SellRate"], giaban);
                            grvThucDon.SetRowCellValue(i, grvThucDon.Columns["Amount"], Functions.fn_VNDRounding(dSL * giaban));
                        }
                    }
                }
                TinhTienHoaDon();
            }
        }

        private void btnEditGioVao_Click(object sender, EventArgs e)
        {
            DateTime dteIn = DateTime.Parse(dteStart.Text);
            frmChangeHours frm = new frmChangeHours(dteIn);
            if (DialogResult.OK == frm.ShowDialog())
            {
                SetEditStartTime(frm.dteStart);
                Save();
            }
        }

        private void btnThemNgoai_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtTenMon.Text) && cbbDVT.SelectedIndex > 0 && !string.IsNullOrEmpty(speGia.Text))
            {
                strGoldCode = Guid.NewGuid().ToString().Substring(0, 10);
                strGoldDesc = txtTenMon.Text;
                strMaDVt = ((ItemList)cbbDVT.SelectedItem).ID;
                strDVt = ((ItemList)cbbDVT.SelectedItem).Value;
                strSectionID = "MN";
                dSL = 1;
                dGiaBan = speGia.Value;
                dThanhTien = dSL * dGiaBan;
                bool themmoi = true;

                if (themmoi)
                {
                    grvThucDon.AddNewRow();
                    grvThucDon.UpdateCurrentRow();
                    TinhTienHoaDon();
                    Save();
                    SaveBep("1");
                }
            }
        }

        private void btnGuiBep_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(magd))
                {
                    DataSet ds = clsCommon.ExecuteDatasetSP("[rptHDB_PrintBill]", magd, "1");
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        Functions.fn_ShowReport_CloseAfterPrint(ds, "InBillBep.rpt", "GIOLAP", DateTime.Now.ToString("HH:mm"), true);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
            }

            try
            {
                DataSet ds = clsCommon.ExecuteDatasetSP("CapNhatHDH", magd, "1", clsSystem.UserID);
                if (ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0")
                {

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
            }
        }

        private void btnTraBep_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(magd))
                {
                    DataSet ds = clsCommon.ExecuteDatasetSP("[rptHDB_PrintBill]", magd, "2");
                    if (ds.Tables[1].Rows.Count > 0)
                    {
                        Functions.fn_ShowReport_CloseAfterPrint(ds, "InBillTraBep.rpt", "GIOLAP", DateTime.Now.ToString("HH:mm"), false);
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
            }
            try
            {
                DataSet ds = clsCommon.ExecuteDatasetSP("CapNhatHDH", magd, "2", clsSystem.UserID);
                if (ds.Tables[0].Rows[0]["ErrCode"].ToString() == "0")
                {

                }
            }
            catch (Exception ex)
            {
                log.Error(ex.ToString(), ex);
            }
        }
    }
}