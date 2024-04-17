using Microsoft.EntityFrameworkCore;

namespace RWM.Domain.Models.Entities
{
    [PrimaryKey(nameof(Section), nameof(Key))]
    public class Configuration
    {
        public string Section { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
        public string? Description { get; set; }
    }
}
