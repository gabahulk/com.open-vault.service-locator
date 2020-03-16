namespace OpenVault.Tools
{
    public interface IServiceLocator
    {
        void ClearAllServices();
        void DeregisterService<T>(T service) where T : class;
        object GetService<T>() where T : class;
        void RegisterService<T>(T serviceObject) where T : class;
    }
}