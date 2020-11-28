using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Examen2.Models
{
    public class db_conn
    {
        public static string LoginCheck(Login log)
        {
            string result = "";
            using (tiendaContext db = new tiendaContext())
            {
                var usuarios = db.Usuarios.Where(s => s.Email == log.email && s.Password == log.password).ToList();
                if (usuarios.Count == 1)
                {
                    result = usuarios[0].Nombre;
                }
            }
            return result;
        } 

        public static int addArticulo (Login art)
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
            catch (Exception e)
            {
                result = 2;
            }
            return result;
        }
        public static int updateArticulo(Login art)
        {
            int result = 1;
            try
            {
                using (var db = new tiendaContext())
                {
                    var articulo = db.Articulos.Where(s => s.IdArticulo == art.IdArticulo).First();
                    articulo.Nombre = art.Nombre;
                    articulo.Precio = art.Precio;
                    articulo.Iva = art.Iva;
                    articulo.Cantidad = art.Cantidad;
                    db.SaveChanges();
                }
            }
            catch (Exception e)
            {
                result = 2;
            }
            return result;
        }
        public static int deleteArticulo(Login art)
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
                Console.WriteLine(e);
            }
            return result;
        }
    }
}
