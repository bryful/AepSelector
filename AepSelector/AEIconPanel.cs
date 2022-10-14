using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AepSelector
{
	public partial class AEIconPanel : Control
	{
		public bool AutoQuit = false;
		public delegate void AepChangedHandler(object sender, StringChangeArgs e);
		public event AepChangedHandler? AepChanged = null;

		protected virtual void OnAepChanged(StringChangeArgs e)
		{
			if (AepChanged != null)
			{
				AepChanged(this, e);
			}
		}
		private string[] m_AfterFXList =
		{
			@"C:\Program Files\Adobe\Adobe After Effects CS4\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects CS6\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects CC\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects CC 2011\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects CC 2012\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects CC 2013\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects CC 2014\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects CC 2015\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects CC 2016\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects CC 2017\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects CC 2018\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects CC 2019\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects 2020\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects 2021\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects 2022\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects 2023\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects 2024\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects 2025\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects 2026\Support Files\AfterFX.exe"

		}; [DllImport("user32.dll")]
		private static extern IntPtr SetFocus(IntPtr hWnd);
		/*
		private Form? m_form = null;
		public Form? Form
		{
			get { return m_form; }
			set
			{
				m_form = value;
				if(m_form != null)
				{
					if (m_form is AEForm)
					{
						((AEForm)m_form).AEIconPanel = this;
					}
				}
			}
		}
		*/

		private string m_AepPath = "";

		public string AepPath
		{
			get { return m_AepPath; }
			set { SetAepPath(value); }
		}
		private string m_Caption = "";
		public string Caption
		{
			get { return m_Caption; }
		}
		public string AfterFXPath
		{
			get 
			{
				string ret = "";
				int cnt = this.Controls.Count;
				if (cnt>0)
				{
					if((m_TargetIndex>=0)&&(m_TargetIndex<cnt))
					{
						AEIcon icon = (AEIcon)(this.Controls[m_TargetIndex]);
						ret = icon.AfterFX;
					}

				}
				return ret;
			}
			set
			{
				int cnt = this.Controls.Count;
				if (cnt > 0)
				{
					int idx = -1;
					for(int i=0; i<cnt;i++)
					{
						if(this.Controls[i] is AEIcon)
						{
							AEIcon icon = (AEIcon)(this.Controls[i]);
							if(icon.AfterFX == value)
							{
								idx = i;
								break;
							}

						}
					}
					if(idx!= m_TargetIndex)
					{
						TargetIndex = idx;
					}
				}
			}
		}
		private int m_TargetIndex = -1;
		public int TargetIndex
		{
			get { return m_TargetIndex; }
			set
			{
				int idx = value;
				if (idx < 0) idx = -1;
				if (m_TargetIndex != idx)
				{
					m_TargetIndex = idx;
					if ((idx >= 0) && (idx < this.Controls.Count)) {
						if(this.Controls[idx].Focused==false)
							SetFocus(this.Controls[idx].Handle);
					}
				}
			}
		}

		public AEIconPanel()
		{
			this.SetStyle(
				ControlStyles.DoubleBuffer |
			//	ControlStyles.UserPaint |
			//	ControlStyles.AllPaintingInWmPaint |
				ControlStyles.SupportsTransparentBackColor,
				true);

			this.BackColor = Color.Transparent;
			this.ForeColor = Color.FromArgb(255, 200, 200, 255);

			InitializeComponent();
			ChkAfterFX();
		}
		private bool AddIcon(string s)
		{
			bool ret = false;
			if(File.Exists(s)==false) return ret;
			AEIcon icon = new AEIcon();
			icon.SetAfterFX(s);
			int idx = this.Controls.Count;
			icon.Location = new Point(icon.Width * idx, 0);

			icon.AepChanged += Icon_AepChanged;
			icon.ExecEvent += Icon_ExecEvent;
			icon.GotFocus += Icon_GotFocus;
			icon.ID = this.Controls.Count;
			this.Controls.Add(icon);

			ret = true;
			return ret;
		}

		private void Icon_ExecEvent(object? sender, EventArgs e)
		{
			if ((TargetIndex>=0))
			{
				//MessageBox.Show($"{AfterFXPath}\r\n{m_AepPath}");
				ExecAE(AfterFXPath, m_AepPath);
			}
		}
		public bool ExecAE(string afx, string aep)
		{
			bool ret = false;
			if (File.Exists(afx) == false)
			{
				return ret;
			}
			Process proc = new Process();
			proc.StartInfo.FileName = afx;
			if ((aep != "") && (File.Exists(aep) == true))
			{
				proc.StartInfo.Arguments = "\"" + aep + "\"";
			}
			proc.Start();
			if(AutoQuit) Application.Exit();	
			ClearAepPath();
			ret = true;
			return ret;
		}
		private void Icon_GotFocus(object? sender, EventArgs e)
		{
			AEIcon icon = (AEIcon)sender;
			if(icon.ID != TargetIndex)
			{
				TargetIndex = icon.ID;
			}
		}

		private void Icon_AepChanged(object sender, StringChangeArgs e)
		{
			string p = e.Name;
			if (m_AepPath != p)
			{
				SetAepPath(e.Name);
				OnAepChanged(new StringChangeArgs(m_Caption));
			}
		}

			public void ChkAfterFX()
		{
			if(this.Controls.Count > 0)
			{
				foreach(AEIcon icon in this.Controls)
				{
					icon.Dispose();
				}
				this.Controls.Clear();
			};
			foreach(string s in m_AfterFXList)
			{
				AddIcon(s);
			}
			ChkSize();
		}
		public Size ChkSize()
		{
			Size ret = new Size(0,0);
			int cnt = this.Controls.Count;
			if (cnt > 0)
			{
				ret = new Size(cnt * this.Controls[0].Width, this.Controls[0].Height);
				this.Size = ret;
				this.MinimumSize = ret;
				this.MaximumSize = new Size(0, 0);
			}
			else
			{
				this.MinimumSize = new Size(0, 0);
				this.MaximumSize = new Size(0, 0);
			}
			return ret;
		}
		public void SetAepPath(string s)
		{
			if (File.Exists(s) == false) return;
			if(m_AepPath == s) return;
			m_AepPath = s;
			m_Caption= Path.GetFileName(s);
			OnAepChanged(new StringChangeArgs(m_Caption));
		}
		public void ClearAepPath()
		{
			if (m_AepPath != "")
			{
				m_AepPath = "";
				m_Caption = "";
				OnAepChanged(new StringChangeArgs(m_Caption));
			}
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			base.OnPaint(pe);
		}
	}
}
