using Library.Api.Entities;
using Library.Api.EntityMaps;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Library.Api.Controllers
{
    [ApiController]
    [Route("Api/User")]
    public class UserEntityController : ControllerBase
    {
       
        private readonly EFLibrary Person;
        public UserEntityController()
        {
                Person= new EFLibrary();
        }
        [HttpPost("Add-User")]
        public void AddUser([FromQuery]UserDto dto)
        {
            var user = new User()
            {
                FullName = dto.FullName,
                Email = dto.Email,
                CreatAt = DateTime.Now,
            };
            
            Person.Users.Add(user);
            Person.SaveChanges();
        }
        [HttpGet("Get-User")]
        public DbSet<User> GetUsers()
        {
            return Person.Users;
        }
        [HttpPatch("update-User/{id}")]
        public void UpadteUser([FromQuery]int id, [FromBody] UserDto dto)
        {
            var update = Person.Users.Where(_ => _.Id == id).FirstOrDefault();
            update.FullName=dto.FullName;
            update.Email=dto.Email;
            Person.SaveChanges();
        }
        [HttpDelete("delete_user/{id}")]
        public void DeleteUser([FromQuery]int id)
        {
            var delete = Person.Users.Where(_ => _.Id == id).FirstOrDefault();
            Person.Users.Remove(delete); 
            Person.SaveChanges();

        }
        [HttpPost("Serch-User")]
        public List<User> Serch([FromQuery] string item)
        {

            var search = Person.Users.Where(_ => _.FullName.Contains(item) || _.Email.Contains(item));
            return search.ToList();
        }
    }
    public class UserDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
      
    }
}
