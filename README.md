# Hash-Calculator
Nuget package: Install-Package HashCalculator -Version 1.0.0 

This is a simple Hash code calculator library targeting .Net Framwork 4.7.2. It provides support of calculating hash code of
any file and return its hash code in string representation.

##Following Hash algorithm is supported.
  * 1. SHA1
  * 2. SHA256
  * 3. SHA384
  * 4. SHA512
  * 5. RIPEMD160
  * 6. MD5
  
 ##Usage:
 
 This nuget package is fairly simple and straight forward. It conatains one simple static class and One method ComputeHash.
 
 To use, simple add the nuget package in your project by:
 
  * 1.From Package management console in Visual Studio: Install-Package HashCalculator -Version 1.0.0 
  
  * 2.From Dotnet CLI: dotnet add package HashCalculator --version 1.0.0 
 and call the function in your program: HashCalculator.HashComputer.ComputeHash("PATH/TO/YOUT/FILE", "ALGORITHM")
 
  * 3. If the file you need to calculate its hash is going to be very large in size, you may consider do this asynchronously by 
  calling ComputeHashAsync("PATH/TO/YOUR/FILE", "ALGORITHM")
  
  * 4. To pass algorithm simple pass it in String as "SHA1", "SHA256", "SHA384", "SHA512", "RIPEMD160", "MD5".
  
  * 5. Please be aware that both synchronous method and asynchronous method throws FileNotFoundExceptions for incorrect path to file
  and Exception for possible wrong algorithm name.
