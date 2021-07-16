using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        private readonly SynchronizationContext sychronizationContext;
        private bool cancel_clicked = false;

        public Form1()
        {
            InitializeComponent();
            sychronizationContext = SynchronizationContext.Current;
        }

        private void set_folder_txtbox(System.Windows.Forms.TextBox folder_textbox, string dialog_description)
        {
            // open folder browser and assign value to specified text box

            FolderBrowserDialog folderBrowserDialog1 = new FolderBrowserDialog();

            folderBrowserDialog1.Description = dialog_description;
            folderBrowserDialog1.UseDescriptionForTitle = true;
            folderBrowserDialog1.ShowNewFolderButton = true;
            folderBrowserDialog1.RootFolder = Environment.SpecialFolder.Desktop;

            if (System.IO.Directory.Exists(folder_textbox.Text))
                folderBrowserDialog1.SelectedPath = folder_textbox.Text;

            DialogResult result = folderBrowserDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {                
                folder_textbox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void btn_GetSourceFolder_Click(object sender, EventArgs e)
        {
            // open folder browser and assign value to text box
             set_folder_txtbox (txtbox_Source, "Select directory to copy files from");
        }

        private void btn_GetDestFolder_Click(object sender, EventArgs e)
        {
            // open folder browser and assign value to text box
            set_folder_txtbox(txtbox_Destination, "Select directory to copy files to");
            chkbox_Overwrite.Checked = false;
        }

        private void copy_Files(bool replaceFiles)
        {
            var failures = new List<string>();
            int warnings = 0;
            int success = 0;

            // copy files from list
            foreach (string f in txtbox_FileList.Lines)
            {
                UpdateProgress();

                // stop if exit button was clicked
                if (cancel_clicked)
                    break;

                if (f.Replace(" ", "").Length == 0)
                    continue;

                // Use Path class to manipulate file and directory paths.
                string sourceFile = System.IO.Path.Combine(txtbox_Source.Text, f);
                string destFile = System.IO.Path.Combine(txtbox_Destination.Text, f);

                UpdateTextBox("FROM: \t");
                UpdateTextBox(sourceFile + "\r\n");
                // If source file exists, then continue process
                if (System.IO.File.Exists(sourceFile))
                {
                    UpdateTextBox("TO: \t");
                    UpdateTextBox(destFile + "\r\n");

                    // make sure destination file doesn't already exist. If it does, skip copying unless user selected that they wish to replace existing files
                    bool destFileExists = System.IO.File.Exists(destFile);
                    if (!destFileExists || replaceFiles)
                    {
                        if (destFileExists)
                            UpdateTextBox("INFO: Replacing existing file...");

                        try
                        {
                            // Copy the file
                            System.IO.File.Copy(sourceFile, destFile, replaceFiles);
                            UpdateTextBox("SUCCESS!\r\n", Color.Green);
                            success++;
                        }
                        catch (System.IO.IOException exception)
                        {
                            UpdateTextBox("FAIL!\r\n" + exception.Message + "\r\n", Color.Red);
                            failures.Add("Copy Failed: \r\n\tSource:\t" + sourceFile + "\r\n\tDest: \t" + destFile);
                        }
                    }
                    else
                    {
                        UpdateTextBox("WARNING: File already exists!\r\n", Color.Orange);
                        warnings++;
                    }
                }
                else
                {
                    UpdateTextBox("FAILED: Source file missing!\r\n", Color.Red);
                    failures.Add("Source missing: \t"+ sourceFile);
                }
                UpdateTextBox("------------\r\n");
            }

            if (failures.Count > 0)
            {
                UpdateTextBox("\r\n====== ERROR SUMMARY ======\r\n", Color.Red);
                foreach (var fail in failures)
                {
                    UpdateTextBox(fail+ "\r\n", Color.Red);
                }
            }
            UpdateTextBox("\r\n====== SUMMARY ======\r\n");
            UpdateTextBox(String.Format("Success:\t\t{0}\r\n", success), Color.Green);
            UpdateTextBox(String.Format("Errors: \t\t{0}\r\n", failures.Count), Color.Red);
            UpdateTextBox(String.Format("Warnings:\t{0}\r\n", warnings), Color.Orange);
            UpdateTextBox("------------\r\n");
        }

        public void UpdateTextBox(string value, Color? color = null, bool addNewLine = false)
        {
            
            // allow updating output textbox from a different thread
            sychronizationContext.Post(new SendOrPostCallback(o =>
            {
                txtbox_output.SuspendLayout();
                txtbox_output.SelectionColor = color ?? Color.Black;
                txtbox_output.AppendText(addNewLine
                    ? $"{value}{Environment.NewLine}"
                    : value);
                txtbox_output.ScrollToCaret();
                txtbox_output.ResumeLayout();
            }
            ), value);
        }

        public void UpdateProgress()
        {
            // allow updating progress bar from a different thread
            var i = 0; // not needed, but need a variable passed to Post
            sychronizationContext.Post(new SendOrPostCallback(o =>
            {
                progress_Copy.PerformStep();
            }
            ), i);
        }

        public void AppendOutput(string value, Color? color = null, bool addNewLine = false)
        {
            txtbox_output.SuspendLayout();
            txtbox_output.SelectionColor = color ?? Color.Black;
            txtbox_output.AppendText(addNewLine
                ? $"{value}{Environment.NewLine}"
                : value);
            txtbox_output.ScrollToCaret();
            txtbox_output.ResumeLayout();
        }

        private async void btn_CopyFiles_Click(object sender, EventArgs e)
        {
            int numLines = txtbox_FileList.Lines.Length;
            txtbox_output.Clear();
            cancel_clicked = false;
            bool replaceFiles = chkbox_Overwrite.Checked;

            // Update GUI items to "copy in progress" state
            progress_Copy.Minimum = 0;
            progress_Copy.Maximum = numLines;
            progress_Copy.Value = 0;
            progress_Copy.Step = 1;
            progress_Copy.Visible = true;
            progress_Copy.Enabled = true;

            txtbox_FileList.Enabled = false;
            btn_clearList.Enabled = false;
            btn_CopyFiles.Enabled = false;
            btn_Cancel.Visible = true;
            btn_Cancel.Enabled = true;
            btn_GetDestFolder.Enabled = false;
            btn_GetSourceFolder.Enabled = false;

            // Perform some basic checks and start copying files if appropriate
            AppendOutput("Start: \t" + DateTime.Now.ToString("u") + "\r\n");
            AppendOutput("------------\r\n");
            if ((numLines >= 1) && (txtbox_Source.Text.Length > 0) && (txtbox_Destination.Text.Length > 0))
            {
                {
                    AppendOutput("Running Initial Folder Checks...\r\n");
                    

                    if (System.IO.Directory.Exists(txtbox_Source.Text))
                    {
                        AppendOutput("   [EXISTS]\t", Color.Green);
                    }
                    else
                    {
                        AppendOutput("   [MISSING]\t", Color.Red);
                    }
                    AppendOutput("FROM: \t" + txtbox_Source.Text + "\r\n");


                    if (System.IO.Directory.Exists(txtbox_Destination.Text))
                    {
                        AppendOutput("   [EXISTS]\t", Color.Green);
                    }
                    else
                    {
                        AppendOutput("   [MISSING]\t", Color.Red);
                    }
                    AppendOutput("TO: \t" + txtbox_Destination.Text + "\r\n");

                    
                    if (txtbox_Destination.Text != txtbox_Source.Text)
                    {
                        AppendOutput("   [PASS]\t\t", Color.Green);
                    }
                    else
                    {
                        AppendOutput("   [FAIL]\t\t", Color.Red);
                    }
                    AppendOutput("Source and Destination Different?\r\n");
                }
                
                if (System.IO.Directory.Exists(txtbox_Destination.Text) && System.IO.Directory.Exists(txtbox_Source.Text) && (txtbox_Destination.Text != txtbox_Source.Text))
                {                    
                    AppendOutput("...Continue with copying files...\r\n", Color.Green);
                    AppendOutput("Replace files if exist?");
                    if (chkbox_Overwrite.Checked)
                    {
                        AppendOutput("   [YES] (risky, no prompts)\r\n", Color.Orange);
                    }
                    else
                    {
                        AppendOutput("   [NO] (safer)\r\n", Color.Green);
                    }
                    AppendOutput("------------\r\n");

                    // Launch file copying process in separate thread to prevent blocking GUI function (aka. Allow cancel button functionality)
                    await Task.Run(() => copy_Files(replaceFiles));
                }
                else
                {
                    AppendOutput("...Abort copying files! \r\n", Color.Red);
                    AppendOutput("------------\r\n");
                }

            }
            else
            {
                AppendOutput("ABORTING: \tMissing at least one input value!\r\n", Color.Red);
                AppendOutput("------------\r\n");
            }
            AppendOutput("End: \t"+ DateTime.Now.ToString("u") + "\r\n");

            // Update GUI items to normal state
            progress_Copy.Enabled = false;
            progress_Copy.Visible = false;

            txtbox_FileList.Enabled = true;
            btn_clearList.Enabled = true;
            btn_Cancel.Visible = false;
            btn_Cancel.Enabled = false;
            btn_CopyFiles.Enabled = true;
            btn_GetDestFolder.Enabled = true;
            btn_GetSourceFolder.Enabled = true;
        }

        private void btn_clearList_Click(object sender, EventArgs e)
        {
            // Clear output and file list text boxes
            txtbox_FileList.Clear();
            txtbox_output.Clear();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            // Handle if user clicks cancel button during copy process
            cancel_clicked = true;
            btn_Cancel.Enabled = false;
            AppendOutput("!!! Cancelling after current file completes !!!", Color.Red);
        }
    }
}
