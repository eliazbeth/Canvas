namespace MAUI.Canvas;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
	private void StudentsViewClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Students");
	}
	private void InstructorsViewClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Instructors");
	}
}

