#define RELEASE
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace HashCalculator
{
    public static class HashCalculator
    {
        public static string ComputeHash(string hashAlgorithm, string path)
        {
            try
            {
                using (var fileStream = File.OpenRead(path))
                {
                    switch (hashAlgorithm)
                    {
                        case "SHA1":
                            using (var sha1 = HMACSHA1.Create())
                            {
                                return ByteArrayToString(sha1.ComputeHash(fileStream));
                            }
                        case "SHA384":
                            using (var sha384 = HMACSHA384.Create())
                            {
                                return ByteArrayToString(sha384.ComputeHash(fileStream));
                            }
                        case "SHA256":
                            using (var sha256 = HMACSHA256.Create())
                            {
                                return ByteArrayToString(sha256.ComputeHash(fileStream));
                            }
                        case "SHA512":
                            using (var sha512 = HMACSHA512.Create())
                            {
                                return ByteArrayToString(sha512.ComputeHash(fileStream));
                            }
                        case "MD5":
                            using (var md5 = MD5.Create())
                            {
                                return ByteArrayToString(md5.ComputeHash(fileStream));
                            }
                        case "RIPEMD160":
                            using (var ripemd160 = RIPEMD160.Create())
                            {
                                return ByteArrayToString(ripemd160.ComputeHash(fileStream));
                            }
                        //if defualt ever gets called 
                        //there is a great change that the string hashAlgorithm is not right
                        //so throws exception
                        //CAUTION: HANDLE THIS EXCEPTION WHEN USE THIS METHOD!!!
                        default:
#if DEBUG
                            var exception = new System.Exception("Error: Something is wrong, may be the hash algorithm request is not supported.");
                            Debug.Write(exception.ToString());
                            throw exception;
#elif RELEASE
                            throw new System.Exception("Error: Something is wrong, may be the hash algorithm request is not supported.");
#endif
        
                    }
                }
            }
            //thows exception if path is not correct!
            //CAUTION: HANDLE THIS EXCEPTION WHEN USE THIS METHOD!!!
            catch (FileNotFoundException ex)
            {
#if DEBUG
                Debug.Write(ex.ToString());
#endif
                throw ex;
            }

            //Local Function
            //Hash computed by this method in default returns a byte array
            //this method transfer it into string representation
            string ByteArrayToString(byte[] input)
            {
                StringBuilder result = new StringBuilder();
                foreach (var item in input)
                {
                    result.Append(item.ToString("X2"));
                }
                return result.ToString();
            }
        }

        public async static Task<string> ComputeHashAsync(string hashAlgorithm, string path)
        {
            try
            {
                return await Task.Run(() =>
                {
                    return ComputeHash(hashAlgorithm, path);
                });
            }
            catch(FileNotFoundException ex)
            {
                throw ex;
            }catch(System.Exception e)
            {
                throw e;
            }
        }
    }
}
