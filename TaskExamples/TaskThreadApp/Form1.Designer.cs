namespace TaskThreadApp {
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
            this.btnStart = new System.Windows.Forms.Button();
            this.btnCounter = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(60, 40);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(114, 38);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "Başlat";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnCounter
            // 
            this.btnCounter.Location = new System.Drawing.Point(260, 40);
            this.btnCounter.Name = "btnCounter";
            this.btnCounter.Size = new System.Drawing.Size(114, 38);
            this.btnCounter.TabIndex = 1;
            this.btnCounter.Text = "Sayaç";
            this.btnCounter.UseVisualStyleBackColor = true;
            this.btnCounter.Click += new System.EventHandler(this.btnCounter_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(60, 143);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(897, 29);
            this.progressBar1.TabIndex = 2;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(60, 243);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(897, 29);
            this.progressBar2.TabIndex = 3;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(60, 110);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(161, 27);
            this.textBox1.TabIndex = 4;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(60, 210);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(161, 27);
            this.textBox2.TabIndex = 5;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 479);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.progressBar2);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnCounter);
            this.Controls.Add(this.btnStart);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button btnStart;
        private Button btnCounter;
        private ProgressBar progressBar1;
        private ProgressBar progressBar2;
        private TextBox textBox1;
        private TextBox textBox2;
    }
}