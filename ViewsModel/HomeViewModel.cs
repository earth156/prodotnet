using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiAppPro.Pages;
using System.Diagnostics;
using MauiApp1.Services; // เพิ่ม namespace ของ UserService
using System.Linq;

namespace MauiAppPro.ViewsModel;

public partial class HomeViewModel : ObservableObject
{
    private readonly UserService _userService;

    [ObservableProperty]
    private string fullName = string.Empty;

    [ObservableProperty]
    private int year;

    [ObservableProperty]
    private string major = string.Empty;

    [ObservableProperty]
    private string studentId = string.Empty;

    [ObservableProperty]
    private string profilePicture = string.Empty;

    [ObservableProperty]
    private string currentSemesterCourses = string.Empty;


    public HomeViewModel()
    {
        _userService = new UserService();
    }

    public async void LoadData(string userId)
    {
        Debug.WriteLine($"HomeViewModel: LoadData started with userId: {userId}");

        if (!string.IsNullOrEmpty(userId))
        {
            try
            {
                var users = await _userService.LoadUsersAsync();

                if (users != null && users.Count > 0)
                {
                    Debug.WriteLine($"HomeViewModel: Users list count: {users.Count}");

                    var user = users.FirstOrDefault(u => u.StudentId?.Trim().ToLower() == userId.Trim().ToLower());

                    if (user != null)
                    {
                        Debug.WriteLine($"HomeViewModel: User found: {user.FirstName} {user.LastName}");

                        try
                        {
                            FullName = (user.FirstName != null && user.LastName != null)
                                ? $"{user.FirstName} {user.LastName}"
                                : "ไม่พบชื่อ";

                            Year = (int)user.Year;

                            Major = user.Major ?? "ไม่พบสาขา";

                            StudentId = user.StudentId ?? "ไม่พบรหัสนิสิต";

                            ProfilePicture = !string.IsNullOrEmpty(user.ProfilePicture)
                                ? user.ProfilePicture
                                : "dotnet_bot.png";

                            Debug.WriteLine("========== LOGGED IN USER ==========");
                            Debug.WriteLine($"ชื่อ-นามสกุล: {FullName}");
                            Debug.WriteLine($"รหัสนิสิต: {StudentId}");
                            Debug.WriteLine($"ชั้นปี: {Year}");
                            Debug.WriteLine($"สาขา: {Major}");
                            Debug.WriteLine($"ที่อยู่ภาพ: {ProfilePicture}");
                            Debug.WriteLine($"วิชาที่ลงเรียนในปัจจุบัน: {currentSemesterCourses}");

                            Debug.WriteLine("===================================");
                        }
                        catch (Exception ex)
                        {
                            Debug.WriteLine($"HomeViewModel: Error processing user data: {ex.Message}");
                            SetDefaultValues();
                        }
                    }
                    else
                    {
                        Debug.WriteLine($"HomeViewModel: User with ID {userId} not found in the users list.");
                        SetDefaultValues();
                    }
                }
                else
                {
                    Debug.WriteLine("HomeViewModel: Users list is empty or null.");
                    SetDefaultValues();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"HomeViewModel: Error loading user data: {ex.Message}");
                SetDefaultValues();
            }
        }
        else
        {
            Debug.WriteLine("HomeViewModel: userId is null or empty.");
            SetDefaultValues();
        }
    }

    [RelayCommand]
    public async Task NavigateToProfilePage()
    {
        await Shell.Current.GoToAsync(nameof(Pages.ProfilePage), new Dictionary<string, object> { { "studentId", StudentId }, { "viewModel", this } }); // ส่ง HomeViewModel ไปด้วย
    }

    [RelayCommand]
    public async Task NavigateToCurrentTermRegistrationPage()
    {
        await Shell.Current.GoToAsync(nameof(Pages.CurrentTermRegistrationPage), new Dictionary<string, object> { { "studentId", StudentId }, { "viewModel", this } }); // ส่ง HomeViewModel ไปด้วย
    }

    [RelayCommand]
    public async Task NavigateToSearchCoursesPage()
    {
        await Shell.Current.GoToAsync(nameof(Pages.SearchCoursesPage), new Dictionary<string, object> { { "studentId", StudentId }, { "viewModel", this } }); // ส่ง HomeViewModel ไปด้วย
    }

    private void SetDefaultValues()
    {
        FullName = "ไม่พบผู้ใช้";
        Year = 0;
        Major = "ไม่พบสาขา";
        StudentId = "ไม่พบรหัสนิสิต";
        ProfilePicture = "dotnet_bot.png";
    }
}