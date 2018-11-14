using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HashCalculator
{
    internal class MD5Calculator : IHashCalculator
    {
        private byte[] _result;
        private void ComputeHash(string path)
        {
            using (FileStream fileStream = File.OpenRead(path))
            {
                using (MD5 hasher = MD5.Create())
                {
                    _result = hasher.ComputeHash(fileStream);
                }
            }
        }

        private async Task<byte[]> ComputeHashAsync(string path)
        {
            using (FileStream fileStream = File.OpenRead(path))
            {
                using (MD5 hasher = MD5.Create())
                {
                    return await Task.Run(() =>
                    {
                        return hasher.ComputeHash(fileStream);
                    });
                }
            }
        }

        private async void GetResultAsync(string path)
        {
            _result = await ComputeHashAsync(path);
        }

        public string GetHashInString(string path)
        {
            ComputeHash(path);
            return Util.ByteArrayToString(_result);
        }

        public string GetHashInStringAsync(string path)
        {
            GetResultAsync(path);
            return Util.ByteArrayToString(_result);
        }

        public byte[] GetHashInByte(string path)
        {
            ComputeHash(path);
            return _result;
        }

        public byte[] GetHashInByteAsync(string path)
        {

            GetResultAsync(path);
            return _result;
        }
    }
}
