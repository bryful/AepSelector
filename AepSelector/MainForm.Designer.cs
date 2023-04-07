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
			aeIconPanel1 = new AEIconPanel();
			SuspendLayout();
			// 
			// aeIconPanel1
			// 
			aeIconPanel1.AepPath = "";
			aeIconPanel1.AfterFXPath = "";
			aeIconPanel1.BackColor = Color.Transparent;
			aeIconPanel1.ForeColor = Color.FromArgb(200, 200, 255);
			aeIconPanel1.Location = new Point(8, 24);
			aeIconPanel1.MinimumSize = new Size(320, 64);
			aeIconPanel1.Name = "aeIconPanel1";
			aeIconPanel1.Size = new Size(320, 64);
			aeIconPanel1.TabIndex = 0;
			aeIconPanel1.TargetIndex = -1;
			aeIconPanel1.Text = "aeIconPanel1";
			// 
			// MainForm
			// 
			AEIconPanel = aeIconPanel1;
			AutoScaleDimensions = new SizeF(9F, 21F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(336, 88);
			Controls.Add(aeIconPanel1);
			Name = "MainForm";
			StartPosition = FormStartPosition.Manual;
			Text = "MainForm";
			ResumeLayout(false);
		}

		#endregion

		private AEIconPanel aeIconPanel1;
	}
}