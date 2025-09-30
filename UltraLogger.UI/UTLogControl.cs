using System.Globalization;
using System.Text;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI;

public partial class UTLogControl : UserControl
{
    private readonly DefectogramService _defectogramService;
    private readonly AuthenticationService _authenticationService;
    private readonly PlateService _plateService;
    private readonly UserService _userService;
    private readonly ReportService _reportService;
    private readonly OrderService _orderService;
    private readonly CustomerService _customerService;

    public UTLogControl(
        DefectogramService defectogramService,
        AuthenticationService authenticationService,
        PlateService plateService,
        UserService userService,
        ReportService reportService,
        OrderService orderService,
        CustomerService customerService)
    {
        _defectogramService = defectogramService;
        _authenticationService = authenticationService;
        _plateService = plateService;
        _userService = userService;
        _reportService = reportService;
        _orderService = orderService;
        _customerService = customerService;
        InitializeComponent();
    }

    private void UTLogControl_Load(object sender, EventArgs e)
    {
        UpdateData();
    }

    private void UpdateData()
    {
        entriesList.Items.Clear();
        entryDetails.Text = string.Empty;

        IEnumerable<DefectogramDTO> defectograms = _defectogramService.GetAll();
        IEnumerable<USTModeDTO> ustModes = _defectogramService.GetUSTModes();

        foreach (DefectogramDTO defectogram in defectograms)
        {
            PlateDTO? plate = _plateService.GetForDefectogram(defectogram.Id).Value;
            USTModeDTO mode = ustModes.First(m => m.Id == defectogram.UstModeId);

            ListViewItem listViewItem = entriesList.Items.Add(defectogram.Name);
            listViewItem.Tag = defectogram;
            listViewItem.SubItems.Add(defectogram.CreatedAt.ToString("g"));
            listViewItem.SubItems.Add(mode.Name);
            listViewItem.SubItems.Add($"{defectogram.Thickness.ToString("F2", CultureInfo.InvariantCulture)} x {defectogram.Width} x {defectogram.Length}");
            if (plate != null)
            {
                listViewItem.SubItems.Add($"{plate.MeltYear}-{plate.MeltNumber}-{plate.SlabNumber}");
            }
        }
    }

    private void entriesList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (entriesList.SelectedItems.Count > 0)
        {
            DefectogramDTO selectedDefectogram = (DefectogramDTO)entriesList.SelectedItems[0].Tag!;
            PlateDTO? plate = _plateService.GetForDefectogram(selectedDefectogram.Id).Value;
            UserDTO? creator = _userService.GetById(selectedDefectogram.UserId).Value;

            StringBuilder content = new StringBuilder();
            content.AppendLine($"{selectedDefectogram.Name}");
            content.AppendLine();
            content.AppendLine($"Дефектоскопист: {creator?.LastName} {creator?.FirstName} {creator?.MiddleName}");
            content.AppendLine();

            if (plate != null)
            {
                IEnumerable<EvaluationDTO> evaluations = _plateService.GetEvaluations();

                int i = 0;
                foreach (PlatePartDTO platePart in plate.Parts)
                {
                    EvaluationDTO? evaluation = platePart.InspectionResult != null ? evaluations.First(e => e.Id == platePart.InspectionResult.EvaluationId) : null;

                    content.AppendLine($"{++i}: {plate.MeltYear}-{plate.MeltNumber}-{plate.SlabNumber}-{platePart.Number}: {evaluation?.Name}");
                    content.AppendLine($"   Размер: {platePart.Width}x{platePart.Length}");
                    content.AppendLine($"   X: {platePart.X}мм");
                    content.AppendLine($"   Y: {platePart.Y}мм");
                }
                content.AppendLine();
                content.AppendLine();
                if (plate.ReportId != null)
                {
                    content.AppendLine($"Отчет: {plate.ReportId.Value}");
                }
            }
            entryDetails.Text = content.ToString();
        }
    }

    private void entriesList_Resize(object sender, EventArgs e)
    {
        entriesList.Columns[entriesList.Columns.Count - 1].Width = -2;
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        EditDefectogramForm form = new EditDefectogramForm(_defectogramService, _plateService, _authenticationService);
        if (form.ShowDialog() == DialogResult.OK)
            UpdateData();
    }

    private void deleteButton_Click(object sender, EventArgs e)
    {
        if (entriesList.SelectedItems.Count > 0)
        {
            DefectogramDTO selectedDefectogram = (DefectogramDTO)entriesList.SelectedItems[0].Tag!;
            if (_defectogramService.DeleteDefectogram(selectedDefectogram.Id).IsSuccess)
                UpdateData();
        }
    }

    private void addToReport_Click(object sender, EventArgs e)
    {
        if (entriesList.SelectedItems.Count > 0)
        {
            DefectogramDTO selectedDefectogram = (DefectogramDTO)entriesList.SelectedItems[0].Tag!;
            PlateDTO? plate = _plateService.GetForDefectogram(selectedDefectogram.Id).Value;
            if (plate != null)
            {
                AddToReportForm form = new AddToReportForm(_reportService, _plateService, _orderService, _customerService, plate);
                if (form.ShowDialog() == DialogResult.OK)
                    UpdateData();
            }
        }
    }

    private void removeFromReport_Click(object sender, EventArgs e)
    {
        if (entriesList.SelectedItems.Count > 0)
        {
            DefectogramDTO selectedDefectogram = (DefectogramDTO)entriesList.SelectedItems[0].Tag!;
            PlateDTO? plate = _plateService.GetForDefectogram(selectedDefectogram.Id).Value;
            if (plate != null)
            {
                plate.ReportId = null;
                if (_plateService.UpdatePlate(plate).IsSuccess)
                    UpdateData();
            }
        }
    }
}
