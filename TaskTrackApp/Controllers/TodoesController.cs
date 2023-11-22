using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TaskTrackerApp.Models;
using TaskTrackerApp.Models.Services;
using TaskTracker.Data;
using TaskTrackerApp.Models.Interfaces;
using Microsoft.AspNetCore.Hosting;

namespace TaskTrackerApp.Controllers
{
    public class TodoesController : Controller
    {

        private readonly ITodo _todo;
        public TodoesController(ITodo context)
        {
            _todo = context;
        }

        // GET: Todoes
        public async Task<IActionResult> Index()
        {
            var returnLsitTasks = await _todo.GetAllTasks();
            return View(returnLsitTasks);
        }

        // GET: Todoes/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null || await _todo.GetAllTasks() == null)
            {
                return NotFound();
            }

            var taskDetails = await _todo.GetTaskById(id);
            if (taskDetails == null)
            {
                return NotFound();
            }

            return View(taskDetails);
        }

        // GET: Todoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Todoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TaskTodoId,TaskTodoName,TaskTodoDescription,TaskTodoDate")] Todo todo)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _todo.CreateNewTask(todo);
                    TempData["success"] = "Task added successfully";
                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex)
                {
                    // Log the exception if needed
                    TempData["error"] = "An error occurred while adding the Task";
                    return View(todo);
                }
            }

            return View(todo);
        }

        // GET: Todoes/Edit/5
        public async Task<IActionResult> Edit(int Id)
        {
            if (Id == null)
            {
                return NotFound();
            }

            var todo = await _todo.GetTaskById(Id);
            if (todo == null)
            {
                return NotFound();
            }
            return View(todo);
        }

        // POST: Todoes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int TaskTodoId, [Bind("TaskTodoId,TaskTodoName,TaskTodoDescription,TaskTodoDate")] Todo todo)
        {
            if (TaskTodoId != todo.TaskTodoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _todo.UpdateTask(TaskTodoId, todo);
                    TempData["success"] = "Task updated successfully";
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (await TodoExists(todo.TaskTodoId) == false)
                    {
                        return NotFound();
                    }
                    else
                    {
                        TempData["error"] = "An error occurred while updating the Task";
                        return View(todo);
                    }
                }
                catch (Exception ex)
                {
                    // Log the exception if needed
                    TempData["error"] = "An unexpected error occurred while updating the Task";
                    return View(todo);
                }
            }

            return View(todo);
        }

        private async Task<bool> TodoExists(int id)
        {
            if (await _todo.GetTaskById(id) == null)
            {
                return false;
            }
            return true;
        }

        #region API CALLS
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            List<Todo> todoList = await _todo.GetAllTasks();
            return Json(new { data = todoList });
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(int id)
        {
            var taskToBeDeleted = await _todo.GetTaskById(id);

            if (taskToBeDeleted == null)
            {
                return Json(new { success = false, message = "Error while deleting" });
            }

            _todo.DeleteTask(id);

            return Json(new { success = true, message = "Delete Successful" });
        }

        #endregion
    }
}
