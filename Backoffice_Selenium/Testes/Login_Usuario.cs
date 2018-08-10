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
            Assert.Equal("O campo Usuário é obrigatório.", login.lbl_ErroUsuario.Text);
			Driver.Quit();
		}
		[Fact(DisplayName = "Invalido")]
		public void Invalido()
        {
			Driver = Acoes.InicializarDriver();
			var login = new Login(Driver);
            Acoes.PreencherLogin(Config.Credenciais.Usuario.Invalido, Config.Credenciais.Senha.Valida, Driver);
            Assert.Equal("Usuário não autorizado.", login.lbl_ErrorSum.Text);
			Driver.Quit();
		}
		[Fact(DisplayName = "Valido")]
		public void Valido()
        {
			Driver = Acoes.InicializarDriver();
			Acoes.PreencherLogin(Config.Credenciais.Usuario.Valido, Config.Credenciais.Senha.Valida, Driver);
            var barra = new BarraTopo(Driver);
            Assert.True(barra.act_Usuario.Displayed);
            Acoes.Logoff(Driver);
			Driver.Quit();
		}
    }
}
