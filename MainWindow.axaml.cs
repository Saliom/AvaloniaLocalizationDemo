using Avalonia.Controls;
using System.Globalization;
using System.ComponentModel;

namespace AvaloniaLocalizationDemo
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public new event PropertyChangedEventHandler PropertyChanged;
        public string HelloTxt => Lang.Resources.Hello;
        public string CurrentCultureTxt => Lang.Resources.Culture != null ? Lang.Resources.Culture.Name : "en-EN";

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void ComboBox_SelectionChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)
        {
            var comboBox = sender! as Avalonia.Controls.ComboBox;

            switch (comboBox!.SelectedIndex)
            {
                case 0:
                    Lang.Resources.Culture = new CultureInfo("fr-FR");
                    break;
                case 1:
                    Lang.Resources.Culture = new CultureInfo("en-EN");
                    break;
                case 2:
                    Lang.Resources.Culture = new CultureInfo("zh-CN");
                    break;
                case 3:
                    Lang.Resources.Culture = new CultureInfo("ja-JP");
                    break;
                case 4:
                    Lang.Resources.Culture = new CultureInfo("fil-PH");
                    break;
                default:
                    Lang.Resources.Culture = new CultureInfo("en-EN");
                    break;
            }

            OnPropertyChanged(nameof(HelloTxt));
            OnPropertyChanged(nameof(CurrentCultureTxt));

        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}