using System;
using System.Collections.ObjectModel;
using Microsoft.Maui.Controls;

namespace MauiAppPro.Pages;

public partial class CurrentTermRegistrationPage : ContentPage
{
    public CurrentTermRegistrationPage()
    {
        InitializeComponent();
        BindingContext = new CurrentTermRegistrationViewModel();
    }

    private void OnWithdrawClicked(object sender, EventArgs e)
    {
        var button = (Button)sender;
        var course = (Course)button.CommandParameter;
        var viewModel = (CurrentTermRegistrationViewModel)BindingContext;

        if (viewModel.CurrentSemesterCourses.Contains(course))
        {
            viewModel.CurrentSemesterCourses.Remove(course);
        }
    }
}