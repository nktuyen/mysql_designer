using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;

namespace mysql_designer
{
    public partial class frmGenerator : Form
    {

        public frmGenerator()
        {
            InitializeComponent();
        }

        private void frmGenerator_Load(object sender, EventArgs e)
        {
            Excel.Workbook activeWB = ExcelHelper.Instance.Application.ActiveWorkbook;
            if(null != activeWB)
            {
                foreach(Excel.Worksheet sheet in activeWB.Sheets)
                {
                    cbSheets.Items.Add(sheet.Name);
                }
            }
        }

        private void frmGenerator_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(e.CloseReason == CloseReason.UserClosing)
            {
                this.Hide();
                e.Cancel = true;
            }
        }

        private void radAllSheets_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radCurrentSheet_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void radSpecifiedSheet_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

        }

        private void cbSheets_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
