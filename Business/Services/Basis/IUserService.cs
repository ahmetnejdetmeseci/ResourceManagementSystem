namespace Business;

public interface IUserService
{
    //Okuyabilmemiz için Queryable kullandık
    //User model döneceği için UserModel dedik sonra yaratıcaz
    IQueryable<UserModel> Query();

}
