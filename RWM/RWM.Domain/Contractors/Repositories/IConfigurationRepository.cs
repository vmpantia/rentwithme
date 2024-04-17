namespace RWM.Domain.Contractors.Repositories
{
    public interface IConfigurationRepository
    {
        TProperty GetValue<TProperty>(string section, string key);
    }
}