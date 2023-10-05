using OpenQA.Selenium;

namespace PlanitTechnicalAssessment.TestFrameWork
{

    /// <summary>
    /// All the web elements and specific functions and features of the page Cart needs to be added here
    /// </summary>
    public partial class Cart
    {
        public Text Total => new Text(By.ClassName("total"));
    }
}