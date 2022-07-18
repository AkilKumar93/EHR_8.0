using System;
using System.Text;
using System.Security.Cryptography;
using System.IO;
using System.Runtime.InteropServices;
namespace client
{
	public class CryptoFunctions
	{
        public CryptoFunctions()
		{
			
		}
        
        /// <param name="Algorithm">the Algorithm of choice. 0 for MD5, 1 for SHA-1</param>
		public string HashString(string strToHash, int Algorithm)
		{
            System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
            byte[] bytes = ue.GetBytes(strToHash);
            string hashString = "";
  
            if (Algorithm == 1) // SHA1
			{
  
				//  Compute Hash
				SHA1CryptoServiceProvider SHA = new SHA1CryptoServiceProvider();
                byte[] hashBytes = SHA.ComputeHash(bytes);
  
				// Convert the hash bytes back to a string (base 16)
			
                //for(int i=0;i<hashBytes.Length;i++)
                //{
                //    hashString += Convert.ToString(hashBytes[i],16).PadLeft(2,'0');
                //}
                hashString = Convert.ToBase64String(hashBytes,0,hashBytes.Length );   
				//return hashString.PadLeft(32,'0');
			}
			else
			{
				//return encryptString(strToEncryp);
            
                // Compute MD5 Hash 
                System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hashBytes = md5.ComputeHash(bytes);

                // Convert the hash bytes back to a string (base 16)
  
                //for (int i = 0; i < hashBytes.Length; i++)
                //{
                //    hashString += Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');
                //}
                hashString = Convert.ToBase64String(hashBytes, 0, hashBytes.Length);   
                //return hashString.PadLeft(32, '0');
            
            }
			return hashString ;
		}
		
        /// converts the MD5 of SHA-1 result byte[] to a string representative
		public string DisplayStringForBytes(byte[] RawStringBytes)
		{	
			 
				string hashString ="";
                //for(int i=0;i<RawStringBytes.Length;i++)
                //{
                //    hashString += Convert.ToString(RawStringBytes[i],16).PadLeft(2,'0');
                //}
                hashString = Convert.ToBase64String(RawStringBytes, 0, RawStringBytes.Length);    
            return hashString;
  
				//return hashString.PadLeft(32,'0');
		
		}

        public byte[] HashBytes(byte[] bytes, int Algorithm)
        {
            byte[] hashBytes = null;

            if (Algorithm == 0)//MD5
            {

                System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                hashBytes = md5.ComputeHash(bytes);
            }
            else if (Algorithm == 1)//SHA-1
            {
                SHA1CryptoServiceProvider SHS = new SHA1CryptoServiceProvider();
                hashBytes = SHS.ComputeHash(bytes);
            }
            else
            {
                return null;
            }
            return hashBytes;
        }

        static byte[] GenerateIV()
        {
            // Create an instance of Symetric Algorithm. Key and IV is generated automatically.
            AesCryptoServiceProvider aesCrypto = (AesCryptoServiceProvider)AesCryptoServiceProvider.Create();

            // Use the Automatically generated key for Encryption. 
            return aesCrypto.IV;
            //return ASCIIEncoding.ASCII.GetString(aesCrypto.Key);
            
        }

        //  Call this function to remove the key from memory after use for security
        [System.Runtime.InteropServices.DllImport("KERNEL32.DLL", EntryPoint = "RtlZeroMemory")]
        public static extern bool ZeroMemory(IntPtr Destination, int Length);
    

    public  void DecryptAES(string InputFileToDecrypt,
                            string OutputFile,
                            string PassPhrase,
                            string SaltValue,
                            string HashAlgorithm,
                            int PasswordIterations,
                            string InitVector,
                            int KeySize)
    {

            AesCryptoServiceProvider AES = new AesCryptoServiceProvider();
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);

            PasswordDeriveBytes password =
                new PasswordDeriveBytes(PassPhrase,
                                        saltValueBytes,
                                        HashAlgorithm,
                          PasswordIterations);

            AES.Key = password.GetBytes(KeySize / 8);
            //AES.IV = ASCIIEncoding.ASCII.GetBytes(Key);
            AES.IV = initVectorBytes;
            //AES.IV = GenerateIV();
        //AES.Mode = CipherMode.CBC;

            FileStream inputFile = new FileStream(InputFileToDecrypt, FileMode.Open,FileAccess.Read);
            ICryptoTransform aesDecryptor = AES.CreateDecryptor();
            FileStream fsDecrypted = new FileStream(OutputFile,FileMode.OpenOrCreate, FileAccess.Write);
            CryptoStream cryptostreamDecryptor = new CryptoStream(fsDecrypted,aesDecryptor, CryptoStreamMode.Write);
            
            try
            {
                
                byte[] buffer = new byte[inputFile.Length];
                inputFile.Read(buffer, 0, buffer.Length);
                cryptostreamDecryptor.Write(buffer, 0, buffer.Length);
                cryptostreamDecryptor.Close();
            }

            catch 
            {
            }
        finally
        {
                //fsDecrypted.Flush();
             fsDecrypted.Close();
             
        }

    }
        
public void EncryptAES(string InputFileToEncrypt, 
                            string OutputFile, 
                            string PassPhrase,
                            string SaltValue,
                            string HashAlgorithm,
                            int PasswordIterations,
                            string InitVector,
                            int KeySize)
    {

            AesCryptoServiceProvider AES = new AesCryptoServiceProvider();
            byte[] initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
            byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);

            PasswordDeriveBytes password =
                new PasswordDeriveBytes(PassPhrase,
                                        saltValueBytes,
                                        HashAlgorithm,
                                        PasswordIterations);

            AES.Key = password.GetBytes(KeySize / 8);
            //AES.IV = ASCIIEncoding.ASCII.GetBytes(Key);
            AES.IV = initVectorBytes;
    //AES.IV = GenerateIV();
            //AES.Mode = CipherMode.CBC;
            // For additional security pin the password.
            GCHandle gch = GCHandle.Alloc(PassPhrase  , GCHandleType.Pinned);

            FileStream inputFile = new FileStream(InputFileToEncrypt,FileMode.Open, FileAccess.Read);
            FileStream fsEncrypted = new FileStream(OutputFile,FileMode.Create, FileAccess.Write);

            ICryptoTransform aesEncrypt = AES.CreateEncryptor();
            CryptoStream cryptoStreamObject = new CryptoStream(fsEncrypted,aesEncrypt,CryptoStreamMode.Write);

            try
            {
                Byte[] inputBytes = new Byte[inputFile.Length];
                inputFile.Read(inputBytes, 0, inputBytes.Length);
                cryptoStreamObject.Write(inputBytes, 0,
                inputBytes.Length);
            }
            catch 
            {
                
            }
            finally
            {
                cryptoStreamObject.Close();
                inputFile.Close();
                // Remove the key from memory. 
                ZeroMemory(gch.AddrOfPinnedObject(), PassPhrase.Length *2);
                gch.Free();
            }
            
    }

public void EncryptDES(string InputFileToEncrypt,
                            string OutputFile,
                            string PassPhrase,
                            string SaltValue,
                            string HashAlgorithm,
                            int PasswordIterations,
                            string InitVector,
                            int KeySize)
{

    DESCryptoServiceProvider DES = new DESCryptoServiceProvider(); 
    byte[] initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
    byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);

    PasswordDeriveBytes password =
        new PasswordDeriveBytes(PassPhrase,
                                saltValueBytes,
                                HashAlgorithm,
                                PasswordIterations);

   
    DES.Key = password.GetBytes(KeySize / 8);
    //AES.IV = ASCIIEncoding.ASCII.GetBytes(Key);
    DES.IV = initVectorBytes;
    //AES.IV = GenerateIV();
    //AES.Mode = CipherMode.CBC;
    // For additional security pin the password.
    GCHandle gch = GCHandle.Alloc(PassPhrase, GCHandleType.Pinned);

    FileStream inputFile = new FileStream(InputFileToEncrypt, FileMode.Open, FileAccess.Read);
    FileStream fsEncrypted = new FileStream(OutputFile, FileMode.Create, FileAccess.Write);

    ICryptoTransform desEncrypt = DES.CreateEncryptor();
    CryptoStream cryptoStreamObject = new CryptoStream(fsEncrypted, desEncrypt, CryptoStreamMode.Write);

    try
    {
        Byte[] inputBytes = new Byte[inputFile.Length];
        inputFile.Read(inputBytes, 0, inputBytes.Length);
        cryptoStreamObject.Write(inputBytes, 0,
        inputBytes.Length);
    }
    catch 
    {
        
    }
    finally
    {
        cryptoStreamObject.Close();
        inputFile.Close();
        // Remove the key from memory. 
        ZeroMemory(gch.AddrOfPinnedObject(), PassPhrase.Length * 2);
        gch.Free();
    }
}

public void DecryptDES(string InputFileToDecrypt,
                string OutputFile,
                string PassPhrase,
                string SaltValue,
                string HashAlgorithm,
                int PasswordIterations,
                string InitVector,
                int KeySize)
{

    DESCryptoServiceProvider DES = new DESCryptoServiceProvider();
    byte[] initVectorBytes = Encoding.ASCII.GetBytes(InitVector);
    byte[] saltValueBytes = Encoding.ASCII.GetBytes(SaltValue);

    PasswordDeriveBytes password =
        new PasswordDeriveBytes(PassPhrase,
                                saltValueBytes,
                                HashAlgorithm,
                  PasswordIterations);

    DES.Key = password.GetBytes(KeySize / 8);
    //AES.IV = ASCIIEncoding.ASCII.GetBytes(Key);
    DES.IV = initVectorBytes;
    //AES.IV = GenerateIV();
    //AES.Mode = CipherMode.CBC;

    FileStream inputFile = new FileStream(InputFileToDecrypt, FileMode.Open, FileAccess.Read);
    ICryptoTransform desDecryptor = DES.CreateDecryptor();
    FileStream fsDecrypted = new FileStream(OutputFile, FileMode.OpenOrCreate, FileAccess.Write);
    CryptoStream cryptostreamDecryptor = new CryptoStream(fsDecrypted, desDecryptor, CryptoStreamMode.Write);

    try
    {

        byte[] buffer = new byte[inputFile.Length];
        inputFile.Read(buffer, 0, buffer.Length);
        cryptostreamDecryptor.Write(buffer, 0, buffer.Length);
        cryptostreamDecryptor.Close();
    }

    catch 
    {
    }
    finally
    {
        //fsDecrypted.Flush();
        fsDecrypted.Close();

    }

}

    }

        
}
