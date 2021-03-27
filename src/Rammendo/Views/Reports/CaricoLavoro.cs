using Rammendo.Behaviors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Rammendo.Views.Reports
{
    public partial class CaricoLavoro : CWindow
    {
        public CaricoLavoro(Panel parent) : base(true, parent)
        {
            InitializeComponent();
            GenerateChildForm();
        }
    }
}
