using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using MVVMBase;
using Microsoft.Win32;
using System.IO;

namespace RawImageView
{
    class MainWIndowViewModel:ViewModelBase
    {

        #region Property
        private int _width;
        public int Width
        {
            get { return _width; }
            set
            {
                _width = value;
                RaisePropertyChanged("Width");
            }
        }

        private int _height;
        public int Height
        {
            get { return _height; }
            set
            {
                _height = value;
                RaisePropertyChanged("Height");
            }
        }

        private int _headerSize;
        public int HeaderSize
        {
            get { return _headerSize; }
            set
            {
                _headerSize = value;
                RaisePropertyChanged("HeaderSize");
            }
        }

        private RawInformation.BitDepth _bitDepth;
        public RawInformation.BitDepth BitDepth
        {
            get { return _bitDepth; }
            set
            {
                _bitDepth = value;
                RaisePropertyChanged("BitDepth");
            }
        }

        private int _bitPosition;
        public int BitPosition
        {
            get { return _bitPosition; }
            set
            {
                _bitPosition = value;
                RaisePropertyChanged("BitPosition");
            }
        }

        private int _endian;
        public int Endian
        {
            get { return _endian; }
            set
            {
                _endian = value;
                RaisePropertyChanged("Endian");
            }
        }

        private int _headColor;
        public int HeadColor
        {
            get { return _headColor; }
            set
            {
                _headColor = value;
                RaisePropertyChanged("HeadColor");
            }
        }

        #endregion

        #region DelegateCommand
        private DelegateCommand _openCommnad;
        public DelegateCommand OpenCommand
        {
            get
            {
                if (_openCommnad == null)
                {
                    _openCommnad = new DelegateCommand(
                        ()=> { OnOpenCommand(); });
                }
                return _openCommnad;
            }
        }

        private DelegateCommand _closeCommand;
        public DelegateCommand CloseCommand
        {
            get
            {
                if (_closeCommand == null)
                {
                    _closeCommand = new DelegateCommand(
                        () => { CloseAction?.Invoke(); });
                }
                return _closeCommand;
            }
        }
        #endregion

        #region Action
        public Action CloseAction { get; set; }
        #endregion

        #region Constructor
        public MainWIndowViewModel(MainWindow main)
        {

        }
        #endregion

        #region Private Method
        private void OnOpenCommand()
        {
            var dialog = new OpenFileDialog();
            dialog.Filter= "RAWファイル (*.raw)|*.raw|TIFファイル (*.tif)|*.tif";

            bool? result = dialog.ShowDialog();

            if (result == true)
            {
                SettingWindow sw = new SettingWindow();
                sw.Title = Path.GetFileName( dialog.FileName);
                sw.ShowDialog();
            }
        }

        private void ShowRawImage(string fileName)
        {
            MessageBox.Show(fileName);
        }

        private void ReadRaw(string fileName)
        {
            MessageBox.Show(string.Format(
             "Width:{0}\n" +
             "Height:{1}\n" +
             "HeaderSize:{2}\n" +
             "BitDepth:{3}\n" +
             "BitPosition:{4}\n" +
             "Endian:{5}\n" +
             "HeadColor:{6}",
             Width, Height, HeaderSize, BitDepth, 
             BitPosition, Endian, HeadColor));
        }
        #endregion
    }
}
