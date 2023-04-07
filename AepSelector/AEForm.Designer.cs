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
			components = new System.ComponentModel.Container();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AEForm));
			contextMenuStrip1 = new ContextMenuStrip(components);
			topMostToolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem1 = new ToolStripSeparator();
			autoQuitToolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem2 = new ToolStripSeparator();
			iconInstToolStripMenuItem = new ToolStripMenuItem();
			iconUnInstToolStripMenuItem = new ToolStripMenuItem();
			toolStripMenuItem3 = new ToolStripSeparator();
			quitToolStripMenuItem = new ToolStripMenuItem();
			shortcutToDesktopToolStripMenuItem = new ToolStripMenuItem();
			contextMenuStrip1.SuspendLayout();
			SuspendLayout();
			// 
			// contextMenuStrip1
			// 
			contextMenuStrip1.BackColor = Color.FromArgb(20, 20, 50);
			contextMenuStrip1.Items.AddRange(new ToolStripItem[] { topMostToolStripMenuItem, toolStripMenuItem1, shortcutToDesktopToolStripMenuItem, autoQuitToolStripMenuItem, toolStripMenuItem2, iconInstToolStripMenuItem, iconUnInstToolStripMenuItem, toolStripMenuItem3, quitToolStripMenuItem });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new Size(181, 176);
			// 
			// topMostToolStripMenuItem
			// 
			topMostToolStripMenuItem.ForeColor = Color.FromArgb(200, 200, 255);
			topMostToolStripMenuItem.Name = "topMostToolStripMenuItem";
			topMostToolStripMenuItem.Size = new Size(180, 22);
			topMostToolStripMenuItem.Text = "TopMost";
			topMostToolStripMenuItem.Click += topMostToolStripMenuItem_Click;
			// 
			// toolStripMenuItem1
			// 
			toolStripMenuItem1.Name = "toolStripMenuItem1";
			toolStripMenuItem1.Size = new Size(177, 6);
			// 
			// autoQuitToolStripMenuItem
			// 
			autoQuitToolStripMenuItem.Checked = true;
			autoQuitToolStripMenuItem.CheckState = CheckState.Checked;
			autoQuitToolStripMenuItem.DisplayStyle = ToolStripItemDisplayStyle.Text;
			autoQuitToolStripMenuItem.ForeColor = Color.FromArgb(200, 200, 255);
			autoQuitToolStripMenuItem.Name = "autoQuitToolStripMenuItem";
			autoQuitToolStripMenuItem.Size = new Size(180, 22);
			autoQuitToolStripMenuItem.Text = "実行後終了";
			autoQuitToolStripMenuItem.Click += autoQuitToolStripMenuItem_Click;
			// 
			// toolStripMenuItem2
			// 
			toolStripMenuItem2.Name = "toolStripMenuItem2";
			toolStripMenuItem2.Size = new Size(177, 6);
			// 
			// iconInstToolStripMenuItem
			// 
			iconInstToolStripMenuItem.ForeColor = Color.FromArgb(200, 200, 255);
			iconInstToolStripMenuItem.Name = "iconInstToolStripMenuItem";
			iconInstToolStripMenuItem.Size = new Size(180, 22);
			iconInstToolStripMenuItem.Text = "IconInst";
			iconInstToolStripMenuItem.Click += iconInstToolStripMenuItem_Click;
			// 
			// iconUnInstToolStripMenuItem
			// 
			iconUnInstToolStripMenuItem.ForeColor = Color.FromArgb(200, 200, 255);
			iconUnInstToolStripMenuItem.Name = "iconUnInstToolStripMenuItem";
			iconUnInstToolStripMenuItem.Size = new Size(180, 22);
			iconUnInstToolStripMenuItem.Text = "IconUnInst";
			iconUnInstToolStripMenuItem.Click += iconUnInstallToolStripMenuItem_Click;
			// 
			// toolStripMenuItem3
			// 
			toolStripMenuItem3.Name = "toolStripMenuItem3";
			toolStripMenuItem3.Size = new Size(177, 6);
			// 
			// quitToolStripMenuItem
			// 
			quitToolStripMenuItem.ForeColor = Color.FromArgb(200, 200, 255);
			quitToolStripMenuItem.Name = "quitToolStripMenuItem";
			quitToolStripMenuItem.Size = new Size(180, 22);
			quitToolStripMenuItem.Text = "Quit";
			quitToolStripMenuItem.Click += quitToolStripMenuItem_Click_1;
			// 
			// shortcutToDesktopToolStripMenuItem
			// 
			shortcutToDesktopToolStripMenuItem.ForeColor = Color.FromArgb(200, 200, 255);
			shortcutToDesktopToolStripMenuItem.Name = "shortcutToDesktopToolStripMenuItem";
			shortcutToDesktopToolStripMenuItem.Size = new Size(180, 22);
			shortcutToDesktopToolStripMenuItem.Text = "ShortcutToDesktop";
			shortcutToDesktopToolStripMenuItem.Click += shortcutToDesktopToolStripMenuItem_Click;
			// 
			// AEForm
			// 
			AutoScaleDimensions = new SizeF(9F, 21F);
			AutoScaleMode = AutoScaleMode.Font;
			BackColor = Color.FromArgb(10, 10, 60);
			ClientSize = new Size(330, 79);
			ContextMenuStrip = contextMenuStrip1;
			DoubleBuffered = true;
			Font = new Font("Yu Gothic UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
			ForeColor = Color.FromArgb(200, 200, 255);
			FormBorderStyle = FormBorderStyle.None;
			Icon = (Icon)resources.GetObject("$this.Icon");
			KeyPreview = true;
			Margin = new Padding(4);
			Name = "AEForm";
			Text = "Form1";
			FormClosed += Form1_FormClosed;
			Load += Form1_Load;
			contextMenuStrip1.ResumeLayout(false);
			ResumeLayout(false);
		}

		#endregion

		private ContextMenuStrip contextMenuStrip1;
		private ToolStripMenuItem quitToolStripMenuItem;
		private ToolStripMenuItem autoQuitToolStripMenuItem;
		private ToolStripMenuItem iconInstToolStripMenuItem;
		private ToolStripMenuItem iconUnInstToolStripMenuItem;
		private ToolStripMenuItem topMostToolStripMenuItem;
		private ToolStripSeparator toolStripMenuItem1;
		private ToolStripSeparator toolStripMenuItem2;
		private ToolStripSeparator toolStripMenuItem3;
		private ToolStripMenuItem shortcutToDesktopToolStripMenuItem;
	}
}