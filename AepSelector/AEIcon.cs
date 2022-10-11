using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AepSelector
{
	public partial class AEIcon : Control
	{
		[DllImport("user32.dll")]
		private static extern IntPtr SetFocus(IntPtr hWnd);

		public AEIcon()
		{
			this.SetStyle(ControlStyles.Selectable, true);
			this.SetStyle(ControlStyles.UserMouse, true);
			this.BackColor = Color.Black;
			this.ForeColor = Color.White;
			this.Size = new Size(64, 64);
			this.MinimumSize = this.Size;
			this.MaximumSize = this.Size;
			InitializeComponent();
		}

		protected override void OnMouseDown(MouseEventArgs e)
		{
			base.OnMouseDown(e);
			SetFocus(this.Handle);
			this.Invalidate();
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
			SolidBrush sb= new SolidBrush(this.BackColor);
			Pen p = new Pen(Color.White);
			try
			{
				g.FillRectangle(sb, this.ClientRectangle);

				sb.Color = Color.FromArgb(220,220, 255);
				StringFormat sf = new StringFormat();
				sf.Alignment = StringAlignment.Center;
				sf.LineAlignment = StringAlignment.Center;
				g.DrawString("AE\r\n2022", this.Font, sb, this.ClientRectangle,sf);
				if(this.Focused)
				{
					p.Width = 2;
					g.DrawRectangle(p, new Rectangle(2,2,this.Width-4,this.Height-4));
				}
				p.Width = 1;
				p.Color=Color.FromArgb(128, 128, 255);
				g.DrawRectangle(p, new Rectangle(0, 0, this.Width - 1, this.Height - 1));

			}
			finally
			{
				sb.Dispose();
			}
			//base.OnPaint(pe);
		}
	}
}
