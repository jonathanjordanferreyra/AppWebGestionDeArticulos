using Dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class FavoritosNegocio
    {
        public void Agregar(int IdUser, int IdArticulo)
        {
            if (EsFavorito(IdUser, IdArticulo))
            {
                return;
            }
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("INSERT INTO FAVORITOS (IdUser, IdArticulo) VALUES (@idUser,@idArticulo)");
                datos.SetearParametros("idUser", IdUser);
                datos.SetearParametros("@idArticulo", IdArticulo);
                datos.EjecutarAccion();
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
        public void Eliminar(int IdUser, int IdArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("DELETE FROM FAVORITOS WHERE IdUser = @idUser AND IdArticulo = @idArticulo");
                datos.SetearParametros("@idUser", IdUser);
                datos.SetearParametros("@idArticulo", IdArticulo);
                datos.EjecutarAccion();
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

        public bool EsFavorito(int idUser, int idArticulo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT 1 FROM FAVORITOS WHERE IdUser = @idUser AND IdArticulo = @idArticulo");
                datos.SetearParametros("@IdUser", idUser);
                datos.SetearParametros("@IdArticulo", idArticulo);
                datos.EjecutarLectura();
                if (datos.Lector.Read())
                {
                    return true;
                }
                return false;
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

        public List<Articulo> ListarFavoritos(int iduser)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();
            try
            {
                datos.SetearConsulta("Select A.Id,A.Nombre,A.Codigo,A.Descripcion,A.ImagenUrl,A.Precio,A.IdMarca,A.IdCategoria,M.Descripcion as Marca,C.Descripcion as Categoria from ARTICULOS as A,MARCAS as M,CATEGORIAS as C, FAVORITOS as F where A.IdCategoria = C.Id and A.IdMarca = M.Id and a.Id = f.IdArticulo and f.IdUser = @idUser");
                datos.SetearParametros("@idUser", iduser);
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
    }
}
