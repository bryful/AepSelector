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
		private const string ApplicationId = "AepSelector"; // GUIDなどユニークなもの
		private static System.Threading.Mutex _mutex = new System.Threading.Mutex(false, ApplicationId);

		// *******************************************************************************************
		[STAThread]
		static void Main(string[] args)
		{
			// 通常の起動
			//ApplicationConfiguration.Initialize();
			//Application.Run(new Form1());

			if (_mutex.WaitOne(0, false))
			{//起動していない
				AEForm._execution = true;
				AEForm.ArgumentPipeServer(ApplicationId);
				ApplicationConfiguration.Initialize();
				Application.Run(new MainForm());
				AEForm._execution = false;
			}
			else
			{ //起動している
			  //MessageBox.Show("すでに起動しています",
			  //				ApplicationId,
			  //				MessageBoxButtons.OK, MessageBoxIcon.Hand);

				AEForm.ArgumentPipeClient(ApplicationId, args).Wait();
			}
		}
	}
}