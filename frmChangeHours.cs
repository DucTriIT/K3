using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;

namespace SuperX
{
    public partial class frmChangeHours : Form
    {
        private DateTime giovao;
        public string dteStart;
        public frmChangeHours()
        {
            InitializeComponent();
        }
        public frmChangeHours(DateTime giovao)
        {
            InitializeComponent();
            this.giovao = giovao;
            timeIn.EditValue = DateTime.Parse(this.giovao.ToString("MM/dd/yyyy HH:mm"));
        }

        private void btnEditGioVao_Click(object sender, EventArgs e)
        {
            if (timeIn.Time.CompareTo(giovao) > 0)
            {
                return;
            }
            this.dteStart = timeIn.Time.ToString("hh:mm tt");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
