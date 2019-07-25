using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_To_Do.Models;

namespace Core_To_Do.Services
{
    public interface IToDoDataService
    {

        IEnumerable<ToDoItemModel> ListToDos();

        ToDoItemModel AddToDo(string label);

        bool MarkCompleteToDo(int id);

        bool DeleteToDo(int id);

    }
}
