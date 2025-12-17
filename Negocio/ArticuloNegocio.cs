using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> ListarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("Select A.Id,A.Nombre,A.Codigo,A.Descripcion,A.ImagenUrl,A.Precio,A.IdMarca,A.IdCategoria,M.Descripcion as Marca,C.Descripcion as Categoria from ARTICULOS as A,MARCAS as M,CATEGORIAS as C where A.IdCategoria = C.Id and A.IdMarca = M.Id");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo articulo = new Articulo();
                    //Valido si no es null, conforme si la columna admite un DBNULL.
                    articulo.Id = (int)datos.Lector["Id"];
                    if (datos.Lector["Nombre"] != DBNull.Value)
                    {
                        articulo.Nombre = (string)datos.Lector["Nombre"];
                    }
                    if (datos.Lector["Codigo"] != DBNull.Value)
                    {
                        articulo.Codigo = (string)datos.Lector["Codigo"];
                    }
                    if (datos.Lector["Descripcion"] != DBNull.Value)
                    {
                        articulo.Descripcion = (string)datos.Lector["Descripcion"];
                    }
                    if (datos.Lector["ImagenUrl"] != DBNull.Value)
                    {
                        articulo.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }
                    if (datos.Lector["Precio"] != DBNull.Value)
                    {
                        articulo.Precio = (decimal)datos.Lector["Precio"];
                    }

                    articulo.Marca = new Marca();
                    if (datos.Lector["IdMarca"] != DBNull.Value)
                    {
                        articulo.Marca.Id = (int)datos.Lector["IdMarca"];
                    }
                    if (datos.Lector["Marca"] != DBNull.Value)
                    {
                        articulo.Marca.Descripcion = (string)datos.Lector["Marca"];
                    }
                    articulo.Categoria = new Categoria();
                    if (datos.Lector["IdCategoria"] != DBNull.Value)
                    {
                        articulo.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    }
                    if (datos.Lector["Categoria"] != DBNull.Value)
                    {
                        articulo.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }

                    lista.Add(articulo);

                }

                return lista;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        public Articulo BuscarArticulo(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("Select A.Id,A.Nombre,A.Codigo,A.Descripcion,A.ImagenUrl,A.Precio,A.IdMarca,A.IdCategoria,M.Descripcion as Marca,C.Descripcion as Categoria from ARTICULOS as A,MARCAS as M,CATEGORIAS as C where A.IdCategoria = C.Id and A.IdMarca = M.Id and A.Id = @id");
                datos.SetearParametros("@id", id);
                datos.EjecutarLectura();
                Articulo aux = new Articulo();
                if (datos.Lector.Read())
                {
                    aux.Id = id;
                    if (datos.Lector["Nombre"] != DBNull.Value)
                    {
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    }
                    if (datos.Lector["Codigo"] != DBNull.Value)
                    {
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    }
                    if (datos.Lector["Descripcion"] != DBNull.Value)
                    {
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    }
                    if (datos.Lector["ImagenUrl"] != DBNull.Value)
                    {
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }
                    if (datos.Lector["Precio"] != DBNull.Value)
                    {
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    }

                    aux.Marca = new Marca();
                    if (datos.Lector["IdMarca"] != DBNull.Value)
                    {
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    }
                    if (datos.Lector["Marca"] != DBNull.Value)
                    {
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    }
                    aux.Categoria = new Categoria();
                    if (datos.Lector["IdCategoria"] != DBNull.Value)
                    {
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    }
                    if (datos.Lector["Categoria"] != DBNull.Value)
                    {
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
                }
                else
                {
                    return null;
                }
                return aux;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        public List<Articulo> BuscarPorNombre(string nombreArticulo)
        {
            List<Articulo> ListaFiltrada = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("Select A.Id,A.Nombre,A.Codigo,A.Descripcion,A.ImagenUrl,A.Precio,A.IdMarca,A.IdCategoria,M.Descripcion as Marca,C.Descripcion as Categoria from ARTICULOS as A,MARCAS as M,CATEGORIAS as C where A.IdCategoria = C.Id and A.IdMarca = M.Id and A.Nombre LIKE @nombre");
                datos.SetearParametros("@nombre", "%" + nombreArticulo + "%");
                datos.EjecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Id = (int)datos.Lector["Id"];
                    if (datos.Lector["Nombre"] != DBNull.Value)
                    {
                        aux.Nombre = (string)datos.Lector["Nombre"];
                    }
                    if (datos.Lector["Codigo"] != DBNull.Value)
                    {
                        aux.Codigo = (string)datos.Lector["Codigo"];
                    }
                    if (datos.Lector["Descripcion"] != DBNull.Value)
                    {
                        aux.Descripcion = (string)datos.Lector["Descripcion"];
                    }
                    if (datos.Lector["ImagenUrl"] != DBNull.Value)
                    {
                        aux.ImagenUrl = (string)datos.Lector["ImagenUrl"];
                    }
                    if (datos.Lector["Precio"] != DBNull.Value)
                    {
                        aux.Precio = (decimal)datos.Lector["Precio"];
                    }

                    aux.Marca = new Marca();
                    if (datos.Lector["IdMarca"] != DBNull.Value)
                    {
                        aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    }
                    if (datos.Lector["Marca"] != DBNull.Value)
                    {
                        aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    }
                    aux.Categoria = new Categoria();
                    if (datos.Lector["IdCategoria"] != DBNull.Value)
                    {
                        aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    }
                    if (datos.Lector["Categoria"] != DBNull.Value)
                    {
                        aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    }
                    ListaFiltrada.Add(aux);
                }
                return ListaFiltrada;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
