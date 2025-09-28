using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI;

public partial class EditCustomerForm : Form
{
    private readonly CustomerService _customerService;
    private readonly CustomerDTO? _customerDTO;

    public EditCustomerForm(CustomerService customerService, CustomerDTO? customerDTO = null)
    {
        _customerService = customerService;
        _customerDTO = customerDTO;

        InitializeComponent();

        if (customerDTO == null)
        {
            Text = "Добавить заказчика";
        }
        else
        {
            Text = "Редактировать заказчика";
            companyNameTextBox.Text = customerDTO.CompanyName;
            descriptionTextBox.Text = customerDTO.Description;
        }
    }

    private void okButton_Click(object sender, EventArgs e)
    {
        Result result;
        if (_customerDTO == null)
        {
            CreateCustomerDTO createCustomerDTO = new CreateCustomerDTO() {
                CompanyName = companyNameTextBox.Text,
                Description = descriptionTextBox.Text};
            result = _customerService.CreateCustomer(createCustomerDTO);
        }
        else 
        {
            _customerDTO.CompanyName = companyNameTextBox.Text;
            _customerDTO.Description = descriptionTextBox.Text;
            result =_customerService.UpdateCustomer(_customerDTO);
        }

        if (result.IsSuccess)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

        errorLabel.Text = result.Error.Description;
    }
}
