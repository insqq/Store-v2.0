using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Store
{
    public partial class Search : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            loadProductBoxes();
        }

        private void loadProductBoxes()
        {
            var context = new StoreDbContext();
            int idCategory = Convert.ToInt32(Request.QueryString["id"]);
            var l = (from c in context.product
                    where c.category_idcategory == idCategory
                    select c.idproduct).Take(20);

            foreach (var pID in l)
            {
                ProductBox pb = (ProductBox)LoadControl("~/UserControls/ProductBox.ascx");
                pb.id = pID;
                UpdPanelContent.ContentTemplateContainer.Controls.Add(pb);
            }
        }
    }
}