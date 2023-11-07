
using Business.Results;
using Business.Results.Basis;
using DataAccess;
using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

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

	public Result Add(UserModel model)
	{

        //Way 1: 
        //boslukulara dikkat!
        //User existingUser = _db.Users.SingleOrDefault(u => u.UserName.ToUpper() == model.UserName.ToUpper().Trim());
		//if (existingUser is not null)
		//{
		//	return new FailureResult("User with same user name exists");
		//}
		//Way 2:
        
        if(_db.Users.Any(u => u.UserName.ToUpper() == model.UserName.ToUpper().Trim()))
        {
            return new FailureResult("User with same user name exists");
        }


		//throw new NotImplementedException();
		User user = new User() //parantezleri koymaya da bilirsin
        {
            IsActive = model.IsActive,
            UserName = model.UserName,
            Password = model.Password,
			//Way 1:
			//RoleId = model.RoleId.Value,
			//Way 2:
			//RoleId = model.RoleId != null ? model.RoleId.Value : 0,
			//RoleId = model.RoleId is not null ? model.RoleId.Value : 0,
            RoleId = model.RoleId ?? 0,
			//RoleId = model.RoleId.HasValue ? model.RoleId.Value : 0,
            //Way 3:
            //RoleId = model.RoleId,  
            Status = model.Status,
            
        };
        //Adding to DbSet
        //Updating DataBase
        _db.Users.Add(user);
        _db.SaveChanges(); // changes of the db sets are committed to the database with unity of work

        return new SuccessResult("User added successfully!");
	}

    
    public Result Delete(int id)
    {
        var userResourceEntities = _db.UserResources.Where(userResource => userResource.UserId == id).ToList();
        
        //Way 1:
        //foreach(var userResourceEntity in userResourceEntities)
        //{
        //    _db.Remove(userResourceEntity);
        //}

        //Way 2:
        _db.RemoveRange(userResourceEntities);

        var userEntity = _db.Users.SingleOrDefault(user => user.Id == id);

        if(userEntity == null)
        {
            return new FailureResult("User not found");
        }
        
        _db.Users.Remove(userEntity);

        _db.SaveChanges();

        return new SuccessResult("Deleted Successfully");

    }

    public Result DeleteUser(int id)
    {
        var userEntity = _db.Users.Include(u => u.UserResources).SingleOrDefault(u => u.Id == id);
        if( userEntity == null)
        {
            return new FailureResult("User not found");
        }

        _db.UserResources.RemoveRange(userEntity.UserResources);
        _db.Users.Remove(userEntity);
        _db.SaveChanges();

        return new SuccessResult("User deleted successfully");

    }

    public IQueryable<UserModel> Query()
    {
        //entity yi model e çevirmemiz lazım
        return _db.Users.Include(e => e.Role).OrderByDescending(e => e.IsActive)//ilk başta aktifliğe göre sıralıyoruz
            .ThenBy(e => e.UserName)//sonra username e göre sıralarız
            .Select(e => new UserModel(){//Burada e User a delege eder.
                Id /*UserModelin Idsi*/ = e.Id /*Users ın ID si*/,
                IsActive = e.IsActive,
                Password = e.Password,
                UserName = e.UserName,
                RoleId = e.RoleId,
                Status = e.Status,

                IsActiveOutput = e.IsActive ? "Yes" : "No",
                RoleNameOutput = e.Role.Name
            });
        //Select alır ve projecte eder. Db den aldık Modele proje edicez.


        //Yukarıda yazdıklarımıza göre sql sorgusu yazıyor.
    }

    public Result Update(UserModel model)
    {
		//Way 1:
		//if(_db.Users.Any(u => u.UserName.ToLower() == model.UserName.ToLower().Trim() && u.Id != model.Id))
		//{
		//    return new FailureResult("User with same user name exists");
		//}
		//Way 2:
		//i girdiginde sorun yasamamak icin bunu kullandk
		//ileride sql kisminda ir cozum olacak!
		//var existingUsers = _db.Users.Where(u => u.Id != model.Id).ToList();
		//if(existingUsers.Any(u => u.UserName.Equals(model.UserName.Trim(), StringComparison.OrdinalIgnoreCase)))
		//{
		//    return new FailureResult("User with same user name exists");
		//}

		List<User> existingUser = _db.Users.ToList();
        if(existingUser.Any(u => u.UserName.Equals(model.UserName.Trim(), StringComparison.OrdinalIgnoreCase) && u.Id != model.Id))
        {
            return new FailureResult("User with same user name exists");
        }
    
        var user = _db.Users.SingleOrDefault(u => u.Id == model.Id);

        if(user is not  null)
        {
            user.UserName = model.UserName.Trim();
            user.Password = model.Password.Trim();
            user.IsActive = model.IsActive;
            user.RoleId = model.RoleId ?? 0;
            user.Status = model.Status;

            _db.Users.Update(user);

            _db.SaveChanges();
            
        }
        return new SuccessResult("User updated successfully");
    }
}
