using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Linq;

namespace PlanitTechnicalAssessment.TestFrameWork
{
    public class WebElements
    {
        internal IWebElement element;
        internal bool Exists { get; set; }

        /// <summary>
        /// Create default constructor so other classes can inherit the calss without necessarily 
        /// overwriting parameterised constructor
        /// </summary>
        public WebElements() { }

        /// <summary>
        /// Find any element by just passing id of the element
        /// </summary>
        /// <param name="id"></param>
        public WebElements(string id)
        {
            Exists = AssignIfElementExists(TestConfig.driver.FindElements(By.Id(id)));
        }

        /// <summary>
        /// If any element does not have id available to find and other locator needs to be used to find the 
        /// then this consrector should able to incorporate with other locators
        /// </summary>
        /// <param name="by"></param>
        public WebElements(By by)
        {
            Exists = AssignIfElementExists(TestConfig.driver.FindElements(by));
        }

        /// <summary>
        /// Basically all elements should be able to receive a click without cauing any issue
        /// so the click action should be shared amongst all the elements across the application
        /// </summary>
        internal void Click()
        {
            element.Click();
        }


        /// <summary>
        /// Ensure that element exists before looking for it and assgning it 
        /// This allows user to mitigate the stalelement issue and noSuchElementException
        /// </summary>
        /// <param name="webElements"></param>
        /// <returns></returns>
        internal bool AssignIfElementExists(ReadOnlyCollection<IWebElement> webElements)
        {
            if (webElements.Count <= 0)
            {
                return false;
            }
            else
            {
                element = webElements.First();
                return true;
            }
        }
    }

    /// <summary>
    /// Button class allows user to execute all button related functionality and access related data
    /// </summary>
    public class Button : WebElements
    {
        public Button(string id) : base(id) { }

        public Button(By by) : base(by) { }

        /// <summary>
        /// this constructor overloading allows user to find the element of the interest within the element 
        /// </summary>
        /// <param name="element"></param>
        public Button(ReadOnlyCollection<IWebElement> element)
        {
            AssignIfElementExists(element);
        }
    }


    /// <summary>
    /// Allows user to read and write any text kind of element
    /// </summary>
    public class Text : WebElements
    {
        public Text(string id) : base(id) { }
        public Text(By by) : base(by) { }

        public Text(ReadOnlyCollection<IWebElement> element)
        {
            AssignIfElementExists(element);
        }

        public string InnerText
        {
            get { return element.Text; }
            set { element.SendKeys(value.ToString()); }
        }
    }


    /// <summary>
    /// Web Application specific element which allows user to excute and access all the product related funtions and data
    /// </summary>
    public class Product : WebElements
    {
        public Product(string id) : base(id) { }
        public Product(By by) : base(by) { }

        public Text Price => new Text(element.FindElements(By.ClassName("product-price")));

        public Button Buy => new Button(element.FindElements(By.LinkText("Buy")));
    }
}
