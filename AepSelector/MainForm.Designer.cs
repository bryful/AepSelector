namespace AepSelector
{
	partial class MainForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.aeIconPanel1 = new AepSelector.AEIconPanel();
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoQuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// aeIconPanel1
			// 
			this.aeIconPanel1.AepPath = "";
			this.aeIconPanel1.AfterFXPath = "";
			this.aeIconPanel1.BackColor = System.Drawing.Color.Transparent;
			this.aeIconPanel1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
			this.aeIconPanel1.Location = new System.Drawing.Point(12, 19);
			this.aeIconPanel1.MaximumSize = new System.Drawing.Size(320, 64);
			this.aeIconPanel1.MinimumSize = new System.Drawing.Size(320, 64);
			this.aeIconPanel1.Name = "aeIconPanel1";
			this.aeIconPanel1.Size = new System.Drawing.Size(320, 64);
			this.aeIconPanel1.TabIndex = 0;
			this.aeIconPanel1.TargetIndex = -1;
			this.aeIconPanel1.Text = "aeIconPanel1";
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.autoQuitToolStripMenuItem,
            this.quitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(181, 70);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click_1);
			// 
			// autoQuitToolStripMenuItem
			// 
			this.autoQuitToolStripMenuItem.Checked = true;
			this.autoQuitToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoQuitToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.autoQuitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
			this.autoQuitToolStripMenuItem.Name = "autoQuitToolStripMenuItem";
			this.autoQuitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
			this.autoQuitToolStripMenuItem.Text = "実行後終了";
			this.autoQuitToolStripMenuItem.Click += new System.EventHandler(this.autoQuitToolStripMenuItem_Click);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(60)))));
			this.ClientSize = new System.Drawing.Size(341, 95);
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.Controls.Add(this.aeIconPanel1);
			this.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "MainForm";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private AEIconPanel aeIconPanel1;
		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem quitToolStripMenuItem;
		private ToolStripMenuItem autoQuitToolStripMenuItem;
	}
}