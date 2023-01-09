namespace _3_29_ParallelForForEachCancellationTokenApp {
    partial class Form1 {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            this.btnGetir = new System.Windows.Forms.Button();
            this.btnArtir = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnIptal = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnGetir
            // 
            this.btnGetir.Location = new System.Drawing.Point(88, 43);
            this.btnGetir.Name = "btnGetir";
            this.btnGetir.Size = new System.Drawing.Size(94, 29);
            this.btnGetir.TabIndex = 0;
            this.btnGetir.Text = "Getir";
            this.btnGetir.UseVisualStyleBackColor = true;
            this.btnGetir.Click += new System.EventHandler(this.btnGetir_Click);
            // 
            // btnArtir
            // 
            this.btnArtir.Location = new System.Drawing.Point(285, 43);
            this.btnArtir.Name = "btnArtir";
            this.btnArtir.Size = new System.Drawing.Size(94, 29);
            this.btnArtir.TabIndex = 1;
            this.btnArtir.Text = "Artır";
            this.btnArtir.UseVisualStyleBackColor = true;
            this.btnArtir.Click += new System.EventHandler(this.btnArtir_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(88, 111);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(487, 344);
            this.listBox1.TabIndex = 2;
            // 
            // btnIptal
            // 
            this.btnIptal.Location = new System.Drawing.Point(481, 43);
            this.btnIptal.Name = "btnIptal";
            this.btnIptal.Size = new System.Drawing.Size(94, 29);
            this.btnIptal.TabIndex = 3;
            this.btnIptal.Text = "İptal";
            this.btnIptal.UseVisualStyleBackColor = true;
            this.btnIptal.Click += new System.EventHandler(this.btnIptal_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 503);
            this.Controls.Add(this.btnIptal);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.btnArtir);
            this.Controls.Add(this.btnGetir);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnGetir;
        private System.Windows.Forms.Button btnArtir;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnIptal;
    }
}
