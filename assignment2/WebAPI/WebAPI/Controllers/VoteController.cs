using System.Data;
using System.Data.SqlClient;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
  [ApiController]
  public class VoteController : ControllerBase
  {
    private IConfiguration _configuration;
    public VoteController(IConfiguration configuration)
    {
      _configuration = configuration;
    }

    [HttpGet("get_votes")]
    public JsonResult get_votes()
    {
      string query = "select * from VoteDetails";
      DataTable table = new DataTable();
      string SqlDatasource = _configuration.GetConnectionString("mydb");
      SqlDataReader myReader;
      using (SqlConnection myCon = new SqlConnection(SqlDatasource))
      {
        myCon.Open();
        using(SqlCommand myCommand=new SqlCommand(query, myCon))
        {
          myReader=myCommand.ExecuteReader();
          table.Load(myReader);
        }
      }

      return new JsonResult(table);
    }

    [HttpGet("get_option")]
    public JsonResult get_option()
    {
      string query = "select * from OptionDetail";
      DataTable table = new DataTable();
      string SqlDatasource = _configuration.GetConnectionString("mydb");
      SqlDataReader myReader;
      using (SqlConnection myCon = new SqlConnection(SqlDatasource))
      {
        myCon.Open();
        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        {
          myReader = myCommand.ExecuteReader();
          table.Load(myReader);
        }
      }

      return new JsonResult(table);
    }

    [HttpPost("add_vote")]
    public JsonResult add_vote([FromForm] string topicName, [FromForm] string topicDetail)
    {
      string query = "insert into VoteDetails values (@topicName, @topicDetail)";
      DataTable table = new DataTable();
      string SqlDatasource = _configuration.GetConnectionString("mydb");
      SqlDataReader myReader;
      using (SqlConnection myCon = new SqlConnection(SqlDatasource))
      {
        myCon.Open();
        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        {
          myCommand.Parameters.AddWithValue("@topicName", topicName);
          myCommand.Parameters.AddWithValue("@topicDetail", topicDetail);
          myReader = myCommand.ExecuteReader();
          table.Load(myReader);
        }
      }

      return new JsonResult("Added Successfully");
    }

    [HttpPost("add_option")]
    public JsonResult add_option([FromForm] string optionDetail, [FromForm] string voteDetailID)
    {
      string query = "insert into OptionDetail values (@optionDetail, @optionScore, @optionIsVote, @voteDetailID)";
      DataTable table = new DataTable();
      string SqlDatasource = _configuration.GetConnectionString("mydb");
      SqlDataReader myReader;
      using (SqlConnection myCon = new SqlConnection(SqlDatasource))
      {
        myCon.Open();
        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        {
          myCommand.Parameters.AddWithValue("@optionDetail", optionDetail);
          myCommand.Parameters.AddWithValue("@optionScore", 0);
          myCommand.Parameters.AddWithValue("@optionIsVote", 0);
          myCommand.Parameters.AddWithValue("@voteDetailID", voteDetailID);
          myReader = myCommand.ExecuteReader();
          table.Load(myReader);
        }
      }

      return new JsonResult("Added Successfully");
    }

    [HttpPost("update_vote")]
    public JsonResult update_vote([FromForm] string id, [FromForm] string score, [FromForm] string detail)
    {
      string query = "update OptionDetail set OptionScore=@score where (VoteDetailID=@id and OptionDetail=@detail)";
      DataTable table = new DataTable();
      string SqlDatasource = _configuration.GetConnectionString("mydb");
      SqlDataReader myReader;
      using (SqlConnection myCon = new SqlConnection(SqlDatasource))
      {
        myCon.Open();
        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        {
          myCommand.Parameters.AddWithValue("@id", id);
          myCommand.Parameters.AddWithValue("@score", score);
          myCommand.Parameters.AddWithValue("@detail", detail);
          myReader = myCommand.ExecuteReader();
          table.Load(myReader);
        }
      }

      return new JsonResult("Updated Successfully");
    }

    [HttpPost("delete_vote")]
    public JsonResult delete_vote([FromForm] string id)
    {
      string query = "delete from VoteDetails where VoteDetailID=@id";
      DataTable table = new DataTable();
      string SqlDatasource = _configuration.GetConnectionString("mydb");
      SqlDataReader myReader;
      using (SqlConnection myCon = new SqlConnection(SqlDatasource))
      {
        myCon.Open();
        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        {
          myCommand.Parameters.AddWithValue("@id", id);
          myReader = myCommand.ExecuteReader();
          table.Load(myReader);
        }
      }

      return new JsonResult("Deleted Successfully");
    }

    [HttpPost("delete_option")]
    public JsonResult delete_option([FromForm] string id)
    {
      string query = "delete from VoteDetails where VoteDetailID=@id";
      DataTable table = new DataTable();
      string SqlDatasource = _configuration.GetConnectionString("mydb");
      SqlDataReader myReader;
      using (SqlConnection myCon = new SqlConnection(SqlDatasource))
      {
        myCon.Open();
        using (SqlCommand myCommand = new SqlCommand(query, myCon))
        {
          myCommand.Parameters.AddWithValue("@id", id);
          myReader = myCommand.ExecuteReader();
          table.Load(myReader);
        }
      }

      return new JsonResult("Deleted Successfully");
    }
  }
}
