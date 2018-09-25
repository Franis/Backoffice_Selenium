using OpenQA.Selenium;
using Xunit;

namespace Backoffice_Selenium
{

	public class Login_Usuario
	{
		public IWebDriver Driver { get; set; }
		public Login_Usuario()
		{
		}
		
		[Fact(DisplayName = "Vazio")]
        public void Vazio()
        {
			Driver = Acoes.InicializarDriver();
			var login = new Login(Driver);
            Acoes.PreencherLogin("", Config.Credenciais.Senha.Valida, Driver);
            Assert.True(login.lblErrorSum.Displayed);

			Driver.Quit();
		}
		[Fact(DisplayName = "Invalido")]
		public void Invalido()
        {
			Driver = Acoes.InicializarDriver();
			var login = new Login(Driver);
            Acoes.PreencherLogin(Config.Credenciais.Usuario.Invalido, Config.Credenciais.Senha.Valida, Driver);
			Assert.True(login.lblErrorSum.Displayed);
			Driver.Quit();
		}
		[Fact(DisplayName = "Valido")]
		public void Valido()
        {
			Driver = Acoes.InicializarDriver();
			Acoes.PreencherLogin(Config.Credenciais.Usuario.Valido, Config.Credenciais.Senha.Valida, Driver);
            var barra = new BarraTopo(Driver);
            Assert.True(barra.actMenuUsuario.Displayed);
            Acoes.Logoff(Driver);
			Driver.Quit();
		}
    }
}
