using Laurus.UiTest;
using Laurus.UiTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Secrets.UiTest.Pages
{
	public interface ILoginPage : IPage
	{
        [Locator("Id = username")]
		IEditable Username { get; set; }
        [Locator("Id = password")]
		IEditable Password { get; set; }
        [Locator("Id = submit-button")]
		IClickable Login { get; set; }
        [Locator("Id = register-button")]
		IClickable Register { get; set; }
	}
}
