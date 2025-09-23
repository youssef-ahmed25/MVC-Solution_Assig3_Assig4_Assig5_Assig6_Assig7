namespace ServiceLifeTime.Services
{
    public interface ISingletonService
    {
        public string GetGuid();
    }
    public class SingletonService : ISingletonService
    {
        private Guid Guid;
        public SingletonService()
        {
            Guid = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return Guid.ToString();
        }
    }
}
