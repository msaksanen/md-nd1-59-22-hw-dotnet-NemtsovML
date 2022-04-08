using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HW12.Task1
{
    public interface IMotoCRUD
    {
        void AddMotoinDb(Moto moto, List<Moto> list);

        void DeleteMoto(Guid id, List<Moto> list);

        bool UpdateMoto(Moto moto, List<Moto> list);

        Moto GetMotoByID(Guid id, List<Moto> list);

        void GetMotosInfo(List<Moto> list);

    }
}
