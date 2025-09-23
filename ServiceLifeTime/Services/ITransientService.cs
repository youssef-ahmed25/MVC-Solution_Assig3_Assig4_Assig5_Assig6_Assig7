namespace ServiceLifeTime.Services
{
    public interface ITransientService
    {
        public string GetGuid();
    }
    public class TransientService : ITransientService
    {
        private Guid Guid;
        public TransientService()
        {
            Guid = Guid.NewGuid();
        }
        public string GetGuid()
        {
            return Guid.ToString();
        }
    }
}
