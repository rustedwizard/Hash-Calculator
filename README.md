# Hash-Calculator

## Nuget package: HashCalculator Version 2.0.0

**This version is still in test, it haven't been uploaded yet**

**CAUTION: HashCalculator 2.0 package introduce breaking change, the usage of this package is very different now!**

In this version the HashCalculator now fully support computing hash for any given file asynchronously and provide the ability to extend the support of other hash algorithms
by a simple implementation of an interface.

## Following Hash algorithm is supported out of box

* SHA1
* SHA256
* SHA384
* SHA512
* RIPEMD160
* MD5

## Usage

In version 2.0.0.0, this package now contain a class called HashCalculator, all the hash computing function can be accessed from here.

Todo this, simple follow the following steps:

* First of all, install HashCalculator version 2.0.0.0. (Of course, otherwise you wouldn't be here)!

* In your program you need create a new object in type of HashCalculator.

* After object creation, your will have choice to get hash code in string or in byte array byte[]. Also you have choice to choose whether compute hash synchronously and asynchronously.

* To get hash in string simply call GetHashInString("Algorithm", "Path/To/Your/File") or GetHashInStringAsync("Algorithm", "PATH/TO/YOUR/FILE") accordingly, as in previous version, you can simple pass name of algorithm as "MD5", "SHA1" etc.

* Similarly, get hash in byte[] simply call GetHashInByte("Algorithm", "Path/To/Your/File") or GetHashInByteAsync("Algorithm", "PATH/TO/YOUR/FILE") accordingly.

* In this version, you will also be able to directly compare 2 files' hash. Simply call CompareTwoFilesHash(string algoritm, string path, string pathToCompare), this method returns bool value represents if two files' hash are same.

* To extend the support of other algorithm, simply implement the interface called IHashCalculator. You will need to implement 4 methods:

    * string GetHashInString(string path)

    * string GetHashInStringAsync(string path)

    * byte[] GetHashInByte(string path)

    * byte[] GetHashInByteAsync(string path)

* After this simply call AddNewAlgorithm(string name, IHashCalculator hashClass)

    * parameter name: the name of the algorithm, this will be used as algorithm name.

    * parameter hashClass: instance of class which implement the IHashCalculator interface.

# HashCalculator Version 1.x.x.x

## Nuget package: HashCalculator Version 1.1.1.6

This is a simple Hash code calculator library targeting .Net Framework 4.7.2. It provides support of calculating hash code of
any file and return its hash code in string representation.

## Following Hash algorithm is supported

* SHA1
* SHA256
* SHA384
* SHA512
* RIPEMD160
* MD5

## Usage

 This nuget package is fairly simple and straight forward. It contains one simple static class and two method ComputeHash and ComputeHashAsync.

 To use, simply add the nuget package in your project by:

* From Package management console in Visual Studio: Install-Package HashCalculator -Version 1.1.1.6

* From Dotnet CLI: dotnet add package HashCalculator --version 1.1.1.6
 and call the function in your program: HashCalculator.HashCalculator.ComputeHash("ALGORITHM","PATH/TO/YOUR/FILE")

* To pass algorithm simple pass it in String as "SHA1", "SHA256", "SHA384", "SHA512", "RIPEMD160", "MD5".

* Please **be aware** that ComputeHash method throws FileNotFoundExceptions for incorrect path to file
  and Exception for possible wrong algorithm name.
