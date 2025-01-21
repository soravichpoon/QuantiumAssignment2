using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NuGet.Versioning;
using WebAPI2.Models;
using WebAPI2.ViewModels;

namespace WebAPI2.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class VotesController : ControllerBase
  {
    private readonly VoteDetailContext dbContext;
    public VotesController(VoteDetailContext dbContext)
    {
      this.dbContext = dbContext;
    }

    [HttpGet("vote")]
    public IActionResult GetAllVotes()
    {
      var allVotes = dbContext.VoteDetails.ToList();

      return Ok(allVotes);
    }

    [HttpGet("option")]
    public IActionResult GetAllOptions()
    {
      var allOptions = dbContext.OptionDetails.ToList();

      return Ok(allOptions);
    }

    [HttpPost("vote")]
    public IActionResult AddVoteDetail([FromBody]  VoteDetailViewModel voteDetailViewModel)
    {
      var voteEntity = new VoteDetail()
      {
        TopicName = voteDetailViewModel.TopicName,
        TopicDetail = voteDetailViewModel.TopicDetail,
      };

      dbContext.VoteDetails.Add(voteEntity);
      dbContext.SaveChanges();

      return Ok(voteEntity);
    }

    [HttpPost("option")]
    public IActionResult AddOptionDetail([FromBody]  OptionDetailViewModel optionDetailViewModel)
    {
      var optionEntity = new OptionDetail()
      {
        OptionName = optionDetailViewModel.OptionName,
        OptionScore = optionDetailViewModel.OptionScore,
        OptionIsVote = optionDetailViewModel.OptionIsVote,
        VoteDetailId = optionDetailViewModel.VoteDetailId
      };

      dbContext.OptionDetails.Add(optionEntity);
      dbContext.SaveChanges();

      return Ok(optionEntity);
    }

    [HttpPut("updateOption")]
    public IActionResult UpdateOptionDetail(int voteDetailId, string optionName, [FromBody] OptionDetailViewModel optionDetailViewModel)
    {
      var option = dbContext.OptionDetails.FirstOrDefault(opt => opt.VoteDetailId == voteDetailId && opt.OptionName == optionName);

      if (option is null)
      {
        return NotFound();
      }

      option.OptionScore = optionDetailViewModel.OptionScore;

      dbContext.SaveChanges();
      return Ok(option);
    }
  }
}
