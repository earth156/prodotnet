using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System.Linq;
using System.Collections.Generic;
using Microsoft.Maui.Controls;

namespace MauiAppPro.ViewsModel
{
    public partial class SearchCoursesViewModel : ObservableObject
    {
        [ObservableProperty]
        private ObservableCollection<Course> courses = new ObservableCollection<Course>
        {
            new Course { CourseCode = "CS101", CourseName = "พื้นฐานวิทยาการคอมพิวเตอร์", Credit = 3 },
            new Course { CourseCode = "MATH101", CourseName = "แคลคูลัส 1", Credit = 4 },
            new Course { CourseCode = "ENG101", CourseName = "การเขียนภาษาอังกฤษ", Credit = 3 },
            new Course { CourseCode = "PHYS101", CourseName = "ฟิสิกส์ 1", Credit = 4 },
            new Course { CourseCode = "CHEM101", CourseName = "เคมีทั่วไป", Credit = 3 },
            new Course { CourseCode = "HIST101", CourseName = "ประวัติศาสตร์โลก", Credit = 3 },
            new Course { CourseCode = "MATH201", CourseName = "พีชคณิตเชิงเส้น", Credit = 4 },
            // ... เพิ่มวิชาอื่น ๆ
        };

        [ObservableProperty]
        private string searchText;

        [ObservableProperty]
        private ObservableCollection<Course> filteredCourses = new ObservableCollection<Course>();

        public SearchCoursesViewModel()
        {
        }

        [RelayCommand]
        private async void AddCourse(Course courseToAdd)
        {
            if (courseToAdd != null && !FilteredCourses.Contains(courseToAdd))
            {
                FilteredCourses.Add(courseToAdd);
                courseToAdd.IsAdded = true;
                await Application.Current.MainPage.DisplayAlert("เพิ่มวิชา", $"{courseToAdd.CourseName} ถูกเพิ่มแล้ว", "ตกลง");
            }
        }

        [RelayCommand]
        private void SearchCourses()
        {
            if (string.IsNullOrWhiteSpace(SearchText))
            {
                // Do not clear FilteredCourses if SearchText is empty
            }
            else
            {
                var addedCourses = FilteredCourses.Where(c => c.IsAdded).ToList();
                var searchResults = Courses.Where(course =>
                    course.CourseName.Contains(SearchText, StringComparison.OrdinalIgnoreCase) ||
                    course.CourseCode.Contains(SearchText, StringComparison.OrdinalIgnoreCase)
                ).ToList();

                FilteredCourses.Clear();

                foreach (var course in addedCourses)
                {
                    FilteredCourses.Add(course);
                }

                foreach (var course in searchResults)
                {
                    if (!FilteredCourses.Contains(course))
                    {
                        FilteredCourses.Add(course);
                    }
                }
            }
        }
    }

    public partial class Course : ObservableObject
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public int Credit { get; set; }

        [ObservableProperty]
        private bool isAdded = false;

        [ObservableProperty]
        private Color frameBackgroundColor = Colors.White;

        [ObservableProperty]
        private string addButtonText = "เพิ่ม";

        [ObservableProperty]
        private Color addButtonBackgroundColor = Color.FromRgb(76, 175, 80);

        partial void OnIsAddedChanged(bool value)
        {
            if (value)
            {
                FrameBackgroundColor = Color.FromRgba(144, 238, 144, 255); // LightGreen
                AddButtonText = "เพิ่มแล้ว";
                AddButtonBackgroundColor = Color.FromRgba(211, 211, 211, 255); // Lighter Gray but clickable
            }
            else
            {
                FrameBackgroundColor = Colors.White;
                AddButtonText = "เพิ่ม";
                AddButtonBackgroundColor = Color.FromRgb(76, 175, 80); // Green
            }
        }
    }
}
