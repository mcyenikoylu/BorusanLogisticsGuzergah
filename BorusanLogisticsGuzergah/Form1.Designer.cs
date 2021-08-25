namespace BorusanLogisticsGuzergah
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.ribbonControl1 = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barAndDockingController1 = new DevExpress.XtraBars.BarAndDockingController(this.components);
            this.barStaticItem1 = new DevExpress.XtraBars.BarStaticItem();
            this.barStaticItem2 = new DevExpress.XtraBars.BarStaticItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar1 = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.xtraTabbedMdiManager1 = new DevExpress.XtraTabbedMdi.XtraTabbedMdiManager(this.components);
            this.galleryDropDown1 = new DevExpress.XtraBars.Ribbon.GalleryDropDown(this.components);
            this.backstageViewControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewControl();
            this.backstageViewClientControl1 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControl2 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.backstageViewClientControl3 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.bvTabWayPoints = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.bvTabRoadSurvey = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator1 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.bvTabSettings = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            this.backstageViewItemSeparator2 = new DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator();
            this.bvBtnAbout = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.bvBtnExit = new DevExpress.XtraBars.Ribbon.BackstageViewButtonItem();
            this.backstageViewClientControl4 = new DevExpress.XtraBars.Ribbon.BackstageViewClientControl();
            this.bvTabReports = new DevExpress.XtraBars.Ribbon.BackstageViewTabItem();
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryDropDown1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).BeginInit();
            this.backstageViewControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbonControl1
            // 
            this.ribbonControl1.ApplicationButtonDropDownControl = this.backstageViewControl1;
            this.ribbonControl1.ApplicationButtonImageOptions.Image = global::BorusanLogisticsGuzergah.Properties.Resources.Logo;
            this.ribbonControl1.Controller = this.barAndDockingController1;
            this.ribbonControl1.ExpandCollapseItem.Id = 0;
            this.ribbonControl1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbonControl1.ExpandCollapseItem,
            this.barStaticItem1,
            this.barStaticItem2});
            resources.ApplyResources(this.ribbonControl1, "ribbonControl1");
            this.ribbonControl1.MaxItemId = 3;
            this.ribbonControl1.MdiMergeStyle = DevExpress.XtraBars.Ribbon.RibbonMdiMergeStyle.OnlyWhenMaximized;
            this.ribbonControl1.Name = "ribbonControl1";
            this.ribbonControl1.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbonControl1.RibbonStyle = DevExpress.XtraBars.Ribbon.RibbonControlStyle.Office2007;
            this.ribbonControl1.ShowCategoryInCaption = false;
            this.ribbonControl1.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.True;
            this.ribbonControl1.ShowPageHeadersMode = DevExpress.XtraBars.Ribbon.ShowPageHeadersMode.Show;
            this.ribbonControl1.ShowToolbarCustomizeItem = false;
            this.ribbonControl1.StatusBar = this.ribbonStatusBar1;
            this.ribbonControl1.Toolbar.ShowCustomizeItem = false;
            this.ribbonControl1.ApplicationButtonClick += new System.EventHandler(this.ribbonControl1_ApplicationButtonClick);
            // 
            // barStaticItem1
            // 
            resources.ApplyResources(this.barStaticItem1, "barStaticItem1");
            this.barStaticItem1.Id = 1;
            this.barStaticItem1.Name = "barStaticItem1";
            // 
            // barStaticItem2
            // 
            this.barStaticItem2.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            resources.ApplyResources(this.barStaticItem2, "barStaticItem2");
            this.barStaticItem2.Id = 2;
            this.barStaticItem2.Name = "barStaticItem2";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
            this.ribbonPage1.Name = "ribbonPage1";
            resources.ApplyResources(this.ribbonPage1, "ribbonPage1");
            // 
            // ribbonPageGroup1
            // 
            this.ribbonPageGroup1.Name = "ribbonPageGroup1";
            resources.ApplyResources(this.ribbonPageGroup1, "ribbonPageGroup1");
            // 
            // ribbonStatusBar1
            // 
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem1);
            this.ribbonStatusBar1.ItemLinks.Add(this.barStaticItem2);
            resources.ApplyResources(this.ribbonStatusBar1, "ribbonStatusBar1");
            this.ribbonStatusBar1.Name = "ribbonStatusBar1";
            this.ribbonStatusBar1.Ribbon = this.ribbonControl1;
            // 
            // xtraTabbedMdiManager1
            // 
            this.xtraTabbedMdiManager1.AllowDragDrop = DevExpress.Utils.DefaultBoolean.False;
            this.xtraTabbedMdiManager1.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InActiveTabPageHeaderAndOnMouseHover;
            this.xtraTabbedMdiManager1.Controller = this.barAndDockingController1;
            this.xtraTabbedMdiManager1.HeaderButtons = ((DevExpress.XtraTab.TabButtons)((((DevExpress.XtraTab.TabButtons.Prev | DevExpress.XtraTab.TabButtons.Next) 
            | DevExpress.XtraTab.TabButtons.Close) 
            | DevExpress.XtraTab.TabButtons.Default)));
            this.xtraTabbedMdiManager1.HeaderButtonsShowMode = DevExpress.XtraTab.TabButtonShowMode.Always;
            this.xtraTabbedMdiManager1.HeaderLocation = DevExpress.XtraTab.TabHeaderLocation.Bottom;
            this.xtraTabbedMdiManager1.MdiParent = this;
            // 
            // galleryDropDown1
            // 
            this.galleryDropDown1.Name = "galleryDropDown1";
            this.galleryDropDown1.Ribbon = this.ribbonControl1;
            // 
            // backstageViewControl1
            // 
            this.backstageViewControl1.Controller = this.barAndDockingController1;
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl1);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl2);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl4);
            this.backstageViewControl1.Controls.Add(this.backstageViewClientControl3);
            this.backstageViewControl1.Items.Add(this.bvTabWayPoints);
            this.backstageViewControl1.Items.Add(this.bvTabRoadSurvey);
            this.backstageViewControl1.Items.Add(this.bvTabReports);
            this.backstageViewControl1.Items.Add(this.backstageViewItemSeparator1);
            this.backstageViewControl1.Items.Add(this.bvTabSettings);
            this.backstageViewControl1.Items.Add(this.backstageViewItemSeparator2);
            this.backstageViewControl1.Items.Add(this.bvBtnAbout);
            this.backstageViewControl1.Items.Add(this.bvBtnExit);
            resources.ApplyResources(this.backstageViewControl1, "backstageViewControl1");
            this.backstageViewControl1.Name = "backstageViewControl1";
            this.backstageViewControl1.OwnerControl = this.ribbonControl1;
            this.backstageViewControl1.Style = DevExpress.XtraBars.Ribbon.BackstageViewStyle.Office2013;
            // 
            // backstageViewClientControl1
            // 
            resources.ApplyResources(this.backstageViewClientControl1, "backstageViewClientControl1");
            this.backstageViewClientControl1.Name = "backstageViewClientControl1";
            // 
            // backstageViewClientControl2
            // 
            resources.ApplyResources(this.backstageViewClientControl2, "backstageViewClientControl2");
            this.backstageViewClientControl2.Name = "backstageViewClientControl2";
            // 
            // backstageViewClientControl3
            // 
            resources.ApplyResources(this.backstageViewClientControl3, "backstageViewClientControl3");
            this.backstageViewClientControl3.Name = "backstageViewClientControl3";
            // 
            // bvTabWayPoints
            // 
            resources.ApplyResources(this.bvTabWayPoints, "bvTabWayPoints");
            this.bvTabWayPoints.ContentControl = this.backstageViewClientControl1;
            this.bvTabWayPoints.ImageOptions.ItemNormal.Image = ((System.Drawing.Image)(resources.GetObject("bvTabWayPoints.ImageOptions.ItemNormal.Image")));
            this.bvTabWayPoints.Name = "bvTabWayPoints";
            // 
            // bvTabRoadSurvey
            // 
            resources.ApplyResources(this.bvTabRoadSurvey, "bvTabRoadSurvey");
            this.bvTabRoadSurvey.ContentControl = this.backstageViewClientControl2;
            this.bvTabRoadSurvey.ImageOptions.ItemNormal.Image = ((System.Drawing.Image)(resources.GetObject("bvTabRoadSurvey.ImageOptions.ItemNormal.Image")));
            this.bvTabRoadSurvey.Name = "bvTabRoadSurvey";
            // 
            // backstageViewItemSeparator1
            // 
            this.backstageViewItemSeparator1.Name = "backstageViewItemSeparator1";
            // 
            // bvTabSettings
            // 
            resources.ApplyResources(this.bvTabSettings, "bvTabSettings");
            this.bvTabSettings.ContentControl = this.backstageViewClientControl3;
            this.bvTabSettings.ImageOptions.ItemNormal.Image = ((System.Drawing.Image)(resources.GetObject("bvTabSettings.ImageOptions.ItemNormal.Image")));
            this.bvTabSettings.Name = "bvTabSettings";
            // 
            // backstageViewItemSeparator2
            // 
            this.backstageViewItemSeparator2.Name = "backstageViewItemSeparator2";
            // 
            // bvBtnAbout
            // 
            resources.ApplyResources(this.bvBtnAbout, "bvBtnAbout");
            this.bvBtnAbout.ImageOptions.ItemNormal.Image = ((System.Drawing.Image)(resources.GetObject("bvBtnAbout.ImageOptions.ItemNormal.Image")));
            this.bvBtnAbout.Name = "bvBtnAbout";
            // 
            // bvBtnExit
            // 
            resources.ApplyResources(this.bvBtnExit, "bvBtnExit");
            this.bvBtnExit.ImageOptions.ItemNormal.Image = ((System.Drawing.Image)(resources.GetObject("bvBtnExit.ImageOptions.ItemNormal.Image")));
            this.bvBtnExit.Name = "bvBtnExit";
            // 
            // backstageViewClientControl4
            // 
            resources.ApplyResources(this.backstageViewClientControl4, "backstageViewClientControl4");
            this.backstageViewClientControl4.Name = "backstageViewClientControl4";
            // 
            // bvTabReports
            // 
            resources.ApplyResources(this.bvTabReports, "bvTabReports");
            this.bvTabReports.ContentControl = this.backstageViewClientControl4;
            this.bvTabReports.ImageOptions.ItemNormal.Image = ((System.Drawing.Image)(resources.GetObject("bvTabReports.ImageOptions.ItemNormal.Image")));
            this.bvTabReports.Name = "bvTabReports";
            // 
            // Form1
            // 
            this.AllowFormGlass = DevExpress.Utils.DefaultBoolean.False;
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.backstageViewControl1);
            this.Controls.Add(this.ribbonStatusBar1);
            this.Controls.Add(this.ribbonControl1);
            this.IsMdiContainer = true;
            this.Name = "Form1";
            this.Ribbon = this.ribbonControl1;
            this.StatusBar = this.ribbonStatusBar1;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbonControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barAndDockingController1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabbedMdiManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryDropDown1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backstageViewControl1)).EndInit();
            this.backstageViewControl1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbonControl1;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar1;
        private DevExpress.XtraBars.BarAndDockingController barAndDockingController1;
        private DevExpress.XtraTabbedMdi.XtraTabbedMdiManager xtraTabbedMdiManager1;
        private DevExpress.XtraBars.Ribbon.GalleryDropDown galleryDropDown1;
        private DevExpress.XtraBars.Ribbon.BackstageViewControl backstageViewControl1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem1;
        private DevExpress.XtraBars.BarStaticItem barStaticItem2;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl1;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl2;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl3;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem bvTabWayPoints;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem bvTabRoadSurvey;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator1;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem bvTabSettings;
        private DevExpress.XtraBars.Ribbon.BackstageViewItemSeparator backstageViewItemSeparator2;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem bvBtnAbout;
        private DevExpress.XtraBars.Ribbon.BackstageViewButtonItem bvBtnExit;
        private DevExpress.XtraBars.Ribbon.BackstageViewClientControl backstageViewClientControl4;
        private DevExpress.XtraBars.Ribbon.BackstageViewTabItem bvTabReports;
    }
}

