namespace FinanceServices.Interfaces
{
    public interface IFileProvider
    {
        void Write(string path, string value);

        string Read(string path);
    }
}
