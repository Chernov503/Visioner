using Visioner;

var u = false;
while (u == false)
{
    Console.WriteLine("\nВвести вруную или загрузить из text.txt? (1 или 2)");
    int choise = ((int)Console.ReadKey().Key);
    Console.Clear();
    switch (choise)
    {
        case 49:
            {
                Console.WriteLine("Введите сообщение");
                Console.WriteLine("Введите ключ");
                
                string message = Console.ReadLine();
                
                var a = new VisionerCrypt();
                a.VisionerEncrypt(Console.ReadLine(), message);
                a.VisioneredMessageShow();
                a.Decryption();
                Console.ReadLine();
                u = true;
                break;
            }
        case 50:
            {
                var message = (File.ReadAllText(@"C:\Users\sofia\Desktop\ЛИМ\программы\VisionerEncryption\Visioner\text.txt"));
                var a = new VisionerCrypt();
                a.VisionerEncrypt("КЛЮЧ", message);
                a.VisioneredMessageShow();
                a.Decryption();
                Console.ReadLine();
                u = true;
                break;
            }
    }
}

