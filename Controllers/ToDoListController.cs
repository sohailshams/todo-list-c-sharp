using Microsoft.AspNetCore.Mvc;
using ToDoList.Api.Models;
using ToDoList.Api.Repositories;

namespace ToDoList.Api.Controllers
{
    [ApiController]
    [Route("ToDoList")]
    public class ToDoListController : ControllerBase
    {
        private TaskRepository _tasks;

        public ToDoListController(TaskRepository tasks)
        {
            _tasks = tasks;
        }

        [HttpGet]
        [Route("/items")]
        public ActionResult<ToDoListItem> GetToDoList()
        {
            var tasks = _tasks.GetAllTasks();

            return Ok(tasks);
        }

        [HttpGet]
        [Route("/item/{id}")]

        public ActionResult<ToDoListItem> GetItem(int id)

        {
            var task = _tasks.GetTask(id);
            if (task == null)
            {
                return NotFound("Task Could not be found!");
            }
            return Ok(task);

        }

        [HttpPost]
        [Route("/item")]

        public ActionResult<ToDoListItem> PostItem([FromBody] AddToDoListItem addItem)
        {
            var newTask = _tasks.PostTask(addItem.Title, addItem.Description);
            if (newTask == null)
            {
                return Problem("There was an error while adding a task in the DB!");
            }
            return Ok(newTask);

        }

        [HttpDelete]
        [Route("/item")]

        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ToDoListItem> DeleteItem(int id)
        {
            var task = _tasks.DeleteTask(id);
            if (task != null)
            {
                return Ok(task);
            }
            return UnprocessableEntity("There was an error while deleting this task!");
        }


        [HttpPost]
        [Route("/updateItem")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<ToDoListItem> UpdateItem([FromBody] UpdateToDoListItem request)
        {
            var task = _tasks.UpdateTask(request.Id, request.Title, request.Description);
            if (task != null)
            {
                return Ok(task);
            }
            return UnprocessableEntity("There was an error while updating this task!");
        }
    }
}
