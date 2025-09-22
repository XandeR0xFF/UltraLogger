using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using UltraLogger.Core.Application.DTOs;
using UltraLogger.Core.Application.Services;

namespace UltraLogger.UI
{
    public partial class UTLogControl : UserControl
    {
        private readonly DefectogramService _defectogramService;

        private List<DefectogramDTO> _defectograms = new List<DefectogramDTO>();

        public UTLogControl(DefectogramService defectogramService)
        {
            _defectogramService = defectogramService;
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
                listViewItem.SubItems.Add($"{defectogram.Thickness:F2} x {defectogram.Width} x {defectogram.Length}");
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
                foreach (var platePart in defectogram.Plate.Parts)
                {
                    content.AppendLine($"{defectogram.Plate.MeltYear}-{defectogram.Plate.MeltNumber}-{defectogram.Plate.SlabNumber}-{platePart.Number}: {platePart.Evaluation?.Name}");
                }
            }
            

            entryDetails.Text = content.ToString();
        }
    }
}
