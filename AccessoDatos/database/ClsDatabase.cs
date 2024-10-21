using System;
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

            NombreDB = "DB_NicaPOS";
        }
        #endregion


        #region metodos privados
        private void connectionDB(ref ClsDatabase objDB)
        {
            // permite la conexion de multiples BD
            switch (objDB.nombreDB)
            {
                case "DB_NicaPOS":
                    objDB.ObjSqlConnection = new SqlConnection(Properties.Settings.Default.StringConnection_DB_NicaPOS); 
                    break;
                default:
                    break;
            }
        }
        private void validateConnectionDB(ref ClsDatabase objDB)
        {
            if (objDB.ObjSqlConnection.State == ConnectionState.Closed)
            {
                objDB.ObjSqlConnection.Open();

            }
            else
            {
                objDB.ObjSqlConnection.Close(); // cierra la conexion 
                objDB.ObjSqlConnection.Close(); // quita la conexion de memoria

            }
        }
        private void addParameters(ref ClsDatabase objDB)
        {
            if (objDB.Parametros != null)
            {
                SqlDbType TipoDatoSQL = new SqlDbType();
                foreach (DataRow item in objDB.Parametros.Rows)
                {
                    switch (item[1])
                    {
                        case "1":
                            TipoDatoSQL = SqlDbType.Bit;
                            break;
                        case "2": // Integer
                            TipoDatoSQL = SqlDbType.Int;
                            break;
                        case "3": // Small Integer
                            TipoDatoSQL = SqlDbType.SmallInt;
                            break;
                        case "4": // Tiny Integer
                            TipoDatoSQL = SqlDbType.TinyInt;
                            break;
                        case "5": // Big Integer
                            TipoDatoSQL = SqlDbType.BigInt;
                            break;
                        case "6": // Decimal
                            TipoDatoSQL = SqlDbType.Decimal;
                            break;
                        case "7": // Float
                            TipoDatoSQL = SqlDbType.Float;
                            break;
                        case "8": // Real
                            TipoDatoSQL = SqlDbType.Real;
                            break;
                        case "9": // Char
                            TipoDatoSQL = SqlDbType.Char;
                            break;
                        case "10": // VarChar
                            TipoDatoSQL = SqlDbType.VarChar;
                            break;
                        case "11": // NChar
                            TipoDatoSQL = SqlDbType.NChar;
                            break;
                        case "12": // NVarChar
                            TipoDatoSQL = SqlDbType.NVarChar;
                            break;
                        case "13": // Text
                            TipoDatoSQL = SqlDbType.Text;
                            break;
                        case "14": // NText
                            TipoDatoSQL = SqlDbType.NText;
                            break;
                        case "15": // Binary
                            TipoDatoSQL = SqlDbType.Binary;
                            break;
                        case "16": // VarBinary
                            TipoDatoSQL = SqlDbType.VarBinary;
                            break;
                        case "17": // Date
                            TipoDatoSQL = SqlDbType.Date;
                            break;
                        case "18": // DateTime
                            TipoDatoSQL = SqlDbType.DateTime;
                            break;
                        case "19": // SmallDateTime
                            TipoDatoSQL = SqlDbType.SmallDateTime;
                            break;
                        case "20": // Time
                            TipoDatoSQL = SqlDbType.Time;
                            break;
                        case "21": // DateTime2
                            TipoDatoSQL = SqlDbType.DateTime2;
                            break;
                        case "22": // DateTimeOffset
                            TipoDatoSQL = SqlDbType.DateTimeOffset;
                            break;
                        case "23": // UniqueIdentifier (GUID)
                            TipoDatoSQL = SqlDbType.UniqueIdentifier;
                            break;
                        case "24": // XML
                            TipoDatoSQL = SqlDbType.Xml;
                            break;
                        case "25": // Money
                            TipoDatoSQL = SqlDbType.Money;
                            break;
                        case "26": // SmallMoney
                            TipoDatoSQL = SqlDbType.SmallMoney;
                            break;
                        case "27": // Image (deprecated)
                            TipoDatoSQL = SqlDbType.Image;
                            break;
                        case "28": // Timestamp
                            TipoDatoSQL = SqlDbType.Timestamp;
                            break;
                        default:
                            break;
                    }
                    if (objDB.Escalar)
                    {
                        if (item[2].ToString().Equals(string.Empty))
                        {
                            objDB.SqlCommand.Parameters.Add(item[0].ToString(),TipoDatoSQL).Value = DBNull.Value;
                        }
                        else
                        {
                            objDB.SqlCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = item[2].ToString();

                        }
                    }
                    else
                    {
                        if (item[2].ToString().Equals(string.Empty))
                        {
                            objDB.SqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = DBNull.Value;
                        }
                        else
                        {
                            objDB.SqlDataAdapter.SelectCommand.Parameters.Add(item[0].ToString(), TipoDatoSQL).Value = item[2].ToString();

                        }
                    }
                }
                }
            }

        private void PrepareConnectionDB(ref ClsDatabase objDB)
        {
            connectionDB(ref objDB);
            validateConnectionDB(ref objDB);
        }

        private void ExecDataAdapter(ref ClsDatabase objDB)
        {
            try
            {
                PrepareConnectionDB(ref objDB);
                objDB.SqlDataAdapter = new SqlDataAdapter(objDB.NombreSP, objDB.ObjSqlConnection);
                objDB.SqlDataAdapter.SelectCommand.CommandType = CommandType.StoredProcedure;
                addParameters(ref objDB);
                objDB.Resultado=new DataSet();
                objDB.SqlDataAdapter.Fill(objDB.Resultado, objDB.nombreTabla);


            }
            catch (System.Exception ex)
            {
                objDB.mensajeErrorDB = ex.Message;
            }
            finally
            {
                if(objDB.ObjSqlConnection.State == ConnectionState.Open)
                {
                    validateConnectionDB(ref objDB);
                }

            }

        }
        private void ExecCommand(ref ClsDatabase objDB)
        {
            try
            {
                PrepareConnectionDB(ref objDB);
                objDB.SqlCommand = new SqlCommand(objDB.nombreDB, objDB.ObjSqlConnection)
                {
                    CommandType = CommandType.StoredProcedure
                };
                addParameters(ref objDB);
                if (objDB.Escalar)
                {
                    objDB.ValorEscalar = objDB.SqlCommand.ExecuteScalar().ToString().Trim();
                }
                else {
                    objDB.SqlCommand.ExecuteNonQuery();
                }
            }
            catch
            (System.Exception ex)
            {

                objDB.mensajeErrorDB = ex.Message.ToString();
                
            }
            finally
            {
                if (objDB.ObjSqlConnection.State == ConnectionState.Open)
                {
                    validateConnectionDB(ref objDB);
                }
            }
        }


        #endregion

        #region Metodos publicos

        public void CRUD(ref ClsDatabase objDB)
        {
            if (objDB.Escalar)
            {
                ExecCommand(ref objDB);
            }
            else
            {
                ExecDataAdapter(ref objDB);
            }
        }
        #endregion
    }
}
