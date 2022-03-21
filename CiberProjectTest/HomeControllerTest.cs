using CiberProject.Models.ModelView;
using CiberProject.Services;
using Microsoft.Extensions.Configuration;
using PAKNAPI.Common;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace CiberProjectTest
{
    public class HomeControllerTest
    {

        //HomeController _controller;
        IOrderService _orderService;
        IAppSetting _appSetting;
        IConfiguration _config;


        public HomeControllerTest() {

            var inMemorySettings = new Dictionary<string, string>
            {
                {
                    "ConnectionStrings","Server=DESKTOP-R346NSM;Database=Ciber;Trusted_Connection=True; encrypt=true;trustServerCertificate=true"
                },
            };

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(inMemorySettings)
                .Build();

            _appSetting = new AppSetting(configuration);
            _orderService = new OrderService(_appSetting);
        }

        [Fact]
        public async Task GetOrderAsync()
        {

            var result = await _orderService.getListOrder(String.Empty,0,2,1);

            Assert.IsType<OrderModelResponse>(result);

            Assert.IsType<List<OrderModelView>>(result.listOrder);



            var listOrders = result.listOrder as List<OrderModelView>;

            Assert.Equal(2, listOrders.Count);
        }
    }
}
