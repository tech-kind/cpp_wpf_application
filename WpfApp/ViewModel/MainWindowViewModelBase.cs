using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfApp.Model;

namespace WpfApp.ViewModel
{
    public abstract class MainWindowViewModelBase : ViewModelBase
    {
        static readonly BitmapSource _defaultImage;
        public MainWindowModel Model = new MainWindowModel();

        /// <summary>
        /// 元画像のパス
        /// </summary>
        public string DataPath
        {
            get { return Model.DataPath; }
            set
            {
                if (Model.DataPath != value)
                {
                    Model.DataPath = value;
                    OnPropertyChanged("DataPath");
                }
            }
        }

        /// <summary>
        /// 二値化最大値
        /// </summary>
        public string ThldMax
        {
            get { return Model.ThldMax.ToString(); }
            set
            {
                try
                {
                    int ivalue = int.Parse(value);

                    if (ivalue < 0) ivalue = 0;
                    if (ivalue > 50) ivalue = 50;

                    if (Model.ThldMax != ivalue)
                    {
                        Model.ThldMax = ivalue;
                        OnPropertyChanged("ThldMax");
                    }
                }
                catch
                {
                    ThldMax = Model.ThldMax.ToString();
                }
            }
        }

        /// <summary>
        /// 元画像
        /// </summary>
        public BitmapImage SrcImage
        {
            get
            {
                return Model.SrcImage;
            }
            set
            {
                if (Model.SrcImage != value)
                {
                    Model.SrcImage = value;
                    OnPropertyChanged("SrcImage");
                }
            }
        }

        /// <summary>
        /// 加工画像
        /// </summary>
        public BitmapImage ProcImage
        {
            get
            {
                return Model.ProcImage;
            }
            set
            {
                if (Model.ProcImage != value)
                {
                    Model.ProcImage = value;
                    OnPropertyChanged("ProcImage");
                }
            }
        }

        /// <summary>
        /// 画像読み込み
        /// </summary>    
        public ICommand SelectCommand => new DelegateCommand(obj =>
        {
            var dialog = new OpenFileDialog();
            var result = dialog.ShowDialog();
            
            if(result == true)
            {
                DataPath = dialog.FileName;
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.UriSource = new Uri(dialog.FileName);
                image.EndInit();
                SrcImage = image;
            }
        });

        protected abstract void ProcessingThreshold();

        /// <summary>
        /// 二値化開始
        /// </summary>    
        public ICommand StartCommand => new DelegateCommand(obj =>
        {
            ProcessingThreshold();
        });
    }
}
