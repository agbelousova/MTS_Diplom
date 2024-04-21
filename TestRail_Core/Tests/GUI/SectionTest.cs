using MTS_Diplom.Models;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;

namespace MTS_Diplom.Tests;

[AllureSuite("GUI Tests")]
public class SectionTest: BaseTest
{
    [Test]
    [Order(1)]
    [Category("Positive")]
    [AllureSubSuite("Successful Add Section Test")]
    [AllureFeature("Positive GUI Tests")]
    public void SuccessfulAddSectionTest()
    {
        _navigationSteps.SuccessfulLogin(Admin);

        Section section = new Section()
        {
            Name = "New Test Section" + new Random().Next(1, 100),
            Description = "Description 1"
        };

        var sectionBasePage = _sectionSteps.AddSection(section);
        Assert.That(sectionBasePage.FindNewSection(section.Name), Is.EqualTo(section.Name));
    }

    [Test]
    [Order(2)]
    [Category("Positive")]
    [AllureSubSuite("Successful PopUp Message Test")]
    [AllureFeature("Positive GUI Tests")]
    public void PopUpMessageTest()
    {
        _navigationSteps.SuccessfulLogin(Admin);
        
        Assert.That(_sectionSteps.PopUpMessage(), Is.EqualTo("Opens a print view of this test case repository."));
    }
    
    [Test]
    [Order(5)]
    [Category("Positive")]
    [AllureSubSuite("Successful Delete Section Test")]
    [AllureFeature("Positive GUI Tests")]
    public void DeleteSectionTest()
    {
        _navigationSteps.SuccessfulLogin(Admin);

        Section section = new Section()
        {
            Name = "New Test Section" + new Random().Next(1, 100),
            Description = "Description 1"
        };

        var sectionBasePage = _sectionSteps.AddSection(section);
        Assert.That(sectionBasePage.FindNewSection(section.Name), Is.EqualTo(section.Name));
        sectionBasePage.DeleteSection();
    }
    
    [Test]
    [Order(4)]
    [Category("Negative")]
    [AllureSubSuite("Successful Limit Value Test")]
    [AllureFeature("Negative GUI Tests")]
    public void LimitValueTest()
    {
        _navigationSteps.SuccessfulLogin(Admin);

        Section section = new Section()
        {
            Name = "Test Limit" + "Lorem ipsum dolor sit amet, consectetuer adipiscing elit, sed diam nonummy nibh euismod tincidunt ut laoreet dolore magna aliquam erat volutpat. Ut wisi enim ad minim veniam, quis nostrud exerci tation ullamcorper suscipit lobortis nisl ut"
                                + "L1"
            ,
            Description = "Description 123"
        };
        var sectionBasePage = _sectionSteps.AddSection(section);
        
        if (sectionBasePage.FindNameSection(section) == "error")
            Console.WriteLine("Длина поля Name превышает допустимое!");
        else
        {
            Console.WriteLine("Длина поля Name изменилась! Проверить новое ограничение.");
            Assert.Fail();
        }
    }
    
    [Test]
    [Order(3)]
    [Category("Negative")]
    [AllureSubSuite("Failed Add Section Test")]
    [AllureFeature("Positive GUI Tests")]
    public void FailedAddSectionTest()
    {
        _navigationSteps.SuccessfulLogin(Admin);

            Assert.That(
            _sectionSteps
                .AddFaildSection(new Section()
                {
                    Description = "Description"
                }), 
            Is.EqualTo("Field Name is a required field."));
    }
}