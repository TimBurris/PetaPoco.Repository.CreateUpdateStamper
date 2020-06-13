using System;
using System.Collections.Generic;
using System.Text;

namespace PetaPoco.Repository.CreateUpdateStamper
{
    public interface ICurrentUserProvider
    {
        object GetCurrentUserId();
    }
}
