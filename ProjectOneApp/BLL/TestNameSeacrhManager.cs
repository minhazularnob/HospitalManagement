using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectArnobApp.DAL;
using ProjectArnobApp.Models.ViewModels;

namespace ProjectArnobApp.BLL
{
    public class TestNameSeacrhManager
    {
        TestNameSearchGateway _testNameSearchGateway=new TestNameSearchGateway();

        public List<TestNameSearchViewModel> GetAllTestNameInformation()
        {
            return _testNameSearchGateway.GetAllTestNameInformation();
        }

        public List<TestNameSearchViewModel> GetAll()
        {
            return _testNameSearchGateway.GetAll();
        }

        public double GetTotalForAll()
        {
            return _testNameSearchGateway.GetTotalForAll();
        }
        public double GetTotal()
        {
            return _testNameSearchGateway.GetTotal();
        }

        public void CreateView(DateTime from,DateTime to)
        {
            _testNameSearchGateway.CreateView(from,to);
        }

        public void DropView()
        {
            _testNameSearchGateway.DropView();
        }
    }
}