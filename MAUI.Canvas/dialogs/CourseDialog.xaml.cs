using MAUI.Canvas.viewmodels;
namespace MAUI.Canvas.dialogs;

[QueryProperty(nameof(CourseCode), "courseCode")]
public partial class CourseDialog : ContentPage
{
	public CourseDialog()
	{
		InitializeComponent();
		BindingContext = new CourseDialogViewModel(string.Empty);
	}
	public string CourseCode{get; set;}
	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Instructors");
	}
	private void AddClicked(object sender, EventArgs e)
	{	
		(BindingContext as CourseDialogViewModel)?.AddCourse();
		Shell.Current.GoToAsync("//Instructors");
	}
	private void CourseDialog_NavigatedTo(object sender, NavigatedToEventArgs e)
	{	
		BindingContext = new CourseDialogViewModel(CourseCode);
	}
}