using System.Collections.ObjectModel;

namespace MauiAppPro.ViewModels;

public class ProfilePageViewModel
{
    public string ProfilePicture { get; set; } = "https://i.pravatar.cc/300"; // รูปโปรไฟล์สมมุติ
    public string FullName { get; set; } = "สมชาย ใจดี";
    public string StudentId { get; set; } = "65123456";
    public string Major { get; set; } = "วิทยาการคอมพิวเตอร์";
    public int Year { get; set; } = 3;

    // วิชาเรียนภาคการศึกษาปัจจุบัน
    public ObservableCollection<Course> CurrentSemesterCourses { get; set; } = new()
    {
        new Course { CourseName = "โครงสร้างข้อมูล", Grade = "" },
        new Course { CourseName = "เครือข่ายคอมพิวเตอร์", Grade = "" },
        new Course { CourseName = "ปัญญาประดิษฐ์", Grade = "" }
    };

    // วิชาเรียนภาคการศึกษาที่ผ่านมา
    public ObservableCollection<PreviousSemester> PreviousSemesterCourses { get; set; } = new()
    {
        new PreviousSemester
        {
            Semester = "ปี 2 เทอม 2",
            Courses = new ObservableCollection<Course>
            {
                new Course { CourseName = "ฐานข้อมูล", Grade = "B" },
                new Course { CourseName = "ระบบปฏิบัติการ", Grade = "B+" },
                new Course { CourseName = "การโปรแกรมเชิงวัตถุ", Grade = "A" }
            }
        },
        new PreviousSemester
        {
            Semester = "ปี 2 เทอม 1",
            Courses = new ObservableCollection<Course>
            {
                new Course { CourseName = "แคลคูลัส", Grade = "C+" },
                new Course { CourseName = "ฟิสิกส์เบื้องต้น", Grade = "B-" }
            }
        }
    };
}

// คลาสสำหรับวิชาเรียน
public class Course
{
    public string CourseName { get; set; }
    public string Grade { get; set; }
}

// คลาสสำหรับวิชาเรียนของภาคการศึกษาก่อนหน้า
public class PreviousSemester
{
    public string Semester { get; set; }
    public ObservableCollection<Course> Courses { get; set; }
}
