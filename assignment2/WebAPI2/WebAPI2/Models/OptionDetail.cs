using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace WebAPI2.Models
{
  public class OptionDetail
  {
    [Key]
    public int OptionID { get; set; }

    [Column(TypeName = "nvarchar(100)")]
    public string OptionName { get; set; } = "";

    [Column(TypeName = "int")]
    public int OptionScore { get; set; }

    [Column(TypeName = "bit")]
    public bool OptionIsVote { get; set; }

    [ForeignKey("VoteDetailID")]
    public int? VoteDetailId { get; set; }
  }
}
