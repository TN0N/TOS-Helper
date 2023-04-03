using System.Collections.ObjectModel;
using System.Threading;
using System.Windows;
using TOS_Helper.Model;
using TOS_Helper.ViewModel;

namespace TOS_Helper
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// The selected culture of the application.
        /// </summary>
        public static Culture _selectedCulture = new Culture();
        /// <summary>
        /// Find a culture in <see cref="_cultures"/>.
        /// </summary>
        /// <param name="id">The code of the language.</param>
        /// <param name="cultures">The native name of the language.</param>
        /// <returns>Returns the <see cref="Culture"/>, with a corresponding id code. Otherwise it returns a new empty <see cref="Culture"/>.</returns>
        public static Culture FindCulture(string id, ObservableCollection<Culture> cultures)
        { 
            foreach (var c in cultures)
                if (c.id == id)
                    return c;
            return new Culture();
        }
        /// <summary>
        /// The definition of the available languages to choose from.
        /// </summary>
        public static ObservableCollection<Culture> _cultures = new ObservableCollection<Culture>()
        {
            new Culture() { id = "en-US", culture = "English"},
            new Culture() { id = "sl-SI", culture = "slovenščina"},
            new Culture() { id = "ro", culture = "română"},
            new Culture() { id="hu", culture = "magyar"}
        };
        /// <summary>
        /// This method changes the language of the application as defined by the parameter.
        /// </summary>
        /// <param name="culture">The culture to which the applicatio wishes to be changed to.</param>
        public static void ChangeCulture(Culture culture)
        {
            // Assign the new culture
            _selectedCulture = culture;
            Settings.Default.language = _selectedCulture.id;
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(culture.id);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(culture.id);
            // Save the newly selected culture as a user preferance.
            Settings.Default.Save();
            
            // Create new window, assign old DataContext to display new language.
            var oldWindow = Application.Current.MainWindow;

            Application.Current.MainWindow = new MainWindow()
            {
                DataContext = oldWindow.DataContext
            };
            Application.Current.MainWindow.Show();
            oldWindow.Close();
        }
        protected override void OnStartup(StartupEventArgs e)
        {
            _selectedCulture = FindCulture(Settings.Default.language, _cultures);
            Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo(_selectedCulture.id);
            Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(_selectedCulture.id);
            base.OnStartup(e);
        }
        protected override void OnExit(ExitEventArgs e)
        {
            Settings.Default.Save();
            base.OnExit(e);
        }
    }
}