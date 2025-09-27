using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI
{
    public partial class EditDefectogramForm : Form
    {
        private readonly bool _createdMode;

        private PlateDTO _plateDTO = new PlateDTO();

        private bool _updatingPlatePartControls;

        public EditDefectogramForm()
        {
            _createdMode = true;
            InitializeComponent();
        }

        public List<USTModeDTO> USTModes { get; } = new List<USTModeDTO>();
        public List<PlatePartEvaluationDTO> Evaluations { get; } = new List<PlatePartEvaluationDTO>();
        public long CurentUserId { get; set; }
        public CreateDefectogramDTO? CreateDTO { get; private set; }

        private void EditDefectogramForm_Load(object sender, EventArgs e)
        {

            UpdatePlateDataControlsState();

            if (_createdMode)
            {
                dateTimePicker.Value = DateTime.Now;
                this.Text = "Новая дефектограмма";
            }

            foreach (USTModeDTO mode in USTModes)
            {
                ustModesComboBox.Items.Add(mode.Name);
            }

            foreach (PlatePartEvaluationDTO evaluationDTO in Evaluations)
            {
                utEvaluationsComboBox.Items.Add(evaluationDTO.Name);
            }

            if (ustModesComboBox.Items.Count > 0)
                ustModesComboBox.SelectedIndex = 0;
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            float thickness = default;
            int width = default;
            int length = default;

            float.TryParse(thicknessTextBox.Text, CultureInfo.InvariantCulture, out thickness);
            int.TryParse(widthTextBox.Text, out width);
            int.TryParse(lengthTextBox.Text, out length);

            CreateDTO = new CreateDefectogramDTO()
            {
                CreatedAt = dateTimePicker.Value,
                UstModeId = ustModesComboBox.SelectedIndex + 1,
                Name = defectogramNumberTextBox.Text,
                Thickness = thickness,
                Width = width,
                Length = length,
                UserId = CurentUserId
            };

            if (plateDataCheckBox.Checked)
            {
                int meltYear = default;
                int meltNumber = default;
                int slabNumber = default;

                int.TryParse(meltYearTextBox.Text, out meltYear);
                int.TryParse(meltNumberTextBox.Text, out meltNumber);
                int.TryParse(slabNuberTextBox.Text, out slabNumber);

                _plateDTO.MeltYear = meltYear;
                _plateDTO.MeltNumber = meltNumber;
                _plateDTO.SlabNumber = slabNumber;
                CreateDTO.Plate = _plateDTO;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void plateDataCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdatePlateDataControlsState();
        }

        private void UpdatePlateDataControlsState()
        {
            bool enableState = plateDataCheckBox.Checked;

            meltYearTextBox.Enabled = enableState;
            meltNumberTextBox.Enabled = enableState;
            slabNuberTextBox.Enabled = enableState;
            platesListView.Enabled = enableState;

            UpdatePlatePartControls();
        }

        private void UpdatePlateListViewContent()
        {
            platesListView.Items.Clear();
            foreach (PlatePartDTO partDTO in _plateDTO.Parts)
            {
                var item = platesListView.Items.Add(partDTO.Number.ToString());
                item.Tag = partDTO;
                item.SubItems.Add($"{partDTO.Width} x {partDTO.Length}");
                item.SubItems.Add(partDTO.Evaluation?.Name);
            }
        }

        private void UpdatePlatePartControls()
        {
            _updatingPlatePartControls = true;
            if (platesListView.SelectedItems.Count > 0)
            {
                PlatePartDTO seletedPartDTO = (PlatePartDTO)(platesListView.SelectedItems[0].Tag!);

                platePartNumberTextBox.Text = seletedPartDTO.Number.ToString();
                platePartNumberTextBox.Enabled = true;

                plateWidthTextBox.Text = seletedPartDTO.Width.ToString();
                plateWidthTextBox.Enabled = true;

                plateLengthTextBox.Text = seletedPartDTO.Length.ToString();
                plateLengthTextBox.Enabled = true;

                plateXTextBox.Text = seletedPartDTO.X.ToString(); ;
                plateXTextBox.Enabled = true;

                plateYTextBox.Text = seletedPartDTO.Y.ToString();
                plateYTextBox.Enabled = true;

                if (seletedPartDTO.Evaluation != null)
                {
                    utEvaluationsComboBox.SelectedIndex = (int)(seletedPartDTO.Evaluation.Id - 1);
                }
                else
                {
                    utEvaluationsComboBox.SelectedIndex = -1;
                }
                utEvaluationsComboBox.Enabled = true;
            }
            else
            {
                platePartNumberTextBox.Text = string.Empty;
                platePartNumberTextBox.Enabled = false;

                plateWidthTextBox.Text = string.Empty;
                plateWidthTextBox.Enabled = false;

                plateLengthTextBox.Text = string.Empty;
                plateLengthTextBox.Enabled = false;

                plateXTextBox.Text = string.Empty;
                plateXTextBox.Enabled = false;

                plateYTextBox.Text = string.Empty;
                plateYTextBox.Enabled = false;

                utEvaluationsComboBox.SelectedIndex = -1;
                utEvaluationsComboBox.Enabled = false;
            }
            _updatingPlatePartControls = false;
        }

        private void addPlatePartButton_Click(object sender, EventArgs e)
        {
            PlatePartDTO partForAdd = new PlatePartDTO() { Number = _plateDTO.Parts.Count + 1 };
            _plateDTO.Parts.Add(partForAdd);
            UpdatePlateListViewContent();
            platesListView.SelectedIndices.Add(platesListView.Items.Count - 1);
        }

        private void platesListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            UpdatePlatePartControls();
        }

        private void OnPlatePartsControlValueChanged(object sender, EventArgs e)
        {
            if (_updatingPlatePartControls)
                return;

            if (platesListView.SelectedItems.Count > 0)
            {
                PlatePartDTO seletedPartDTO = (PlatePartDTO)(platesListView.SelectedItems[0].Tag!);

                int partNumber = default;
                int partWidth = default;
                int partLength = default;
                int partX = default;
                int partY = default;

                int.TryParse(platePartNumberTextBox.Text, out partNumber);
                int.TryParse(plateWidthTextBox.Text, out partWidth);
                int.TryParse(plateLengthTextBox.Text, out partLength);
                int.TryParse(plateXTextBox.Text, out partX);
                int.TryParse(plateYTextBox.Text, out partY);

                seletedPartDTO.Number = partNumber;
                seletedPartDTO.Width = partWidth;
                seletedPartDTO.Length = partLength;
                seletedPartDTO.X = partX;
                seletedPartDTO.Y = partY;
                if (utEvaluationsComboBox.SelectedIndex != -1)
                {
                    seletedPartDTO.Evaluation = Evaluations[utEvaluationsComboBox.SelectedIndex];
                }
                else 
                {
                    seletedPartDTO.Evaluation = null;
                }

                platesListView.SelectedItems[0].Text = partNumber.ToString();
                platesListView.SelectedItems[0].SubItems[1].Text = $"{partWidth} x {partLength}";
                platesListView.SelectedItems[0].SubItems[2].Text = seletedPartDTO.Evaluation?.Name ?? string.Empty;
            }
        }
    }
}
