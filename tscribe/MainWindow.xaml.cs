using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Printing;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace tscribe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new MainViewModel();
        }
    }


    public partial class MainViewModel : ObservableObject
    {
        private readonly DispatcherTimer timer;

        private readonly int tickPeriodS = 1;

        [ObservableProperty]
        private TimeSpan totalTime;

        [ObservableProperty]
        private TimeSpan currentTime;

        [RelayCommand]
        private void ToggleTimer()
        {
            if (timer.IsEnabled) { timer.Stop(); }
            else 
            {
                CurrentTime = TimeSpan.Zero;
                timer.Start(); 
            }
        }

        public MainViewModel()
        {
            timer = new();
            timer.Interval = TimeSpan.FromSeconds(tickPeriodS);
            timer.Tick += Timer_Tick;

        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            CurrentTime += TimeSpan.FromSeconds(tickPeriodS);
            TotalTime += TimeSpan.FromSeconds(tickPeriodS);
        }
    }

    public partial class Project : ObservableObject
    {
        [ObservableProperty]
        string projectName = String.Empty;

        [ObservableProperty]
        string projectId = string.Empty;

        [ObservableProperty]
        TimeSpan projectTime = TimeSpan.Zero; 
    }

}
