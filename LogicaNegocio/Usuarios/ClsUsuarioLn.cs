using System;
using System.Data;
using AccessoDatos.database;
using Entidades.Usuarios;

namespace LogicaNegocio.Usuarios
{
    public class ClsUsuarioLn
    {
        #region variables privadas
        ClsDatabase objDB = null;
        #endregion 

        #region metodo index

        public void Index(ref ClsUsuario objUsuario)
        {
            objDB = new ClsDatabase()
            {
                NombreTabla = "usuario",
                NombreSP ="",
                Escalar = false

            };
            exec(ref objUsuario);
        }
        #endregion
        #region metodos CRUD





        #endregion

        #region metodo privado
        private void exec(ref ClsUsuario objUsuario)
        {
            objDB.CRUD (ref objDB);
            if (objDB.MensajeErrorDB == null)
            {
                if (objDB.Escalar)
                {
                    objUsuario.ValorEscalar = objDB.ValorEscalar;
                }
                else
                {
                    objUsuario.DbResultado = objDB.Resultado.Tables[0];
                    if (objUsuario.DbResultado.Rows.Count == 1) {
                        foreach (DataRow item in objUsuario.DbResultado.Rows)
                        {
                            objUsuario.Id=Convert.ToInt32(item["ID"].ToString());
                            objUsuario.IdEmpleado = Convert.ToInt32(item["id_empleado"].ToString());
                            objUsuario.Username = item["ususario"].ToString();
                            objUsuario.Password = item["contra"].ToString();
                            objUsuario.Fecha_creacion = Convert.ToDateTime(item["fecha_creacion"].ToString());



                        }
                    }
                }
            }
            else
            {
                objUsuario.MensajeError = objDB.MensajeErrorDB;

            }

        }
        #endregion
    }
}
