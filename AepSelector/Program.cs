using BRY;

namespace AepSelector
{
	public enum StartupCmd
	{
		None = 0,
		IsRunning,
		StartProcess
	}

	internal static class Program
	{
		private const string Id = "AepSelector"; // GUIDなどユニークなもの
		private static System.Threading.Mutex _mutex = new System.Threading.Mutex(false, Id);

		// *******************************************************************************************
		[STAThread]
		static void Main(string[] args)
		{
			bool IsRunning = (_mutex.WaitOne(0, false)) == false;

			if (IsRunning == false)
			{
				//起動していない
				//　通常起動
				// To customize application configuration such as set high DPI settings or default font,
				// see https://aka.ms/applicationconfiguration.
				ApplicationConfiguration.Initialize();
				MainForm mf = new MainForm();
				mf.StartServer(Id);
				Application.Run(mf);
				mf.StopServer();
			}
			else
			{
				//起動している
				//MessageBox.Show("すでに起動しています",
				//				ApplicationId,
				//				MessageBoxButtons.OK, MessageBoxIcon.Hand);

				PipeData pd = new PipeData(args, PIPECALL.DoubleExec);
				F_Pipe.Client(Id, pd.ToJson()).Wait();
			}
		}
	}
}