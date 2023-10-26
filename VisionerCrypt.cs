using System.Text;

namespace Visioner
{
    public class VisionerCrypt
    {
        Dictionary<string, int[]> cisionerSqare { get; set; } = new Dictionary<string, int[]>();
        //Квадрат вижинера
        string alphabet = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
        //Русский алфавит
        Dictionary<int, string> AlphabetDictionary = new Dictionary<int, string>();
        //Русский пронумерованный алфавит
        string key;
        //ключ фраза
        string message;
        //сообщение
        public string VisioneredMessage { get; set; }
        //Зашифрованное сообщение

        public VisionerCrypt()
        {
            VisionerCreate();
            CreateAlphabetDictionary();
        }

        public void VisioneredMessageShow()
        {
            Console.WriteLine($"Зашифрованное сообщение {VisioneredMessage}");
        }
        public void VisionerEncrypt(string key, string message)
        {
            this.key = key.ToUpper();
            StringBuilder BuffKey = new StringBuilder();
            StringBuilder messageBuff = new StringBuilder(message.ToUpper());

            string english = "ABCDEFGHIJKLMNOPQRSTUVWXYZ!@#/-.,»«:;1234567890()?'";
            foreach (var el in english)
            {
                messageBuff = messageBuff.Replace(el.ToString(), String.Empty);
            }
            this.message = messageBuff.ToString();
            this.message = this.message.Replace(" ", String.Empty);

            for (int i = 0, j = 0; i < this.message.Length; i++, j++)
            {
                j = j == this.key.Length ? 0 : j;
                BuffKey.Append(this.key[j]);
            }
            Console.WriteLine($"Ключ в подготовленном виде {BuffKey}"); 

            StringBuilder buffVisioneredMessage = new StringBuilder();
            for (int i = 0; i < this.message.Length; i++)
            {
                int keyindex = alphabet.IndexOf(BuffKey[i]);
                int VisionerdChar = cisionerSqare[this.message[i].ToString()][keyindex];
                buffVisioneredMessage.Append(AlphabetDictionary[VisionerdChar]);
            }
            VisioneredMessage = buffVisioneredMessage.ToString();
        }

        public void Decryption()
        {
            StringBuilder BuffKey = new StringBuilder();
            for (int i = 0, j = 0; i < VisioneredMessage.Length; i++, j++)
            {
                j = j == key.Length ? 0 : j;
                BuffKey.Append(key[j]);
            }
            StringBuilder buffDevisioneredMessage = new StringBuilder();

            for (int i = 0; i < VisioneredMessage.Length; i++)
            {
                int VisioneredMessageCharIndex = alphabet.IndexOf(VisioneredMessage[i]);
                int KeyCharIndex = alphabet.IndexOf(BuffKey[i]);

                int result = VisioneredMessageCharIndex - KeyCharIndex;
                result = result < 0 ? result + 33 : result;
                buffDevisioneredMessage.Append(AlphabetDictionary[result]);
            }
            Console.WriteLine($"Расшифрованное сообщение {buffDevisioneredMessage.ToString()}");


        }
        void VisionerCreate()
        {
            // Заполнение квадрата Виженера
            for (int i = 0; i < alphabet.Length; i++)
            {
                int[] row = new int[alphabet.Length];

                for (int j = 0; j < alphabet.Length; j++)
                {
                    int index = (i + j) % alphabet.Length;
                    row[j] = index;
                }

                cisionerSqare.Add(alphabet[i].ToString(), row);
            }
        }
        void CreateAlphabetDictionary()
        {
            foreach (var el in alphabet) //заполняем пронумерованный русский алфавит
            {
                AlphabetDictionary.Add(alphabet.IndexOf(el.ToString()), el.ToString());
            }
        }
    }
}
