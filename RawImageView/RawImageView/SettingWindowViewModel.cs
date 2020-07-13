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
            string[] depth= Enum.GetNames(typeof(RawInformation.BitDepth));
            BitDepthItems = ReplaceEnumValue(depth, "depth_", "");

            BitPositionItems = Enum.GetNames(typeof(RawInformation.BitPosition));

            EndianItems = Enum.GetNames(typeof(RawInformation.Endian));

            string[] color =  Enum.GetNames(typeof(RawInformation.HeadColor));
            HeadColorItems = ReplaceEnumValue(color, "_", " ");
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

        private string[] ReplaceEnumValue(string[] src, string srcStr, string dstStr)
        {
            string[] array = new string[src.Length];

            string tmp = string.Empty;

            for (int i = 0; i < src.Length; i++)
            {
                tmp = src[i].Replace(srcStr, dstStr);

                array[i] = tmp;
            }

            return array;
        }

        #endregion
    }
}
