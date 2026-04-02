using System;
using System.Collections.Generic;
using System.Text;

namespace UiTestsPlaywright.Core
{
    public class Product
    {
        public string Name { get; set; }
        public string Slug {  get; set; }

        public Product(string name, string slug)
        {
            Name = name;
            Slug = slug;
        }
    }
}
