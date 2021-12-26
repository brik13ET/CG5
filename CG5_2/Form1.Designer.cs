namespace CG5_2
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
			this.pictureBox1 = new System.Windows.Forms.PictureBox();
			this.splitContainer1 = new System.Windows.Forms.SplitContainer();
			this.label4 = new System.Windows.Forms.Label();
			this.trackBar4 = new System.Windows.Forms.TrackBar();
			this.label3 = new System.Windows.Forms.Label();
			this.trackBar3 = new System.Windows.Forms.TrackBar();
			this.label2 = new System.Windows.Forms.Label();
			this.label1 = new System.Windows.Forms.Label();
			this.trackBar2 = new System.Windows.Forms.TrackBar();
			this.trackBar1 = new System.Windows.Forms.TrackBar();
			this.label5 = new System.Windows.Forms.Label();
			this.trackBar5 = new System.Windows.Forms.TrackBar();
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
			this.splitContainer1.Panel1.SuspendLayout();
			this.splitContainer1.Panel2.SuspendLayout();
			this.splitContainer1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.trackBar4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar5)).BeginInit();
			this.SuspendLayout();
			// 
			// pictureBox1
			// 
			this.pictureBox1.BackColor = System.Drawing.Color.Black;
			this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.pictureBox1.Location = new System.Drawing.Point(0, 0);
			this.pictureBox1.Name = "pictureBox1";
			this.pictureBox1.Size = new System.Drawing.Size(782, 407);
			this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
			this.pictureBox1.TabIndex = 0;
			this.pictureBox1.TabStop = false;
			this.pictureBox1.SizeChanged += new System.EventHandler(this.pictureBox1_Resize);
			this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
			this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
			this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
			this.pictureBox1.Resize += new System.EventHandler(this.pictureBox1_Resize);
			// 
			// splitContainer1
			// 
			this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainer1.Location = new System.Drawing.Point(0, 0);
			this.splitContainer1.Name = "splitContainer1";
			// 
			// splitContainer1.Panel1
			// 
			this.splitContainer1.Panel1.Controls.Add(this.label5);
			this.splitContainer1.Panel1.Controls.Add(this.trackBar5);
			this.splitContainer1.Panel1.Controls.Add(this.label4);
			this.splitContainer1.Panel1.Controls.Add(this.trackBar4);
			this.splitContainer1.Panel1.Controls.Add(this.label3);
			this.splitContainer1.Panel1.Controls.Add(this.trackBar3);
			this.splitContainer1.Panel1.Controls.Add(this.label2);
			this.splitContainer1.Panel1.Controls.Add(this.label1);
			this.splitContainer1.Panel1.Controls.Add(this.trackBar2);
			this.splitContainer1.Panel1.Controls.Add(this.trackBar1);
			// 
			// splitContainer1.Panel2
			// 
			this.splitContainer1.Panel2.Controls.Add(this.pictureBox1);
			this.splitContainer1.Size = new System.Drawing.Size(976, 407);
			this.splitContainer1.SplitterDistance = 190;
			this.splitContainer1.TabIndex = 1;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(12, 175);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(31, 13);
			this.label4.TabIndex = 10;
			this.label4.Text = "RotZ";
			// 
			// trackBar4
			// 
			this.trackBar4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar4.Location = new System.Drawing.Point(3, 191);
			this.trackBar4.Maximum = 180;
			this.trackBar4.Minimum = 1;
			this.trackBar4.Name = "trackBar4";
			this.trackBar4.Size = new System.Drawing.Size(180, 45);
			this.trackBar4.TabIndex = 9;
			this.trackBar4.Value = 1;
			this.trackBar4.Scroll += new System.EventHandler(this.trackBar4_Scroll);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 124);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(31, 13);
			this.label3.TabIndex = 8;
			this.label3.Text = "RotX";
			// 
			// trackBar3
			// 
			this.trackBar3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar3.Location = new System.Drawing.Point(3, 140);
			this.trackBar3.Maximum = 180;
			this.trackBar3.Minimum = 1;
			this.trackBar3.Name = "trackBar3";
			this.trackBar3.Size = new System.Drawing.Size(180, 45);
			this.trackBar3.TabIndex = 7;
			this.trackBar3.Value = 1;
			this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 73);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(34, 13);
			this.label2.TabIndex = 6;
			this.label2.Text = "Scale";
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(40, 13);
			this.label1.TabIndex = 5;
			this.label1.Text = "Radius";
			// 
			// trackBar2
			// 
			this.trackBar2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar2.Location = new System.Drawing.Point(3, 89);
			this.trackBar2.Maximum = 40;
			this.trackBar2.Minimum = 1;
			this.trackBar2.Name = "trackBar2";
			this.trackBar2.Size = new System.Drawing.Size(180, 45);
			this.trackBar2.TabIndex = 4;
			this.trackBar2.Value = 1;
			this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
			// 
			// trackBar1
			// 
			this.trackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar1.Location = new System.Drawing.Point(3, 25);
			this.trackBar1.Maximum = 64;
			this.trackBar1.Minimum = 1;
			this.trackBar1.Name = "trackBar1";
			this.trackBar1.Size = new System.Drawing.Size(180, 45);
			this.trackBar1.TabIndex = 3;
			this.trackBar1.Value = 1;
			this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(12, 226);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(22, 13);
			this.label5.TabIndex = 12;
			this.label5.Text = "DX";
			// 
			// trackBar5
			// 
			this.trackBar5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.trackBar5.Location = new System.Drawing.Point(3, 242);
			this.trackBar5.Maximum = 180;
			this.trackBar5.Minimum = 1;
			this.trackBar5.Name = "trackBar5";
			this.trackBar5.Size = new System.Drawing.Size(180, 45);
			this.trackBar5.TabIndex = 11;
			this.trackBar5.Value = 1;
			this.trackBar5.Scroll += new System.EventHandler(this.trackBar5_Scroll);
			// 
			// Form1
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(976, 407);
			this.Controls.Add(this.splitContainer1);
			this.Name = "Form1";
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
			this.splitContainer1.Panel1.ResumeLayout(false);
			this.splitContainer1.Panel1.PerformLayout();
			this.splitContainer1.Panel2.ResumeLayout(false);
			this.splitContainer1.Panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
			this.splitContainer1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.trackBar4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.trackBar5)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.SplitContainer splitContainer1;
		private System.Windows.Forms.TrackBar trackBar1;
		private System.Windows.Forms.TrackBar trackBar2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TrackBar trackBar4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TrackBar trackBar3;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TrackBar trackBar5;
	}
}

