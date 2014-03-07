using Laurus.Secrets.UiTest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Laurus.Secrets.UiTest
{
    public class Registration : IUseFixture<Framework.WebFixture>
    {
        [Fact]
        public void New_User_Can_Register()
		{
			var loginPage = _fixture.Test.GetPage<ILoginPage>();
			loginPage.Username.Text = "Demo";
			loginPage.Password.Text = "Demo";
			loginPage.Login.Click();
		}

		public void SetFixture(Framework.WebFixture data)
		{
			_fixture = data;
		}

		private Framework.WebFixture _fixture;
	}
}
