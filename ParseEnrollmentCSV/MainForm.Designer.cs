namespace ParseEnrollmentCSV
{
    partial class MainForm
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
            this.button1 = new System.Windows.Forms.Button();
            this.lblCsvFilePath = new System.Windows.Forms.Label();
            this.txtCsvFilePath = new System.Windows.Forms.TextBox();
            this.btnFileSearch = new System.Windows.Forms.Button();
            this.gvResults = new System.Windows.Forms.DataGridView();
            this.lblGvResults = new System.Windows.Forms.Label();
            this.btnUpload = new System.Windows.Forms.Button();
            this.btnParse = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(448, 689);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // lblCsvFilePath
            // 
            this.lblCsvFilePath.AutoSize = true;
            this.lblCsvFilePath.Location = new System.Drawing.Point(12, 9);
            this.lblCsvFilePath.Name = "lblCsvFilePath";
            this.lblCsvFilePath.Size = new System.Drawing.Size(72, 13);
            this.lblCsvFilePath.TabIndex = 1;
            this.lblCsvFilePath.Text = "CSV Location";
            // 
            // txtCsvFilePath
            // 
            this.txtCsvFilePath.Location = new System.Drawing.Point(15, 25);
            this.txtCsvFilePath.Name = "txtCsvFilePath";
            this.txtCsvFilePath.Size = new System.Drawing.Size(309, 20);
            this.txtCsvFilePath.TabIndex = 2;
            // 
            // btnFileSearch
            // 
            this.btnFileSearch.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.btnFileSearch.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFileSearch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnFileSearch.Location = new System.Drawing.Point(323, 25);
            this.btnFileSearch.Name = "btnFileSearch";
            this.btnFileSearch.Size = new System.Drawing.Size(25, 20);
            this.btnFileSearch.TabIndex = 3;
            this.btnFileSearch.Text = "...";
            this.btnFileSearch.UseVisualStyleBackColor = true;
            this.btnFileSearch.Click += new System.EventHandler(this.btnFileSearch_Click);
            // 
            // gvResults
            // 
            this.gvResults.AllowUserToOrderColumns = true;
            this.gvResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gvResults.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvResults.Location = new System.Drawing.Point(13, 122);
            this.gvResults.Name = "gvResults";
            this.gvResults.Size = new System.Drawing.Size(1239, 547);
            this.gvResults.TabIndex = 4;
            // 
            // lblGvResults
            // 
            this.lblGvResults.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.lblGvResults.AutoSize = true;
            this.lblGvResults.Location = new System.Drawing.Point(10, 106);
            this.lblGvResults.Name = "lblGvResults";
            this.lblGvResults.Size = new System.Drawing.Size(73, 13);
            this.lblGvResults.TabIndex = 5;
            this.lblGvResults.Text = "CSV Contents";
            // 
            // btnUpload
            // 
            this.btnUpload.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUpload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUpload.Location = new System.Drawing.Point(183, 51);
            this.btnUpload.Name = "btnUpload";
            this.btnUpload.Size = new System.Drawing.Size(141, 33);
            this.btnUpload.TabIndex = 6;
            this.btnUpload.Text = "Upload Results";
            this.btnUpload.UseVisualStyleBackColor = true;
            // 
            // btnParse
            // 
            this.btnParse.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnParse.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnParse.Location = new System.Drawing.Point(15, 51);
            this.btnParse.Name = "btnParse";
            this.btnParse.Size = new System.Drawing.Size(141, 33);
            this.btnParse.TabIndex = 7;
            this.btnParse.Text = "Parse CSV";
            this.btnParse.UseVisualStyleBackColor = true;
            this.btnParse.Click += new System.EventHandler(this.btnParse_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.Controls.Add(this.btnParse);
            this.Controls.Add(this.btnUpload);
            this.Controls.Add(this.lblGvResults);
            this.Controls.Add(this.gvResults);
            this.Controls.Add(this.btnFileSearch);
            this.Controls.Add(this.txtCsvFilePath);
            this.Controls.Add(this.lblCsvFilePath);
            this.Controls.Add(this.button1);
            this.Name = "MainForm";
            this.Text = "Availity Enrollment CSV Parser";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvResults)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label lblCsvFilePath;
        private System.Windows.Forms.TextBox txtCsvFilePath;
        private System.Windows.Forms.Button btnFileSearch;
        private System.Windows.Forms.DataGridView gvResults;
        private System.Windows.Forms.Label lblGvResults;
        private System.Windows.Forms.Button btnUpload;
        private System.Windows.Forms.Button btnParse;
    }
}

