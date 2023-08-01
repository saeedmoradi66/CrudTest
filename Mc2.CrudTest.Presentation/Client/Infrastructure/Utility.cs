namespace Mc2.CrudTest.Presentation.Client.Infrastructure
{
	public class Utility
	{
		private static Utility _instance;
		public static Utility GetInstance()
		{
			if (_instance == null)
				_instance = new Utility();
			return _instance;
		}

		public Utility()
		{

		}

		public static string getBaseUrl()
		{
			string BaseUrl = "https://localhost:7089/api";
			return BaseUrl;
		}


	}
}
