using System.Security.Cryptography;
using System.Text;

namespace LabWork.ViewModels.PageLabWork
{
    internal class LabWork22ViewModel : ViewModelBase
    {
        internal static LabWork22ViewModel LabWork22ViewModelInstanse { get; private set; } = new();

        private string userLogin = string.Empty;

        public string UserLogin
        {
            get => userLogin;
            set => this.RaiseAndSetIfChanged(ref userLogin, value);
        }

        private string userPassword = string.Empty;

        public string UserPassword
        {
            get => userPassword;
            set => this.RaiseAndSetIfChanged(ref userPassword, value);
        }

        private string userSite = string.Empty;

        public string UserSite
        {
            get => userSite;
            set => this.RaiseAndSetIfChanged(ref userSite, value);
        }

        private double numeric = 0;

        public double Numeric
        {
            get => numeric;
            set => this.RaiseAndSetIfChanged(ref numeric, value);
        }

        private string encryptPassword = "";
        private string decryptPassword = "";

        internal LabWork22ViewModel()
        {
            LabWork22ViewModelInstanse = this;
        }

        internal void VisualDataReg()
        {
            var lines = File.ReadLines(Environment.CurrentDirectory + "/Assets/" + "password.txt");
            var users = lines.Select(x => x.Split(";")).Select(x => new User(x[1], x[2], x[0], x[3], x[4]));
            Data.ObjectDataReport.AddRange(users);
        }

        internal void AddDataReg()
        {
            using var file = File.Open(Environment.CurrentDirectory + "/Assets/" + "password.txt", FileMode.Append);
            var lineReg = new StringBuilder().AppendJoin(";",
                new List<string> { UserSite, UserLogin, UserPassword, encryptPassword, decryptPassword });
            file.Write(Encoding.Default.GetBytes(lineReg + "\n"));
        }

        internal void PasswordGenerate()
        {
            var s = new StringBuilder();
            var password = "";
            do
            {
                s.Append(Md5Sum(
                    $"Password-{DateTime.Now.ToLongDateString()}-{Numeric}-{DateTime.Now.Millisecond}-{DateTime.Now.Microsecond}-{DateTime.Now.Nanosecond}"));
                if (s.Length > Numeric)
                {
                    password = s.ToString()[..(int)Numeric];
                }
            } while (password.Length != (int)Numeric);

            UserPassword = password;
        }

        private string Md5Sum(string strToEncrypt)
        {
            var bytes = new UTF8Encoding().GetBytes(strToEncrypt);
            var hashBytes = MD5.Create().ComputeHash(bytes);

            var hashString = hashBytes.Aggregate("", (current, t) => current + Convert.ToString(t, 16).PadLeft(2, '0'));

            return hashString.PadLeft(32, '0');
        }


        private const int Keysize = 128;
        private const int DerivationIterations = 1000;

        public void Encrypt()
        {
            var saltStringBytes = Generate128BitsOfRandomEntropy();
            var ivStringBytes = Generate128BitsOfRandomEntropy();
            var plainTextBytes = Encoding.UTF8.GetBytes(UserPassword);

            using var password = Password(saltStringBytes);

            var keyBytes = password.GetBytes(Keysize / 8);

            using var symmetricKey = SymetricKeyFill();

            using var memoryStream = new MemoryStream();
            
            using var encryptor = symmetricKey.CreateEncryptor(keyBytes, ivStringBytes);
            
            using var cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write);
            
            cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
            cryptoStream.FlushFinalBlock();

            var cipherTextBytes = saltStringBytes.Concat(ivStringBytes).Concat(memoryStream.ToArray()).ToArray();

            encryptPassword = Convert.ToBase64String(cipherTextBytes);
        }

        public void Decrypt()
        {
            var cipherTextBytesWithSaltAndIv = Convert.FromBase64String(encryptPassword);
            var saltStringBytes = cipherTextBytesWithSaltAndIv.Take(Keysize / 8).ToArray();
            var ivStringBytes = cipherTextBytesWithSaltAndIv.Skip(Keysize / 8).Take(Keysize / 8).ToArray();
            var cipherTextBytes = cipherTextBytesWithSaltAndIv.Skip((Keysize / 8) * 2).Take(cipherTextBytesWithSaltAndIv.Length - ((Keysize / 8) * 2)).ToArray();

            using var password = Password(saltStringBytes);

            var keyBytes = password.GetBytes(Keysize / 8);
            
            using var symmetricKey = SymetricKeyFill();

            using var memoryStream = new MemoryStream(cipherTextBytes);

            using var decryptor = symmetricKey.CreateDecryptor(keyBytes, ivStringBytes);
            
            using var cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read);
            
            using var streamReader = new StreamReader(cryptoStream, Encoding.UTF8);
            
            decryptPassword = streamReader.ReadToEnd();
        }

        private Rfc2898DeriveBytes Password(byte[] saltStringBytes)
        {
            return new Rfc2898DeriveBytes(UserLogin, saltStringBytes, DerivationIterations,
                HashAlgorithmName.SHA512);
        }
        private Aes SymetricKeyFill()
        {
            var symmetricKey = Aes.Create();
            symmetricKey.BlockSize = Keysize;
            symmetricKey.Mode = CipherMode.CBC;
            symmetricKey.Padding = PaddingMode.PKCS7;
            return symmetricKey;
        }

        private static byte[] Generate128BitsOfRandomEntropy()
        {
            var randomBytes = new byte[16];
            using var rngCsp = RandomNumberGenerator.Create();
            rngCsp.GetBytes(randomBytes);
            return randomBytes;
        }


        internal class User
        {
            public string Login { get; }
            public string Password { get; }
            public string Site { get; }
            public string PasswordShifr { get; }
            public string PasswordUnShift { get; }

            public User(string login, string password, string site, string passwordShifr, string passwordUnShift)
            {
                Login = login;
                Password = password;
                Site = site;
                PasswordShifr = passwordShifr;
                PasswordUnShift = passwordUnShift;
            }
        }
    }
}
