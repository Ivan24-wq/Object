using StressTest;
namespace Task4;

public partial class MainPage : ContentPage
{
	TestCaseResult[] results;
	int passCount = 0;
	int failCout = 0;

	public MainPage()
	{
		InitializeComponent();
	}

	//Обработчик кнокпи Стрес Тест
	private void RunTests_Click(object sender, EventArgs e)
    {
        //Очитим данные
		reasonList.ItemsSource = null;
		passCount = 0;
		failCout = 0;

		//Создаём массив
		results = new TestCaseResult[10];
		for(int i = 0; i < results.Length; ++i)
        {
            results[i] = GenerateResult();
        }

		//Результат в списке
		List<string> reasons = new List<string>();
		foreach(var res in results)
        {
            if(res.Result == TestResult.Pass)
            {
                passCount ++;
            }
            else
            {
                failCout ++;
				reasons.Add(res.ReasonForFailure);
            }
        }

		sucessfull.Text = $"Удачных: {passCount}";
		fail.Text = $"Провалено: {failCout}";
		reasonList.ItemsSource = reasons;
    }

	private TestCaseResult GenerateResult()
    {
        Random rnd = new Random();
		bool pass = rnd.Next(2) == 0;

		if(pass)
			return new TestCaseResult
            {
                Result = TestResult.Pass,
				ReasonForFailure = " "
            };

		string[] reason =
        {
            "Перегрузка конструкции",
			"Некачественный материал",
			"Усталость метала",
			"Трещина на стыке"
        };

		return new TestCaseResult
        {
            Result = TestResult.Fail,
			ReasonForFailure = reason[rnd.Next(reason.Length)]
        };
    }
}