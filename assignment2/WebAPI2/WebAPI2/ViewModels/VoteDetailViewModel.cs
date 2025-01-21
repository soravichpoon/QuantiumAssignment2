using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI2.ViewModels
{
  public class VoteDetailViewModel
  {
    public int VoteDetailID { get; set; }

    public string TopicName { get; set; } = "";

    public string TopicDetail { get; set; } = "";
  }
}
