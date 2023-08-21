using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SkillServices.Data.DbModels
{
    [Table("tblSkillCategories")]
    public class SkillCategory
    {
        public SkillCategory()
        {
            SubCategories = new HashSet<SkillSubCategory>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int SkillCategoryId { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }

        public ICollection<SkillSubCategory>? SubCategories { get; set; }
    }
}
