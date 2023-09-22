#nullable disable
namespace DataAccess.Entities;

public class Role
{
    // data member and member method usage example from Java:
    // private int id; // a class variable is called as a field in C#

    // public void setId(int id) // a class method is called as a behavior in C#
    // {
    //     this.id = id;
    // }

    // public int getId()
    // {
    //     return id;
    // }
    public int Id {get; set;}
    public string Name {get; set;}

    //class has-a-relationship
    //Way 1:
    //public IEnumerable<User> Users {get; set;}
    //Way 2:
    //public ICollection<User> Users { get; set; }
    public List<User> Users { get; set; }
}
