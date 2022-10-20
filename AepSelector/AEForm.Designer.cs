namespace AepSelector
{
	partial class AEForm
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AEForm));
			this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
			this.iconInstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.iconUnInstToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.autoQuitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.contextMenuStrip1.SuspendLayout();
			this.SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			this.contextMenuStrip1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(50)))));
			this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.iconInstToolStripMenuItem,
            this.iconUnInstToolStripMenuItem,
            this.autoQuitToolStripMenuItem,
            this.quitToolStripMenuItem});
			this.contextMenuStrip1.Name = "contextMenuStrip1";
			this.contextMenuStrip1.Size = new System.Drawing.Size(135, 92);
			// 
			// iconInstToolStripMenuItem
			// 
			this.iconInstToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
			this.iconInstToolStripMenuItem.Name = "iconInstToolStripMenuItem";
			this.iconInstToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.iconInstToolStripMenuItem.Text = "IconInst";
			this.iconInstToolStripMenuItem.Click += new System.EventHandler(this.iconInstToolStripMenuItem_Click);
			// 
			// iconUnInstToolStripMenuItem
			// 
			this.iconUnInstToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
			this.iconUnInstToolStripMenuItem.Name = "iconUnInstToolStripMenuItem";
			this.iconUnInstToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.iconUnInstToolStripMenuItem.Text = "IconUnInst";
			this.iconUnInstToolStripMenuItem.Click += new System.EventHandler(this.iconUnInstallToolStripMenuItem_Click);
			// 
			// autoQuitToolStripMenuItem
			// 
			this.autoQuitToolStripMenuItem.Checked = true;
			this.autoQuitToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
			this.autoQuitToolStripMenuItem.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
			this.autoQuitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
			this.autoQuitToolStripMenuItem.Name = "autoQuitToolStripMenuItem";
			this.autoQuitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.autoQuitToolStripMenuItem.Text = "実行後終了";
			this.autoQuitToolStripMenuItem.Click += new System.EventHandler(this.autoQuitToolStripMenuItem_Click);
			// 
			// quitToolStripMenuItem
			// 
			this.quitToolStripMenuItem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
			this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			this.quitToolStripMenuItem.Size = new System.Drawing.Size(134, 22);
			this.quitToolStripMenuItem.Text = "Quit";
			this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click_1);
			// 
			// AEForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 21F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(10)))), ((int)(((byte)(10)))), ((int)(((byte)(60)))));
			this.ClientSize = new System.Drawing.Size(341, 85);
			this.ContextMenuStrip = this.contextMenuStrip1;
			this.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
			this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(255)))));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.KeyPreview = true;
			this.Margin = new System.Windows.Forms.Padding(4);
			this.Name = "AEForm";
			this.Text = "Form1";
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
			this.Load += new System.EventHandler(this.Form1_Load);
			this.contextMenuStrip1.ResumeLayout(false);
			this.ResumeLayout(false);

		}

		#endregion

		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem quitToolStripMenuItem;
		private ToolStripMenuItem autoQuitToolStripMenuItem;
		private ToolStripMenuItem iconInstToolStripMenuItem;
		private ToolStripMenuItem iconUnInstToolStripMenuItem;
	}
}