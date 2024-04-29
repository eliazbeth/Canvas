using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Library.Canvas.Models;
using Library.Canvas.Services;
namespace MAUI.Canvas.viewmodels;

public class ModulesDialogViewModel
{
    private Course course;
    private Module module;
    private ContentItem contentItem;
    private List<Module> modules;
    private List<ContentItem> contentItems;
    private CourseService courseService;

     public ModulesDialogViewModel(string code)
    {
        courseService = CourseService.Current;
        if (code != null) 
            course = courseService.GetCourse(code);
        else course = new Course();
        modules = course.Modules;
        if (module == null)
        {
            module = new Module();
        }
        if (module.Content == null)
            module.Content = new List<ContentItem>();
        if(contentItem == null)
        {
            contentItem = new ContentItem();
        }
    }
    public IEnumerable<Module> Modules
    {
        get
        {
            return modules;
        }
    }
    public string ModuleName
    {
        get{return module?.Name ?? string.Empty;}
        set{if (module==null) module = new Module();
        module.Name=value;}
    }
    public string ModuleDescription
    {
        get{return module?.Description ?? string.Empty;}
        set{if (module==null) module = new Module();
        module.Description=value;}
    }
    public string ContentName
    {
        get{return contentItem?.Name ?? string.Empty;}
        set{if (contentItem==null) contentItem = new ContentItem();
        contentItem.Name=value;}
    }
    public string ContentDescription
    {
        get{return contentItem?.Description ?? string.Empty;}
        set{if (contentItem==null) contentItem = new ContentItem();
        contentItem.Description=value;}
    }
    public void AddModule()
    {
        if(course != null && module != null)
        {
            courseService.AddModule(course, module, contentItem);
        }
    }
}
