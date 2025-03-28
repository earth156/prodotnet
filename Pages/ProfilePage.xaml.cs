using MauiAppPro.ViewModels;

namespace MauiAppPro.Pages;

public partial class ProfilePage : ContentPage
{
    public ProfilePage()
    {
        InitializeComponent();
        BindingContext = new ProfilePageViewModel(); // ตั้งค่า BindingContext เป็น ViewModel
    }
}
