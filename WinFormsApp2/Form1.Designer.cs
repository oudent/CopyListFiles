
using System;

namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_GetSourceFolder = new System.Windows.Forms.Button();
            this.txtbox_Source = new System.Windows.Forms.TextBox();
            this.btn_GetDestFolder = new System.Windows.Forms.Button();
            this.txtbox_Destination = new System.Windows.Forms.TextBox();
            this.label_FileList = new System.Windows.Forms.Label();
            this.txtbox_FileList = new System.Windows.Forms.TextBox();
            this.btn_CopyFiles = new System.Windows.Forms.Button();
            this.btn_clearList = new System.Windows.Forms.Button();
            this.progress_Copy = new System.Windows.Forms.ProgressBar();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.chkbox_Overwrite = new System.Windows.Forms.CheckBox();
            this.txtbox_output = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // btn_GetSourceFolder
            // 
            this.btn_GetSourceFolder.Location = new System.Drawing.Point(35, 22);
            this.btn_GetSourceFolder.Name = "btn_GetSourceFolder";
            this.btn_GetSourceFolder.Size = new System.Drawing.Size(75, 23);
            this.btn_GetSourceFolder.TabIndex = 0;
            this.btn_GetSourceFolder.Text = "From:";
            this.btn_GetSourceFolder.UseVisualStyleBackColor = true;
            this.btn_GetSourceFolder.Click += new System.EventHandler(this.btn_GetSourceFolder_Click);
            // 
            // txtbox_Source
            // 
            this.txtbox_Source.Location = new System.Drawing.Point(35, 51);
            this.txtbox_Source.Name = "txtbox_Source";
            this.txtbox_Source.Size = new System.Drawing.Size(715, 23);
            this.txtbox_Source.TabIndex = 1;
            // 
            // btn_GetDestFolder
            // 
            this.btn_GetDestFolder.Location = new System.Drawing.Point(35, 95);
            this.btn_GetDestFolder.Name = "btn_GetDestFolder";
            this.btn_GetDestFolder.Size = new System.Drawing.Size(75, 23);
            this.btn_GetDestFolder.TabIndex = 2;
            this.btn_GetDestFolder.Text = "To:";
            this.btn_GetDestFolder.UseVisualStyleBackColor = true;
            this.btn_GetDestFolder.Click += new System.EventHandler(this.btn_GetDestFolder_Click);
            // 
            // txtbox_Destination
            // 
            this.txtbox_Destination.Location = new System.Drawing.Point(35, 124);
            this.txtbox_Destination.Name = "txtbox_Destination";
            this.txtbox_Destination.Size = new System.Drawing.Size(715, 23);
            this.txtbox_Destination.TabIndex = 3;
            // 
            // label_FileList
            // 
            this.label_FileList.AutoSize = true;
            this.label_FileList.Location = new System.Drawing.Point(35, 168);
            this.label_FileList.Name = "label_FileList";
            this.label_FileList.Size = new System.Drawing.Size(149, 15);
            this.label_FileList.TabIndex = 4;
            this.label_FileList.Text = "Files to copy (one per line):";
            // 
            // txtbox_FileList
            // 
            this.txtbox_FileList.AllowDrop = true;
            this.txtbox_FileList.Location = new System.Drawing.Point(35, 187);
            this.txtbox_FileList.Multiline = true;
            this.txtbox_FileList.Name = "txtbox_FileList";
            this.txtbox_FileList.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtbox_FileList.Size = new System.Drawing.Size(264, 219);
            this.txtbox_FileList.TabIndex = 5;
            this.txtbox_FileList.WordWrap = false;
            // 
            // btn_CopyFiles
            // 
            this.btn_CopyFiles.Location = new System.Drawing.Point(35, 413);
            this.btn_CopyFiles.Name = "btn_CopyFiles";
            this.btn_CopyFiles.Size = new System.Drawing.Size(715, 23);
            this.btn_CopyFiles.TabIndex = 6;
            this.btn_CopyFiles.Text = "Copy Files";
            this.btn_CopyFiles.UseVisualStyleBackColor = true;
            this.btn_CopyFiles.Click += new System.EventHandler(this.btn_CopyFiles_Click);
            // 
            // btn_clearList
            // 
            this.btn_clearList.Location = new System.Drawing.Point(224, 158);
            this.btn_clearList.Name = "btn_clearList";
            this.btn_clearList.Size = new System.Drawing.Size(75, 23);
            this.btn_clearList.TabIndex = 8;
            this.btn_clearList.Text = "Clear List";
            this.btn_clearList.UseVisualStyleBackColor = true;
            this.btn_clearList.Click += new System.EventHandler(this.btn_clearList_Click);
            // 
            // progress_Copy
            // 
            this.progress_Copy.Enabled = false;
            this.progress_Copy.Location = new System.Drawing.Point(359, 158);
            this.progress_Copy.Name = "progress_Copy";
            this.progress_Copy.Size = new System.Drawing.Size(391, 24);
            this.progress_Copy.Step = 1;
            this.progress_Copy.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progress_Copy.TabIndex = 9;
            this.progress_Copy.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(305, 166);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "Output:";
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(35, 413);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(715, 23);
            this.btn_Cancel.TabIndex = 12;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Visible = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // chkbox_Overwrite
            // 
            this.chkbox_Overwrite.AutoSize = true;
            this.chkbox_Overwrite.Location = new System.Drawing.Point(417, 99);
            this.chkbox_Overwrite.Name = "chkbox_Overwrite";
            this.chkbox_Overwrite.Size = new System.Drawing.Size(333, 19);
            this.chkbox_Overwrite.TabIndex = 13;
            this.chkbox_Overwrite.Text = "Replace files in destination if they exist? (No notifications!)";
            this.chkbox_Overwrite.UseVisualStyleBackColor = true;
            // 
            // txtbox_output
            // 
            this.txtbox_output.Location = new System.Drawing.Point(305, 187);
            this.txtbox_output.Name = "txtbox_output";
            this.txtbox_output.ReadOnly = true;
            this.txtbox_output.Size = new System.Drawing.Size(445, 220);
            this.txtbox_output.TabIndex = 14;
            this.txtbox_output.Text = "";
            this.txtbox_output.WordWrap = false;
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 461);
            this.Controls.Add(this.txtbox_output);
            this.Controls.Add(this.chkbox_Overwrite);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.progress_Copy);
            this.Controls.Add(this.btn_clearList);
            this.Controls.Add(this.btn_CopyFiles);
            this.Controls.Add(this.txtbox_FileList);
            this.Controls.Add(this.label_FileList);
            this.Controls.Add(this.txtbox_Destination);
            this.Controls.Add(this.btn_GetDestFolder);
            this.Controls.Add(this.txtbox_Source);
            this.Controls.Add(this.btn_GetSourceFolder);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(800, 500);
            this.MinimumSize = new System.Drawing.Size(800, 500);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Copy List of Files";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_GetSourceFolder;
        private System.Windows.Forms.TextBox txtbox_Source;
        private System.Windows.Forms.Button btn_GetDestFolder;
        private System.Windows.Forms.TextBox txtbox_Destination;
        private System.Windows.Forms.Label label_FileList;
        private System.Windows.Forms.TextBox txtbox_FileList;
        private System.Windows.Forms.Button btn_CopyFiles;
        private System.Windows.Forms.Button btn_clearList;
        private System.Windows.Forms.ProgressBar progress_Copy;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.CheckBox chkbox_Overwrite;
        private System.Windows.Forms.RichTextBox txtbox_output;
    }
}

