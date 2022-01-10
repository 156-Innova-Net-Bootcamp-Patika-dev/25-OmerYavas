using RehberWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RehberWebApi.Database
{
    public static class DatabaseHelper
    {
        //Kişi listesini bellekte liste olarak tutmak için kullanılır.
        private static readonly List<Person> _personList = new List<Person>();

        //Kayıtlı kişilerin listesini getirir.
        public static List<Person> GetAll()
        {
            return _personList;
        }

        //Kayıtlı olan kişilerden id'ye göre kayıt getirir.
        public static Person GetById(int id)
        {
            return _personList.FirstOrDefault(x => x.Id == id);
        }

        //Yeni kişi eklemek için kullanılacak metot.
        public static void Add(Person person)
        {
            _personList.Add(person);
        }

        //Kayıtlı kişi bilgilerini güncellemek için kullanılacak metot.
        public static bool Update(Person person)
        {
            Person personInDb = GetById(person.Id);

            if (personInDb != null)
            {
                personInDb.Name = person.Name;
                personInDb.Surname = person.Surname;
                personInDb.PhoneNumber = person.PhoneNumber;
                personInDb.Address = person.Address;
                return true;
            }

            return false;
        }

        //Kayıtlı kişinin bilgilerini silmek için kullanılacak metot.
        public static bool Delete(int id)
        {
            Person personInDb = GetById(id);

            if (personInDb != null)
            {
                _personList.Remove(personInDb);
                return true;
            }

            return false;
        }



    }
}
