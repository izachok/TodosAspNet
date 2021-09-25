using Microsoft.AspNetCore.Mvc;
using System.Collections;
using System.Collections.Generic;
using TodosWeb.Data;
using TodosWeb.Models;
using System.Linq;

namespace TodosWeb.Controllers
{
		public class TodoController : Controller
		{

				private readonly ApplicationDbContext _db;

				public TodoController(ApplicationDbContext db)
				{
						_db = db;
				}
				public IActionResult Index()
				{
						IEnumerable<Todo> todos = _db.Todos;
						return View(todos);
				}

				public IActionResult Create()
				{
						return View();
				}

				[HttpPost]
				[ValidateAntiForgeryToken]
				public IActionResult Create(Todo item)
				{
						if (!ModelState.IsValid)
						{
								return View(item);
						}
						_db.Todos.Add(item);
						_db.SaveChanges();
						return RedirectToAction("Index");
				}

				//GET Delete
				public IActionResult Delete(int? id)
				{
						Todo item = _db.Todos.Find(id);
						if (item == null)
						{
								return NotFound();
						}
						return View(item);
				}

				[HttpPost]
				[ValidateAntiForgeryToken]
				public IActionResult DeletePost(int? id)
				{
						Todo item = _db.Todos.Find(id);
						if (item == null)
						{
								return NotFound();
						}
						_db.Todos.Remove(item);
						_db.SaveChanges();
						return RedirectToAction("Index");
				}

				//GET Edit
				public IActionResult Edit(int? id)
				{
						Todo item = _db.Todos.Find(id);
						if (item == null)
						{
								return NotFound();
						}
						return View(item);
				}

				[HttpPost]
				[ValidateAntiForgeryToken]
				public IActionResult Edit(Todo item)
				{
						//Todo item = _db.Todos.Find(id);
						if (!ModelState.IsValid)
						{
								return View("Edit", item);
						}

						_db.Todos.Update(item);
						_db.SaveChanges();
						return RedirectToAction("Index");
				}
		}
}
