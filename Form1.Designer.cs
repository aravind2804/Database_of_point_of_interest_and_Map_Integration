namespace WinFormsApp2
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            splitter1 = new Splitter();
            map = new GMap.NET.WindowsForms.GMapControl();
            lat = new Label();
            txtlat = new TextBox();
            txtlon = new TextBox();
            lon = new Label();
            LoadintoMap = new Button();
            txtAddress = new RichTextBox();
            chkEnableMouseclick = new CheckBox();
            btnloadlat = new Button();
            SuspendLayout();
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(530, 534);
            splitter1.TabIndex = 0;
            splitter1.TabStop = false;
            splitter1.SplitterMoved += splitter1_SplitterMoved;
            // 
            // map
            // 
            map.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            map.Bearing = 0F;
            map.CanDragMap = true;
            map.EmptyTileColor = Color.Navy;
            map.GrayScaleMode = false;
            map.HelperLineOption = GMap.NET.WindowsForms.HelperLineOptions.DontShow;
            map.LevelsKeepInMemory = 5;
            map.Location = new Point(24, 12);
            map.MarkersEnabled = true;
            map.MaxZoom = 2;
            map.MinZoom = 2;
            map.MouseWheelZoomEnabled = true;
            map.MouseWheelZoomType = GMap.NET.MouseWheelZoomType.MousePositionAndCenter;
            map.Name = "map";
            map.NegativeMode = false;
            map.PolygonsEnabled = true;
            map.RetryLoadTile = 0;
            map.RoutesEnabled = true;
            map.ScaleMode = GMap.NET.WindowsForms.ScaleModes.Integer;
            map.SelectedAreaFillColor = Color.FromArgb(33, 65, 105, 225);
            map.ShowTileGridLines = false;
            map.Size = new Size(500, 486);
            map.TabIndex = 1;
            map.Zoom = 0D;
            map.Load += gMapControl1_Load;
            map.MouseClick += map_MouseClick;
            // 
            // lat
            // 
            lat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lat.AutoSize = true;
            lat.Location = new Point(579, 24);
            lat.Name = "lat";
            lat.Size = new Size(60, 20);
            lat.TabIndex = 2;
            lat.Text = "latitude";
            // 
            // txtlat
            // 
            txtlat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtlat.Location = new Point(579, 58);
            txtlat.Name = "txtlat";
            txtlat.Size = new Size(197, 27);
            txtlat.TabIndex = 3;
            // 
            // txtlon
            // 
            txtlon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtlon.Location = new Point(579, 147);
            txtlon.Name = "txtlon";
            txtlon.Size = new Size(197, 27);
            txtlon.TabIndex = 5;
            // 
            // lon
            // 
            lon.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            lon.AutoSize = true;
            lon.Location = new Point(579, 104);
            lon.Name = "lon";
            lon.Size = new Size(73, 20);
            lon.TabIndex = 4;
            lon.Text = "longitude";
            // 
            // LoadintoMap
            // 
            LoadintoMap.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            LoadintoMap.Location = new Point(579, 202);
            LoadintoMap.Name = "LoadintoMap";
            LoadintoMap.Size = new Size(197, 29);
            LoadintoMap.TabIndex = 6;
            LoadintoMap.Text = "Load";
            LoadintoMap.UseVisualStyleBackColor = true;
            LoadintoMap.Click += LoadintoMap_Click;
            // 
            // txtAddress
            // 
            txtAddress.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            txtAddress.Location = new Point(579, 312);
            txtAddress.Name = "txtAddress";
            txtAddress.Size = new Size(197, 161);
            txtAddress.TabIndex = 7;
            txtAddress.Text = "";
            // 
            // chkEnableMouseclick
            // 
            chkEnableMouseclick.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            chkEnableMouseclick.AutoSize = true;
            chkEnableMouseclick.Location = new Point(617, 268);
            chkEnableMouseclick.Name = "chkEnableMouseclick";
            chkEnableMouseclick.Size = new Size(159, 24);
            chkEnableMouseclick.TabIndex = 8;
            chkEnableMouseclick.Text = "Enable Mouse Click";
            chkEnableMouseclick.UseVisualStyleBackColor = true;
            // 
            // btnloadlat
            // 
            btnloadlat.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnloadlat.Location = new Point(591, 492);
            btnloadlat.Name = "btnloadlat";
            btnloadlat.Size = new Size(164, 29);
            btnloadlat.TabIndex = 9;
            btnloadlat.Text = "load lat and lon";
            btnloadlat.UseVisualStyleBackColor = true;
            btnloadlat.Click += btnloadlat_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 534);
            Controls.Add(btnloadlat);
            Controls.Add(chkEnableMouseclick);
            Controls.Add(txtAddress);
            Controls.Add(LoadintoMap);
            Controls.Add(txtlon);
            Controls.Add(lon);
            Controls.Add(txtlat);
            Controls.Add(lat);
            Controls.Add(map);
            Controls.Add(splitter1);
            Name = "Form1";
            Text = "Form1";
            Load += Form1_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Splitter splitter1;
        private GMap.NET.WindowsForms.GMapControl map;
        private Label lat;
        private TextBox txtlat;
        private TextBox txtlon;
        private Label lon;
        private Button LoadintoMap;
        private RichTextBox txtAddress;
        private CheckBox chkEnableMouseclick;
        private Button btnloadlat;
    }
}
