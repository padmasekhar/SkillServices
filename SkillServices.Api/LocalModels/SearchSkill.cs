using System.Text;

namespace SkillServices.Api.LocalModels
{
    public class SearchSkill
    {
        public int? SkillId { get; set; }
        public int? Page { get; set; }
        public int? Rows { get; set; }
        public string? SkillName { get; set; }
        public string? SubCatName { get; set; }
        public bool IsAsc { get; set; } = true;

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            if (SkillId.HasValue)
            {
                sb.Append($"SkillId = {SkillId.Value}");
                sb.Append("; ");
            }
            if (Page.HasValue)
            {
                sb.Append($"Page = {Page.Value}");
                sb.Append("; ");
            }
            if (Rows.HasValue)
            {
                sb.Append($"Rows = {Rows.Value}");
                sb.Append("; ");
            }
            if (!string.IsNullOrEmpty(SkillName))
            {
                sb.Append($"SkillName = {SkillName}");
                sb.Append("; ");
            }

            if (!string.IsNullOrEmpty(SubCatName))
                sb.Append($"SubCatName = {SubCatName}");

            return sb.ToString();
        }
    }
}
