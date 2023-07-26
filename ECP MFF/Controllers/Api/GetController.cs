using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ECP_MFF.Controllers.Api
{
    public class GetController : ApiController
    {
        [HttpPost]
        [ActionName("getInfo")]
        public string getInfo(mod e)
        {
            DataTable dt = new DataTable();
            string descrip = string.Empty;
            dt = getVal("SELECT descripcion FROM dbo.machote WHERE codigoBarras='"+e.codigoBarras.ToString().ToUpper()+"'");
            if (dt.Rows.Count>0)
            {
                descrip = dt.Rows[0][0].ToString();
            }
            else
            {
                descrip = "Producto no encontrado";
            }
            return descrip;
        }
        public DataTable getVal(string qry)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string connection = @"data source=SJLL-ALANV;initial catalog=ECP;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd2 = new SqlCommand(qry, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                da.Fill(dataTable);
                con.Close();
                return dataTable;
                               
            }
            catch (Exception)
            {
                throw;
            }            
        }

        [HttpPost]
        [ActionName("getInfoRow")]
        public IEnumerable<reportReturn> getInfoRow(dataReturn e)
        {
            DateTime dtIni = Convert.ToDateTime(e.fechaIni).Date;
            DateTime dtFin = Convert.ToDateTime(e.fechaFin).Date;
            DataTable dt = getValRow("SELECT * FROM dbo.evaluaciones WHERE codigoBarras='" + e.codigoBarras.ToString().ToUpper() + "'");

            foreach (DataRow row in dt.Rows)
            {
                yield return new reportReturn
                {
                    ID = row["id"] is DBNull ? 0 : Convert.ToInt32(row["id"]),
                    codigoBarras = row["codigoBarras"] is DBNull ? "" : row["codigoBarras"].ToString(),
                    numReloj = row["numReloj"] is DBNull ? 0 : Convert.ToInt32(row["numReloj"]),
                    turno = row["turno"] is DBNull ? "" : row["turno"].ToString(),
                    regionLote = row["regionLote"] is DBNull ? "" : row["regionLote"].ToString(),
                    loteCorrecto = row["loteCorrecto"] is DBNull ? "" : row["loteCorrecto"].ToString(),
                    lote= row["lote"] is DBNull ? "" : row["lote"].ToString(),
                    nombreProducto = row["nombreProducto"] is DBNull ? "" : row["nombreProducto"].ToString(),
                    p1Peso = row["p1Peso"] is DBNull ? "" : row["p1Peso"].ToString(),
                    p2Sellado = row["p2Sellado"] is DBNull ? "" : row["p2Sellado"].ToString(),
                    p3Apariencia = row["p3Apariencia"] is DBNull ? "" : row["p3Apariencia"].ToString(),
                    p4Sabor = row["p4Sabor"] is DBNull ? "" : row["p4Sabor"].ToString(),
                    p5Textura = row["p5Textura"] is DBNull ? "" : row["p5Textura"].ToString(),
                    promedio = row["promedio"] is DBNull ? "" : row["promedio"].ToString(),
                    fecha = Convert.ToDateTime(row["fecha"]).ToLongDateString()
                };
            }
        }
        public DataTable getValRow(string qry)
        {
            try
            {
                DataTable dataTable = new DataTable();
                string connection = @"data source=SJLL-ALANV;initial catalog=ECP;Integrated Security=True";
                SqlConnection con = new SqlConnection(connection);
                con.Open();
                SqlCommand cmd2 = new SqlCommand(qry, con);
                SqlDataAdapter da = new SqlDataAdapter(cmd2);
                da.Fill(dataTable);
                con.Close();
                return dataTable;

            }
            catch (Exception)
            {
                throw;
            }
        }


        public class mod
        {
            public string codigoBarras { get; set; }
        }

        public class dataReturn
        {
            public string codigoBarras { get; set; }
            public string fechaIni { get; set; }
            public string fechaFin { get; set; }
        }

        public class reportReturn
        {
            public int ID { get; set; }
            public string codigoBarras { get; set; }            
            public int numReloj { get; set; }
            public string turno { get; set; }
            public string regionLote { get; set; }
            public string loteCorrecto { get; set; }
            public string lote{ get; set; }
            public string nombreProducto { get; set; }
            public string p1Peso { get; set; }
            public string p2Sellado { get; set; }
            public string p3Apariencia { get; set; }
            public string p4Sabor { get; set; }
            public string p5Textura { get; set; }
            public string promedio { get; set; }
            public string fecha { get; set; }
        }
    }
}