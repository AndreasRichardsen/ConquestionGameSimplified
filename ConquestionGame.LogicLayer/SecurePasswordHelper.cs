using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ConquestionGame.LogicLayer
{
    class SecurePasswordHelper
    {
        // SALT_BYTES is set to 24 bytes because it is more than enough and the accepted standard is 16 bytes.
        public const int SALT_BYTES = 24;
        //HASH_BYTES is 18 byte to avoid slowness to the PBKDF2 computation, since it is 14 bits and less than SHA1's 160-bit output
        public const int HASH_BYTES = 18;
        //Set the amount of iterations
        public const int PBKDF2_ITERATIONS = 64000;
        //Divide the Hash format into 5 sections 
        public const int HASH_SECTIONS = 5;
        //Set the placement in the indec for each one
        public const int HASH_ALGORITHM_INDEX = 0;
        public const int ITERATION_INDEX = 1;
        public const int HASH_SIZE_INDEX = 2;
        public const int SALT_INDEX = 3;
        public const int PBKDF2_INDEX = 4;

        public static string CreateHash(string password)
        {
            byte[] salt = new byte[SALT_BYTES];
            try
            { 
                using (RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider())
                {
                    csprng.GetBytes(salt);
                }
            }catch (CryptographicException ex)
            {
                throw new CannotPerformOperationException("Random number generator not available", ex);
            }
            catch (ArgumentException ex)
            {
                throw new CannotPerformOperationException("Invalid argumnt given to random number generator", ex);
            }

            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTES);

            //format: algorithm:iterations:hashSize:salt:hash
            String parts = "sha1:" +
                PBKDF2_ITERATIONS + ":" +
                hash.Length + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
            return parts;
        }

        public static bool VerifyPassword(string password, string goodHash)
        {
            char[] delimiter = { ':' };
            string[] split = goodHash.Split(delimiter);

            if (split.Length != HASH_SECTIONS)
            {
                throw new InvalidHashException("Fields are missing from the password hash.");
            }

            if (split[HASH_ALGORITHM_INDEX] != "sha1"){
                throw new CannotPerformOperationException("Unsupported hash type.");
            }

            int iterations = 0;
            try
            {
                iterations = Int32.Parse(split[ITERATION_INDEX]);
            }catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException("Invalid argument given to Int32.Parse.", ex);
            }catch (FormatException ex)
            {
                throw new InvalidHashException("Could not parse the iteration count as an integer.", ex);
            }catch (OverflowException ex)
            {
                throw new InvalidHashException("The hash size is too large to be represented.", ex);
            }

            if (iterations < 1)
            {
                throw new InvalidHashException("Invalid number of iterations. Must be >=1.");
            }

            byte[] salt = null;
            try
            {
                salt = Convert.FromBase64String(split[SALT_INDEX]);
            }catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException("Invalid argument given to Convert.FromBase64String.", ex);
            }catch ( FormatException ex)
            {
                throw new InvalidHashException("Base64 decoding of salt failed.", ex);
            }

            byte[] hash = null;
            try
            {
                hash = Convert.FromBase64String(split[PBKDF2_INDEX]);
            }catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException("Invalid argument given to Convert.FromBase64String.", ex);
            }catch (FormatException ex)
            {
                throw new InvalidHashException("Base64 decoding of pbkdf2 output fdailed.", ex);
            }

            int storedHashSize = 0;
            try
            {
                storedHashSize = Int32.Parse(split[HASH_SIZE_INDEX]);
            }catch (ArgumentNullException ex)
            {
                throw new CannotPerformOperationException("Invalid argument given to Int32.Parse.", ex);
            }catch (FormatException ex)
            {
                throw new InvalidHashException("Could not parse the hash size as an integer.", ex);
            }catch (OverflowException ex)
            {
                throw new InvalidHashException("The hash size is too large to be represented.", ex);
            }

            if(storedHashSize != hash.Length)
            {
                throw new InvalidHashException("Hash lenght doesn't match stored hash lenght.");
            }

            byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }


        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++) {
                diff |= (uint)(a[i] ^ b[i]);
            }
            return diff == 0;
        }

        public static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt)) {
                pbkdf2.IterationCount = iterations;
                return pbkdf2.GetBytes(outputBytes);
            }
        }
    }
    class InvalidHashException : Exception
    {
        public InvalidHashException() { }
        public InvalidHashException(string message)
            : base(message) { }
        public InvalidHashException(string message, Exception inner)
            : base(message, inner) { }
    }

    class CannotPerformOperationException : Exception
    {
        public CannotPerformOperationException() { }
        public CannotPerformOperationException(string message)
            : base(message) { }
        public CannotPerformOperationException(string message, Exception inner)
            : base(message, inner) { }
    }
}
