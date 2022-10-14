﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace BRY
{
	public class PrefFile : AEJson
	{
		// *********************************
		private string _m_AppName = "";
		public string AppName { get { return _m_AppName; } }
		private Form? m_Form = null;
		// *********************************
		// *********************************
		public PrefFile(Form? fm =null,string aName = "")
		{
			m_Form = fm;
			if (aName == "")
			{
				_m_AppName = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
			}
			else
			{
				_m_AppName = aName;
			}
			SetFilePath(Path.Combine(
				GetFileSystemPath(Environment.SpecialFolder.ApplicationData),
				_m_AppName + ".json"));
		}
		// ****************************************************
		private static string GetFileSystemPath(Environment.SpecialFolder folder)
		{
			// パスを取得
			string path = String.Format(@"{0}\{1}",//\{2}
			  Environment.GetFolderPath(folder),  // ベース・パス
			  //Application.CompanyName,            // 会社名
			  Application.ProductName
			  );           // 製品名

			// パスのフォルダを作成
			lock (typeof(Application))
			{
				if (!Directory.Exists(path))
				{
					Directory.CreateDirectory(path);
				}
			}
			return path;
		}
		// ****************************************************
		public void StoreForm()
		{
			if (m_Form == null) return;
			SetRect("FormBounds", m_Form.Bounds);
		}
		public void RestoreForm()
		{
			if (m_Form == null) return;
			bool ok = false;
			Rectangle r = GetRect("FormBounds", out ok);
			if(ok) m_Form.Bounds = r;
			if ((ok==false)||(ScreenIn(r) == false))
			{
				Rectangle rct = Screen.PrimaryScreen.Bounds;
				Point p = new Point((rct.Width - m_Form.Width) / 2, (rct.Height - m_Form.Height) / 2);
				m_Form.Location = p;
			}

		}
		// ****************************************************
		public void StoreLoc()
		{
			if (m_Form == null) return;
			SetPoint("Location", m_Form.Location);
		}
		public void RestoreLoc()
		{
			if (m_Form == null) return;
			bool ok = false;
			Point p = GetPoint("Location", out ok);
			if (ok) m_Form.Location = p;
			Rectangle r = m_Form.Bounds;
			if ((ok == false) || (ScreenIn(r) == false))
			{
				Rectangle rct = Screen.PrimaryScreen.Bounds;
				Point p2 = new Point((rct.Width - m_Form.Width) / 2, (rct.Height - m_Form.Height) / 2);
				m_Form.Location = p2;
			}

		}
		// ****************************************************
		static public bool IsInRect(Rectangle a, Rectangle b)
		{
			bool ret = true;

			if ((a.Left > b.Left + b.Width) || (a.Left + a.Width < b.Left))
			{
				ret = false;
			}
			if ((a.Top > b.Top + b.Height) || (a.Top + a.Height < b.Top))
			{
				ret = false;
			}
			return ret;
		}
		// ****************************************************
		static public bool ScreenIn(Rectangle rct)
		{
			bool ret = false;
			foreach (Screen s in Screen.AllScreens)
			{
				Rectangle r = s.Bounds;
				if (IsInRect(r, rct))
				{
					ret = true;
					break;
				}
			}
			return ret;
		}
		static public bool ScreenIn(Point p,Size sz)
		{
			return ScreenIn(new Rectangle(p, sz));
		}
	}
}
