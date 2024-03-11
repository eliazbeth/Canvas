namespace MAUI.Canvas;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
	}
	private void StudentViewClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Students");
	}
	private void InstructorViewClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Instructors");
	}
}

