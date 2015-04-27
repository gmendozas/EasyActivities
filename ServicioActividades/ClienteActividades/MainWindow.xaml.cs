using GoogleMaps.LocationServices;
using RepositorioDB.MongoDb.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace ClienteActividades
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private Actividad actividad;
        private DateTime horaInicio;
        private DispatcherTimer dispatcherTimer;
        List<Actividad> actividades = null;

        public MainWindow()
        {
            InitializeComponent();
            this.actividad = new Actividad();
            this.actividad.Persona = new Persona
                                        {
                                            Nombre = "Gilberto Mendoza",
                                            Usuario = "gmendoza",
                                            Correo = "gmendoza@syesoftware.com"
                                        };
            this.actividad.Fecha = "24/04/2015";//DateTime.Now.ToString("dd/MM/yyyy");
            this.dispatcherTimer = null;
            ObtenerActividades();
        }

        private async void ObtenerActividades()
        {
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:53675/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    string uri = "api/Actividades/" + this.actividad.Fecha.Replace('/', '-');
                    HttpResponseMessage response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        actividades = response.Content.ReadAsAsync<IEnumerable<Actividad>>().Result.ToList<Actividad>();
                        dtgActividades.ItemsSource = actividades;
                    }
                }
            }
            catch (Exception ex)
            {
                actividades = new List<Actividad>();
                MessageBox.Show(this, ex.Message);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (Object.Equals(null, dispatcherTimer))
            {
                if(string.IsNullOrEmpty(Descripcion.Text.Trim()))
                {
                    MessageBox.Show(this, "Ingrese una descripción para la actividad");
                    return;
                }
                if (string.IsNullOrEmpty(Tipo.Text.Trim()))
                {
                    MessageBox.Show(this, "Ingrese un tipo de actividad");
                    return;
                }

                actividad.Descripcion = Descripcion.Text;
                actividad.TipoActividad = new TipoActividad();
                horaInicio = DateTime.Now;
                actividad.HoraInicio = horaInicio.TimeOfDay;
                txbHoraInicio.Text = horaInicio.ToString("hh:mm:ss");
                var address = "Av Insurgentes Sur 1458, Benito Juarez Actipan, Benito Juárez 03230 Ciudad de México, D.F.";

                var locationService = new GoogleLocationService();
                var point = locationService.GetLatLongFromAddress(address);

                actividad.TipoActividad = new TipoActividad
                                            {
                                                Nombre = Tipo.Text,
                                                Descripcion = string.Empty
                                            };

                actividad.Ubicacion = new Ubicacion
                                        {
                                            Latitud = point.Latitude.ToString(),
                                            Longitud = point.Longitude.ToString()
                                        };
                dispatcherTimer = new DispatcherTimer();
                dispatcherTimer.Tick += new EventHandler(dispatcherTimer_Tick);
                dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
                dispatcherTimer.Start();                
            }
            else
            {
                dispatcherTimer.Stop();
                dispatcherTimer = null;
                actividad.HoraFin = TimeSpan.Parse(tblTimer.Text);
                actividad.Duracion = actividad.HoraFin.Subtract(actividad.HoraInicio);
                CambiarEstadoHabilitado(true);
            }
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {
            tblTimer.Text = DateTime.Now.ToString("HH:mm:ss");
        }

        private async void Button_Click_1(object sender, RoutedEventArgs e)
        {
            BtnGuardar.IsEnabled = false;
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:53675/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.PostAsJsonAsync("api/Actividades", actividad);
                    if (response.IsSuccessStatusCode)
                    {
                        CambiarEstadoHabilitado(false);
                        actividades.Add(actividad);
                        dtgActividades.ItemsSource = actividades;
                        InicializarActividad();
                        MessageBox.Show(this, "Actividad agregada");                        
                    }                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(this, ex.Message);
            }
            BtnGuardar.IsEnabled = true;
        }

        private void CambiarEstadoHabilitado(bool estado)
        {
            BtnGuardar.IsEnabled = estado;
            Descripcion.IsEnabled = !estado;
            Tipo.IsEnabled = !estado;
            BtnTimer.IsEnabled = !estado;
        }

        private void InicializarActividad()
        {
            tblTimer.Text = txbHoraInicio.Text = Descripcion.Text = Tipo.Text = string.Empty;
        }
    }
}
