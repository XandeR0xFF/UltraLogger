using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI;

public partial class CustomersControl : UserControl
{
    private readonly CustomerService _customerService;

    public CustomersControl(CustomerService customerService)
    {
        _customerService = customerService;
        InitializeComponent();
    }

    private void CustomersControl_Load(object sender, EventArgs e)
    {
        UpdateData();
    }

    private void UpdateData()
    {
        var customers = _customerService.GetAll();
        customersListView.Items.Clear();
        descriptionLabel.Text = string.Empty;

        foreach (CustomerDTO customer in customers)
        {
            ListViewItem item = customersListView.Items.Add(customer.CompanyName);
            item.Tag = customer;
        }
    }

    private void customersListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (customersListView.SelectedItems.Count > 0)
        {
            descriptionLabel.Text = ((CustomerDTO)customersListView.SelectedItems[0].Tag!).Description;
        }
        else
        {
            descriptionLabel.Text = string.Empty;
        }
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        EditCustomerForm form = new EditCustomerForm(_customerService);
        if (form.ShowDialog() == DialogResult.OK)
            UpdateData();
    }

    private void editButton_Click(object sender, EventArgs e)
    {
        if (customersListView.SelectedItems.Count == 0)
            return;

        CustomerDTO customerForEdit = ((CustomerDTO)customersListView.SelectedItems[0].Tag!);
        EditCustomerForm form = new EditCustomerForm(_customerService, customerForEdit);

        if (form.ShowDialog() == DialogResult.OK)
            UpdateData();
    }

    private void deleteButton_Click(object sender, EventArgs e)
    {
        if (customersListView.SelectedItems.Count == 0)
            return;

        long idForDelete = ((CustomerDTO)customersListView.SelectedItems[0].Tag!).Id;
        if (_customerService.DeleteCustomer(idForDelete).IsSuccess)
            UpdateData();
    }
}
