using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RehberWebApi.Database;
using RehberWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace RehberWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        //api/Person ==> Tüm listeyi getirir.
        [HttpGet]
        public IActionResult GetAllPersonList()
        {
            List<Person> personList = DatabaseHelper.GetAll();
            if (personList == null || personList.Count == 0)
            {
                return BadRequest("Gösterilecek kayıt bulunamadı!");
            }
            return Ok(personList);
        }

        //api/Person/1 ==> istenen Id'ye göre tek kayıt getirir.
        [HttpGet("{id}")]
        public IActionResult GetPersonById(int id)
        {
            Person person = DatabaseHelper.GetById(id);
            if (person == null)
            {
                return BadRequest("Kişi bulunamadı");
            }
            return Ok(person);
        }

        //api/Person/search?name="aranacakName"&surname="aranacakSurname" ==> istenen name veya surname uyan kayıtları getirir.
        [HttpGet]
        [Route("search")]
        public IActionResult GetPerson(string name, string surname)
        {
            List<Person> personList;

            if (!string.IsNullOrEmpty(name) && string.IsNullOrEmpty(surname))
            {
                //Sadece name aranmak istendiğinde çalışır.
                personList = DatabaseHelper.GetAll()
                                           .Where(x => x.Name.ToLower().Contains(name.ToLower())).ToList();

                return Ok(personList);
            }
            else if (!string.IsNullOrEmpty(surname))
            {
                personList = !string.IsNullOrEmpty(name)
                             //Name ve surname birlikte aranmak istendiğinde çalışacak kısım
                             ? DatabaseHelper.GetAll()
                                             .Where(x => x.Surname.ToLower().Contains(surname.ToLower())
                                             && x.Name.ToLower().Contains(name.ToLower())).ToList()
                             //Sadece surname aranmak istediğinde çalışacak kısım
                             : DatabaseHelper.GetAll()
                                             .Where(x => x.Surname.ToLower().Contains(surname.ToLower())).ToList();

                return Ok(personList);
            }

            return BadRequest("Uygun kayıt bulunamadı!");
        }

        //api/Person/ ==> İstenilen bilgiler eksiksiz gönderilmesi halinde kişi ekler.
        [HttpPost]
        public IActionResult AddPerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Eksik veya hatalı kayıtlar mevcut");
            }
            DatabaseHelper.Add(person);
            return Created("", "Kişi başarıyla eklendi.");
        }

        //api/Person/ ==> İstenilen bilgiler eksiksiz gönderilmesi halinde kişi günceller.
        [HttpPut]
        public IActionResult UpdatePerson([FromBody] Person person)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Eksik veya hatalı kayıtlar mevcut");
            }

            if (DatabaseHelper.Update(person))
            {
                return Ok("Kişi başarıyla güncellendi.");
            }

            return BadRequest("Güncellenmek istenen kişi bulunamadı");
        }


        //api/Person/1 ==> Id'ye göre kişi siler.
        [HttpDelete("{id}")]
        public IActionResult UpdatePerson(int id)
        {

            if (DatabaseHelper.Delete(id))
            {
                return Ok("Kişi başarıyla silindi.");
            }

            return BadRequest("Silinmek istenen kişi bulunamadı");
        }

    }
}

