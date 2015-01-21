using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store
{
    public partial class SearchPanel : System.Web.UI.UserControl
    {
        public int idCategory { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            initPanel();
        }

        private void initPanel()
        {
            
        }

    }
}