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

            login.txt_Usuario.Clear();
            login.txt_Usuario.SendKeys(Usuario);
            login.txt_Senha.Clear();
            login.txt_Senha.SendKeys(Senha);
            login.btn_Entrar.Click();
        }
        public static void Logoff(IWebDriver driver)
        {
            var barra = new BarraTopo(driver);
            barra.act_Usuario.Click();
            barra.btn_Logout.Click();
        }
    }
}
