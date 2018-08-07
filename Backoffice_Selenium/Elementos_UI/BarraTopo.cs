using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Backoffice_Selenium
{
    internal class BarraTopo
    {
        public BarraTopo(IWebDriver driver)
        {
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.CssSelector, Using = "div.nav>div>a")]
        public IWebElement act_Usuario { get; set; }

        [FindsBy(How = How.CssSelector, Using = "form#frmLogout>a")]
        public IWebElement btn_Logout { get; set; }
    }
}