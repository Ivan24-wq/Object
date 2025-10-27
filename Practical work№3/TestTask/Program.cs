int x, y, i;
i = int.Parse(Console.ReadLine()!);
try
{
    try
    {
        x = 5;
        y = x / i;
        Console.WriteLine($"x = {x}, y = {y}", x, y);
    }
    catch (System.FormatException e)
    {
        Console.WriteLine("Введено не целое число! Исключение", e.ToString());
    }
    /*
        catch (System.DivideByZeroException e)
        {
            Console.WriteLine("Попытка деления на ноль" + e.ToString());
        }
    */

    catch
    {
        Console.WriteLine("Неизвестная ошибка. Перезапустите программу!");
        throw;
    }
    finally
    {
        Console.WriteLine("Выполни блок finally");
    }
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
    Console.WriteLine(ex.StackTrace);
    Console.WriteLine(ex.TargetSite);
    Console.WriteLine(ex.InnerException);
    Console.WriteLine(ex.Source);
    Console.WriteLine(ex.Data);
    Console.WriteLine(ex.HelpLink);
}