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
		Shell.Current.GoToAsync("//StudentDetails?studentId=0");
		//(BindingContext as StudentsViewModel)?.AddStudent();
	}
	private void UpdateClicked(object sender, EventArgs e)
	{
		var studentId = (BindingContext as StudentsViewViewModel)?.SelectedStudent?.Id;
		if (studentId != null)
			Shell.Current.GoToAsync($"//StudentDetails?studentId={studentId}");
	}
	private void RemoveClicked(object sender, EventArgs e)
	{
		(BindingContext as StudentsViewViewModel)?.Remove();
	}
	
	private void SearchClicked(object sender, EventArgs e)
	{
		(BindingContext as StudentsViewViewModel)?.Refresh();
	}
	private void StudentsView_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as StudentsViewViewModel)?.Refresh();
	}
	
}
