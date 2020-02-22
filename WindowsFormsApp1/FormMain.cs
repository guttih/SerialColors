using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using System.Management;
using System.Threading;
using SerialColors.Data;
using SerialColors.Properties;

namespace SerialColors
{
    
    public partial class FormMain : Form
    {
        private SerialPort port;
        private Thread calcilationThread;
        public static PerformanceCounter CpuCounter;
        private float cpuUsage;
        private List<Step> steps;
        private FormSplash splash;
        public bool visabilityAllowed = true;
        private bool hasInitilized = false;

        public FormMain()
        {
            visabilityAllowed = !Properties.Settings.Default.HideOnStartup;
            
            InitializeComponent();

            if (!hasInitilized)
            {
                trayMenuItemShow.Visible = !visabilityAllowed;
                trayMenuItemHide.Visible = visabilityAllowed;

                splash = new FormSplash("initializing...");
                if (visabilityAllowed)
                    splash.Show();

                Init();
                if (visabilityAllowed)
                    splash.Hide();
                hasInitilized = true;
                
            }

            SetButtonState();

            
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        protected override void SetVisibleCore(bool value)
        {
            base.SetVisibleCore(visabilityAllowed? value : false);
        }


        private void Init()
        {
            splash.Set("SerialColors", "Setting up Timers");
            EnableCpu(manualToolStripMenuItem.Checked);
            CpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total");

            splash.Message = "Setting up config";

            steps = (new StepRepository(Settings.Default)).GetAllSteps();
            InitCombo();
            splash.Set("Application", "Starting CPU Thread");
            StartCpuThread();
            //GetFullComputerDevices();


        }

        public void StartCpuThread()
        {

            calcilationThread = new Thread(GetAndUpdateCpuUsage);
            calcilationThread.IsBackground = true;
            calcilationThread.Start();
        }

        public float GetCurrentCpuUsage()
        {
            CpuCounter.NextValue();
            Thread.Sleep(1200);
            return CpuCounter.NextValue();
        }

        private void GetAndUpdateCpuUsage()
        {
            while (true)
            {
                cpuUsage = GetCurrentCpuUsage();
            }

        }

        private void CloseForm()
        {
            calcilationThread.Abort();
            Close();
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            CloseForm();
        }

        private void OnTrackBarScroll()
        {
            timer1.Stop();
            timer1.Start();
            timer1.Enabled = true;
        }
        private void TbRed_Scroll(object sender, EventArgs e)
        {
            OnTrackBarScroll();
        }

        private void TbGreen_Scroll(object sender, EventArgs e)
        {
            OnTrackBarScroll();
        }

        private void TbBlue_Scroll(object sender, EventArgs e)
        {
            OnTrackBarScroll();
        }

        private void TbRed_SizeChanged(object sender, EventArgs e)
        {
        }

        
        private void Timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Enabled = false;


            string sendString;
            SColor color = new SColor(0,0,0);
            if (manualToolStripMenuItem.Checked == true)
            {
               
                color.Red = (byte)(ulong)tbRed.Value;
                color.Green = (byte)(ulong)tbGreen.Value;
                color.Blue = (byte)(ulong)tbBlue.Value;
                
                
            }
            else
            {
                var rounded = Convert.ToInt32(cpuUsage);
                if (steps != null) { 
                    foreach (var item in steps)
                    {
                        if (rounded >= item.From && rounded <= item.To )
                        {
                            color.SetColor(item.Color);
                            break;
                        }
                    }
                }
            }

            
            pbColorBox.BackColor = Color.FromArgb(color.Red, color.Green, color.Blue);
            sendString = $"{color.ToUlong()}";



            if (port != null && port.IsOpen)
            {
                Console.Write(sendString);
                try { 
                    port.WriteLine(sendString);
                    //Console.WriteLine(" -> " + ScolorToString(color));
                } catch (Exception exception)
                {
                    Console.WriteLine("Exception :" +  exception.Message);
                    return;
                }
                
            }

            if (manualToolStripMenuItem.Checked == false)
            {
                timer1.Interval = 1000;
                timer1.Enabled = true;
            }
            else
            {
                timer1.Interval = 200;
            }

        }

        private string ScolorToString(SColor color)
        {
            return $"r:{color.Red} g:{color.Green} b:{color.Blue} ";
        }

        public bool GetFullComputerDevices(string findPort)
        {
            var ret = false;
            ManagementClass processClass = new ManagementClass("Win32_PnPEntity");


            ManagementObjectCollection moCollection = processClass.GetInstances();

            foreach (var mo in moCollection)
            {
                /*Console.WriteLine("--------------------------");
                foreach (PropertyData prop in mo.Properties)
                {
                    Console.WriteLine($"{prop.Name}: {prop.Value}");
                }*/
                var property = (ManagementObject) mo;
                if (property.GetPropertyValue("Name") != null)
                {

                    var format = property.GetPropertyValue("Name").ToString();
                    if (format.Contains("COM") && (format.Contains("USB") || format.Contains("Standard Serial over Bluetooth link"))
                        )
                    {
                        var name = format;
                        Console.WriteLine(format);
                        ret = (name.IndexOf($"({findPort})", StringComparison.Ordinal) > -1) ||
                              (name.IndexOf($"Standard Serial over Bluetooth link ({findPort})", StringComparison.Ordinal) > -1);
                        if (ret)
                            break;
                    }
                }
            }
            return ret;
        }

        public void InitCombo()
        {
            splash.Set("SerialColors - Scanning ports...", "");
            string[] ports = SerialPort.GetPortNames();

            Console.WriteLine("The following serial ports were found:");
            comboPorts.Items.Clear();
            // Display each port name to the console.
            var list = new List<string>();
            foreach (string portName in ports)
            {
                splash.Message = portName;
                if (GetFullComputerDevices(portName))
                {
                    if (!list.Contains(portName))
                    {
                        list.Add(portName);
                    }
                        
                }
                

            }

            var sorted = list.OrderBy(m => m.Length).ThenBy(m => m).ToList();
            sorted.ForEach(m => comboPorts.Items.Add(m));

            //Selecting and opening port
            comboPorts.Enabled = comboPorts.Items.Count > 0;
            if (comboPorts.Enabled)
            {
                int index = 0;
                while(index < comboPorts.Items.Count)
                {
                    var nextPortName = comboPorts.Items[index].ToString();
                    splash.Message = $"{nextPortName}";
                    if ( OpenSerialPort(nextPortName, 115200) ) {
                        comboPorts.SelectedIndex = index;
                        return;
                    }
                    index++;
                }
            }
        }

        void StringColorToForm(string color)
        {
            ulong res = Convert.ToUInt32(color);
            var colorRet = new SColor(res);
            tbRed.Value = colorRet.Red;
            tbGreen.Value = colorRet.Green;
            tbBlue.Value = colorRet.Blue;
        }
        
        private bool OpenSerialPort(string portName, int baudRate)
        {
            splash.Set("SerialColors - Attemting connection to port", portName);
            if (port != null)
            {
                port.Close();
            }
            
            port = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);

            try
            {
                port.ReadTimeout = 1200;
                port.WriteTimeout = 1200;
                port.Open();
                port.WriteLine("status");
                var strColor = port.ReadLine();
                StringColorToForm(strColor);
                return true;
            }
            catch (UnauthorizedAccessException)
            {
                Console.WriteLine($"Error: Port {portName} is in use");
            }
            catch (Exception ex)
            {
                if (ex.HResult == -2146233083 || ex.HResult == -2146233083)
                {   //{"The read timed out."} or {"The write timed out."}
                    Console.WriteLine($"Port operation on {portName} took too long, {ex.Message}");
                    port.Close();
                    return false;
                }
                Console.WriteLine("Error opening port: " + ex);
                port.Close();
            }

            return false;

        }

        private void ComboPorts_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboPorts.SelectedIndex;
            if (index > -1)
            {
                var portName = comboPorts.Items[index].ToString();
                if (!OpenSerialPort(portName, 115200)) {
                    manualToolStripMenuItem.Checked = true;
                }
            }
            
        }

        private void checkManual_CheckedChanged(object sender, EventArgs e)
        {
        }

        private void EnableCpu(bool manualToolStripMenuItemChecked)
        {
            
            tbRed   .Visible = manualToolStripMenuItemChecked;
            tbGreen .Visible = manualToolStripMenuItemChecked;
            tbBlue  .Visible = manualToolStripMenuItemChecked;
            lblRed  .Visible = manualToolStripMenuItemChecked;
            lblGreen.Visible = manualToolStripMenuItemChecked;
            lblBlue .Visible = manualToolStripMenuItemChecked;

            lblCPU .Visible = !manualToolStripMenuItemChecked;
        }

        private void timerCpu_Tick(object sender, EventArgs e)
        {
            //lblCPU.Text = $"{this.cpuUsage:00.0} %";
            lblCPU.Text = $"{cpuUsage:00}%";

            if (manualToolStripMenuItem.Checked)
            {

                pbColorBox.BackColor = Color.FromArgb(tbRed.Value, tbGreen.Value, tbBlue.Value);
            }
            
        }
        private void btnCopyClipboard_Click(object sender, EventArgs e)
        {
            CopyColorToClipboard();
        }

        private void mainToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

         private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CopyColorToClipboard();
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PasteColorFromClipboard();
        }

        private void CopyColorToClipboard()
        {
            var color = pbColorBox.BackColor;
            var number = (new SColor(color.R, color.G, color.B)).ToUlong();
            Clipboard.SetText(number.ToString());
        }

        private void PasteColorFromClipboard()
        {
            string text = Clipboard.GetText();
            try
            {
                StringColorToForm(text);
            }
            catch (Exception)
            {
                Console.WriteLine("Let's just eat this error ;)");
            }
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new FormSettings();
            var res = form.ShowDialog();
            if (res == DialogResult.OK)
            {
                steps = (new StepRepository(Settings.Default)).GetAllSteps();
            }
        }
        private void manualToolStripMenuItem_CheckedChanged(object sender, EventArgs e)
        {
            if (manualToolStripMenuItem.Checked == false)
            {
                timer1.Enabled = true;
            }
            EnableCpu(manualToolStripMenuItem.Checked);
            SetButtonState();
        }

        private void manualToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var item = (System.Windows.Forms.ToolStripMenuItem)sender;
            item.Checked = !item.Checked;
        }

        private void SetButtonState()
        {
            pasteToolStripMenuItem.Enabled = manualToolStripMenuItem.Checked && Clipboard.ContainsText();
        }

        private void copyCurrentColorToolStripMenuItem_Paint(object sender, PaintEventArgs e)
        {
            SetButtonState();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new About();
            form.ShowDialog();
        }

        private void openClientFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try {
                var path = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                path += @"\SerialColors\Arduino";
                System.Diagnostics.Process.Start(path);
            } catch (Exception ex)
               {
                   MessageBox.Show(ex.Message);
               }
               
               
        }

        private void contextMenuTray_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

            Console.WriteLine(sender);
        }

        private void OnShowTrayItemClicked(bool show)
        {
            visabilityAllowed = true;
            base.SetVisibleCore(true);
            this.Visible = show;
            trayMenuItemShow.Visible = !show;
            trayMenuItemHide.Visible = show;
        }
        private void contextMenuTray_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Name == "trayMenuItemExit")
            {
                Close();
            }
            else if (e.ClickedItem.Name == "trayMenuItemShow")
            {
                OnShowTrayItemClicked(true);
            } else if (e.ClickedItem.Name == "trayMenuItemHide")
            {
                OnShowTrayItemClicked(false);
            }

        }

        private void hideOnStartupToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hideOnStartup = !hideOnStartupToolStripMenuItem.Checked;
            hideOnStartupToolStripMenuItem.Checked = hideOnStartup;
            Properties.Settings.Default.HideOnStartup = hideOnStartup;
            Properties.Settings.Default.Save();

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }
    }
}
