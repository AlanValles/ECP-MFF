using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECP_MFF.Controllers.Api
{
    public class SubmController : ApiController
    {
        [HttpPost]
        [ActionName("getValues")]
        public string getValues(model e)
        {
            string msg = string.Empty;
            decimal prom = (Convert.ToInt32(e.p1Peso) + Convert.ToInt32(e.p2Sellado) + Convert.ToInt32(e.p3Apariencia) + Convert.ToInt32(e.p4Sabor) + Convert.ToInt32(e.p5Textura)) / 5;
            try
            {
                string connection = @"data source=SJLL-ALANV;initial catalog=ECP;Integrated Security=True";
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    SqlCommand cmd2 = new SqlCommand("INSERT INTO dbo.evaluaciones(numReloj,turno,regionLote,loteCorrecto,lote,codigoBarras,nombreProducto,p1Peso,p2Sellado,p3Apariencia,p4Sabor,p5Textura,promedio,fecha)" +
                                                                          "VALUES (@numReloj,@turno,@regionLote,@loteCorrecto,@lote,@codigoBarras,@nombreProducto,@p1Peso,@p2Sellado,@p3Apariencia,@p4Sabor,@p5Textura,@promedio,@fecha)",con);
                    cmd2.Parameters.AddWithValue("@numReloj", Convert.ToInt32(e.numReloj));
                    cmd2.Parameters.AddWithValue("@turno", Convert.ToString(e.turno));
                    cmd2.Parameters.AddWithValue("@regionLote", Convert.ToString(e.regionSeleccionada));
                    cmd2.Parameters.AddWithValue("@loteCorrecto", e.loteCorrecto.ToString().ToUpper());
                    cmd2.Parameters.AddWithValue("@lote", e.lote.ToString().ToUpper());
                    cmd2.Parameters.AddWithValue("@codigoBarras", e.codigoBarras.ToString().ToUpper());
                    cmd2.Parameters.AddWithValue("@nombreProducto", e.nombreProducto.ToString());
                    cmd2.Parameters.AddWithValue("@p1Peso", Convert.ToInt32(e.p1Peso));
                    cmd2.Parameters.AddWithValue("@p2Sellado", Convert.ToInt32(e.p2Sellado));
                    cmd2.Parameters.AddWithValue("@p3Apariencia", Convert.ToInt32(e.p3Apariencia));
                    cmd2.Parameters.AddWithValue("@p4Sabor", Convert.ToInt32(e.p4Sabor));
                    cmd2.Parameters.AddWithValue("@p5Textura", Convert.ToInt32(e.p5Textura));
                    cmd2.Parameters.AddWithValue("@promedio", prom);
                    cmd2.Parameters.AddWithValue("@fecha", DateTime.Now);
                    cmd2.ExecuteNonQuery();
                    con.Close();
                }
                msg = "Evaluacion terminada";
            }
            catch (Exception ex)
            {
                throw ex;
                msg = "Algo salio mal";
            }
            return msg;
        }

        public class model
        {
            public int numReloj { get; set; }
            public string turno{ get; set; }
            public string regionSeleccionada{ get; set; }
            public string loteCorrecto{ get; set; }
            public string lote { get; set; }
            public string codigoBarras { get; set; }
            public string nombreProducto { get; set; }
            public string p1Peso { get; set; }
            public string p2Sellado { get; set; }
            public string p3Apariencia { get; set; }
            public string p4Sabor { get; set; }
            public string p5Textura { get; set; }
        }


    }
}