using ExampleApp.Tests.WebApp;
using ExampleApp.Tests.WebApp.Pages;
using FluentAssertions;
using Xunit;

namespace ExampleApp.Tests
{
    public class PageObjectModelTests : IClassFixture<WebAppFixture>
    {
        private readonly WebAppFixture _fixture;

        public PageObjectModelTests(WebAppFixture fixture)
        {
            _fixture = fixture;
        }

        [Fact]
        public void LoadHomePage()
        {
            // Arrange
            using var sut = _fixture.LaunchApp();

            // Act
            var homePage = sut.OpenPage<HomePage>();

            // Assert
            homePage.Greeting.Text.Should().Be("Welcome");
        }

        [Fact]
        public void LoadControlsPage()
        {
            // Arrange
            using var sut = _fixture.LaunchApp();

            // Act
            var controlsPage = sut.NavigatePage<ControlsPage>("/Controls");

            // Assert
            controlsPage.Name.SetValue("test");
            controlsPage.Name.Value.Should().Be("test");

            controlsPage.Description.SetValue("test");
            controlsPage.Description.Value.Should().Be("test");

            controlsPage.MaleGender.Checked.Should().BeFalse();
            controlsPage.FemaleGender.Checked.Should().BeFalse();
            controlsPage.MaleGender.Checked = true;
            controlsPage.MaleGender.Checked.Should().BeTrue();
            controlsPage.FemaleGender.Checked.Should().BeFalse();
            controlsPage.FemaleGender.Checked = true;
            controlsPage.MaleGender.Checked.Should().BeFalse();
            controlsPage.FemaleGender.Checked.Should().BeTrue();

            controlsPage.AcceptTerms.Checked.Should().BeFalse();
            controlsPage.AcceptTerms.Check();
            controlsPage.AcceptTerms.Checked.Should().BeTrue();
            controlsPage.AcceptTerms.Uncheck();
            controlsPage.AcceptTerms.Checked.Should().BeFalse();

            controlsPage.Country.Options.Should().HaveCount(3);
            controlsPage.Country.Options[0].Value.Should().Be("USA");
            controlsPage.Country.Options[1].Value.Should().Be("Canada");
            controlsPage.Country.Options[2].Value.Should().Be("Mexico");
            controlsPage.Country.SelectValue("Mexico");
            controlsPage.Country.Selected.Value.Should().Be("Mexico");
            controlsPage.Country.Options[1].Select();
            controlsPage.Country.Selected.Value.Should().Be("Canada");

            controlsPage.Hide.Displayed.Should().BeTrue();
            controlsPage.Hide.Click();
            controlsPage.Hide.Displayed.Should().BeFalse();

            controlsPage.Disable.Disabled.Should().BeFalse();
            controlsPage.Disable.Click();
            controlsPage.Disable.Displayed.Should().BeTrue();

            controlsPage.ToggleText.Text.Should().Be("ToggleText");
            controlsPage.ToggleText.Click();
            controlsPage.ToggleText.Text.Should().Be("ToggledText");

            controlsPage.ToggleClass.ClassList.Should().Contain("btn-primary");
            controlsPage.ToggleClass.ClassList.Should().NotContain("btn-danger");
            controlsPage.ToggleClass.Click();
            controlsPage.ToggleClass.ClassList.Should().NotContain("btn-primary");
            controlsPage.ToggleClass.ClassList.Should().Contain("btn-danger");

            controlsPage.Meals.Items.Should().HaveCount(3);
            controlsPage.Meals.Items[0].Text.Should().Be("Pizza");
            controlsPage.Meals.Items[1].Text.Should().Be("Pasta");
            controlsPage.Meals.Items[2].Text.Should().Be("Burger");

            controlsPage.OrderedMeals.Items.Should().HaveCount(3);
            controlsPage.OrderedMeals.Items[0].Text.Should().Be("Pizza");
            controlsPage.OrderedMeals.Items[1].Text.Should().Be("Pasta");
            controlsPage.OrderedMeals.Items[2].Text.Should().Be("Burger");

            controlsPage.History.Rows.Should().HaveCount(3);
            controlsPage.History.Rows[0].Cells.Should().HaveCount(2);
            controlsPage.History.Rows[0].Cells[0].Text.Should().Be("Year");
            controlsPage.History.Rows[0].Cells[1].Text.Should().Be("Action");
            controlsPage.History.Rows[1].Cells.Should().HaveCount(2);
            controlsPage.History.Rows[1].Cells[0].Text.Should().Be("1991");
            controlsPage.History.Rows[1].Cells[1].Text.Should().Be("Birth");
            controlsPage.History.Rows[2].Cells.Should().HaveCount(2);
            controlsPage.History.Rows[2].Cells[0].Text.Should().Be("2021");
            controlsPage.History.Rows[2].Cells[1].Text.Should().Be("Testing");

            controlsPage.Homepage.Text.Should().Be("Homepage");

            controlsPage.Photo.Source.Should().StartWith("http://");

            controlsPage.Children.Child1.GrandChild1.Text.Should().Be("gc1");
            controlsPage.Children.Child1.GrandChild2.Text.Should().Be("gc2");
            controlsPage.Children.Child1.GrandChild3.Text.Should().Be("gc3");
            controlsPage.Children.Child2.Text.Should().Be("c2");
            controlsPage.Children.Child3.Text.Should().Be("c3");

            controlsPage.DynamicChildren.Children.Should().HaveCount(4);
            controlsPage.DynamicChildren.Add.Click();
            controlsPage.DynamicChildren.Children.Should().HaveCount(5);
            controlsPage.DynamicChildren.Add.Click();
            controlsPage.DynamicChildren.Children.Should().HaveCount(6);
            controlsPage.DynamicChildren.Remove.Click();
            controlsPage.DynamicChildren.Children.Should().HaveCount(5);

            controlsPage.MultipleChildren.Children.Should().HaveCount(4);
        }
    }
}
