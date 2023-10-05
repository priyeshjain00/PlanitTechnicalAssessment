using OpenQA.Selenium;
using System.Linq;

namespace PlanitTechnicalAssessment.TestFrameWork
{
    /// <summary>
    /// Create basic page defintion which is being shared across all the pages of the application,
    /// this includes web elements, and any functionality which are present on each page of the application
    /// </summary>
    public class Page : WebElements
    {
        
        /// <summary>
        /// The GoTo method allows user to directly access any page and overwritting the default page adress if required.
        /// However, this is not necessary that tester always wants to overwrite the default address so this also gives user freeedom
        /// to not specify any adress
        /// </summary>
        /// <param name="path"></param>
        public void GoTo(string path = null)
        {
            string Url = Hooks.config.WebApplicationUrl;  // get the base URL to the application

            // Get the default pageAdress from its attribute
            Pages defaultPageAdress = (Pages)System.Attribute.GetCustomAttributes(this.GetType()).FirstOrDefault();


            // Goto the user specified page address
            if (path != null)
            {
                Url += path;
            }

            // Goto Default address of the page
            else
            {
                Url += defaultPageAdress.path; // Go to the specifed address by the test
            }

            TestConfig.driver.Url = Url;
        }

        /// <summary>
        /// Add all the basic elements which are avaialble across entire web application and
        /// shared across all the pages
        /// </summary>
        public Button JupiterToys => new Button(By.ClassName("brand"));
        public Button Home => new Button("nav-shop");
        public Button Shop => new Button("nav-shop");
        public Button Contact => new Button("nav-contact");
        public Button Cart => new Button("nav-cart");

        public Button CollapseMenu => new Button(By.ClassName("btn-navbar"));
    }
}
