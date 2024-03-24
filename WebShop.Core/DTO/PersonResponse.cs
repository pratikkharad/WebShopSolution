using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using WebShop.Core.Domain.Entities;
using WebShop.Domain.Entities;

namespace WebShop.Core.DTO
{
    public class PersonResponse : TableModel
    {
        public string? UserGuid { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public int? TotalRecords
        {
            get; set;
        }





        public override bool Equals(object? obj)
        {
            if (obj == null)
            {
                return false;
            }

            if (obj.GetType() != typeof(PersonResponse)) { return false; }

            PersonResponse userResponse = (PersonResponse)obj;
            return this.UserGuid == userResponse.UserGuid
                   && this.FirstName == userResponse.FirstName
                   && this.LastName == userResponse.LastName
                   && this.DateOfBirth == userResponse.DateOfBirth
                   && this.Email == userResponse.Email
                   && this.PhoneNumber == userResponse.PhoneNumber
                   && this.TotalRecords == userResponse.TotalRecords;
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override string ToString()
        {
            return $" UserGuid:{UserGuid},FirstName:{FirstName},LastName:{LastName},DateOfBirth:{DateOfBirth},Email:{Email},PhoneNumber:{PhoneNumber} ";
        }


    }

    public class PersonResponseDTOConverter
    {
        //Use IEnumerable<Person> when you want to take advantage of lazy-loading and only load the data into memory as needed. This can be more memory-efficient for large datasets. only read-only operation
        public static IEnumerable<PersonResponse> ConvertToPerson(IEnumerable<Person> people)
        {
            return people.Select(person => new PersonResponse
            {
                UserGuid = person.UserGuid,                
                FirstName = person.FirstName,
                LastName = person.LastName,
                DateOfBirth = person.DateOfBirth,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber,
                TotalRecords = person.TotalRecords

                
            }).ToList();
        }
    }

    public static class PersonExtensions
    {
        //public static void ConvertUserGuids(this IEnumerable<Person> users)
        //{
        //    foreach (var user in users)
        //    {
        //        if (user.UserGuid != null)
        //        {
        //            if(Guid.TryParse(user.UserGuid.ToString(), out Guid pareGuid))
        //            {
        //                user.UserGuid = pareGuid;
        //            }
        //            else
        //            {
        //                Console.WriteLine("Sorry, that's not a valid number.");
        //            }
        //        }
        //    }
        //}
    }

}
