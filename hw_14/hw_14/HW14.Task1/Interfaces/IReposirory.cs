using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW14.Task1.Interfaces
{
    interface IRepository<T, in L>
    {
        void AddTranspInDb(T transport, L list);

        void DeleteTransp(Guid id, L list);

        bool UpdateTransp(T transport, L list);

        T GetByID(Guid id, L list);

        void GetTranspInfo(L list);
    }

}
