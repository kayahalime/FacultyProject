using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User, FacultyContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new FacultyContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.OperationClaimId equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { OperationClaimId = operationClaim.OperationClaimId, OperationClaimName = operationClaim.OperationClaimName };
                return result.ToList();

            }
        }
    }
}
