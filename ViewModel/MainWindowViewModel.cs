using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using TOS_Helper.Model;

namespace TOS_Helper.ViewModel
{
    /// <summary>
    /// This viewmodel class binds the MainWindow view with the <see cref="MainWindowViewModel"/>.
    /// </summary>
    public class MainWindowViewModel : BindableBase
    {
        private BannerToolViewModel _bannerToolViewModel;
        /// <summary>
        /// An <see cref="ObservableCollection{T}"/> of the languages the user can choose from.
        /// </summary>
        public ObservableCollection<Culture> Cultures
        {
            get => App._cultures;
            set => App._cultures = value;
        }
        /// <summary>
        /// The selected language of the user.
        /// </summary>
        public static Culture SelectedCulture
        {
            get => App._selectedCulture;
            set
            {
                App.ChangeCulture(value);
            }
        }
        /// <summary>
        /// A public property to bind the UserControl to the <see cref="BannerToolViewModel"/> viewmodel.
        /// </summary>
        public BannerToolViewModel BannerToolViewModel
        { 
            get => _bannerToolViewModel; 
            set => SetProperty(ref _bannerToolViewModel, value);
        }
        /// <summary>
        /// The constructor for <see cref="MainWindowViewModel"/> that assigns a new <see cref="BannerToolViewModel"/>
        /// to <see cref="_bannerToolViewModel"/>.
        /// </summary>
        public MainWindowViewModel()
        {
            _bannerToolViewModel = new BannerToolViewModel();
        }
    }
}
