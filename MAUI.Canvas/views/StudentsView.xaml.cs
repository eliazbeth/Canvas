using MAUI.Canvas.viewmodels;

namespace MAUI.Canvas.views;
public partial class StudentsView : ContentPage
{
	public StudentsView()
	{
		InitializeComponent();
		BindingContext = new StudentsViewViewModel();
	}
	private void BackClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}

	private void AddClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//StudentDetails");
		//(BindingContext as StudentsViewModel)?.AddStudent();
	}
	private void StudentsView_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as StudentsViewViewModel)?.Refresh();
	}
}
