using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Backoffice_Selenium
{
	[Parallelizable]

	class Login_Senha
	{
		public IWebDriver Driver { get; set; }
		public Login_Senha()
		{
		}

		[SetUp]
		public void Initialize()
		{
			Driver = Acoes.InicializarDriver();
		}
		[Test]
		public void Login_SenhaVazia()
		{
			var login = new Login(Driver);
			Acoes.PreencherLogin(Config.Credenciais.Usuario.Valido, "", Driver);
			Assert.AreEqual("O campo Senha é obrigatório.", login.lbl_ErroSenha.Text);
		}
		[Test]
		public void Login_SenhaInvalida()
		{
			var login = new Login(Driver);
			Acoes.PreencherLogin(Config.Credenciais.Usuario.Valido, Config.Credenciais.Senha.Invalida, Driver);
			Assert.AreEqual("Usuário não autorizado.", login.lbl_ErrorSum.Text);
		}
		[Test]
		public void Login_SenhaValida()
		{
			Acoes.PreencherLogin(Config.Credenciais.Usuario.Valido, Config.Credenciais.Senha.Valida, Driver);
			var barra = new BarraTopo(Driver);
			Assert.True(barra.act_Usuario.Displayed);
			Acoes.Logoff(Driver);
		}

		[TearDown]
		public void CleanUp()
		{
			Driver.Quit();
		}
	}
}
