using BeoRecruitment.Models.Entities;
using BeoRecruitment.Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

public class ArtistViewModel : INotifyPropertyChanged, INavigationParameter<Artist>
{
    public ICommand OpenUrlCommand { get; }

    private Artist _artist;
    public Artist Artist
    {
        get => _artist;
        set
        {
            _artist = value;
            OnPropertyChanged(nameof(Artist));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;

    public ArtistViewModel()
    {
        OpenUrlCommand = new Command<string>(OpenUrl);
    }

    protected virtual void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public void SetParameter(Artist artist)
    {
        Artist = artist;
    }

    private void OpenUrl(string url)
    {
        Launcher.OpenAsync(new Uri(url));
    }
}
