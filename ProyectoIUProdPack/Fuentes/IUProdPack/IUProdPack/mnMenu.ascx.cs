﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace IUProdPack
{
    public partial class mnMenu : System.Web.UI.UserControl
    {
        protected HttpApplication ApplicationInstance
        {
            get
            {
                return this.Context.ApplicationInstance;
            }
        }

        public mnMenu()
        {
        }

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}