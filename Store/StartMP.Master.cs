using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AjaxControlToolkit;
using System.Web.UI.HtmlControls;

namespace Store
{
    public partial class StartMP : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            menuInit();
            Label1.Text = "PLACEHOLDER";
        }

        private void menuInit()
        {
            menuBar1.Panes.Clear();
            var context = new StoreDbContext();
            // get categorys from db
            var l = from c in context.category
                    where c.category_idcategory == null
                    select new
                    {
                        name = c.name,
                        subNames = from c1 in context.category
                                   where c1.category_idcategory == c.idcategory
                                   select c1
                    };
            // add categorys to menu
            int i = 1;
            foreach (var item in l)
            {
                AccordionPane mItem = new AccordionPane();
                mItem.ID = "AcPane" + i;
                i++;
                HtmlAnchor title = new HtmlAnchor();
                title.Attributes.Add("class", "btn btn-primary; margin-top:10px");
                title.InnerText = item.name;
                mItem.HeaderContainer.Controls.Add(title);
                // add subcategorys to menu
                foreach (var subMenuItem in item.subNames)
                {
                    HtmlAnchor hAnchor = new HtmlAnchor();
                    hAnchor.InnerHtml = "&nbsp&nbsp&nbsp-&nbsp" + subMenuItem.name;
                    hAnchor.HRef = "Search.aspx?id=" + subMenuItem.idcategory.ToString();
                    mItem.ContentContainer.Controls.Add(hAnchor);
                    mItem.ContentContainer.Controls.Add(new LiteralControl("<br />"));
                }
                menuBar1.Panes.Add(mItem);
            }
        }
    }
}