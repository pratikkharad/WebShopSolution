using WebShop.Core.DTO;
using WebShop.UI.Models;

namespace WebShopTest
{
    public class PersonUnitTest
    {
        /// <summary>
        /// Example : How to write the text case
        /// </summary>
        [Fact]
        public void Test1()
        {
            // Three step of every unit test Arrange, Act, Assert
            // Arrange - declaration of variable 
            // Act - which method you want to call
            // Assert - compare the result with actual value and expected value is same then test case is pass

            // Arrange 
            TestCaseExample objTest = new TestCaseExample();
            int input1 = 10; int input2 = 20;
            int expected = 30;

            // Act
            int actual = objTest.Add(input1, input2);

            // Assert
            Assert.Equal(expected, actual);


        }

        [Fact]
        public void GetFilteredPerson_EmptySearchText()
        {
            PersonResponse response1 = new PersonResponse()
            {
                FirstName = "pratik",
                Email = "pratik@gmail.com",
                PhoneNumber = "9145619372",
                DateOfBirth = DateTime.Now
            };
            PersonResponse response2 = new PersonResponse()
            {
                FirstName = "sandesh",
                Email = "sandesh@gmail.com",
                PhoneNumber = "9145619372",
                DateOfBirth = DateTime.Now
            };
            PersonResponse response3 = new PersonResponse()
            {
                FirstName = "mayur",
                Email = "mayur@gmail.com",
                PhoneNumber = "9145619372",
                DateOfBirth = DateTime.Now
            };

            List<PersonResponse> person_requests = new List<PersonResponse>()
            {
                response1,response2,response3
            };

            List<PersonResponse> person_response_list_from_add = new List<PersonResponse>();

            //foreach (var item in person_requests)
            //{
                
            //}






        }
    }
}