using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMBase;
using System.Windows;

namespace RawImageView
{
    class SettingWindowViewModel:ViewModelBase
    {

        #region Property
        /// <summary>
        /// Width
        /// </summary>
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

        /// <summary>
        /// Height
        /// </summary>
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

        /// <summary>
        /// HeaderSize
        /// </summary>
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

        private string[] _bitDepthItems;
        public string[] BitDepthItems
        {
            get { return _bitDepthItems; }
            set
            {
                _bitDepthItems = value;
                RaisePropertyChanged("BitDepthItems");
            }
        }

        private string[] _bitPositionItems;
        public string[] BitPositionItems
        {
            get { return _bitPositionItems; }
            set
            {
                _bitPositionItems = value;
                RaisePropertyChanged("BitPositionItems");
            }
        }

        private string[] _endianItems;
        public string[] EndianItems
        {
            get { return _endianItems; }
            set
            {
                _endianItems = value;
                RaisePropertyChanged("EndianItems");
            }
        }

        private string[] _headColorItems;
        public string[] HeadColorItems
        {
            get { return _headColorItems; }
            set
            {
                _headColorItems = value;
                RaisePropertyChanged("HeadColorItems");
            }
        }

        #endregion

        #region DelegateCommand
        private DelegateCommand _okButtonClickCommand;
        public DelegateCommand OKButtonClickCommand
        {
            get
            {
                if (_okButtonClickCommand == null)
                {
                    _okButtonClickCommand = new DelegateCommand(
                        () => { OnOKButtonClickCommand(); });
                }
                return _okButtonClickCommand;
            }
        }
        #endregion

        #region Constructor
        public SettingWindowViewModel(SettingWindow sw)
        {
            BitDepthItems= Enum.GetNames(typeof(RawInformation.BitDepth));
            BitPositionItems = Enum.GetNames(typeof(RawInformation.BitPosition));
            EndianItems = Enum.GetNames(typeof(RawInformation.Endian));
            HeadColorItems = Enum.GetNames(typeof(RawInformation.HeadColor));
        }
        #endregion

        #region Private Method
        private void OnOKButtonClickCommand()
        {
            MessageBox.Show(string.Format(
                "Width:{0}\n" +
                "Height:{1}\n" +
                "HeaderSize:{2}\n", Width, Height, HeaderSize));
        }
        #endregion
    }
}
