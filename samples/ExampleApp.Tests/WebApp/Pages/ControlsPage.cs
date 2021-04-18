using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using Testime.Automation.Attributes;
using Testime.Automation.Elements;

namespace ExampleApp.Tests.WebApp.Pages
{
    public class ControlsPage : HtmlPage
    {
        [Id("Name")]
        public TextBox Name;

        [Id("Description")]
        public TextArea Description;

        [Id("Male")]
        public RadioBox MaleGender;

        [Id("Female")]
        public RadioBox FemaleGender;

        [Id("AcceptTerms")]
        public CheckBox AcceptTerms;

        [Id("Country")]
        public Dropdown Country;

        [Id("Hide")]
        public Button Hide;

        [Id("Disable")]
        public Button Disable;

        [Id("ToggleText")]
        public Button ToggleText;

        [Id("ToggleClass")]
        public Button ToggleClass;

        [Id("Meals")]
        public List Meals;

        [Id("OrderedMeals")]
        public List OrderedMeals;

        [Id("History")]
        public Table History;

        [Id("Homepage")]
        public Link Homepage;

        [Id("Photo")]
        public Image Photo;

        [Id("Children")]
        public Children Children;

        [Id("DynamicChildren")]
        public DynamicChildren DynamicChildren;

        [Id("MultipleChildren")]
        public MultipleChildren MultipleChildren;
    }

    public class Children : Block
    {
        [Id("Child1")]
        public GrandChildren Child1;

        [Id("Child2")]
        public Block Child2;

        [Id("Child3")]
        public Block Child3;
    }

    public class GrandChildren : Block
    {
        [Id("GrandChild1")]
        public Block GrandChild1;

        [Id("GrandChild2")]
        public Block GrandChild2;

        [Id("GrandChild3")]
        public Block GrandChild3;
    }

    public class DynamicChildren : Block
    {
        public List<Block> Children => FindElements<Block>(By.ClassName("DynamicChild")).ToList();

        [Id("AddDynamicChild")]
        public Button Add;

        [Id("RemoveDynamicChild")]
        public Button Remove;
    }

    public class MultipleChildren : Block
    {
        [ClassName("DynamicChild")]
        public List<Block> Children;
    }
}
