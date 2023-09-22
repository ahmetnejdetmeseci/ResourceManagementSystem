#nullable disable

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccess.Entities;

public class UserResource
{
    
    //Database relationship için
    [Key] // hemen alt satırdaki variable ı priamtu yapar
    [Column(Order = 0)]
    public int UserId {get; set;}
    
    //class relationship için
    public User User { get; set; }

    //Database için
    [Key]
    [Column(Order = 1)]
    public int ResourceId {get; set;}

    //class relationship için
    public Resource Resource { get; set; }

    //We  want to make these ResourceId and UserId both composite primary key

}
