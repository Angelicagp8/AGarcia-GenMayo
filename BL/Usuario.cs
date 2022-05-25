using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Usuario
    {
        public static ML.Result Add(ML.Usuario usuario)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection context = new SqlConnection(DL.Conexion.GetConnection()))
                {
                    string query = "INSERT INTO [Usuario]([Nombre],[ApellidoPaterno],[ApellidoMaterno] ,[Sexo],[CURP])VALUES (@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Sexo,@CURP)";

                    SqlCommand cmd = new SqlCommand();
                    cmd.CommandText = query;
                    cmd.Connection = context;

                    SqlParameter[] collection = new SqlParameter[5];

                    collection[0] = new SqlParameter("@Nombre", System.Data.SqlDbType.VarChar);
                    collection[0].Value = usuario.Nombre;

                    collection[1] = new SqlParameter("@ApellidoPaterno", System.Data.SqlDbType.VarChar);
                    collection[1].Value = usuario.ApellidoPaterno;

                    collection[2] = new SqlParameter("@ApellidoMaterno", System.Data.SqlDbType.VarChar);
                    collection[2].Value = usuario.ApellidoMaterno;

                    collection[3] = new SqlParameter("@Sexo", System.Data.SqlDbType.Char);
                    collection[3].Value = usuario.Sexo;

                    collection[4] = new SqlParameter("@CURP", System.Data.SqlDbType.VarChar);
                    collection[4].Value = usuario.CURP;

                    cmd.Parameters.AddRange(collection);
                    cmd.Connection.Open();

                    int RowsAffected = cmd.ExecuteNonQuery();
                    if (RowsAffected > 0)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }

                }
                
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;

            }
            return result;
        }
    }
}
