using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillServices.Data.DbModels
{
    [Table("tblSkillSubCategories")]
    public class SkillSubCategory
    {
        public SkillSubCategory()
        {
            Skills = new HashSet<Skill>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SubCategoryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public int? SkillCategoryId { get; set; }
        [ForeignKey("SkillCategoryId")]
        public SkillCategory? Category { get; set; }

        public ICollection<Skill>? Skills { get; set; }
    }
}
