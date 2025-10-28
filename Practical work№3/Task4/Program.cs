int a = 2147483647;
int b = 2;

//Исключение на переполнение типа
try
{
    int res = checked(a * b);
    Console.WriteLine(res);
}
catch(OverflowException)
{
    Console.WriteLine("Ошибка! Переполнение типа int!");
}