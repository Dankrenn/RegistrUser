using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Businesslogic.Repository
{
    public interface IRepository<T> : IDisposable where T : class
    {
        IEnumerable<T> GetList(); // получение всех объектов
        T GetID(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Delete(int id); // удаление объекта по id
        void Save( T item);  // сохранение изменений
    }
}
