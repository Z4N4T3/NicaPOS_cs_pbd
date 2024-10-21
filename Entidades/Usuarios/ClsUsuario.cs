using System;
using System.Data;

namespace Entidades.Usuarios
{
    public class ClsUsuario
    {
        #region Atributos privados
            private int _id, _idEmpleado;
            private string _username,_password;
            private DateTime _fecha_creacion;

        // atributos del manejo de datos

        private String _mensajeError, _valorEscalar;
        private DataTable _dbResultado;
        #endregion

        #region Atributos publicos

        public int Id { get => _id; set => _id = value; }
        public int IdEmpleado { get => _idEmpleado; set => _idEmpleado = value; }
        public string Username { get => _username; set => _username = value; }
        public string Password { get => _password; set => _password = value; }
        public DateTime Fecha_creacion { get => _fecha_creacion; set => _fecha_creacion = value; }
        public string MensajeError { get => _mensajeError; set => _mensajeError = value; }
        public string ValorEscalar { get => _valorEscalar; set => _valorEscalar = value; }
        public DataTable DbResultado { get => _dbResultado; set => _dbResultado = value; }
        #endregion

        #region
        #endregion
    }
}
