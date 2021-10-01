using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace YDM.CustomeUserControl
{
    public partial class SettingItemControl : UserControl
    {
        private readonly string _actualName;
        private readonly IsValid _check;
        private readonly Type _objtype;

        public SettingItemControl(string settingName, string actualName, IsValid check, Type objtype)
        {
            InitializeComponent();
            LblSettingFor.Text = settingName;
            TxtBoxSettingID.Text = Properties.Settings.Default[actualName].ToString();
            TxtBoxSettingID.LostFocus += TxtBoxSettingID_FontChanged;
            _actualName = actualName;
            _check = check;
            this._objtype = objtype;
        }

        public delegate bool IsValid(object path);

        private void TxtBoxSettingID_FontChanged(object sender, EventArgs e)
        {
            if (_check(TxtBoxSettingID.Text))
            {
                TxtBoxSettingID.BackColor = default;
                Properties.Settings.Default[_actualName] = Convert.ChangeType(TxtBoxSettingID.Text, _objtype);
                Properties.Settings.Default.Save();
                TxtBoxSettingID.LostFocus -= TxtBoxSettingID_FontChanged;
            }
            else
            {
                TxtBoxSettingID.Select();
                TxtBoxSettingID.BackColor = Color.Red;
                TxtBoxSettingID.LostFocus -= TxtBoxSettingID_FontChanged;
            }
            TxtBoxSettingID.LostFocus += TxtBoxSettingID_FontChanged;
        }
    }
}
