using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace invites
{
    public class Guests
    {
        [Required(ErrorMessage = "Please enter the name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter the surname")]
        public string Surname { get; set; }
    }

    public interface IRepository{
      IEnumerable<Guests> RespGuests{get;}

      void AddGuest(Guests gs);
    }
}