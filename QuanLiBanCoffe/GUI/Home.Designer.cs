namespace QuanLiBanCoffe
{
    partial class Home
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Home));
            this.pb_Logo = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pb_Logo)).BeginInit();
            this.SuspendLayout();
            // 
            // pb_Logo
            // 
            this.pb_Logo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pb_Logo.Image = ((System.Drawing.Image)(resources.GetObject("pb_Logo.Image")));
            this.pb_Logo.Location = new System.Drawing.Point(0, 0);
            this.pb_Logo.Name = "pb_Logo";
            this.pb_Logo.Size = new System.Drawing.Size(852, 530);
            this.pb_Logo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pb_Logo.TabIndex = 1;
            this.pb_Logo.TabStop = false;
            this.pb_Logo.Click += new System.EventHandler(this.pb_Logo_Click);
            // 
            // Home
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pb_Logo);
            this.Name = "Home";
            this.Size = new System.Drawing.Size(852, 530);
            ((System.ComponentModel.ISupportInitialize)(this.pb_Logo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pb_Logo;
    }
}
