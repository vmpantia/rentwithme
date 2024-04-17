using RWM.Domain.Contractors.Repositories;
using RWM.Domain.Models.Entities;
using RWM.Infrastructure.Databases.Contexts;
using System.Linq.Expressions;

namespace RWM.Infrastructure.Databases.Repositories
{
    public class ConfigurationRepository : BaseRepository<Configuration>, IConfigurationRepository
    {
        public ConfigurationRepository(RWMDbContext context) : base(context) { }

        public TProperty GetValue<TProperty>(string section, string key) =>
            GetValue<TProperty>(data => data.Section == section && data.Key == key);

        private TProperty GetValue<TProperty>(Expression<Func<Configuration, bool>> expression)
        {
            var config = GetByExpression(expression)
                            .FirstOrDefault();

            if (config == null) return default(TProperty);

            return (TProperty)Convert.ChangeType(config.Value, typeof(TProperty));
        }
    }
}
