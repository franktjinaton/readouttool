using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BBMSBootloaderDevice;
using BBmsLogfile;
using SwReadoutToolExample;

namespace VeldiaReadout
{
    public partial class NewDesign : Form
    {
        // The interface to the pack, null when no device is found, object when ready to use
        private ISBSInterface canSbsDevice;

        /// <summary>
        /// Constructor, intialize dialog and USB interface
        /// </summary>
        public NewDesign()
        {
            Stm32WinUSBInterface.Stm32Interface.StartUSBNotifier(this);
            Stm32WinUSBInterface.Stm32Interface.Arrival += DeviceChange;
            Stm32WinUSBInterface.Stm32Interface.Removal += DeviceChange;

            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void NewDesign_Load(object sender, EventArgs e)
        {
            btnReadClock.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnReadRegisters.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnSetClock.FlatAppearance.MouseOverBackColor = Color.Transparent;
            btnReadLogging.FlatAppearance.MouseOverBackColor = Color.Transparent;

            btnReadClock.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnReadRegisters.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnSetClock.FlatAppearance.MouseDownBackColor = Color.Transparent;
            btnReadLogging.FlatAppearance.MouseDownBackColor = Color.Transparent;
        }

        private void buttonModified1_Click(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void label28_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// The dialog is shown to the user, scan for devices attached to the system
        /// </summary>
        private void NewDesign_Shown(object sender, EventArgs e)
        {
            DeviceChange(sender);
        }

        /// <summary>
        /// Go and look for devices we can use
        /// If we find more then one, use the first one found
        /// </summary>
        private void DeviceChange(object sender)
        {
            //Create a interface the the Readout tool
            IBootloaderDevice devIntf = new BBmsProgrammer.BBmsProgrammer();

            //Get a list of devices and communication options
            ISBSInterface[] sbsDevs = devIntf.AvailableInterface;
            IDevice[] devs = devIntf.AvailableDevice;
            if (devs == null || devs.Length == 0)
            {
                //Clear the localy stored device object
                canSbsDevice = null;
                //Update the view
                //gbRegisters.Enabled = gbLogging.Enabled = gbClock.Enabled = 
                gbBattery.Enabled = false;
                lblDevice.Text = "Not connected";
                lblDevice.ForeColor = Color.Red;
                return;
            }

            //Check if the device supports CAN
            canSbsDevice = sbsDevs.FirstOrDefault(x => x.Protocol == "CAN");
            if (canSbsDevice == null)
            {
                //Update the view
                //gbRegisters.Enabled = gbLogging.Enabled = gbClock.Enabled = 
                gbBattery.Enabled = false;
                lblDevice.Text = "Not connected";
                lblDevice.ForeColor = Color.Red;
                return;
            }

            //Open the (first)device
            canSbsDevice.Open(devs[0]);

            //Update the view
            //gbRegisters.Enabled = gbLogging.Enabled = gbClock.Enabled = 
            gbBattery.Enabled = true;
            lblDevice.Text = "Connected";
            lblDevice.ForeColor = Color.Green;
        }

        private void button1_MouseHover(object sender, EventArgs e)
        {
           
        }

        private void btnReadLogging_MouseUp(object sender, MouseEventArgs e)
        {
            
        }

        private void btnReadLogging_MouseHover(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
        }

        private void btnReadLogging_MouseLeave(object sender, EventArgs e)
        {
            
        }

        private void btnReadLogging_CursorChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
        }

        private void btnReadClock_Click(object sender, EventArgs e)
        {
            //Just to be sure, check if we have an open device
            if (canSbsDevice == null)
                return;

            //Store the current time, for comparison
            DateTime now = DateTime.UtcNow;

            //Read the RTC time from the pack
            Byte[] data;
            if (!canSbsDevice.ReadSBSRegister(BBMSBootloaderDevice.SBSRegisters.RTCTime, 4, out data))
            {
                MessageBox.Show(this, "Failed to read RTC time", "Failed to read", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //Create a DateTime object
            DateTime rtc = new DateTime(1970, 1, 1).AddSeconds(BitConverter.ToUInt32(data, 0));

            //Create a delta between pack and current time
            TimeSpan span = rtc.Subtract(now);

            //Show values in dialog box
            String Message = String.Format("BBMS internal clock {0} (offset {1:0}s)", rtc.ToString("dd-MM-yyyy HH:mm:ss"), span.TotalSeconds);
            MessageBox.Show(this, Message, "BBMS clock", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSetClock_Click(object sender, EventArgs e)
        {
            //Just to be sure, check if we have an open device
            if (canSbsDevice == null)
                return;

            //Create a byte-array of the current time
            DateTime now = DateTime.UtcNow;
            UInt32 TimeStamp = (UInt32)now.Subtract(new DateTime(1970, 1, 1)).TotalSeconds;
            Byte[] data = BitConverter.GetBytes(TimeStamp);

            //Write the RTC time
            if (!canSbsDevice.WriteSBSRegister(BBMSBootloaderDevice.SBSRegisters.RTCTime, data))
            {
                MessageBox.Show(this, "Failed to set RTC time", "Failed to set", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnReadLogging_Click(object sender, EventArgs e)
        {
            //Just to be sure, check if we have an open device
            if (canSbsDevice == null)
                return;

            //Create an interface to the logfile
            Logfile logfile = new Logfile(canSbsDevice);

            //A dialog is created that displays the readout progress.
            //The shown event of the dialog is used to start a task that actually reads the log and updates the dialog text and progress bar.
            //An events list is returned when finished
            IEvent[] events = null;
            BmsProgressStatus waitDialog = new BmsProgressStatus();
            waitDialog.Shown += (se, ev) =>
            {
                Task tsk = new Task(delegate
                {
                    //Actual reading function for events
                    logfile.ReadLog(out events, waitDialog, true);
                });
                tsk.Start();
            };
            waitDialog.ShowDialog(this);

            Events dlg = new Events();
            dlg.events = events;
            dlg.ShowDialog(this);
        }

        private void btnReadRegisters_Click(object sender, EventArgs e)
        {
            //Just to be sure, check if we have an open device
            if (canSbsDevice == null)
            {
                gbStat.Enabled = false;
                return;
            }

            //Display wait cursor while reading registers
            this.Cursor = Cursors.WaitCursor;

            //Create a variable where output is stored before sending it to the textbox
            StringBuilder Output = new StringBuilder();

            //FTAT 
            UInt16 remainingCapacity1;
            canSbsDevice.ReadSBSRegister(SBSRegisters.RemainingCapacity, out remainingCapacity1);
            //Output.AppendLine(String.Format("Remaining capacity: {0} Ah ", (Double)remainingCapacity1 / 1000 ));
            lblremainingCap.Text = String.Format("{0} Wh ", Math.Round((Double)remainingCapacity1 / 1000 * 36, 0));
            // END

            //FTAT 
            UInt16 fullChargeCapacity1;
            canSbsDevice.ReadSBSRegister(SBSRegisters.FullChargeCapacity, out fullChargeCapacity1);
            lblFullChargeC.Text = String.Format("{0} Wh ", Math.Round((Double)fullChargeCapacity1 / 1000 * 36));
            // END

            //FTAT 
            UInt16 bmsSettingsVersion1;
            canSbsDevice.ReadSBSRegister(SBSRegisters.BmsSettingsVersion, out bmsSettingsVersion1);
            //Output.AppendLine(String.Format("BMS settings version: {0} ", bmsSettingsVersion1));
            // END

            //FTAT 
            UInt16 specificationInfo1;
            canSbsDevice.ReadSBSRegister(SBSRegisters.SpecificationInfo, out specificationInfo1);
            //Output.AppendLine(String.Format("Specification info: {0} ", specificationInfo1));
            // END

            //FTAT Read the absolute state of charge
            UInt16 absoluteStateCharge1;
            canSbsDevice.ReadSBSRegister(SBSRegisters.AbsoluteStateOfCharge, out absoluteStateCharge1);
            lblAbsoluteSOC.Text = String.Format("{0}%", absoluteStateCharge1);
            // END

            //Read the relative state of charge
            UInt16 relativeStateCharge;
            canSbsDevice.ReadSBSRegister(SBSRegisters.RelativeStateOfCharge, out relativeStateCharge);
            lblRelativeSOC.Text = String.Format("{0}%", relativeStateCharge);

            //FTAT 
            UInt16 fullChargeCount1;
            canSbsDevice.ReadSBSRegister(SBSRegisters.FullChargeCount, out fullChargeCount1);
            lblFullChargeC.Text = String.Format("{0} ", fullChargeCount1);
            // END

            //FTAT Read the cycle count
            UInt16 cycleCount;
            canSbsDevice.ReadSBSRegister(SBSRegisters.CycleCount, out cycleCount);
            lblCycleC.Text = String.Format("{0}", cycleCount);
            // END

            //FTAT 
            UInt16 serialNumber;
            canSbsDevice.ReadSBSRegister(SBSRegisters.SerialNumber, out serialNumber);
            //Output.AppendLine(String.Format("Serial number BMS: {0} ", serialNumber));
            // END

            //Read the pack voltage
            UInt16 packVoltage;
            canSbsDevice.ReadSBSRegister(SBSRegisters.Voltage, out packVoltage);
            lblPackV.Text = String.Format("Pack voltage: {0:0.00}V", (Double)packVoltage / 1000.0);

            //Read the current charge / discharge current
            //Positive value is charging
            //Negative value is discharging
            UInt16 actualCurrent;
            canSbsDevice.ReadSBSRegister(SBSRegisters.Current, out actualCurrent);
            lblDeltaV.Text = String.Format("Actual current: {0:0.00}A", (Double)((Int16)actualCurrent) / 1000.0);

            //Read the cell voltages
            //First read the number of cells in the pack
            UInt16 nrCells = 0;
            canSbsDevice.ReadSBSRegister(SBSRegisters.CellNumber, out nrCells);

            UInt16 high = 0;
            UInt16 low = 0;

            for (UInt16 idx = 0; idx < nrCells; idx++)
            {
                //Select the index of the cell
                canSbsDevice.WriteSBSRegister(SBSRegisters.CellNumber, idx);

                //Read the cell voltage for the selected cell
                UInt16 cellVoltage;
                canSbsDevice.ReadSBSRegister(SBSRegisters.ActualVoltage, out cellVoltage);

                string l = "lblBatt" + (idx + 1);

                Label lbl_text = this.Controls.Find(l, true).FirstOrDefault() as Label;

                lbl_text.Text = String.Format("{1:0.000}V", (Double)cellVoltage / 1000.0);

                if (cellVoltage > high)
                {
                    high = cellVoltage;
                }
                else
                {
                    if (cellVoltage == 0) { low = cellVoltage; }

                    if (cellVoltage < low)
                    {
                        low = cellVoltage;
                    }
                }
            }

            lblDeltaVolt.Text = String.Format("{1:0.000}V", (high - low) / 1000.0);

            //Read the temperature values
            //First read the number of thermistors in the pack
            UInt16 nrThermistors = 0;
            canSbsDevice.ReadSBSRegister(SBSRegisters.PackTemperatureSensors, out nrThermistors);
            for (UInt16 idx = 0; idx < nrThermistors; idx++)
            {
                //Select the index of the thermistor
                canSbsDevice.WriteSBSRegister(SBSRegisters.PackTemperatureSensors, idx);

                //Read the temperature for the selected thermistor
                UInt16 tempSensor;
                canSbsDevice.ReadSBSRegister(SBSRegisters.TemperatureRegister, out tempSensor);

                string l = "lblTemp" + (idx + 1);

                Label lbl_text = this.Controls.Find(l, true).FirstOrDefault() as Label;

                lbl_text.Text = String.Format("{1:0.00}°C", ((Double)tempSensor / 10.0) - 273.15);
            }

            Byte[] chargCtrl;
            canSbsDevice.ReadSBSRegister(BBMSBootloaderDevice.SBSRegisters.PackChargeCtrl, 4, out chargCtrl);
            //Output.AppendLine(String.Format("Charge control: {0}", ChargeControlToString(chargCtrl)));

            //Update the textbox
            //txtRegisterOutput.Text = Output.ToString();

            //Set the cursor back to default
            this.Cursor = DefaultCursor;
        }

        /// <summary>
        /// Set the charge control to the specified level
        /// </summary>
        private void SetChargeControl(Byte level)
        {
            //Just to be sure, check if we have an open device
            if (canSbsDevice == null)
                return;

            Byte[] data = new Byte[4];
            data[0] = 1;    //Charge control ON
            data[1] = level;   //95%, charge control threshold
            data[2] = 40;   //40%, lower SOC threshold for winter storage
            data[3] = 50;   //50%, upper SOC threshold for winter storage

            //Write the Battery charge percentage
            if (!canSbsDevice.WriteSBSRegister(BBMSBootloaderDevice.SBSRegisters.PackChargeCtrl, data))
            {
                MessageBox.Show(this, "Failed to set Charge control", "Failed to set", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        //Converts the bytes from the charge control to a string
        private String ChargeControlToString(Byte[] data)
        {
            String modeTxt = "";

            switch (data[0])
            {
                case 0:
                    modeTxt += "Winter";
                    break;
                case 1:
                    modeTxt += "On";
                    break;
                case 2:
                    modeTxt += "Off";
                    break;
                default:
                    modeTxt += "Error";
                    break;
            }

            return String.Format("{0}, {1}%, {2}%, {3}%", modeTxt, data[1], data[2], data[3]);
        }

        private void lblTemp1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }
    }

   
}
