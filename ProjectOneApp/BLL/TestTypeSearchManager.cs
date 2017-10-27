using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjectArnobApp.DAL;
using ProjectArnobApp.Models.ViewModels;

namespace ProjectArnobApp.BLL
{
    public class TestTypeSearchManager
    {
        TestTypeSearchGateway _testTypeSearchGateway = new TestTypeSearchGateway();

        public List<TestTypeSearchViewModel> GetAllTestNameInformation()
        {
            return _testTypeSearchGateway.GetAllTestNameInformation();
        }
        public List<TestTypeSearchViewModel> GetAll()
        {
            return _testTypeSearchGateway.GetAll();
        }
        public double GetTotalForAll()
        {
            return _testTypeSearchGateway.GetTotalForAll();
        }

        public double GetTotal()
        {
            return _testTypeSearchGateway.GetTotal();
        }

        public void CreateView(DateTime from, DateTime to)
        {
            _testTypeSearchGateway.CreateView(from, to);
        }

        public void DropView()
        {
            _testTypeSearchGateway.DropView();
        }
    }
}