using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KubaShop.Order.Application.Interfaces
{
    public interface IRepository<T> where T : class
    {
        //CQRS=> yazma ve okumanın sorumluluklarının ayrıştırılmasına dayanan bir mimari tasarım modelidir.Order da SQRS'de kullanılacak.Get ön eki alır. Farklı servislerde  etkilenmemesi için kullanılır.
        //READ //// WRİTE 

        //CQRS ==> Read-Write işlemlerini birbirinden ayırır

        /*
         Read --> Results 
        Parametre --> Queries

        ----------------------------------------

        Parametreler (Ekleme Silme Güncelleme) --> Commands
        Crud --> Handlers

         
         */
        Task<List<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> GetByFilterAsync(Expression<Func<T, bool>> filter);//Filtreleme işlemlerinde entity frameworkte lambda ifade var.Giriş değeri çıkış değeri olacak.Adress kontrolü ankra girdik ankara girdiyse bool true yada false girecek filter ifadesi de o değeri tutuyor olacak.


    }
}
