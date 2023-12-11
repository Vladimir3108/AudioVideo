using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AudioVideo
{
    /// <summary>
    /// Логика взаимодействия для App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static VideoAudioSalonEntities1 AudioSalon { get; } = new VideoAudioSalonEntities1();
        public static User CurrentUser = null;
    }
}
