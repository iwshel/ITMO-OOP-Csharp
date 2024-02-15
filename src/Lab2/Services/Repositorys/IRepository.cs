using System.Collections.Generic;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositorys;

public interface IRepository<T>
{
    void AddNew(T newComponent);
    ICollection<T> GetAll();
    T FindByName(string name);
}