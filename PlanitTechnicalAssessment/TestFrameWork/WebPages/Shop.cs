using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace PlanitTechnicalAssessment.TestFrameWork
{

    /// <summary>
    /// All the web elements and specific functions and features of the page shop needs to be added here
    /// </summary>
    public partial class Shop
    {
        public Product StuffedFrog => new Product("product-2");
        public Product FluffyBunny => new Product("product-4");
        public Product ValentineBear => new Product("product-7");
    }
}
