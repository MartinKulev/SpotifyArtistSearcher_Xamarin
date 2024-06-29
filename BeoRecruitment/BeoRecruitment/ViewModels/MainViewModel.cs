﻿using System.Windows.Input;
using BeoRecruitment.Services.Interfaces;
using Xamarin.Forms;
using BeoRecruitment.Models.Entities;
using System.Collections.Generic;

namespace BeoRecruitment.ViewModels
{
    public class MainViewModel
    {
        private readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            DetailsCommand = new Command(NavigateToDetailPage);
        }

        public ICommand DetailsCommand { get; }

        private void NavigateToDetailPage(object obj)
        {
            _navigationService.NavigateToAsync<DetailsViewModel, int>(1013);
        }


    }
}
