using CicekSepeti.PageModel;
using CicekSepeti.Service;
using NUnit.Framework;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using TechTalk.SpecFlow;

namespace CicekSepeti.Test
{
    
    [TestFixture]
    [Binding, Scope(Feature = "CicekSepeti")]
    public class CicekSepetiTest
    {
        public IWebDriver webDriver;
        public WebDriverService webDriverService;
        public SignInPage signInPage;
        public HomePage homePage;
        public FacebookPopupPage facebookPopupPage;
        private readonly string driverPath = string.Empty;

        public CicekSepetiTest()
        {
            driverPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            webDriverService = new WebDriverService();            
        }

        [AfterScenario]
        public void AfterScenario()
        {
            webDriver.Quit();
        }

        [StepDefinition(@"'(.*)' driver ile browser acilir")]
        public void OpenBrowser(string requestedDriver){
            
            switch (requestedDriver) {
                case "Chrome": { webDriver = webDriverService.SetWebDriverAsChrome(driverPath);  break; }
                case "Firefox": { webDriver = webDriverService.SetWebDriverAsFirefox(driverPath); break; }
                case "InternetExplorer": { webDriver = webDriverService.SetWebDriverAsInternetExplorer(driverPath); break; }
            }
            signInPage = new SignInPage(webDriver);
            homePage = new HomePage(webDriver);
            facebookPopupPage = new FacebookPopupPage(webDriver);
        }

        [StepDefinition(@"'(.*)' sayfasina gidilir")]
        public void OpenWebSiteUrl(string url)
        {
            webDriver.Navigate().GoToUrl(url);
        }

        [StepDefinition(@"Email alanina '(.*)' yazilir")]
        public void SetEmailAddress(string emailAddress)
        {
            signInPage.SetEmailAddress(emailAddress);
        }

        [StepDefinition(@"Password alanina '(.*)' yazilir")]
        public void SetPassword(string password)
        {
            signInPage.SetPassword(password);
        }

        [StepDefinition(@"Sign In butonuna tiklanir")]
        public void ClickSignInButton()
        {
            signInPage.ClickSignInButton();
        }

        [StepDefinition(@"Basarili giris yapildigi gorulur")]
        public void CheckSignInSuccessful()
        {
            Assert.IsTrue(homePage.IsButtonMyAccountVisible(), "Kullanıcı girişinde hata alındı!");
        }

        [StepDefinition(@"Sign in with Facebook butonuna tiklanir")]
        public void ClickButtonSignInWithFacebook()
        {
            signInPage.ClickSignInWithFacebookButton();
        }

        [StepDefinition(@"'(.*)' nolu pencereye gecilir")]
        public void SwitchToWindow(int window)
        {
            ReadOnlyCollection<string> handle = signInPage.GetWindowHandles();
            signInPage.SwitchToWindow(handle[window]);
        }

        [StepDefinition(@"Eposta alanina '(.*)' yazilir")]
        public void SetFacebookEmail(string email)
        {
            facebookPopupPage.SetEmail(email);
        }

        [StepDefinition(@"Sifre alanina '(.*)' yazilir")]
        public void SetFacebookPassword(string password)
        {
            facebookPopupPage.SetPassword(password);
        }

        [StepDefinition(@"Giris yap butonuna tiklanir")]
        public void ClickFacebookLoginButton()
        {
            facebookPopupPage.ClickButtonLogin();
        }

        [StepDefinition(@"Hatali giris ile ilgili popup mesaji gorulur")]
        public void CheckUnsuccessfulLoginPopupMessage()
        {            
            string expectedPopupMessage = "E-mail address or password is incorrect. Please check your information and try again.";
            Assert.AreEqual(expectedPopupMessage, signInPage.GetTextPopupErrorMessage(), "Hatali giris popup mesaji ekrana dogru gelmemistir! ");
        }

        [StepDefinition(@"Email alani altinda '(.*)' hatasi gorulur")]
        public void CheckEmailErrorMessage(string expectedErrorMessage)
        {
            Assert.AreEqual(expectedErrorMessage, signInPage.GetTextEmailLoginError(), $"{expectedErrorMessage} hatasi ekrana gelmemistir! ");
        }

        [StepDefinition(@"Password alani altinda '(.*)' hatasi gorulur")]
        public void CheckPasswordErrorMessage(string expectedErrorMessage)
        {
            Assert.AreEqual(expectedErrorMessage, signInPage.GetTextPasswordError(), $"{expectedErrorMessage} hatasi ekrana gelmemistir! ");
        }

        [StepDefinition(@"Forgot Password butonuna tiklanir")]
        public void ClickForgotPassword()
        {
            signInPage.ClickForgotPassword();
        }

        [StepDefinition(@"Mail alanina '(.*)' yazilir")]
        public void SetMailAddressForForgotPassword(string email)
        {
            signInPage.SetEmailForForgotPassword(email);
        }

        [StepDefinition(@"Send butonuna tiklanir")]
        public void ClickSendButton()
        {
            signInPage.ClickSend();
        }

        [StepDefinition(@"Email gonderiminin basarili oldugu gorulur")]
        public void CheckForgotEmailMessage()
        {
            string expectedMessage = "You will receive an e-mail from us with instructions for resetting your password.";
            Assert.AreEqual(expectedMessage, signInPage.GetTextSuccessfulForgotPasswordMessage(), "Forgot password icin basarili email gönderme yazısı görülemedi! ");
        }
    }
}