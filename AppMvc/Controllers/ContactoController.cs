using Microsoft.AspNetCore.Mvc;
using AppMvc.Datos;
using AppMvc.Models;

namespace AppMvc.Controllers
{
    public class ContactoController : Controller
    {

        ContactoDatos _contactoDatos=new ContactoDatos();
        public IActionResult Listar()
        {
            //LA VISTA MOSTRARA UNA LISTA DE CONTACTOS
            var contactos = _contactoDatos.Lista();
            return View(contactos);
        }
        public IActionResult Guardar()
        {
            //DEVUEVE UNA VISTA
            return View();
        }
        [HttpPost]
        public IActionResult Guardar(ContactoModel contacto)
        {
            //RECIBE UN OBJETO PARA GUARDARLO EN BD

            if (!ModelState.IsValid)
            {
                return View();
            }
            var respuesta=_contactoDatos.Guardar(contacto);

            if (respuesta)
            {
                return RedirectToAction("Listar");
            }
            else
            return View();
        }
        /*
        public IActionResult Editar()
        {
            return View();

        }

        public IActionResult Eliminar()
        {
            return View();
        }*/
    }
}
