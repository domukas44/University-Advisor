using System;
using System.Collections.Generic;
using System.Text;

namespace UniversityAdvisor.Models
{
    public enum MenuItemType
    {
        Browse,
        About,
        Register
    }
    public class HomeMenuItem
    {
        public MenuItemType Id { get; set; }

        public string Title { get; set; }
    }
}
