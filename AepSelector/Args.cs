using System.IO;

namespace BRY
{
	public class Param
	{
		private int m_Index = 0;
		public int Index { get { return m_Index; } }
		private string m_Arg = "";
		private bool m_IsOption = false;
		public bool IsOption { get { return m_IsOption; } }
		private bool m_IsPath = false;
		public bool IsPath { get { return m_IsPath; } }
		public string OptionStr
		{
			get
			{
				string ret = "";
				if (m_IsOption)
				{
					ret = m_Arg.Substring(1);
				}
				return ret;
			}
		}
		// *******************************************************
		public Param(string s, int idx)
		{
			m_Arg = s;
			m_Index = idx;
			if (m_Arg != "")
			{
				m_IsOption = ((m_Arg[0] == '-') || (m_Arg[0] == '/'));
				// Path文字列か調べる
				if (m_IsOption == false)
				{
					if (s.Length > 3)
					{
						//とりあえず/は\に直しておく
						string ps = m_Arg.Replace('/', '\\');
						// js形式か
						string dd = ps.Substring(1, 1).ToUpper();
						if ((ps[0] == '/') && (ps[2] == '/') && ((dd[0] >= 'A') && (dd[0] <= 'Z')))
						{
							m_IsPath = true;
							ps = String.Format("/{0}{1}", dd, ps[2..]);
						}
						if (m_IsPath == false)
						{
							dd = s.Substring(0, 1).ToUpper();
							if ((s[1] == ':') && (s[2] == '\\') && ((dd[0] >= 'A') && (dd[0] <= 'Z')))
							{
								m_IsPath = true;
							}
						}
						if (m_IsPath == false)
						{
							if ((ps.Substring(0, 2) == ".\\") || (ps.Substring(0, 3) == "..\\"))
							{
								m_IsPath = true;
							}
						}
						if (m_IsPath == false)
						{
							if (ps[0] == '~')
							{
								m_IsPath = true;
							}
						}
						if (m_IsPath == false)
						{
							if (Path.GetExtension(ps) != "")
							{
								m_IsPath = true;
							}
						}
						if (m_IsPath == true)
						{
							m_Arg = ps;
						}
					}
				}
			}

		}
		// *******************************************************

	}

	public class Args
	{
		// ********************************************************************
		public Param[] Params = new Param[0];
		private int[] m_IndexTbl = new int[0];
		public int OptionCount { get { return m_IndexTbl.Length; } }
		public Param Option(int idx)
		{
			Param ret = new Param("", -1);
			if ((idx >= 0) && (idx < m_IndexTbl.Length))
			{
				ret = Params[m_IndexTbl[idx]];
			}
			return ret;
		}
		// ********************************************************************
		// ********************************************************************
		public Args(string[] args)
		{
			if (args.Length <= 0) return;
			Params = new Param[args.Length];
			List<int> list = new List<int>();
			for (int i = 0; i < args.Length; i++)
			{
				Params[i] = new Param(args[i], i);
				if (Params[i].IsOption)
				{
					list.Add(i);
				}
			}
			m_IndexTbl = list.ToArray();
		}
		// ********************************************************************
	}
}
