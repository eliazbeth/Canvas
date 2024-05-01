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
	private void DoneClicked(object sender, EventArgs e)
	{	
		(BindingContext as CourseDialogViewModel)?.AddCourse();
		Shell.Current.GoToAsync("//Instructors");
	}
	private void AddStudentClicked(object sender, EventArgs e)
	{	
		(BindingContext as CourseDialogViewModel)?.AddStudent();
	}
	private void AddModuleClicked(object sender, EventArgs e)
	{	
		var courseCode = (BindingContext as InstructorsViewViewModel)?.SelectedCourse?.Code;
		if (CourseCode != null)
			Shell.Current.GoToAsync($"//ModulesDetails?courseCode={CourseCode}");
	}
	private void AddAssignmentClicked(object sender, EventArgs e)
	{	
		(BindingContext as CourseDialogViewModel)?.AddAssignment();
	}
	private void GradeClicked(object sender, EventArgs e)
	{	
		(BindingContext as CourseDialogViewModel)?.GradeSubmission();
	}
	private void CourseDialog_NavigatedTo(object sender, NavigatedToEventArgs e)
	{	
		BindingContext = new CourseDialogViewModel(CourseCode);
		(BindingContext as CourseDialogViewModel)?.Refresh();
	}
}