using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using demoAR1.Resources;
using System.Collections.ObjectModel;
using GART.Data;
using System.Windows.Media.Imaging;
using GART;

namespace demoAR1
{
    public partial class MainPage : PhoneApplicationPage
    {
        private ObservableCollection<ARItem> lista;


        private void ObtenerDatos()
        {
            System.Device.Location.GeoCoordinate actual = arDisplay.Location;
            Uri uri = new Uri("/images/foto1.png", UriKind.Relative);
            BitmapImage bmp = new BitmapImage(uri);
            lista.Add(new InfoCiudad
            {
                GeoLocation = new System.Device.Location.GeoCoordinate(actual.Latitude, actual.Longitude),
                Content = "Actual",
                Descripcion = "Posición actual",
                Foto = bmp
            });
            lista.Add(new InfoCiudad
            {
                GeoLocation = new System.Device.Location.GeoCoordinate(40.4396299, -3.6203223999999636),
                Content = "Alhambra-Eidos",
                Descripcion = "A-E"
            });
            lista.Add(new InfoCiudad
            {
                GeoLocation = new System.Device.Location.GeoCoordinate(40.4392468, -3.63237909999998),
                Content = "Albasanz 14",
                Descripcion = "A14"
            });
            lista.Add(new InfoCiudad
            {
                GeoLocation = new System.Device.Location.GeoCoordinate(40.4345276, -3.632699099999968),
                Content = "Altafit",
                Descripcion = "Altafit",
                Foto = bmp
            });
            lista.Add(new InfoCiudad
            {
                GeoLocation = new System.Device.Location.GeoCoordinate(40.43819149999999, -3.6351942999999665),
                Content = "Test",
                Descripcion = "Test",
                Foto=bmp
            });
            lista.Add(new InfoCiudad
            {
                GeoLocation = new System.Device.Location.GeoCoordinate(40.4330305, -3.628395800000021),
                Content = "Test2",
                Descripcion = "Test2",
                Foto=bmp
            });

            arDisplay.ARItems = lista;
        }

        // Constructor
        public MainPage()
        {
            InitializeComponent();
            lista = new ObservableCollection<ARItem>();
            ObtenerDatos();



            // Código de ejemplo para traducir ApplicationBar
            //BuildLocalizedApplicationBar();
        }

        // Código de ejemplo para compilar una ApplicationBar traducida
        //private void BuildLocalizedApplicationBar()
        //{
        //    // Establecer ApplicationBar de la página en una nueva instancia de ApplicationBar.
        //    ApplicationBar = new ApplicationBar();

        //    // Crear un nuevo botón y establecer el valor de texto en la cadena traducida de AppResources.
        //    ApplicationBarIconButton appBarButton = new ApplicationBarIconButton(new Uri("/Assets/AppBar/appbar.add.rest.png", UriKind.Relative));
        //    appBarButton.Text = AppResources.AppBarButtonText;
        //    ApplicationBar.Buttons.Add(appBarButton);

        //    // Crear un nuevo elemento de menú con la cadena traducida de AppResources.
        //    ApplicationBarMenuItem appBarMenuItem = new ApplicationBarMenuItem(AppResources.AppBarMenuItemText);
        //    ApplicationBar.MenuItems.Add(appBarMenuItem);
        //}

        //protected override void OnOrientationChanged(OrientationChangedEventArgs e)
        //{
        //    base.OnOrientationChanged(e);
        //    arDisplay.Orientation = GART.BaseControls.ControlOrientation.Default;
        //}

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);
            arDisplay.StartServices();
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);
            arDisplay.StopServices();
        }

        private void btn3D_Click(object sender, EventArgs e)
        {
            UIHelper.ToggleVisibility(worldView);
        }

        private void btnHeading_Click(object sender, EventArgs e)
        {
            UIHelper.ToggleVisibility(headingIndicator);
        }

        private void btnMapa_Click(object sender, EventArgs e)
        {
            UIHelper.ToggleVisibility(overheadMap);
        }

        private void btnRotar3D_Click(object sender, EventArgs e)
        {
            CambiarRotacion();
        }

        private void CambiarRotacion()
        {
            if (headingIndicator.RotationSource == GART.Controls.RotationSource.AttitudeHeading)
            {
                headingIndicator.RotationSource = GART.Controls.RotationSource.North;
                overheadMap.RotationSource = GART.Controls.RotationSource.AttitudeHeading;
            }
            else
            {
                overheadMap.RotationSource = GART.Controls.RotationSource.North;
                headingIndicator.RotationSource = GART.Controls.RotationSource.AttitudeHeading;
            }
        }

        

    }
}