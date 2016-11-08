using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Web;

namespace LoginSignup.Models
{
    public class TripModel
    {
        public CodeDB DB = new CodeDB();

        public int id { get; set; }

        [Required]
        public string source { get; set; }

        [Required]
        public string destination { get; set; }
        
        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public /*DateTime*/string date { get; set; }

        //[Required]
        public string created_by
        {
            get
            {
                SqlDataReader userId = null;
                bool bRet = DB.Open();
                if (bRet)
                {
                    string query = "select Id from AspNetUsers where Email = '" + HttpContext.Current.User.Identity.Name + "'";
                    userId = DB.DataRetrieve(query);
                }

                userId.Read();
                return userId["Id"].ToString();
            }
        }

        [Required]
        public bool carAvailable { get; set; }
        
        public string description { get; set; }
        
        public int vacant_seats { get; set; }
        
        public float estimated_cost { get; set; }
    }
}