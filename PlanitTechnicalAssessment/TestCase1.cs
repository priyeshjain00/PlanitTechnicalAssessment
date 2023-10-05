using NUnit.Framework;
using PlanitTechnicalAssessment.TestFrameWork;

namespace PlanitTechnicalAssessment
{
    public class TestCase1
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
        public void GotoContactPage_ValidateMandatoryFields_AssertErrorMessagesAndTheirExistance()
        {
            var home = new Home();
            home.GoTo();

            // Check if the collapsse button is present if so then click on it
            // this will make all the common tab buttons available on the page
            if (home.CollapseMenu.Exists)
            {
                home.CollapseMenu.Click();
            }

            home.Contact.Click();

            testConfig.ImplicitWait(5*1000);

            var contact = new Contact();
            var any = contact.Submit;
            contact.Submit.Click();

            Assert.That(contact.ForenameError.InnerText, Is.EqualTo("Forename is required"), "Foreman is a mandatory field, It can't be empty");
            Assert.That(contact.EmailError.InnerText, Is.EqualTo("Email is required"), "Email is a mandatory field, It can't be empty");
            Assert.That(contact.MessageError.InnerText, Is.EqualTo("Message is required"), "Message is a mandatory, It can't be empty");

            contact.Forename.InnerText = "Priyesh";
            contact.Email.InnerText = "priyesh.jain@planit.co.nz";
            contact.Message.InnerText = "Planit Technical Assessment Test Case 1";

            // Assert that the errors do not exist on the page at
            Assert.That(contact.ForenameError.Exists, Is.False, "Ensure that Forename Error does not exist");
            Assert.That(contact.EmailError.Exists, Is.False, "Ensure that Email Error does not exist");
            Assert.That(contact.MessageError.Exists, Is.False, "Ensure that Message Error does not exist");
        }

        [TearDown]
        public void TearDown()
        {
            testConfig.DisposeTestData(); // Closes brower but any additional clean up required can be added here
        }
    }
}