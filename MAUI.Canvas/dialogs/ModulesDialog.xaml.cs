using MAUI.Canvas.viewmodels;
namespace MAUI.Canvas.dialogs;

[QueryProperty(nameof(CourseCode), "courseCode")]
public partial class ModulesDialog : ContentPage
{
	public ModulesDialog()
	{
		InitializeComponent();
		BindingContext = new ModulesDialogViewModel(CourseCode);
	}
	public string CourseCode{get; set;}
	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync($"//CourseDetails?courseCode={CourseCode}");
	}
	private void ModulesDialog_NavigatedTo(object sender, NavigatedToEventArgs e)
	{	
		BindingContext = new ModulesDialogViewModel(CourseCode);
		//(BindingContext as ModulesDialogViewModel)?.Refresh();
	}
	private void AddClicked(object sender, EventArgs e)
	{	
		(BindingContext as ModulesDialogViewModel)?.AddModule();
		Shell.Current.GoToAsync($"//CourseDetails?courseCode={CourseCode}");
	}
}