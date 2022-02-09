using FYP_UOS_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FYP_UOS_2022.Utills
{
    public static class BaseHelper
    {
        public static Examcell CurrentExamCell { get; set; }
        public static Student CurrentStudent { get; internal set; }
        public static Supervisor CurrentSupervisor { get; internal set; }
        public static PMO CurrentPMO { get; internal set; }
    }
}