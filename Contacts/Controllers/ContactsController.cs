using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contacts.Models.DB;
using Contacts.Data.DataAccess;
using Microsoft.AspNetCore.Authorization;

namespace Contacts.Controllers
{
    [Authorize]
    public class ContactsController : Controller
    {
        private readonly IContactsData _mydata;

        public ContactsController(IContactsData mydata)
        {
            _mydata = mydata;
        }

        [AllowAnonymous]
        // GET: Contacts
        public async Task<IActionResult> Index(string searchString)
        {
            var contacts = _mydata.ListContacts(searchString);
            ViewData["searchString"] = searchString;
            return View(contacts);
        }

        [AllowAnonymous]
        // GET: Contacts/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var theContact = _mydata.GetContact(id);
            if (id == null || theContact == null)
            {
                return NotFound();
            }

            return View(theContact);
        }

        // GET: Contacts/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contacts/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Firstname,Lastname,Phone,InternalPhone,Fax,Post,PersonnelId,WorkPlace")] Contact contact)
        {
            if (ModelState.IsValid)
            {
                var ms = _mydata.CreateContact(contact);
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // get: contacts/edit/5
        public IActionResult Edit(int id)
        {

            var contact = _mydata.GetContact(id);
            if (id == null || contact == null)
            {
                return NotFound();
            }
            return View(contact);
        }

        // POST: Contacts/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ContactId, Firstname,Lastname,Phone,InternalPhone,Fax,Post,PersonnelId,WorkPlace")] Contact contact)
        {

            if (ModelState.IsValid)
            {
                try
                {
                    _mydata.EditContact(contact);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_mydata.ContactExists(contact.ContactId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contact);
        }

        // GET: Contacts/Delete/5
        public IActionResult Delete(int id)
        {
            var contact = _mydata.GetContact(id);
            if (id == null || contact == null)
            {
                return NotFound();
            }

            return View(contact);
        }

        // POST: Contacts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {

            var contact = _mydata.GetContact(id);
            if (contact != null)
            {
                _mydata.DeleteContact(contact);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
