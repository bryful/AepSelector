using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;

namespace BRY
{
	public class AE
	{
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
			@"C:\Program Files\Adobe\Adobe After Effects CC 2020\Support Files\AfterFX.exe",
			@"C:\Program Files\Adobe\Adobe After Effects CC 2021\Support Files\AfterFX.exe"

		};
		private List<string> m_AfxPaths = new List<string>();
		private List<string> m_AfxPathsCap = new List<string>();
		private int m_SelectedIndex = -1;

		public List<string> AfxPaths {  get { return m_AfxPaths; } }
		private ListBox m_ListBox = null;
		public ListBox ListBox
		{
			get { return m_ListBox; }
			set
			{
				m_ListBox = value;
				if(m_ListBox!=null)
				{
					m_ListBox.Items.Clear();
					m_ListBox.Items.AddRange(m_AfxPathsCap.ToArray());
					m_ListBox.SelectedIndexChanged += M_ListBox_SelectedIndexChanged;
					m_ListBox.KeyDown += M_ListBox_KeyDown;
					m_ListBox.DoubleClick += M_ListBox_DoubleClick;
				}
			}
		}

		private void M_ListBox_DoubleClick(object sender, EventArgs e)
		{
			if(m_ListBox!=null)
			{
				if(m_ListBox.SelectedIndex>=0)
				{
					if (Exec()) Application.Exit();
				}
			}
		}

		public string AfxPath
		{
			get
			{
				if(m_SelectedIndex>=0)
				{
					return m_AfxPaths[m_SelectedIndex];
				}
				else
				{
					return "";
				}
			}
			set
			{
				int idx = -1;
				if(m_AfxPaths.Count>0)
				{
					for(int i=0; i<m_AfxPaths.Count;i++)
					{
						if (m_AfxPaths[i]==value)
						{
							idx = i;
							break;
						}
					}
				}
				if(idx<0)
				{
					m_AfxPaths.Add(value);
					m_SelectedIndex = 0;
					if (m_ListBox!=null)
					{
						m_ListBox.Items.Add(cap(value));
						m_ListBox.SelectedIndex = 0;
					}
				}
				else
				{
					m_SelectedIndex = idx;
					if (m_ListBox != null)
					{
						m_ListBox.SelectedIndex = idx;
					}
				}
			}
		}

		private void M_ListBox_KeyDown(object sender, KeyEventArgs e)
		{

			switch(e.KeyData.ToString())
			{
				case "Return":
					if (Exec()) Application.Exit();
					break;
				case "Escape":
					Application.Exit();
					break;
			}
		}
		private string m_aep = "";
		public string Aep
		{
			get { return m_aep; }
			set
			{
				m_aep = value;
			}
		}

		// ***********************************************************************
		private void M_ListBox_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (m_ListBox == null) return;
			m_SelectedIndex = m_ListBox.SelectedIndex;
		}
		// ***********************************************************************
		private string cap(string s)
		{
			s = Path.GetDirectoryName(s);
			s = Path.GetDirectoryName(s);
			s = Path.GetFileName(s);
			return s;
		}
		// ***********************************************************************

		/// <summary>
		/// 
		/// </summary>
		public AE()
		{
			m_AfxPaths.Clear();
			m_AfxPathsCap.Clear();
			foreach (string s in m_AfterFXList)
			{
				if (File.Exists(s)==true)
				{
					m_AfxPaths.Add(s);
					m_AfxPathsCap.Add(cap(s));
				}
			}
		}
		public bool ExecAE(string afx, string aep)
		{
			bool ret = false;
			if(File.Exists(afx)==false)
			{
				return ret;
			}
			Process proc = new Process();
			proc.StartInfo.FileName = afx;
			if ((aep != "")&&(File.Exists(aep)==true))
			{
				proc.StartInfo.Arguments = "\"" + aep + "\"";
			}
			proc.Start();
			ret = true;
			return ret;
		}
		public bool Exec()
		{
			bool ret = false;
			if (m_ListBox == null) return ret;
			if (m_ListBox.SelectedIndex<0)
			{
				MessageBox.Show("no selected");
				return ret;
			}
			ret = ExecAE(m_AfxPaths[m_ListBox.SelectedIndex], Aep);

			return ret;
		}

	}
}
