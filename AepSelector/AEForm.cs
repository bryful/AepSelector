using BRY;
using System.Diagnostics;
using System.IO.Pipes;
using System.Runtime.InteropServices;

namespace AepSelector
{

	public partial class AEForm : Form
	{
		// ********************************************************************
		private F_Pipe m_Server = new F_Pipe();
		public void StartServer(string pipename)
		{
			m_Server.Server(pipename);
			m_Server.Reception += (sender, e) =>
			{
				this.Invoke((Action)(() =>
				{
					PipeData pd = new PipeData(e.Text);
					Command(pd.Args, PIPECALL.PipeExec);
					this.Activate();
				}));
			};
		}
		// ********************************************************************
		public void StopServer()
		{
			m_Server.StopServer();
		}
		// ********************************************************************
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool SetForegroundWindow(IntPtr hWnd);
		public AEForm()
		{
			InitializeComponent();
			//this.AEIconPanel = aeIconPanel1;

			contextMenuStrip1.Click += (sender, e) =>
			{
				topMostToolStripMenuItem.Checked = this.TopMost;
			};
		}
		protected override void InitLayout()
		{
			base.InitLayout();
			ChkSize();
		}
		// ********************************************************************
		public void ChkSize()
		{
			if (m_AEIconPanel == null) return;
			Size sz = m_AEIconPanel.ChkSize();
			int w = sz.Width + m_SideMargin * 2;
			int h = sz.Height + m_CaptiobHeight;
			int w2 = 64 * 3 + m_SideMargin * 2;
			if (w < w2) w = w2;
			this.MinimumSize = new Size(0, 0);
			this.MaximumSize = new Size(0, 0);
			this.Size = new Size(w, h);
			m_AEIconPanel.Location = new Point(m_SideMargin, m_CaptiobHeight);
		}
		// ********************************************************************
		private AEIconPanel? m_AEIconPanel = null;
		public AEIconPanel? AEIconPanel
		{
			get { return m_AEIconPanel; }
			set
			{
				m_AEIconPanel = value;
				if (m_AEIconPanel != null)
				{
					m_AEIconPanel.AepChanged += M_AEIconPanel_AepChanged;
					ChkSize();
				}
			}
		}

		private void M_AEIconPanel_AepChanged(object sender, StringChangeArgs e)
		{
			this.Text = e.Name;
			this.Invalidate();
		}

		// ********************************************************************
		private void Form1_Load(object sender, EventArgs e)
		{
			PrefFile pf = new PrefFile(this);
			this.Text = pf.AppName;
			if (pf.Load() == true)
			{
				pf.RestoreLoc();
				bool ok = false;
				if (m_AEIconPanel != null)
				{
					string ap = pf.GetValueString("AfterFX", out ok);
					if (ok) m_AEIconPanel.AfterFXPath = ap;
					bool b = pf.GetValueBool("AutoQuit", out ok);
					if (ok)
					{
						autoQuitToolStripMenuItem.Checked = b;
						m_AEIconPanel.AutoQuit = b;
					}
					else
					{
						autoQuitToolStripMenuItem.Checked = m_AEIconPanel.AutoQuit;
					}
				}
				bool b2 = pf.GetValueBool("TopMost", out ok);
				if (ok)
				{
					this.TopMost = b2;
					topMostToolStripMenuItem.Checked = b2;
				}
			}
			else
			{
				ToCenter();
			}
			//
			ChkSize();
			Command(Environment.GetCommandLineArgs().Skip(1).ToArray(), PIPECALL.StartupExec);
			//this.Text = nameof(MainForm.Parent) + "/aa";
		}
		// ********************************************************************
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			PrefFile pf = new PrefFile(this);
			pf.StoreLoc();
			if (m_AEIconPanel != null)
			{
				pf.SetValue("AfterFX", m_AEIconPanel.AfterFXPath);
				pf.SetValue("AutoQuit", m_AEIconPanel.AutoQuit);
			}
			pf.SetValue("TopMost", this.TopMost);
			pf.Save();
		}
		// ********************************************************************
		public void ToCenter()
		{
			Rectangle rct = Screen.PrimaryScreen.Bounds;
			Point p = new Point((rct.Width - this.Width) / 2, (rct.Height - this.Height) / 2);
			this.Location = p;
		}
		// ********************************************************************
		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}
		// ********************************************************************
		public void Command(string[] args, PIPECALL IsPipe = PIPECALL.StartupExec)
		{
			if (args == null || args.Length == 0)
			{
			}
			else
			{
				foreach (string arg in args)
				{
					if (File.Exists(arg))
					{
						string e = Path.GetExtension(arg).ToLower();
						if (e == ".aep")
						{
							if (m_AEIconPanel != null)
							{
								this.Invoke((Action)(() =>
								{
									m_AEIconPanel.AepPath = arg;
									this.Text = m_AEIconPanel.Caption;
								}));
								break;
							}
						}
					}
				}
			}
			SetForegroundWindow(this.Handle);
		}
		private Point m_MD = new Point(0, 0);
		// *******************************************************************************
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				int x = e.X;
				int y = e.Y;
				if ((x >= this.Width - m_CaptiobHeight) && (y < m_CaptiobHeight))
				{
					Application.Exit();
				}
				m_MD = e.Location;
			}
			base.OnMouseDown(e);
		}
		protected override void OnMouseMove(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				int ax = e.X - m_MD.X;
				int ay = e.Y - m_MD.Y;
				this.Location = new Point(ax + this.Left, ay + this.Top);
			}
			base.OnMouseMove(e);
		}
		// *******************************************************************************
		private int m_CaptiobHeight = 24;
		private int m_SideMargin = 8;
		private int m_DotWidth = 12;
		private Color m_CloseAreaColor = Color.FromArgb(255, 40, 40, 80);
		private int m_KagiWidth = 12;
		private int m_KagiHeight = 8;
		private Color m_KagiColor = Color.FromArgb(255, 128, 128, 220);
		private Color m_CaptionColor = Color.FromArgb(255, 0, 0, 15);

		// *******************************************************************************
		protected override void OnKeyDown(KeyEventArgs e)
		{
			Debug.WriteLine($"kd:{e.KeyData}");
			base.OnKeyDown(e);
			if (e.KeyData == Keys.Escape)
			{
				Application.Exit();
			}
		}
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			if (m_AEIconPanel != null)
			{
				if (m_AEIconPanel.Focused == false)
				{
					m_AEIconPanel.Focus();
				}
			}

		}
		protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e)
		{
			Debug.WriteLine($"pkd:{e.KeyData}");
			if (m_AEIconPanel != null)
			{
				if (m_AEIconPanel.Focused == false)
				{
					m_AEIconPanel.Focus();
				}
				if (e.KeyData == Keys.Left)
				{
				}
			}
			base.OnPreviewKeyDown(e);
		}
		// *******************************************************************************
		protected override void OnPaint(PaintEventArgs e)
		{

			Graphics g = e.Graphics;
			SolidBrush sb = new SolidBrush(ForeColor);
			Pen p = new Pen(ForeColor);
			try
			{
				sb.Color = m_CaptionColor;
				Rectangle r = new Rectangle(0, 0, this.Width, m_CaptiobHeight);
				g.FillRectangle(sb, r);
				p.Width = 2;
				p.Color = m_KagiColor;
				Point[] pnts = new Point[3];
				pnts[0] = new Point(1, m_KagiHeight + m_CaptiobHeight + 1);
				pnts[1] = new Point(1, m_CaptiobHeight + 1);
				pnts[2] = new Point(m_KagiWidth, m_CaptiobHeight + 1);
				g.DrawLines(p, pnts);
				pnts[0] = new Point(this.Width - m_KagiWidth, m_CaptiobHeight + 1);
				pnts[1] = new Point(this.Width - 1, m_CaptiobHeight + 1);
				pnts[2] = new Point(this.Width - 1, m_KagiHeight + m_CaptiobHeight + 1);
				g.DrawLines(p, pnts);
				pnts[0] = new Point(1, this.Height - m_KagiHeight - 1);
				pnts[1] = new Point(1, this.Height - 1);
				pnts[2] = new Point(m_KagiWidth, this.Height - 1);
				g.DrawLines(p, pnts);
				pnts[0] = new Point(this.Width - m_KagiWidth - 1, this.Height - 1);
				pnts[1] = new Point(this.Width - 1, this.Height - 1);
				pnts[2] = new Point(this.Width - 1, this.Height - m_KagiHeight - 1);
				g.DrawLines(p, pnts);

				sb.Color = ForeColor;
				r = new Rectangle(m_SideMargin, (m_CaptiobHeight - m_DotWidth) / 2, m_DotWidth, m_DotWidth);
				g.FillRectangle(sb, r);
				r = new Rectangle(m_SideMargin + m_DotWidth + 4, 0, this.Width - (m_SideMargin * 2 + m_DotWidth + 4), 24);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				g.DrawString(this.Text, this.Font, sb, r, sf);
				sb.Color = m_CloseAreaColor;
				r = new Rectangle(this.Width - m_CaptiobHeight + m_DotWidth / 2, (m_CaptiobHeight - m_DotWidth) / 2, m_DotWidth, m_DotWidth);
				g.FillRectangle(sb, r);

			}
			finally
			{
				sb.Dispose();
			}
			base.OnPaint(e);

		}


		private void quitToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			Application.Exit();
		}
		private bool IsAdministrator()
		{
			var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
			var principal = new System.Security.Principal.WindowsPrincipal(identity);
			return principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator);
		}
		private void iconInstToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (IsAdministrator() == false)
			{
				MessageBox.Show($"管理者権限で実行してください {Application.ProductName}");
			}
			else
			{
				Extention ext = new Extention();
				ext.ext = ".aep";
				ext.fileType = Application.ProductName;
				ext.description = "AepSelector : AE Version selector";
				ext.iconIndex = 1;

				ExtentionSetup exs = new ExtentionSetup();
				exs.Add(ext);
				exs.Inst();
			}

		}

		private void iconUnInstallToolStripMenuItem_Click(object sender, EventArgs e)
		{
			if (IsAdministrator() == false)
			{
				MessageBox.Show($"管理者権限で実行してください {Application.ProductName}");
			}
			else
			{
				Extention ext = new Extention();
				ext.ext = ".aep";
				ext.fileType = Application.ProductName;
				ext.description = "AepSelector : AE Version selector";
				ext.iconIndex = 1;

				ExtentionSetup exs = new ExtentionSetup();
				exs.Add(ext);
				exs.Uninst();
			}
		}

		private void autoQuitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToolStripMenuItem item = (ToolStripMenuItem)sender;

			item.Checked = !item.Checked;
			if (m_AEIconPanel != null)
			{
				m_AEIconPanel.AutoQuit = item.Checked;
			}
		}

		private void topMostToolStripMenuItem_Click(object sender, EventArgs e)
		{
			this.TopMost = !this.TopMost;
			topMostToolStripMenuItem.Checked = this.TopMost;
		}
		public void MakeSC()
		{
			string shortcutPath = System.IO.Path.Combine(
				Environment.GetFolderPath(System.Environment.SpecialFolder.DesktopDirectory),
				@"AepSelector.lnk");
			string targetPath = Application.ExecutablePath;

			//WshShellを作成
			Type t = Type.GetTypeFromCLSID(new Guid("72C24DD5-D70A-438B-8A42-98424B88AFB8"));
			dynamic shell = Activator.CreateInstance(t);

			//WshShortcutを作成
			var shortcut = shell.CreateShortcut(shortcutPath);

			//リンク先
			shortcut.TargetPath = targetPath;
			//アイコンのパス
			shortcut.IconLocation = Application.ExecutablePath + ",0";
			//その他のプロパティも同様に設定できるため、省略
			shortcut.Arguments = "\"%1\"";
			shortcut.WorkingDirectory = Application.StartupPath;

			//ショートカットを作成
			shortcut.Save();

			//後始末
			System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shortcut);
			System.Runtime.InteropServices.Marshal.FinalReleaseComObject(shell);
		}

		private void shortcutToDesktopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			MakeSC();
		}
	}
	// ********************************************************************
}