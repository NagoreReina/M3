using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstExample.Models;

namespace FirstExample.Controllers
{
    public class EmpleadosController : Controller
    {
        public IActionResult Index(string nombre)
        {
            List<Empleado> empleados = new List<Empleado>()
            {
                new Empleado
                {
                    Id = 1,
                    Nombre = "Nagore",
                    Apellido = "Reina",
                    FechaNacimiento = Convert.ToDateTime("11/04/1995"),
                    Imagen = "https://ge13.gipuzkoaencounter.org/images/opengune_2019/NagoreReina.jpg"
                },
                new Empleado
                {
                    Id = 2,
                    Nombre = "Sergio",
                    Apellido = "Reina",
                    FechaNacimiento = Convert.ToDateTime("29/05/1996"),
                    Imagen = "https://media.licdn.com/dms/image/C5603AQHKUCVPAPEYDQ/profile-displayphoto-shrink_200_200/0?e=1579132800&v=beta&t=hq0q64vCKWJFMYj9Se-FrQAPj0w9bQMY34yqP8TRm3k"
                },
                new Empleado
                {
                    Id = 3,
                    Nombre = "Andre",
                    Apellido = "Garcia",
                    FechaNacimiento = Convert.ToDateTime("05/06/1995"),
                    Imagen = "https://scontent-mad1-1.cdninstagram.com/vp/cbbb37a28419a89fb3f216dd7c18bb17/5E5E36C3/t51.2885-19/s320x320/71738946_785023935273252_3495487158511206400_n.jpg?_nc_ht=scontent-mad1-1.cdninstagram.com"
                },
                new Empleado
                {
                    Id = 4,
                    Nombre = "Josu",
                    Apellido = "Etxebarrena",
                    FechaNacimiento = Convert.ToDateTime("03/07/1998"),
                    Imagen = "https://scontent-mad1-1.xx.fbcdn.net/v/t1.0-1/p160x160/49092838_2434541023440350_2118208343456612352_n.jpg?_nc_cat=111&_nc_oc=AQlQk3guB3rc3cfl-NR6wOCZwvdtfTBQV5mtSfaVz4Jlke0AouD2jjDX7j3PvRu5xhk&_nc_ht=scontent-mad1-1.xx&oh=e74a72db0218ffb268fd1dac60a8833a&oe=5E63426B"
                },
                new Empleado
                {
                    Id = 5,
                    Nombre = "Nazan",
                    Apellido = "Haba",
                    FechaNacimiento = Convert.ToDateTime("08/06/1992"),
                    Imagen = "https://scontent.fmad3-8.fna.fbcdn.net/v/t1.0-1/c142.35.436.436a/s160x160/168667_107247616016403_7729488_n.jpg?_nc_cat=101&_nc_oc=AQk5i_4uxo1pmFEbeVt3CWW5xSZnGwun4AVqdmvt5CvF2gCgrlfpYggVrQmSisXirGU&_nc_ht=scontent.fmad3-8.fna&oh=5bac6bfc9ec06dc353cae5f3088bd157&oe=5E613833"
                },
            };
            //empleados = empleados.Where(x =>  x.Nombre[0] == 'N').ToList();
            if (!String.IsNullOrEmpty(nombre))
            {
                empleados = empleados.Where(x => x.Nombre.ToLower().Contains(nombre.ToLower())).ToList();
            }
            return View(empleados);
        }
        public IActionResult Detalle()
        {
            Empleado empleado = new Empleado
            {
                Id = 1,
                Nombre = "Nagore",
                Apellido = "Reina",
                FechaNacimiento = Convert.ToDateTime("11/04/1995"),
                Imagen = "https://ge13.gipuzkoaencounter.org/images/opengune_2019/NagoreReina.jpg",
            };

            return View(empleado);
        }
    }
}