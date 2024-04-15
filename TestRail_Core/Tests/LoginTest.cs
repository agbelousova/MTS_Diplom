using MTS_Diplom.Models;

namespace MTS_Diplom.Tests;

public class LoginTest : BaseTest
{
    [Test]
    [Category("Positive")]
    public void SuccessfulLoginTest()
    {
        Assert.That(
            _navigationSteps
                .SuccessfulLogin(Admin)
                .SidebarProjectsAddButton
                .Displayed
        );
    }
    
    [Test]
    [Category("Negative")]
    public void FailedLoginTest()
    {
        Assert.That(
                _navigationSteps
                    .IncorrectLogin(new User
                    {
                        Username = "wrongUsername",
                        Password = Admin.Password
                    })
                    .GetErrorLabelText(), 
                Is.EqualTo("Email/Login or Password is incorrect. Please try again."));
    }
}