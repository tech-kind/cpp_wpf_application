using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WpfApp.Model
{
    public class MainWindowModel
    {
        public MainWindowModel()
        {
            DataPath = "";
            SrcImage = new BitmapImage();
            ProcImage = new BitmapImage();
            ThldMax = 50;
        }

        public string DataPath { get; set; }

        public BitmapImage SrcImage { get; set; }

        public BitmapImage ProcImage { get; set; }

        public int ThldMax { get; set; }        
    }
}
