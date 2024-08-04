using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V123.CSS;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivrariaTest
{
    [TestFixture]
    public class SeleniumTest
    {

        public IWebDriver driver;

        [SetUp]
        public void setUp()
        {

            driver = new ChromeDriver();
            driver.Navigate().GoToUrl("http://127.0.0.1:5500/index.html");
        }

        [Test]
        public void  DeveCadastrarLivro()
        {
            driver.FindElement(By.Id("titulo")).SendKeys("O pequeno Principe");
            driver.FindElement(By.Id("anoPublicacao")).SendKeys("1994");
            driver.FindElement(By.Id("autorId")).SendKeys("2");
            driver.FindElement(By.CssSelector("#cadastroLivroForm button")).Click();
            
           


        }

        [Test]
        public void DeveBuscarLivroPorId()
        {
            driver.FindElement(By.Id("buscarLivroId")).SendKeys("1");
            driver.FindElement(By.CssSelector("#buscarLivroForm button")).Click();

            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            var livroEncontrado = driverWait.Until(d => d.FindElement(By.Id("livroEncontrado")).Text);
            Assert.That(livroEncontrado.Contains("Dom qui"));
        }

        [Test]
        public void DeveFalharAoBuscarLivroPorIdInexistente()
        {
            int id = 33;
            driver.FindElement(By.Id("buscarLivroId")).SendKeys("33");
            driver.FindElement(By.CssSelector("#buscarLivroForm button")).Click();
            WebDriverWait driverWait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            var livroNaoEncontrado = driverWait.Until(d => d.FindElement(By.Id("livroErro"))).Text;
            Assert.That( livroNaoEncontrado, Is.Empty);
        }

        [Test]
        public void DeveListarLivros()
        {
            driver.FindElement(By.Id("listarLivrosBtn")).Click();
            WebDriverWait driverWait = new WebDriverWait (driver, TimeSpan.FromSeconds(10));
            var listagemDeLivros = driverWait.Until(p => p.FindElement(By.Id("listaLivros")).Text).ToList();

            Assert.That(listagemDeLivros, Is.Not.Null);
        }

        [TearDown]
        public void TearDown()
        {
            driver.Dispose();
        }

    }
}