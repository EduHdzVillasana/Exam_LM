using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2.Models
{
    public class db_conn
    {
        public static string LoginCheck(Login log) //checa si email y pass es correcto
        {
            string result = "";
            using (tiendaContext db = new tiendaContext())
            {
                var usuarios = db.Usuarios.Where(s => s.Email == log.email && s.Password == log.password).ToList();
                // USO DE FUNCIONES LAMBDA
                if (usuarios.Count == 1)
                {
                    result = usuarios[0].Nombre;
                }
            }
            return result;
        } 

        public static int addArticulo (CRUD art)//agrega a la base de datos el articulo
        {
            int result = 1;
            try
            {
                using (var db = new tiendaContext())
                {
                    var articulo = new Articulo
                    {
                        Nombre = art.Nombre,
                        Precio = art.Precio,
                        Iva = art.Iva,
                        Cantidad = art.Cantidad
                    };
                    db.Add(articulo);
                    db.SaveChanges();
                }
            }
            catch (Exception e) // USO DE FRIENDLY EXCEPTION
            {
                result = 2;
            }
            return result;
        }
        public static int updateArticulo(CRUD art)
        {
            int result = 1;
            try
            {
                using (var db = new tiendaContext())
                {
                    var articulo = db.Articulos.Where(s => s.IdArticulo == art.IdArticulo).First(); // FUNCIONE LAMBDA
                    articulo.Nombre = art.Nombre;
                    articulo.Precio = art.Precio;
                    articulo.Iva = art.Iva;
                    articulo.Cantidad = art.Cantidad;
                    db.SaveChanges();
                }
            }
            catch (Exception e) // FRIENDLY EXCEPTION
            {
                result = 2;
            }
            return result;
        }
        public static int deleteArticulo(CRUD art)
        {
            int result = 1;
            try
            {
                using (var db = new tiendaContext())
                {
                    var articulo = db.Articulos.Where(s => s.IdArticulo == art.IdArticulo).First<Articulo>();
                    db.Articulos.Remove(articulo);
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = 2;
                //Console.WriteLine(e);
            }
            return result;
        }
    }
}
