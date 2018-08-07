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

		[FindsBy(How = How.Id, Using = "UserName")]
		public IWebElement txt_Usuario { get; set; }

		[FindsBy(How = How.Id, Using = "Password")]
        public IWebElement txt_Senha { get; set; }

        [FindsBy(How = How.ClassName, Using = "btn")]
        public IWebElement btn_Entrar { get; set; }

        [FindsBy(How = How.Id, Using = "UserName-error")]
        public IWebElement lbl_ErroUsuario { get; set; }

        [FindsBy(How = How.Id, Using = "Password-error")]
        public IWebElement lbl_ErroSenha { get; set; }

        [FindsBy(How = How.Id, Using = "errorsummary")]
        public IWebElement lbl_ErrorSum { get; set; }
        
    }
}
