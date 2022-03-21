using CiberProject.Models.Entity;
using Dapper;
using PAKNAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiberProject.Models.ModelView
{
    public class OrderModelView : Order
    {
        public OrderModelView(IAppSetting appSetting)
        {
            _sQLCon = new SQLCon(appSetting.GetConnectstring());
        }

        public OrderModelView()
        {
        }


        private SQLCon _sQLCon;
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CustomerName { get; set; }
        public int? RowNumber { get; set; }


        public async Task<List<OrderModelView>> GetListOrder(string keySearch, int? orderBy, int? pageSize, int pageIndex)
        {
            DynamicParameters dp = new DynamicParameters();
            dp.Add("KeySearch", keySearch);
            dp.Add("orderBy", orderBy);
            dp.Add("PageSize", pageSize);
            dp.Add("PageIndex", pageIndex);

            return (await _sQLCon.ExecuteListDapperAsync<OrderModelView>("OrderGetList", dp)).ToList();
        }
    }

    public class OrderModelResponse {
        public List<OrderModelView> listOrder { get; set; }
        public List<DropDown> dropDownProduct { get; set; }
        public List<DropDown> dropDownCustomer { get; set; }

        public int? rowNumber { get; set; }
        public int? orderBy { get; set; }
        public int? pageSize { get; set; }
        public int? pageIndex { get; set; }
    }

    public class DropDown
    {
        private SQLCon _sQLCon;
        public int? Value { get; set; }
        public string Text { get; set; }


        public DropDown(IAppSetting appSetting)
        {
            _sQLCon = new SQLCon(appSetting.GetConnectstring());
        }

        public DropDown() { }

        public async Task<List<DropDown>> GetDropDownProduct()
        {
            DynamicParameters dp = new DynamicParameters();

            return (await _sQLCon.ExecuteListDapperAsync<DropDown>("GetDropDownProduct", dp)).ToList();
        }

        public async Task<List<DropDown>> GetDropDownCustomer()
        {
            DynamicParameters dp = new DynamicParameters();

            return (await _sQLCon.ExecuteListDapperAsync<DropDown>("GetDropDownCustomer", dp)).ToList();
        }

    }
}
