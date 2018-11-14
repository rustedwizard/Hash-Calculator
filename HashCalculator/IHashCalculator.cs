namespace HashCalculator
{
    public interface IHashCalculator
    {
        string GetHashInString(string path);
        string GetHashInStringAsync(string path);
        byte[] GetHashInByte(string path);
        byte[] GetHashInByteAsync(string path);
    }
}
