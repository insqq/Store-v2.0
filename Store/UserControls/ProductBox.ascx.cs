using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Reflection;

namespace Store
{
    public partial class ProductBox : System.Web.UI.UserControl
    {
        private int _id;

        public int id
        {
            get { return _id; }
            set
            {
                _id = value;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            initBox();
        }

        private void initBox()
        {
            // get product information from database
            var context = new StoreDbContext();
            var productInfo = (from c in context.product
                               where c.idproduct == _id
                               select c).Single();

            // init product box
            nameLink.Text = productInfo.name;
            nameLink.NavigateUrl = "";
            imgBtn.ImageUrl = productInfo.img;
            priceBtn.Text = "" + productInfo.price + "  грн.";

            // get product attributes from database
            var d = (from c in context.generalinfo
                              where productInfo.idproduct == c.product_idproduct
                              where c.type == "attr"
                              select c).ToDictionary(t=>t.Key, t=>t.Value);

            // init Data Grid View by product attributes
            DataGrid dg = new DataGrid();
            dg.ShowHeader = false;
            dg.GridLines = GridLines.None;
            dg.DataSource = d;
            dg.DataBind();
            prodInfoUPD.ContentTemplateContainer.Controls.Add(dg);
        }
    }
}