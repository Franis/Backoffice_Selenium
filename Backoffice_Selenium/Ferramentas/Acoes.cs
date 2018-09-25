using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Backoffice_Selenium
{
    class Acoes
    {
        public static IWebDriver InicializarDriver()
        {
            IWebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(Config.URLbase);
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            return driver;
        }
        public static void PreencherLogin( string Usuario, string Senha, IWebDriver driver)
        {
            var login = new Login(driver);

            login.txtUsuario.Clear();
            login.txtUsuario.SendKeys(Usuario);
            login.txtSenha.Clear();
            login.txtSenha.SendKeys(Senha);
            login.btnEntrar.Click();
        }
        public static void Logoff(IWebDriver driver)
        {
            var barra = new BarraTopo(driver);
            barra.actMenuUsuario.Click();
            barra.btnSair.Click();
        }
		public static void 
    }
}
