using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.WindowsForms.ToolTips;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BanksSearchApp
{
    public partial class MainForm : Form
    {
        public GMapControl MapControl { get; } = new GMapControl();

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            SetMapParams();
        }

        void SetMapParams()
        {
            MapControl.Dock = DockStyle.Fill;

            Controls.Add(MapControl);

            MapControl.MapProvider = GMap.NET.MapProviders.GMapProviders.OpenStreetMap;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;

            MapControl.Bearing = 0;
            MapControl.MaxZoom = 18;
            MapControl.MinZoom = 11;
            MapControl.Zoom = 15;

            MapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;

            MapControl.CanDragMap = true;

            MapControl.Position = new GMap.NET.PointLatLng(53.902800, 27.561759);

            MapControl.MarkersEnabled = true;

            MapControl.MouseClick += mapClick;
            MapControl.OnMapZoomChanged += ZoomChanged;

            scaleLabel.Text = "Масштаб: " + MapControl.Zoom.ToString();

        }

        private void ZoomChanged()
        {
            scaleLabel.Text = "Масштаб: " + MapControl.Zoom.ToString();
        }

        void mapClick(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                // удаляем предыдущую метку
                GMapOverlay prevUserLocation = (from ov in MapControl.Overlays
                                                where ov.Id == "UserLocationMarker"
                                                select ov).FirstOrDefault();

                if (prevUserLocation != null)
                {
                    MapControl.Overlays.Remove(prevUserLocation);
                }


                double X = MapControl.FromLocalToLatLng(e.X, e.Y).Lng;
                double Y = MapControl.FromLocalToLatLng(e.X, e.Y).Lat;

                GMapOverlay markersOverlay = new GMapOverlay(MapControl, "UserLocationMarker");

                GMapMarkerGoogleRed markerG = new GMapMarkerGoogleRed
                                               (new GMap.NET.PointLatLng(Y, X));

                markerG.ToolTip = new GMapRoundedToolTip(markerG);
                markerG.ToolTipText = "Вы";
                markersOverlay.Markers.Add(markerG);
                MapControl.Overlays.Add(markersOverlay);
            }
           
        }
       
    }
}
