namespace MAUI.Canvas.views;
public partial class InstructorsView : ContentPage
{
	public InstructorsView()
	{
		InitializeComponent();
	}

	private void BackClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}
}