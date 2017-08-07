using EmptyWebApiProject.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmptyWebApiProject.Controllers
{
    public class LoginController : ApiController
    {
        [Route("api/Views/Login/SignIn")]
        [HttpPost]
        public HttpResponseMessage SignIn([FromBody]User user)
        {
          
            try
            {
                SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
                conn.Open();
                var checkuser = "select userName,password from Login where userName= '" + user.Username + "' and password='" + user.Password + "'";
                var com1 = new SqlCommand(checkuser, conn);
                string name = com1.ExecuteScalar().ToString().Replace(" ", "");
                conn.Close();
                if (name.Equals(null))
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Utilizator inexistent");
                }
                else
                {
                return Request.CreateResponse(HttpStatusCode.OK,user);
                }
            
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
