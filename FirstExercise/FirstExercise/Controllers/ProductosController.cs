using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FirstExercise.Models;

namespace FirstExercise.Controllers
{
    public class ProductosController : Controller
    {
        List<Producto> productos = new List<Producto>()
        {
            new Producto(){Id= 0, Nombre = "Patatas Fritas", Descripcion= "Crujientes y saldas", Tipo= "Aperitivo", Precio = 1.99, FechaCaducidad = Convert.ToDateTime("11/11/2024"), Imagen = "https://sc02.alicdn.com/kf/HTB134lRXjvuK1Rjy0Faq6x2aVXaW/plastic-lays-potato-chips-paper-bag-for.jpg_350x350.jpg"},
            new Producto(){Id= 1, Nombre = "Croquetas de Setas", Descripcion= "Las mejores croquetas que jamas probarás", Tipo= "Congelado", Precio = 3.95 , FechaCaducidad = Convert.ToDateTime("11/11/2022"), Imagen = "https://s2.eestatic.com/2019/04/22/cocinillas/actualidad-gastronomica/Croquetas-Mercadona-Actualidad_gastronomica_392971612_121039744_854x640.jpg"},
            new Producto(){Id= 2, Nombre = "Platos de plastico", Descripcion= "Articulo util para fiestas o eventos", Tipo= "Utensilios", Precio = 0.75, FechaCaducidad = Convert.ToDateTime("11/11/2023"), Imagen = "https://www.coenba.com/1962-large_default/caja-de-300-platos-pl%C3%A1stico-ps-blancos-25-cms.jpg"},
            new Producto(){Id= 3, Nombre = "Hamburguesa de guisantes", Descripcion= "Hamburguesas 100% vegetales", Tipo= "Nevera", Precio = 2.99, FechaCaducidad = Convert.ToDateTime("11/11/2029"), Imagen = "https://info.mercadona.es/img-cont/es/hamburguesas-guisantes-y-espinacas.jpg"},
            new Producto(){Id= 4, Nombre = "Helado de vainilla", Descripcion= "Rico rico y fresquito", Tipo= "Congelado", Precio = 2.75, FechaCaducidad = Convert.ToDateTime("11/11/2027"), Imagen = "https://static.ideal.es/www/multimedia/201804/30/media/cortadas/avena2-knPG-U501774712917WDF-624x385@Ideal.jpg"},
            new Producto(){Id= 5, Nombre = "Alubias a la Jardinera", Descripcion= "Como la de la abuela", Tipo= "Conservas", Precio = 1.25, FechaCaducidad = Convert.ToDateTime("11/11/2021"), Imagen = "https://static.openfoodfacts.org/images/products/848/000/026/1144/front_es.13.full.jpg"},
            new Producto(){Id= 6, Nombre = "Boniato asado", Descripcion= "Patata dulce asada", Tipo= "Nevera", Precio = 0.99, FechaCaducidad = Convert.ToDateTime("11/11/2026"), Imagen = "https://info.mercadona.es/img-cont/es/batata-congelada-lista-para-hornear-o-freir-min.jpg"},
            new Producto(){Id= 7, Nombre = "Lasaña vegetal", Descripcion= "Facil de preparar en microondas", Tipo= "Nevera", Precio = 3.59, FechaCaducidad = Convert.ToDateTime("11/11/2028"), Imagen = "https://1.bp.blogspot.com/-Z6372_zwhJk/WJPS87vnGSI/AAAAAAAABsY/Bfbbmlc2zgUweUc5XWdLnuvRlJ0AKeLnQCLcB/s1600/28730657.png"},
            new Producto(){Id= 8, Nombre = "Pizza vegetal", Descripcion= "apto para veganos e intolerantes a la lactosa", Tipo= "Nevera", Precio = 2.59, FechaCaducidad = Convert.ToDateTime("11/11/2020"), Imagen = "https://www.noticiasde.info/sites/default/files/inline-images/Captura%20de%20pantalla%202019-06-26%20a%20las%2020.15.30.jpg"},
            new Producto(){Id= 9, Nombre = "Salchichas Veganas", Descripcion= "Preparado a base de soja", Tipo= "Nevera", Precio = 1.25, FechaCaducidad = Convert.ToDateTime("11/10/2020"), Imagen = "https://1.bp.blogspot.com/-CaNrXkSERjY/W83chwUn93I/AAAAAAAAF-U/vInrwOs1Xkcw2s5MtoEgD85ZRyE4I2VFACKgBGAs/s1600/salchichas-vegana-hacendado-mercadona-1.jpg"},
        };
        public IActionResult Index()
        {
            return View(productos.OrderBy(x=> x.Nombre).ToList());
        }
        public IActionResult ProductosPrecio()
        {
            return View(productos.OrderBy(x => x.Precio).ToList());
        }
        public IActionResult ProductosTipo()
        {
            return View(productos.OrderBy(x => x.Tipo).ToList());
        }
        public IActionResult Favoritos()
        {
            return View(productos);
        }
    }
}