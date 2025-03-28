using MauiAppPro.ViewsModel;

namespace MauiAppPro.Pages;

public partial class SearchCoursesPage : ContentPage
{
    public SearchCoursesPage()
    {
        InitializeComponent();
        BindingContext = new SearchCoursesViewModel(); // กำหนด BindingContext
    }
}