#nullable disable
namespace DataAccess.Entities;

public class Resource
{
    public int Id { get; set; }

    public string Title { get; set; }

    public string Content { get; set; }

    //Way 1: public double Score { get; set; } = 1.2
    
    //Way 2: public float Score { get; set; } = 1.2f or 1.2F
     
    public decimal Score { get; set; } // = 1.2m or 1.2M

    //Way 1:
    //public Nullable<DateTime> Date { get; set; } --> not useful

    //Way 2:
    //we want Date to be nullable
    public DateTime? Date { get; set; }
    
    public List<UserResource> UserResources { get; set; }
}
