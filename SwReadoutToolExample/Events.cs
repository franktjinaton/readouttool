using BBmsLogfile;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SwReadoutToolExample
{
    public partial class Events : Form
    {
        public IEvent[] events { set; private get; }

        public Events()
        {
            InitializeComponent();
        }

        private void Events_Shown(object sender, EventArgs e)
        {
            StringBuilder sb = new StringBuilder();

            foreach (IEvent evt in events)
            {
                sb.Append(evt.DateTime.ToString("yyyy-MM-dd HH:mm:ss"));
                sb.Append("\t");
                sb.Append(evt.EventType);
                sb.Append("\t");
                foreach (EventValue val in evt.EventValues)
                    sb.AppendFormat("{0}: {1}, ", val.Parameter, val.Value);
                sb.AppendLine("");
            }

            txtEvents.Text = sb.ToString();
        }
    }
}
