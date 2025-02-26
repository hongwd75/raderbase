using System;
using System.Windows.Controls;
using System.Windows.Threading;

namespace RadarBase.SubPage
{
	/// <summary>
	/// MainPage.xaml에 대한 상호 작용 논리
	/// </summary>
	public partial class MainPage : Page
	{
		private MapDraw gamemap;
		private DispatcherTimer timer;

		public MainPage()
		{
			InitializeComponent();
			gamemap = new MapDraw(MapCanvas);

            Loaded += MainPage_Loaded;
		}

        private void MainPage_Loaded(object sender, System.Windows.RoutedEventArgs e)
        {
			drawMapBase();
			timer = new DispatcherTimer();
			timer.Interval = TimeSpan.FromMilliseconds(10);
            timer.Tick += Timer_Tick;
			timer.Start();
		}

        private void Timer_Tick(object sender, EventArgs e)
        {
			drawMapBase();

		}

		
		private void drawMapBase()
        {
			gamemap.DrawAll();
		}


	}
}
