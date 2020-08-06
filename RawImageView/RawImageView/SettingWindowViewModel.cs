using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMBase;
using System.Windows;

namespace RawImageView
{
    public class SettingWindowViewModel:ViewModelBase
    {

        public class BitDepthItem
        {
            public RawInformation.BitDepth BitDepthData { get; set; }
            public string DisplayBitDepthData { get; set; }
        }

        public bool OKButtonClicked = false;

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

        /// <summary>
        /// BitDepth
        /// </summary>
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

        private List<BitDepthItem> _bitDepth_List;
        public List<BitDepthItem> BitDepth_List
        {
            get { return _bitDepth_List; }
            set
            {
                _bitDepth_List = value;
                RaisePropertyChanged("Items");
            }
        }

        private RawInformation.BitDepth _selectedBitDepth;
        public RawInformation.BitDepth SelectedBitDepth
        {
            get { return _selectedBitDepth; }
            set
            {
                _selectedBitDepth = value;
                RaisePropertyChanged("SelectedBitDepth");
            }
        }

        /// <summary>
        /// BitPosition
        /// </summary>
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
        private int _selectedBitPosition;
        public int SelectedBitPosition
        {
            get { return _selectedBitPosition; }
            set
            {
                _selectedBitPosition = value;
                RaisePropertyChanged("SelectedBitPosition");
            }
        }

        /// <summary>
        /// Endian
        /// </summary>
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

        private int _selectedEndian;
        public int SelectedEndian
        {
            get { return _selectedEndian; }
            set
            {
                _selectedEndian = value;
                RaisePropertyChanged("SelectedEndian");
            }
        }

        /// <summary>
        /// HeadColor
        /// </summary>
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

        private int _selectedHeadColor;
        public int SelectedHeadColor
        {
            get { return _selectedHeadColor; }
            set
            {
                _selectedHeadColor = value;
                RaisePropertyChanged("SelectedHeadColor");
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
                        () => {
                                OnOKButtonClickCommand();
                            OKButtonClicked = true;
                            CloseAction?.Invoke();
                        });
                }
                return _okButtonClickCommand;
            }
        }

        private DelegateCommand _cancelButtonClickCommand;
        public DelegateCommand CancelButtonClickCommand
        {
            get
            {
                if (_cancelButtonClickCommand == null)
                {
                    _cancelButtonClickCommand = new DelegateCommand(
                        () =>
                        {
                            OKButtonClicked = false;
                            CloseAction?.Invoke();
                        });
                }
                return _cancelButtonClickCommand;
            }
        }

        #endregion

        #region Action
        public Action CloseAction { get; set; }
        #endregion

        #region Constructor
        public SettingWindowViewModel(SettingWindow sw)
        {
            string[] depth= Enum.GetNames(typeof(RawInformation.BitDepth));
            BitDepthItems = ReplaceEnumValue(depth, "depth_", "");
            var Items = new List<BitDepthItem>
            {
                new BitDepthItem(){BitDepthData = RawInformation.BitDepth.depth_8bits, DisplayBitDepthData = BitDepthItems[0]},
                new BitDepthItem(){BitDepthData = RawInformation.BitDepth.depth_10bits, DisplayBitDepthData = BitDepthItems[1]},
                new BitDepthItem(){BitDepthData = RawInformation.BitDepth.depth_12bits, DisplayBitDepthData = BitDepthItems[2]},
                new BitDepthItem(){BitDepthData = RawInformation.BitDepth.depth_14bits, DisplayBitDepthData = BitDepthItems[3]},
                new BitDepthItem(){BitDepthData = RawInformation.BitDepth.depth_16bits, DisplayBitDepthData = BitDepthItems[4]}
            };

            BitDepth_List = Items;

            SelectedBitDepth = RawInformation.BitDepth.depth_8bits;


            BitPositionItems = Enum.GetNames(typeof(RawInformation.BitPosition));
            SelectedBitPosition = (int)RawInformation.BitPosition.LSB;

            EndianItems = Enum.GetNames(typeof(RawInformation.Endian));
            SelectedEndian = (int)RawInformation.Endian.LITTLE;

            string[] color =  Enum.GetNames(typeof(RawInformation.HeadColor));
            HeadColorItems = ReplaceEnumValue(color, "_", " ");
            SelectedHeadColor = (int)RawInformation.HeadColor.Red;
        }
        #endregion

        #region Private Method
        private void OnOKButtonClickCommand()
        {
            // MainWindowにデータを渡す
            MainWindow mw = new MainWindow();
            mw.WidthValue = Width;
            mw.HeightValue = Height;
            mw.HeaderSize = HeaderSize;
            mw.BitDepth = SelectedBitDepth;
            mw.BitPosition = SelectedBitPosition;
            mw.Endian = SelectedEndian;
            mw.HeadColor = SelectedHeadColor;
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
