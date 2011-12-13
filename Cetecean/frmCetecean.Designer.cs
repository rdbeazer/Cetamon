namespace Cetecean
{
    partial class frmCetecean
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmCetecean));
            this.panel1 = new System.Windows.Forms.Panel();
            this.spatialToolStrip1 = new DotSpatial.Controls.SpatialToolStrip();
            this.map1 = new DotSpatial.Controls.Map();
            this.legend1 = new DotSpatial.Controls.Legend();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fIleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenProject = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.openShapefileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.importFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExcelToLine = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsmExit = new System.Windows.Forms.ToolStripMenuItem();
            this.operationsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomInToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomOutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomExtenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.infoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitTracksByGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertGridToPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.splitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spatialJoinToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pointsToPolygonsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.polygonsToPointsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.extractRasterValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.calculateAreaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.calculateSurveyEffortByGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surveyTracksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.surveySwathesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.calculatorFieldToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.tsmAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.tslMapProjectionLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslProjection = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslSave = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslOpen = new System.Windows.Forms.ToolStripStatusLabel();
            this.tsslProjName = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslXCoord = new System.Windows.Forms.ToolStripStatusLabel();
            this.tslYCoord = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.appManager1 = new DotSpatial.Controls.AppManager();
            this.panel1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.spatialToolStrip1);
            this.panel1.Controls.Add(this.menuStrip1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(847, 49);
            this.panel1.TabIndex = 0;
            // 
            // spatialToolStrip1
            // 
            this.spatialToolStrip1.ApplicationManager = null;
            this.spatialToolStrip1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.spatialToolStrip1.Location = new System.Drawing.Point(0, 24);
            this.spatialToolStrip1.Map = this.map1;
            this.spatialToolStrip1.Name = "spatialToolStrip1";
            this.spatialToolStrip1.Size = new System.Drawing.Size(847, 25);
            this.spatialToolStrip1.TabIndex = 1;
            this.spatialToolStrip1.Text = "spatialToolStrip1";
            // 
            // map1
            // 
            this.map1.AllowDrop = true;
            this.map1.BackColor = System.Drawing.Color.White;
            this.map1.CollectAfterDraw = false;
            this.map1.CollisionDetection = false;
            this.map1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.map1.ExtendBuffer = false;
            this.map1.FunctionMode = DotSpatial.Controls.FunctionMode.None;
            this.map1.IsBusy = false;
            this.map1.Legend = this.legend1;
            this.map1.Location = new System.Drawing.Point(0, 0);
            this.map1.Name = "map1";
            this.map1.ProgressHandler = null;
            this.map1.ProjectionModeDefine = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.ProjectionModeReproject = DotSpatial.Controls.ActionMode.Prompt;
            this.map1.RedrawLayersWhileResizing = false;
            this.map1.SelectionEnabled = true;
            this.map1.Size = new System.Drawing.Size(670, 502);
            this.map1.TabIndex = 0;
            // 
            // legend1
            // 
            this.legend1.BackColor = System.Drawing.Color.White;
            this.legend1.ControlRectangle = new System.Drawing.Rectangle(0, 0, 173, 502);
            this.legend1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.legend1.DocumentRectangle = new System.Drawing.Rectangle(0, 0, 103, 178);
            this.legend1.HorizontalScrollEnabled = true;
            this.legend1.Indentation = 30;
            this.legend1.IsInitialized = false;
            this.legend1.Location = new System.Drawing.Point(0, 0);
            this.legend1.MinimumSize = new System.Drawing.Size(5, 5);
            this.legend1.Name = "legend1";
            this.legend1.ProgressHandler = null;
            this.legend1.ResetOnResize = false;
            this.legend1.SelectionFontColor = System.Drawing.Color.Black;
            this.legend1.SelectionHighlight = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(238)))), ((int)(((byte)(252)))));
            this.legend1.Size = new System.Drawing.Size(173, 502);
            this.legend1.TabIndex = 0;
            this.legend1.Text = "legend1";
            this.legend1.VerticalScrollEnabled = true;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fIleToolStripMenuItem,
            this.operationsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.tsmHelp});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(847, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fIleToolStripMenuItem
            // 
            this.fIleToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenProject,
            this.mnuSave,
            this.mnuSaveAs,
            this.toolStripSeparator6,
            this.openShapefileToolStripMenuItem,
            this.toolStripMenuItem4,
            this.toolStripSeparator2,
            this.importFileToolStripMenuItem,
            this.ExcelToLine,
            this.toolStripSeparator1,
            this.printToolStripMenuItem,
            this.toolStripSeparator5,
            this.tsmExit});
            this.fIleToolStripMenuItem.Name = "fIleToolStripMenuItem";
            this.fIleToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fIleToolStripMenuItem.Text = "File";
            // 
            // mnuOpenProject
            // 
            this.mnuOpenProject.Name = "mnuOpenProject";
            this.mnuOpenProject.Size = new System.Drawing.Size(260, 22);
            this.mnuOpenProject.Text = "Open Project";
            this.mnuOpenProject.Click += new System.EventHandler(this.mnuOpenProject_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(260, 22);
            this.mnuSave.Text = "Save Project";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // mnuSaveAs
            // 
            this.mnuSaveAs.Name = "mnuSaveAs";
            this.mnuSaveAs.Size = new System.Drawing.Size(260, 22);
            this.mnuSaveAs.Text = "Save Project As";
            this.mnuSaveAs.Click += new System.EventHandler(this.mnuSaveAs_Click);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(257, 6);
            // 
            // openShapefileToolStripMenuItem
            // 
            this.openShapefileToolStripMenuItem.Name = "openShapefileToolStripMenuItem";
            this.openShapefileToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.openShapefileToolStripMenuItem.Text = "Open Shapefile";
            this.openShapefileToolStripMenuItem.Click += new System.EventHandler(this.openShapefileToolStripMenuItem_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(260, 22);
            this.toolStripMenuItem4.Text = "Reproject Shapefile";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(257, 6);
            // 
            // importFileToolStripMenuItem
            // 
            this.importFileToolStripMenuItem.Name = "importFileToolStripMenuItem";
            this.importFileToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.importFileToolStripMenuItem.Text = "Convert Excel file to Point Shapefile";
            this.importFileToolStripMenuItem.Click += new System.EventHandler(this.importFileToolStripMenuItem_Click);
            // 
            // ExcelToLine
            // 
            this.ExcelToLine.Name = "ExcelToLine";
            this.ExcelToLine.Size = new System.Drawing.Size(260, 22);
            this.ExcelToLine.Text = "Convert Excel file to Line Shapefile";
            this.ExcelToLine.Click += new System.EventHandler(this.ExcelToLine_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(257, 6);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(260, 22);
            this.printToolStripMenuItem.Text = "Print";
            this.printToolStripMenuItem.Click += new System.EventHandler(this.printToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(257, 6);
            // 
            // tsmExit
            // 
            this.tsmExit.Name = "tsmExit";
            this.tsmExit.Size = new System.Drawing.Size(260, 22);
            this.tsmExit.Text = "Exit";
            this.tsmExit.Click += new System.EventHandler(this.tsmExit_Click);
            // 
            // operationsToolStripMenuItem
            // 
            this.operationsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.zoomInToolStripMenuItem,
            this.zoomOutToolStripMenuItem,
            this.zoomExtenToolStripMenuItem,
            this.panToolStripMenuItem,
            this.infoToolStripMenuItem});
            this.operationsToolStripMenuItem.Name = "operationsToolStripMenuItem";
            this.operationsToolStripMenuItem.Size = new System.Drawing.Size(77, 20);
            this.operationsToolStripMenuItem.Text = "Operations";
            // 
            // zoomInToolStripMenuItem
            // 
            this.zoomInToolStripMenuItem.Name = "zoomInToolStripMenuItem";
            this.zoomInToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.zoomInToolStripMenuItem.Text = "Zoom In";
            this.zoomInToolStripMenuItem.Click += new System.EventHandler(this.zoomInToolStripMenuItem_Click);
            // 
            // zoomOutToolStripMenuItem
            // 
            this.zoomOutToolStripMenuItem.Name = "zoomOutToolStripMenuItem";
            this.zoomOutToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.zoomOutToolStripMenuItem.Text = "Zoom Out";
            this.zoomOutToolStripMenuItem.Click += new System.EventHandler(this.zoomOutToolStripMenuItem_Click);
            // 
            // zoomExtenToolStripMenuItem
            // 
            this.zoomExtenToolStripMenuItem.Name = "zoomExtenToolStripMenuItem";
            this.zoomExtenToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.zoomExtenToolStripMenuItem.Text = "Zoom Extents";
            // 
            // panToolStripMenuItem
            // 
            this.panToolStripMenuItem.Name = "panToolStripMenuItem";
            this.panToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.panToolStripMenuItem.Text = "Pan";
            this.panToolStripMenuItem.Click += new System.EventHandler(this.panToolStripMenuItem_Click);
            // 
            // infoToolStripMenuItem
            // 
            this.infoToolStripMenuItem.Name = "infoToolStripMenuItem";
            this.infoToolStripMenuItem.Size = new System.Drawing.Size(146, 22);
            this.infoToolStripMenuItem.Text = "Info";
            this.infoToolStripMenuItem.Click += new System.EventHandler(this.infoToolStripMenuItem_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createGridToolStripMenuItem,
            this.splitTracksByGridToolStripMenuItem,
            this.convertGridToPointsToolStripMenuItem,
            this.toolStripSeparator3,
            this.splitToolStripMenuItem,
            this.spatialJoinToolStripMenuItem,
            this.toolStripSeparator7,
            this.toolStripMenuItem1,
            this.extractRasterValuesToolStripMenuItem,
            this.toolStripMenuItem2,
            this.toolStripSeparator4,
            this.calculateAreaToolStripMenuItem,
            this.toolStripMenuItem3,
            this.calculateSurveyEffortByGridToolStripMenuItem,
            this.calculatorFieldToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // createGridToolStripMenuItem
            // 
            this.createGridToolStripMenuItem.Name = "createGridToolStripMenuItem";
            this.createGridToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.createGridToolStripMenuItem.Text = "Create Grid";
            this.createGridToolStripMenuItem.Click += new System.EventHandler(this.createGridToolStripMenuItem_Click);
            // 
            // splitTracksByGridToolStripMenuItem
            // 
            this.splitTracksByGridToolStripMenuItem.Name = "splitTracksByGridToolStripMenuItem";
            this.splitTracksByGridToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.splitTracksByGridToolStripMenuItem.Text = "Split Tracks by Grid";
            this.splitTracksByGridToolStripMenuItem.Click += new System.EventHandler(this.splitTracksByGridToolStripMenuItem_Click);
            // 
            // convertGridToPointsToolStripMenuItem
            // 
            this.convertGridToPointsToolStripMenuItem.Name = "convertGridToPointsToolStripMenuItem";
            this.convertGridToPointsToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.convertGridToPointsToolStripMenuItem.Text = "Convert Grid to Points";
            this.convertGridToPointsToolStripMenuItem.Click += new System.EventHandler(this.convertGridToPointsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(231, 6);
            // 
            // splitToolStripMenuItem
            // 
            this.splitToolStripMenuItem.Name = "splitToolStripMenuItem";
            this.splitToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.splitToolStripMenuItem.Text = "Split Swathe by polygon";
            this.splitToolStripMenuItem.Click += new System.EventHandler(this.splitToolStripMenuItem_Click);
            // 
            // spatialJoinToolStripMenuItem
            // 
            this.spatialJoinToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.pointsToPolygonsToolStripMenuItem,
            this.polygonsToPointsToolStripMenuItem});
            this.spatialJoinToolStripMenuItem.Name = "spatialJoinToolStripMenuItem";
            this.spatialJoinToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.spatialJoinToolStripMenuItem.Text = "Spatial Join";
            // 
            // pointsToPolygonsToolStripMenuItem
            // 
            this.pointsToPolygonsToolStripMenuItem.Name = "pointsToPolygonsToolStripMenuItem";
            this.pointsToPolygonsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.pointsToPolygonsToolStripMenuItem.Text = "Points to Polygons";
            this.pointsToPolygonsToolStripMenuItem.Click += new System.EventHandler(this.pointsToPolygonsToolStripMenuItem_Click);
            // 
            // polygonsToPointsToolStripMenuItem
            // 
            this.polygonsToPointsToolStripMenuItem.Name = "polygonsToPointsToolStripMenuItem";
            this.polygonsToPointsToolStripMenuItem.Size = new System.Drawing.Size(173, 22);
            this.polygonsToPointsToolStripMenuItem.Text = "Polygons to Points";
            this.polygonsToPointsToolStripMenuItem.Click += new System.EventHandler(this.polygonsToPointsToolStripMenuItem_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(231, 6);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(234, 22);
            this.toolStripMenuItem1.Text = "Buffer";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // extractRasterValuesToolStripMenuItem
            // 
            this.extractRasterValuesToolStripMenuItem.Name = "extractRasterValuesToolStripMenuItem";
            this.extractRasterValuesToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.extractRasterValuesToolStripMenuItem.Text = "Extract Raster Values";
            this.extractRasterValuesToolStripMenuItem.Click += new System.EventHandler(this.extractRasterValuesToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(234, 22);
            this.toolStripMenuItem2.Text = "Count Sightings per Polygon";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(231, 6);
            // 
            // calculateAreaToolStripMenuItem
            // 
            this.calculateAreaToolStripMenuItem.Name = "calculateAreaToolStripMenuItem";
            this.calculateAreaToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.calculateAreaToolStripMenuItem.Text = "Calculate area";
            this.calculateAreaToolStripMenuItem.Click += new System.EventHandler(this.calculateAreaToolStripMenuItem_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(234, 22);
            this.toolStripMenuItem3.Text = "Calculate Line Length";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // calculateSurveyEffortByGridToolStripMenuItem
            // 
            this.calculateSurveyEffortByGridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.surveyTracksToolStripMenuItem,
            this.surveySwathesToolStripMenuItem});
            this.calculateSurveyEffortByGridToolStripMenuItem.Name = "calculateSurveyEffortByGridToolStripMenuItem";
            this.calculateSurveyEffortByGridToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.calculateSurveyEffortByGridToolStripMenuItem.Text = "Calculate Survey Effort by Grid";
            // 
            // surveyTracksToolStripMenuItem
            // 
            this.surveyTracksToolStripMenuItem.Name = "surveyTracksToolStripMenuItem";
            this.surveyTracksToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.surveyTracksToolStripMenuItem.Text = "Survey Tracks";
            this.surveyTracksToolStripMenuItem.Click += new System.EventHandler(this.surveyTracksToolStripMenuItem_Click);
            // 
            // surveySwathesToolStripMenuItem
            // 
            this.surveySwathesToolStripMenuItem.Name = "surveySwathesToolStripMenuItem";
            this.surveySwathesToolStripMenuItem.Size = new System.Drawing.Size(155, 22);
            this.surveySwathesToolStripMenuItem.Text = "Survey Swathes";
            this.surveySwathesToolStripMenuItem.Click += new System.EventHandler(this.surveySwathesToolStripMenuItem_Click);
            // 
            // calculatorFieldToolStripMenuItem
            // 
            this.calculatorFieldToolStripMenuItem.Name = "calculatorFieldToolStripMenuItem";
            this.calculatorFieldToolStripMenuItem.Size = new System.Drawing.Size(234, 22);
            this.calculatorFieldToolStripMenuItem.Text = "Calculator Field";
            this.calculatorFieldToolStripMenuItem.Click += new System.EventHandler(this.calculatorFieldToolStripMenuItem_Click);
            // 
            // tsmHelp
            // 
            this.tsmHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsmAbout});
            this.tsmHelp.Name = "tsmHelp";
            this.tsmHelp.Size = new System.Drawing.Size(44, 20);
            this.tsmHelp.Text = "&Help";
            // 
            // tsmAbout
            // 
            this.tsmAbout.Name = "tsmAbout";
            this.tsmAbout.Size = new System.Drawing.Size(107, 22);
            this.tsmAbout.Text = "&About";
            this.tsmAbout.Click += new System.EventHandler(this.tsmAbout_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tslMapProjectionLabel2,
            this.tslProjection,
            this.toolStripStatusLabel1,
            this.tsslSave,
            this.tsslOpen,
            this.tsslProjName,
            this.tslXCoord,
            this.tslYCoord});
            this.statusStrip1.Location = new System.Drawing.Point(0, 551);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(847, 24);
            this.statusStrip1.TabIndex = 3;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // tslMapProjectionLabel2
            // 
            this.tslMapProjectionLabel2.Name = "tslMapProjectionLabel2";
            this.tslMapProjectionLabel2.Size = new System.Drawing.Size(91, 19);
            this.tslMapProjectionLabel2.Text = "Map Projection:";
            // 
            // tslProjection
            // 
            this.tslProjection.Name = "tslProjection";
            this.tslProjection.Size = new System.Drawing.Size(0, 19);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(699, 19);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // tsslSave
            // 
            this.tsslSave.Image = ((System.Drawing.Image)(resources.GetObject("tsslSave.Image")));
            this.tsslSave.Name = "tsslSave";
            this.tsslSave.Size = new System.Drawing.Size(16, 19);
            this.tsslSave.Visible = false;
            // 
            // tsslOpen
            // 
            this.tsslOpen.Image = ((System.Drawing.Image)(resources.GetObject("tsslOpen.Image")));
            this.tsslOpen.Name = "tsslOpen";
            this.tsslOpen.Size = new System.Drawing.Size(16, 19);
            this.tsslOpen.Visible = false;
            // 
            // tsslProjName
            // 
            this.tsslProjName.Name = "tsslProjName";
            this.tsslProjName.Size = new System.Drawing.Size(0, 19);
            // 
            // tslXCoord
            // 
            this.tslXCoord.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tslXCoord.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tslXCoord.Name = "tslXCoord";
            this.tslXCoord.Size = new System.Drawing.Size(21, 19);
            this.tslXCoord.Text = "--";
            // 
            // tslYCoord
            // 
            this.tslYCoord.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right)));
            this.tslYCoord.BorderStyle = System.Windows.Forms.Border3DStyle.SunkenOuter;
            this.tslYCoord.Name = "tslYCoord";
            this.tslYCoord.Size = new System.Drawing.Size(21, 19);
            this.tslYCoord.Text = "--";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 49);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.legend1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.map1);
            this.splitContainer1.Size = new System.Drawing.Size(847, 502);
            this.splitContainer1.SplitterDistance = 173;
            this.splitContainer1.TabIndex = 4;
            // 
            // appManager1
            // 
            this.appManager1.DataManager.LoadInRam = true;
            this.appManager1.DataManager.ProgressHandler = null;
            this.appManager1.Directories = ((System.Collections.Generic.List<string>)(resources.GetObject("appManager1.Directories")));
            this.appManager1.DockManager = null;
            this.appManager1.HeaderControl = null;
            this.appManager1.Legend = null;
            this.appManager1.Map = null;
            this.appManager1.ProgressHandler = null;
            this.appManager1.ShowExtensionsDialog = DotSpatial.Controls.ShowExtensionsDialog.Default;
            this.appManager1.ToolManager = null;
            // 
            // frmCetecean
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(847, 575);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.panel1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "frmCetecean";
            this.Load += new System.EventHandler(this.frmCetecean_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fIleToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFileToolStripMenuItem;
        private DotSpatial.Controls.Legend legend1;
        private System.Windows.Forms.ToolStripMenuItem operationsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomInToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomOutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomExtenToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openShapefileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem panToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem infoToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem ExcelToLine;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem splitTracksByGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateSurveyEffortByGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private DotSpatial.Controls.SpatialToolStrip spatialToolStrip1;
        private System.Windows.Forms.ToolStripMenuItem surveyTracksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem surveySwathesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem splitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculateAreaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spatialJoinToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pointsToPolygonsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem polygonsToPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem extractRasterValuesToolStripMenuItem;
        //private DotSpatial.Controls.AppManager appManager1;
        private System.Windows.Forms.ToolStripMenuItem convertGridToPointsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem calculatorFieldToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem tsmHelp;
        private System.Windows.Forms.ToolStripMenuItem tsmAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem tsmExit;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private DotSpatial.Controls.Map map1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel tslXCoord;
        private System.Windows.Forms.ToolStripStatusLabel tslYCoord;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripStatusLabel tslMapProjectionLabel2;
        private System.Windows.Forms.ToolStripStatusLabel tslProjection;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenProject;
        private System.Windows.Forms.ToolStripStatusLabel tsslProjName;
        private System.Windows.Forms.ToolStripStatusLabel tsslOpen;
        private System.Windows.Forms.ToolStripStatusLabel tsslSave;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private DotSpatial.Controls.AppManager appManager1;

    }
}

