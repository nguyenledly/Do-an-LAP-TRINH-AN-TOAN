using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Client_02
{
    class DiffieHellman02
    {
        public byte[] bobPublicKey;
        public byte[] bobKey;
        public byte[] generatePublicKey()
        {
            //bobPublicKey = new byte[1024];
            using (ECDiffieHellmanCng bob = new ECDiffieHellmanCng())
            {
                //byte[] bobPublicKey;
                bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                bob.HashAlgorithm = CngAlgorithm.Sha256;
                bobPublicKey = bob.PublicKey.ToByteArray();
                byte[] a = bobPublicKey;
                return a;
            }
            //return bobPublicKey;
        }
        public string generatePublicKeyString()
        {
            bobPublicKey = new byte[1024];
            using (ECDiffieHellmanCng bob = new ECDiffieHellmanCng())
            {
                //byte[] bobPublicKey;
                bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                bob.HashAlgorithm = CngAlgorithm.Sha256;
                bobPublicKey = bob.PublicKey.ToByteArray();


            }
            return Convert.ToBase64String(bobPublicKey);
        }

        public void generatePublicKey01()
        {
            //bobPublicKey = new byte[1024];
            using (ECDiffieHellmanCng bob = new ECDiffieHellmanCng())
            {

                //byte[] alicePublicKey;
                bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                bob.HashAlgorithm = CngAlgorithm.Sha256;
                bobPublicKey = bob.PublicKey.ToByteArray();

            }
        }

        public byte[] secretKey(byte[] alicePublicKey)
        {
            //bobKey = new byte[1024];
            using (ECDiffieHellmanCng bob = new ECDiffieHellmanCng())
            {
                //bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                //bob.HashAlgorithm = CngAlgorithm.Sha256;
                //bobPublicKey = generatePublicKey();
                CngKey k = CngKey.Import(alicePublicKey, CngKeyBlobFormat.EccPublicBlob);
                bobKey = bob.DeriveKeyMaterial(k);
                byte[] a = bobKey;
                return a;                
            }
            //return bobKey;
        }
        public string secretKeyString(byte[] alicePublicKey)
        {
            bobKey = new byte[1024];
            using (ECDiffieHellmanCng bob = new ECDiffieHellmanCng())
            {
                //bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                //bob.HashAlgorithm = CngAlgorithm.Sha256;
                //bobPublicKey = generatePublicKey();
                CngKey k = CngKey.Import(alicePublicKey, CngKeyBlobFormat.EccPublicBlob);
                bobKey = bob.DeriveKeyMaterial(k);

            }
            return Convert.ToBase64String(bobKey);
        }
        public void secretKey01(byte[] bobPublicKey)
        {
            //bobKey = new byte[1024];
            using (ECDiffieHellmanCng bob = new ECDiffieHellmanCng())
            {
                //alice.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                //alice.HashAlgorithm = CngAlgorithm.Sha256;
                //alicePublicKey = generatePublicKey();
                CngKey k = CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob);
                bobKey = bob.DeriveKeyMaterial(k);

            }

        }
        public byte[][] publicAndSecretKey(byte[] bobPublicKey)
        {
            using (ECDiffieHellmanCng bob = new ECDiffieHellmanCng())
            {
                byte[][] result = new byte[2][];
                bob.KeyDerivationFunction = ECDiffieHellmanKeyDerivationFunction.Hash;
                bob.HashAlgorithm = CngAlgorithm.Sha256;
                bobPublicKey= bob.PublicKey.ToByteArray();
                CngKey k = CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob);
                bobKey = bob.DeriveKeyMaterial(CngKey.Import(bobPublicKey, CngKeyBlobFormat.EccPublicBlob));
                result[0] = bobPublicKey;
                result[1] = bobKey;
                return result;
            }
        }

    }
}
