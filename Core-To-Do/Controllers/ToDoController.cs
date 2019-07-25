using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Core_To_Do.Services;
using Core_To_Do.Models;

namespace Core_To_Do.Controllers
{
    
    [ApiController]
    public class ToDoController : Controller
    {
        private IToDoDataService dataService;
        public ToDoController(IToDoDataService dataService)
        {
            this.dataService = dataService;
        }
        [Route("api/todo/add")]
        [HttpPost]
        public JsonResult Add([FromBody] string toDoLabel)
        {

            ToDoItemModel result = dataService.AddToDo(toDoLabel);

            return Json(result);
        }


        [Route("api/todo/complete")]
        [HttpPost]
        public JsonResult MarkComplete([FromBody] int id)
        {

            if (dataService.MarkCompleteToDo(id))
            {
                return Json(new { updated = true });
            } else
            {
                return Json(new { updated = false });
            }
        }

        [Route("api/todo/delete")]
        [HttpPost]
        public JsonResult Delete([FromBody] int id)
        {

            if (dataService.DeleteToDo(id))
            {
                return Json(new { updated = true });
            }
            else
            {
                return Json(new { updated = false });
            }
        }




    }
}