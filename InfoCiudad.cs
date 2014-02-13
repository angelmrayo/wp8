using GART.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace demoAR1
{
    public class InfoCiudad: ARItem
    {
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set {
                if (_descripcion != value)
                {
                    _descripcion = value;
                    NotifyPropertyChanged("Descripcion");
                }
                }
        }

        private BitmapImage _foto;

        public BitmapImage Foto
        {
            get { return _foto; }
            set
            {
                if (_foto != value)
                {
                    _foto = value;
                    NotifyPropertyChanged("Foto");
                }
            }
        }
        
        
    }
}
