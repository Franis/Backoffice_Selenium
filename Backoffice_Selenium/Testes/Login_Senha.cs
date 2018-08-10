using OpenQA.Selenium;
using Xunit;

namespace Backoffice_Selenium
{

	public class Login_Senha
	{
		public IWebDriver Driver { get; set; }
		public Login_Senha()
		{
		}

		[Fact(DisplayName = "Vazia")]
		public void Vazia()
		{
			Driver = Acoes.InicializarDriver();
			var login = new Login(Driver);
			Acoes.PreencherLogin(Config.Credenciais.Usuario.Valido, "", Driver);
			Assert.Equal("O campo Senha é obrigatório.", login.lbl_ErroSenha.Text);
			Driver.Quit();
		}
		[Fact(DisplayName = "Invalida")]
		public void Invalida()
		{
			Driver = Acoes.InicializarDriver();
			var login = new Login(Driver);
			Acoes.PreencherLogin(Config.Credenciais.Usuario.Valido, Config.Credenciais.Senha.Invalida, Driver);
			Assert.Equal("Usuário não autorizado.", login.lbl_ErrorSum.Text);
			Driver.Quit();
		}
		[Fact(DisplayName = "Valida")]
		public void Valida()
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
