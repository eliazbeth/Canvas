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
	}
	private void UpdateClicked(object sender, EventArgs e)
	{
		var studentId = (BindingContext as StudentsViewViewModel)?.SelectedStudent?.Id;
		if (studentId != null)
			Shell.Current.GoToAsync($"//StudentDetails?studentId={studentId}");
	}

	private void StudentDetailsClicked(object sender, EventArgs e)
	{
		(BindingContext as StudentsViewViewModel)?.Refresh();
	}
	private void CourseDetailsClicked(object sender, EventArgs e)
	{
		(BindingContext as StudentsViewViewModel)?.Refresh();
	}
	private void SubmitAssignmentClicked(object sender, EventArgs e)
	{
		(BindingContext as StudentsViewViewModel)?.Submit();
	}

	private void StudentsView_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as StudentsViewViewModel)?.RefreshStudents();
	}
	
}
