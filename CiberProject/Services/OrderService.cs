using CiberProject.Models.ModelView;
using PAKNAPI.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CiberProject.Services
{

    public interface IOrderService {
        public Task<OrderModelResponse> getListOrder(string keySearch, int? orderBy, int? pageSize, int pageIndex);
    }

    public class OrderService : IOrderService
    {
        private readonly IAppSetting _appSetting;
        public OrderService(IAppSetting appSetting) {
            _appSetting = appSetting;
        }

        public async Task<OrderModelResponse> getListOrder(string keySearch, int? orderBy = 0, int? pageSize = 2, int pageIndex = 1) {

            OrderModelResponse response = new OrderModelResponse() {
                listOrder = await new OrderModelView(_appSetting).GetListOrder(keySearch, orderBy, pageSize, pageIndex),
                dropDownCustomer = await new DropDown(_appSetting).GetDropDownCustomer(),
                dropDownProduct = await new DropDown(_appSetting).GetDropDownProduct(),
                orderBy = orderBy,
                pageSize = pageSize,
                pageIndex = pageIndex
            };

            response.rowNumber = response.listOrder.Count() == 0 ? 0 : response.listOrder[0].RowNumber;
            return response;
        }
    }
}
