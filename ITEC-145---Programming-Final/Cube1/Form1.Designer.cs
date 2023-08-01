namespace Cube1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.mainTimer = new System.Windows.Forms.Timer(this.components);
            this.hScrollBarX = new System.Windows.Forms.HScrollBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.hScrollBarY = new System.Windows.Forms.HScrollBar();
            this.label3 = new System.Windows.Forms.Label();
            this.hScrollBarZ = new System.Windows.Forms.HScrollBar();
            this.SuspendLayout();
            // 
            // mainTimer
            // 
            this.mainTimer.Enabled = true;
            this.mainTimer.Interval = 1;
            this.mainTimer.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // hScrollBarX
            // 
            this.hScrollBarX.Location = new System.Drawing.Point(66, 5);
            this.hScrollBarX.Maximum = 50;
            this.hScrollBarX.Minimum = -50;
            this.hScrollBarX.Name = "hScrollBarX";
            this.hScrollBarX.Size = new System.Drawing.Size(232, 19);
            this.hScrollBarX.TabIndex = 0;
            this.hScrollBarX.Value = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "X Angle";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(320, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 15);
            this.label2.TabIndex = 3;
            this.label2.Text = "Y Angle";
            // 
            // hScrollBarY
            // 
            this.hScrollBarY.Location = new System.Drawing.Point(373, 9);
            this.hScrollBarY.Maximum = 50;
            this.hScrollBarY.Minimum = -50;
            this.hScrollBarY.Name = "hScrollBarY";
            this.hScrollBarY.Size = new System.Drawing.Size(232, 19);
            this.hScrollBarY.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(632, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Z Angle";
            // 
            // hScrollBarZ
            // 
            this.hScrollBarZ.Location = new System.Drawing.Point(685, 9);
            this.hScrollBarZ.Maximum = 50;
            this.hScrollBarZ.Minimum = -50;
            this.hScrollBarZ.Name = "hScrollBarZ";
            this.hScrollBarZ.Size = new System.Drawing.Size(232, 19);
            this.hScrollBarZ.TabIndex = 4;
            this.hScrollBarZ.Value = -8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(979, 681);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.hScrollBarZ);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.hScrollBarY);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.hScrollBarX);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "3D Pong";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer mainTimer;
        private HScrollBar hScrollBarX;
        private Label label1;
        private Label label2;
        private HScrollBar hScrollBarY;
        private Label label3;
        private HScrollBar hScrollBarZ;
    }
}