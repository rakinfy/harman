using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Xml;
using System.Xml.Serialization;
using System.Xml.Linq;
using Patient_API.Controllers;
namespace Patient_Test
{
    [TestClass]
    public class PatientTest
    {
        [TestMethod]
        public void GetTest()
        {
            // Arrange
            //Act
            //Assert




            string target = @"< ForeName > Shilpi </ ForeName >< Surname > Kumari </ Surname >< DateOfBirth > 0001 - 01 - 01T00: 00:00 </ DateOfBirth >  < Gender > Female </ Gender > < Telephones > < Telephone >< PhoneType > Home </ PhoneType ></ Telephone >< Telephone >   < PhoneType > Work </ PhoneType > </ Telephone > < Telephone > < PhoneType > Mobile </ PhoneType > < PhoneNumber > 4356567 </ PhoneNumber ></ Telephone ></ Telephones ></ PatientDetails > ";
            string Actual = string.Empty;
            //  Actual=Patient_API.Controllers.PatientController.Equals(target);
            Assert.AreEqual(target, Actual);
        }
        [TestMethod]
        public void PostTest()
        {

           
        }
        
    }
}
