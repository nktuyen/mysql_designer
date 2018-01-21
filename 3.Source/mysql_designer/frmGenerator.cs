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
        public Excel.Workbook Book { get; set; }

        public frmGenerator()
        {
            InitializeComponent();
        }

        private string ResourceString(string index)
        {
            try
            {
                return Properties.Resources.ResourceManager.GetString(index);
            }
            catch
            {
                return index;
            }
        }

        private void frmGenerator_Load(object sender, EventArgs e)
        {
            if(null != Book)
            {
                foreach(Excel.Worksheet sheet in Book.Sheets)
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
            cbSheets.SelectedIndex = -1;
            cbSheets.Enabled = false;
        }

        private void radCurrentSheet_CheckedChanged(object sender, EventArgs e)
        {
            if (null != Book)
            {
                Excel.Worksheet curSheet = Book.ActiveSheet;
                if (null != curSheet)
                {
                    cbSheets.SelectedIndex = cbSheets.FindString(curSheet.Name);
                }
            }
            cbSheets.Enabled = false;
        }

        private void radSpecifiedSheet_CheckedChanged(object sender, EventArgs e)
        {
            cbSheets.Enabled = true;
            if (cbSheets.SelectedIndex == -1)
            {
                cbSheets.SelectedIndex = 0;
            }
        }

        private void GenerateSQL(Excel.Worksheet sheet)
        {
            if (null == sheet)
            {
                return;
            }

            string strCreate = "CREATE TABLE";
            string tblName = string.Empty;

            if (radTableNameFromSheetName.Checked)
            {
                tblName = sheet.Name;
            }
            else if (radTableNameFromCell.Checked)
            {
                try
                {
                    Excel.Range tblNameCell = sheet.Range[txtTableNameCellColumn.Text + txtTableNameCellRow.Text];
                    if (null != tblNameCell)
                    {
                        tblName = tblNameCell.Text;
                    }
                }
                catch(Exception ex)
                {
                    Logger.Instance.Write(LogInfo.LogType.ERROR, ex.Message);
                    return;
                }
            }

            string tblComment = string.Empty;
            if (radTableCommentFromText.Checked)
            {
                tblComment = txtTableComment.Text;
            }
            else if (radTableCommentFromCellText.Checked)
            {
                try
                {
                    Excel.Range tblCommentCell = sheet.Range[txtTableCommentColumn.Text + txtTableCommentRow.Text];
                    if (null != tblCommentCell)
                    {
                        tblComment = tblCommentCell.Text;
                    }
                }
                catch (Exception ex)
                {
                    Logger.Instance.Write(LogInfo.LogType.ERROR, ex.Message);
                    return;
                }
            }

            string query = strCreate + " " + tblName + "(\n";

            //Obtain fields
            string fieldCommand = string.Empty;
            int row = int.Parse(txtStartRow.Text);
            Excel.Range fieldNameCell = null;
            Excel.Range fieldTypeCell = null;
            Excel.Range fieldSizeCell = null;
            Excel.Range fieldAttributeCell = null;
            Excel.Range fieldNullableCell = null;
            Excel.Range fieldPrimaryCell = null;
            Excel.Range fieldUniqueCell = null;
            Excel.Range fieldAutoIncreCell = null;
            Excel.Range fieldDefaultValueCell = null;
            Excel.Range fieldRemarkCell = null;

            try
            {
                fieldNameCell = sheet.Range[txtFieldNameColumn.Text + row];
                fieldTypeCell = sheet.Range[txtFieldTypeColumn.Text + row];

                while( (null != fieldNameCell) && (null != fieldTypeCell ) && (null!=fieldNameCell.Text) )
                {
                    fieldCommand = "\n\t'" + fieldNameCell.Text + "' " + fieldTypeCell.Text;
                    //Field size
                    if (chbFieldSize.Checked)
                    {
                        try
                        {
                            fieldSizeCell = sheet.Range[txtFieldTypeColumn.Text + row];
                            if(null != fieldSizeCell)
                            {
                                fieldCommand += "(" + fieldSizeCell.Text + ")";
                            }
                        }
                        catch(Exception ex)
                        {
                            Logger.Instance.Write(LogInfo.LogType.ERROR, ex.Message);
                            return;
                        }
                    }

                    //Field's remark
                    if (chbFieldRemark.Checked)
                    {
                        try
                        {
                            fieldRemarkCell = sheet.Range[txtFieldRemarkColumn.Text + row];
                            if (null != fieldRemarkCell)
                            {
                                fieldCommand += " COMMENT '" + fieldRemarkCell.Text + "'";
                            }
                        }
                        catch (Exception ex)
                        {
                            Logger.Instance.Write(LogInfo.LogType.ERROR, ex.Message);
                            return;
                        }
                    }
                    query += fieldCommand;

                    row++;
                }
            }
            catch(Exception ex)
            {
                Logger.Instance.Write(LogInfo.LogType.ERROR, ex.Message);
                return;
            }


            query += ")";

            if (tblComment.Length > 0)
            {
                query += " COMMENT='" + tblComment + "'";
            }

            query += ";";

            MessageBox.Show(query);
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            Logger.Instance.Reset();

            if (radAllSheets.Checked)
            {
                foreach(Excel.Worksheet sheet in Book.Sheets)
                {
                    GenerateSQL(sheet);
                }
            }
            else if (radCurrentSheet.Checked)
            {
                Excel.Worksheet curSheet = Book.ActiveSheet;
                GenerateSQL(curSheet);
            }
            else
            {
                int selectedSheetIndex = cbSheets.SelectedIndex;
                if (selectedSheetIndex == -1)
                {
                    MessageBox.Show(ResourceString(Constants.MSG_NO_SHEET_SPECIFIED), ResourceString(Constants.STR_WARNING), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbSheets.Focus();
                    return;
                }
                string sheetName = cbSheets.Items[selectedSheetIndex].ToString();
                Excel.Worksheet  selectedSheet = Book.Sheets[sheetName];
                if (null == selectedSheet)
                {
                    MessageBox.Show(ResourceString(Constants.MSG_SHEET_CANNOT_FOUND), ResourceString(Constants.STR_WARNING), MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    cbSheets.Focus();
                    return;
                }

                GenerateSQL(selectedSheet);
            }
        }

        private void cbSheets_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void radTableNameFromSheetName_CheckedChanged(object sender, EventArgs e)
        {
            txtTableNameCellRow.Enabled = false;
            txtTableNameCellColumn.Enabled = false;
        }

        private void radTableNameFromCell_CheckedChanged(object sender, EventArgs e)
        {
            txtTableNameCellRow.Enabled = true;
            txtTableNameCellColumn.Enabled = true;
            txtTableNameCellRow.Focus();
        }
    }
}
