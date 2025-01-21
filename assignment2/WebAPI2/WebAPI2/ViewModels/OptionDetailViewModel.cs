using System.ComponentModel.DataAnnotations.Schema;
using WebAPI2.Models;


namespace WebAPI2.ViewModels
{
  public class OptionDetailViewModel
  {
    public int OptionID { get; set; }

    public string OptionName { get; set; } = "";

    public int OptionScore { get; set; }

    public bool OptionIsVote { get; set; }

    public int? VoteDetailId { get; set; }
  }
}
