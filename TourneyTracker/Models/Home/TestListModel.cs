using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TourneyTracker.Models.Home
{
    public class TestListModel
    {
        public List<TestListModelItem> List {get;set;}

        public TestListModel()
        {
            List = new List<TestListModelItem>();
        }
    }
}