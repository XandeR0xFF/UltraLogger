using System.Globalization;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI;

public partial class AddToReportForm : Form
{
    private readonly ReportService _reportService;
    private readonly PlateService _plateService;
    private readonly OrderService _orderService;
    private readonly CustomerService _customerService;

    private readonly PlateDTO _plate;
    private readonly List<ReportDTO> _reports;

    public AddToReportForm(
        ReportService reportService,
        PlateService plateService,
        OrderService orderService,
        CustomerService customerService, PlateDTO plate)
    {
        _reportService = reportService;
        _plateService = plateService;
        _orderService = orderService;
        _customerService = customerService;

        _plate = plate;
        InitializeComponent();

        _reports = [.. _reportService.GetOpen()];
        FillReportsList();
        okButton.Enabled = false;
    }

    private void FillReportsList()
    {
        foreach (var report in _reports)
        {
            reportsComboBox.Items.Add(report.Id);
        }
    }

    private void reportsComboBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (reportsComboBox.SelectedIndex != -1)
        {
            okButton.Enabled = true;
            ReportDTO selecteReport = _reports[reportsComboBox.SelectedIndex];
            OrderDTO order = _orderService.GetById(selecteReport.OrderId).Value!;
            CustomerDTO customer = _customerService.GetById(order.CustomerId).Value!;

            orderLabel.Text = order.Number;
            customerLabel.Text = customer.CompanyName;
            steelGradeLabel.Text = order.SteelGrade;
            sizeLabel.Text = $"{order.PlateThickness.ToString("F2", CultureInfo.InvariantCulture)} x {order.PlateWidth} x {order.PlateLength}";
        }
    }

    private void okButton_Click(object sender, EventArgs e)
    {
        ReportDTO selecteReport = _reports[reportsComboBox.SelectedIndex];
        _plate.ReportId = selecteReport.Id;
        if (_plateService.UpdatePlate(_plate).IsSuccess)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
