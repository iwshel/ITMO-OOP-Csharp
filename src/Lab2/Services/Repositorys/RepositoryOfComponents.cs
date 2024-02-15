using System;
using System.Collections.Generic;
using System.Linq;
using Itmo.ObjectOrientedProgramming.Lab2.Entities;

namespace Itmo.ObjectOrientedProgramming.Lab2.Services.Repositorys;

public class RepositoryOfComponents<T> : IRepository<T>
where T : IComponent
{
    private readonly IList<T> _allComponents = new List<T>();

    public void AddNew(T newComponent)
    {
        newComponent = newComponent ?? throw new ArgumentNullException(nameof(newComponent));
        if (_allComponents.Contains(newComponent)) return;
        _allComponents.Add(newComponent);
    }

    public ICollection<T> GetAll()
    {
        IList<T> tempRepo = _allComponents;
        return tempRepo;
    }

    public T FindByName(string name)
    {
        IList<T> temp = _allComponents.Where(x => x.Name == name).ToList();
        if (temp.Count == 0)
        {
            throw new ArgumentException("no such elements found");
        }

        return temp[0];
    }
}