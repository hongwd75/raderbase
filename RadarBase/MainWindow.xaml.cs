using RadarBase.SubPage;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace RadarBase
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow 
    {
        private const double SwipeThreshold = 50.0; // 스와이프로 인식할 최소 거리

        private bool capturedMouse = false;
        private Point capturedMouseStartPoint;
        private int currentPageIndex = 0;

        private List<Page> Pages = new List<Page>();

        public MainWindow()
        {
            InitializeComponent();
            Pages.Add(new MainPage());
            Pages.Add(new ConfigPage());
            MainFrame.NavigationUIVisibility = System.Windows.Navigation.NavigationUIVisibility.Hidden;


            ShowViewPage(1);

            this.MouseLeftButtonDown += MainWindow_MouseLeftButtonDown;
            this.MouseMove += MainWindow_MouseMove;
            this.MouseLeave += MainWindow_MouseLeave;
            this.MouseLeftButtonUp += MainWindow_MouseLeftButtonUp;
        }

        private void ShowViewPage(int index)
        {
            currentPageIndex = index;
            MainFrame.Content = Pages[index];
        }


        #region ## 마우스 콘트롤러
        private void MainWindow_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            capturedMouse = false;
        }
        
        private void MainWindow_MouseLeave(object sender, MouseEventArgs e)
        {
            capturedMouse = false;
        }

        // 스와이프 스크롤 코드
        private void MainWindow_MouseMove(object sender, MouseEventArgs e)
        {
            if(capturedMouse == true && 
                MouseButtonState.Pressed == e.LeftButton)
            {
                Point currentPoint = e.GetPosition(this);
                Vector difference = capturedMouseStartPoint - currentPoint;

                if (Math.Abs(difference.X) > SwipeThreshold)
                {
                    int currentpage = currentPageIndex;
                    if (difference.X > 0)
                    {
                        // 오른쪽으로 스와이프
                        currentpage++;
                        if (currentpage >= Pages.Count) 
                            currentpage = 0;
                    }
                    else if (difference.X < 0)
                    {
                        // 왼쪽으로 스와이프
                        currentpage--;
                        if (currentpage < 0)
                        {
                            currentpage = Pages.Count - 1;
                        }
                    }

                    ShowViewPage(currentpage);
                    capturedMouse = false;
                }
            }
        }

        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            capturedMouseStartPoint = e.GetPosition(this);
            capturedMouse = true;
        }
        #endregion

        #region ## 윈도우 크기 변경
        private void Window_SizeChanged(object sender, System.Windows.SizeChangedEventArgs e)
        {
            foreach (var page in Pages)
            {
                if (page != null)
                {
                    // MainFrame의 실제 크기를 가져옵니다.
                    double frameWidth = MainFrame.ActualWidth;
                    double frameHeight = MainFrame.ActualHeight;

                    // Page의 크기를 Frame 크기에 맞춥니다.
                    page.Width = frameWidth;
                    page.Height = frameHeight;

                    // Page 내의 루트 요소(예: Grid)의 크기도 조정합니다.
                    if (page.Content is FrameworkElement rootElement)
                    {
                        rootElement.Width = frameWidth;
                        rootElement.Height = frameHeight;
                    }
                }
            }
        }
        #endregion
    }
}