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
            var context = new StoreDbContext();

            var dictAttrs = (from gi in context.generalinfo
                             join p in context.product on gi.product_idproduct equals p.idproduct
                             join c in context.category on p.category_idcategory equals c.idcategory
                             where gi.type == "info" && c.idcategory == idCategory
                             select new
                             {
                                 name = gi.Key,
                                 values = gi.Value.Distinct()
                             }).ToDictionary(t => t.name, t => t.values);

            GridView dg = new GridView();
            dg.DataSource = dictAttrs;
            dg.DataBind();
            ControlContentUPD.ContentTemplateContainer.Controls.Add(dg);
        }
    }
}