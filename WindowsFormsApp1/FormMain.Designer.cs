namespace SerialColors
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.lblRed = new System.Windows.Forms.Label();
            this.lblGreen = new System.Windows.Forms.Label();
            this.lblBlue = new System.Windows.Forms.Label();
            this.btnClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tbRed = new System.Windows.Forms.TrackBar();
            this.tbGreen = new System.Windows.Forms.TrackBar();
            this.tbBlue = new System.Windows.Forms.TrackBar();
            this.comboPorts = new System.Windows.Forms.ComboBox();
            this.lblCPU = new System.Windows.Forms.Label();
            this.timerCpu = new System.Windows.Forms.Timer(this.components);
            this.pbColorBox = new System.Windows.Forms.PictureBox();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mainToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.manualToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyCurrentColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openClientFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.hideOnStartupToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuTray = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.trayMenuItemShow = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuItemHide = new System.Windows.Forms.ToolStripMenuItem();
            this.trayMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.tbRed)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorBox)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.contextMenuTray.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblRed
            // 
            this.lblRed.AutoSize = true;
            this.lblRed.Location = new System.Drawing.Point(12, 202);
            this.lblRed.Name = "lblRed";
            this.lblRed.Size = new System.Drawing.Size(27, 13);
            this.lblRed.TabIndex = 3;
            this.lblRed.Text = "Red";
            // 
            // lblGreen
            // 
            this.lblGreen.AutoSize = true;
            this.lblGreen.Location = new System.Drawing.Point(100, 198);
            this.lblGreen.Name = "lblGreen";
            this.lblGreen.Size = new System.Drawing.Size(36, 13);
            this.lblGreen.TabIndex = 4;
            this.lblGreen.Text = "Green";
            // 
            // lblBlue
            // 
            this.lblBlue.AutoSize = true;
            this.lblBlue.Location = new System.Drawing.Point(197, 202);
            this.lblBlue.Name = "lblBlue";
            this.lblBlue.Size = new System.Drawing.Size(28, 13);
            this.lblBlue.TabIndex = 5;
            this.lblBlue.Text = "Blue";
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(170, 251);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Exit";
            this.toolTip1.SetToolTip(this.btnClose, "Exit this application");
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.BtnClose_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.Timer1_Tick);
            // 
            // tbRed
            // 
            this.tbRed.Location = new System.Drawing.Point(15, 26);
            this.tbRed.Maximum = 255;
            this.tbRed.Name = "tbRed";
            this.tbRed.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbRed.Size = new System.Drawing.Size(45, 173);
            this.tbRed.SmallChange = 25;
            this.tbRed.TabIndex = 0;
            this.tbRed.Scroll += new System.EventHandler(this.TbRed_Scroll);
            this.tbRed.SizeChanged += new System.EventHandler(this.TbRed_SizeChanged);
            // 
            // tbGreen
            // 
            this.tbGreen.Location = new System.Drawing.Point(107, 26);
            this.tbGreen.Maximum = 255;
            this.tbGreen.Name = "tbGreen";
            this.tbGreen.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbGreen.Size = new System.Drawing.Size(45, 173);
            this.tbGreen.SmallChange = 25;
            this.tbGreen.TabIndex = 1;
            this.tbGreen.Scroll += new System.EventHandler(this.TbGreen_Scroll);
            // 
            // tbBlue
            // 
            this.tbBlue.Location = new System.Drawing.Point(202, 26);
            this.tbBlue.Maximum = 255;
            this.tbBlue.Name = "tbBlue";
            this.tbBlue.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.tbBlue.Size = new System.Drawing.Size(45, 173);
            this.tbBlue.SmallChange = 25;
            this.tbBlue.TabIndex = 2;
            this.tbBlue.Scroll += new System.EventHandler(this.TbBlue_Scroll);
            // 
            // comboPorts
            // 
            this.comboPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboPorts.Enabled = false;
            this.comboPorts.FormattingEnabled = true;
            this.comboPorts.Location = new System.Drawing.Point(9, 251);
            this.comboPorts.Name = "comboPorts";
            this.comboPorts.Size = new System.Drawing.Size(93, 21);
            this.comboPorts.TabIndex = 7;
            this.toolTip1.SetToolTip(this.comboPorts, "Select which com port the device is connected to");
            this.comboPorts.SelectedIndexChanged += new System.EventHandler(this.ComboPorts_SelectedIndexChanged);
            // 
            // lblCPU
            // 
            this.lblCPU.AutoSize = true;
            this.lblCPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCPU.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.lblCPU.Location = new System.Drawing.Point(53, 87);
            this.lblCPU.Name = "lblCPU";
            this.lblCPU.Size = new System.Drawing.Size(175, 73);
            this.lblCPU.TabIndex = 9;
            this.lblCPU.Text = "XX%";
            this.lblCPU.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // timerCpu
            // 
            this.timerCpu.Enabled = true;
            this.timerCpu.Interval = 200;
            this.timerCpu.Tick += new System.EventHandler(this.timerCpu_Tick);
            // 
            // pbColorBox
            // 
            this.pbColorBox.Location = new System.Drawing.Point(233, 0);
            this.pbColorBox.Name = "pbColorBox";
            this.pbColorBox.Size = new System.Drawing.Size(27, 26);
            this.pbColorBox.TabIndex = 10;
            this.pbColorBox.TabStop = false;
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mainToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(260, 24);
            this.menuStrip1.TabIndex = 13;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mainToolStripMenuItem
            // 
            this.mainToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.manualToolStripMenuItem,
            this.copyCurrentColorToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.openClientFolderToolStripMenuItem,
            this.hideOnStartupToolStripMenuItem,
            this.aboutToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.mainToolStripMenuItem.Name = "mainToolStripMenuItem";
            this.mainToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.mainToolStripMenuItem.Text = "&Menu";
            this.mainToolStripMenuItem.Click += new System.EventHandler(this.mainToolStripMenuItem_Click);
            // 
            // manualToolStripMenuItem
            // 
            this.manualToolStripMenuItem.Name = "manualToolStripMenuItem";
            this.manualToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.manualToolStripMenuItem.Text = "Select color manually";
            this.manualToolStripMenuItem.ToolTipText = "Stop setting color by CPU usage";
            this.manualToolStripMenuItem.CheckedChanged += new System.EventHandler(this.manualToolStripMenuItem_CheckedChanged);
            this.manualToolStripMenuItem.Click += new System.EventHandler(this.manualToolStripMenuItem_Click);
            // 
            // copyCurrentColorToolStripMenuItem
            // 
            this.copyCurrentColorToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.copyToolStripMenuItem,
            this.pasteToolStripMenuItem});
            this.copyCurrentColorToolStripMenuItem.Name = "copyCurrentColorToolStripMenuItem";
            this.copyCurrentColorToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.copyCurrentColorToolStripMenuItem.Text = "Color";
            this.copyCurrentColorToolStripMenuItem.Paint += new System.Windows.Forms.PaintEventHandler(this.copyCurrentColorToolStripMenuItem_Paint);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.ToolTipText = "Copy current color to the Clipboard";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(102, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.ToolTipText = "Paste from Clipboard";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.settingsToolStripMenuItem.Text = "&Steps";
            this.settingsToolStripMenuItem.ToolTipText = "Set the color steps.  Which color for how much processing usage";
            this.settingsToolStripMenuItem.Click += new System.EventHandler(this.settingsToolStripMenuItem_Click);
            // 
            // openClientFolderToolStripMenuItem
            // 
            this.openClientFolderToolStripMenuItem.AutoToolTip = true;
            this.openClientFolderToolStripMenuItem.Name = "openClientFolderToolStripMenuItem";
            this.openClientFolderToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.openClientFolderToolStripMenuItem.Text = "&Open Arduino Folder";
            this.openClientFolderToolStripMenuItem.ToolTipText = "Contains the code used to program the microcontroller";
            this.openClientFolderToolStripMenuItem.Click += new System.EventHandler(this.openClientFolderToolStripMenuItem_Click);
            // 
            // hideOnStartupToolStripMenuItem
            // 
            this.hideOnStartupToolStripMenuItem.Checked = true;
            this.hideOnStartupToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.hideOnStartupToolStripMenuItem.Name = "hideOnStartupToolStripMenuItem";
            this.hideOnStartupToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.hideOnStartupToolStripMenuItem.Text = "&Hide window on startup";
            this.hideOnStartupToolStripMenuItem.ToolTipText = "By checking this, the application window will be hidden on startup.\r\n\r\nYou can cl" +
    "ick the icon in the notification tray \r\nnext to the clock on the taskbar.";
            this.hideOnStartupToolStripMenuItem.Click += new System.EventHandler(this.hideOnStartupToolStripMenuItem_Click);
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.aboutToolStripMenuItem.Text = "&About";
            this.aboutToolStripMenuItem.ToolTipText = "Open ";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuTray;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "SerialColors";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuTray
            // 
            this.contextMenuTray.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuTray.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.trayMenuItemShow,
            this.trayMenuItemHide,
            this.trayMenuItemExit});
            this.contextMenuTray.Name = "contextMenuTray";
            this.contextMenuTray.Size = new System.Drawing.Size(181, 92);
            this.contextMenuTray.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuTray_ItemClicked);
            // 
            // trayMenuItemShow
            // 
            this.trayMenuItemShow.Name = "trayMenuItemShow";
            this.trayMenuItemShow.Size = new System.Drawing.Size(180, 22);
            this.trayMenuItemShow.Text = "Show window";
            this.trayMenuItemShow.ToolTipText = "Show the application window";
            this.trayMenuItemShow.Visible = false;
            // 
            // trayMenuItemHide
            // 
            this.trayMenuItemHide.Name = "trayMenuItemHide";
            this.trayMenuItemHide.Size = new System.Drawing.Size(180, 22);
            this.trayMenuItemHide.Text = "Hide window";
            this.trayMenuItemHide.ToolTipText = "Hide the application window";
            this.trayMenuItemHide.Visible = false;
            // 
            // trayMenuItemExit
            // 
            this.trayMenuItemExit.Name = "trayMenuItemExit";
            this.trayMenuItemExit.Size = new System.Drawing.Size(180, 22);
            this.trayMenuItemExit.Text = "Exit the application";
            this.trayMenuItemExit.ToolTipText = "Exit the application";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(260, 289);
            this.Controls.Add(this.pbColorBox);
            this.Controls.Add(this.lblCPU);
            this.Controls.Add(this.comboPorts);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.lblBlue);
            this.Controls.Add(this.lblGreen);
            this.Controls.Add(this.lblRed);
            this.Controls.Add(this.tbBlue);
            this.Controls.Add(this.tbGreen);
            this.Controls.Add(this.tbRed);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.Text = "CPU usage";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.tbRed)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGreen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbBlue)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbColorBox)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuTray.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblRed;
        private System.Windows.Forms.Label lblGreen;
        private System.Windows.Forms.Label lblBlue;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TrackBar tbRed;
        private System.Windows.Forms.TrackBar tbGreen;
        private System.Windows.Forms.TrackBar tbBlue;
        private System.Windows.Forms.ComboBox comboPorts;
        private System.Windows.Forms.Label lblCPU;
        private System.Windows.Forms.Timer timerCpu;
        private System.Windows.Forms.PictureBox pbColorBox;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mainToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyCurrentColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem manualToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openClientFolderToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuTray;
        private System.Windows.Forms.ToolStripMenuItem trayMenuItemShow;
        private System.Windows.Forms.ToolStripMenuItem trayMenuItemHide;
        private System.Windows.Forms.ToolStripMenuItem trayMenuItemExit;
        private System.Windows.Forms.ToolStripMenuItem hideOnStartupToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}

