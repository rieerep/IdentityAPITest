using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityAPIWorkshop.Models
{
    public class HighscoreModel
    {

        [Key()]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public string UserId { get; set; }
        public int Score { get; set; }
    }
}
