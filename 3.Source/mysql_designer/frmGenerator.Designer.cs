namespace mysql_designer
{
    partial class frmGenerator
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.grbApplyTo = new System.Windows.Forms.GroupBox();
            this.radAllSheets = new System.Windows.Forms.RadioButton();
            this.radCurrentSheet = new System.Windows.Forms.RadioButton();
            this.radSpecifiedSheet = new System.Windows.Forms.RadioButton();
            this.cbSheets = new System.Windows.Forms.ComboBox();
            this.grbSettings = new System.Windows.Forms.GroupBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.grbApplyTo.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbApplyTo
            // 
            this.grbApplyTo.Controls.Add(this.radSpecifiedSheet);
            this.grbApplyTo.Controls.Add(this.radCurrentSheet);
            this.grbApplyTo.Controls.Add(this.radAllSheets);
            this.grbApplyTo.Location = new System.Drawing.Point(12, 12);
            this.grbApplyTo.Name = "grbApplyTo";
            this.grbApplyTo.Size = new System.Drawing.Size(308, 43);
            this.grbApplyTo.TabIndex = 0;
            this.grbApplyTo.TabStop = false;
            this.grbApplyTo.Text = "Apply To";
            // 
            // radAllSheets
            // 
            this.radAllSheets.AutoSize = true;
            this.radAllSheets.Checked = true;
            this.radAllSheets.Location = new System.Drawing.Point(29, 21);
            this.radAllSheets.Name = "radAllSheets";
            this.radAllSheets.Size = new System.Drawing.Size(70, 17);
            this.radAllSheets.TabIndex = 0;
            this.radAllSheets.TabStop = true;
            this.radAllSheets.Text = "All sheets";
            this.radAllSheets.UseVisualStyleBackColor = true;
            this.radAllSheets.CheckedChanged += new System.EventHandler(this.radAllSheets_CheckedChanged);
            // 
            // radCurrentSheet
            // 
            this.radCurrentSheet.AutoSize = true;
            this.radCurrentSheet.Location = new System.Drawing.Point(111, 21);
            this.radCurrentSheet.Name = "radCurrentSheet";
            this.radCurrentSheet.Size = new System.Drawing.Size(88, 17);
            this.radCurrentSheet.TabIndex = 0;
            this.radCurrentSheet.Text = "Current sheet";
            this.radCurrentSheet.UseVisualStyleBackColor = true;
            this.radCurrentSheet.CheckedChanged += new System.EventHandler(this.radCurrentSheet_CheckedChanged);
            // 
            // radSpecifiedSheet
            // 
            this.radSpecifiedSheet.AutoSize = true;
            this.radSpecifiedSheet.Location = new System.Drawing.Point(208, 21);
            this.radSpecifiedSheet.Name = "radSpecifiedSheet";
            this.radSpecifiedSheet.Size = new System.Drawing.Size(98, 17);
            this.radSpecifiedSheet.TabIndex = 0;
            this.radSpecifiedSheet.Text = "Specified sheet";
            this.radSpecifiedSheet.UseVisualStyleBackColor = true;
            this.radSpecifiedSheet.CheckedChanged += new System.EventHandler(this.radSpecifiedSheet_CheckedChanged);
            // 
            // cbSheets
            // 
            this.cbSheets.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSheets.FormattingEnabled = true;
            this.cbSheets.Location = new System.Drawing.Point(326, 32);
            this.cbSheets.Name = "cbSheets";
            this.cbSheets.Size = new System.Drawing.Size(241, 21);
            this.cbSheets.TabIndex = 1;
            this.cbSheets.SelectedIndexChanged += new System.EventHandler(this.cbSheets_SelectedIndexChanged);
            // 
            // grbSettings
            // 
            this.grbSettings.Location = new System.Drawing.Point(12, 71);
            this.grbSettings.Name = "grbSettings";
            this.grbSettings.Size = new System.Drawing.Size(555, 280);
            this.grbSettings.TabIndex = 2;
            this.grbSettings.TabStop = false;
            this.grbSettings.Text = "Settings";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(250, 355);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 25);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // frmGenerator
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(575, 384);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.grbSettings);
            this.Controls.Add(this.cbSheets);
            this.Controls.Add(this.grbApplyTo);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmGenerator";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmGenerator_FormClosing);
            this.Load += new System.EventHandler(this.frmGenerator_Load);
            this.grbApplyTo.ResumeLayout(false);
            this.grbApplyTo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbApplyTo;
        private System.Windows.Forms.RadioButton radAllSheets;
        private System.Windows.Forms.RadioButton radSpecifiedSheet;
        private System.Windows.Forms.RadioButton radCurrentSheet;
        private System.Windows.Forms.ComboBox cbSheets;
        private System.Windows.Forms.GroupBox grbSettings;
        private System.Windows.Forms.Button btnGenerate;
    }
}