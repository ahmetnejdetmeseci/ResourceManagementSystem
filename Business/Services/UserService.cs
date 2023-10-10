
using DataAccess;

namespace Business;

//we will use CRUD operations
public class UserService : IUserService
{
    //BUNU YAPMA
    //DB db = new DB();
    
    //readonly yanlışlık yapmanın önüne geçiyor
    //readonly yi ya tanımladığın yerde 
    //ya da constructor da newlersin
    //methodlarda newleyemezsin

    private readonly DB _db;

    public UserService(DB db)
    {
        //CONSTRUCTOR INJECTION
        _db = db;
    }

    public IQueryable<UserModel> Query()
    {
        //entity yi model e çevirmemiz lazım
        return _db.Users.OrderByDescending(e => e.IsActive)//ilk başta aktifliğe göre sıralıyoruz
            .ThenBy(e => e.UserName)//sonra username e göre sıralarız
            .Select(e => new UserModel(){//Burada e User a delege eder.
                Id /*UserModelin Idsi*/ = e.Id /*Users ın ID si*/,
                IsActive = e.IsActive,
                Password = e.Password,
                UserName = e.UserName,
                RoleId = e.RoleId,
                Status = e.Status
            });
        //Select alır ve projecte eder. Db den aldık Modele proje edicez.


        //Yukarıda yazdıklarımıza göre sql sorgusu yazıyor.
    }
}
