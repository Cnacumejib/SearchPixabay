
namespace SearchPixabay
{
    partial class Form1
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
            this.btnSearchImages = new System.Windows.Forms.Button();
            this.txtTags = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.btnSetKey = new System.Windows.Forms.Button();
            this.labelKey = new System.Windows.Forms.Label();
            this.listBoxUrls = new System.Windows.Forms.ListBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearchImages
            // 
            this.btnSearchImages.Location = new System.Drawing.Point(362, 51);
            this.btnSearchImages.Name = "btnSearchImages";
            this.btnSearchImages.Size = new System.Drawing.Size(75, 23);
            this.btnSearchImages.TabIndex = 0;
            this.btnSearchImages.Text = "Найти";
            this.btnSearchImages.UseVisualStyleBackColor = true;
            this.btnSearchImages.Click += new System.EventHandler(this.btnSearchImages_Click);
            // 
            // txtTags
            // 
            this.txtTags.Location = new System.Drawing.Point(21, 53);
            this.txtTags.Multiline = true;
            this.txtTags.Name = "txtTags";
            this.txtTags.Size = new System.Drawing.Size(326, 84);
            this.txtTags.TabIndex = 1;
            this.txtTags.Text = "sea\r\ngirls\r\n3d";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(21, 13);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(326, 20);
            this.textBox3.TabIndex = 3;
            this.textBox3.Text = "19700975-5439f8c319c1140f2fdb338b5";
            // 
            // btnSetKey
            // 
            this.btnSetKey.Location = new System.Drawing.Point(362, 10);
            this.btnSetKey.Name = "btnSetKey";
            this.btnSetKey.Size = new System.Drawing.Size(75, 23);
            this.btnSetKey.TabIndex = 4;
            this.btnSetKey.Text = "Задать";
            this.btnSetKey.UseVisualStyleBackColor = true;
            this.btnSetKey.Click += new System.EventHandler(this.BtnSetKey_Click);
            // 
            // labelKey
            // 
            this.labelKey.Location = new System.Drawing.Point(468, 10);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(310, 23);
            this.labelKey.TabIndex = 5;
            // 
            // listBoxUrls
            // 
            this.listBoxUrls.FormattingEnabled = true;
            this.listBoxUrls.Location = new System.Drawing.Point(471, 53);
            this.listBoxUrls.Name = "listBoxUrls";
            this.listBoxUrls.Size = new System.Drawing.Size(825, 394);
            this.listBoxUrls.TabIndex = 6;
            this.listBoxUrls.Click += new System.EventHandler(this.listBoxUrls_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(22, 168);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(324, 278);
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1329, 649);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.listBoxUrls);
            this.Controls.Add(this.labelKey);
            this.Controls.Add(this.btnSetKey);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.txtTags);
            this.Controls.Add(this.btnSearchImages);
            this.Name = "Form1";
            this.Text = "Test PixaBay";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearchImages;
        private System.Windows.Forms.TextBox txtTags;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.Button btnSetKey;
        private System.Windows.Forms.Label labelKey;
        private System.Windows.Forms.ListBox listBoxUrls;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

