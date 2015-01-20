using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            menuBar.Items.Clear();
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
            foreach (var item in l)
            {
                MenuItem mItem = new MenuItem(item.name);
                // add subcategorys to menu
                foreach (var subMenuItem in item.subNames)
                {
                    mItem.ChildItems.Add(new MenuItem(subMenuItem.name, "", "", "Search.aspx?id=" + subMenuItem.idcategory.ToString()));
                }
                menuBar.Items.Add(mItem);
            }
        }
    }
}