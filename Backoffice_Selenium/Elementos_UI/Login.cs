using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Backoffice_Selenium
{
    public class Login
    {
        public Login(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

		[FindsBy(How = How.Id, Using = "txtUsuario")]
		public IWebElement txtUsuario { get; set; }

		[FindsBy(How = How.Id, Using = "txtSenha")]
        public IWebElement txtSenha { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn")]
        public IWebElement btnEntrar { get; set; }

        [FindsBy(How = How.CssSelector, Using = "div.alert")]
        public IWebElement lblErrorSum { get; set; }
        
    }
}
