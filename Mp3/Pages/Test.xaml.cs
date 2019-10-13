using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Mp3.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Test : Page
    {
        public Test()
        {
            this.InitializeComponent();
            var compositor = Window.Current.Compositor;
            var animation = compositor.CreateVector3KeyFrameAnimation();

            animation.InsertKeyFrame(1.0f, new Vector3(2.0f, 2.0f, 1.0f));
            animation.Duration = TimeSpan.FromSeconds(1);
            animation.Target = "Scale";

            button.StartAnimation(animation);
        }
    }
}
