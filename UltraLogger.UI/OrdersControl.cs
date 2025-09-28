using System.Globalization;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI
{
    public partial class OrdersControl : UserControl
    {
        private readonly OrderService _orderService;
        private readonly CustomerService _customerService;

        private readonly Dictionary<long, CustomerDTO> cusomersDictionary = new Dictionary<long, CustomerDTO>();

        public OrdersControl(OrderService orderService, CustomerService customerService)
        {
            _orderService = orderService;
            _customerService = customerService;
            InitializeComponent();
        }

        private void OrdersControl_Load(object sender, EventArgs e)
        {
            UpdateData();
        }

        private void UpdateData()
        {
            ordersListView.Items.Clear();

            IEnumerable<OrderDTO> orders = _orderService.GetAll();
            foreach (OrderDTO order in orders)
            {
                CustomerDTO? customer = cusomersDictionary.GetValueOrDefault(order.CustomerId);
                if (customer == null)
                {
                    var result = _customerService.GetById(order.CustomerId);
                    if (result.IsSuccess)
                    {
                        customer = result.Value;
                        if (customer != null)
                            cusomersDictionary.Add(order.CustomerId, customer);
                    }
                }

                var item = ordersListView.Items.Add(order.Number);
                item.Tag = order;
                item.SubItems.Add(customer?.CompanyName);
                item.SubItems.Add(order.SteelGrade);
                item.SubItems.Add($"{order.PlateThickness.ToString("F2", CultureInfo.InvariantCulture)} x {order.PlateWidth} x {order.PlateLength}");
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            EditOrderForm form = new EditOrderForm(_orderService, _customerService);
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateData();
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (ordersListView.SelectedItems.Count > 0)
            {
                OrderDTO selectedOrder = (OrderDTO)ordersListView.SelectedItems[0].Tag!;
                EditOrderForm form = new EditOrderForm(_orderService, _customerService, selectedOrder);
                if (form.ShowDialog() == DialogResult.OK)
                {
                    UpdateData();
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (ordersListView.SelectedItems.Count > 0)
            {
                OrderDTO selectedOrder = (OrderDTO)ordersListView.SelectedItems[0].Tag!;
                if (_orderService.DeleteOrder(selectedOrder.Id).IsSuccess)
                    UpdateData();
            }
        }
    }
}
