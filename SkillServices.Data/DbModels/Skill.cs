using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillServices.Data.DbModels
{
    [Table("tblSkills")]
    public class Skill
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SkillId { get; set; }
        public string Name { get; set; }

        public bool IsActive { get; set; } = true;

        public int? SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]
        public SkillSubCategory? SubCategory { get; set; }

    }
}
