using NUnit.Framework;
using OpenQA.Selenium;
using System.Threading;

namespace Backoffice_Selenium
{
    [Parallelizable]
    
    public class Login_Usuario
    {
        
        public IWebDriver Driver { get; set; }
        public Login_Usuario()
        {
        }

        [SetUp]
        public void Initialize()
        {
            Driver = Acoes.InicializarDriver();
        }

        [Test]
        public void Login_UsuarioVazio()
        {
            var login = new Login(Driver);
            Acoes.PreencherLogin("", Config.Credenciais.Senha.Valida, Driver);
            Assert.AreEqual("O campo Usuário é obrigatório.", login.lbl_ErroUsuario.Text);
		}
		[Test]
		public void Login_UsuarioInvalido()
        {
            var login = new Login(Driver);
            Acoes.PreencherLogin(Config.Credenciais.Usuario.Invalido, Config.Credenciais.Senha.Valida, Driver);
            Assert.AreEqual("Usuário não autorizado.", login.lbl_ErrorSum.Text);
        }
		[Test]
		public void Login_UsuarioValido()
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
