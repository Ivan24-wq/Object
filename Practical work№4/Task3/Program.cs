using System.Text;
public enum Material
{
    StainlessSteel,
    Aluminium,
    ReinforcedConcrete, 
    Composit,
    Titanium
}


public enum CrossSelection
{
    IBeam,
    Box,
    ZShaped,
    CShaped
}

public enum TestResult
{
    Pass, 
    Fail
}

//Точка входа
class Program
{
    static void Main()
    {
        //Выбираем материал
        Console.WriteLine("Выберите материал: ");
        Console.WriteLine("0 - StainlessSteel\n1 - Aluminium\n2-ReinforcedConcrete\n3 - Composit\n4 - Titanium");
        Material selectedMaterial = (Material)int.Parse(Console.ReadLine());

        //Выбрка сечений
        Console.WriteLine("Тип сечения: ");
        Console.WriteLine("0 - IBeam\n1 - Box\n2 - ZShaped\n3 - CShaped");
        CrossSelection selectedCross = (CrossSelection)int.Parse(Console.ReadLine());

        //Тест
        Console.WriteLine("Результат теста: ");
        Console.WriteLine("0 - Pass\n1 - Fail");
        TestResult TryTest = (TestResult)int.Parse(Console.ReadLine());

        //Построение строки
        StringBuilder sb = new StringBuilder();

        switch (selectedMaterial)
        {
            case Material.StainlessSteel:
            sb.Append("Material: Stainless Steel, ");
            break;

            case Material.Aluminium:
            sb.Append("Material: Aluminium, ");
            break;

            case Material.ReinforcedConcrete:
            sb.Append("Material: Reinforced Concrete, ");
            break;

            case Material.Composit:
            sb.Append("Material: Composit, ");
            break;

            case Material.Titanium:
            sb.Append("Material: Titanium");
            break;
        }

        //Для сечений
        switch (selectedCross)
        {
            case CrossSelection.IBeam:
            sb.Append("Cross-section: I - Beam, ");
            break;

            case CrossSelection.Box:
            sb.Append("Cross-section: Box, ");
            break;

            case CrossSelection.CShaped:
            sb.Append("Cross-section: C-Shaped, ");
            break;

            case CrossSelection.ZShaped:
            sb.Append("Cross-section: Z-Shaped, ");
            break;
        }

        //Для тестов
        switch (TryTest)
        {
            case TestResult.Pass:
            sb.Append("Result: Pass, ");
            break;

            case TestResult.Fail:
            sb.Append("Result: Fail, ");
            break;
        }

        //Вывод
        Console.WriteLine("\n---Вывод результата: ---");
        Console.WriteLine(sb.ToString());
    }
}