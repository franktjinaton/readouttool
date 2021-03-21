namespace SwReadoutToolExample
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
            this.label1 = new System.Windows.Forms.Label();
            this.lblDevice = new System.Windows.Forms.Label();
            this.gbRegisters = new System.Windows.Forms.GroupBox();
            this.txtRegisterOutput = new System.Windows.Forms.TextBox();
            this.btnReadRegisters = new System.Windows.Forms.Button();
            this.gbLogging = new System.Windows.Forms.GroupBox();
            this.btnEraseLogging = new System.Windows.Forms.Button();
            this.btnReadLogging = new System.Windows.Forms.Button();
            this.gbClock = new System.Windows.Forms.GroupBox();
            this.btnSetClock = new System.Windows.Forms.Button();
            this.btnReadClock = new System.Windows.Forms.Button();
            this.gbBattery = new System.Windows.Forms.GroupBox();
            this.btn95proc = new System.Windows.Forms.Button();
            this.btn85proc = new System.Windows.Forms.Button();
            this.gbRegisters.SuspendLayout();
            this.gbLogging.SuspendLayout();
            this.gbClock.SuspendLayout();
            this.gbBattery.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Device:";
            // 
            // lblDevice
            // 
            this.lblDevice.AutoSize = true;
            this.lblDevice.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblDevice.ForeColor = System.Drawing.Color.Red;
            this.lblDevice.Location = new System.Drawing.Point(102, 9);
            this.lblDevice.Name = "lblDevice";
            this.lblDevice.Size = new System.Drawing.Size(151, 25);
            this.lblDevice.TabIndex = 1;
            this.lblDevice.Text = "Not connected";
            // 
            // gbRegisters
            // 
            this.gbRegisters.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.gbRegisters.Controls.Add(this.txtRegisterOutput);
            this.gbRegisters.Controls.Add(this.btnReadRegisters);
            this.gbRegisters.Enabled = false;
            this.gbRegisters.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbRegisters.Location = new System.Drawing.Point(17, 37);
            this.gbRegisters.Name = "gbRegisters";
            this.gbRegisters.Size = new System.Drawing.Size(519, 476);
            this.gbRegisters.TabIndex = 2;
            this.gbRegisters.TabStop = false;
            this.gbRegisters.Text = "Registers";
            // 
            // txtRegisterOutput
            // 
            this.txtRegisterOutput.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtRegisterOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegisterOutput.Location = new System.Drawing.Point(6, 25);
            this.txtRegisterOutput.Multiline = true;
            this.txtRegisterOutput.Name = "txtRegisterOutput";
            this.txtRegisterOutput.ReadOnly = true;
            this.txtRegisterOutput.Size = new System.Drawing.Size(507, 416);
            this.txtRegisterOutput.TabIndex = 3;
            // 
            // btnReadRegisters
            // 
            this.btnReadRegisters.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnReadRegisters.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadRegisters.Location = new System.Drawing.Point(438, 447);
            this.btnReadRegisters.Name = "btnReadRegisters";
            this.btnReadRegisters.Size = new System.Drawing.Size(75, 23);
            this.btnReadRegisters.TabIndex = 2;
            this.btnReadRegisters.Text = "Read";
            this.btnReadRegisters.UseVisualStyleBackColor = true;
            this.btnReadRegisters.Click += new System.EventHandler(this.btnReadRegisters_Click);
            // 
            // gbLogging
            // 
            this.gbLogging.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbLogging.Controls.Add(this.btnEraseLogging);
            this.gbLogging.Controls.Add(this.btnReadLogging);
            this.gbLogging.Enabled = false;
            this.gbLogging.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbLogging.Location = new System.Drawing.Point(17, 519);
            this.gbLogging.Name = "gbLogging";
            this.gbLogging.Size = new System.Drawing.Size(169, 73);
            this.gbLogging.TabIndex = 3;
            this.gbLogging.TabStop = false;
            this.gbLogging.Text = "Logging";
            // 
            // btnEraseLogging
            // 
            this.btnEraseLogging.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEraseLogging.Location = new System.Drawing.Point(87, 29);
            this.btnEraseLogging.Name = "btnEraseLogging";
            this.btnEraseLogging.Size = new System.Drawing.Size(75, 23);
            this.btnEraseLogging.TabIndex = 1;
            this.btnEraseLogging.Text = "Erase";
            this.btnEraseLogging.UseVisualStyleBackColor = true;
            this.btnEraseLogging.Click += new System.EventHandler(this.btnEraseLogging_Click);
            // 
            // btnReadLogging
            // 
            this.btnReadLogging.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadLogging.Location = new System.Drawing.Point(6, 29);
            this.btnReadLogging.Name = "btnReadLogging";
            this.btnReadLogging.Size = new System.Drawing.Size(75, 23);
            this.btnReadLogging.TabIndex = 0;
            this.btnReadLogging.Text = "Read";
            this.btnReadLogging.UseVisualStyleBackColor = true;
            this.btnReadLogging.Click += new System.EventHandler(this.btnReadLogging_Click);
            // 
            // gbClock
            // 
            this.gbClock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbClock.Controls.Add(this.btnSetClock);
            this.gbClock.Controls.Add(this.btnReadClock);
            this.gbClock.Enabled = false;
            this.gbClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbClock.Location = new System.Drawing.Point(192, 520);
            this.gbClock.Name = "gbClock";
            this.gbClock.Size = new System.Drawing.Size(169, 73);
            this.gbClock.TabIndex = 4;
            this.gbClock.TabStop = false;
            this.gbClock.Text = "Clock";
            // 
            // btnSetClock
            // 
            this.btnSetClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetClock.Location = new System.Drawing.Point(87, 29);
            this.btnSetClock.Name = "btnSetClock";
            this.btnSetClock.Size = new System.Drawing.Size(75, 23);
            this.btnSetClock.TabIndex = 2;
            this.btnSetClock.Text = "Set";
            this.btnSetClock.UseVisualStyleBackColor = true;
            this.btnSetClock.Click += new System.EventHandler(this.btnSetClock_Click);
            // 
            // btnReadClock
            // 
            this.btnReadClock.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnReadClock.Location = new System.Drawing.Point(6, 29);
            this.btnReadClock.Name = "btnReadClock";
            this.btnReadClock.Size = new System.Drawing.Size(75, 23);
            this.btnReadClock.TabIndex = 1;
            this.btnReadClock.Text = "Read";
            this.btnReadClock.UseVisualStyleBackColor = true;
            this.btnReadClock.Click += new System.EventHandler(this.btnReadClock_Click);
            // 
            // gbBattery
            // 
            this.gbBattery.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gbBattery.Controls.Add(this.btn95proc);
            this.gbBattery.Controls.Add(this.btn85proc);
            this.gbBattery.Enabled = false;
            this.gbBattery.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gbBattery.Location = new System.Drawing.Point(367, 520);
            this.gbBattery.Name = "gbBattery";
            this.gbBattery.Size = new System.Drawing.Size(169, 73);
            this.gbBattery.TabIndex = 5;
            this.gbBattery.TabStop = false;
            this.gbBattery.Text = "Battery";
            // 
            // btn95proc
            // 
            this.btn95proc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn95proc.Location = new System.Drawing.Point(87, 29);
            this.btn95proc.Name = "btn95proc";
            this.btn95proc.Size = new System.Drawing.Size(75, 23);
            this.btn95proc.TabIndex = 1;
            this.btn95proc.Text = "95%";
            this.btn95proc.UseVisualStyleBackColor = true;
            this.btn95proc.Click += new System.EventHandler(this.btn95proc_Click);
            // 
            // btn85proc
            // 
            this.btn85proc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn85proc.Location = new System.Drawing.Point(6, 29);
            this.btn85proc.Name = "btn85proc";
            this.btn85proc.Size = new System.Drawing.Size(75, 23);
            this.btn85proc.TabIndex = 0;
            this.btn85proc.Text = "85%";
            this.btn85proc.UseVisualStyleBackColor = true;
            this.btn85proc.Click += new System.EventHandler(this.btn85proc_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(555, 605);
            this.Controls.Add(this.gbBattery);
            this.Controls.Add(this.gbClock);
            this.Controls.Add(this.gbLogging);
            this.Controls.Add(this.gbRegisters);
            this.Controls.Add(this.lblDevice);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form1";
            this.Text = "BBMS Readout Tool Veria Onderhoud";
            this.Shown += new System.EventHandler(this.Form1_Shown);
            this.gbRegisters.ResumeLayout(false);
            this.gbRegisters.PerformLayout();
            this.gbLogging.ResumeLayout(false);
            this.gbClock.ResumeLayout(false);
            this.gbBattery.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDevice;
        private System.Windows.Forms.GroupBox gbRegisters;
        private System.Windows.Forms.TextBox txtRegisterOutput;
        private System.Windows.Forms.Button btnReadRegisters;
        private System.Windows.Forms.GroupBox gbLogging;
        private System.Windows.Forms.Button btnEraseLogging;
        private System.Windows.Forms.Button btnReadLogging;
        private System.Windows.Forms.Button btnSetClock;
        private System.Windows.Forms.Button btnReadClock;
        private System.Windows.Forms.GroupBox gbClock;
        private System.Windows.Forms.GroupBox gbBattery;
        private System.Windows.Forms.Button btn95proc;
        private System.Windows.Forms.Button btn85proc;
    }
}

