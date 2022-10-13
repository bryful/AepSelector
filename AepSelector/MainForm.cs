using BRY;
using System.IO.Pipes;

namespace AepSelector
{
	public enum PIPECALL
	{
		StartupExec,
		DoubleExec
	}

	public partial class MainForm : Form
	{
		public static bool _execution = true;

		public MainForm()
		{
			InitializeComponent();

			this.AEIconPanel = aeIconPanel1;
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
			m_AEIconPanel.ChkSize();
			int w = aeIconPanel1.Width + m_SideMargin * 2;
			int h = aeIconPanel1.Height + m_CaptiobHeight;
			int w2 = 64*3 + m_SideMargin * 2;
			if (w < w2) w = w2;
			this.Size = new Size(w,h);
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
			PrefFile pf = new PrefFile();
			this.Text = pf.AppName;
			if (pf.Load() == true)
			{
				bool ok = false;
				Point p = pf.GetPoint("Location", out ok);
				if ((ok)&& (PrefFile.ScreenIn(this.Bounds) == true))
				{
					this.Location = p;
				}
				else
				{
					ToCenter();
				}
				if (m_AEIconPanel != null)
				{
					string ap = pf.GetValueString("AfterFX", out ok);
					if(ok) m_AEIconPanel.AfterFXPath = ap;
					bool b = pf.GetValueBool("AutoQuit", out ok);
					if (ok)
					{
						autoQuitToolStripMenuItem.Checked = b;
						m_AEIconPanel.AutoQuit = b;
					}
					else
					{
						autoQuitToolStripMenuItem.Checked = m_AEIconPanel.AutoQuit ;
					}
				}

			}
			else
			{
				ToCenter();
			}
			//
			Command(Environment.GetCommandLineArgs().Skip(1).ToArray(), PIPECALL.StartupExec);
			//this.Text = nameof(MainForm.Parent) + "/aa";
		}
		// ********************************************************************
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			PrefFile pf = new PrefFile();
			pf.SetPoint("Location", this.Location);
			if(m_AEIconPanel != null)
			{
				pf.SetValue("AfterFX", m_AEIconPanel.AfterFXPath);
				pf.SetValue("AutoQuit", m_AEIconPanel.AutoQuit);
			}
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
				foreach(string arg in args)
				{
					if(File.Exists(arg))
					{
						string e = Path.GetExtension(arg).ToLower();
						if(e==".aep")
						{
							if (m_AEIconPanel != null)
							{
								this.Invoke((Action)(() => {
									m_AEIconPanel.AepPath = arg;
									this.Text = m_AEIconPanel.Caption;
								}));
								break;
							}
						}
					}
				}
			}
		}
		private Point m_MD = new Point(0, 0);
		// *******************************************************************************
		protected override void OnMouseDown(MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				int x = e.X;
				int y = e.Y;
				if((x>=this.Width-m_CaptiobHeight)&&(y< m_CaptiobHeight))
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
		protected override void OnPaint(PaintEventArgs e)
		{

			Graphics g = e.Graphics;
			SolidBrush sb =new SolidBrush(ForeColor);
			Pen p = new Pen(ForeColor);
			try
			{
				sb.Color = m_CaptionColor;
				Rectangle r = new Rectangle(0, 0, this.Width, m_CaptiobHeight);
				g.FillRectangle(sb, r);
				p.Width = 2;
				p.Color = m_KagiColor;
				Point[] pnts = new Point[3];
				pnts[0] = new Point(1 ,m_KagiHeight + m_CaptiobHeight+1);
				pnts[1] = new Point(1, m_CaptiobHeight+1);
				pnts[2] = new Point(m_KagiWidth, m_CaptiobHeight + 1);
				g.DrawLines(p,pnts);
				pnts[0] = new Point(this.Width- m_KagiWidth, m_CaptiobHeight + 1);
				pnts[1] = new Point(this.Width - 1, m_CaptiobHeight + 1);
				pnts[2] = new Point(this.Width - 1, m_KagiHeight + m_CaptiobHeight + 1);
				g.DrawLines(p, pnts);
				pnts[0] = new Point(1, this.Height - m_KagiHeight-1);
				pnts[1] = new Point(1, this.Height -1);
				pnts[2] = new Point(m_KagiWidth, this.Height - 1);
				g.DrawLines(p, pnts);
				pnts[0] = new Point(this.Width- m_KagiWidth-1, this.Height -1);
				pnts[1] = new Point(this.Width-1, this.Height - 1);
				pnts[2] = new Point(this.Width- 1, this.Height - m_KagiHeight -1);
				g.DrawLines(p, pnts);

				sb.Color = ForeColor;
				r = new Rectangle(m_SideMargin, (m_CaptiobHeight - m_DotWidth) / 2, m_DotWidth, m_DotWidth);
				g.FillRectangle(sb, r);
				r = new Rectangle(m_SideMargin+ m_DotWidth+4, 0, this.Width- (m_SideMargin*2+ m_DotWidth+4), 24);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Near;
				sf.LineAlignment = StringAlignment.Center;
				g.DrawString(this.Text, this.Font, sb, r, sf);
				sb.Color = m_CloseAreaColor;
				r = new Rectangle(this.Width - m_CaptiobHeight +m_DotWidth/2, (m_CaptiobHeight - m_DotWidth) / 2, m_DotWidth, m_DotWidth);
				g.FillRectangle(sb, r);

			}
			finally
			{
				sb.Dispose();
			}
			base.OnPaint(e);

		}
		// *******************************************************************************
		static public void ArgumentPipeServer(string pipeName)
		{
			Task.Run(() =>
			{ //Taskを使ってクライアント待ち
				while (_execution)
				{
					//複数作ることもできるが、今回はwhileで1つずつ処理する
					using (NamedPipeServerStream pipeServer = new NamedPipeServerStream(pipeName, PipeDirection.InOut, 1))
					{
						// クライアントの接続待ち
						pipeServer.WaitForConnection();

						StreamString ssSv = new StreamString(pipeServer);

						while (true)
						{ //データがなくなるまで                       
							string read = ssSv.ReadString(); //クライアントの引数を受信 
							if (string.IsNullOrEmpty(read))
								break;

							//引数が受信できたら、Applicationに登録されているだろうForm1に引数を送る
							FormCollection apcl = Application.OpenForms;

							if (apcl.Count > 0)
								((MainForm)apcl[0]).Command(read.Split(";"), PIPECALL.DoubleExec); //取得した引数を送る

							if (!_execution)
								break; //起動停止？
						}
#pragma warning disable CS8600 // Null リテラルまたは Null の可能性がある値を Null 非許容型に変換しています。
						ssSv = null;
#pragma warning restore CS8600 // Null リテラルまたは Null の可能性がある値を Null 非許容型に変換しています。
					}
				}
			});
		}
		// ******************************************************************************
		public static Task ArgumentPipeClient(string pipeName, string[] args)
		{
			return Task.Run(() =>
			{ //Taskを使ってサーバに送信waitで処理が終わるまで待つ
				using (NamedPipeClientStream pipeClient = new NamedPipeClientStream(".", pipeName, PipeDirection.InOut, PipeOptions.None, System.Security.Principal.TokenImpersonationLevel.Impersonation))
				{
					StreamString ssCl;
					string writeData;
					pipeClient.Connect();

					ssCl = new StreamString(pipeClient);
					writeData = string.Join(";", args); //送信する引数
					ssCl.WriteString(writeData);
#pragma warning disable CS8600 // Null リテラルまたは Null の可能性がある値を Null 非許容型に変換しています。
					ssCl = null;
#pragma warning restore CS8600 // Null リテラルまたは Null の可能性がある値を Null 非許容型に変換しています。
				}
			});
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
			ToolStripMenuItem item =(ToolStripMenuItem)sender;

			item.Checked = !item.Checked;
			if(m_AEIconPanel!=null)
			{
				m_AEIconPanel.AutoQuit = item.Checked;
			}
		}
	}
	// ********************************************************************
	public class StreamString
	{
		private System.IO.Stream ioStream;
		private System.Text.UnicodeEncoding streamEncoding;
		public StreamString(System.IO.Stream ioStream)
		{
			this.ioStream = ioStream;
			streamEncoding = new System.Text.UnicodeEncoding();
		}

		// ********************************************************************
		public string ReadString()
		{
			int len = 0;
			len = ioStream.ReadByte() * 256; //テキスト長
			len += ioStream.ReadByte(); //テキスト長余り
			if (len > 0)
			{ //テキストが格納されている
				byte[] inBuffer = new byte[len];
				ioStream.Read(inBuffer, 0, len); //テキスト取得
				return streamEncoding.GetString(inBuffer);
			}
			else //テキストなし
				return "";
		}
		// ********************************************************************
		public int WriteString(string outString)
		{
			if (string.IsNullOrEmpty(outString))
				return 0;
			byte[] outBuffer = streamEncoding.GetBytes(outString);
			int len = outBuffer.Length; //テキストの長さ
			if (len > UInt16.MaxValue)
				len = (int)UInt16.MaxValue; //65535文字
			ioStream.WriteByte((byte)(len / 256)); //テキスト長
			ioStream.WriteByte((byte)(len & 255)); //テキスト長余り
			ioStream.Write(outBuffer, 0, len); //テキストを格納
			ioStream.Flush();
			return outBuffer.Length + 2; //テキスト＋２(テキスト長)
		}
	}
	// ********************************************************************
}