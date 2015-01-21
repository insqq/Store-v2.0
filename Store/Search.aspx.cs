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
            int? page = Convert.ToInt32(Request.QueryString["page"]);

            // checking chosen category
            var catExist = (from c in context.category
                            where c.idcategory == idCategory
                            select c).Count();
            // getting products by chossen category
            var l = from c in context.product
                    where c.category_idcategory == idCategory
                    select c.idproduct;
            int pg = (int)((page == null) ? 0 : page);
            double count = l.Count() / 10;
            count = (count % 1 == 0) ? count : count++;
            // checking sellected page and id
            if (page < 0 || page > count || catExist == 0) Response.Redirect("404.aspx");

            // else init 
            // page buttons
            initButtons(pg, idCategory, count);
            // products on page
            var productOnPage = l.OrderBy(s=>s).Skip(pg * 10).Take(10);
            foreach (var pID in productOnPage)
            {
                ProductBox pb = (ProductBox)LoadControl("~/UserControls/ProductBox.ascx");
                pb.id = pID;
                contentPH.Controls.Add(pb);
            }

            // init search parameters
            SearchPanel sp = (SearchPanel)LoadControl("~/UserControls/SearchPanel.ascx");
            sp.idCategory = idCategory;
            searchPanelPH.Controls.Add(sp);
        }

        private void initButtons(int page, int idCategory, double count)
        {
            count = count % 1 == 0 ? count : count++;

            //first button, go to first page
            Button fBtn = new Button();
            fBtn.PostBackUrl = "Search.aspx?id=" + idCategory + "&" + "page=" + 0;
            fBtn.Text = "<<";
            fBtn.Attributes.Add("Class", "btn btn-primary");
            pageButtonsPH.Controls.Add(fBtn);
            int start = 0;
            int end = 0;
            if (page + 5 < count) end = page + 5;
            else
            {
                start = (int)count - 11;
                end = (int)count - 1;
            }
            if (page - 5 < 0)
            {
                start = 0;
                end = 10;
            }
            else if(start ==0 ) start = page - 5;


            for (int i = start; i <= end; i++)
            {
                addBtn(i, idCategory);
            }
            //last button, go to last page
            Button lBtn = new Button();
            lBtn.PostBackUrl = "Search.aspx?id=" + idCategory + "&" + "page=" + (count - 1);
            lBtn.Text = ">>";
            lBtn.Attributes.Add("Class", "btn btn-primary");
            pageButtonsPH.Controls.Add(lBtn);
        }

        private void addBtn(int i, int idCategory)
        {
            Button btn = new Button();
            btn.Width = 40;
            btn.PostBackUrl = "Search.aspx?id=" + idCategory + "&" + "page=" + i;
            btn.Text = "" + (i + 1);
            btn.Attributes.Add("Class", "btn btn-primary");
            pageButtonsPH.Controls.Add(btn);
        }
        
    }
}