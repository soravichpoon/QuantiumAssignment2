using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI2.Models
{
  public class VoteDetail
  {
    [Key]
    public int VoteDetailID { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string TopicName { get; set; } = "";

    [Column(TypeName = "nvarchar(100)")]
    public string TopicDetail { get; set; } = "";

    public ICollection<OptionDetail>? OptionDetail { get; set; }
  }
}
