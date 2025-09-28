using System.Globalization;
using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI;

public partial class EditOrderForm : Form
{
    private readonly OrderService _orderService;
    private readonly CustomerService _customerService;
    private readonly OrderDTO? _order;

    private List<CustomerDTO> _customers = new List<CustomerDTO>();

    public EditOrderForm(OrderService orderService, CustomerService customerService, OrderDTO? order = null)
    {
        _orderService = orderService;
        _customerService = customerService;
        _order = order;

        InitializeComponent();
        FiilCustomersListBox();

        if (order != null)
        {
            int index = _customers.FindIndex(c => c.Id == order.CustomerId);
            if (index != -1)
            {
                customersComboBox.SelectedIndex = index;
            }
            else
            {
                CustomerDTO? customer = customerService.GetById(order.CustomerId).Value;
                if (customer != null)
                {
                    _customers.Add(customer);
                    customersComboBox.Items.Add(customer.CompanyName);
                    customersComboBox.SelectedIndex = customersComboBox.Items.Count - 1;
                }
            }

            Text = "Редактирование заказа";
            numberTextBox.Text = order.Number;
            thicknessTextBox.Text = order.PlateThickness.ToString("F2", CultureInfo.InvariantCulture);
            widthTextBox.Text = order.PlateWidth.ToString();
            lengthTextBox.Text = order.PlateLength.ToString();
            steelGradeTextBox.Text = order.SteelGrade;
        }
        else
        {
            Text = "Новый заказ";
            customersComboBox.SelectedIndex = customersComboBox.Items.Count - 1;
        }
    }

    private void FiilCustomersListBox()
    {
        _customers.AddRange(_customerService.GetAll());
        foreach (CustomerDTO customer in _customers)
        {
            customersComboBox.Items.Add(customer.CompanyName);
        }
    }

    private void okButton_Click(object sender, EventArgs e)
    {
        Result result;

        float thickness;
        int width;
        int length;

        float.TryParse(thicknessTextBox.Text, CultureInfo.InvariantCulture, out thickness);
        int.TryParse(widthTextBox.Text, out width);
        int.TryParse(lengthTextBox.Text, out length);

        if (_order == null)
        {
            CreateOrderDTO orderForCreate = new CreateOrderDTO()
            {
                Number = numberTextBox.Text,
                CustomerId = _customers[customersComboBox.SelectedIndex].Id,
                PlateThickness = thickness,
                PlateWidth = width,
                PlateLength = length,
                SteelGrade = steelGradeTextBox.Text
            };

            result = _orderService.CreateOrder(orderForCreate);
        }
        else
        {
            _order.Number = numberTextBox.Text;
            _order.CustomerId = _customers[customersComboBox.SelectedIndex].Id;
            _order.PlateThickness = thickness;
            _order.PlateWidth = width;
            _order.PlateLength = length;
            _order.SteelGrade = steelGradeTextBox.Text;
            result = _orderService.UpdateOrder(_order);
        }

        if (result.IsSuccess)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        errorLabel.Text = result.Error.Description;
    }
}
