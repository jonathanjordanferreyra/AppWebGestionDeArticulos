using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class UsuarioNegocio
    {
        public Usuario Login(string email, string password)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.SetearConsulta("SELECT Id, email, pass,nombre,apellido,urlImagenPerfil,admin FROM USERS WHERE email = @Email and pass = @Pass");
                datos.SetearParametros("@Email", email);
                datos.SetearParametros("@Pass", password);
                datos.EjecutarLectura();
                if (datos.Lector.Read())
                {
                    Usuario usuario = new Usuario();
                    usuario.Id = (int)datos.Lector["Id"];
                    usuario.Email = (string)datos.Lector["email"];
                    usuario.Pass = (string)datos.Lector["pass"];
                    if (datos.Lector["nombre"] != DBNull.Value)
                    {
                        usuario.Nombre = (string)datos.Lector["nombre"];
                    }
                    if (datos.Lector["apellido"] != DBNull.Value)
                    {
                        usuario.Apellido = (string)datos.Lector["apellido"];
                    }
                    if (datos.Lector["urlImagenPerfil"] != DBNull.Value)
                    {
                        usuario.UrlImagenPerfil = (string)datos.Lector["urlImagenPerfil"];
                    }
                    usuario.Admin = (bool)datos.Lector["admin"];
                    return usuario;
                }
                //Si no encuentra, retorna null.
                return null;
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
        public int Registrarse(Usuario user)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                //Verifico si existe un email en la base de datos
                datos.SetearConsulta("SELECT Id FROM USERS WHERE Email = @Email");
                datos.SetearParametros("@Email", user.Email);
                datos.EjecutarLectura();

                if (datos.Lector.Read())
                {
                    // Si ingresa existe un usuario con ese email.
                    return 0;
                }
                datos.CerrarConexion();

                //Si no encuentra un user pasa por acá
                datos = new AccesoDatos();
                datos.SetearConsulta("INSERT INTO USERS (email,pass,nombre,admin) output inserted.Id VALUES (@email,@pass,@nombre,@admin)");
                datos.SetearParametros("@email", user.Email);
                datos.SetearParametros("@pass", user.Pass);
                datos.SetearParametros("@nombre", user.Nombre);
                datos.SetearParametros("@admin", 0);
                return datos.EjecutarSacalar();

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
