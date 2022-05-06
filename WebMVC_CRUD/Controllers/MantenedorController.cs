using Microsoft.AspNetCore.Mvc;
using WebMVC_CRUD.Data;
using WebMVC_CRUD.Models;

namespace WebMVC_CRUD.Controllers {
    public class MantenedorController : Controller {
        ContactoData contactData = new ContactoData();

        /* Muestra lista de contactos */
        public IActionResult Listar() {
            var lista = contactData.Listar();

            return View(lista);
        }

        /* Devuelve la vista de formulario */
        public IActionResult Guardar() {
            return View();
        }

        /* Recibe el Objeto Contacto y lo guarda a la BD */
        [HttpPost]
        public IActionResult Guardar(ContactoModel contactoModel) {
            /* Hace validaciones en los campos requeridos */
            if (!ModelState.IsValid) {
                return View();
            }

            var resp = contactData.Guardar(contactoModel);

            if (resp) {
                return RedirectToAction("Listar");
            } else {
                return View();
            }
        }

        /* Devuelve la vista de formulario */
        public IActionResult Editar(int idContacto) {
            var contacto = contactData.Obtener(idContacto);

            return View(contacto);
        }

        [HttpPost]
        public IActionResult Editar(ContactoModel contactoModel) {
            if (!ModelState.IsValid) {
                return View();
            }

            var resp = contactData.Editar(contactoModel);

            if (resp) {
                return RedirectToAction("Listar");
            } else {
                return View();
            }
        }

        /* Devuelve la vista de formulario */
        public IActionResult Eliminar(int idContacto) {
            var contacto = contactData.Obtener(idContacto);

            return View(contacto);
        }

        [HttpPost]
        public IActionResult Eliminar(ContactoModel contactoModel) {
            var resp = contactData.Eliminar(contactoModel.IdContacto);

            if (resp) {
                return RedirectToAction("Listar");
            } else {
                return View();
            }
        }
    }
}
