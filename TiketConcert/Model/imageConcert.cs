using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TiketConcert.Class;

namespace TiketConcert.Model
{
    public partial class Concert
    {
        private bool _isImageDownloaded = false;
        public Byte[] SaveImage { get; set; } = null;

        public Byte[] ByteImage
        {
            get
            {
                if (!String.IsNullOrEmpty(Poster) && !_isImageDownloaded)
                {
                    Byte[] _res;
                    try
                    {
                        _res = AppData.Context.GetImage(Poster);
                    }
                    catch
                    {
                        _res = null;
                    }
                    SaveImage = _res;
                    _isImageDownloaded = true;
                    return _res;
                }
                else
                {
                    return SaveImage;
                }
            }
        }
    }
    public partial class Orderer
    {
        private bool _isImageDownloaded = false;
        public Byte[] SaveImage { get; set; } = null;

        public Byte[] ByteImage
        {
            get
            {
                if (!String.IsNullOrEmpty(Poster) && !_isImageDownloaded)
                {
                    Byte[] _res;
                    try
                    {
                        _res = AppData.Context.GetImage(Poster);
                    }
                    catch
                    {
                        _res = null;
                    }
                    SaveImage = _res;
                    _isImageDownloaded = true;
                    return _res;
                }
                else
                {
                    return SaveImage;
                }
            }
        }

        public static implicit operator List<object>(Orderer v)
        {
            throw new NotImplementedException();
        }
    }
}
