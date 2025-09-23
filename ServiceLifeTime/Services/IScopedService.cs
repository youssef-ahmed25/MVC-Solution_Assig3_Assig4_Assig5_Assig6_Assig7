namespace ServiceLifeTime.Services
{
    public interface IScopedService
    {
        public string GetGuid();
    }
    public class ScopedService : IScopedService
    {
        private Guid Guid;
        public ScopedService()
        {
            Guid = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return Guid.ToString();
        }
    }
}
