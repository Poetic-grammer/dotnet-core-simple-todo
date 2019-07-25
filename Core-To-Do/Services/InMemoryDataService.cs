using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core_To_Do.Models;
using Core_To_Do.Data;

namespace Core_To_Do.Services
{
    public class InMemoryDataService : IToDoDataService
    {
        private InMemoryDBContext _dbContext;
        public InMemoryDataService(InMemoryDBContext dBContext)
        {
            this._dbContext = dBContext;

        }

        public ToDoItemModel AddToDo(string label)
        {

            int newId = 1;
            if (_dbContext.ToDoItems.Count() > 0)
            {
                newId = _dbContext.ToDoItems.Max<ToDoItemModel>(i => i.id) + 1;
            }
            var newItem = new ToDoItemModel { id = newId, label = label, completed = false };

            _dbContext.ToDoItems.Add(newItem);

            _dbContext.SaveChanges();

            return newItem;
            
        }

        public bool DeleteToDo(int id)
        {

            var targetFind = _dbContext.ToDoItems.Find(id);

            if( targetFind == null)
            {
                return false;
            }

            _dbContext.ToDoItems.Remove(targetFind);

            _dbContext.SaveChanges();

            return true;

        }

        public IEnumerable<ToDoItemModel> ListToDos()
        {
            return _dbContext.ToDoItems.Take(50).ToList();
        }

        public bool MarkCompleteToDo(int id)
        {
            var targetFind = _dbContext.ToDoItems.Find(id);

            if (targetFind == null)
            {
                return false;
            }

            targetFind.completed = true;

            _dbContext.SaveChanges();

            return true;
        }
    }
}
