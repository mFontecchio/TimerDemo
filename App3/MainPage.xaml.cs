using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading; //closest I can get to system.windows.threading DispatcherTimer
using Windows.ApplicationModel.Core;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace App3
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private Timer timer;
        MyData myData = null;
        MyData myNewData = null;
        Random random = new Random();
        public MainPage()
        {
            this.InitializeComponent();
            
            myData = new MyData();
            myNewData = new MyData();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            textBlock.Text = "Timer Started"; //+ textBox.Text;
            timer = new Timer(timer_Tick, null, (int)TimeSpan.FromSeconds(1).TotalMilliseconds, (int)TimeSpan.FromSeconds(int.Parse(textBox.Text)).TotalMilliseconds);
        }

        private async void timer_Tick(object state)
        {
            //code to randomly generate a new value and update GetMeasurement
            await CoreApplication.MainView.CoreWindow.Dispatcher.RunAsync(CoreDispatcherPriority.Normal,
            () => {
                myData.Data = random.Next(1,11);
                myNewData.Data = random.Next(11, 20);
                this.DataContext = null;
                this.DataContext = myData;
                highRand.Text = myNewData.Data.ToString();
            });
        }

        private void Stopper_Click(object sender, RoutedEventArgs e)
        {
            timer.Dispose();
            textBlock.Text = "Timer Stopped";
        }
    }
}
