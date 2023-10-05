using NUnit.Framework;
using PlanitTechnicalAssessment.TestFrameWork;

namespace PlanitTechnicalAssessment
{
    public class TestCase2
    {
        TestConfig testConfig;


        /// <summary>
        /// Initialise all basic configurations of the tests ie web browser, driver, application url, waits
        /// </summary>
        [SetUp]
        public void Setup()
        {
            testConfig = new TestConfig();
            testConfig.InitializeTestConfig();
        }

        [Test]
        public void GotoContactPage_FilloutMandatoryFields_AssertSuccessfulSubmissionMessage()
        {
            var forename = "Priyesh";
            var email = "priyesh.jain@planit.co.nz";
            var message = "Planit Technical Assessment Test Case 1";

            var home = new Home();
            home.GoTo();

            // Check if the collapsse button is present if so then click on it
            // this will make all the common tab buttons available on the page
            if (home.CollapseMenu.Exists)
            {
                home.CollapseMenu.Click();
            }

            home.Contact.Click();

            var contact = new Contact();

            testConfig.ImplicitWait(5 * 1000);

            contact.Forename.InnerText = forename;
            contact.Email.InnerText = email;
            contact.Message.InnerText = message;

            contact.Submit.Click();

            Assert.That(contact.sendingFeedback.InnerText, Is.EqualTo("Sending Feedback"), "Ensure that deedback is being submitted");

            testConfig.ImplicitWait(15 * 1000);
            //testConfig.FluentWait(contact.SuccessAlertMesage.element);

            Assert.That(contact.SuccessAlertMesage.InnerText, Is.EqualTo($"Thanks {forename}, we appreciate your feedback."), "Once feedback is submitted succesfully, a success message should pop up on screen");
        }

        [TearDown]
        public void TearDown()
        {
            testConfig.DisposeTestData(); // Closes brower but any additional clean up required can be added here
        }
    }
}