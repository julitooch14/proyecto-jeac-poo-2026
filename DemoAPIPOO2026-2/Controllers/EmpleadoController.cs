using DemoAPIPOO2026_2.DTOs;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using System.Collections.Generic;

namespace DemoAPIPOO2026_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        public static List<Empleado> listaEmpleados = new List<Empleado>()
        {
            new Empleado()
            {
                Id=1,
                Nombre = "Juan",
                Apellido = "Velasquez"
            },
            new Empleado()
            {
                Id=2,
                Nombre = "Salome",
                Apellido = "Cardona"
            },
            new Empleado()
            {
                Id=3,
                Nombre = "Isabela",
                Apellido = "Osorio"
            },
            new Empleado()
            {
                Id=4,
                Nombre = "Steven",
                Apellido = "Gomez"
            }

        };
        public EmpleadoController() { 
            
        }

        
        //[HttpGet("{id}")]
        [HttpGet("GetEmpleadoPorId")]
        public IActionResult GetEmpleadoPorId(int id)
        {
            var empleado = listaEmpleados.Where(item=>item.Id == id).FirstOrDefault();
            
            return Ok(empleado);
        }

        [HttpGet("GetEmpleadoPorNombre")]
        public IActionResult GetEmpleadoPorNombre(string nombre)
        {
            var empleados = listaEmpleados.Where(item => item.Nombre.ToLower().Contains(nombre.ToLower())).ToList();

            return Ok(empleados);
        }



        [HttpGet("ObtenerTodosLosEmpleados")]
        public IActionResult GetEmpleados() { 
            return Ok(listaEmpleados);
        }
        
        

        [HttpPost]
        public IActionResult AddEmpleado(EmpleadoDTO empleadoDto)
        {

            int nuevoId = listaEmpleados.Count + 1;

            var empleadoBD = new Empleado();
            empleadoBD.Id = nuevoId;
            empleadoBD.Nombre = empleadoDto.Nombre;
            empleadoBD.Apellido = empleadoDto.Apellido;

            listaEmpleados.Add(empleadoBD);
            return StatusCode(StatusCodes.Status201Created);
        }

    }
}
