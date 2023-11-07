#nullable disable
using System.ComponentModel;
using DataAccess.Enums;
using DataAccess.Entities;
using System.ComponentModel.DataAnnotations;

namespace Business;

public class UserModel
{
    public int Id { get; set; }

    [DisplayName("User Name")]

    [Required(ErrorMessage = "{0} is required")]
    //[StringLength(10, MinimumLength = 3)]
    [MaxLength(10)]
    [MinLength(3)]
    public string UserName { get; set; }

    //Error message larla bu şekilde oynayabiliriz.
    [Required(ErrorMessage = "{0} is required")]
    [MaxLength(8)]
    [MinLength(5)]
    public string Password {get; set;}

    [DisplayName("Active")]
    public bool IsActive {get; set;}

    public Stasuses Status {get; set;}


    

    [DisplayName("Role")]
    [Required]
    public int? RoleId {get; set;}

    #region Extra properties required for the views
    [DisplayName("Active")]
    public string IsActiveOutput { get; set;}


    [DisplayName("Role")]
    public string RoleNameOutput { get; set; }
    #endregion

}
