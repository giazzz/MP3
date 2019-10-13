using Microsoft.Toolkit.Uwp.UI.Animations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;

namespace Mp3.Constant
{
    class Animation
    {
        public static void StartRotationImage(PersonPicture pic)
        {
            if (pic == null)
            {
                return;
            }
            pic.Rotate(value: 3600f, centerX: 40f, centerY: 40f, duration: 100000, delay: 0, easingType: EasingType.Linear).Start();
        }
        public static void StopRotationImage(PersonPicture pic)
        {
            if (pic == null)
            {
                return;
            }
            pic.Rotate(value: 0f, centerX: 40f, centerY: 40f, duration: 0, delay: 0, easingType: EasingType.Linear).Start();
        }
    }
}
