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

using BRY;

using Codeplex.Data;
/// <summary>
/// 基本となるアプリのスケルトン
/// </summary>
namespace AepSelector
{
	public partial class Form1 : Form
	{
		private AE m_ae = new AE();
		//-------------------------------------------------------------
		/// <summary>
		/// コンストラクタ
		/// </summary>
		public Form1()
		{
			InitializeComponent();
		}
		/// <summary>
		/// コントロールの初期化はこっちでやる
		/// </summary>
		protected override void InitLayout()
		{
			base.InitLayout();
		}
		//-------------------------------------------------------------
		/// <summary>
		/// フォーム作成時に呼ばれる
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_Load(object sender, EventArgs e)
		{
			//設定ファイルの読み込み
			JsonPref pref = new JsonPref();
			string afx = "";
			if (pref.Load())
			{
				bool ok = false;
				Size sz = pref.GetSize("Size", out ok);
				if (ok) this.Size = sz;
				Point p = pref.GetPoint("Point", out ok);
				if (ok) this.Location = p;
				afx = pref.GetString("Afx", out ok);
				if(ok==false)
				{
					afx = "";
				}
			}
			this.Text = Path.GetFileNameWithoutExtension(Application.ExecutablePath);
			m_ae.ListBox = edAfx;
			if(afx!="")
			{
				m_ae.AfxPath = afx;
			}
			GetCommand(System.Environment.GetCommandLineArgs());


		}
		//-------------------------------------------------------------
		/// <summary>
		/// フォームが閉じられた時
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_FormClosed(object sender, FormClosedEventArgs e)
		{
			//設定ファイルの保存
			JsonPref pref = new JsonPref();
			pref.SetSize("Size", this.Size);
			pref.SetPoint("Point", this.Location);

			pref.SetString("Afx", m_ae.AfxPath);
			pref.Save();

		}
		//-------------------------------------------------------------
		/// <summary>
		/// ドラッグ＆ドロップの準備
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_DragEnter(object sender, DragEventArgs e)
		{
			if (e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				e.Effect = DragDropEffects.All;
			}
			else
			{
				e.Effect = DragDropEffects.None;
			}
		}
		/// <summary>
		/// ドラッグ＆ドロップの本体
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Form1_DragDrop(object sender, DragEventArgs e)
		{
			string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
			//ここでは単純にファイルをリストアップするだけ
			GetCommand(files);
		}
		//-------------------------------------------------------------
		/// <summary>
		/// ダミー関数
		/// </summary>
		/// <param name="cmd"></param>
		public void GetCommand(string[] cmd)
		{
			if (cmd.Length > 0)
			{
				foreach (string s in cmd)
				{
					if(File.Exists(s)==true)
					{
						if(Path.GetExtension(s).ToLower()==".aep")
						{
							edAep.Text = s;
							m_ae.Aep = s;
							break;
						}
					}
				}
			}
		}
		/// <summary>
		/// メニューの終了
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		//-------------------------------------------------------------
		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
		{
			AppInfoDialog.ShowAppInfoDialog();
		}
		private void button1_Click(object sender, EventArgs e)
		{

			JsonPref j = new JsonPref();

			int[] aaa = new int[] { 78, 9, 12 };
			double[] bbb = new double[] { 0.7, 0.01, 0.12 };
			string[] ccc = new string[] { "eee", "sfskjbF", "13" };
			j.SetIntArray("aa", aaa);
			j.SetDoubleArray("bb", bbb);
			j.SetStringArray("cc", ccc);

			MessageBox.Show(j.ToJson());

		}

		private void edAep_TextChanged(object sender, EventArgs e)
		{

		}

		private void quitToolStripMenuItem_Click_1(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void setupExtentionToolStripMenuItem_Click(object sender, EventArgs e)
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

		private void unsetExtentionToolStripMenuItem_Click(object sender, EventArgs e)
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
}
