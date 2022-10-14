namespace AepSelector
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
			this.aeIconPanel1 = new AepSelector.AEIconPanel();
			this.SuspendLayout();
			// 
			// aeIconPanel1
			// 
			this.aeIconPanel1.AepPath = "";
			this.aeIconPanel1.AfterFXPath = "";
			this.aeIconPanel1.BackColor = System.Drawing.Color.Transparent;
			this.aeIconPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
			this.aeIconPanel1.Location = new System.Drawing.Point(8, 24);
			this.aeIconPanel1.Name = "aeIconPanel1";
			this.aeIconPanel1.Size = new System.Drawing.Size(349, 64);
			this.aeIconPanel1.TabIndex = 0;
			this.aeIconPanel1.TargetIndex = -1;
			this.aeIconPanel1.Text = "aeIconPanel1";
			// 
			// MainForm
			// 
			this.AEIconPanel = this.aeIconPanel1;
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(384, 88);
			this.Controls.Add(this.aeIconPanel1);
			this.Name = "MainForm";
			this.Text = "MainForm";
			this.ResumeLayout(false);

		}

		#endregion

		private AEIconPanel aeIconPanel1;
	}
}