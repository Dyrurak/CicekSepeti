using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CicekSepeti.PageModel
{
    public class SignInPage : BasePage
    {
        public SignInPage(IWebDriver webDriver) : base (webDriver)
        {
        }

        [FindsBy(How = How.Id, Using = "EmailLogin")]
        public IWebElement txtEmail;

        [FindsBy(How = How.Id, Using = "Password")]
        public IWebElement txtPassword;

        [FindsBy(How = How.XPath, Using = "//button[@class='btn btn-primary btn-lg pull-right login__btn js-login-button']")]
        public IWebElement btnSignIn;

        [FindsBy(How = How.XPath, Using = "//*[@class='login__facebook btn btn-info btn-xlg full-width']")]
        public IWebElement btnSignInWithFacebook;

        [FindsBy(How = How.XPath, Using = "//*[@class='modal-body']")]
        public IWebElement lblErrorMessageEmailOrPasswordIncorrect;

        [FindsBy(How = How.Id, Using = "EmailLogin-error")]
        public IWebElement lblEmailLoginError;

        [FindsBy(How = How.Id, Using = "Password-error")]
        public IWebElement lblPasswordError;

        [FindsBy(How = How.XPath, Using = "//*[@class='login__forgot-password js-forgot-password']")]
        public IWebElement btnForgotPaassword;

        [FindsBy(How = How.Id, Using = "Mail")]
        public IWebElement txtEmailForForgotPassword;

        [FindsBy(How = How.XPath, Using = "//*[@class='btn btn-lg btn-primary form-password-recovery__btn js-password-recovery-button']")]
        public IWebElement btnSend;

        [FindsBy(How = How.XPath, Using = "//*[@class='password-recovery-result js-password-recovery-result is-hidden is-visible']")]
        public IWebElement lblSuccessfulForgotPasswordMessage;
        


        public void SetEmailAddress(string email)
        {
            SetText(txtEmail, email);
        }

        public void SetPassword(string password)
        {
            SetText(txtPassword, password);
        }

        public void ClickSignInButton()
        {
            Click(btnSignIn);
        }

        public void ClickSignInWithFacebookButton()
        {
            Click(btnSignInWithFacebook);
        }

        public string GetTextPopupErrorMessage()
        {
            return GetTextOfElement(lblErrorMessageEmailOrPasswordIncorrect);
        }

        public string GetTextEmailLoginError()
        {
            return GetTextOfElement(lblEmailLoginError);
        }

        public string GetTextPasswordError()
        {
            return GetTextOfElement(lblPasswordError);
        }

        public void ClickForgotPassword()
        {
            Click(btnForgotPaassword);
        }

        public void SetEmailForForgotPassword(string email)
        {
            SetText(txtEmailForForgotPassword, email);
        }

        public void ClickSend()
        {
            Click(btnSend);
        }

        public string GetTextSuccessfulForgotPasswordMessage()
        {
            return GetTextOfElement(lblSuccessfulForgotPasswordMessage);
        }
    }
}