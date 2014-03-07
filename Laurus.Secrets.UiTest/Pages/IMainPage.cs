using Laurus.UiTest;
using Laurus.UiTest.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laurus.Secrets.UiTest.Pages
{
	public interface IMainPage : IPage
	{
        [Locator("Id = logout-link")]
		IClickable Logout { get; set; }
	}
}
