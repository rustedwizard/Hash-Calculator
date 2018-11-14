using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HashCalculator
{
    internal class SHA256Calculator : IHashCalculator
    {
        private byte[] _result;
        private void ComputeHash(string path)
        {
            using (var fileStream = File.OpenRead(path))
            {
                using (var hasher = HMACSHA256.Create())
                {
                    _result = hasher.ComputeHash(fileStream);
                }
            }
        }

        private async Task<byte[]> ComputeHashAsync(string path)
        {
            using (var fileStream = File.OpenRead(path))
            {
                using (var hasher = HMACSHA256.Create())
                {
                    return await Task.Run(() =>
                    {
                        return hasher.ComputeHash(fileStream);
                    });
                }
            }
        }

        public string GetHashInString(string path)
        {
            ComputeHash(path);
            return Util.ByteArrayToString(_result);
        }

        public string GetHashInStringAsync(string path)
        {
            _result = ComputeHashAsync(path).Result;
            return Util.ByteArrayToString(_result);
        }

        public byte[] GetHashInByte(string path)
        {
            ComputeHash(path);
            return _result;
        }

        public byte[] GetHashInByteAsync(string path)
        {

            _result = ComputeHashAsync(path).Result;
            return _result;
        }
    }
}
