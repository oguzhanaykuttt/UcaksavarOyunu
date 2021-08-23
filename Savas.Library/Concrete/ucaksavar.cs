using Savas.Library.Abstract;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Savas.Library.Concrete
{
     internal class ucaksavar : Cisim
    {
        public ucaksavar(int panelGenisligi)
        {
            Left = (panelGenisligi - Width) / 2;

        }
    }
}
