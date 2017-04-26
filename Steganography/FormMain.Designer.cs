namespace NET
{
    partial class FormMain
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
            this.OpenFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.ButtonOpenFile = new System.Windows.Forms.Button();
            this.GroupBoxText = new System.Windows.Forms.GroupBox();
            this.TextBoxMsg = new System.Windows.Forms.TextBox();
            this.RadioButtonEncode = new System.Windows.Forms.RadioButton();
            this.RadioButtonDecode = new System.Windows.Forms.RadioButton();
            this.ButtonProcess = new System.Windows.Forms.Button();
            this.GroupBoxText.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenFileDialog
            // 
            this.OpenFileDialog.FileName = "OpenFileDialog";
            // 
            // ButtonOpenFile
            // 
            this.ButtonOpenFile.Location = new System.Drawing.Point(12, 154);
            this.ButtonOpenFile.Name = "ButtonOpenFile";
            this.ButtonOpenFile.Size = new System.Drawing.Size(167, 43);
            this.ButtonOpenFile.TabIndex = 0;
            this.ButtonOpenFile.Text = "Открыть файл";
            this.ButtonOpenFile.UseVisualStyleBackColor = true;
            this.ButtonOpenFile.Click += new System.EventHandler(this.ButtonOpenFile_Click);
            // 
            // GroupBoxText
            // 
            this.GroupBoxText.Controls.Add(this.TextBoxMsg);
            this.GroupBoxText.Location = new System.Drawing.Point(12, 12);
            this.GroupBoxText.Name = "GroupBoxText";
            this.GroupBoxText.Size = new System.Drawing.Size(351, 113);
            this.GroupBoxText.TabIndex = 5;
            this.GroupBoxText.TabStop = false;
            this.GroupBoxText.Text = "Текст для шифрования";
            // 
            // TextBoxMsg
            // 
            this.TextBoxMsg.Location = new System.Drawing.Point(18, 24);
            this.TextBoxMsg.Multiline = true;
            this.TextBoxMsg.Name = "TextBoxMsg";
            this.TextBoxMsg.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.TextBoxMsg.Size = new System.Drawing.Size(314, 87);
            this.TextBoxMsg.TabIndex = 0;
            // 
            // RadioButtonEncode
            // 
            this.RadioButtonEncode.AutoSize = true;
            this.RadioButtonEncode.Checked = true;
            this.RadioButtonEncode.Location = new System.Drawing.Point(12, 131);
            this.RadioButtonEncode.Name = "RadioButtonEncode";
            this.RadioButtonEncode.Size = new System.Drawing.Size(143, 17);
            this.RadioButtonEncode.TabIndex = 6;
            this.RadioButtonEncode.TabStop = true;
            this.RadioButtonEncode.Text = "Будем зашифровывать";
            this.RadioButtonEncode.UseVisualStyleBackColor = true;
            this.RadioButtonEncode.CheckedChanged += new System.EventHandler(this.RadioButtonEncode_CheckedChanged);
            // 
            // RadioButtonDecode
            // 
            this.RadioButtonDecode.AutoSize = true;
            this.RadioButtonDecode.Location = new System.Drawing.Point(208, 129);
            this.RadioButtonDecode.Name = "RadioButtonDecode";
            this.RadioButtonDecode.Size = new System.Drawing.Size(149, 17);
            this.RadioButtonDecode.TabIndex = 7;
            this.RadioButtonDecode.Text = "Будем расшифровывать";
            this.RadioButtonDecode.UseVisualStyleBackColor = true;
            // 
            // ButtonProcess
            // 
            this.ButtonProcess.Location = new System.Drawing.Point(185, 154);
            this.ButtonProcess.Name = "ButtonProcess";
            this.ButtonProcess.Size = new System.Drawing.Size(172, 43);
            this.ButtonProcess.TabIndex = 9;
            this.ButtonProcess.Text = "Зашифровать";
            this.ButtonProcess.UseVisualStyleBackColor = true;
            this.ButtonProcess.Click += new System.EventHandler(this.ButtonProcess_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(387, 210);
            this.Controls.Add(this.ButtonProcess);
            this.Controls.Add(this.RadioButtonDecode);
            this.Controls.Add(this.RadioButtonEncode);
            this.Controls.Add(this.GroupBoxText);
            this.Controls.Add(this.ButtonOpenFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Стеганография";
            this.GroupBoxText.ResumeLayout(false);
            this.GroupBoxText.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog OpenFileDialog;
        private System.Windows.Forms.Button ButtonOpenFile;
        private System.Windows.Forms.GroupBox GroupBoxText;
        private System.Windows.Forms.TextBox TextBoxMsg;
        private System.Windows.Forms.RadioButton RadioButtonEncode;
        private System.Windows.Forms.RadioButton RadioButtonDecode;
        private System.Windows.Forms.Button ButtonProcess;
    }
}

