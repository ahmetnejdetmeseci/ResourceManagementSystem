using Business.Results.Basis;

namespace Business;

/// <summary>
/// Performs user CRUD operations
/// </summary>
public interface IUserService
{
    //Okuyabilmemiz için Queryable kullandık
    //User model döneceği için UserModel dedik sonra yaratıcaz
    IQueryable<UserModel> Query();

    //Create icin kullandigimiz method
    Result Add(UserModel model);

    Result Update(UserModel model);

    [Obsolete("Do not use this method, use DelteUser method instead!")]
    Result Delete(int id);

    Result DeleteUser(int id);
}
