using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace HashCalculator
{
    public class HashCalculator
    {
        private readonly Dictionary<string, IHashCalculator> _calculator;
        public HashCalculator()
        {
            _calculator = new Dictionary<string, IHashCalculator>();
            _calculator.Add("MD5", new MD5Calculator());
            _calculator.Add("SHA1", new SHA1Calculator());
            _calculator.Add("SHA256", new SHA256Calculator());
            _calculator.Add("SHA384", new SHA384Calculator());
            _calculator.Add("SHA512", new SHA512Calculator());
            _calculator.Add("RIPEMD160", new RIPEMD160Calculator());
        }

        public string GetHashInString(string algorithm, string path)
        {

            VerifyParameter(algorithm, path);
            IHashCalculator calculator = _calculator[algorithm];
            return calculator.GetHashInString(path);
        }

        public async Task<string> GetHashInStringAsync(string algorithm, string path)
        {
            VerifyParameter(algorithm, path);
            IHashCalculator calculator = _calculator[algorithm];
            return await calculator.GetHashInStringAsync(path);
        }

        public byte[] GetHashInByte(string algorithm, string path)
        {
            VerifyParameter(algorithm, path);
            IHashCalculator calculator = _calculator[algorithm];
            return calculator.GetHashInByte(path);
        }

        public async Task<byte[]> GetHashInByteAsync(string algorithm, string path)
        {
            VerifyParameter(algorithm, path);
            IHashCalculator calculator = _calculator[algorithm];
            return await calculator.GetHashInByteAsync(path);
        }

        public async Task<bool> CompareTwoFilesHash(string algoritm, string path, string pathToCompare)
        {
            Task<byte[]> t1 = new Task<byte[]>(() => { return GetHashInByte(algoritm, path); });
            Task<byte[]> t2 = new Task<byte[]>(() => { return GetHashInByte(algoritm, pathToCompare); });
            byte[] first = await t1;
            byte[] second = await t2;
            foreach(var item in first)
            {
                foreach(var secItem in second)
                {
                   if (!item.Equals(secItem))
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private void VerifyParameter(string algorithm, string path)
        {
            if (!File.Exists(path))
            {
                throw new FileNotFoundException("File given in the path does not exist");
            }
            if (!_calculator.ContainsKey(algorithm))
            {
                throw new KeyNotFoundException("Algoritm requested is not supported");
            }
        }

        public void AddNewAlgorithm(string name, IHashCalculator hashClass)
        {
            _calculator.Add(name, hashClass);
        }
    }
}

