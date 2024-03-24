using Library.Canvas.Models;
using Library.Canvas.Services;
using MAUI.Canvas.viewmodels;

namespace MAUI.Canvas.dialogs;

[QueryProperty(nameof(StudentId), "studentId")]
public partial class StudentDialog : ContentPage
{
	public StudentDialog()
	{
		InitializeComponent();
		BindingContext = new StudentDialogViewModel(0);
	}
	public int StudentId{get; set;}
	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Instructors");
	}
	private void AddClicked(object sender, EventArgs e)
	{	
		(BindingContext as StudentDialogViewModel)?.AddStudent();
		Shell.Current.GoToAsync("//Instructors");
	}
	private void StudentDialog_NavigatedTo(object sender, NavigatedToEventArgs e)
	{	
		BindingContext = new StudentDialogViewModel(StudentId);
	}
}