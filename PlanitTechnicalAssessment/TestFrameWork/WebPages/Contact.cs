using OpenQA.Selenium;
using PlanitTechnicalAssessment.TestFrameWork;


namespace PlanitTechnicalAssessment.TestFrameWork
{
    /// <summary>
    /// All the web elements and specific functions and features of the page Contact needs to be added here
    /// </summary>
    public partial class Contact
    {
        public Text HeaderMessage => new Text("header-message");
        public Text Forename => new Text("forename");
        public Text ForenameError => new Text("forename-err");
        public Text Surname => new Text("surname");
        public Text Email => new Text("email");
        public Text EmailError => new Text("email-err");
        public Text Telephone => new Text("telephone");
        public Text Message => new Text("message");
        public Text MessageError => new Text("message-err");
        public Button Submit => new Button(By.LinkText("Submit"));
        public Text SuccessAlertMesage => new Text(By.ClassName("alert-success"));
        public Text sendingFeedback => new Text(By.ClassName("modal-header"));
    }
}