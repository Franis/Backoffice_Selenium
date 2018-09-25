using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Backoffice_Selenium
{
	class ModEncerrarSessão
	{
		public ModEncerrarSessão(IWebDriver driver)
		{
			PageFactory.InitElements(driver, this);
		}

		[FindsBy(How = How.ClassName, Using = "close")]
		public IWebElement btnClose { get; set; }

		[FindsBy(How = How.Id, Using = "null")]
		public IWebElement btnSim { get; set; }

		[FindsBy(How = How.Id, Using = "btnClose")]
		public IWebElement btnNao { get; set; }

	}
}
