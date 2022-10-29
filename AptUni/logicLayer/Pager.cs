using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace AptUni.logicLayer
{
    public class Pager
    {
        DatabaseConnection DatabaseConnection = new DatabaseConnection();

        // Pager Properties

        public HiddenField TotalPagesHF { get; set; } 

        public int CurrentPage { get; set; }

        public int Counter { get; set; }

        public List<int> Pages { get; set; }

        public Label PaginationLabel { get; set; }

        public void Pagination()
        {
            int totalPages = 4;
            TotalPagesHF.Value = totalPages.ToString();
            Counter++;

            if(CurrentPage < 1)
            {
                CurrentPage = 1;
            }
            else if(CurrentPage > Convert.ToInt32(TotalPagesHF.Value))
            {
                CurrentPage = Convert.ToInt32(TotalPagesHF.Value);
            }

            int startPage, endPage = Convert.ToInt32(TotalPagesHF.Value);

            // Create a list of pages that can be looped over
            
            for(startPage = 1; startPage <= endPage; startPage++)
            {
                Pages.Add(startPage);
            }

            foreach(var Page in Pages)
            {
                PaginationLabel.Text += Page + " ";
            }
        }


    }
}