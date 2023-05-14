using Microsoft.AspNetCore.Mvc;
using System.Data.SqlClient;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace hanamohamed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public List<string> GetEmpById(string id)
        {
            List<string> employees = new List<string>();
            string connectionString = "Data Source=YOUSSEFSENOUSY;Initial Catalog=AdventureWorks2016;User ID=sa;Password=P@ssw0rd; Integrated Security=true";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("SELECT BusinessEntityID, NationalIDNumber, OrganizationLevel, JobTitle, BirthDate," +
                    " MaritalStatus, Gender, HireDate, ModifiedDate FROM  HumanResources.Employee WHERE(NationalIDNumber = '" + id + "')", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string NationalIDNo = reader["NationalIDNumber"].ToString();
                    string OrganizationLevel = reader["OrganizationLevel"].ToString();
                    string JobTitle = reader["JobTitle"].ToString();
                    string BirthDate = reader["BirthDate"].ToString();
                    string MaritalStatus = reader["MaritalStatus"].ToString();
                    string Gender = reader["Gender"].ToString();
                    string HireDate = reader["HireDate"].ToString();
                    string ModifiedDate = reader["ModifiedDate"].ToString();
                    employees.Add(NationalIDNo);
                    employees.Add(OrganizationLevel);
                    employees.Add(JobTitle);
                    employees.Add(BirthDate);
                    employees.Add(MaritalStatus);
                    employees.Add(Gender);
                    employees.Add(HireDate);
                    employees.Add(ModifiedDate);
                }
            }
            return employees;
        }
    }
    }

