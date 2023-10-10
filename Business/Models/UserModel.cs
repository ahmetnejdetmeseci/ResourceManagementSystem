#nullable disable
using System.ComponentModel;
using DataAccess.Enums;

namespace Business;

public class UserModel
{
     public int Id {get; set;}

    [DisplayName("User Name")]
    public string UserName {get; set;}

    public string Password {get; set;}

    [DisplayName("Active")]
    public bool IsActive {get; set;}

    public Stasuses Status {get; set;}

    [DisplayName("Role")]    
    public int RoleId {get; set;}
}
