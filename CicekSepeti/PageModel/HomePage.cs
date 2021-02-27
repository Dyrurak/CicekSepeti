using OpenQA.Selenium;

namespace CicekSepeti.PageModel
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver webDriver) : base(webDriver)
        {
        }

        public bool IsButtonMyAccountVisible()
        {
            return IsElementVisible("(//*[@class='user-menu__title' and text()='My Account'])[1]");
        }
    }
}