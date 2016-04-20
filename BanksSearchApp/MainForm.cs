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
        GMapControl mapControl;

        public MainForm()
        {
            InitializeComponent();
            Load += MainForm_Load;
        }

        void MainForm_Load(object sender, EventArgs e)
        {
            SetParamsMap();
        }


        // ПРИМЕР РАБОТЫ С КАРТОЙ ! 
        // (данный код используйте по своему усмотрению!)
        void SetParamsMap()
        {
            // Создание элемента, отображающего карту !
            mapControl = new GMapControl();
            // Растягивание элемента на все окно!
            mapControl.Dock = DockStyle.Fill;
            // Добавление элемента 
            Controls.Add(mapControl);

// ОБЩИЕ НАСТРОЙКИ КАРТЫ 
            //Указываем, что будем использовать карты OpenStreetMap.
            mapControl.MapProvider = GMap.NET.MapProviders.GMapProviders.OpenStreetMap;
            // Указываем источник данных карты (выбран: интренети или локальный кэш)
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerAndCache;

           
            //Настройки для компонента GMap.
            mapControl.Bearing = 0;
    
      // МАСШТАБИРОВАНИЕ
            //Указываем значение максимального приближения.
            mapControl.MaxZoom = 18;

            //Указываем значение минимального приближения.
            mapControl.MinZoom = 2;

            //Указываем, что при загрузке карты будет использоваться 
            //16ти кратной приближение.
            mapControl.Zoom = 17;

            //Устанавливаем центр приближения/удаления
            //курсор мыши.
            mapControl.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;


  // НАВИГАЦИЯ ПО КАРТЕ 
            //CanDragMap - Если параметр установлен в True,
            //пользователь может перетаскивать карту  помощью правой кнопки мыши. 
            mapControl.CanDragMap = true;

            //Указываем что перетаскивание карты осуществляется 
            //с использованием левой клавишей мыши. По умолчанию - правая.
            mapControl.DragButton = MouseButtons.Left;

            //Указываем элементу управления, что необходимо при открытии карты
            // прейти по координатам 
            mapControl.Position = new GMap.NET.PointLatLng(53.902800, 27.561759);


// ОТОБРАЖЕНИЕ МАРКЕРОВ НА КАРТЕ 
            //MarkersEnabled - Если параметр установлен в True,
            //любые маркеры, заданные вручную будет показаны.
            //Если нет, они не появятся.
            mapControl.MarkersEnabled = true;
                  
            //Создаем новый список маркеров, с указанием компонента 
            //в котором они будут использоваться и названием списка.
            GMap.NET.WindowsForms.GMapOverlay markersOverlay =
                new GMap.NET.WindowsForms.GMapOverlay(mapControl, "marker");
            //Инициализация нового ЗЕЛЕНОГО маркера, с указанием его координат.
            GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen markerG =
                new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleGreen(
                //Указываем координаты 
                new GMap.NET.PointLatLng(53.902542, 27.561781));
            markerG.ToolTip =
                new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(markerG);
            //Текст отображаемый при наведении на маркер.
            markerG.ToolTipText = "Объект №1";

            //Инициализация нового КРАСНОГО маркера, с указанием его координат.
            GMap.NET.WindowsForms.Markers.GMapMarkerGoogleRed markerR =
                new GMap.NET.WindowsForms.Markers.GMapMarkerGoogleRed(
                //Указываем координаты 
                new GMap.NET.PointLatLng(53.902752, 27.561294));
            markerR.ToolTip = new GMap.NET.WindowsForms.ToolTips.GMapBaloonToolTip(markerR);
            //Текст отображаемый при наведении на маркер.
            markerR.ToolTipText = "Объект №2";

            //Добавляем маркеры в список маркеров.
            //Зеленый маркер
            markersOverlay.Markers.Add(markerG);
            //Красный маркет
            markersOverlay.Markers.Add(markerR);
            //Добавляем в компонент, список маркеров.
            mapControl.Overlays.Add(markersOverlay);

// СОБЯТИЯ ПО КАРТЕ !
            mapControl.MouseClick += gMapControl1_MouseClick;

        
        }

       

        void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            double X = mapControl.FromLocalToLatLng(e.X, e.Y).Lng;
            double Y = mapControl.FromLocalToLatLng(e.X, e.Y).Lat;
            GMapOverlay markersOverlay = new GMapOverlay(mapControl, "NewMarkers");
            GMapMarkerGoogleRed markerG = new GMapMarkerGoogleRed
                                           (new GMap.NET.PointLatLng(Y, X));
           markerG.ToolTip = new GMapRoundedToolTip(markerG);
           markerG.ToolTipText = "Новый объект";
           markersOverlay.Markers.Add(markerG);
           mapControl.Overlays.Add(markersOverlay);
        }
       
    }
}
