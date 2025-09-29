using System.Globalization;
using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI;

public partial class EditReportForm : Form
{
    private readonly ReportService _reportService;
    private readonly OrderService _orderService;
    private readonly CustomerService _customerService;

    private readonly ReportDTO? _report;

    private readonly List<OrderDTO> _orders;
    private readonly Dictionary<long, CustomerDTO> _customers = new Dictionary<long, CustomerDTO>();

    public EditReportForm(ReportService reportService, OrderService orderService, CustomerService customerService, ReportDTO? report = null)
    {
        _reportService = reportService;
        _orderService = orderService;
        _customerService = customerService;
        _report = report;
        _orders = [.. _orderService.GetAll()];

        InitializeComponent();
        FillOrdersList();

        if (_report == null)
        {
            Text = "Новый отчет";
            if (orderComboBox.Items.Count > 0)
                orderComboBox.SelectedIndex = 0;
        }
        else
        {
            Text = "Изменение отчета";
            int index = _orders.FindIndex(o => o.Id == _report.OrderId);
            if (index == -1)
            {
                OrderDTO? order = _orderService.GetById(_report.OrderId).Value;
                if (order != null)
                {
                    _orders.Add(order);
                    orderComboBox.Items.Add(order.Number);
                    orderComboBox.SelectedIndex = orderComboBox.Items.Count - 1;
                }
            }
            else
            {
                orderComboBox.SelectedIndex = index;
            }
        }
    }

    private void FillOrdersList()
    {
        foreach (var order in _orders)
        {
            orderComboBox.Items.Add(order.Number);
        }
    }

    private void orderComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        OrderDTO order = _orders[orderComboBox.SelectedIndex];
        CustomerDTO? customer = _customers.GetValueOrDefault(order.CustomerId);
        if (customer == null)
        {
            customer = _customerService.GetById(order.CustomerId).Value;
            if (customer != null)
                _customers.Add(customer.Id, customer);
        }

        customerLabel.Text = customer?.CompanyName;
        steelGradeLabel.Text = order.SteelGrade;
        dimensionsLabel.Text = $"{order.PlateThickness.ToString("F2", CultureInfo.InvariantCulture)} x {order.PlateWidth} x {order.PlateLength}";
    }

    private void okButton_Click(object sender, EventArgs e)
    {
        OrderDTO selectedOrder = _orders[orderComboBox.SelectedIndex];

        Result result;
        if (_report == null)
        {
            CreateReportDTO reportForCreate = new CreateReportDTO() { OrderId = selectedOrder.Id };
            result = _reportService.CreateReport(reportForCreate);
        }
        else
        {
            _report.OrderId = selectedOrder.Id;
            result = _reportService.UpdateReport(_report);
        }

        if (result.IsSuccess)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
