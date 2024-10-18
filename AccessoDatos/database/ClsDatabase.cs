using System.Data;
using System.Data.SqlClient;

namespace AccessoDatos.database
{

    public class ClsDatabase
    {
        #region variables privadas

        private SqlConnection _objSqlConnection;
        private SqlDataAdapter _SqlDataAdapter;
        private SqlCommand _SqlCommand;
        private DataSet _resultado;
        private DataTable _parametros;

        private string nombreTabla, nombreSP, mensajeErrorDB, valorEscalar, nombreDB;
        private bool escalar;

        #endregion

        #region Variables publicas

        public SqlConnection ObjSqlConnection { get => _objSqlConnection; set => _objSqlConnection = value; }
        public SqlDataAdapter SqlDataAdapter { get => _SqlDataAdapter; set => _SqlDataAdapter = value; }
        public SqlCommand SqlCommand { get => _SqlCommand; set => _SqlCommand = value; }
        public DataSet Resultado { get => _resultado; set => _resultado = value; }
        public DataTable Parametros { get => _parametros; set => _parametros = value; }
        public string NombreTabla { get => nombreTabla; set => nombreTabla = value; }
        public string NombreSP { get => nombreSP; set => nombreSP = value; }
        public string MensajeErrorDB { get => mensajeErrorDB; set => mensajeErrorDB = value; }
        public string ValorEscalar { get => valorEscalar; set => valorEscalar = value; }
        public string NombreDB { get => nombreDB; set => nombreDB = value; }
        public bool Escalar { get => escalar; set => escalar = value; }
        #endregion


        #region constructores
        public ClsDatabase()
        {
            _parametros = new DataTable("SP_parametros");
            _parametros.Columns.Add("Nombre");
            _parametros.Columns.Add("TipoDato");
            _parametros.Columns.Add("Valor");

            NombreDB = string.Empty;
        }
        #endregion


        #region metodos privados
        private void connectionDB(ref ClsDatabase objDB)
        {

        }
        private void validateConnectionDB(ref ClsDatabase objDB)
        {

        }
        private void addParameters(ref ClsDatabase objDB)
        {

        }

        private void PrepareConnectionDB(ref ClsDatabase objDB)
        {

        }

        private void ExecDataAdapter(ref ClsDatabase objDB)
        {

        }
        private void ExecCommand(ref ClsDatabase objDB)
        {

        }

        #endregion
    }
}
