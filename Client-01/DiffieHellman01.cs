using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Client_01
{
    class DiffieHellman01
    {
        public byte[] alicePublicKey;
        public byte[] aliceKey;
        //private ECDiffieHellmanCng alice = null;
        public byte[] generatePublicKey()
        {
            //alicePublicKey = new byte[1024];
            using (ECDiffieHellmanCng alice = new ECDiffieHellmanCng())
            {
                
                //byte[] alicePublicKey;
                alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                alice.HashAlgorithm = CngAlgorithm.Sha256;
                alicePublicKey = alice.PublicKey.ToByteArray();
                byte[] a = alicePublicKey;
                return a;
            }
            
        }
        public string generatePublicKeyString()
        {
            alicePublicKey = new byte[1024];
            using (ECDiffieHellmanCng alice = new ECDiffieHellmanCng())
            {

                //byte[] alicePublicKey;
                alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                alice.HashAlgorithm = CngAlgorithm.Sha256;
                alicePublicKey = alice.PublicKey.ToByteArray();

            }
            return Convert.ToBase64String(alicePublicKey);
        }
        public void generatePublicKey01()
        {
            //alicePublicKey = new byte[1024];
            using (ECDiffieHellmanCng alice = new ECDiffieHellmanCng())
            {

                //byte[] alicePublicKey;
                alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                alice.HashAlgorithm = CngAlgorithm.Sha256;
                alicePublicKey = alice.PublicKey.ToByteArray();
                
            }
        }
        public byte[] secretKey(byte[] bobPublicKey)
        {
            //aliceKey = new byte[1024];
            using (ECDiffieHellmanCng alice = new ECDiffieHellmanCng())
            {
                //alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                //alice.HashAlgorithm = CngAlgorithm.Sha256;
                //alicePublicKey = generatePublicKey();
                CngKey k = CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob);
                aliceKey = alice.DeriveKeyMaterial(k);
                byte[] a = aliceKey;
                return a;
            }
            //return aliceKey;
        }
        public string secretKeyString(byte[] bobPublicKey)
        {
            aliceKey = new byte[1024];
            using (ECDiffieHellmanCng alice = new ECDiffieHellmanCng())
            {
                //alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                //alice.HashAlgorithm = CngAlgorithm.Sha256;
                //alicePublicKey = generatePublicKey();
                CngKey k = CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob);
                aliceKey = alice.DeriveKeyMaterial(k);

            }
            return Convert.ToBase64String(aliceKey);
        }
        public void secretKey01(byte[] bobPublicKey)
        {
            //aliceKey = new byte[1024];
            using (ECDiffieHellmanCng alice = new ECDiffieHellmanCng())
            {
                //alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                //alice.HashAlgorithm = CngAlgorithm.Sha256;
                //alicePublicKey = generatePublicKey();
                CngKey k = CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob);
                aliceKey = alice.DeriveKeyMaterial(k);

            }
            
        }
        public byte[][] publicAndSecretKey(byte[] bobPublicKey)
        {
            using (ECDiffieHellmanCng alice = new ECDiffieHellmanCng())
            {
                byte[][] result = new byte[2][];
                //byte[] alicePublicKey;
                alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                alice.HashAlgorithm = CngAlgorithm.Sha256;
                alicePublicKey = alice.PublicKey.ToByteArray();
                CngKey k = CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob);
                aliceKey = alice.DeriveKeyMaterial(CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob));
                result[0]= alicePublicKey;
                result[1] = aliceKey;
                return result;
            }
        }


    }
}
