using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookShop.Interface
{
    public interface IRepository<T>
    {
        void Add(T item);  //Добавляем объект в хранилище
        void Delete(int id); //Удаляем объект из хранилища
        T Get(int id); //Храним Id
        IEnumerable<T> GetAll();  //Возврат всех элементов
    }
}
