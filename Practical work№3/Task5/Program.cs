using System.Security.Cryptography;
using System.Text;


//Строка Имя Фамилия
string fio = "Воронин Иван Дмитриевич";
//Преобразование строки в массив байтов
byte[] inputBytes = Encoding.UTF8.GetBytes(fio);


//Для алгоритма  SHA-256(вычисляем хэш)
using (SHA256 sha256 = SHA256.Create())
{
    byte[] hashBytes = sha256.ComputeHash(inputBytes);
    string hashHex = Convert.ToHexString(hashBytes);
    Console.WriteLine($"ФИО: {fio}");
    Console.WriteLine($"ХЭШ ФИО: {hashHex}");
}