using MeasuringDevice;
namespace Task1;

public partial class MainPage : ContentPage
{

	private MeasureLengthDevice device;

	public MainPage()
	{
		InitializeComponent();
	}

	private void CreateDevice_Click(object sender, EventArgs e)
    {
        if (UnitsPicker.SelectedIndex == -1)
        {
            OutputLabel.Text = "Выберите систему измерений!";
            return;
        }

        Units units = UnitsPicker.SelectedItem.ToString() == "Metric"
            ? Units.Metric
            : Units.Imperial;

        device = new MeasureLengthDevice(units);

        OutputLabel.Text = "Device создан.";
    }

    private void Start_Click(object sender, EventArgs e)
    {
        device?.StartCollecting();
        OutputLabel.Text = "Сбор данных начат.";
    }

    private void Stop_Click(object sender, EventArgs e)
    {
        device?.StopCollecting();
        OutputLabel.Text = "Сбор данных остановлен.";
    }

    private void ShowMetric_Click(object sender, EventArgs e)
    {
        if (device != null)
            OutputLabel.Text = "Metric value: " + device.MetricValue();
    }

    private void ShowImperial_Click(object sender, EventArgs e)
    {
        if (device != null)
            OutputLabel.Text = "Imperial value: " + device.ImperialValue();
    }

    private void ShowRaw_Click(object sender, EventArgs e)
    {
        if (device != null)
        {
            var data = device.GetRawData();
            OutputLabel.Text = "Raw data: " + string.Join(", ", data);
        }
    }
}