using Laurus.UiTest;
using Laurus.UiTest.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Secrets.UiTest.Framework
{
	public class WebFixture : IDisposable
	{
		public string Host { get; private set; }
		public ITest Test { get; set; }

		public WebFixture()
		{
			Host = "http://secrets.lavr.us";
			Test = new SeleniumTest(new Dictionary<string, object>(), new StartupParameters() 
			{
				BrowserType = BrowserType.Firefox,
                ImplicitWait = TimeSpan.FromSeconds(5),
			});
			StartBrowser();
		}

		public void StartBrowser()
		{
			Test.Navigate(Host);
		}

		void IDisposable.Dispose()
		{
			Test.Quit();
		}
	}
}
