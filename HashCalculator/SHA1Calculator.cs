﻿using System.IO;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace HashCalculator
{
    internal class SHA1Calculator : IHashCalculator
    {
        private byte[] _result;
        private void ComputeHash(string path)
        {
            using (var fileStream = File.OpenRead(path))
            {
                using (var hasher = SHA1.Create())
                {
                    _result = hasher.ComputeHash(fileStream);
                }
            }
        }

        private async Task<byte[]> ComputeHashAsync(string path)
        {
            using (var fileStream = File.OpenRead(path))
            {
                using (var hasher = SHA1.Create())
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

        public async Task<string> GetHashInStringAsync(string path)
        {
            _result = await ComputeHashAsync(path);
            return Util.ByteArrayToString(_result);
        }

        public byte[] GetHashInByte(string path)
        {
            ComputeHash(path);
            return _result;
        }

        public async Task<byte[]> GetHashInByteAsync(string path)
        {

            _result = await ComputeHashAsync(path);
            return _result;
        }
    }
}
