using System.Globalization;
using System.Text;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI;

public partial class UTLogControl : UserControl
{
    private readonly DefectogramService _defectogramService;
    private readonly AuthenticationService _authenticationService;

    private List<DefectogramDTO> _defectograms = new List<DefectogramDTO>();

    public UTLogControl(DefectogramService defectogramService, AuthenticationService authenticationService)
    {
        _defectogramService = defectogramService;
        _authenticationService = authenticationService;
        InitializeComponent();
    }

    private void UTLogControl_Load(object sender, EventArgs e)
    {
        UpdateData();
    }

    private void entriesList_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (entriesList.SelectedIndices.Count == 0)
            return;

        UpdateEntryDetails(entriesList.SelectedIndices[0]);

    }

    private void UpdateData()
    {
        entriesList.Items.Clear();
        entryDetails.Text = string.Empty;
        _defectograms.Clear();

        _defectograms.AddRange(_defectogramService.GetAll());

        foreach (DefectogramDTO defectogram in _defectograms)
        {
            ListViewItem listViewItem = new ListViewItem();

            listViewItem.Text = defectogram.Name;
            listViewItem.SubItems.Add(defectogram.CreatedAt.ToString("g"));
            listViewItem.SubItems.Add(defectogram.UstMode?.Name);
            listViewItem.SubItems.Add($"{defectogram.Thickness.ToString("F2", CultureInfo.InvariantCulture)} x {defectogram.Width} x {defectogram.Length}");
            if (defectogram.Plate != null)
            {
                listViewItem.SubItems.Add($"{defectogram.Plate.MeltYear}-{defectogram.Plate.MeltNumber}-{defectogram.Plate.SlabNumber}");
            }


            entriesList.Items.Add(listViewItem);
        }

    }

    private void UpdateEntryDetails(int entryIndex)
    {
        DefectogramDTO defectogram = _defectograms[entryIndex];

        StringBuilder content = new StringBuilder();

        content.AppendLine($"{defectogram.Name}");
        content.AppendLine();
        content.AppendLine($"Дефектоскопист: {defectogram.Creator?.LastName} {defectogram.Creator?.FirstName} {defectogram.Creator?.MiddleName}");
        content.AppendLine();

        if (defectogram.Plate != null)
        {
            int i = 0;
            foreach (var platePart in defectogram.Plate.Parts)
            {
                content.AppendLine($"{++i}: {defectogram.Plate.MeltYear}-{defectogram.Plate.MeltNumber}-{defectogram.Plate.SlabNumber}-{platePart.Number}: {platePart.Evaluation?.Name}");
                content.AppendLine($"   Размер: {platePart.Width}x{platePart.Length}");
                content.AppendLine($"   X: {platePart.X}мм");
                content.AppendLine($"   Y: {platePart.Y}мм");
            }
        }


        entryDetails.Text = content.ToString();
    }

    private void entriesList_Resize(object sender, EventArgs e)
    {
        entriesList.Columns[entriesList.Columns.Count - 1].Width = -2;
    }

    private void addButton_Click(object sender, EventArgs e)
    {
        EditDefectogramForm form = new EditDefectogramForm();
        form.USTModes.AddRange(_defectogramService.GetUSTModes());
        form.Evaluations.AddRange(_defectogramService.GetEvaluations());
        form.CurentUserId = _authenticationService.GetCurrentUser().Value!.Id;
        if (form.ShowDialog() == DialogResult.OK && form.CreateDTO != null)
        {
            _defectogramService.CreateDefectogram(form.CreateDTO);
        }
        UpdateData();
    }
}
