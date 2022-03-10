using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Messages
{
    public enum ListButton
    {
        Close, OkCancel, YesNo
    };

    public enum ICon
    {
        QuestionMark, Information, Error, Warning, None
    };
    public enum Result
    {
        Close, Ok, Cancel, Abort, Yes, No, Back, Next
    };
    public partial class frmThongBao : DevExpress.XtraEditors.XtraForm
    {
        public frmThongBao(string Title, string Message, string OKButton, string CancelButton, ICon icon)
        {
            InitializeComponent();
            this.Text = Title;
            btnOK.Text = OKButton;
            btnCancel.Text = CancelButton;
            lblMessage.Text = Message;
            if (OKButton == "")
                btnOK.Dispose();
            SetIcon(icon);
        }

        private void SetIcon(ICon icon)
        {
            switch (icon)
            {
                case ICon.Information:
                    pictureBox.Image = imageCollection.Images[0];
                    break;
                case ICon.Error:
                    pictureBox.Image = imageCollection.Images[1];
                    break;
                case ICon.QuestionMark:
                    pictureBox.Image = imageCollection.Images[2];
                    break;
                case ICon.Warning:
                    pictureBox.Image = imageCollection.Images[3];
                    break;
                default:
                    pictureBox.Image = imageCollection.Images[0];
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
        }

        private void frmThongBao_Load(object sender, EventArgs e)
        {
            
        }
    }
}