using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace CicekSepeti.PageModel
{
    public class FacebookPopupPage : BasePage
    {
        public FacebookPopupPage(IWebDriver webDriver) : base(webDriver)
        {
        }

        [FindsBy(How = How.Id, Using = "email")]
        public IWebElement TxtEmail { get; set; }

        [FindsBy(How = How.Id, Using = "pass")]
        public IWebElement TxtPassword { get; set; }

        [FindsBy(How = How.Id, Using = "loginbutton")]
        public IWebElement BtnLoginFacebook { get; set; }

        public void SetEmail(string email)
        {
            SetText(TxtEmail, email);
        }

        public void SetPassword(string password)
        {
            SetText(TxtPassword, password);
        }

        public void ClickButtonLogin()
        {
            Click(BtnLoginFacebook);
        }
    }
}