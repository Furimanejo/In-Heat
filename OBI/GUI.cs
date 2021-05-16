using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OBI
{
    public partial class GUI : Form
    {
        ClientController clientController;
        OnFireTracker onFireTracker;

        public GUI()
        {
            InitializeComponent();
            clientController = new ClientController();
            onFireTracker = new OnFireTracker(TrackerPictureBox);
        }
    }
}
