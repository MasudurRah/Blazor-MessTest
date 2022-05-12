using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLibrary
{
    public class PeopleData : IPeopleData
    {
        private readonly ISQLdata _db;
        public PeopleData(ISQLdata db)
        {
            _db = db;
        }

        public Task<List<PersonModel>> GetPeople()
        {
            string sql = "select * from dbo.Person";

            return _db.LoadData<PersonModel, dynamic>(sql, new { });
        }

        public Task InsertPerson(PersonModel person)
        {
            string sql = @"insert into dbo.Person (FirstName, LastName, PhoneNumber)
                           values (@FirstName, @LastName, @PhoneNumber);";

            return _db.SavaData(sql, person);
        }
    }
}
