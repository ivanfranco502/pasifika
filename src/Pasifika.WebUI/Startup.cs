﻿using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pasifika.WebUI
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}