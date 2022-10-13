using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AepSelector
{
	public class StringChangeArgs : EventArgs
	{
		public string Name="";
		public StringChangeArgs(string name)
		{
			Name = name;
		}
	}
	public partial class AEIcon : Control
	{
		public delegate void AepChangedHandler(object sender, StringChangeArgs e);
		public event AepChangedHandler? AepChanged = null;

		protected virtual void OnAepChanged(StringChangeArgs e)
		{
			if (AepChanged != null)
			{
				AepChanged(this, e);
			}
		}
		public event EventHandler? ExecEvent = null;
		protected virtual void OnExecEvent(EventArgs e)
		{
			if (ExecEvent != null)
			{
				ExecEvent(this, e);
			}
		}
		[DllImport("user32.dll")]
		private static extern IntPtr SetFocus(IntPtr hWnd);

		private Bitmap IconBase = Properties.Resources.IconBase;
		private Bitmap IconBaseActived = Properties.Resources.IconBaseActived;

		private string m_aep = "";
		public string Aep { get { return m_aep; } }
		private string m_AfterFX = "";
		public string AfterFX
		{
			get { return m_AfterFX; }
			set { SetAfterFX(value);this.Invalidate() ; }
		}	

		private Font m_Top_font = new Font("Arial", 22);
		public Font Top_font
		{
			get { return m_Top_font; }
			set { m_Top_font = value; this.Invalidate(); }
		}
		private Font m_Bottom_font = new Font("Arial", 16);
		public Font Bottom_font
		{
			get { return m_Bottom_font; }
			set { m_Bottom_font = value; this.Invalidate(); }
		}
		private string m_Top_Text = "Ae";
		public string Top_Text
		{
			get { return m_Top_Text; }
			set { m_Top_Text = value; this.Invalidate(); }
		}
		private string m_Bottom_Text = "2022";
		public string Bottom_Text
		{
			get { return m_Bottom_Text; }
			set { m_Bottom_Text = value; this.Invalidate(); }
		}
		private Rectangle m_TopRect = new Rectangle(0, 10, 64, 24);
		public Rectangle TopRect
		{
			get { return m_TopRect; }
			set { m_TopRect = value; this.Invalidate(); }
		}
		private Rectangle m_BottomRect = new Rectangle(0, 30, 64, 32);
		public Rectangle BottomRect
		{
			get { return m_BottomRect; }
			set { m_BottomRect = value; this.Invalidate(); }
		}
		public int ID = -1;
		public AEIcon()
		{
			this.SetStyle(
				ControlStyles.Selectable|
				ControlStyles.UserMouse |
				ControlStyles.DoubleBuffer |
				ControlStyles.UserPaint |
				ControlStyles.AllPaintingInWmPaint |
				ControlStyles.SupportsTransparentBackColor,
				true);
			this.BackColor = Color.Transparent;
			this.ForeColor = Color.FromArgb(220, 220, 255);
			this.Size = new Size(64, 64);
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
			this.UpdateStyles();
			InitializeComponent();
			SetAfterFX(@"C:\Program Files\Adobe\Adobe After Effects 2022\Support Files\AfterFX.exe");
			this.AllowDrop = true;
		}
		public void SetAfterFX(string s)
		{
			string tag = "Adobe After Effects";
			int idx = s.IndexOf(tag);
			if (idx< 0) return;
			idx += tag.Length;
			int idx2 = s.IndexOf('\\',idx);
			if (idx2 < 0) return;
			string n = s.Substring(idx, idx2 - idx).Trim();
			string [] sa = n.Split(' ');
			if(sa.Length<=0)
			{ 
			}
			else if(sa.Length==1)
			{
				if (sa[0].IndexOf("CS")==0)
				{
					m_Top_Text = "CS";
					m_Bottom_Text = sa[0].Substring(2);
				}
				else
				{
					m_Top_Text = "Ae";
					m_Bottom_Text = sa[0];
				}
			}
			else
			{
				m_Top_Text = sa[0].Trim();
				m_Bottom_Text = sa[1].Trim();
			}
			m_AfterFX = s;
		}
		// *******************************************************************************
		protected override void OnDragEnter(DragEventArgs drgevent)
		{
			if (drgevent != null)
			{
				if (drgevent.Data.GetDataPresent(DataFormats.FileDrop))
				{
					string[] fileNames =(string[])drgevent.Data.GetData(DataFormats.FileDrop, false);
					if(fileNames.Length==1)
					{
						if ( File.Exists( fileNames[0]))
						{
							string e = Path.GetExtension(fileNames[0]).ToLower();

							if (e==".aep")
							{
								SetFocus(this.Handle);
								this.Invalidate();
								OnAepChanged(new StringChangeArgs(fileNames[0]));
								drgevent.Effect = DragDropEffects.All;
							}
						}

					}
				}
				else
				{
					drgevent.Effect = DragDropEffects.None;
				}
			}
			base.OnDragEnter(drgevent);
		}
		protected override void OnDragDrop(DragEventArgs drgevent)
		{
			if(this.Focused)
			{
				OnExecEvent(new EventArgs());
			}
			base.OnDragDrop(drgevent);
		}
		// *******************************************************************************
		protected override void OnMouseDoubleClick(MouseEventArgs e)
		{
			if (this.Focused)
			{
				OnExecEvent(new EventArgs());
			}
			base.OnMouseDoubleClick(e);
		}
		protected override void OnKeyDown(KeyEventArgs e)
		{
			if(e.KeyData== Keys.Enter)
			{
				OnExecEvent(new EventArgs());
			}
			base.OnKeyDown(e);
		}
		// *******************************************************************************
		protected override void OnMouseEnter(EventArgs e)
		{
			base.OnMouseEnter(e);
			//SetFocus(this.Handle);
		}
		protected override void OnGotFocus(EventArgs e)
		{
			base.OnGotFocus(e);
			this.Invalidate();
		}
		protected override void OnLostFocus(EventArgs e)
		{
			base.OnLostFocus(e);
			this.Invalidate();
		}
		protected override void OnPaint(PaintEventArgs pe)
		{
			Graphics g = pe.Graphics;
			g.SmoothingMode = SmoothingMode.AntiAlias;
			g.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceOver;
			SolidBrush sb = new SolidBrush(Color.Transparent);
			Pen p = new Pen(Color.White);
			try
			{
				g.FillRectangle(sb, this.ClientRectangle);


				if (this.Focused)
				{
					g.DrawImage(IconBaseActived, 0, 0);
				}
				else
				{
					g.DrawImage(IconBase, 0, 0);
				}


				sb.Color = this.ForeColor;
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Center;
				sf.LineAlignment = StringAlignment.Center;
				g.DrawString(m_Top_Text, m_Top_font, sb, m_TopRect,sf);
				g.DrawString(m_Bottom_Text, m_Bottom_font, sb, m_BottomRect, sf);

			}
			finally
			{
				sb.Dispose();
			}
			//base.OnPaint(pe);
		}
	}
}
