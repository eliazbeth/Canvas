using MAUI.Canvas.viewmodels;
namespace MAUI.Canvas.views;
public partial class InstructorsView : ContentPage
{
	public InstructorsView()
	{
		InitializeComponent();
		BindingContext = new InstructorsViewViewModel();
	}

	private void BackClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//MainPage");
	}
	private void AddStudentClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//StudentDetails?studentId=0");
	}
	private void UpdateClicked(object sender, EventArgs e)
	{
		var studentId = (BindingContext as InstructorsViewViewModel)?.SelectedStudent?.Id;
		if (studentId != null)
			Shell.Current.GoToAsync($"//StudentDetails?studentId={studentId}");
	}
	private void RemoveClicked(object sender, EventArgs e)
	{
		(BindingContext as InstructorsViewViewModel)?.Remove();
	}
	
	private void SearchClicked(object sender, EventArgs e)
	{
		(BindingContext as InstructorsViewViewModel)?.Refresh();
	}
	private void AddCourseClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//CourseDetails?courseCode=string.Empty");
	}
	private void InstructorsView_NavigatedTo(object sender, NavigatedToEventArgs e)
	{
		(BindingContext as InstructorsViewViewModel)?.Refresh();
	}
}