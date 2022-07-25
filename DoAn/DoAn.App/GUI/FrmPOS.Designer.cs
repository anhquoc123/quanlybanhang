namespace DoAn.App.GUI
{
    partial class FrmPOS
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmPOS));
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            this.xttabMain = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPanel = new DevExpress.XtraTab.XtraTabPage();
            ((System.ComponentModel.ISupportInitialize)(this.xttabMain)).BeginInit();
            this.xttabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // xttabMain
            // 
            this.xttabMain.ClosePageButtonShowMode = DevExpress.XtraTab.ClosePageButtonShowMode.InAllTabPageHeaders;
            editorButtonImageOptions1.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("editorButtonImageOptions1.SvgImage")));
            this.xttabMain.CustomHeaderButtons.AddRange(new DevExpress.XtraTab.Buttons.CustomHeaderButton[] {
            new DevExpress.XtraTab.Buttons.CustomHeaderButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "Thêm hóa đơn", -1, true, true, editorButtonImageOptions1, serializableAppearanceObject1, "", null, null)});
            this.xttabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xttabMain.Location = new System.Drawing.Point(0, 0);
            this.xttabMain.Name = "xttabMain";
            this.xttabMain.SelectedTabPage = this.xtraTabPanel;
            this.xttabMain.Size = new System.Drawing.Size(1129, 449);
            this.xttabMain.TabIndex = 0;
            this.xttabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPanel});
            this.xttabMain.CloseButtonClick += new System.EventHandler(this.xttabMain_CloseButtonClick);
            this.xttabMain.CustomHeaderButtonClick += new DevExpress.XtraTab.ViewInfo.CustomHeaderButtonEventHandler(this.xttabMain_CustomHeaderButtonClick);
            // 
            // xtraTabPanel
            // 
            this.xtraTabPanel.AutoScroll = true;
            this.xtraTabPanel.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("xtraTabPanel.ImageOptions.SvgImage")));
            this.xtraTabPanel.Name = "xtraTabPanel";
            this.xtraTabPanel.ShowCloseButton = DevExpress.Utils.DefaultBoolean.True;
            this.xtraTabPanel.Size = new System.Drawing.Size(1123, 402);
            this.xtraTabPanel.Text = "Đơn hàng";
            // 
            // FrmPOS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1129, 449);
            this.Controls.Add(this.xttabMain);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmPOS";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "POS";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmPOS_FormClosed);
            this.Load += new System.EventHandler(this.FrmPOS_Load);
            ((System.ComponentModel.ISupportInitialize)(this.xttabMain)).EndInit();
            this.xttabMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xttabMain;
        private DevExpress.XtraTab.XtraTabPage xtraTabPanel;
    }
}