using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Models;
using DataAccess;

namespace Business.Services
{
	public class RoleService : IRoleService
	{
		private readonly DB _db;

		public RoleService(DB db)
		{
			_db = db;
		}

		public IQueryable<RoleModel> Query()
		{
			return _db.Roles.OrderBy(r => r.Name).Select(r => new RoleModel()
			{
				Id = r.Id,
				Name = r.Name
			});	
		}
	}
}
