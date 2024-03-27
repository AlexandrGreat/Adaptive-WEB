using LR6.Interfaces;
using LR6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace LR6.Services
{
    public class DatabaseService:IDatabaseService
    {
        public async Task<JsonResult> Get(string conLine)
        {
            SqlConnection con = new SqlConnection(conLine);
            SqlDataAdapter da = new SqlDataAdapter("Select * from ProductsLR6", con);
            DataTable dt = new DataTable();
            da.Fill(dt);
            List<DatabaseObjectSampleModel> objects = new List<DatabaseObjectSampleModel>();
            if (dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DatabaseObjectSampleModel model = new DatabaseObjectSampleModel();
                    model.ID = Convert.ToInt32(dt.Rows[i]["ID"]);
                    model.PublisherID = Convert.ToInt32(dt.Rows[i]["PublisherID"]);
                    model.Name = Convert.ToString(dt.Rows[i]["Name"]);
                    model.Rating = Convert.ToDouble(dt.Rows[i]["Rating"]);
                    model.Downloads = Convert.ToInt32(dt.Rows[i]["Downloads"]);
                    objects.Add(model);
                }
            }
            if (objects.Count > 0)
                return new JsonResult(objects);
            else
            {
                return new JsonResult(null);
            }
        }
    }
}
