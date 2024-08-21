using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using System.Data.Entity;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using System.Data.SqlClient;
using Microsoft.VisualBasic.Logging;


namespace WinFormsApp2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

        }


        private void gMapControl1_Load(object sender, EventArgs e)
        {

        }

        private async void LoadintoMap_Click(object sender, EventArgs e)
        {
            GMapProviders.GoogleMap.ApiKey = "AIzaSyBa1LD82u9mXVwbYXmK8LgMQNre1LfCo5Q";

            map.MapProvider = GMapProviders.GoogleMap;
            double lat = Convert.ToDouble(txtlat.Text);
            double lon = Convert.ToDouble(txtlon.Text);
            map.Position = new GMap.NET.PointLatLng(lat, lon);
            map.DragButton = MouseButtons.Left;
            map.MinZoom = 5;
            map.MaxZoom = 100;
            map.Zoom = 10;

            PointLatLng point = new PointLatLng(lat, lon);
            
            var add = await GetAddressFromCoordinates(lat, lon);
            if (add != null)
            {
                txtAddress.Text = add;
                GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_pushpin);

                GMapOverlay markers = new GMapOverlay("markers");
                marker.ToolTipText = "Latitude:" + lat + ",\nLongitude:" + lon + ",\nAddress:" + add;

                markers.Markers.Add(marker);
                map.Overlays.Clear();
                map.Overlays.Add(markers);
                insertdata(lat,lon,add);
            }
            else
                txtAddress.Text = "unable to load address";

        }
    
        static async Task<string> GetAddressFromCoordinates(double lat, double lng)
        {
            string url = $"https://nominatim.openstreetmap.org/reverse?format=jsonv2&lat={lat}&lon={lng}";

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.UserAgent.TryParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");

                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();
                JObject json = JObject.Parse(responseBody);

                // Parse the address from the response JSON
                JToken formattedAddress = json["display_name"];
                return formattedAddress?.ToString();
            }
        }


        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            map.ShowCenter = false;
            map.DragButton = MouseButtons.Left;
            map.MapProvider = GMapProviders.GoogleMap;
            GMapOverlay markers = new GMapOverlay("markers");

        }


        private async void map_MouseClick(object sender, MouseEventArgs e)
        {
            if (chkEnableMouseclick.Checked == true && e.Button == MouseButtons.Left)
            {
                var point = map.FromLocalToLatLng(e.X, e.Y);
                double lat = point.Lat;
                double lon = point.Lng;

                txtlat.Text = lat + "";
                txtlon.Text = lon + "";

                map.Position = point;

                var add = await GetAddressFromCoordinates(lat, lon);
                if (add != null)
                {
                    txtAddress.Text = add;
                    var markers = new GMapOverlay("markers");
                    var marker = new GMarkerGoogle(point, GMarkerGoogleType.red_pushpin);
                    marker.ToolTipText = "Latitude:" + lat + ",\nLongitude:" + lon + ",\nAddress:" + add;
                    markers.Markers.Add(marker);
                    map.Overlays.Add(markers);
                    insertdata(lat, lon, add);
                }
                else
                    txtAddress.Text = "unable to load address";

            }

        }

        private async void btnloadlat_Click(object sender, EventArgs e)
        {
            string json = JsonConvert.SerializeObject(txtAddress.Text);
            
            
                string url = $"https://nominatim.openstreetmap.org/search?q={Uri.EscapeDataString(json)}&format=json&limit=1";

                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.UserAgent.TryParseAdd("Mozilla/5.0 (compatible; AcmeInc/1.0)");

                    HttpResponseMessage response = await client.GetAsync(url);
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();
                    JArray json_1 = JArray.Parse(responseBody);

                if (json_1.Count > 0)
                {
                    var firstResult = json_1[0];
                    double latitude = (double)firstResult["lat"];
                    double longitude = (double)firstResult["lon"];
                    txtlat.Text = latitude.ToString();
                    txtlon.Text = longitude.ToString();
                    insertdata(latitude, longitude, txtAddress.Text);
                    GMapProviders.GoogleMap.ApiKey = "AIzaSyBa1LD82u9mXVwbYXmK8LgMQNre1LfCo5Q";

                    map.MapProvider = GMapProviders.GoogleMap;
                    double lat = Convert.ToDouble(txtlat.Text);
                    double lon = Convert.ToDouble(txtlon.Text);
                    map.Position = new GMap.NET.PointLatLng(lat, lon);
                    map.DragButton = MouseButtons.Left;
                    map.MinZoom = 5;
                    map.MaxZoom = 100;
                    map.Zoom = 10;

                    PointLatLng point = new PointLatLng(lat,lon);
                    GMapMarker marker = new GMarkerGoogle(point, GMarkerGoogleType.red_pushpin);

                    GMapOverlay markers = new GMapOverlay("markers");
                    marker.ToolTipText = "Latitude:" + lat + ",\nLongitude:" + lon + ",\nAddress:" + txtAddress.Text;
                    markers.Markers.Add(marker);
                    map.Overlays.Clear();
                    map.Overlays.Add(markers);



                }


            }
        }
        private void insertdata(double lat, double lon, string add)
        {
            SqlConnection con = null;

            con = new SqlConnection("data source=ARAVIND\\SQLEXPRESS01; database=POIdatabase; integrated security=SSPI");

            string query = "insert into PointsOfInterest(Latitude,Longitude,Address)values(" + lat + "," + lon + ",'" + add + "')";
            SqlCommand sc = new SqlCommand(query, con);
            con.Open();
            int status = sc.ExecuteNonQuery();
            con.Close();
        }
    }
    
}



