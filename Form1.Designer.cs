using System.Windows.Forms;

namespace HA6400AdminUnlocker
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.headerPanel = new System.Windows.Forms.Panel();
            this.progressRing = new System.Windows.Forms.ProgressBar();
            this.btnUnlock = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnGithub = new System.Windows.Forms.Button();
            this.titleLabel = new System.Windows.Forms.Label();
            this.chkAutoUnlock = new System.Windows.Forms.CheckBox();
            this.infoMessageText = new System.Windows.Forms.Label();
            this.infoMessageBar = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.headerPanel.SuspendLayout();
            this.infoMessageBar.SuspendLayout();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView.Location = new System.Drawing.Point(0, 186);
            this.webView.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(2133, 1006);
            this.webView.TabIndex = 0;
            this.webView.ZoomFactor = 1D;
            // 
            // headerPanel
            // 
            this.headerPanel.Controls.Add(this.progressRing);
            this.headerPanel.Controls.Add(this.btnUnlock);
            this.headerPanel.Controls.Add(this.btnRefresh);
            this.headerPanel.Controls.Add(this.btnGithub);
            this.headerPanel.Controls.Add(this.titleLabel);
            this.headerPanel.Controls.Add(this.chkAutoUnlock);
            this.headerPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.headerPanel.Location = new System.Drawing.Point(0, 0);
            this.headerPanel.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.headerPanel.Name = "headerPanel";
            this.headerPanel.Padding = new System.Windows.Forms.Padding(27, 24, 27, 24);
            this.headerPanel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.headerPanel.Size = new System.Drawing.Size(2133, 112);
            this.headerPanel.TabIndex = 1;
            // 
            // progressRing
            // 
            this.progressRing.Location = new System.Drawing.Point(1200, 24);
            this.progressRing.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.progressRing.MarqueeAnimationSpeed = 50;
            this.progressRing.Name = "progressRing";
            this.progressRing.Size = new System.Drawing.Size(72, 64);
            this.progressRing.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressRing.TabIndex = 4;
            this.progressRing.Visible = false;
            // 
            // btnUnlock
            // 
            this.btnUnlock.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnUnlock.Location = new System.Drawing.Point(536, 24);
            this.btnUnlock.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnUnlock.MinimumSize = new System.Drawing.Size(320, 0);
            this.btnUnlock.Name = "btnUnlock";
            this.btnUnlock.Size = new System.Drawing.Size(400, 64);
            this.btnUnlock.TabIndex = 3;
            this.btnUnlock.Text = "فعال کردن دسترسی ادمین";
            this.btnUnlock.UseVisualStyleBackColor = true;
            this.btnUnlock.Click += new System.EventHandler(this.BtnUnlock_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnRefresh.Location = new System.Drawing.Point(200, 24);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnRefresh.MinimumSize = new System.Drawing.Size(320, 0);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(320, 64);
            this.btnRefresh.TabIndex = 2;
            this.btnRefresh.Text = "بارگذاری مجدد";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.BtnRefresh_Click);
            // 
            // btnGithub
            // 
            this.btnGithub.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.btnGithub.Location = new System.Drawing.Point(32, 24);
            this.btnGithub.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.btnGithub.Name = "btnGithub";
            this.btnGithub.Size = new System.Drawing.Size(152, 64);
            this.btnGithub.TabIndex = 1;
            this.btnGithub.Text = "گیت‌هاب";
            this.btnGithub.UseVisualStyleBackColor = true;
            this.btnGithub.Click += new System.EventHandler(this.BtnGithub_Click);
            // 
            // titleLabel
            // 
            this.titleLabel.Dock = System.Windows.Forms.DockStyle.Right;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(1349, 24);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(8, 0, 8, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.titleLabel.Size = new System.Drawing.Size(757, 64);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "مدیریت دسترسی ادمین مودم HA6400";
            this.titleLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkAutoUnlock
            // 
            this.chkAutoUnlock.Font = new System.Drawing.Font("Segoe UI", 8.25F);
            this.chkAutoUnlock.Location = new System.Drawing.Point(952, 29);
            this.chkAutoUnlock.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.chkAutoUnlock.Name = "chkAutoUnlock";
            this.chkAutoUnlock.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkAutoUnlock.Size = new System.Drawing.Size(232, 57);
            this.chkAutoUnlock.TabIndex = 5;
            this.chkAutoUnlock.Text = "آنلاک خودکار";
            this.chkAutoUnlock.CheckedChanged += new System.EventHandler(this.ChkAutoUnlock_CheckedChanged);
            // 
            // infoMessageText
            // 
            this.infoMessageText.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoMessageText.Location = new System.Drawing.Point(13, 12);
            this.infoMessageText.Margin = new System.Windows.Forms.Padding(0);
            this.infoMessageText.Name = "infoMessageText";
            this.infoMessageText.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.infoMessageText.Size = new System.Drawing.Size(2107, 55);
            this.infoMessageText.TabIndex = 0;
            this.infoMessageText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // infoMessageBar
            // 
            this.infoMessageBar.Controls.Add(this.infoMessageText);
            this.infoMessageBar.Dock = System.Windows.Forms.DockStyle.Top;
            this.infoMessageBar.Location = new System.Drawing.Point(0, 112);
            this.infoMessageBar.Margin = new System.Windows.Forms.Padding(27, 0, 27, 24);
            this.infoMessageBar.Name = "infoMessageBar";
            this.infoMessageBar.Padding = new System.Windows.Forms.Padding(13, 12, 13, 12);
            this.infoMessageBar.Size = new System.Drawing.Size(2133, 74);
            this.infoMessageBar.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(16F, 31F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2133, 1192);
            this.Controls.Add(this.webView);
            this.Controls.Add(this.infoMessageBar);
            this.Controls.Add(this.headerPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(8, 7, 8, 7);
            this.Name = "Form1";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Text = "MCI - HA6400 Hidden Settings Unlocker";
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.headerPanel.ResumeLayout(false);
            this.infoMessageBar.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private Panel headerPanel;
        private Label titleLabel;
        private Button btnGithub;
        private Button btnRefresh;
        private Button btnUnlock;
        private CheckBox chkAutoUnlock;
        private ProgressBar progressRing;
        private Label infoMessageText;
        private Panel infoMessageBar;
    }
}