namespace Sara
{
    partial class fmPrincipal
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
            this.pbMic = new System.Windows.Forms.ProgressBar();
            this.lblFala = new System.Windows.Forms.Label();
            this.lblFalaSara = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // pbMic
            // 
            this.pbMic.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.pbMic.Location = new System.Drawing.Point(102, 12);
            this.pbMic.Name = "pbMic";
            this.pbMic.Size = new System.Drawing.Size(53, 23);
            this.pbMic.TabIndex = 0;
            // 
            // lblFala
            // 
            this.lblFala.AutoSize = true;
            this.lblFala.Location = new System.Drawing.Point(12, 60);
            this.lblFala.Name = "lblFala";
            this.lblFala.Size = new System.Drawing.Size(71, 13);
            this.lblFala.TabIndex = 1;
            this.lblFala.Text = "Reconhecido";
            // 
            // lblFalaSara
            // 
            this.lblFalaSara.AutoSize = true;
            this.lblFalaSara.Location = new System.Drawing.Point(12, 82);
            this.lblFalaSara.Name = "lblFalaSara";
            this.lblFalaSara.Size = new System.Drawing.Size(29, 13);
            this.lblFalaSara.TabIndex = 2;
            this.lblFalaSara.Text = "Sara";
            // 
            // fmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.lblFalaSara);
            this.Controls.Add(this.lblFala);
            this.Controls.Add(this.pbMic);
            this.Name = "fmPrincipal";
            this.Text = "SARA";
            this.Load += new System.EventHandler(this.SARA_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar pbMic;
        private System.Windows.Forms.Label lblFala;
        private System.Windows.Forms.Label lblFalaSara;
    }
}

