#nullable disable

using DataAccess.Enums;

namespace DataAccess.Entities;

public class User
{
    public int Id {get; set;}

    public string UserName {get; set;}

    public string Password {get; set;}

    public bool IsActive {get; set;}

    //Stasuses enum type
    //1 WAY :
    //DataAccess.Enums.Stasuses 
    //2 WAY : using
    public Stasuses Status {get; set;}
    
    
    //class has-a-relationship
    public Role Role { get; set; }

    //database one to many relationship many site
    public int RoleId {get; set;}


    //always think 2 sided
    //one is UserResource
    //one is User
    public List<UserResource> UserResources { get; set; }



}