using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using Messages;

namespace Messages
{
    class ThongBao
    {
        public static DialogResult Show(string Title, string Message, string OKButton, string CancelButton, ICon icon)
        {
            frmThongBao frm = new frmThongBao(Title, Message, OKButton, CancelButton, icon);
            return frm.ShowDialog();
        }
        public static DialogResult Show(string Title, string Message, string CancelButton, ICon icon)
        {
            frmThongBao frm = new frmThongBao(Title, Message, "", CancelButton, icon);
            return frm.ShowDialog();
        }
        public static DialogResult Show(string Title, string Message, string OKButton, string CancelButton)
        {
            frmThongBao frm = new frmThongBao(Title, Message, OKButton, CancelButton, ICon.None);
            return frm.ShowDialog();
        }
    }
}
