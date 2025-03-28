using MauiAppPro.Pages;

namespace MauiAppPro;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();
        Routing.RegisterRoute(nameof(HomePage), typeof(HomePage));
        Routing.RegisterRoute(nameof(ProfilePage), typeof(ProfilePage));
        Routing.RegisterRoute(nameof(SearchCoursesPage), typeof(SearchCoursesPage)); // เพิ่มบรรทัดนี้
		Routing.RegisterRoute(nameof(CurrentTermRegistrationPage), typeof(CurrentTermRegistrationPage));
    }
}