using System.Globalization;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI;

public partial class ReportsControl : UserControl
{
    private readonly ReportService _reportService;
    private readonly OrderService _orderService;
    private readonly CustomerService _customerService;
    private readonly DefectogramService _defectogramService;
    private readonly PlateService _plateService;

    private readonly Dictionary<long, OrderDTO> _orders = new Dictionary<long, OrderDTO>();
    readonly Dictionary<long, CustomerDTO> _customers = new Dictionary<long, CustomerDTO>();

    public ReportsControl(ReportService reportService,
        OrderService orderService,
        CustomerService customerService,
        DefectogramService defectogramService,
        PlateService plateService)
    {
        _reportService = reportService;
        _orderService = orderService;
        _customerService = customerService;
        _defectogramService = defectogramService;
        _plateService = plateService;

        InitializeComponent();
    }

    private void UpdateReportsList()
    {
        reportsListView.Items.Clear();

        IEnumerable<ReportDTO> reports = _reportService.GetAll();
        foreach (ReportDTO report in reports)
        {
            OrderDTO? order = GetOrder(report.OrderId);
            CustomerDTO? customer = order != null ? GetCustomer(order.CustomerId) : null;

            ListViewItem item = reportsListView.Items.Add(report.Id.ToString());
            item.Tag = report;
            item.SubItems.Add(report.CreatedAt.ToString("G"));
            item.SubItems.Add($"{order?.PlateThickness.ToString("F2", CultureInfo.InvariantCulture)} x {order?.PlateWidth} x {order?.PlateLength}");
            item.SubItems.Add(customer?.CompanyName);
            item.SubItems.Add(report.IsOpen ? "Открыт" : "Закрыт");
        }
    }

    private void UpdatePlatesList(long reportId)
    {
        platesListView.Items.Clear();

        IEnumerable<EvaluationDTO> evaluations = _plateService.GetEvaluations();

        IEnumerable<PlateDTO> plates = _plateService.GetForReport(reportId);
        foreach (PlateDTO plate in plates)
        {
            DefectogramDTO defectogram = _defectogramService.GetById(plate.DefectogramId).Value!;

            foreach (PlatePartDTO platePart in plate.Parts)
            {
                var item = platesListView.Items.Add(defectogram.CreatedAt.ToString("G"));
                item.Tag = plate;
                item.SubItems.Add($"{plate.MeltYear}-{plate.MeltNumber}-{plate.SlabNumber}-{platePart.Number.ToString("D4")}");

                if (platePart.InspectionResult != null)
                {
                    EvaluationDTO evaluation = evaluations.First(e => e.Id == platePart.InspectionResult.EvaluationId);
                    item.SubItems.Add(evaluation.Name);
                }
            }
        }
    }

    private OrderDTO? GetOrder(long orderId)
    {
        OrderDTO? order = _orders.GetValueOrDefault(orderId);
        if (order == null)
        {
            order = _orderService.GetById(orderId).Value;
            if (order != null)
            {
                _orders.Add(order.Id, order);
            }
        }
        return order;
    }

    private CustomerDTO? GetCustomer(long customerId)
    {
        CustomerDTO? customer = _customers.GetValueOrDefault(customerId);
        if (customer == null)
        {
            customer = _customerService.GetById(customerId).Value;
            if (customer != null)
            {
                _customers.Add(customer.Id, customer);
            }
        }
        return customer;
    }

    private void ReportsControl_Load(object sender, EventArgs e)
    {
        UpdateReportsList();
    }

    private void reportsListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (reportsListView.SelectedItems.Count > 0)
        {
            ReportDTO selectedReport = (ReportDTO)reportsListView.SelectedItems[0].Tag!;
            UpdatePlatesList(selectedReport.Id);
        }
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        EditReportForm form = new EditReportForm(_reportService, _orderService, _customerService);
        if (form.ShowDialog() == DialogResult.OK)
        {
            UpdateReportsList();
        }
    }

    private void editButton_Click(object sender, EventArgs e)
    {
        if (reportsListView.SelectedItems.Count > 0)
        {
            ReportDTO selectedReport = (ReportDTO)reportsListView.SelectedItems[0].Tag!;
            EditReportForm form = new EditReportForm(_reportService, _orderService, _customerService, selectedReport);
            if (form.ShowDialog() == DialogResult.OK)
            {
                UpdateReportsList();
            }
        }
    }

    private void deleteButton_Click(object sender, EventArgs e)
    {
        if (reportsListView.SelectedItems.Count > 0)
        {
            ReportDTO selectedReport = (ReportDTO)reportsListView.SelectedItems[0].Tag!;
            if (_reportService.DeleteReport(selectedReport.Id).IsSuccess)
                UpdateReportsList();
        }
    }

    private void lockButton_Click(object sender, EventArgs e)
    {
        if (reportsListView.SelectedItems.Count > 0)
        {
            ReportDTO selectedReport = (ReportDTO)reportsListView.SelectedItems[0].Tag!;
            selectedReport.IsOpen = !selectedReport.IsOpen;
            if (_reportService.UpdateReport(selectedReport).IsSuccess)
                UpdateReportsList();
        }
    }

    private void removePlate_Click(object sender, EventArgs e)
    {
        if (platesListView.SelectedItems.Count > 0)
        {
            PlateDTO selectedPlate = (PlateDTO)platesListView.SelectedItems[0].Tag!;

            long reportId = selectedPlate.ReportId!.Value;

            selectedPlate.ReportId = null;
            if (_plateService.UpdatePlate(selectedPlate).IsSuccess)
                UpdatePlatesList(reportId);
        }
    }
}
