using Laurus.Secrets.UiTest.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Laurus.Secrets.UiTest
{
	public class Authentication : IUseFixture<Framework.WebFixture>
	{
        [Fact]
        public void Demo_User_Can_Login()
		{
			var loginPage = _fixture.Test.GetPage<ILoginPage>();
			loginPage.Username.Text = "Demo";
			loginPage.Password.Text = "demo";
			loginPage.Login.Click();

			var loginVisible = loginPage.Login.IsVisible();
			Assert.False(loginVisible, "Demo user can't log in");
		}

        [Fact]
        public void Invalid_User_Cant_Login()
		{
			var loginPage = _fixture.Test.GetPage<ILoginPage>();
			loginPage.Username.Text = Guid.NewGuid().ToString();
			loginPage.Password.Text = Guid.NewGuid().ToString();
			loginPage.Login.Click();

			var loginVisible = loginPage.Login.IsVisible();
			Assert.True(loginVisible, "Demo user can't log in");
		}

		public void SetFixture(Framework.WebFixture data)
		{
			_fixture = data;
		}

		private Framework.WebFixture _fixture;
	}
}
