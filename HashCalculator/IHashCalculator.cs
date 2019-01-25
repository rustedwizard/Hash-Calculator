using System.Threading.Tasks;

namespace HashCalculator
{
    public interface IHashCalculator
    {
        string GetHashInString(string path);
        Task<string> GetHashInStringAsync(string path);
        byte[] GetHashInByte(string path);
        Task<byte[]> GetHashInByteAsync(string path);
    }
}
