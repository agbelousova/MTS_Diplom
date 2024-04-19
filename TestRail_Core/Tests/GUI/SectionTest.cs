using MTS_Diplom.Models;
using NUnit.Allure.Core;

namespace MTS_Diplom.Tests;

public class SectionTest: BaseTest
{
    [Test]
    [Order(1)]
    [Category("Positive")]
    public void SuccessfulAddSectionTest()
    {
        _navigationSteps.SuccessfulLogin(Admin);

        Section section = new Section()
        {
            Name = "New Test Section" + new Random().Next(1, 100),
            Description = "Description 1"
        };

        var sectionBasePage = _sectionSteps.AddSection(section);
        Assert.That(sectionBasePage.FindNewSection(section.Name), Is.EqualTo(true));
        
        Console.WriteLine(_sectionSteps.PopUpMessage()); 
    }

    [Test]
    [Order(2)]
    [Category("Positive")]
    public void PopUpMessageTest()
    {
        _navigationSteps.SuccessfulLogin(Admin);
        
        Assert.That(_sectionSteps.PopUpMessage(), Is.EqualTo("Opens a print view of this test case repository."));
    }
    
    [Test]
    [Order(3)]
    [Category("Positive")]
    public void DeleteSectionTest()
    {
        _navigationSteps.SuccessfulLogin(Admin);

        Section section = new Section()
        {
            Name = "New Test Section" + new Random().Next(1, 100),
            Description = "Description 1"
        };

        var sectionBasePage = _sectionSteps.AddSection(section);
        sectionBasePage.DeleteIdSection(section);
    }
    
    [Test]
    [Order(4)]
    [Category("Negative")]
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
    [Order(5)]
    [Category("Negative")]
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