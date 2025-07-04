using Microsoft.Web.WebView2.Core;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HA6400AdminUnlocker
{
    public partial class Form1 : Form
    {
        private Timer autoCloseTimer;
        private bool autoUnlockExecuted = false;

        public Form1()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            InitializeAsync();
            LoadSettings();
        }

        private async void InitializeAsync()
        {
            await InitializeWebView2Async();
        }

        private void LoadSettings()
        {
            chkAutoUnlock.Checked = Properties.Settings.Default.AutoUnlockEnabled;
        }

        private void SaveSettings()
        {
            Properties.Settings.Default.AutoUnlockEnabled = chkAutoUnlock.Checked;
            Properties.Settings.Default.Save();
        }

        private async Task InitializeWebView2Async()
        {
            try
            {
                progressRing.Visible = true;
                btnUnlock.Enabled = false;

                var env = await CoreWebView2Environment.CreateAsync();
                await webView.EnsureCoreWebView2Async(env);

                webView.CoreWebView2.Settings.IsScriptEnabled = true;
                webView.CoreWebView2.Settings.AreDevToolsEnabled = false;
                webView.CoreWebView2.NavigationCompleted += WebView_NavigationCompleted;
                webView.CoreWebView2.Navigate("http://192.168.1.1");

                progressRing.Visible = false;
                btnUnlock.Enabled = true;
            }
            catch (Exception ex)
            {
                ShowInfoMessage("خطا", $"خطا در راه‌اندازی مرورگر: {ex.Message}", "Error");
            }
        }

        private async void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            if (!e.IsSuccess)
            {
                ShowInfoMessage("خطا", "خطا در بارگذاری صفحه مودم", "Error");
                return;
            }

            var currentUrl = webView.Source.ToString();

            if (currentUrl.EndsWith("/Login.html", StringComparison.OrdinalIgnoreCase))
            {
                this.Invoke((MethodInvoker)delegate
                {
                    btnUnlock.Text = "لطفاً ابتدا وارد شوید";
                    btnUnlock.Enabled = false;
                });

                ShowInfoMessage("توجه", "برای استفاده از قابلیت دسترسی ادمین، ابتدا وارد حساب مدیریت مودم شوید", "Info", true);
                return;
            }

            if (currentUrl.EndsWith("/overview.html", StringComparison.OrdinalIgnoreCase) ||
                currentUrl.EndsWith("/index.html", StringComparison.OrdinalIgnoreCase))
            {
                ShowInfoMessage("توجه", "با موفقیت به صفحه‌ی مدیریت مودم وارد شده‌اید!", "Success", true);

                if (chkAutoUnlock.Checked && !autoUnlockExecuted)
                {
                    autoUnlockExecuted = true;
                    await BtnUnlock_ClickAsync();
                }
                return;
            }

            await CheckStorageStatus();
        }

        private async Task CheckStorageStatus()
        {
            try
            {
                var result = await webView.CoreWebView2.ExecuteScriptAsync(
                    "JSON.stringify({level: localStorage.getItem('level')})");

                this.Invoke((MethodInvoker)delegate
                {
                    btnUnlock.Text = result.Contains("\"level\":\"01\"") ?
                        "دسترسی ادمین فعال است" : "فعال کردن دسترسی ادمین";
                    btnUnlock.Enabled = !result.Contains("\"level\":\"01\"");
                });
            }
            catch (Exception ex)
            {
                ShowInfoMessage("خطا", $"خطا در بررسی وضعیت ذخیره سازی: {ex.Message}", "Error");
            }
        }

        private async void BtnUnlock_Click(object sender, EventArgs e)
        {
            await BtnUnlock_ClickAsync();
        }

        private async Task BtnUnlock_ClickAsync()
        {
            try
            {
                progressRing.Visible = true;
                btnUnlock.Enabled = false;

                // تغییر مقدار localStorage
                await webView.CoreWebView2.ExecuteScriptAsync(
                    "localStorage.setItem('level', '01');" +
                    "localStorage.setItem('testKey', 'testValue');");

                // رفرش صفحه و انتظار برای بارگذاری کامل
                webView.CoreWebView2.Reload();

                // ثبت event handler برای NavigationCompleted
                var completionSource = new TaskCompletionSource<bool>();
                void Handler(object s, CoreWebView2NavigationCompletedEventArgs args)
                {
                    webView.CoreWebView2.NavigationCompleted -= Handler;
                    completionSource.TrySetResult(args.IsSuccess);
                }

                webView.CoreWebView2.NavigationCompleted += Handler;

                // انتظار برای تکمیل بارگذاری
                var success = await completionSource.Task;
                if (!success)
                {
                    ShowInfoMessage("خطا", "خطا در بارگذاری مجدد صفحه", "Error");
                    return;
                }

                // بررسی وضعیت جدید
                await CheckStorageStatus();

                ShowInfoMessage("موفقیت", "دسترسی ادمین با موفقیت فعال شد", "Success", true);
            }
            catch (Exception ex)
            {
                ShowInfoMessage("خطا", $"خطا در فعال کردن دسترسی ادمین: {ex.Message}", "Error");
            }
            finally
            {
                progressRing.Visible = false;
            }
        }

        private async void BtnRefresh_Click(object sender, EventArgs e)
        {
            webView.Reload();
        }

        private void BtnGithub_Click(object sender, EventArgs e)
        {
            try
            {
                Process.Start("https://github.com/MEHDIMYADI/HA6400AdminUnlocker");
            }
            catch (Exception ex)
            {
                ShowInfoMessage("خطا", $"خطا در باز کردن لینک گیت‌هاب: {ex.Message}", "Error");
            }
        }

        private void ChkAutoUnlock_CheckedChanged(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void ShowInfoMessage(string title, string message, string severity, bool autoClose = false, int closeAfterSeconds = 5)
        {
            this.Invoke((MethodInvoker)delegate
            {
                infoMessageText.Text = $"{title}: {message}";

                // تغییر رنگ بر اساس نوع پیام
                switch (severity)
                {
                    case "Error":
                        infoMessageBar.BackColor = Color.LightPink;
                        break;
                    case "Success":
                        infoMessageBar.BackColor = Color.LightGreen;
                        break;
                    case "Info":
                    default:
                        infoMessageBar.BackColor = Color.LightBlue;
                        break;
                }

                if (autoClose)
                {
                    if (autoCloseTimer != null)
                    {
                        autoCloseTimer.Stop();
                        autoCloseTimer = null;
                    }

                    autoCloseTimer = new Timer
                    {
                        Interval = closeAfterSeconds * 1000
                    };
                    autoCloseTimer.Tick += (s, e) =>
                    {
                        autoCloseTimer.Stop();
                        autoCloseTimer = null;
                    };
                    autoCloseTimer.Start();
                }
            });
        }
    }
}