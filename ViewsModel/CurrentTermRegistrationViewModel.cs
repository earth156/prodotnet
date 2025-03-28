using System.Collections.ObjectModel;
using System.ComponentModel;

namespace MauiAppPro.Pages;

public class CurrentTermRegistrationViewModel : INotifyPropertyChanged
{
    public ObservableCollection<Course> CurrentSemesterCourses { get; set; }

    public CurrentTermRegistrationViewModel()
    {
        CurrentSemesterCourses = new ObservableCollection<Course>
        {
            new Course { CourseName = "โครงสร้างข้อมูล", Grade = "" },
            new Course { CourseName = "เครือข่ายคอมพิวเตอร์", Grade = "" },
            new Course { CourseName = "ปัญญาประดิษฐ์", Grade = "" }
        };
    }

    public event PropertyChangedEventHandler PropertyChanged;

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class Course
{
    public string CourseName { get; set; }
    public string Grade { get; set; }
}