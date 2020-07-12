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
