using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using appW.Models;

namespace appW.Controllers
{
    public class EmpregadoController : Controller
    {
        testarEntities cobj = new testarEntities(); // GET: Empregado
        
        public ActionResult AddEmpregado()
        {
            EmpregadoModel obj = new EmpregadoModel();

            return View("AddEmpregado");
        }

        [HttpPost]
        public ActionResult AddEmpregado(EmpregadoModel obj)
        {
            
            cobj.empregadoTs.Add(new empregadoT() { nome=obj.nome, departamento=obj.departamento});
            cobj.SaveChanges();
            return View("AddEmpregado", obj);
        }

        public ActionResult MostrarEmpregado()
        {
           
            var empregadosG = cobj.empregadoTs.ToList();
            return View("MostrarEmpregado", empregadosG);
        }

        public ActionResult EditarEmpregado(int empregadoid)
        {
           
            var empregadoSH = (from item in cobj.empregadoTs where item.empregadoID == empregadoid select item).First();
            return View("EditarEmpregado", empregadoSH);
        }
        [HttpPost]
        public ActionResult EditarEmpregado(empregadoT obj)
        {
           
            var empregadoSH = (from item in cobj.empregadoTs where item.empregadoID == obj.empregadoID select item).First();

            empregadoSH.empregadoID = obj.empregadoID;
            empregadoSH.nome = obj.nome;
            empregadoSH.departamento = obj.departamento;
            cobj.SaveChanges();

            var empregadosG = cobj.empregadoTs.ToList();
            return View("MostrarEmpregado", empregadosG);
        }
        public ActionResult EliminarEmpregado(int empregadoid)
        {
           
            var empregadoSH = (from item in cobj.empregadoTs where item.empregadoID == empregadoid select item).First();
            cobj.empregadoTs.Remove(empregadoSH);
            cobj.SaveChanges();
            var empregadosG = cobj.empregadoTs.ToList();
            return View("MostrarEmpregado", empregadosG);
        }
    }
}
