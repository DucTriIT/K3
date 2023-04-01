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
        private DateTime gioedit;
        private bool isGiovao;
        public string dteStart;
        public frmChangeHours()
        {
            InitializeComponent();
        }
        public frmChangeHours(DateTime gioedit, bool isGiovao = true)
        {
            InitializeComponent();
            this.gioedit = gioedit;
            this.isGiovao = isGiovao;
            timeIn.EditValue = DateTime.Parse(this.gioedit.ToString("MM/dd/yyyy HH:mm"));
        }

        private void btnEditGioVao_Click(object sender, EventArgs e)
        {
            if (isGiovao && timeIn.Time.CompareTo(gioedit) > 0)
            {
                return;
            }
            else if(!isGiovao && timeIn.Time.CompareTo(gioedit) < 0)
            {
                return;
            }
            this.dteStart = timeIn.Time.ToString("hh:mm tt");
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
