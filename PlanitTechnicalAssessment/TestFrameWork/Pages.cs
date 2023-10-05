using System;
using System.Collections.Generic;
using System.Text;

namespace PlanitTechnicalAssessment.TestFrameWork
{
    /// <summary>
    /// Declare all pages in this place so the address of the pages would be in one place
    /// and other essential attribute could be added later if required and shared across al the pages such as visibility, color, enability etc
    /// </summary>
    public class Pages : Attribute
    {
        public string path { get; set; }
    }

    [Pages(path = "#/")]
    public partial class Home : Page { }

    [Pages(path = "#/contact")]
    public partial class Contact : Page { }

    [Pages(path = "#/shop")]
    public partial class Shop : Page { }

    [Pages(path = "#/cart")]
    public partial class Cart : Page { }
}
