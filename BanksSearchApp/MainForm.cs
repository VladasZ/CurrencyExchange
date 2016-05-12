using BanksSearchApp.Markers;
using CurrencyExchange;
using CurrencyExchange.Database;
using GMap.NET;
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
        enum OverlayType
        {
            UserLocationMarker,
            BanksOverlay
        }

        public GMapControl MapControl { get; } = new GMapControl();
        public PointLatLng UserLocation
        {
            get
            {
                return getOverlay(OverlayType.UserLocationMarker).Markers.First().Position;
            }
        }

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            SetMapParams();

            searchRadiusTrackBar.Value = 1000;
            searchRadiusLabel.Text = "1000 м.";
        }

        void SetMapParams()
        {
            MapControl.Dock = DockStyle.Fill;

            Controls.Add(MapControl);

            MapControl.MapProvider = GMap.NET.MapProviders.GMapProviders.OpenStreetMap;
            GMaps.Instance.Mode = AccessMode.ServerAndCache;

            MapControl.Bearing = 0;
            MapControl.MaxZoom = 18;
            MapControl.MinZoom = 12;
            MapControl.Zoom = 12;

            MapControl.MouseWheelZoomType = MouseWheelZoomType.MousePositionAndCenter;

            MapControl.CanDragMap = true;

            MapControl.Position = new PointLatLng(53.902800, 27.561759);

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
                setUserMark(sender, e);

                addMarks(DatabaseManager.getBankDepartmentsMarks(UserLocation, searchRadiusTrackBar.Value));
            }

        }

        void setUserMark(object sender, MouseEventArgs e)
        {
            // удаляем предыдущую метку
            GMapOverlay prevUserLocation = getOverlay(OverlayType.UserLocationMarker);

            if (prevUserLocation != null)
            {
                MapControl.Overlays.Remove(prevUserLocation);
            }


            PointLatLng userLocation = MapControl.FromLocalToLatLng(e.X, e.Y);

            GMapOverlay markersOverlay = new GMapOverlay(OverlayType.UserLocationMarker.ToString());

            GMarkerGoogle markerG = new GMarkerGoogle(userLocation, GMarkerGoogleType.red);

            markerG.ToolTip = new GMapRoundedToolTip(markerG);
            markerG.ToolTipText = "Вы";
            MapControl.Overlays.Add(markersOverlay);
            markersOverlay.Markers.Add(markerG);
        }

        void addMarks(List<BankMark> marks)
        {
            //удаляем предыдущие марки

            GMapOverlay prevBankMarks = getOverlay(OverlayType.BanksOverlay);

            if (prevBankMarks != null)
            {
                MapControl.Overlays.Remove(prevBankMarks);
            }

            GMapOverlay banksOverlay = new GMapOverlay(OverlayType.BanksOverlay.ToString());
            MapControl.Overlays.Add(banksOverlay);

            foreach (BankMark mark in marks)
            {
                GMarkerGoogle bankMarker = new GMarkerGoogle(mark.Location, GMarkerGoogleType.arrow);
                bankMarker.ToolTip = new GMapRoundedToolTip(bankMarker);
                bankMarker.ToolTipText = mark.Title;
                banksOverlay.Markers.Add(bankMarker);
            }

          //  somePlace = marks.Last().Location;
        }


        GMapOverlay getOverlay(OverlayType overlayType)
        {
            return (from ov in MapControl.Overlays
                    where ov.Id == overlayType.ToString()
                    select ov).FirstOrDefault();
        }

        private void searchRadiusTrackBar_Scroll(object sender, EventArgs e)
        {
            searchRadiusLabel.Text = searchRadiusTrackBar.Value.ToString() + " м.";
            addMarks(DatabaseManager.getBankDepartmentsMarks(UserLocation, searchRadiusTrackBar.Value));
        }

        private void searchSettingsButton_Click(object sender, EventArgs e)
        {
            SearchSettingsForm form = new SearchSettingsForm();

            form.ShowDialog();
        }
    }
       
    }

