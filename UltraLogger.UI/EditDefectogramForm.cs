using System.Globalization;
using UltraLogger.Core.Application.Common.ResultPattern;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI;

public partial class EditDefectogramForm : Form
{
    private readonly DefectogramService _defectogramService;
    private readonly PlateService _plateService;
    private readonly DefectogramDTO? _defectogram;
    private readonly AuthenticationService _authenticationService;

    private readonly List<USTModeDTO> _modes;
    private readonly List<EvaluationDTO> _evaluations;
    private readonly List<PlatePartDTO> _plateParts;

    private bool isUserInput = true;

    public EditDefectogramForm(DefectogramService defectogramService, PlateService plateService, AuthenticationService authenticationService, DefectogramDTO? defectogram = null)
    {
        _defectogramService = defectogramService;
        _plateService = plateService;
        _defectogram = defectogram;
        _authenticationService = authenticationService;

        _modes = [.. _defectogramService.GetUSTModes()];
        _evaluations = [.. _plateService.GetEvaluations()];

        InitializeComponent();
        FillUSTModes();
        FillEvaluations();

        if (_defectogram != null)
        {
            Text = "Изменение дефектограммы";

            _plateParts = new List<PlatePartDTO>(); //!!! 
        }
        else
        {
            Text = "Новая дефектограмма";
            ustModesComboBox.SelectedIndex = 0;
            evaluationsComboBox.SelectedIndex = -1;

            _plateParts = new List<PlatePartDTO>();
        }

        UpdateEnableStatePlateControls();
        UpdateEnableStatePlatePartControls();
    }

    private void FillUSTModes()
    {
        foreach (USTModeDTO mode in _modes)
        {
            ustModesComboBox.Items.Add(mode.Name);
        }
    }

    private void FillEvaluations()
    {
        foreach (EvaluationDTO evaluation in _evaluations)
        {
            evaluationsComboBox.Items.Add(evaluation.Name);
        }
    }

    private void UpdateEnableStatePlateControls()
    {
        meltYearTextBox.Enabled = plateDataCheckBox.Checked;
        meltNumberTextBox.Enabled = plateDataCheckBox.Checked;
        slabNuberTextBox.Enabled = plateDataCheckBox.Checked;
        platePartsListView.Enabled = plateDataCheckBox.Checked;
        addPlatePartButton.Enabled = plateDataCheckBox.Checked;
    }

    private void UpdateEnableStatePlatePartControls()
    {
        bool isEnabled = platePartsListView.SelectedItems.Count > 0;
        platePartNumberTextBox.Enabled = isEnabled;
        platePartLengthTextBox.Enabled = isEnabled;
        platePartWidthTextBox.Enabled = isEnabled;
        platePartXTextBox.Enabled = isEnabled;
        platePartYTextBox.Enabled = isEnabled;
        evaluationsComboBox.Enabled = isEnabled;
        deletePlatePartButon.Enabled = isEnabled;
    }

    private void UpdatePlatePartsList()
    {
        platePartsListView.Items.Clear();

        foreach (PlatePartDTO platePart in _plateParts)
        {
            ListViewItem item = platePartsListView.Items.Add(platePart.Number.ToString());
            EvaluationDTO? plateEvaluation = platePart.InspectionResult != null ? _evaluations.Find(x => x.Id == platePart.InspectionResult.EvaluationId) : null;

            item.Tag = platePart;
            item.SubItems.Add($"{platePart.Width} x {platePart.Length}");
            item.SubItems.Add($"{plateEvaluation?.Name}");
        }
    }

    private void plateDataCheckBox_CheckedChanged(object sender, EventArgs e)
    {
        UpdateEnableStatePlateControls();
    }

    private void addPlatePartButton_Click(object sender, EventArgs e)
    {
        PlatePartDTO newPlatePart = new PlatePartDTO() { Number = _plateParts.Count + 1 };
        _plateParts.Add(newPlatePart);

        UpdatePlatePartsList();
    }

    private void buttonOk_Click(object sender, EventArgs e)
    {
        float defectogramThickness;
        int defectogramWidth;
        int defectogramLength;

        float.TryParse(thicknessTextBox.Text, CultureInfo.InvariantCulture, out defectogramThickness);
        int.TryParse(widthTextBox.Text, out defectogramWidth);
        int.TryParse(lengthTextBox.Text, out defectogramLength);

        USTModeDTO selectedMode = _modes[ustModesComboBox.SelectedIndex];

        Result result;
        if (_defectogram == null)
        {
            CreateDefectogramDTO defectogramForCreate = new CreateDefectogramDTO()
            {
                CreatedAt = dateTimePicker.Value,
                Length = defectogramLength,
                Thickness = defectogramThickness,
                Width = defectogramWidth,
                Name = defectogramNumberTextBox.Text,
                UstModeId = selectedMode.Id,
                UserId = _authenticationService.GetCurrentUser().Value!.Id
            };

            long newDefectogramId = _defectogramService.CreateDefectogram(defectogramForCreate).Value;

            if (plateDataCheckBox.Checked)
            {
                int meltYear;
                int meltNumber;
                int slabNumber;

                int.TryParse(meltYearTextBox.Text, out meltYear);
                int.TryParse(meltNumberTextBox.Text, out meltNumber);
                int.TryParse(slabNuberTextBox.Text, out slabNumber);

                CreatePlateDTO plateForCreate = new CreatePlateDTO()
                {
                    DefectogramId = newDefectogramId,
                    MeltNumber = meltNumber,
                    MeltYear = meltYear,
                    SlabNumber = slabNumber
                };

                plateForCreate.Parts = _plateParts;

                _plateService.CreatePlate(plateForCreate);
            }

            result = Result.Success();
        }
        else
        {
            result = Result.Success();
        }

        if (result.IsSuccess)
        {
            DialogResult = DialogResult.OK;
            Close();
        }

    }

    private void platePartsListView_SelectedIndexChanged(object sender, EventArgs e)
    {
        UpdateEnableStatePlatePartControls();
        isUserInput = false;
        if (platePartsListView.SelectedItems.Count > 0)
        {
            PlatePartDTO selectedPlatePart = (PlatePartDTO)platePartsListView.SelectedItems[0].Tag!;
            int evaluationIndex = selectedPlatePart.InspectionResult != null ? _evaluations.FindIndex(x => x.Id == selectedPlatePart.InspectionResult.EvaluationId) : -1;

            platePartNumberTextBox.Text = selectedPlatePart.Number.ToString();
            platePartLengthTextBox.Text = selectedPlatePart.Length.ToString();
            platePartWidthTextBox.Text = selectedPlatePart.Width.ToString();
            platePartXTextBox.Text = selectedPlatePart.X.ToString();
            platePartYTextBox.Text = selectedPlatePart.Y.ToString();
            evaluationsComboBox.SelectedIndex = evaluationIndex;
        }
        else
        {
            platePartNumberTextBox.Text = string.Empty;
            platePartLengthTextBox.Text = string.Empty;
            platePartWidthTextBox.Text = string.Empty;
            platePartXTextBox.Text = string.Empty;
            platePartYTextBox.Text = string.Empty;
            evaluationsComboBox.SelectedIndex = -1;
        }
        isUserInput = true;
    }

    private void platePartsControlsChangeValue(object sender, EventArgs e)
    {
        if (!isUserInput)
            return;

        if (platePartsListView.SelectedItems.Count > 0)
        {
            PlatePartDTO selectedPlatePart = (PlatePartDTO)platePartsListView.SelectedItems[0].Tag!;

            int platePartNumber;
            int platePartLength;
            int platePartWidth;
            int platePartX;
            int platePartY;

            int.TryParse(platePartNumberTextBox.Text, out platePartNumber);
            int.TryParse(platePartLengthTextBox.Text, out platePartLength);
            int.TryParse(platePartWidthTextBox.Text, out platePartWidth);
            int.TryParse(platePartXTextBox.Text, out platePartX);
            int.TryParse(platePartYTextBox.Text, out platePartY);

            selectedPlatePart.Number = platePartNumber;
            selectedPlatePart.Length = platePartLength;
            selectedPlatePart.Width = platePartWidth;
            selectedPlatePart.X = platePartX;
            selectedPlatePart.Y = platePartY;

            if (evaluationsComboBox.SelectedIndex == -1)
            {
                selectedPlatePart.InspectionResult = null;
            }
            else
            {
                long userId = _authenticationService.GetCurrentUser().Value!.Id;
                EvaluationDTO selectedEvaluation = _evaluations[evaluationsComboBox.SelectedIndex];
                selectedPlatePart.InspectionResult = new InspectionResultDTO()
                {
                    Id = 0,
                    CreatedAt = DateTime.Now,
                    UserId = userId,
                    EvaluationId = selectedEvaluation.Id
                };
            }


            EvaluationDTO? evaluation = selectedPlatePart.InspectionResult != null ?_evaluations.Find(x => x.Id == selectedPlatePart.InspectionResult.EvaluationId) : null;

            var item = platePartsListView.SelectedItems[0];
            item.Text = selectedPlatePart.Number.ToString();
            item.SubItems[1].Text = $"{selectedPlatePart.Width} x {selectedPlatePart.Length}";
            item.SubItems[2].Text = evaluation?.Name;
        }
    }
}

