using MAUI.Canvas.viewmodels;

namespace MAUI.Canvas.views;
public partial class StudentsView : ContentPage
{
	public StudentsView()
	{
		InitializeComponent();
		BindingContext = new StudentsViewModel();
	}
	private void BackClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}
}
