using Library.Canvas.Models;
using Library.Canvas.Services;
using MAUI.Canvas.viewmodels;

namespace MAUI.Canvas.dialogs;

public partial class StudentDialog : ContentPage
{
	public StudentDialog()
	{
		InitializeComponent();
		BindingContext = new StudentDialogViewModel();
	}
	private void CancelClicked(object sender, EventArgs e)
	{
		Shell.Current.GoToAsync("//Students");
	}
	private void AddClicked(object sender, EventArgs e)
	{	
		(BindingContext as StudentDialogViewModel)?.AddStudent();
		Shell.Current.GoToAsync("//Students");
	}
	private void StudentDialog_NavigatedTo(object sender, NavigatedToEventArgs e)
	{	
		BindingContext = new StudentDialogViewModel();
	}
}